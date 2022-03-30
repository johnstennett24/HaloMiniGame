using System;
using Raylib_cs;
using HaloMiniGame.Game.Casting;
using HaloMiniGame.Game.Services;
using HaloMiniGame.Game.Directing;

namespace HaloMiniGame.Game.Scripting
{
    public class ControlActorAction : Action
    {
        private KeyboardService keyboardService;

        public ControlActorAction(KeyboardService keyboardService)
        {
            this.keyboardService = keyboardService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            MC mc = (MC)cast.GetFirstActor(Constants.MC_GROUP);
            if (keyboardService.IsKeyDown(Constants.LEFT))
            {
                MC.Left();
            }
            else if (keyboardService.IsKeyDown(Constants.RIGHT))
            {
                MC.Right();
            }
            else if (keyboardService.IsKeyDown(Constants.UP))
            {
                MC.Up();
            }
            else if (keyboardService.IsKeyDown(Constants.DOWN))
            {
                MC.Down();
            }
            else
            {
                MC.StopMoving();
            }
        }
    }
}