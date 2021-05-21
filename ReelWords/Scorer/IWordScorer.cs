namespace ReelWords.Scorer
{
    public interface IWordScorer
    {   
        Score Calculate(UserWord userWord);
    }
}