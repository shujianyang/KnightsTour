using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int size;
            Console.WriteLine("Please enter size of chessboard:");
            string input = Console.ReadLine();
            Int32.TryParse(input, out size);
            int x, y;
            Console.WriteLine("Please enter starting position x:");
            input = Console.ReadLine();
            Int32.TryParse(input, out x);
            Console.WriteLine("Please enter starting position y:");
            input = Console.ReadLine();
            Int32.TryParse(input, out y);

            KnightsTourGame game = new KnightsTourGame(size);
            game.startGameFrom(x, y);
        }
    }
}
