using System.Threading.Tasks;

namespace ReelWords
{
    public interface IGamePrinter
    {
        void PrintReel(ReelLine reelLine);
        void PrintInvalidWordMessage();
        void PrintWordScore(Score score);
    }
}