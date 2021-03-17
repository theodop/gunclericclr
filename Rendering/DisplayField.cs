using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;

namespace GunCleric.Rendering
{
    public class DisplayField
    {
        public Rectangle DrawArea { get; set; }

        public int X => DrawArea.X;
        public int Y => DrawArea.Y;

        [NotNull]
        private Func<string> _getValueFunc;

        public string GetValue()
        {
            var value = _getValueFunc()?.Trim() ?? "";

            if (value.Length < DrawArea.Width) 
            {
                value = $"{value}{new string(' ', DrawArea.Width - value.Length)}";
            } 
            else
            {
                value = value.Substring(0, DrawArea.Width);
            }

            return value;
        }

        public DisplayField(Rectangle drawArea, Func<string> getValueFunc)
        {
            _getValueFunc = getValueFunc;
            DrawArea = drawArea;
        }

        public DisplayField(int x, int y, int width, Func<string> getValueFunc) 
            : this(new Rectangle(x, y, width, 1), getValueFunc)
        {

        }
    }
}