using System.Collections.Generic;
using System.Linq;

namespace ReelWords
{
    public class UserSessionManager : IUserSessionManager
    {
        private List<Score> _score;

        public UserSessionManager()
        {
            _score = new List<Score>();
        }

        public void SaveScore(Score score)
        {
            _score.Add(score);
        }

        public Score GetTotalScore()
        {
            return new Score(_score.Sum(s => s.Points));
        }
    }
}