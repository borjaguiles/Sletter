using System;
using System.Threading.Tasks;

namespace ReelWords
{
    public class SletterGame : ISletterGame
    {
        private readonly IGamePrinter _gamePrinter;
        private readonly ILetterReel _letterReel;
        private readonly IGameReader _gameReader;
        private readonly IWordValidator _wordValidator;

        public SletterGame(IGamePrinter gamePrinter, ILetterReel letterReel, IGameReader gameReader, IWordValidator wordValidator)
        {
            _gamePrinter = gamePrinter;
            _letterReel = letterReel;
            _gameReader = gameReader;
            _wordValidator = wordValidator;
        }

        public void Play()
        {
            var nextLetters = _letterReel.GetAvailableLetters();
            _gamePrinter.PrintReel(nextLetters);
            var word = _gameReader.ReadNextWord();
            var score = _wordValidator.CheckWord(word);
            score.Match(s => throw new NotImplementedException(), () => _gamePrinter.PrintInvalidWordMessage());

        }
    }
}