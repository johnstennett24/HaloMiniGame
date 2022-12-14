using System;
using Raylib_cs;

namespace HaloMiniGame.Game.Scripting
{
    public interface ActionCallback
    {
    void OnNext(string SceneName);
    }
}
