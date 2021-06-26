using System;
using guncleric.console.Rendering;
using GunCleric.Assets;
using GunCleric.Enemies;
using GunCleric.Events;
using GunCleric.Game;
using GunCleric.Input;
using GunCleric.Items;
using GunCleric.Levels;
using GunCleric.Player;
using GunCleric.Rendering;
using GunCleric.Saving;
using GunCleric.Scheduler;

namespace GunCleric
{
    class Program
    {
        static void Main(string[] args)
        {
            //var outputter = new ConsoleOutputter();
            var outputter = new TCCOutputter();
            var gameController = new GameFactory().GetGameController(outputter);
            gameController.Start();
        }
    }
}
