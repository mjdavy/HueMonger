using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HueMonger.Model
{
    [DataContract(Name = "specVersion", Namespace = "urn:schemas-upnp-org:device-1-0")]
    public class BridgeSpecVersion
    {
        [DataMember(Name = "major")]
        public int Major
        {
            get;
            set;
        }

        [DataMember(Name = "minor")]
        public int Minor
        {
            get;
            set;
        }
    }
}
