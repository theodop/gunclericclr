using System;
using GunCleric.Rendering;
using System.Text;

namespace guncleric.console.Rendering
{
    public class BasicOutputter : IOutputter
    {
        private readonly StringBuilder _sb = new();

        public void Init()
        {

            Console.OutputEncoding = Encoding.UTF8;
            try
            {
                Console.Clear();
            }
            catch { }

            Console.CursorVisible = false;
        }

        public void Output(RenderedImage image, RenderedImage lastImage)
        {
            Console.SetCursorPosition(0, 0);
            _sb.Clear();

            for (int y = 0; y < image.Size.Height; y++)
            {
                ColouredChar[] row = image.GetRow(y);

                foreach (ColouredChar cchar in row)
                {
                    _sb.Append(cchar.Char);
                }
            }

            var bytes = Encoding.UTF8.GetBytes(_sb.ToString());
            Console.Write(_sb.ToString());
        }
    }
}