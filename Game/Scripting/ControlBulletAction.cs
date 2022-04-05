using HaloMiniGame.Game.Casting;
using HaloMiniGame.Game.Directing;
using HaloMiniGame.Game.Services;

namespace HaloMiniGame.Game.Scripting
{
    public class ControlBulletAction : Action
    {
        private AudioService audioService;

        private KeyboardService keyboardService;
        public ControlBulletAction(AudioService audioService, KeyboardService keyboardService)
        {
            this.audioService = audioService;
            this.keyboardService = keyboardService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {   
            foreach (bullet bullet in cast.GetActors(Constants.BULLET_GROUP))
            {            
                bullet.Shoot();
    
            }
        }
    }
}