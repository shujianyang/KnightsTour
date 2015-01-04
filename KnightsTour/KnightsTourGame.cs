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
        private int step;

        private List<Direction> allDirections = new List<Direction>
        { Direction.UpRight, Direction.RightUp, Direction.RightDown, Direction.DownRight,
            Direction.DownLeft, Direction.LeftDown, Direction.LeftUp, Direction.UpLeft };

        public KnightsTourGame(int size)
        {
            cb = new Chessboard(size);
            step = 1;
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

        private int possibleMoves(int x, int y)
        {
            int count = 0;
            foreach (Direction dir in allDirections)
                if (canMoveTowards(x, y, dir))
                    count++;
            return count;
        }

        private class directionCountComparer: IComparer<int>
        {
            public int Compare(int x, int y)
            {
                if (x <= y)
                    return -1;
                else
                    return 1;
            }
        }

        SortedList<int, Direction> setPriority(int x, int y)
        {
            SortedList<int, Direction> directionPriority = new SortedList<int, Direction>(new directionCountComparer());
            foreach (Direction dir in allDirections)
            {
                if(canMoveTowards(x, y, dir))
                {
                    int endX, endY;
                    move(x, y, dir, out endX, out endY);
                    int count = possibleMoves(endX, endY);
                    directionPriority.Add(count, dir);
                }
            }
            return directionPriority;
        }

        public bool recursiveMoveFrom(int x, int y)
        {
            cb.Board[x, y].Step = step++;
            cb.Board[x, y].Visited = true;
            if (step > cb.Size * cb.Size)
                return true;

            if (possibleMoves(x, y) == 0)
                return false;

            SortedList<int, Direction> directionPriority = setPriority(x, y);
            foreach(var dir in directionPriority.Values)
            {
                int endX, endY;
                move(x, y, dir, out endX, out endY);
                if (recursiveMoveFrom(endX, endY))
                    return true;
                else
                {
                    cb.Board[endX, endY].Step = -1;
                    cb.Board[endX, endY].Visited = false;
                    step--;
                }
            }
            return false;
        }

        public void startGameFrom(int x, int y)
        {
            if (recursiveMoveFrom(x - 1, y - 1))
                cb.printChessBoard();
            else
                Console.WriteLine("No solution is found.");
        }
    }
}
