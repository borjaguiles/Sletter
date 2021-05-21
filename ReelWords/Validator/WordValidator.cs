using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ReelWords.Validator
{
    public class WordValidator : IWordValidator
    {
        private const char Separator = ' ';
        private Trie _wordDictionary { get; }
        public WordValidator()
        {
            _wordDictionary = new Trie();
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "ReelWords.Resources.american-english-large.txt";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                var lines = new List<char[]>();
                while (!reader.EndOfStream)
                {
                    _wordDictionary.Insert(reader.ReadLine());
                }
            }
        }
        public bool WordExists(UserWord word)
        {
            return _wordDictionary.Search(word);
        }
    }
}