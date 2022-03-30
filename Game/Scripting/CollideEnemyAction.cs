using HaloMiniGame.Game.Services;
using HaloMiniGame.Game.Casting;


namespace HaloMiniGame.Game.Scripting
{

    

    public class CollideRacketAction : Action
    {
        private AudioService audioService;
        MC mc = new MC();
        Enemy1 enemy = new Enemy1();
        
        public CollideRacketAction(AudioService audioService)
        {
            this.audioService = audioService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            MC mC = (MC)cast.GetFirstActor(Constants.MC_GROUP);
            Enemy1 enemy = (Enemy1)cast.GetFirstActor(Constants.ENEMY_GROUP);
            Body MCBody = mc.GetBody();
            Body EnemyBody = enemy.GetBody();
        }
    }
}