using System;
using System.Collections.Generic;


namespace HaloMiniGame.Game.Casting
{
    /// <summary>
    /// 
    /// </summary>
    public class Enemy : Actor
    {
        private int health = 1;
        private Point position = new Point(0, 0);
        private Point velocity = new Point(0, 0);

        private Body body;
        private Image image;

        /// <summary>
        /// Constructs a new instance of Actor.
        /// </summary>
        public Enemy(Body body, Image image, bool debug = false) : base(debug)
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

        public void MoveNext(int maxX, int maxY, Point McPosition)
        {
            int x = ((McPosition.GetX() / position.GetX()) + maxX) % maxX;
            int y = ((McPosition.GetY() / position.GetY()) + maxY) % maxY;
            position = new Point(x, y);
        }
    }
}