﻿using GalaSoft.MvvmLight;
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
                return (int)((double)light.State.Brightness / 255.0 * 100.0);
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

        public SolidColorBrush LightBrush
        {
            get
            {
                var rgb = light.State.ToRgb();
                var R = Convert.ToByte(255 * rgb.R);
                var G = Convert.ToByte(255 * rgb.G);
                var B = Convert.ToByte(255 * rgb.B);

                return new SolidColorBrush(Color.FromArgb(255,R,G,B));
            }
            //set
            //{
            //    var cmd = new LightCommand();
            //    cmd = (value == 0) ? cmd.TurnOff() : cmd.TurnOn();
            //    cmd.ColorTemperature = value;
            //    SendLightCommands(cmd);
            //}
        }

        public async void SendLightCommands(LightCommand command)
        {
            try
            {
                await Model.Bridge.SendLightsCommands(command, new List<string>() { light.Id });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
