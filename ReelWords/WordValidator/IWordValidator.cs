using LanguageExt;

namespace ReelWords
{
    public interface IWordValidator
    {
        bool WordExists(UserWord word);
    }
}