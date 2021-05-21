using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using LanguageExt;
using ReelWords;
using ReelWords.WordValidator;
using Xunit;

namespace ReelWordsTests
{
    public class WordValidatorShould
    {
        private IWordValidator _wordValidator;

        public WordValidatorShould()
        {
            _wordValidator = new WordValidator();
        }

        [Fact]
        public void ReturnNothingIfAWordDoesntExist()
        {
            //assert
            var result = _wordValidator.WordExists(new UserWord("asdasdasd"));
            result.Should().BeFalse();
        }
    }
}
