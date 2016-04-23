using GalaSoft.MvvmLight;
using HueMonger.Model;
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
            Init();
        }

        public ObservableCollection<Light> Lights
        {
            get;
            set;
        }
            
        public async void Init()
        {
            var bridges = await Bridge.Initialize();
            var myBridge = bridges.First();
            var key = await Bridge.Register(myBridge);
            
        }
    }
}
