using GunCleric.Game;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GunCleric.Saving
{
    public class SaveController
    {
        public void Save(GameState gameState)
        {
            /*
            var ser = new DataContractSerializer(gameState.GetType());
            using (var stream = File.OpenWrite("save.xml"))
            using (var writer = XmlWriter.Create(stream, new XmlWriterSettings()
            {

            }
            ))
            {
                ser.WriteObject(stream, gameState);
            } 
            man fuck this */
        }
    }
}
