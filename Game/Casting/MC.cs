using System;
using System.Collections.Generic;


namespace HaloMiniGame.Game.Casting
{
    /// <summary>
    /// 
    /// </summary>
    public class MC : Actor
    {
        private int health = 3;
        private Point position = new Point(0, 0);
        private Point velocity = new Point(0, 0);

        private Body body;
        private Image image;

        /// <summary>
        /// Constructs a new instance of Actor.
        /// </summary>
        public MC(Body body, Image image, bool debug = false) : base(debug)
        {
            this.body = body;
            this.image = image;
        }
        
        /// <summary>
        /// Gets the body.
        /// </summary>
        /// <returns>The body.</returns>
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

        public void MoveNext(int maxX, int maxY)
        {
            int x = ((position.GetX() + velocity.GetX()) + maxX) % maxX;
            int y = ((position.GetY() + velocity.GetY()) + maxY) % maxY;
            position = new Point(x, y);
        }
    }
}