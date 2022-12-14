using Raylib_cs;
using HaloMiniGame.Game.Casting;
using HaloMiniGame.Game.Services;


namespace HaloMiniGame.Game.Scripting
{
    public class EndDrawingAction : Action
    {
        private VideoService videoService;
        
        public EndDrawingAction(VideoService videoService)
        {
            this.videoService = videoService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            videoService.FlushBuffer();
        }
    }
}