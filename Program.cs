using System;
using HaloMiniGame.Game.Directing;
using HaloMiniGame.Game.Services;

namespace HaloMiniGame
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