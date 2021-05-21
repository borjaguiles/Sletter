using System.Threading.Tasks;

namespace ReelWords
{
    public interface ILetterReelGenerator
    {
        LetterReel GenerateAReel();
        void MoveSlots(UserWord userWord);
    }
}