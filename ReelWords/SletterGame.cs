using System;
using System.Threading.Tasks;

namespace ReelWords
{
    public class SletterGame : ISletterGame
    {
        private readonly IGamePrinter _gamePrinter;
        private readonly ILetterReel _letterReel;

        public SletterGame(IGamePrinter gamePrinter, ILetterReel letterReel)
        {
            _gamePrinter = gamePrinter;
            _letterReel = letterReel;
        }

        public void Play()
        {
            var nextLetters = _letterReel.GetAvailableLetters();
            _gamePrinter.PrintReel(nextLetters);
        
        }
    }
}