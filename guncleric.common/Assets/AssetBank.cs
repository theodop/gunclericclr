using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunCleric.Assets
{
    public class AssetBank
    {
        private readonly IStringFormatter _stringFormatter;

        public AssetBank(IStringFormatter stringFormatter)
        {
            _stringFormatter = stringFormatter;
        }

        public string GetAssetString(string id, object values)
        {
            string result;
            if (_assetStrings.TryGetValue(id, out result))
            {
                if (values != null)
                {
                    result = _stringFormatter.Format(result, values);
                }
            }
            else result = $"Asset string {id} not found.";

            return result;
        }

        private IDictionary<string, string> _assetStrings = new Dictionary<string, string>
        {
            {"WELCOME", "Welcome to GunCleric!" },
            {"HIT", "{doer} hit {doee} for {damage} damage." },
            {"HIT_NO_DAM", "{doer} hit {doee} but it had no effect." },
            {"PICKUP", "{doer} picked up {doee}." }
        };
    }
}
