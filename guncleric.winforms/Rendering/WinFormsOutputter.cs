using GunCleric.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace guncleric.winforms.Rendering
{
    class WinFormsOutputter : IOutputter
    {
        private StringBuilder _sb = new StringBuilder();
        private RichTextBox _textBox;

        public WinFormsOutputter(RichTextBox textBox)
        {
            _textBox = textBox;
        }

        public void Init() { }

        public void Output(RenderedImage image, RenderedImage lastImage)
        {
            _sb.Clear();
            for (int y = 0; y<image.Size.Height; y++)
            {
                var row = image.GetRow(y);

                foreach (var cchar in row)
                {
                    _sb.Append(cchar.Char);
                }
                _sb.Append("\r\n");
            }

            if (_textBox.InvokeRequired)
            {
                _textBox.Invoke((MethodInvoker)delegate { _textBox.Text = _sb.ToString(); Colour(image); });
            }
        }

        private void Colour(RenderedImage image)
        {
            for (var y = 0; y < image.Size.Height; y++)
            {
                var row = image.GetRow(y);
                for (var x = 0; x < image.Size.Width; x++)
                {
                    var cchar = row[x];
                    if (cchar.Char != ' ')
                    {
                        _textBox.Select(y * (image.Size.Width+2) + x, 1);
                        _textBox.SelectionColor = cchar.Color;
                    }
                }
            }
        }
    }
}
