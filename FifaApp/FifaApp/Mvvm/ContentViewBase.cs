using Xamarin.Forms;

namespace FifaApp.Mvvm
{
    public class ContentViewBase : ContentPage
    {
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (BindingContext is ViewModelBase viewModel)
            {
                viewModel.Init();
            }
        }
    }
}