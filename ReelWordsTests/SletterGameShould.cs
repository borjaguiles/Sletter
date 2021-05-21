using NSubstitute;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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
        public async Task ShowThePlayerTheCurrentlyAvailableLettersInTheReel()
        {
            var expectedLetters = new Letters(new[]{'a','b','c','d','e','f','g'});
            //Arrange
            _letterReel.GetAvailableLetters().Returns(expectedLetters);
            //Act
            _sletter.Play();
            //Assert
            await _gamePrinter.Received(1).PrintReel(Arg.Is<char[]>(s => s.Equals(expectedLetters)));
        }
    }
}
