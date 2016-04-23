using Q42.HueApi;
using Q42.HueApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static async Task<string> Register(string ip)
        {
            ILocalHueClient client = new LocalHueClient(ip);
            var appKey = await client.RegisterAsync("huemonger", "huemonger");
            return appKey;
        }
    }
}
