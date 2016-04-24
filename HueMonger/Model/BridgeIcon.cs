using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HueMonger.Model
{
    [DataContract(Name = "icon", Namespace = "urn:schemas-upnp-org:device-1-0")]
    public class BridgeIcon
    {
        [DataMember(Name = "mimetype", Order =0)]
        public string MimeType
        {
            get;
            set;
        }

        [DataMember(Name = "height", Order =1)]
        public int Height
        {
            get;
            set;
        }

        [DataMember(Name = "width", Order =2)]
        public int Width
        {
            get;
            set;
        }

        [DataMember(Name = "depth", Order =3)]
        public int Depth
        {
            get;
            set;
        }

        [DataMember(Name = "url", Order =4)]
        public string Url
        {
            get;
            set;
        }
       
    }
}
