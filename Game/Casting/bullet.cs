using System;

namespace HaloMiniGame.Game.Casting
{
    public class bullet : Actor
    {
        private Body body;
        private Image image;
        private Point position = new Point(0, 0);

        public bullet(Body body, Image image, Point velocity, bool debug = false) : base(debug)
        {
            this.body = body;
            this.image = image;
        }

         public void MoveNext(int maxX, int maxY, Point MousePosition)
        {
            int x = ((MousePosition.GetX() / position.GetX()) + maxX) % maxX;
            int y = ((MousePosition.GetY() / position.GetY()) + maxY) % maxY;
            position = new Point(x, y);
        }
    }
}