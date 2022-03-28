using System;
using System.Collections.Generic;


namespace Unit06.Game.Casting
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
        private Animation animation;

        /// <summary>
        /// Constructs a new instance of Actor.
        /// </summary>
        public MC(Body body, Animation animation, bool debug = false) : base(debug)
        {
            this.body = body;
            this.animation = animation;
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
        public Animation GetAnimation()
        {
            return animation;
        }

        public void MoveNext(int maxX, int maxY)
        {
            int x = ((position.GetX() + velocity.GetX()) + maxX) % maxX;
            int y = ((position.GetY() + velocity.GetY()) + maxY) % maxY;
            position = new Point(x, y);
        }
    }
}