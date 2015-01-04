using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsTour
{

    public enum Direction
    {
        UpRight, RightUp, RightDown, DownRight,
        DownLeft, LeftDown, LeftUp, UpLeft
    }

    public class KnightsTourGame
    {

        private Chessboard cb;
        private List<Direction> allDirections = new List<Direction>
        { Direction.UpRight, Direction.RightUp, Direction.RightDown, Direction.DownRight,
            Direction.DownLeft, Direction.LeftDown, Direction.LeftUp, Direction.UpLeft };

        public KnightsTourGame(int size)
        {
            cb = new Chessboard(size);
        }

        private void move(int x, int y, Direction dir, out int endX, out int endY)
        {
            switch (dir)
            {
                case Direction.UpRight:
                    x += 1;
                    y += 2;
                    break;
                case Direction.RightUp:
                    x += 2;
                    y += 1;
                    break;
                case Direction.RightDown:
                    x += 2;
                    y -= 1;
                    break;
                case Direction.DownRight:
                    x += 1;
                    y -= 2;
                    break;
                case Direction.DownLeft:
                    x -= 1;
                    y -= 2;
                    break;
                case Direction.LeftDown:
                    x -= 2;
                    y -= 1;
                    break;
                case Direction.LeftUp:
                    x -= 2;
                    y += 1;
                    break;
                case Direction.UpLeft:
                    x -= 1;
                    y += 2;
                    break;
            }
            endX = x;
            endY = y;
        }

        private bool canMoveTowards(int x, int y, Direction dir)
        {
            bool onBoard = false;
            int endX, endY;

            move(x, y, dir, out endX, out endY);

            onBoard = endX > -1 && endX < cb.Size && endY > -1 && endY < cb.Size;
            if (onBoard)
                return ! cb.Board[endX, endY].Visited;
            return onBoard;
        }

        private Square squreTowards(int x, int y, Direction dir)
        {
            int endX, endY;

            move(x, y, dir, out endX, out endY);

            return cb.Board[endX, endY];
        }

        private int possibleMoves(int x, int y)
        {
            int count = 0;
            foreach (Direction dir in allDirections)
                if (canMoveTowards(x, y, dir))
                    count++;
            return count;
        }

        public void test()
        {
            cb.Board[1, 6].Visited = true;

            for (int m = 0; m < cb.Size; m++)
                for (int n = 0; n < cb.Size; n++)
                    cb.Board[m, n].Step = possibleMoves(m, n);

            cb.printChessBoard();
        }
    }
}
