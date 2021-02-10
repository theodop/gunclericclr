using GunCleric.Game;
using GunCleric.Extensions;
using System;
using System.Linq;

namespace GunCleric.Rendering
{
    public class RenderController
    {
        public void Initialise(GameState gameState)
        {
            if (gameState.LastImage == null)
            {
                gameState.LastImage = new char[gameState.WindowSize.Height, gameState.WindowSize.Width];
                gameState.LastImage.Populate(' ');
            }
            Console.CursorVisible = false;
        }

        public void Render(GameState gameState)
        {
            var screen = gameState.CurrentScreen;
            var newImage = new char[gameState.WindowSize.Height, gameState.WindowSize.Width];
            gameState.LastImage.CopyTo(newImage);

            foreach (var viewport in screen.Viewports)
            {
                for (int i = 0; i < viewport.Area.Height; i++)
                {
                    var newLine = GenerateLine(viewport.Area.Width);
                    
                    for (int j = 0; j < viewport.Area.Width; j++)
                    {
                        char? thisChar = null;

                        foreach (var atom in gameState.CurrentLevel.GetAtoms(j, i))
                        {
                            thisChar = atom.Tile;
                        }

                        if (thisChar != null)
                        {
                            newLine[j] = thisChar.Value;
                        }
                    }

                    InjectIntoImage(newImage, newLine, viewport.Area.X, viewport.Area.Y + i);
                }
            }

            foreach (var displayField in screen.DisplayFields)
            {
                var value = displayField.GetValue();
                var lastX = Math.Min(displayField.X + value.Length, gameState.WindowSize.Width);

                if (gameState.WindowSize.Intersect(displayField.X, displayField.Y))
                {
                    InjectIntoImage(newImage, value.ToCharArray(), displayField.X, displayField.Y);
                }
            }

            RenderToConsole(newImage, gameState.LastImage);

            gameState.LastImage = newImage;
        }

        private char[] GenerateLine(int length, char value = ' ')
        {
            var line = new char[length];

            for (int i = 0; i < length; i++)
            {
                line[i] = value;
            }

            return line;
        }

        private void InjectIntoImage(char[,] image, char[] value, int x, int y)
        {
            for (int i = x; i < Math.Min(image.GetLength(1), value.Length + x); i++)
            {
                image[y, i] = value[i - x];
            }
        }

        private void RenderToConsole(char[,] newImage, char[,] lastImage)
        {
            for (int i = 0; i < newImage.GetLength(0); i++)
            {
                var newRow = newImage.GetRow(i);
                var oldRow = lastImage.GetRow(i);

                //if (newRow != oldRow)
                //{
                Console.SetCursorPosition(0, i);
                Console.WriteLine(newRow);
                //}
            }

            Console.SetCursorPosition(0, 0);
        }
    }
}