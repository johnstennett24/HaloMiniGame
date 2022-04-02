using HaloMiniGame.Game.Services;
using HaloMiniGame.Game.Casting;


namespace HaloMiniGame.Game.Scripting
{

    

    public class CollideEnemyAction : Action
    {
        private AudioService audioService;
        
        public CollideEnemyAction(AudioService audioService)
        {
            this.audioService = audioService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            MC mC = (MC)cast.GetFirstActor(Constants.MC_GROUP);
            Enemy enemy = (Enemy)cast.GetFirstActor(Constants.ENEMY_GROUP);
            Body MCBody = mC.GetBody();
            Body EnemyBody = enemy.GetBody();
        }
    }
}