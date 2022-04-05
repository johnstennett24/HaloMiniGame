using System;
using System.Collections.Generic;
using System.IO;
using HaloMiniGame.Game.Casting;
using HaloMiniGame.Game.Scripting;
using HaloMiniGame.Game.Services;


namespace HaloMiniGame.Game.Directing
{
    public class SceneManager
    {
        public static AudioService AudioService = new RaylibAudioService();
        public static KeyboardService KeyboardService = new RaylibKeyboardService();
        public static MouseService MouseService = new RaylibMouseService();
        public static PhysicsService PhysicsService = new RaylibPhysicsService();

        public static VideoService VideoService = new RaylibVideoService(Constants.GAME_NAME,
            Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT, Constants.BLACK);

        public SceneManager()
        {
        }

        public void PrepareScene(string scene, Cast cast, Script script)
        {
            if (scene == Constants.NEW_GAME)
            {
                PrepareNewGame(cast, script);
            }
            else if (scene == Constants.GAME_OVER)
            {
                PrepareGameOver(cast, script);
            }
        }

        private void PrepareNewGame(Cast cast, Script script)
        {
            AddStats(cast);
            AddLevel(cast);
            AddLives(cast);
            AddMC(cast);
            AddEnemy(cast);
            AddDialog(cast, Constants.ENTER_TO_START);

            script.ClearAllActions();
            AddInitActions(script);
            AddLoadActions(script);

            ChangeSceneAction a = new ChangeSceneAction(KeyboardService, Constants.NEXT_LEVEL);
            script.AddAction(Constants.INPUT, a);

            AddUpdateActions(script);
            AddOutputActions(script);
            AddUnloadActions(script);
            AddReleaseActions(script);
        }


        private void PrepareGameOver(Cast cast, Script script)
        {
            AddMC(cast);
            AddDialog(cast, Constants.WAS_GOOD_GAME);

            script.ClearAllActions();

            TimedChangeSceneAction ta = new TimedChangeSceneAction(Constants.NEW_GAME, 5, DateTime.Now);
            script.AddAction(Constants.INPUT, ta);

            AddOutputActions(script);
        }

        // -----------------------------------------------------------------------------------------
        // casting methods
        // -----------------------------------------------------------------------------------------

        private void AddMC(Cast cast)
        {
            cast.ClearActors(Constants.MC_GROUP);
        
            int x = Constants.MC_WIDTH;
            int y = Constants.CENTER_Y;
        
            Point position = new Point(x, y);
            Point size = new Point(Constants.MC_WIDTH, Constants.MC_HEIGHT);
            Point velocity = new Point(0, 0);
        
            Body body = new Body(position, size, velocity);
            Image image = new Image(Constants.MC_IMAGE);
            MC mc = new MC(body, image, false);
        
            cast.AddActor(Constants.MC_GROUP, mc);
        }

        private void AddEnemy(Cast cast)
        {
            cast.ClearActors(Constants.ENEMY_GROUP);
            // add the spawn action enemies

            List<Point> enemyPoints = new List<Point>();
            enemyPoints.Add(Constants.TopSpawn);
            enemyPoints.Add(Constants.RightSpawn);
            enemyPoints.Add(Constants.BottomSpawn);

            for (int i = 0; i < enemyPoints.Count; i ++)
            {
                int x = enemyPoints[i].GetX();
                int y = enemyPoints[i].GetY();
                Point position = new Point(x,y);
                Point size = new Point(Constants.ENEMY_WIDTH, Constants.ENEMY_HEIGHT);
                Point velocity = new Point(0, 0);

                Body body = new Body(position, size, velocity);
                Image image = new Image(Constants.ENEMY_IMAGE);
                Enemy enemy = new Enemy(body, image, false);
        
            cast.AddActor(Constants.ENEMY_GROUP, enemy);
                
            }

        }

