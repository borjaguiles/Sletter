using System;

namespace ReelWords
{
    public class UserWord
    {
        private readonly string _word;

        public UserWord(string word)
        {
            _word = word;
        }

        public bool IsEndGame()
        {
            return _word.ToLower() == "quit";
        }
    }
}