using System.Collections.Generic;
using HaloMiniGame.Game.Casting;


namespace HaloMiniGame
{
    public class Constants
    {

        public static string GAME_NAME = "Halo Mini Game";
        public static int FRAME_RATE = 60;
        public static int CELL_SIZE = 15;

        // SCREEN
        public static int SCREEN_WIDTH = 1040;
        public static int SCREEN_HEIGHT = 680;
        public static int CENTER_X = SCREEN_WIDTH / 2;
        public static int CENTER_Y = SCREEN_HEIGHT / 2;

        // FIELD
        public static int FIELD_TOP = 60;
        public static int FIELD_BOTTOM = SCREEN_HEIGHT;
        public static int FIELD_LEFT = 0;
        public static int FIELD_RIGHT = SCREEN_WIDTH;

        // FONT
        public static string FONT_FILE = "Assets/Fonts/Halo.ttf";
        public static int FONT_SIZE = 32;

        // SOUND - Need to find yet 
        // public static string BOUNCE_SOUND = "Assets/Sounds/boing.wav";
        // public static string WELCOME_SOUND = "Assets/Sounds/start.wav";
        // public static string OVER_SOUND = "Assets/Sounds/over.wav";

        // TEXT
        public static int ALIGN_LEFT = 0;
        public static int ALIGN_CENTER = 1;
        public static int ALIGN_RIGHT = 2;


        // COLORS
        public static Color BLACK = new Color(0, 0, 0);
        public static Color WHITE = new Color(255, 255, 255);
        public static Color PURPLE = new Color(255, 0, 255);

        // KEYS
        public static string LEFT = "left";
        public static string RIGHT = "right";
        public static string SPACE = "space";
        public static string ENTER = "enter";
        public static string PAUSE = "p";

        public static string UP = "up";
        public static string DOWN = "down";

        // SCENES
        public static string NEW_GAME = "new_game";
        public static string TRY_AGAIN = "try_again";
        public static string NEXT_LEVEL = "next_level";
        public static string IN_PLAY = "in_play";
        public static string GAME_OVER = "game_over";

        // LEVELS - Need tgo figured it out yet
        public static string LEVEL_FILE = "Assets/Data/level-{0:000}.txt";
        public static int BASE_LEVELS = 5;

        // ----------------------------------------------------------------------------------------- 
        // SCRIPTING CONSTANTS
        // ----------------------------------------------------------------------------------------- 

        // PHASES
        public static string INITIALIZE = "initialize";
        public static string LOAD = "load";
        public static string INPUT = "input";
        public static string UPDATE = "update";
        public static string OUTPUT = "output";
        public static string UNLOAD = "unload";
        public static string RELEASE = "release";

        // ----------------------------------------------------------------------------------------- 
        // CASTING CONSTANTS
        // ----------------------------------------------------------------------------------------- 

        // STATS
        public static string STATS_GROUP = "stats";
        public static int DEFAULT_LIVES = 3;
        public static int MAXIMUM_LIVES = 5;

        // HUD
        public static int HUD_MARGIN = 15;
        public static string LEVEL_GROUP = "level";
        public static string LIVES_GROUP = "lives";
        public static string TIMER_GROUP = "timer";
        public static string LEVEL_FORMAT = "LEVEL: {0}";
        public static string LIVES_FORMAT = "LIVES: {0}";
        public static string TIMER_FORMAT = "TIMER: {0}";

        // // Captain - Personage
        public static string MC_GROUP = "masterchief";
        public static int MC_WIDTH = 20;
        public static int MC_HEIGHT = 28;
        public static int MC_VELOCITY = 6;  
        public static int MC_RATE = 4;
        public static List<string> MC_IMAGES
            = new List<string>() {
                "Assets/Images/100.png",
                "Assets/Images/101.png",
                "Assets/Images/102.png"
            };


        // ENEMY
        public static string ENEMY_GROUP = "enemy";
        public static string BALL_IMAGE = "Assets/Images/000.png";
        public static int ENEMY_WIDTH = 20;
        public static int ENEMY_HEIGHT = 28;
        public static Point TopSpawn = new Point(Constants.CENTER_X,0);
        public static Point RightSpawn = new Point(Constants.SCREEN_WIDTH,Constants.CENTER_Y);

        public static Point BottomSpawn = new Point(Constants.CENTER_X,Constants.SCREEN_HEIGHT);
        public static Point LeftSpawn = new Point(0,Constants.CENTER_Y);


        // DIALOG - Create our own dialogue
        public static string DIALOG_GROUP = "dialogs";
        public static string ENTER_TO_START = "PRESS ENTER TO START";
        public static string PREP_TO_LAUNCH = "PREPARING TO LAUNCH";
        public static string WAS_GOOD_GAME = "GAME OVER";


















    }
}