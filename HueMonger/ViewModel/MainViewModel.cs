using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using HueMonger.Model;
using Microsoft.Practices.ServiceLocation;
using Q42.HueApi;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HueMonger.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            //if (string.IsNullOrEmpty(AppSettings.Instance.UserKey))
            //{
            //    Register()
            //}
        }

        public ObservableCollection<Light> Lights
        {
            get;
            set;
        }

        public bool IsNotConfigured()
        {
            return (string.IsNullOrEmpty(AppSettings.Instance.UserKey));
        }

        internal void OnConfigured(BridgeInfo bridgeInfo)
        {
            var navService = ServiceLocator.Current.GetInstance<INavigationService>();
            navService.NavigateTo(typeof(MainViewModel).FullName);
        }
    }
}
