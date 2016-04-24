using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using HueMonger.Model;
using HueMonger.View;
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

        public ConfigViewModel Config
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ConfigViewModel>();
            }
        }

        static ViewModelLocator()
        {
            RegisterNavigationService();
            RegisterViewModels();
            RegisterMessages();
        }

        private static void RegisterNavigationService()
        {
            var navigationService = InitNavigationService();
            SimpleIoc.Default.Register<INavigationService>(() => navigationService);
        }

        static void RegisterViewModels()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<ConfigViewModel>();
        }

        static void RegisterMessages()
        {
            var main = ServiceLocator.Current.GetInstance<MainViewModel>();
            Messenger.Default.Register<BridgeInfo>(main, main.OnConfigured);
        }

        protected static INavigationService InitNavigationService()
        {
            var service = new NavigationService();

            service.Configure(typeof(MainViewModel).FullName, typeof(MainPage));
            service.Configure(typeof(ConfigViewModel).FullName, typeof(ConfigPage));

            return service;
        }
    }
}
