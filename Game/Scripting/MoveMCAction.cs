using HaloMiniGame.Game.Casting;
using HaloMiniGame.Game.Scripting;
using HaloMiniGame.Game.Services;

namespace HaloMiniGame.Game.Scripting
{
    public class MoveMCAction : Action
    {
        private AudioService audioService;
        public MoveMCAction(AudioService audioService)
        {
            this.audioService = audioService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            MC mC = (MC)cast.GetFirstActor(Constants.MC_GROUP);
            Body body = mC.GetBody();
            Point position = body.GetPosition();
            Point velocity = body.GetVelocity();
            int x = position.GetX();

            position = position.Add(velocity);
            if (x < 0)
            {
                position = new Point(0, position.GetY());
            }
            else if (x > Constants.SCREEN_WIDTH - Constants.MC_WIDTH)
            {
                position = new Point(Constants.SCREEN_WIDTH - Constants.MC_WIDTH, 
                    position.GetY());
            }
            body.SetPosition(position);
        }
    }
}