using Microsoft.Extensions.DependencyInjection;
using ReelWords.IO;
using ReelWords.Reel;

namespace ReelWords
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<ISletterGame, SletterGame>()
                .AddSingleton<IGamePrinter, GamePrinter>()
                .AddSingleton<IGameReader, GameReader>()
                .AddTransient<ILetterReelGenerator, LetterReelGenerator>()
                .BuildServiceProvider();

            var game = serviceProvider.GetService<ISletterGame>();
            game.Play();
        }
    }
}