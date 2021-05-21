using NSubstitute;
using System.Collections.Generic;
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

        public SletterGameShould()
        {
            _gamePrinter = Substitute.For<IGamePrinter>();  
            _letterReel = Substitute.For<ILetterReel>();
            _sletter = new SletterGame(_gamePrinter, _letterReel);
        }

        [Fact]
        public void ShowThePlayerTheCurrentlyAvailableLettersInTheReel()
        {
            var expectedLetters = new ReelLine(new[]{'a','b','c','d','e','f','g'});
            //Arrange
            _letterReel.GetAvailableLetters().Returns(expectedLetters);
            //Act
            _sletter.Play();
            //Assert
            _gamePrinter.Received(1).PrintReel(Arg.Is<ReelLine>(s => IsEquivalentTo(s,expectedLetters)));
        }

        // This is used as a deep comparer
        public bool IsEquivalentTo(object first, object second)
        {
            first.Should().BeEquivalentTo(second);
            return true;
        }
    }
}
