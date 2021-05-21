using LanguageExt;

namespace ReelWords
{
    public interface IWordValidator
    {
        Option<Score> CheckWord(UserWord word);
    }
}