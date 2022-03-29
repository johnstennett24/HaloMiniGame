using MiniHaloGame;


namespace HaloMiniGame.Game.Scripting
{
    public class CollideRacketAction : Action
    {
        private AudioService audioService;
        private PhysicsService physicsService;
        
        public CollideRacketAction(PhysicsService physicsService, AudioService audioService)
        {
            this.physicsService = physicsService;
            this.audioService = audioService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Ball ball = (Ball)cast.GetFirstActor(Constants.PLAYER_GROUP);
            Racket racket = (Racket)cast.GetFirstActor(Constants.ENEMY_GROUP);
            Body ballBody = ball.GetBody();
            Body racketBody = racket.GetBody();

            if (physicsService.HasCollided(racketBody, ballBody))
            {
                ball.BounceY();
                Sound sound = new Sound(Constants.BOUNCE_SOUND);
                audioService.PlaySound(sound);
            }
        }
    }
}