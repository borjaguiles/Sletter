using System;
using System.Collections.Generic;
using System.Linq;

namespace ReelWords
{
    public class Trie
    {
        private char _value;
        public Trie()
        {
            _value = 'º';
        }

        private List<Trie> _children = new List<Trie>();

        private const char EndOfWordCharacter = '=';

        private Trie(char letter)
        {
            _value = letter;
        }

        public bool Search(string word)
        {
            if (word.Length == 0)
            {
                word = EndOfWordCharacter.ToString();
            }
            var next = _children.FirstOrDefault(s => s == word[0]);
            
            if (next == null)
            {
                return false;
            }

            if (next == EndOfWordCharacter)
            {
                return true;
            }

            

            return next.Search(word.Substring(1));
        }

        public void Insert(string newWord)
        {
            Trie son;
            son = _children.FirstOrDefault(s => s == newWord[0]);
            if (son == null)
            {
                son = new Trie(newWord[0]);
                _children.Add(son);
            }

            if (newWord == EndOfWordCharacter.ToString())
            {
                return;
            }

            var nextSegment = newWord.Substring(1);
            if (string.IsNullOrEmpty(nextSegment))
            {
                son.Insert(EndOfWordCharacter.ToString());
            }
            else
            {
                son.Insert(nextSegment);
            }
        }

        public void Delete(string word)
        {
            if (word.Length == 0)
            {
                word = EndOfWordCharacter.ToString();
            }
            var son = _children.FirstOrDefault(s => s == word[0]);
            if (son == null)
                throw new WordDoesntExistExecption();

            if (son == EndOfWordCharacter)
            {
                _children.Remove(son);
                return;
            }

            son.Delete(word.Substring(1));
            if (son._children.Count == 1)
            {
                _children.Remove(son);
            }
        }

        public static implicit operator char(Trie asd)
        {
            return asd._value;
        }
    }

    public class WordDoesntExistExecption : Exception
    {
    }
}