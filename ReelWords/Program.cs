using Microsoft.Extensions.DependencyInjection;
using ReelWords.IO;
using ReelWords.Reel;
using ReelWords.Validator;

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
                .AddSingleton<IWordValidator, WordValidator>()
                .AddSingleton<IUserSessionManager, UserSessionManager>()
                .AddTransient<ILetterReelGenerator, LetterReelGenerator>()
                .BuildServiceProvider();

            var game = serviceProvider.GetService<ISletterGame>();
            game.Play();
        }
    }
}