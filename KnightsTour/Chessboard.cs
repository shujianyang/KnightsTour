using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsTour
{
    class Chessboard
    {
        public readonly int Size;
        public Square[,] Board { get; set; }

        public Chessboard(int sz)
        {
            Size = sz;
            Board = new Square[Size, Size];

            for (int m = 0; m < Size; m++)
                for (int n = 0; n < Size; n++)
                    Board[m, n] = new Square();
        }

        public void printChessBoard()
        {
            for (int m = Size - 1; m >= 0; m--)
            {
                for (int n = 0; n < Size; n++)
                {
                    if(Size < 10)
                        Console.Write("{0:00} ", Board[n, m].Step);
                    else
                        Console.Write("{0:000} ", Board[n, m].Step);
                }
                Console.WriteLine();
            }
        }
    }
}
