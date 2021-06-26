using GunCleric.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunCleric.Events
{
    public class EventKeeper : IEventListener
    {
        private List<GCEvent> _events = new List<GCEvent>();
        private AssetBank _assetBank;

        public EventKeeper(EventBus eventBus, AssetBank assetBank)
        {
            _assetBank = assetBank;
            eventBus.AddListener(this);
        }

        public void GiveMeAnEvent(GCEvent gcEvent)
        {
            _events.Add(gcEvent);
        }

        public GCEvent GetLatestEvent()
        {
            return _events.Any() ? _events.Last() : null;
        }

        public string GetLatestEventString()
        {
            var latestEvent = GetLatestEvent();
            return latestEvent == null
                ? ""
                : _assetBank.GetAssetString(latestEvent.Id, latestEvent.Values);
        }
    }
}
