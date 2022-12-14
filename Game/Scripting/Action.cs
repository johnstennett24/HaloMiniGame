using System;
using Raylib_cs;
using HaloMiniGame.Game.Casting;


namespace HaloMiniGame.Game.Scripting
{
    public interface Action
    {
        void Execute(Cast cast, Script script, ActionCallback callback);
    }
}
