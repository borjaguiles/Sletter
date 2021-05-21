using System.Threading.Tasks;

namespace ReelWordsTests
{
    internal interface ILetterReel
    {
        Task<Letters> GetAvailableLetters();
    }
}