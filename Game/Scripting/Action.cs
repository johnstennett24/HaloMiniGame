using System;
using Raylib_cs;


namespace HaloMiniGame.Game.Scripting
{
    public interface Action
    {
        void Execute(Cast cast, Script script, Actioncallback callback);
    }
}
