﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using HueMonger.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private INavigationService navigationService;
        private ObservableCollection<BridgeViewModel> _bridgeList;
        private BridgeViewModel _selectedBridge;

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

        public ObservableCollection<BridgeViewModel> BridgeList
        {
            get
            {
                return _bridgeList;
            }
            set
            {
                Set(() => BridgeList, ref _bridgeList, value);
            }
        }

        public BridgeViewModel SelectedBridge
        {
            get
            {
                return _selectedBridge;
            }
            set
            {
                Set(() => SelectedBridge, ref _selectedBridge, value);
                if (value != null)
                {
                    this.navigationService.NavigateTo("Config2");
                    this.ConfigureBridge(value.Bridge);
                }
            }
        }

        public BridgeInfo BridgeConfiguration
        {
            get;
            private set;
        }

        
        public ConfigViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
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
            navigationService.NavigateTo("Config2");
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
            this.BridgeList = new ObservableCollection<BridgeViewModel>();
            foreach(var item in configList)
            {
                var bridgeVm = new BridgeViewModel(item);
                this.BridgeList.Add(bridgeVm);
            }
            navigationService.NavigateTo("Config3");
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
                await Bridge.Register();
                timer.Stop();
                this.navigationService.NavigateTo("Main");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
    }
}
