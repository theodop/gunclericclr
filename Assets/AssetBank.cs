using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunCleric.Assets
{
    public class AssetBank
    {
        public string GetAssetString(string id, IDictionary<string, object> values)
        {
            string result;
            if (_assetStrings.TryGetValue(id, out result))
            {
                if (values != null)
                {
                    foreach (var kvp in values)
                    {
                        result = result.Replace($"{kvp.Key}", kvp.Value.ToString());
                    }
                }
            }
            else result = $"Asset string {id} not found.";

            return result;
        }

        private IDictionary<string, string> _assetStrings = new Dictionary<string, string>
        {
            {"WELCOME", "Welcome to GunCleric!" },
            {"HIT", "{doer} hit {doee}." }
        };
    }
}
