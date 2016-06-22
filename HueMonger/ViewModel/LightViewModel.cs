using GalaSoft.MvvmLight;
using HueMonger.Model;
using Q42.HueApi;
using Q42.HueApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace HueMonger.ViewModel
{
    public class LightViewModel : ViewModelBase
    {
        private DispatcherTimer timer;
        private int _brightness;
        private SolidColorBrush _lightBrush;
        private string _name;

        public LightViewModel(Light light)
        {
            this.timer = new DispatcherTimer();
            this.timer.Interval = TimeSpan.FromMilliseconds(100);
            this.timer.Tick += Timer_Tick;
            this.Update(light);
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                Set(() => Name, ref _name, value);
            }
        }

        public int Brightness
        {
            get
            {
                return _brightness;
            }
            set
            {
                Set(() => Brightness, ref _brightness, value);
                this.timer.Start();
            }
        }

        public SolidColorBrush LightBrush
        {
            get
            {
                return _lightBrush;
            }
            set
            {
                Set(() => LightBrush, ref _lightBrush, value);
                this.timer.Start();
            }
        }

        public string LightId
        {
            get;
            private set;
        }

        public void Select(bool selected = true)
        {
           
        }

        public async void SendLightCommands(LightCommand command)
        {
            try
            {
                await Model.Bridge.SendLightsCommands(command, new List<string>() { LightId });  
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void Update(Light light)
        {
            this.LightId = light.Id;
            this.Name = light.Name;
            this.Brightness = (int)((double)light.State.Brightness / 255.0 * 100.0);
            var rgb = light.State.ToRgb();
            var R = Convert.ToByte(255 * rgb.R);
            var G = Convert.ToByte(255 * rgb.G);
            var B = Convert.ToByte(255 * rgb.B);
            this.LightBrush = new SolidColorBrush(Color.FromArgb(255, R, G, B));
        }

        private async void Timer_Tick(object sender, object e)
        {
            timer.Stop();

            // set brightness
            var cmd = new LightCommand();
            cmd = (_brightness == 0) ? cmd.TurnOff() : cmd.TurnOn();
            var brightness = (byte?)((double)_brightness / 100.0 * 255.0);
            cmd.Brightness = brightness;

            // set color
            var color = this._lightBrush.Color;
            cmd.SetColor(color.R, color.G, color.B);
            SendLightCommands(cmd);

            // get changes and update
            var light = await HueMonger.Model.Bridge.GetLight(this.LightId);
            this.Update(light);
            RaisePropertyChanged("Brightness");
            RaisePropertyChanged("LightBrish");
        }
    }
}
