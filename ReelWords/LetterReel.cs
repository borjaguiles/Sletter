using System;

namespace ReelWords
{
    public class LetterReel
    {
        private readonly char[][] _expectedLetters;

        public LetterReel(params char[][] expectedLetters)
        {
            _expectedLetters = expectedLetters;
        }

        public ReelLine GetAvailableLine()
        {
            return new ReelLine(_expectedLetters[0]);
        }

        public void MoveSlots(UserWord word)
        {
            throw new NotImplementedException();
        }
    }
}