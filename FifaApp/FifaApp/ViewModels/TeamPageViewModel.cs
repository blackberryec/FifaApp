using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using FifaApp.Client;
using FifaApp.Models;
using FifaApp.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;

namespace FifaApp.ViewModels
{
    public class TeamPageViewModel : ViewModelBase
    {
        private FifaClient _fifaClient;

        public TeamDetail Team { get; set; }

        public TeamPageViewModel(INavigationService navigationService, FifaClient fifaClient) : base(navigationService)
        {
            _fifaClient = fifaClient;
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.TryGetValue("team",out string teamId))
            {
                var result = await _fifaClient.TeamAsync(teamId);
                if (result.Success)
                {
                    Team = result.Data;
                }
            }
        }

    }
}
