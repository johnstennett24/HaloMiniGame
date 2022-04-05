using System;

namespace HaloMiniGame.Game.Casting
{
    public class bullet : Actor
    {
        private Body body;
        private Image image;

        public bullet(Body body, Image image, bool debug = false) : base(debug)
        {
            this.body = body;
            this.image = image;
        }
         public Body GetBody()
        {
            return body;
        }

        /// <summary>
        /// Gets the image.
        /// </summary>
        /// <returns>The image.</returns>
        public Image GetImage()
        {
            return image;
        }
        public void Shoot()
        {
            Point velocity = new Point(Constants.BULLET_VELOCITY_X,0);
            body.SetVelocity(velocity);
        }
         public void MoveNext(int maxX, int maxY, Point MousePosition)
        {
           // int x = ((MousePosition.GetX() / position.GetX()) + maxX) % maxX;
           // int y = ((MousePosition.GetY() / position.GetY()) + maxY) % maxY;
           // position = new Point(x, y);
        }
    }
}