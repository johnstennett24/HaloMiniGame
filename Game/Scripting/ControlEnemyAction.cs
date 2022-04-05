using HaloMiniGame.Game.Casting;
using HaloMiniGame.Game.Directing;
using HaloMiniGame.Game.Scripting;
using HaloMiniGame.Game.Services;

namespace HaloMiniGame.Game.Scripting
{
    public class ControlEnemyAction : Action
    {
        public ControlEnemyAction()
        {
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            foreach (Enemy enemy in cast.GetActors(Constants.ENEMY_GROUP))
            {
                MC mC = (MC)cast.GetFirstActor(Constants.MC_GROUP);
                Point position = mC.GetBody().GetPosition();
                Point velocity = new Point(-Constants.ENEMY_VELOCITY_X,0);
                enemy.GetBody().SetVelocity(velocity);
            }
        }
    }
}