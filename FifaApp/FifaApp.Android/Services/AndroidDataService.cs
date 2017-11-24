using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FifaApp.Client;

namespace FifaApp.Droid.Services
{
    public class AndroidDataService : IPlatformDataService
    {
        public Task LoadAsync()
        {
            throw new NotImplementedException();
        }
    }
}