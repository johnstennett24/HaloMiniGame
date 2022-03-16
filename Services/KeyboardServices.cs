using Raylib_cs;

//borrowed from week 04 assingment

namespace MiniHaloGame
{

    public class KeyboardService
    {
        private float cellSize = 15;

        public KeyboardService(float cellSize)
        {
            this.cellSize = cellSize;
        }
        public Point GetDirection()
        {
            float dx = 0;
            float dy = 0;

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