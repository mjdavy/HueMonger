using Q42.HueApi;
using Q42.HueApi.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace HueMonger.Model
{
    public class Bridge
    {
        public async void Find(Action<IEnumerable<string>> callBack)
        {
            var ipList = await Find();
            callBack(ipList);
        }

        public static async Task<IEnumerable<string>> Find()
        {
            IBridgeLocator locator = new HttpBridgeLocator();

            //For Windows 8 and .NET45 projects you can use the SSDPBridgeLocator which actually scans your network. 
            //See the included BridgeDiscoveryTests and the specific .NET and .WinRT projects
            IEnumerable<string> bridgeIPs = await locator.LocateBridgesAsync(TimeSpan.FromSeconds(5));
            return bridgeIPs;
        }

        public static async Task<BridgeInfo> GetConfiguration(string ip)
        {
            var endPoint = string.Format("http://{0}/description.xml", ip);

            HttpClient client = new HttpClient();
            
            using (var stream = await client.GetStreamAsync(endPoint))
            {
                var serializer = new DataContractSerializer(typeof(BridgeInfo));
                var reader = XmlDictionaryReader.CreateTextReader(stream, new XmlDictionaryReaderQuotas());
                var config = serializer.ReadObject(reader) as BridgeInfo;
                config.IPAddress = ip;
                return config;
            }
        }

        public static async Task<string> Register(string ip)
        {
            ILocalHueClient client = new LocalHueClient(ip);
            var appKey = await client.RegisterAsync("huemonger", "huemonger");
            return appKey;
        }
    }
}
