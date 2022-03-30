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
            this.videoService = videoService;
            this.cast = new Cast();
            this.script = new Script();
            this.sceneManager = new SceneManager();
        }

        public void OnNext(string scene)
        {
            sceneManager.PrepareScene(scene, cast, script);
        }

        public void StartGame()
        {
            OnNext(Constants.NEW_GAME);
            ExecuteActions(Constants.INITIALIZE);
            ExecuteActions(Constants.LOAD);
            while (videoService.IsWindowOpen())
            {
                ExecuteActions(Constants.INPUT);
                ExecuteActions(Constants.UPDATE);
                ExecuteActions(Constants.OUTPUT);
            }
                ExecuteActions(Constants.UNLOAD);
                ExecuteActions(Constants.RELEASE);
        }

        private void ExecuteActions(string group)
        {
            List<HaloMiniGame.Game.Scripting.Action> actions = script.GetActions(group);
            foreach(HaloMiniGame.Game.Scripting.Action action in actions)
            {
                action.Execute(cast, script, this);
            }
        }
    }
}