using System.Collections.Generic;
using System.Threading.Tasks;
using FifaApp.Client;
using FifaApp.Models;
using FifaApp.Mvvm;
using FifaApp.Views;
using Prism.Navigation;

namespace FifaApp.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        private readonly FifaClient _fifaClient;
        private List<Competition> _competitions;
        private Competition _selectedCompetition;
        private IDataService _dataService;
        //để lôi đúng service của từng thằng Native
        private IPlatformDataService _platformDataService;

        public HomePageViewModel(INavigationService navigationService, FifaClient client, IDataService dataService, IPlatformDataService platformDataService) : base(navigationService)
        {
            _fifaClient = client;
            _dataService = dataService;
            _platformDataService = platformDataService;
            IsBusy = true;
        }

        public List<Competition> Competitions
        {
            get => _competitions;
            set => SetProperty(ref _competitions, value);
        }

        public Competition SelectedCompetition
        {
            get => _selectedCompetition;
            set
            {
                if (SetProperty( ref _selectedCompetition , value))
                {
                    OnCompetitionSelected(_selectedCompetition);
                }
            }
        }

        public async void OnCompetitionSelected(Competition selected)
        {
            if (selected != null)
            {
                SelectedCompetition = null;
                await NavigationService.NavigateAsync("CompetitionPage",
                    new NavigationParameters() {{"Competition" ,selected}});
            }
        }
        //public override async void Init(object param = null)
        //{
        //    await LoadAsync();
        //}
        public async override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            await LoadAsync();
        }

        public async Task LoadAsync()
        {
            if (Competitions?.Count > 0)
            {
                return;
            }
            IsBusy = true;
            var result = await _fifaClient.CurrentAsync();
            IsBusy = false;

            Competitions = result.Data.Competitions;
        }
    }
}