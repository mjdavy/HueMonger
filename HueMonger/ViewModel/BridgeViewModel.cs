using GalaSoft.MvvmLight;
using HueMonger.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HueMonger.ViewModel
{
    public class BridgeViewModel : ViewModelBase
    {
        private BridgeInfo _bridgeInfo;

        public BridgeViewModel(BridgeInfo bridgeInfo)
        {
            _bridgeInfo = bridgeInfo;
        }

        public BridgeInfo Bridge
        {
            get
            {
                return _bridgeInfo;
            }
        }

        public string FriendlyName
        {
            get
            {
                return _bridgeInfo.Device.FriendlyName;
            }
        }
    }
}
