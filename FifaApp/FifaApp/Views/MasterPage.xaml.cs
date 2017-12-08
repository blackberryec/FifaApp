using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FifaApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : MasterDetailPage
    {
        public MasterPage()
        {
            InitializeComponent();
        }
    }
}