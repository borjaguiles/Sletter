using NSubstitute;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
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

        public SletterGameShould()
        {
            _wordValidator = Substitute.For<IWordValidator>();
            _gameReader = Substitute.For<IGameReader>();
            _gamePrinter = Substitute.For<IGamePrinter>();  
            _letterReel = Substitute.For<ILetterReel>();
            _sletter = new SletterGame(_gamePrinter, _letterReel, _gameReader, _wordValidator);
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

        [Fact]
        public void ReadThePlayersWordAndFailCauseItDoesntExist()
        {
            var word = new UserWord("nucelar");
            _letterReel.GetAvailableLetters().Returns(_sampleReelLine);
            _gameReader.ReadNextWord().Returns(word);
            //Act
            _sletter.Play();
            //Assert
            _gamePrinter.Received(1).PrintReel(_sampleReelLine);
            _wordValidator.Received(1).CheckWord(word);
            _gamePrinter.Received(1).PrintInvalidWordMessage();
        }

        // This is used as a deep comparer
        public bool IsEquivalentTo(object first, object second)
        {
            first.Should().BeEquivalentTo(second);
            return true;
        }
    }
}
