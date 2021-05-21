using System.Threading.Tasks;

namespace ReelWords
{
    public interface ILetterReel
    {
        Task<Letters> GetAvailableLetters();
    }
}