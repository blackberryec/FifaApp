using System.Collections.Generic;
using System.Threading.Tasks;
using FifaApp.Client;
using FifaApp.Models;
using FifaApp.Mvvm;
using FifaApp.Views;

namespace FifaApp.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        private readonly FifaClient _fifaClient;
        private List<Competition> _competitions;
        private Competition _selectedCompetition;

        public HomePageViewModel()
        {
            _fifaClient = new FifaClient();

            IsBusy = true;
        }

        public List<Competition> Competitions
        {
            get => _competitions;
            set
            {
                if (_competitions != value)
                {
                    _competitions = value;
                    OnPropertyChanged();
                }
            }
        }

        public Competition SelectedCompetition
        {
            get => _selectedCompetition;
            set
            {
                if (_selectedCompetition != value)
                {
                    _selectedCompetition = value;
                    OnPropertyChanged();
                    OnCompetitionSelected(_selectedCompetition);
                }
            }
        }

        public async void OnCompetitionSelected(Competition selected)
        {
            if (selected != null)
            {
                SelectedCompetition = null;
                await NavigateToPageAsync<CompetitionPage>(selected);
            }
        }
        public override async void Init(object param = null)
        {
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