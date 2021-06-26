using GunCleric.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueColorConsole;

namespace guncleric.console.Rendering
{
    public class TCCOutputter : IOutputter
    {
        StringBuilder _sb = new StringBuilder();

        public void Init()
        {
            if (!VTConsole.IsEnabled) VTConsole.Enable();

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

                var row = image.GetRow(y);

                foreach (var cchar in row)
                {
                    _sb.Append(VTConsole.GetColorForegroundString(cchar.Color.R, cchar.Color.G, cchar.Color.B));
                    _sb.Append(cchar.Char);
                }
            }

            var bytes = Encoding.UTF8.GetBytes(_sb.ToString());
            VTConsole.WriteFast(bytes);
        }
    }
}
