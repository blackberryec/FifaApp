using System.ComponentModel;
using System.Runtime.CompilerServices;
using FifaApp.Annotations;

namespace FifaApp.Mvvm
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool _isBusy;

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                if (_isBusy != value)
                {
                    _isBusy = value;
                    OnPropertyChanged();

                }
            }
        }

        public bool IsNotBusy => !IsBusy;

        public virtual void Init()
        {
            
        }

    }
}