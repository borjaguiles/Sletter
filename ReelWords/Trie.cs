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

        private const string EndOfWordCharacter = "=";

        private Trie(char letter)
        {
            _value = letter;
        }

        public bool Search(string s)
        {
            throw new NotImplementedException();
        }

        public void Insert(string newWord)
        {
            if (newWord == EndOfWordCharacter)
            {
                return;
            }

            Trie son;
            son = _children.FirstOrDefault(s => s == newWord[0]);
            if (son == null)
            {
                son = new Trie(newWord[0]);
                _children.Add(son);
            }

            var nextSegment = newWord.Substring(1);
            if (string.IsNullOrEmpty(nextSegment))
            {
                son.Insert(EndOfWordCharacter);
            }
            else
            {
                son.Insert(nextSegment);
            }
        }

        public void Delete(string s)
        {
            throw new NotImplementedException();
        }

        public static implicit operator char(Trie asd)
        {
            return asd._value;
        }
    }
}