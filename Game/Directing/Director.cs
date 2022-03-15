using System.Collections.Generic;
using HaloMiniGame.Game.Casting;
using HaloMiniGame.Game.Scripting;
using HaloMiniGame.Game.Services;

namespace HaloMiniGame.Game.Directing
{
    public class Director: ActionCallback
    {
        private Cast cast;
        private Script script;
        private SceneManager sceneManager;
        private VideoService videoService;


        /// Construct a new instance of Director using VideoService
        public Director(VideoService videoService)
        {
            this.videoService = videoService
            this.cast = new Cast();
            this.script = new Script();
            this.sceneManager = new SceneManager();
        }

    }
}