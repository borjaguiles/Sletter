using System;

namespace ReelWords
{
    public class LetterReel
    {
        private readonly char[][] _letterBox;

        public LetterReel(params char[][] letterBox)
        {
            _letterBox = letterBox;
        }

        public ReelLine GetAvailableLine()
        {
            return new ReelLine(_letterBox[0]);
        }

        public void MoveSlots(UserWord word)
        {
            var usedLetters = word.GetLetters();
            foreach (var letter in usedLetters)
            {
                AdvanceSlot(letter);
            }
            
        }

        private void AdvanceSlot(char letter)
        {
            var letterPosition = FindLetterPosition(letter);

            char[] file = new char[_letterBox.Length];
            for (int i = 0; i < _letterBox.Length; i++)
            {
                file[i] = _letterBox[i][letterPosition];
            }

            for (int i = 0; i < _letterBox.Length; i++)
            {
                if (i == 0)
                {
                    _letterBox[i][letterPosition] = file[_letterBox.Length - 1];
                }
                else
                {
                    _letterBox[i][letterPosition] = file[i - 1];
                }
            }
        }

        private int FindLetterPosition(char letter)
        {
            for (int i = 0; i < _letterBox[0].Length; i++)
            {
                if (_letterBox[0][i] == letter)
                {
                    return i;
                    
                }
            }

            return -1;
        }
    }
}