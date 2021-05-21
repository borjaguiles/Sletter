using System;
using System.Linq;
using System.Text;

namespace ReelWords.IO
{
    public class GamePrinter : IGamePrinter
    {
        public void PrintReel(ReelLine reelLine)
        {
            Console.WriteLine("Next round!");
            var stringBuilder = new StringBuilder();
            reelLine.Letters.ToList().ForEach(s => stringBuilder.Append("|"+s+"|"));
            Console.WriteLine(stringBuilder.ToString());
        }

        public void PrintInvalidWordMessage()
        {
            Console.WriteLine("That word doesn't exists, try again.");
        }

        public void PrintWordScore(Score score)
        {
            Console.WriteLine("You earned " + score.Points.ToString() + " points!");
        }

        public void PrintTotalScore(Score score)
        {
            Console.WriteLine("You've accumulated " + score.Points.ToString() + " points, keep it up!");
        }

        public void PrintLettersNotFound()
        {
            Console.WriteLine("You can only use the available letters. Try again!");
        }
    }
}