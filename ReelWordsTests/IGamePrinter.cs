using System.Threading.Tasks;

namespace ReelWordsTests
{
    internal interface IGamePrinter
    {
        Task PrintReel(char[] letters);
    }
}