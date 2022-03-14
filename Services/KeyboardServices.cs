using Raylib_cs;

//borrowed from week 04 assingment

namespace MiniHaloGame
{

    public class KeyboardService
    {
        private int cellSize = 15;

        public KeyboardService(int cellSize)
        {
            this.cellSize = cellSize;
        }
        public Point GetDirection()
        {
            int dx = 0;
            int dy = 0;

            if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
            {
                dx = -1;
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
            {
                dx = 1;
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
            {
                dy = -1;
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
            {
                dy = 1;
            }

            Point direction = new Point(dx, dy);
            direction = direction.Scale(cellSize);

            return direction;
        }
    }
}