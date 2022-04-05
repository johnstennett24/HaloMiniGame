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

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            foreach (Enemy enemy in cast.GetActors(Constants.ENEMY_GROUP))
            {
                Point position = enemy.GetBody().GetPosition();
                position = position.Add(enemy.GetBody().GetVelocity());
                enemy.GetBody().SetPosition(position);            
            }
        }
    }
}