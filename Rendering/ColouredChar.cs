using System;
using System.Collections.Generic;
using System.Drawing;

namespace GunCleric.Rendering
{
    public struct ColouredChar
    {
        public char Char;
        public Color Color;

        public ColouredChar(char thisChar, Color color) : this()
        {
            Char = thisChar;
            Color = color;
        }

        public ColouredChar(char thisChar) : this()
        {
            Char = thisChar;
            Color = Color.White;
        }

        public static implicit operator ColouredChar(char c) => new ColouredChar(c);

        public override string ToString()
        {
            return Char.ToString();
        }
    }
}
