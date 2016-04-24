using GalaSoft.MvvmLight;
using Q42.HueApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
