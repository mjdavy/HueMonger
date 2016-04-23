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
    }
}
