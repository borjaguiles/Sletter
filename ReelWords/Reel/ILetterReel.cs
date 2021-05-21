using System.Threading.Tasks;

namespace ReelWords
{
    public interface ILetterReel
    {
        ReelLine GetAvailableLetters();
    }
}