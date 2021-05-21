using System;
using System.Collections.Generic;
using System.Linq;
using LanguageExt;

namespace ReelWords
{
    public class LetterReel
    {
        private readonly char[][] _letterBox;
        private char[] activeLine => _letterBox[0];

        public LetterReel(params char[][] letterBox)
        {
            _letterBox = letterBox;
        }

        public ReelLine GetActiveLine()
        {
            return new ReelLine(activeLine);
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
            return FindLetterInArray(letter, activeLine);
        }

        private int FindLetterInArray(char letter, char[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == letter)
                {
                    return i;
                    
                }
            }

            return -1;
        }

        public bool HasTheWord(UserWord word)
        {
            var allowedLetters = activeLine.ToList();
            foreach (var letter in word.GetLetters())
            {
                if (!allowedLetters.Contains(letter))
                    return false;
                allowedLetters.Remove(letter);
            }

            return true;
        }
    }
}