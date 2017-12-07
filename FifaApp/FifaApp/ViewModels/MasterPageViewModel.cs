using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using FifaApp.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;

namespace FifaApp.ViewModels
{
    public class MasterPageViewModel : ViewModelBase
    {
        public MasterPageViewModel(INavigationService navigationService): base(navigationService)
        {
            NavigateCommand = new DelegateCommand<string>(Navigate);
        }

        private async void Navigate(string url)
        {
            await NavigationService.NavigateAsync(url);
        }

        public DelegateCommand<string> NavigateCommand { get; }
    }
}
