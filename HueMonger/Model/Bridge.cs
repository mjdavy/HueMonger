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
        public static async Task<IEnumerable<string>> Initialize()
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
            var appKey = await client.RegisterAsync("huemonger", "mjdavy@hotmail.com");
            return appKey;
        }
    }
}
