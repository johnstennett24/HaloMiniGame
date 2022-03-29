using HaloMiniGame.Game.Services;
using HaloMiniGame.Game.Casting;


namespace HaloMiniGame.Game.Scripting
{
    public class CollideRacketAction : Action
    {
        private AudioService audioService;
        
        public CollideRacketAction(AudioService audioService)
        {
            this.audioService = audioService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Ball ball = (Ball)cast.GetFirstActor(Constants.PLAYER_GROUP);
            Racket racket = (Racket)cast.GetFirstActor(Constants.ENEMY_GROUP);
            Body ballBody = ball.GetBody();
            Body racketBody = racket.GetBody();
        }
    }
}