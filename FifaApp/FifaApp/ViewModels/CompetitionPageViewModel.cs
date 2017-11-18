using FifaApp.Models;
using FifaApp.Mvvm;

namespace FifaApp.ViewModels
{
    public class CompetitionPageViewModel : ViewModelBase
    {
        public override void Init(object param = null)
        {
            base.Init(param);

            if (param is Competition competition)
            {
                Title = competition.CompetitionEn;
            }
        }
    }
}