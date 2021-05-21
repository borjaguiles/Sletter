using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using ReelWords;
using Xunit;

namespace ReelWordsTests
{
    public class ReelShould
    {
        [Fact]
        public void ReplaceEachLetterUsedInAWordWithTheNextInTheSlot()
        {
            //Arrange
            var reel = new LetterReel(new[]{'a','b','c','d','e','f','g'}, new[]{'h','i','j','k','l','m','n'});
            //Act
            var word = new UserWord("bed");
            reel.MoveSlots(word);
            //Assert
            var expectedReelLine = new ReelLine(new[]{'a','i','c','k','l','f','g'});
            var resultReelLine = reel.GetAvailableLine();
            resultReelLine.Should().BeEquivalentTo(expectedReelLine);
        }
    }
}
