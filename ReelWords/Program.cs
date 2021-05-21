using Microsoft.Extensions.DependencyInjection;

namespace ReelWords
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<ISletterGame, SletterGame>()
                .BuildServiceProvider();

            var game = serviceProvider.GetService<ISletterGame>();
            game.Play();
        }
    }
}