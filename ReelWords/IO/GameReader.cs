using System;

namespace ReelWords.IO
{
    public class GameReader : IGameReader
    {
        public UserWord ReadNextWord()
        {
            var word = Console.ReadLine();
            return new UserWord(word);
        }
    }
}