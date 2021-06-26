using GunCleric.Game;
using GunCleric.Extensions;
using System;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Collections.Generic;

namespace GunCleric.Rendering
{
    public class RenderController : IDisposable
    {
        private IOutputter _outputter;

        public RenderController(IOutputter outputter)
        {
            _outputter = outputter;
        }

        public void Initialise(GameState gameState)
        { 
            if (gameState.LastImage == null)
            {
                gameState.LastImage = new RenderedImage(gameState.WindowSize);
            }

            _outputter.Init();
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

            _outputter.Output(newImage, gameState.LastImage);

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

        public void Dispose()
        {
            try { Console.Clear(); } catch { }
        }
    }
}