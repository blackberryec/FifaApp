using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using FifaApp.Client;
using FifaApp.Models;
using FifaApp.Mvvm;
using Prism.Navigation;

namespace FifaApp.ViewModels
{
    public class MatchPageViewModel : ViewModelBase
    {
        private FifaClient _fifaClient;

        private MatchDetail _matchDetail;

        public MatchDetail Match
        {
            get => _matchDetail;
            private set
            {
                if (_matchDetail != value)
                {
                    _matchDetail = value;
                    RaisePropertyChanged();
                }
            }
        }

        public MatchPageViewModel(INavigationService navigationService, FifaClient fifaClient): base (navigationService)
        {
            _fifaClient = fifaClient;
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            if (parameters.TryGetValue("match",out string matchId))
            {
                var result = await RunApiAsync(()=>_fifaClient.MatchAsync(matchId));
                if (result.Success)
                {
                    Match = result.Data;
                    Title = Match.HomeTeamEn + " " + Match.HomeGoals + " : "  + Match.AwayGoals + " " + Match.AwayTeamEn;
                }
            }
        }
    }
}
