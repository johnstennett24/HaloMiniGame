namespace HaloMiniGame.Game.Casting
{
    /// <summary>
    /// A thing that participates in the game.
    /// </summary>
    public class Stats : Actor
    {
        private int level;
        private int lives;
        private string text = "Time: ";
        private float timer = 0;

        /// <summary>
        /// Constructs a new instance of Actor.
        /// </summary>
        public Stats(int level = 1, int lives = 3, bool debug = false) : base(debug)
        {
            this.level = level;
            this.lives = lives;
        }

        /// <summary>
        /// Adds one level.
        /// </summary>
        public void AddLevel()
        {
            level++;
        }

        /// <summary>
        /// Adds an extra life.
        /// </summary>
        public void AddLife()
        {
            lives++;
        }

        /// <summary>
        /// Gets the level.
        /// </summary>
        /// <returns>The level.</returns>
        public int GetLevel()
        {
            return level;
        }

        /// <summary>
        /// Gets the lives.
        /// </summary>
        /// <returns>The lives.</returns>
        public int GetLives()
        {
            return lives;
        }

        /// <summary>
        /// Removes a life.
        /// </summary>
        public void RemoveLife()
        {
            lives -= 1;
        }
    
        public void SetTime(float ntimer)
        {
            this.timer = ntimer;
        }

        public string GetTimer()
        {
            return text + timer;
        }

        public void updateTimer(int frames)
        {
            if (frames > 15)
            {
                timer++;
            }
        }
    }
}