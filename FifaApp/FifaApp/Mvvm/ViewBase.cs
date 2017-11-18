using Xamarin.Forms;

namespace FifaApp.Mvvm
{
    public class ViewBase : ContentPage
    {
        public object Param { get; set; }

        public ViewBase()
        {
            Param = null;
        }

        public ViewBase(object param = null)
        {
            Param = param;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (BindingContext is ViewModelBase viewModel)
            {
                viewModel.Init(Param);
            }
        }
    }
}