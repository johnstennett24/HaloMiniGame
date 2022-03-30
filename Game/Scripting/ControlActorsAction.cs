using System;
using Raylib_cs;
using HaloMiniGame.Game.Casting;
using HaloMiniGame.Game.Services;
using HaloMiniGame;

namespace HaloMiniGame.Game.Scripting
{
    public class ControlActorsAction : Action
    {
        private KeyboardService KeyboardService;
        private Point direction = new Point(Constants.CELL_SIZE, 0);
    }
}