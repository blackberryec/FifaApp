using System.Collections.Generic;
using System.Threading.Tasks;
using FifaApp.Client;
using FifaApp.Models;
using FifaApp.Mvvm;

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
                }
            }
        }

        public async Task LoadAsync()
        {
            var result = await _fifaClient.CurrentAsync();

            Competitions = result.Data.Competitions;
            if (Competitions != null)
            {
                SelectedCompetition = Competitions[2];
            }
        }
    }
}