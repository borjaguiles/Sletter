using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using ReelWords;
using ReelWords.Reel;
using Xunit;

namespace ReelWordsTests
{
    public class LetterReelGeneratorShould
    {
        private ILetterReelGenerator _reelGenerator;

        public LetterReelGeneratorShould()
        {
            _reelGenerator = new LetterReelGenerator();
        }

        [Fact]
        public void GenerateANewReelUsingAFile()
        {
            //Assert
            var expectedLine = new ReelLine(new []{'u','d','x','c','l','a','e'});
            var expectedFourthIteration = new ReelLine(new []{'u','b','x','c','s','e','h'});
            var reel = _reelGenerator.GenerateAReel();
            reel.GetActiveLine().Should().BeEquivalentTo(expectedLine);
            reel.MoveSlots(new UserWord("la"));
            reel.MoveSlots(new UserWord("doe"));
            reel.MoveSlots(new UserWord("duet"));
        }
    }
}
