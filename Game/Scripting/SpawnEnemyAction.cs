using HaloMiniGame.Game.Casting;
using HaloMiniGame.Game.Services;
using HaloMiniGame.Game.Scripting;
using HaloMiniGame.Game.Directing;

namespace HaloMiniGame.Game.Scripting
{
    class SpawnAsteroidsAction : Action 
    {    
        private (int x, int y) windowSize;
        private bool timerStarted;
        private bool asteroidSpawn;
        private DateTime lastSpawn;
        private float spawnInterval_ms;
        private Random random;

        public SpawnAsteroidsAction(int priority, (int, int) windowSize, float spawnInterval) : base(priority) {
            this.windowSize = windowSize;
            this.timerStarted = false;
            this.asteroidSpawn = false;
            this.lastSpawn = new DateTime();
            this.spawnInterval_ms = spawnInterval * 1000;
            this.random = new Random();
        }

        private Enemy1 CreateEnemy(int type, int x, int y) {
            if (type == 1) 
            { 
                Point Spawn1 = Constants.LeftSpawn;
                return new Enemy1;
            }
             else if (type == 2) 
            { 
                Point Spawn1 = Constants.RightSpawn;
                return new Enemy1("./asteroid/assets/asteroids/asteroid_large.png",
                                    15, 15,           // Width and height of asteroid
                                    x, y,            // X and Y of asteroid
                                    velX, 3,         // vX and vY of enemy
                                    1, true);        // how many points is this asteroid worth?
            }
            else if (type == 3) 
            { 
                Point Spawn1 = Constants.TopSpawn;
                return new Enemy1("./asteroid/assets/asteroids/asteroid_large.png",
                                    15, 15,           // Width and height of asteroid
                                    x, y,            // X and Y of asteroid
                                    velX, 3,         // vX and vY of enemy
                                    1, true);        // how many points is this asteroid worth?
            }
             else 
            { 
                Point Spawn1 = Constants.BottomSpawn;
                return new Enemy1("./asteroid/assets/asteroids/asteroid_large.png",
                                    15, 15,           // Width and height of asteroid
                                    x, y,            // X and Y of asteroid
                                    velX, 3,         // vX and vY of enemy
                                    1, true);        // how many points is this asteroid worth?
            }
        }

        public void Execute(Cast cast, Script script, ActionCallback callback) 
        {
            if (!this.timerStarted) {
                this.timerStarted = true;
                this.lastSpawn = DateTime.Now;
        }

            // If the spawn interval has passed, spawn a new asteroid
            if ((DateTime.Now - this.lastSpawn).TotalMilliseconds >= this.spawnInterval_ms) {

                // Randomly select a type from 1 to 3 (excluding the 4)
                // 1 is large. 2 is medium. 3 is small
                int asteroidType = this.randomGenerator.Next(1, 4);

                // The x-range within which the asteroid should spawn
                int lowerXBound = (int) (this.windowSize.x /8);
                int upperXBound = (int) (this.windowSize.x - lowerXBound);

                // Start within the x-range on top of the screen
                int startPosX = this.randomGenerator.Next(lowerXBound, upperXBound);
                int startPosY = 0;

                // Create a new asteroid with the type and position
                Enemy1 enemy = this.CreateEnemy(type, startPosX, startPosY);

                // Add the newly created asteroid to the cast
                cast.AddActor("asteroids", enemy);

                // lastSpawn is right now.
                this.lastSpawn = DateTime.Now;
            }
        }
    }
}