using HaloMiniGame.Game.Casting;
using HaloMiniGame.Game.Directing;
using HaloMiniGame.Game.Scripting;
using HaloMiniGame.Game.Services;

namespace HaloMiniGame.Game.Scripting
{
    public class MoveEnemyAction : Action
    {
        public MoveEnemyAction()
        {
        }


  //  public void Execute(Cast cast, Script script, ActionCallback callback)
   //     {   
   //         List<> enemies = new List<Actor>();
   //         enemies = cast.GetAllActors(Constants.ENEMY_GROUP);
   //         foreach (Enemy enemy in enemies)
   //         {
   //             Point position = enemy.GetBody().GetPosition();
   //             position = position.Add(enemy.GetBody().GetVelocity());
   //             enemy.GetBody().SetPosition(position);
   //         }
   //         
   //     }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Enemy enemy = (Enemy)cast.GetFirstActor(Constants.ENEMY_GROUP);
            Point position = enemy.GetBody().GetPosition();
            position = position.Add(enemy.GetBody().GetVelocity());
            enemy.GetBody().SetPosition(position);
        }
    }
}