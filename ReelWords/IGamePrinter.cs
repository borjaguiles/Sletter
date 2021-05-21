using System.Threading.Tasks;

namespace ReelWords
{
    public interface IGamePrinter
    {
        Task PrintReel(ReelLine reelLine);
    }
}