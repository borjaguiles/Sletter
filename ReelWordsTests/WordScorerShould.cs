using System.Collections.Generic;
using System.Text;
using ReelWords;
using Xunit;

namespace ReelWordsTests
{
    public class WordScorerShould
    {
        private IWordScorer _wordScorer;

        public WordScorerShould()
        {
            _wordScorer = new WordScorer();
        }

        [Fact]
        public void ReturnTheScoreOfAnyGivenWord()
        {
            var result = _wordScorer.Calculate(new UserWord("pierplay"));
            //Assert
            var expectedScore = new Score(15);
            result.Should().BeEquivalentTo(expectedScore);
        }
    }
}
