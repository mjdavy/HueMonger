﻿using GalaSoft.MvvmLight;
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
        private INavigationService navigationService;
        private ObservableCollection<LightViewModel> _hueLights;
        private bool _lightsOn;
        private LightViewModel _selectedLight;

        public MainViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;

            if (IsInDesignMode)
            {
                this.HueLights = new ObservableCollection<LightViewModel>();
                for (int i = 0; i < 10; i++)
                {
                    var name = string.Format("Test Light {0}", i);
                    var light = new Light();
                    light.Name = name;
                    light.Id = name;
                    light.State = new State();
                    light.State.Brightness = 0;

                    var vm = new LightViewModel(light);
                    this.HueLights.Add(vm);
                }
            }
        }

        public ObservableCollection<LightViewModel> HueLights
        {
            get
            {
                return _hueLights;
            }
            set
            {
                Set(() => HueLights, ref _hueLights, value);
            }
        }

        public LightViewModel SelectedLight
        {
            get
            {
                return _selectedLight;
            }
            set
            {
                if (_selectedLight != null)
                {
                    _selectedLight.Select(false);
                }
                Set(() => SelectedLight, ref _selectedLight, value);

                if (_selectedLight != null)
                {
                    _selectedLight.Select(true);
                }
            }
        }

        public bool AllLightsOn
        {
            get
            {
                return _lightsOn;
            }
            set
            {
                Set(() => AllLightsOn, ref _lightsOn, value);
                SwitchLights();
            }
        }

        public async void SwitchLights()
        {
            var cmd = new LightCommand();
            cmd = (AllLightsOn) ? cmd.TurnOn() : cmd.TurnOff();
            await Model.Bridge.SendLightsCommands(cmd);
        }

        public bool IsNotConfigured()
        {
            return (string.IsNullOrEmpty(AppSettings.Instance.UserKey));
        }

        public async void Update()
        {
            var lights = await HueMonger.Model.Bridge.GetLights();
            UpdateLights(lights);
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
