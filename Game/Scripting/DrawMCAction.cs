using HaloMiniGame.Game.Casting;
using HaloMiniGame.Game.Directing;
using HaloMiniGame.Game.Scripting;
using HaloMiniGame.Game.Services;


namespace HaloMiniGame.Game.Scripting
{
    public class DrawMCAction : Action
    {
        private VideoService videoService;
        public DrawMCAction(VideoService videoService)
        {
            this.videoService = videoService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            MC mc = (MC)cast.GetFirstActor(Constants.MC_GROUP);
            Body body = mc.GetBody();

            if (mc.IsDebug())
            {
                Rectangle rectangle = body.GetRectangle();
                Point size = rectangle.GetSize();
                Point pos = rectangle.GetPosition();
                videoService.DrawRectangle(size, pos, Constants.PURPLE, false);
            }

            Image image = mc.GetImage();
            Point position = body.GetPosition();
            videoService.DrawImage(image, position);
        }
    }
}