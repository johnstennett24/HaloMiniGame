using System;
using Raylib_cs;
using HaloMiniGame.Game.Casting;
using HaloMiniGame.Game.Directing;
using HaloMiniGame.Game.Services;



namespace HaloMiniGame.Game.Scripting
{
    public class SpawnBulletAction : Action
    {
        private KeyboardService keyboardService;

        public SpawnBulletAction(KeyboardService keyboardService)
        {
            this.keyboardService = keyboardService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {   
            if (keyboardService.IsKeyDown(Constants.SPACE))
            {
                MC mC = (MC)cast.GetFirstActor(Constants.MC_GROUP);
                Point mcPosition = mC.GetBody().GetPosition();
                Point position = mcPosition;
                Point size = new Point(Constants.BULLET_WIDTH, Constants.BULLET_HEIGHT);
                Point velocity = new Point(0, 0);

                Body body = new Body(position, size, velocity);
                HaloMiniGame.Game.Casting.Image image = new HaloMiniGame.Game.Casting.Image(Constants.BULLET_IMAGE);
                bullet bullet = new bullet(body, image, false);
        
                cast.AddActor(Constants.BULLET_GROUP, bullet);
            }
        }
    }
}