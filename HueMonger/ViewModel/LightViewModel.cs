using GalaSoft.MvvmLight;
using HueMonger.Model;
using Q42.HueApi;
using Q42.HueApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace HueMonger.ViewModel
{
    public class LightViewModel : ViewModelBase
    {
        private Light light;

        public LightViewModel(Light light)
        {
            this.light = light;
        }

        public string Name
        {
            get
            {
                return light.Name;
            }
        }

        public int Brightness
        {
            get
            {
                return light.State.Brightness / 255 * 100;
            }
            set
            {
                var cmd = new LightCommand();
                cmd = (value == 0) ? cmd.TurnOff() : cmd.TurnOn();
                var brightness = (byte?)((double)value / 100.0 * 255.0);
                cmd.Brightness = brightness;
                SendLightCommands(cmd);
            }
        }

        public void SendLightCommands(LightCommand command)
        {
            SendLightsCommands(new List<string>() { this.light.Id }, command);
        }

        public async void SendLightsCommands(IList<string> lights, LightCommand command)
        {
            ILocalHueClient client = new LocalHueClient(AppSettings.Instance.DeviceIPAddress, AppSettings.Instance.UserKey);
            await client.SendCommandAsync(command, lights);
        }

    }
}
