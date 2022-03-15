using System;
using HaloMiniGame.Game.Directing;
using HaloMiniGame.Game.Services;

namespace
{
    public class Program
    {
        static void Main(string[] args)
        {
            Director director = new Director(SceneManager.VideoService);
            director.StartGame();
        }
    }
}