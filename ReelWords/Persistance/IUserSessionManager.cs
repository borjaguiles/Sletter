namespace ReelWords
{
    public interface IUserSessionManager
    {
        void SaveScore(Score score);
        Score GetTotalScore();
    }
}