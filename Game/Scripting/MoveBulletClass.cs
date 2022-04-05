using HaloMiniGame.Game.Casting;
using HaloMiniGame.Game.Directing;
using HaloMiniGame.Game.Scripting;
using HaloMiniGame.Game.Services;

namespace HaloMiniGame.Game.Scripting
{
    public class MoveBullet : Action
    {
        private AudioService audioService;
        public MoveBullet(AudioService audioService)
        {
            this.audioService = audioService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
           
            foreach (bullet bullet in cast.GetActors(Constants.BULLET_GROUP))
            {
                Point position = bullet.GetBody().GetPosition();
                position = position.Add(bullet.GetBody().GetVelocity());
                bullet.GetBody().SetPosition(position); 
            }
        }
    }
}