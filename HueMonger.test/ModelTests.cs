using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using HueMonger.Model;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.IO;
using System.Xml;
using System.Text;

namespace HueMonger.test
{
    [TestClass]
    public class ModelTests
    {
        [TestMethod]
        public void SerializeConfiguration()
        {
            var info = new BridgeInfo();
            var version = new BridgeSpecVersion();
            var device = new BridgeDevice();
            var icon1 = new BridgeIcon();
            var icon2 = new BridgeIcon();

            icon1.Depth = 23;
            icon1.Height = 64;
            icon1.Width = 32;
            icon1.Url = "urlicon1";
            icon1.MimeType = "mimetype1";

            icon2.Depth = 10;
            icon2.Height = 99;
            icon2.Width = 44;
            icon2.Url = "urlicon2";
            icon2.MimeType = "mimetype2";

            version.Major = 7;
            version.Minor = 1;

            device.DeviceType = "someType";
            device.FriendlyName = "someFriendlyName";
            device.IconList = new List<BridgeIcon>();
            device.IconList.Add(icon1);
            device.IconList.Add(icon2);
            device.Manufacturer = "someManufacturer";
            device.ManufacturerUrl = "someManufacturerUrl";
            device.ModelDescription = "someModelDescription";
            device.ModelName = "someModelName";
            device.ModelNumber = "someModelNunber";
            device.ModelUrl = "someModelUrl";
            device.PresentationUrl = "somePresentationUrl";
            device.SerialNumber = "someSerialNumber";
            device.UniqueDeviceNumber = "someUniqueDeviceNumber";

            info.Device = device;
            info.SpecVersion = version;
            info.UrlBase = "someUrlBase";

            var serializer = new DataContractSerializer(typeof(BridgeInfo));

            var stream = new MemoryStream();
            serializer.WriteObject(stream, info);
            stream.Flush();
            var xmlString = Encoding.UTF8.GetString(stream.ToArray());

            Assert.IsTrue(stream.Length >0);
            
            


        }
    }
}
