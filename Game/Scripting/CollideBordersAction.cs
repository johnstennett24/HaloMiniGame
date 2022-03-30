using HaloMiniGame.Game.Services;
using HaloMiniGame.Game.Casting;



namespace HaloMiniGame.Game.Scripting
{
    public class CollideBordersAction : Action
    {
        private AudioService audioService;
        
        public CollideBordersAction(AudioService audioService)
        {
            this.audioService = audioService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            MC mc = (MC)cast.GetFirstActor(Constants.MC_GROUP);
            Body body = mc.GetBody();
            Point position = body.GetPosition();
            int x = position.GetX();
            int y = position.GetY();

            if (x < Constants.FIELD_LEFT)
            {
            }
            else if (x >= Constants.FIELD_RIGHT - Constants.MC_WIDTH)
            {
            }

            if (y < Constants.FIELD_TOP)
            {
            }
            else if (y >= Constants.FIELD_BOTTOM - Constants.MC_WIDTH)
            {
                Stats stats = (Stats)cast.GetFirstActor(Constants.STATS_GROUP);
                stats.RemoveLife();

                if (stats.GetLives() > 0)
                {
                    callback.OnNext(Constants.TRY_AGAIN);
                }
                else
                {
                    callback.OnNext(Constants.GAME_OVER);
                }
            }
        }
    }
}