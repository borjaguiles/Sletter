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
        private readonly IUserSessionManager _userSessionManager;

        public SletterGame(IGamePrinter gamePrinter, ILetterReel letterReel, IGameReader gameReader,
            IWordValidator wordValidator, IUserSessionManager userSessionManager)
        {
            _gamePrinter = gamePrinter;
            _letterReel = letterReel;
            _gameReader = gameReader;
            _wordValidator = wordValidator;
            _userSessionManager = userSessionManager;
        }

        public void Play()
        {
            while (true)
            {
                var nextLetters = _letterReel.GetAvailableLetters();
                _gamePrinter.PrintReel(nextLetters);
                var word = _gameReader.ReadNextWord();
                if (word.IsEndGame())
                    return;
                if (word.IsPrintScore())
                {
                    var totalScore = _userSessionManager.GetTotalScore();
                    _gamePrinter.PrintTotalScore(totalScore);
                    continue;
                }
                var score = _wordValidator.CheckWord(word);
                score.Match(s =>
                {
                    _userSessionManager.SaveScore(s);
                    _gamePrinter.PrintWordScore(s);
                    _letterReel.MoveSlots(word);
                }, () => _gamePrinter.PrintInvalidWordMessage());
            }
        }
    }
}