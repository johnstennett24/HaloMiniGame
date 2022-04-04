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
            MC mC = (MC)cast.GetFirstActor(Constants.MC_GROUP);
            Point position = mC.GetBody().GetPosition();
            position = position.Add(mC.GetBody().GetVelocity());
            mC.GetBody().SetPosition(position);
        }
    }
}