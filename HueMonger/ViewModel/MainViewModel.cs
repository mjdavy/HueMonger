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
        }

        public ObservableCollection<LightViewModel> HueLights
        {
            get;
            set;
        }

        public bool IsNotConfigured()
        {
            return (string.IsNullOrEmpty(AppSettings.Instance.UserKey));
        }

        internal async void OnConfigured(BridgeInfo bridgeInfo)
        {
            var navService = ServiceLocator.Current.GetInstance<INavigationService>();
            var lights = await HueMonger.Model.Bridge.GetLights(bridgeInfo.IPAddress, AppSettings.Instance.UserKey);
            UpdateLights(lights);
            navService.NavigateTo(typeof(MainViewModel).FullName);
        }

        private void UpdateLights(IEnumerable<Light> lights)
        {
            this.HueLights = new ObservableCollection<LightViewModel>();
            foreach (var light in lights)
            {
                var vm = new LightViewModel(light);
                this.HueLights.Add(vm);
            }
        }
    }
}
