using GunCleric.Extensions;
using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunCleric.Rendering
{
    public class RenderedImage
    {
        public readonly Size Size;

        private ColouredChar[] _image;

        public RenderedImage(Size size)
        {
            Size = size;
            _image = new ColouredChar[size.Width*size.Height];
            _image.Populate(new ColouredChar(' '));
        }

        public RenderedImage(RenderedImage lastImage)
        {
            Size = lastImage.Size;
            _image = new ColouredChar[Size.Width * Size.Height];
            lastImage._image.CopyTo(_image);
        }

        public RenderedImage(int width, int height)
        {
            Size = new Size(width, height);
            _image = new ColouredChar[width * height];
            _image.Populate(new ColouredChar(' '));
        }

        public ColouredChar[] GetRow(int row)
        {
            return _image[(row*Size.Width)..((row+1)*Size.Width)];
        }

        internal void Inject(ColouredChar[] newLine, int x, int y)
        {
            for (int i = x; i < Math.Min(Size.Width, newLine.Length + x); i++)
            {
                _image[y*Size.Width+i] = newLine[i - x];
            }
        }
    }
}
