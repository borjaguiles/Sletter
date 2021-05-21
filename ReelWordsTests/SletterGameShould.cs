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
        private ILetterReel _letterReel;
        private IGameReader _gameReader;
        private ReelLine _sampleReelLine;
        private IWordValidator _wordValidator;
        private IUserSessionManager _userSessionManager;

        public SletterGameShould()
        {
            _userSessionManager = Substitute.For<IUserSessionManager>();
            _wordValidator = Substitute.For<IWordValidator>();
            _gameReader = Substitute.For<IGameReader>();
            _gamePrinter = Substitute.For<IGamePrinter>();  
            _letterReel = Substitute.For<ILetterReel>();
            _sletter = new SletterGame(_gamePrinter, _letterReel, _gameReader, _wordValidator, _userSessionManager);
            _sampleReelLine = new ReelLine(new[]{'a','b','c','d','e','f','g'});
        }

        [Fact]
        public void ShowThePlayerTheCurrentlyAvailableLettersInTheReel()
        {
            //Arrange
            var expectedLetters = new ReelLine(new[]{'a','b','c','d','e','f','g'});
            _letterReel.GetAvailableLetters().Returns(expectedLetters);
            //Act
            _sletter.Play();
            //Assert
            _gamePrinter.Received(1).PrintReel(Arg.Is<ReelLine>(s => IsEquivalentTo(s,expectedLetters)));
        }

        [Theory,AutoData]
        public void ReadThePlayersWordAndFailCauseItDoesntExist(UserWord userWord)
        {
            _letterReel.GetAvailableLetters().Returns(_sampleReelLine);
            _gameReader.ReadNextWord().Returns(userWord);
            //Act
            _sletter.Play();
            //Assert
            _gamePrinter.Received(1).PrintReel(_sampleReelLine);
            _wordValidator.Received(1).CheckWord(userWord);
            _gamePrinter.Received(1).PrintInvalidWordMessage();
        }

        [Theory,AutoData]
        public void ReadThePlayersWordSaveTheScoreAndPrintIt(UserWord userWord, Score score)
        {
            _letterReel.GetAvailableLetters().Returns(_sampleReelLine);
            _gameReader.ReadNextWord().Returns(userWord);
            _wordValidator.CheckWord(Arg.Is<UserWord>(s => IsEquivalentTo(s, userWord))).Returns(score);
            //Act
            _sletter.Play();
            //Assert
            _userSessionManager.Received(1).SaveScore(score);
            _gamePrinter.Received(1).PrintReel(_sampleReelLine);
            _wordValidator.Received(1).CheckWord(userWord);
            _gamePrinter.Received(1).PrintWordScore(score);
        }

        [Theory,AutoData]
        public void PlayATurnUpdateTheReelAndPrintIt(UserWord userWord, Score score)
        {
            var nextReelLine = new ReelLine(new[]{'d','x','k','p','f','s','s',});
            _letterReel.GetAvailableLetters().Returns(_sampleReelLine, nextReelLine);
            _gameReader.ReadNextWord().Returns(userWord);
            _wordValidator.CheckWord(Arg.Is<UserWord>(s => IsEquivalentTo(s, userWord))).Returns(score);
            //Act
            _sletter.Play();
            //Assert
            _letterReel.Received(1).MoveSlots(userWord);
            _letterReel.Received(2).GetAvailableLetters();
            _gamePrinter.Received(1).PrintReel(Arg.Is<ReelLine>(s => IsEquivalentTo(s,nextReelLine)));
        }

        // This is used as a deep comparer
        public bool IsEquivalentTo(object first, object second)
        {
            first.Should().BeEquivalentTo(second);
            return true;
        }
    }

}
