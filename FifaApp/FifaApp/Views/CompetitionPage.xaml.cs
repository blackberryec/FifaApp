using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FifaApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompetitionPage
    {
        public CompetitionPage(object param) : base(param)
        {
            InitializeComponent();
        }
    }
}