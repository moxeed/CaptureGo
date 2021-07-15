using System;
using System.Collections.Generic;

namespace CaptureGoGame.Domian
{
    public class Board
    {
        const int BOARD_SIZE = 9;

        readonly List<List<Point>> _data;

        public Board()
        {
            _data = new List<List<Point>>();
            Clear();
        }

        internal void Clear()
        {
            _data.Clear();
            for(int i=0; i < BOARD_SIZE; i ++)
            {
                _data.Add(new List<Point>());
                for(int j=0; j < BOARD_SIZE; j ++)
                {
                    _data[i].Add(new Point());
                }
            }
        }

        public void PlaceStone(int x, int y, bool color)
        {
            if (IsGameOver())
                throw new InvalidOperationException();

            _data[x][y].Color = color;
        }

        private bool IsPrisoneer(int x, int y)
        {
            var left = y > 0 ? _data[x][y - 1] : null;
            var right = y < BOARD_SIZE - 1 ? _data[x][y + 1] : null;
            var top = x > 0 ? _data[x - 1][y] : null;
            var bottom = x < BOARD_SIZE - 1 ? _data[x + 1][y] : null;

            return _data[x][y].GetFreedomDegree(left, right, top, bottom) == 0;
        }

        public bool IsGameOver()
        {
            for(int i = 0; i < BOARD_SIZE; i ++)
            {
                for(int j = 0; j < BOARD_SIZE; j ++)
                {
                    if (IsPrisoneer(i, j))
                        return true;
                }
            }
            return false;
        }

        public IReadOnlyList<IReadOnlyList<Point>> Data => _data;
    }
}
