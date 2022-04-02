using HaloMiniGame.Game.Casting;
using HaloMiniGame.Game.Services;
using HaloMiniGame.Game.Scripting;
using HaloMiniGame.Game.Directing;

namespace HaloMiniGame.Game.Scripting
{
    class DrawEnemyAction : Action 
   {
       private VideoService videoService;
        
        public DrawEnemyAction(VideoService videoService)
        {
            this.videoService = videoService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            List<Actor> enemies = cast.GetActors(Constants.ENEMY_GROUP);
            foreach (Actor actor in enemies)
            {
                Enemy enemy = (Enemy)actor;
                Body body = enemy.GetBody();

                if (enemy.IsDebug())
                {
                    Rectangle rectangle = body.GetRectangle();
                    Point size = rectangle.GetSize();
                    Point pos = rectangle.GetPosition();
                    videoService.DrawRectangle(size, pos, Constants.PURPLE, false);
                }

                Image image = enemy.GetImage();
                Point position = body.GetPosition();
                videoService.DrawImage(image, position);
            }
        }
   }
    
}