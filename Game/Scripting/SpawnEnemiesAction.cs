using HaloMiniGame.Game.Casting;
using HaloMiniGame.Game.Directing;


namespace HaloMiniGame.Game.Scripting
{
    class SpawnEnemiesAction : Action
    {
        private List<Point> spawnPoints = new List<Point>();
        private bool timerStarted;
        private DateTime lastSpawn;
        private float spawnInterval_ms;
        private Random randomGenerator;
        // Clock clock;



        public SpawnEnemiesAction(float spawnInterval)
        {
            spawnPoints.Add(Constants.Spawn1);
            spawnPoints.Add(Constants.Spawn2);
            spawnPoints.Add(Constants.Spawn3);
            spawnPoints.Add(Constants.Spawn4);
            spawnPoints.Add(Constants.Spawn5);
            spawnPoints.Add(Constants.Spawn6);
            spawnPoints.Add(Constants.Spawn7);
            this.timerStarted = false;
            this.lastSpawn = new DateTime();
            this.spawnInterval_ms = spawnInterval * 1000;
            this.randomGenerator = new Random();
            // this.clock = clock;
        }

        // public void Execute(Cast cast, Script script, ActionCallback callback)
        // {   

        //     SpawnEnemie(cast, script, clock, callback);
        // }
        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            if (!this.timerStarted)
            {
                this.timerStarted = true;
                this.lastSpawn = DateTime.Now;
            }

            // If the spawn interval has passed, spawn a new asteroid
            if ((DateTime.Now - this.lastSpawn).TotalMilliseconds >= this.spawnInterval_ms)
            {

                // Randomly select a type from 1 to 3 (excluding the 4)
                // 1 is large. 2 is medium. 3 is small
                int positionNumber = this.randomGenerator.Next(1, 7);

                // The x-range within which the asteroid should spawn
                // int lowerXBound = (int) (this.windowSize.x /8);
                // int upperXBound = (int) (this.windowSize.x - lowerXBound);

                // // Start within the x-range on top of the screen
                // int startPosX = this.randomGenerator.Next(lowerXBound, upperXBound);
                // int startPosY = 0;

                // Create a new asteroid with the type and position
                Point position = spawnPoints[positionNumber];
                Point size = new Point(Constants.ENEMY_WIDTH, Constants.ENEMY_HEIGHT);
                Point velocity = new Point(0, 0);

                Body body = new Body(position, size, velocity);
                Image image = new Image(Constants.ENEMY_IMAGE);
                Enemy enemy = new Enemy(body, image, false);
        
                cast.AddActor(Constants.ENEMY_GROUP, enemy);

                // Add the newly created asteroid to the cast
                // cast.AddActor("asteroids", asteroid);

                // lastSpawn is right now.
                this.lastSpawn = DateTime.Now;
            }
        }
    }
}
