using Prism.Commands;
using FifaApp.Mvvm;
using Prism.Navigation;

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
