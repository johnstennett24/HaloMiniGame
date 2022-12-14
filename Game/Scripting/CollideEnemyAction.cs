using HaloMiniGame.Game.Services;
using HaloMiniGame.Game.Casting;


namespace HaloMiniGame.Game.Scripting
{
   

    public class CollideEnemyAction : Action
    {
        private AudioService audioService;
        private PhysicsService physicsService;
        
        public CollideEnemyAction(PhysicsService physicsService,AudioService audioService)
        {
            this.audioService = audioService;
            this.physicsService = physicsService;
        }

               public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            MC mC = (MC)cast.GetFirstActor(Constants.MC_GROUP);
            List<Actor> enemies = cast.GetActors(Constants.ENEMY_GROUP);
            
            foreach (Actor actor in enemies)
            {
                Enemy enemy = (Enemy)actor;
                Body MCBody = mC.GetBody();
                Body EnemyBody = enemy.GetBody();
                int health = mC.GetHealth();
                Stats stats = (Stats)cast.GetFirstActor(Constants.STATS_GROUP);


                if (physicsService.HasCollided(MCBody, EnemyBody))
                {
                    Sound sound = new Sound(Constants.GETTING_SHOT_SOUND);
                    audioService.PlaySound(sound);
                    health = health -1;
                    stats.RemoveLife();
                    mC.SetHealth(health);
                    cast.RemoveActor(Constants.ENEMY_GROUP, enemy);
                }
            }
            
        }
    }
}