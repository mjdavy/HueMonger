using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HueMonger.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace HueMonger.ViewModel
{
    public class ConfigViewModel : ViewModelBase
    {
        private Visibility _messageVisibility;
        private bool _configInProgress;
        private string _configMessage;

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

        public ConfigViewModel()
        {
            ConfigureCommand = new RelayCommand(Configure, CanConfigure);
        }

        public RelayCommand ConfigureCommand
        {
            get;
            private set;
        } 

        public async void Configure()
        {
            ConfigInProgress = true;
            ConfigMessage = "Press the button on your bridge...";
            var ipList = await Bridge.Find();
        }

        public bool CanConfigure()
        {
            return !this.ConfigInProgress;
        }
    }
}
