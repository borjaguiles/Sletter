using System.Threading.Tasks;

namespace ReelWords
{
    public interface ILetterReel
    {
        ReelLine GetAvailableLetters();
        void MoveSlots(UserWord userWord);
    }
}