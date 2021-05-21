using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using LanguageExt;

namespace ReelWords.Reel
{
    public class LetterReelGenerator : ILetterReelGenerator
    {
        private const char Separator = ' ';

        public LetterReel GenerateAReel()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "ReelWords.Resources.reels.txt";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                var lines = new List<char[]>();
                while (!reader.EndOfStream)
                {
                    lines.Add(reader.ReadLine().Split(Separator).Select(s => s[0]).ToArray());
                }
                return new LetterReel(lines.ToArray());
            }
        }
    }
}