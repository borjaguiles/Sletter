using Microsoft.Extensions.DependencyInjection;
using ReelWords.IO;
using ReelWords.Reel;
using ReelWords.Scorer;
using ReelWords.Validator;

namespace ReelWords
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<ISletterGame, SletterGame>()
                .AddSingleton<IGamePrinter, GamePrinter>()
                .AddSingleton<IGameReader, GameReader>()
                .AddSingleton<IWordValidator, WordValidator>()
                .AddTransient<IUserSessionManager, UserSessionManager>()
                .AddSingleton<IWordScorer, WordScorer>()
                .AddTransient<ILetterReelGenerator, LetterReelGenerator>()
                .BuildServiceProvider();

            var game = serviceProvider.GetService<ISletterGame>();
            game.Play();
        }
    }
}