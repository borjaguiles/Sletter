using System.Threading.Tasks;

namespace ReelWords
{
    public interface IGamePrinter
    {
        Task PrintReel(char[] letters);
    }
}