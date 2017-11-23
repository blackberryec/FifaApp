using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using FifaApp.Annotations;
using Prism.Navigation;
using Xamarin.Forms;

namespace FifaApp.Mvvm
{
    public class ViewModelBase : Prism.Mvvm.BindableBase, INavigatedAware
    {
        protected INavigationService NavigationService { get; }

        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        private bool _isBusy;

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                if (SetProperty(ref _isBusy, value))
                {
                    RaisePropertyChanged(nameof(IsNotBusy));
                }
            }
        }
        public bool IsNotBusy => !IsBusy;

        public virtual void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(NavigationParameters parameters)
        {

        }

        private string _title;

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        //public virtual void Init(object param = null)
        //{

        //}

        //protected Task NavigateToPageAsync<T>(object param) where T : ViewBase
        //{
        //    if (Application.Current.MainPage is NavigationPage navigationPage)
        //    {
        //        return navigationPage.Navigation.PushAsync(
        //            (ViewBase)Activator.CreateInstance(typeof(T), param));
        //    }

        //    return Task.FromResult((object)null);
        //}

        //protected Task NavigateToPageAsync<T>() where T : Page
        //{
        //    if (Application.Current.MainPage is NavigationPage navigationPage)
        //    {
        //        return navigationPage.Navigation.PushAsync(
        //            Activator.CreateInstance<T>());
        //    }

        //    return Task.FromResult((object)null);
        //}


    }
}