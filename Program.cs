using System;
using GunCleric.Controllers;

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
