using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using HueMonger.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace HueMonger.ViewModel
{
    public class ConfigViewModel : ViewModelBase
    {
        private Visibility _messageVisibility;
        private bool _configInProgress;
        private string _configMessage;
        private DispatcherTimer timer;

        public Visibility MessageVisibility
        {
            get
            {
                return _messageVisibility;
            }

            set
            {
                Set(() => MessageVisibility, ref _messageVisibility, value);
            }
        }

        public string ConfigMessage
        {
            get
            {
                return _configMessage;
            }

            set
            {
                Set(() => ConfigMessage, ref _configMessage, value);
            }
        }

        public bool ConfigInProgress
        {
            get
            {
                return _configInProgress;
            }
            set
            {
                Set(() => ConfigInProgress, ref _configInProgress, value);
                ConfigureCommand.RaiseCanExecuteChanged();
            }
        }

        public BridgeInfo BridgeConfiguration
        {
            get;
            private set;
        }

        public ConfigViewModel()
        {
            ConfigureCommand = new RelayCommand(Configure, CanConfigure);
            timer = new DispatcherTimer();
        }

        public RelayCommand ConfigureCommand
        {
            get;
            private set;
        } 

        public async void Configure()
        {
            ConfigInProgress = true;
            ConfigMessage = "Searching for Hue Bridges...";
            var ipList = await Bridge.Find();

            var configList = new List<BridgeInfo>();
            foreach(var ip in ipList)
            {
                var config = await Bridge.GetConfiguration(ip);
                configList.Add(config);
            }

            switch (configList.Count())
            {
                case 0:
                    ConfigMessage = "No Hue bridge found.";
                    break;
                case 1:
                    ConfigureBridge(configList.First());
                    
                    break;
                default:
                    ChooseBridge(configList);
                    break; 
            }
        }

        public bool CanConfigure()
        {
            return !this.ConfigInProgress;
        }

        private void ChooseBridge(List<BridgeInfo> configList)
        {
            throw new NotImplementedException();
        }

        private void ConfigureBridge(BridgeInfo config)
        {
            AppSettings.Instance.DeviceIPAddress = config.IPAddress;
            this.BridgeConfiguration = config;
            ConfigMessage = "Press the button on your bridge...";
            timer.Interval = new TimeSpan(0, 0, 5);
            timer.Start();
            timer.Tick += Timer_Tick;
        }

        private async void Timer_Tick(object sender, object e)
        {
            try
            {
                string ip = AppSettings.Instance.DeviceIPAddress;
                AppSettings.Instance.UserKey = await Bridge.Register(ip);
                timer.Stop();
                Messenger.Default.Send<BridgeInfo>(this.BridgeConfiguration);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
    }
}
