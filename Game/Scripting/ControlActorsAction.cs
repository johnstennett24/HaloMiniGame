using System;
using Raylib_cs;
using HaloMiniGame.Game.Casting;
using HaloMiniGame.Game.Services;

namespace HaloMiniGame.Game.Scripting
{
    public class ControlActorsAction : Action
    {
        private KeyBoardService keyBoardService;
        private Point direction = new Point(constants.CELL_SIZE, 0);
    }

    
}