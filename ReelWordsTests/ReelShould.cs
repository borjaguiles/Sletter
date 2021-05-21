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
        private LetterReel _reel;

        public ReelShould()
        {
            _reel = new LetterReel(new[]{'a','b','c','d','e','f','g'}, new[]{'h','i','j','k','l','m','n'});
        }

        [Fact]
        public void ReplaceEachLetterUsedInAWordWithTheNextInTheSlot()
        {
            //Arrange
            //Act
            var word = new UserWord("bed");
            _reel.MoveSlots(word);
            //Assert
            var expectedReelLine = new ReelLine(new[]{'a','i','c','k','l','f','g'});
            var resultReelLine = _reel.GetAvailableLine();
            resultReelLine.Should().BeEquivalentTo(expectedReelLine);
        }

        [Fact]
        public void BeAbleToFindIfAWordIsWithinTheCurrentLine()
        {
            var word = new UserWord("bed");
            _reel.HasTheWord(word).Should().BeTrue();
        }

        [Fact]
        public void BeAbleToFindAWordIsntWithinTheCurrentLineup()
        {
            var word = new UserWord("aguila");
            _reel.HasTheWord(word).Should().BeFalse();
        }
    }
}
