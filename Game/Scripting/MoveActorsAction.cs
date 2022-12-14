using HaloMiniGame.Game.Casting;
using HaloMiniGame.Game.Directing;
using HaloMiniGame.Game.Scripting;
using HaloMiniGame.Game.Services;

namespace HaloMiniGame.Game.Scripting
{
    public class MoveActorsAction : Action
    {
        private AudioService audioService;
        public MoveActorsAction(AudioService audioService)
        {
            this.audioService = audioService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            MC mC = (MC)cast.GetFirstActor(Constants.MC_GROUP);
            Point position = mC.GetBody().GetPosition();
            position = position.Add(mC.GetBody().GetVelocity());
            mC.GetBody().SetPosition(position);
        }
    }
}