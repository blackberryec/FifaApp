using FifaApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace FifaApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage
    {
        public HomePage()
        {
            InitializeComponent();

            MainListView.On<Android>().SetIsFastScrollEnabled(true);

            //Hidden NavigationBar
            //NavigationPage.SetHasNavigationBar(this,false);
        }
    }

    public class MainTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DefaultTemplate { get; set; }
        public DataTemplate LiveTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is Competition competition && competition.Live)
            {
                return LiveTemplate;
            }
            return DefaultTemplate;
        }
    }
}