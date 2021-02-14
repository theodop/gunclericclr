using System;
using GunCleric.Game;
using GunCleric.Input;
using GunCleric.Levels;
using GunCleric.Rendering;
using GunCleric.Saving;

namespace GunCleric
{
    class Program
    {
        static void Main(string[] args)
        {
            var gameController = new GameController(
                new RenderController(),
                new InputController(),
                new SaveController(),
                new LevelController()
            );

            gameController.Start();
        }
    }
}
