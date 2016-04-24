using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HueMonger.Model
{
    [DataContract(Name = "device", Namespace = "urn:schemas-upnp-org:device-1-0")]
    public class BridgeDevice
    {
        [DataMember(Name = "deviceType", Order =0)]
        public string DeviceType
        {
            get;
            set;
        }

        [DataMember(Name = "friendlyName", Order =1)]
        public string FriendlyName
        {
            get;
            set;
        }

        [DataMember(Name = "manufacturer", Order =2)]
        public string Manufacturer
        {
            get;
            set;
        }

        [DataMember(Name = "manufacturerURL", Order =3)]
        public string ManufacturerUrl
        {
            get;
            set;
        }

        [DataMember(Name = "modelDescription", Order =4)]
        public string ModelDescription
        {
            get;
            set;
        }

        [DataMember(Name = "modelName",Order =5)]
        public string ModelName
        {
            get;
            set;
        }

        [DataMember(Name = "modelNumber", Order =6)]
        public string ModelNumber
        {
            get;
            set;
        }

        [DataMember(Name = "modelURL",Order =7)]
        public string ModelUrl
        {
            get;
            set;
        }

        [DataMember(Name = "serialNumber", Order =8)]
        public string SerialNumber
        {
            get;
            set;
        }

        [DataMember(Name = "UDN", IsRequired =true, Order =9)]
        public string UniqueDeviceNumber
        {
            get;
            set;
        }

        [DataMember(Name = "presentationURL", Order =10)]
        public string PresentationUrl
        {
            get;
            set;
        }

        [DataMember(Name = "iconList", Order =11)]
        public IList<BridgeIcon> IconList
        {
            get;
            set;
        }
    }
}
