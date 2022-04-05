using HaloMiniGame.Game.Services;
using HaloMiniGame.Game.Casting;


namespace HaloMiniGame.Game.Scripting
{
   

    public class CollideBulletAction : Action
    {
        private AudioService audioService;
        private PhysicsService physicsService;
        
        public CollideBulletAction(PhysicsService physicsService,AudioService audioService)
        {
            this.audioService = audioService;
            this.physicsService = physicsService;
        }

               public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            List<Actor> enemies = cast.GetActors(Constants.ENEMY_GROUP);
            List<Actor> bullets = cast.GetActors(Constants.BULLET_GROUP);
            
            foreach (Actor actor1 in enemies)
            {
                Enemy enemy = (Enemy)actor1;
                Body EnemyBody = enemy.GetBody();
                foreach (Actor actor2  in bullets)
                {
                    bullet bullet = (bullet)actor2;
                    Body bulletbody = bullet.GetBody();

                    if (physicsService.HasCollided(bulletbody, EnemyBody))
                    {
                        Sound sound = new Sound(Constants.GETTING_SHOT_SOUND);
                        audioService.PlaySound(sound);
                        cast.RemoveActor(Constants.ENEMY_GROUP, enemy);
                        cast.RemoveActor(Constants.BULLET_GROUP, bullet);
                    }
                }
            }
        }
    }
}