        private void AddDialog(Cast cast, string message)
        {
            cast.ClearActors(Constants.DIALOG_GROUP);

            Text text = new Text(message, Constants.FONT_FILE, Constants.FONT_SIZE, 
                Constants.ALIGN_CENTER, Constants.WHITE);
            Point position = new Point(Constants.CENTER_X, Constants.CENTER_Y);

            Label label = new Label(text, position);
            cast.AddActor(Constants.DIALOG_GROUP, label);   
        }

        private void AddLevel(Cast cast)
        {
            cast.ClearActors(Constants.LEVEL_GROUP);

            Text text = new Text(Constants.LEVEL_FORMAT, Constants.FONT_FILE, Constants.FONT_SIZE, 
                Constants.ALIGN_LEFT, Constants.WHITE);
            Point position = new Point(Constants.HUD_MARGIN, Constants.HUD_MARGIN);

            Label label = new Label(text, position);
            cast.AddActor(Constants.LEVEL_GROUP, label);
        }

        private void AddLives(Cast cast)
        {
            cast.ClearActors(Constants.LIVES_GROUP);

            Text text = new Text(Constants.LIVES_FORMAT, Constants.FONT_FILE, Constants.FONT_SIZE, 
                Constants.ALIGN_RIGHT, Constants.WHITE);
            Point position = new Point(Constants.SCREEN_WIDTH - Constants.HUD_MARGIN, 
                Constants.HUD_MARGIN);

            Label label = new Label(text, position);
            cast.AddActor(Constants.LIVES_GROUP, label);   
        }

        private void AddTimer(Cast cast)
        {
            cast.ClearActors(Constants.TIMER_GROUP);

            Text text = new Text(Constants.TIMER_FORMAT, Constants.FONT_FILE, Constants.FONT_SIZE, 
                Constants.ALIGN_CENTER, Constants.WHITE);
            Point position = new Point(Constants.CENTER_X, Constants.HUD_MARGIN);
            
            Label label = new Label(text, position);
            cast.AddActor(Constants.TIMER_GROUP, label);   
        }

        private void AddStats(Cast cast)
        {
            cast.ClearActors(Constants.STATS_GROUP);
            Stats stats = new Stats();
            cast.AddActor(Constants.STATS_GROUP, stats);
        }

                // -----------------------------------------------------------------------------------------
        // scriptig methods
        // -----------------------------------------------------------------------------------------

        private void AddInitActions(Script script)
        {
            script.AddAction(Constants.INITIALIZE, new InitializeDevicesAction(AudioService, 
                VideoService));
        }

        private void AddLoadActions(Script script)
        {
            script.AddAction(Constants.LOAD, new LoadAssetsAction(AudioService, VideoService));
        }

        private void AddOutputActions(Script script)
        {
            script.AddAction(Constants.OUTPUT, new StartDrawingAction(VideoService));
            script.AddAction(Constants.OUTPUT, new DrawHudAction(VideoService));
            script.AddAction(Constants.OUTPUT, new DrawMCAction(VideoService));
            script.AddAction(Constants.OUTPUT, new DrawEnemyAction(VideoService));
            script.AddAction(Constants.OUTPUT, new EndDrawingAction(VideoService));
        }

        private void AddUnloadActions(Script script)
        {
            script.AddAction(Constants.UNLOAD, new UnloadAssetsAction(AudioService, VideoService));
        }

        private void AddReleaseActions(Script script)
        {
            script.AddAction(Constants.RELEASE, new ReleaseDevicesAction(AudioService, 
                VideoService));
        }

        private void AddUpdateActions(Script script) 
        {
            script.AddAction(Constants.UPDATE, new ControlActorsAction(KeyboardService));
            script.AddAction(Constants.UPDATE, new ControlEnemyAction());
            script.AddAction(Constants.UPDATE, new MoveEnemyAction());
            script.AddAction(Constants.UPDATE, new MoveActorsAction());
            script.AddAction(Constants.UPDATE, new CollideBordersAction(AudioService));
            script.AddAction(Constants.UPDATE, new CollideEnemyAction(PhysicsService, AudioService));
            script.AddAction(Constants.UPDATE, new CheckOverAction());     
        }
    }
}