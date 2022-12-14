using System;
using Raylib_cs;
using HaloMiniGame.Game.Casting;
using HaloMiniGame.Game.Services;
using HaloMiniGame.Game.Directing;

namespace HaloMiniGame.Game.Scripting
{
    public class ControlActorsAction : Action
    {
        private KeyboardService keyboardService;

        public ControlActorsAction(KeyboardService keyboardService)
        {
            this.keyboardService = keyboardService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            MC mc = (MC)cast.GetFirstActor(Constants.MC_GROUP);
            if (keyboardService.IsKeyDown(Constants.LEFT))
            {
                mc.Left();
            }
            else if (keyboardService.IsKeyDown(Constants.RIGHT))
            {
                mc.Right();
            }
            else if (keyboardService.IsKeyDown(Constants.UP))
            {
                mc.Up();
            }
            else if (keyboardService.IsKeyDown(Constants.DOWN))
            {
                mc.Down();
            }
            else
            {
                mc.StopMoving();
            }
        }
    }
}