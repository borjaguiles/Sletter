using NSubstitute;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using LanguageExt;
using ReelWords;
using Xunit;

namespace ReelWordsTests
{
    public class SletterGameShould
    {
        private IGamePrinter _gamePrinter;
        private ISletterGame _sletter;
        private ILetterReelGenerator _letterReelGenerator;
        private IGameReader _gameReader;
        private ReelLine _sampleReelLine;
        private IWordValidator _wordValidator;
        private IUserSessionManager _userSessionManager;
        private UserWord _quitWord;
        private char[] _sampleLineLetters;
        private LetterReel _sampleReel;

        public SletterGameShould()
        {
            _quitWord = new UserWord("quit");
            _userSessionManager = Substitute.For<IUserSessionManager>();
            _wordValidator = Substitute.For<IWordValidator>();
            _gameReader = Substitute.For<IGameReader>();
            _gamePrinter = Substitute.For<IGamePrinter>();  
            _letterReelGenerator = Substitute.For<ILetterReelGenerator>();
            _sletter = new SletterGame(_gamePrinter, _letterReelGenerator, _gameReader, _wordValidator, _userSessionManager);
            _sampleLineLetters = new[]{'a','b','c','d','e','f','g'};
            _sampleReelLine = new ReelLine(_sampleLineLetters);
            _sampleReel = new LetterReel(_sampleLineLetters);
        }

        [Fact]
        public void ShowThePlayerTheCurrentlyAvailableLettersInTheReel()
        {
            //Arrange
            var reel = new LetterReel(_sampleLineLetters);
            _letterReelGenerator.GenerateAReel().Returns(reel);
            _gameReader.ReadNextWord().Returns(_quitWord);
            //Act
            _sletter.Play();
            //Assert
            _gamePrinter.Received(1).PrintReel(Arg.Is<ReelLine>(s => IsEquivalentTo(s,_sampleReelLine)));
        }

        [Theory,AutoData]
        public void ReadThePlayersWordAndFailCauseItDoesntExist(UserWord userWord)
        {
            _letterReelGenerator.GenerateAReel().Returns(_sampleReel);
            _gameReader.ReadNextWord().Returns(userWord, _quitWord);
            //Act
            _sletter.Play();
            //Assert
            _wordValidator.Received(1).CheckWord(userWord);
            _gamePrinter.Received(1).PrintInvalidWordMessage();
        }

        [Theory,AutoData]
        public void ReadThePlayersWordSaveTheScoreAndPrintIt(UserWord userWord, Score score)
        {
            _letterReelGenerator.GenerateAReel().Returns(_sampleReel);
            _gameReader.ReadNextWord().Returns(userWord, _quitWord);
            _wordValidator.CheckWord(userWord).Returns(score);
            //Act
            _sletter.Play();
            //Assert
            _userSessionManager.Received(1).SaveScore(score);
            _wordValidator.Received(1).CheckWord(userWord);
            _gamePrinter.Received(1).PrintWordScore(score);
        }

        [Theory,AutoData]
        public void PlayATurnUpdateTheReelAndPrintIt(UserWord userWord, Score score)
        {
            var secondReelLetters = new[]{'d','x','k','p','f','s','s',};
            var reelWithTwoLines = new LetterReel(_sampleLineLetters, secondReelLetters);
            _letterReelGenerator.GenerateAReel().Returns(reelWithTwoLines);
            _gameReader.ReadNextWord().Returns(userWord, _quitWord);
            _wordValidator.CheckWord(Arg.Is<UserWord>(s => IsEquivalentTo(s, userWord))).Returns(score);
            //Act
            _sletter.Play();
            //Assert
            _letterReelGenerator.Received(1).MoveSlots(userWord);
            _letterReelGenerator.Received(2).GenerateAReel();
            var secondReelLine = new ReelLine(secondReelLetters);
            _gamePrinter.Received(1).PrintReel(Arg.Is<ReelLine>(s => IsEquivalentTo(s,secondReelLine)));
        }

        [Theory, AutoData]
        public void PrintTheFullScore(UserWord userWord, Score score, UserWord secondUserWord, Score secondWordScore, Score totalScore)
        {
            _letterReelGenerator.GenerateAReel().Returns(_sampleReel);
            var printScoreWord = new UserWord("show score");
            _gameReader.ReadNextWord().Returns(printScoreWord, _quitWord);
            _userSessionManager.GetTotalScore().Returns(totalScore);
            //Act
            _sletter.Play();
            //Assert
            _gamePrinter.Received(1).PrintTotalScore(totalScore);
        }

        // This is used as a deep comparer
        public bool IsEquivalentTo(object first, object second)
        {
            first.Should().BeEquivalentTo(second);
            return true;
        }
    }
}
