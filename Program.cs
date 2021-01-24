﻿using System;
using GunCleric.Game;
using GunCleric.Rendering;

namespace GunCleric
{
    class Program
    {
        static void Main(string[] args)
        {
            var gameController = new GameController(
                new RenderController()
            );

            gameController.Start();
        }
    }
}
