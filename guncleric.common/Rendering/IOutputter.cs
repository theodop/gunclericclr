using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunCleric.Rendering
{
    public interface IOutputter
    {
        void Init();
        void Output(RenderedImage image, RenderedImage lastImage);
    }
}
