using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HueMonger.ViewModel
{
    public class ViewModelLocator
    {
        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        static ViewModelLocator()
        {
            RegisterViewModels();
            RegisterMessages();
        }

        static void RegisterViewModels()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MainViewModel>();
        }

        static void RegisterMessages()
        {
            //var main = ServiceLocator.Current.GetInstance<MainViewModel>();
            //Messenger.Default.Register<SearchMessage>(main, 1, main.OnSearch);
        }
    }
}
