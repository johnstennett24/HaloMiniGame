using System;


namespace HaloMiniGame.Game.Casting
{
    /// <summary>
    /// <para>A thing that participates in the game.</para>
    /// <para>
    /// The responsibility of Actor is to keep track of its appearance, position and velocity in 2d 
    /// space.
    /// </para>
    /// </summary>
    public class Actor
    {
        private int health = 3;
        private Point position = new Point(0, 0);
        private Point velocity = new Point(0, 0);
        private bool debug;

        /// <summary>
        /// Constructs a new instance of Actor.
        /// </summary>
        public Actor(bool debug)
        {
            this.debug = debug;
        }


        public bool IsDebug()
        {
            return debug;
        }

        /// <summary>
        /// Gets the actor's position.
        /// </summary>
        /// <returns>The position.</returns>
        public Point GetPosition()
        {
            return position;
        }

        /// <summary>
        /// Gets the actor's current velocity.
        /// </summary>
        /// <returns>The velocity.</returns>
        public Point GetVelocity()
        {
            return velocity;
        }

        public int GetHealth()
        {
            return health;
        }

        public void SetHealth(int health)
        {
            if (health == null)
            {
                throw new ArgumentException("health can't be null");
            }
            this.health = health;
        }


        /// <summary>
        /// Sets the actor's position to the given value.
        /// </summary>
        /// <param name="position">The given position.</param>
        /// <exception cref="ArgumentException">When position is null.</exception>
        public void SetPosition(Point position)
        {
            if (position == null)
            {
                throw new ArgumentException("position can't be null");
            }
            this.position = position;
        }

        /// <summary>
        /// Sets the actor's velocity to the given value.
        /// </summary>
        /// <param name="velocity">The given velocity.</param>
        /// <exception cref="ArgumentException">When velocity is null.</exception>
        public void SetVelocity(Point velocity)
        {
            if (velocity == null)
            {
                throw new ArgumentException("velocity can't be null");
            }
            this.velocity = velocity;
        }

    }
}