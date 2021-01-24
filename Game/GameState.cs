using System.Drawing;
using GunCleric.Atoms;
using GunCleric.Rendering;

namespace GunCleric.Game
{
    public class GameState
    {
        public string PlayerName = "Bungus";
        public int Hp = 100;
        public int Xp = 0;
        public string Armour = "Cool coat";
        public string Weapon = "Sick pistol";
        public Screen CurrentScreen;

        public Atom Player;

        public Rectangle WindowSize = new Rectangle(0, 0, 80, 25);

        public char[,] LastImage;
    }
}