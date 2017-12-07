using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Acr.UserDialogs;
using FifaApp.Client;
using FifaApp.Models;
using FifaApp.Mvvm;
using FifaApp.Views;
using Prism.Commands;
using Prism.Navigation;

namespace FifaApp.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        private readonly FifaClient _fifaClient;
        //private List<Competition> _competitions;
        private ObservableCollection<Competition> _competitions;
        private List<CompetitionGroupItem> _competitionGroup;
        //private Competition _selectedCompetition;
        private IDataService _dataService;
        //để lôi đúng service của từng thằng Native
        private IPlatformDataService _platformDataService;
        private bool _isRefreshing;

        public bool IsRefreshing
        {
            get => _isRefreshing;
            set => SetProperty(ref _isRefreshing,value);
        }

        private bool _isLoadingInfinite;

        public bool IsLoadingInfinite
        {
            get => _isLoadingInfinite;
            set => SetProperty(ref _isLoadingInfinite, value);
        }



        public HomePageViewModel(INavigationService navigationService, FifaClient client, IDataService dataService, IPlatformDataService platformDataService) : base(navigationService)
        {
            _fifaClient = client;
            _dataService = dataService;
            _platformDataService = platformDataService;
            IsBusy = true;

            DeleteCommand = new DelegateCommand<Competition>(ExecuteDelete);
            RefreshCommand = new DelegateCommand(ExecuteRefresh);
            LoadingCommand = new DelegateCommand(ExecuteLoading);
            SelectedCommand = new DelegateCommand<Competition>(OnSelected);
        }

        public class CompetitionGroupItem : List<Competition>
        {
            public CompetitionGroupItem(IEnumerable<Competition> enumerable) : base(enumerable)
            {
                
            }
            public string First { get; set; }
        }

        public List<CompetitionGroupItem> CompetitionGroup
        {
            get => _competitionGroup;
            set => SetProperty(ref _competitionGroup, value);
        }

        //public List<Competition> Competitions
        //{
        //    get => _competitions;
        //    set => SetProperty(ref _competitions, value);
        //}
        public ObservableCollection<Competition> Competitions
        {
            get => _competitions;
            set => SetProperty(ref _competitions, value);
        }


        //public Competition SelectedCompetition
        //{
        //    get => _selectedCompetition;
        //    set
        //    {
        //        if (SetProperty(ref _selectedCompetition , value))
        //        {
        //            OnCompetitionSelected(_selectedCompetition);
        //        }
        //    }
        //}

        public async void OnSelected(Competition selected)
        {
            if (selected != null)
            {

                await NavigationService.NavigateAsync("CompetitionPage",
                    new NavigationParameters {{"Competition" ,selected}});
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

            UserDialogs.Instance.ShowLoading();

            var result = await RunApiAsync(() => _fifaClient.CurrentAsync());

            if (result.Success)
            {
                Competitions = new ObservableCollection<Competition>(result.Data.Competitions);
                CompetitionGroup = Competitions
                    .Select(x => new {First = x.CompetitionEn.Substring(0, 1), Data = x})
                    .GroupBy(x => x.First).Select(x =>
                        new CompetitionGroupItem(x.Select(y => y.Data).ToList()) {First = x.Key})
                    .OrderBy(x => x.First).ToList();
            }

            UserDialogs.Instance.HideLoading();
        }

        public DelegateCommand RefreshCommand { get; }
        public DelegateCommand<Competition> DeleteCommand { get; }
        public DelegateCommand LoadingCommand { get; }

        public DelegateCommand<Competition> SelectedCommand { get; }

        private async void ExecuteLoading()
        {
            var result = await RunApiAsync(() => _fifaClient.CurrentAsync());
            if (result.Success)
            {
                foreach (var competition in result.Data.Competitions)
                {
                    Competitions.Add(competition);
                }
            }
            IsLoadingInfinite = false;
        }

        private async void ExecuteRefresh()
        {
            Competitions.Clear();

            await LoadAsync();

            IsRefreshing = false;
        }

        private void ExecuteDelete(Competition competition)
        {
            Competitions.Remove(competition);
        }
    }
}