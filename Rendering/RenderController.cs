using GunCleric.Game;
using GunCleric.Extensions;
using System;
using System.Linq;
using System.Drawing;
using System.Text;
using Pastel;

namespace GunCleric.Rendering
{
    public class RenderController : IDisposable
    {

        private StringBuilder _sb = new StringBuilder();

        public void Initialise(GameState gameState)
        {
            try
            {
                Console.Clear();
            }
            catch { }

            if (gameState.LastImage == null)
            {
                gameState.LastImage = new RenderedImage(gameState.WindowSize);
            }
            Console.CursorVisible = false;
        }

        public void Render(GameState gameState)
        {
            var screen = gameState.CurrentScreen;
            var newImage = new RenderedImage(gameState.LastImage);

            foreach (var viewport in screen.Viewports)
            {
                var offsetX = viewport.AtomToTrack.Position.X - viewport.Area.Width / 2;
                var offsetY = viewport.AtomToTrack.Position.Y - viewport.Area.Height / 2;

                for (int i = 0; i < viewport.Area.Height; i++)
                {
                    var newLine = GenerateLine(viewport.Area.Width);
                    
                    for (int j = 0; j < viewport.Area.Width; j++)
                    {
                        ColouredChar? thisChar = null;

                        foreach (var atom in gameState.CurrentLevel.GetAtoms(j + offsetX, i + offsetY))
                        {
                            thisChar = atom.Tile;
                        }

                        if (thisChar != null)
                        {
                            newLine[j] = thisChar.Value;
                        }
                    }

                    newImage.Inject(newLine, viewport.Area.X, viewport.Area.Y + i);
                }
            }

            var renderRect = new Rectangle(new Point(0,0), gameState.WindowSize);

            foreach (var displayField in screen.DisplayFields)
            {
                var value = displayField.GetValue();
                var lastX = Math.Min(displayField.X + value.Length, gameState.WindowSize.Width);

                if (renderRect.Intersect(displayField.X, displayField.Y))
                {
                    newImage.Inject(value.ToColouredCharArray(), displayField.X, displayField.Y);
                }
            }

            RenderToConsole(newImage, gameState.LastImage);

            gameState.LastImage = newImage;
        }

        private ColouredChar[] GenerateLine(int length, char value = ' ')
        {
            var line = new ColouredChar[length];

            for (int i = 0; i < length; i++)
            {
                line[i] = value;
            }

            return line;
        }

        private void RenderToConsole(RenderedImage newImage, RenderedImage lastImage)
        {
            for (int i = 0; i < newImage.Size.Height; i++)
            {
                var newRow = newImage.GetRow(i);
                var oldRow = lastImage.GetRow(i);

                if (newRow != oldRow)
                {
                    Console.SetCursorPosition(0, i);
                    var row = RenderRow(newRow);
                    Console.Write(row);
                }
            }

            Console.SetCursorPosition(0, 0);
        }

        private string RenderRow(ColouredChar[] row)
        {
            _sb.Clear();
            foreach (var cchar in row)
            {
                _sb.Append(cchar.Char.ToString().Pastel(cchar.Color));
            }
            return _sb.ToString();
        }

        public void Dispose()
        {
            try { Console.Clear(); } catch { }
        }
    }
}