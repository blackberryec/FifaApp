using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using FifaApp.Annotations;
using Xamarin.Forms;

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

        private string _title;

        public string Title
        {
            get => _title;
            set
            {
                if (_title != value)
                {
                    _title = value;
                    OnPropertyChanged();
                }
            }
        }

        public virtual void Init(object param = null)
        {

        }

        protected Task NavigateToPageAsync<T>(object param) where T : ViewBase
        {
            if (Application.Current.MainPage is NavigationPage navigationPage)
            {
                return navigationPage.Navigation.PushAsync(
                    (ViewBase)Activator.CreateInstance(typeof(T), param));
            }

            return Task.FromResult((object)null);
        }

        protected Task NavigateToPageAsync<T>() where T : Page
        {
            if (Application.Current.MainPage is NavigationPage navigationPage)
            {
                return navigationPage.Navigation.PushAsync(
                    Activator.CreateInstance<T>());
            }

            return Task.FromResult((object)null);
        }

    }
}