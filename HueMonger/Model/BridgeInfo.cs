using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HueMonger.Model
{
    [DataContract(Name = "root", Namespace = "urn:schemas-upnp-org:device-1-0")]
    public class BridgeInfo
    {
        [DataMember(Name = "specVersion",Order =0)]
        public BridgeSpecVersion SpecVersion
        {
            get;
            set;
        }

        [DataMember(Name = "URLBase",  Order =1)]
        public string UrlBase
        {
            get;
            set;
        }

        [DataMember(Name = "device", Order =2)]
        public BridgeDevice Device
        {
            get;
            set;
        }

        public string IPAddress
        {
            get;
            set;
        }
    }
}
