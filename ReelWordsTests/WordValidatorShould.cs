using System;
using System.Collections.Generic;
using System.Text;
using LanguageExt;
using ReelWords;
using Xunit;

namespace ReelWordsTests
{
    public class WordValidatorShould
    {
        private IWordValidator _wordValidator;

        public WordValidatorShould()
        {
            //_wordValidator = new WordValidator();
        }

        [Fact]
        public void ReturnNothingIfAWordDoesntExist()
        {
            //assert
            //var result = _wordValidator.;
            //result.IsNone.Should().BeTrue();
        }
    }

    //public class WordValidator : IWordValidator
    //{
    //    public Option<Score> CheckWord(UserWord word)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
