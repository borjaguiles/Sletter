using System;

namespace ReelWords
{
    public class SletterGame : ISletterGame
    {
        public SletterGame(IGamePrinter gamePrinter, ILetterReel letterReel)
        {
            throw new NotImplementedException();
        }

        public void Play()
        {
            bool playing = true;

            while (playing)
            {
                string input = Console.ReadLine();

                // TODO:  Run game logic here using the user input string

                // TODO:  Create simple unit tests to test your code in the ReelWordsTests project,
                // don't worry about creating tests for everything, just important functions as
                // seen for the Trie tests
            }
        }
    }
}