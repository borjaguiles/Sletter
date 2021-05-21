using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using ReelWords.Scorer;

namespace ReelWords.Scorer
{
    public class WordScorer : IWordScorer
    {
        private const char Separator = ' ';
        private Dictionary<char, int> _letterValues;
        public WordScorer()
        {
            _letterValues = new Dictionary<char, int>();
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "ReelWords.Resources.scores.txt";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                var lines = new List<char[]>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine().Split(Separator);
                    _letterValues.Add(line[0][0], Convert.ToInt32(line[1]));
                }
            }
        }

        public Score Calculate(UserWord userWord)
        {
            var currentPoints = 0;
            foreach (var letter in userWord.GetLetters())
            {
                currentPoints += _letterValues[letter];
            }
            return new Score(currentPoints);
        }
    }
}