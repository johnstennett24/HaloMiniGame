using HaloMiniGame.Game.Casting;


namespace HaloMiniGame.Game.Services
{
   
    public class VideoService
    {
        private float cellSize = 15;
        private string caption = "";
        private float width = 640;
        private float height = 480;
        private float frameRate = 0;
        private bool debug = false;

        public VideoService(string caption, float width, float height, float cellSize, float frameRate, 
                bool debug)
        {
            this.caption = caption;
            this.width = width;
            this.height = height;
            this.cellSize = cellSize;
            this.frameRate = frameRate;
            this.debug = debug;
        }


    
        public void CloseWindow()
        {
            Raylib.CloseWindow();
        }

        public void ClearBuffer()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Raylib_cs.Color.BLACK);
            if (debug)
            {
                DrawGrid();
            }
        }

        public void DrawActor(Actor actor)
        {
            string text = actor.GetText();
            float x = actor.GetPosition().GetX();
            float y = actor.GetPosition().GetY();
            float fontSize = actor.GetFontSize();
            Casting.Color c = actor.GetColor();
            Raylib_cs.Color color = ToRaylibColor(c);
            Raylib.DrawText(text, x, y, fontSize, color);
        }


        public void DrawActors(List<Actor> actors)
        {
            foreach (Actor actor in actors)
            {
                DrawActor(actor);
            }
        }

        public void FlushBuffer()
        {
            Raylib.EndDrawing();
        }

        public float GetCellSize()
        {
            return cellSize;
        }

        public float GetHeight()
        {
            return height;
        }

        public float GetWidth()
        {
            return width;
        }

        public bool IsWindowOpen()
        {
            return !Raylib.WindowShouldClose();
        }
        public void OpenWindow()
        {
            Raylib.InitWindow(width, height, caption);
            Raylib.SetTargetFPS(frameRate);
        }


        private void DrawGrid()
        {
            for (float x = 0; x < width; x += cellSize)
            {
                Raylib.DrawLine(x, 0, x, height, Raylib_cs.Color.GRAY);
            }
            for (float y = 0; y < height; y += cellSize)
            {
                Raylib.DrawLine(0, y, width, y, Raylib_cs.Color.GRAY);
            }
        }
        private Raylib_cs.Color ToRaylibColor(Casting.Color color)
        {
            float r = color.GetRed();
            float g = color.GetGreen();
            float b = color.GetBlue();
            float a = color.GetAlpha();
            return new Raylib_cs.Color(r, g, b, a);
        }

    }
}