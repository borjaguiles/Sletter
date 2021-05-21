using System;
using System.Threading.Tasks;
using ReelWords.Scorer;

namespace ReelWords
{
    public class SletterGame : ISletterGame
    {
        private readonly IGamePrinter _gamePrinter;
        private readonly ILetterReelGenerator _letterReelGenerator;
        private readonly IGameReader _gameReader;
        private readonly IWordValidator _wordValidator;
        private readonly IUserSessionManager _userSessionManager;
        private readonly IWordScorer _wordScorer;

        public SletterGame(IGamePrinter gamePrinter, ILetterReelGenerator letterReelGenerator, IGameReader gameReader,
            IWordValidator wordValidator, IUserSessionManager userSessionManager, IWordScorer wordScorer)
        {
            _gamePrinter = gamePrinter;
            _letterReelGenerator = letterReelGenerator;
            _gameReader = gameReader;
            _wordValidator = wordValidator;
            _userSessionManager = userSessionManager;
            _wordScorer = wordScorer;
        }

        public void Play()
        {
            var reel = _letterReelGenerator.GenerateAReel();
            while (true)
            {
                var nextLetters = reel.GetActiveLine();
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

                if (!reel.HasTheWord(word))
                {
                    _gamePrinter.PrintLettersNotFound();
                    continue;
                }

                if (_wordValidator.WordExists(word))
                {
                    var score = _wordScorer.Calculate(word);
                    _userSessionManager.SaveScore(score);
                    _gamePrinter.PrintWordScore(score);
                    reel.MoveSlots(word);
                }
                else
                {
                    _gamePrinter.PrintInvalidWordMessage();
                }
            }
        }
    }
}