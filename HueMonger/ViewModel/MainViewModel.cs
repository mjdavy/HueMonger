using GalaSoft.MvvmLight;
using HueMonger.Model;
using System;
using System.Collections.Generic;
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

        public bool IsNotConfigured()
        {
            return (string.IsNullOrEmpty(AppSettings.Instance.UserKey));
        }
    }
}
