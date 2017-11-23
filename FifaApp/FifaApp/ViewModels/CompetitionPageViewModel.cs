using System.Windows.Input;
using FifaApp.Client;
using FifaApp.Models;
using FifaApp.Mvvm;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;

namespace FifaApp.ViewModels
{
    public class CompetitionPageViewModel : ViewModelBase
    {
        private CompetitionDetail _competition;
        private readonly FifaClient _fifaClient;

        public CompetitionPageViewModel(INavigationService navigationService, FifaClient fifaClient) : base(navigationService)
        {
            _fifaClient = fifaClient;
            MatchCommand = new DelegateCommand<Match>(ViewMatch);
            TeamCommand = new DelegateCommand<object>(ViewTeam);
        }

        public CompetitionDetail Competition
        {
            get { return _competition; }
            set
            {
                if (_competition != value)
                {
                    _competition = value;
                    OnPropertyChanged();
                }
            }
        }

      

        private void ViewTeam(object obj)
        {

        }


        private void ViewMatch(object obj)
        {

        }

        public async override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            if (parameters.TryGetValue("Competition",out Competition param))
            {
                if (param is Competition competition)
                {
                    Title = competition.CompetitionEn;
                    IsBusy = true;
                    var result = await _fifaClient.CompetitionAsync(competition.CompetitionId.ToString());
                    if (result.Success)
                    {
                        Competition = result.Data;
                    }
                    IsBusy = false;
                }
            }
        }

        public ICommand MatchCommand { get; }
        public ICommand TeamCommand { get; }
    }
}