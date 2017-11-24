using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FifaApp.Client;
using FifaApp.Models;
using FifaApp.Mvvm;
using Prism.Navigation;

namespace FifaApp.ViewModels
{
    public class ViewMatchViewModel : ViewModelBase
    {
        private readonly FifaClient _fifaClient;
        private MatchDetail _matchDetail;

        public MatchDetail MatchDetail
        {
            get => _matchDetail;
            set => SetProperty(ref _matchDetail, value);
        }

        public ViewMatchViewModel(INavigationService navigationService, FifaClient fifaClient) : base(navigationService)
        {
            _fifaClient = fifaClient;
        }

        public async override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            if (parameters.TryGetValue("Match",out Match param))
            {
                if (param is Match match)
                {
                    Title = match.CompetitionEn;
                    IsBusy = true;
                    var result = await _fifaClient.MatchAsync(match.MatchId.ToString());
                    if (result.Success)
                    {
                        MatchDetail = result.Data;
                    }
                    IsBusy = false;
                }
            }
        }
    }
}
