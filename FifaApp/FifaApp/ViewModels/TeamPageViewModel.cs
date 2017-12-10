using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FifaApp.Client;
using FifaApp.Models;
using FifaApp.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;

namespace FifaApp.ViewModels
{
    public class TeamPageViewModel : ViewModelBase
    {
        private readonly FifaClient _fifaClient;
        private TeamDetail _teamDetail;
        private CompetitionDetail _competitionDetail;

        public CompetitionDetail CompetitionDetail
        {
            get => _competitionDetail;
            set => SetProperty(ref _competitionDetail, value);

        }

        private List<CompetitionDetail> _competitionDetails;

        public List<CompetitionDetail> CompetitionDetails
        {
            get => _competitionDetails;
            set => SetProperty(ref _competitionDetails, value);
        }


        public TeamDetail Team
        {
            get => _teamDetail;
            private set
            {
                if (_teamDetail != value)
                {
                    _teamDetail = value;
                    RaisePropertyChanged();
                }
            }
        }


        public TeamPageViewModel(INavigationService navigationService, FifaClient fifaClient) : base(navigationService)
        {
            _fifaClient = fifaClient;
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.TryGetValue("team",out string teamId))
            {
                var result = await RunApiAsync(()=>_fifaClient.TeamAsync(teamId));
                if (result.Success)
                {
                    Team = result.Data;
                    Title = Team.TeamEn;
                    LoadTeamDetailCompetitions();
                }
            }
        }

        public async Task LoadTeamDetailCompetitions()
        {
            foreach (Competition competitionId in Team.Competitions)
            {
                var result = await RunApiAsync(() => _fifaClient.CompetitionAsync(competitionId.ToString()));

                CompetitionDetail = result.Data;
                
                CompetitionDetails.Add(CompetitionDetail);
            }    
        }
    }
}
