using SmartFormat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunCleric.Assets
{
    public class StringFormatterSmartFormat : IStringFormatter
    {
        public string Format(string formatString, object input)
        {
            return Smart.Format(formatString, input);
        }

        public string Format(string formatString, IDictionary<string, object> input)
        {
            throw new NotImplementedException();
        }
    }
}
