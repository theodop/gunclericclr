using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunCleric.Assets
{
    public interface IStringFormatter
    {
        public string Format(string formatString, object input);

        public string Format(string formatString, IDictionary<string, object> input);
    }
}
