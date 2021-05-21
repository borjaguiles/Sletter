namespace ReelWords.WordScorer
{
    public interface IWordScorer
    {   
        Score Calculate(UserWord userWord);
    }
}