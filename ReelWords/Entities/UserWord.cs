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

        public bool IsPrintScore()
        {
            return _word.ToLower() == "show score";
        }

        public char[] GetLetters()
        {
            return _word.ToCharArray();
        }

        public static implicit operator string(UserWord word) => word._word;
    }
}