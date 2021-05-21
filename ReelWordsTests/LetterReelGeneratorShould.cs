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
            var reel = _reelGenerator.GenerateAReel();
            reel.GetActiveLine().Should().BeEquivalentTo(expectedLine);
        }
    }
}
