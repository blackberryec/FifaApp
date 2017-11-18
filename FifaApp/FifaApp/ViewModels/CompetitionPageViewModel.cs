using System.Windows.Input;
using FifaApp.Client;
using FifaApp.Models;
using FifaApp.Mvvm;
using Xamarin.Forms;

namespace FifaApp.ViewModels
{
    public class CompetitionPageViewModel : ViewModelBase
    {
        private CompetitionDetail _competition;

       
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

        public CompetitionPageViewModel()
        {
            MatchCommand = new Command(ViewMatch);
            TeamCommand = new Command(ViewTeam);
        }

        private void ViewTeam(object obj)
        {

        }


        private void ViewMatch(object obj)
        {

        }

        public override async void Init(object param = null)
        {
            base.Init(param);

            if (param is Competition competition)
            {
                Title = competition.CompetitionEn;
                IsBusy = true;
                var result = await FifaClient.Current.CompetitionAsync(competition.CompetitionId.ToString());
                if (result.Success)
                {
                    Competition = result.Data;
                }
                IsBusy = false;
            }
        }

        public ICommand MatchCommand { get; }
        public ICommand TeamCommand { get; }
    }
}