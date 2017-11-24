using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using DryIoc;
using FifaApp.Client;
using FifaApp.Droid.Services;
using Prism;
using Prism.DryIoc;
using Xamarin.Forms.Internals;

namespace FifaApp.Droid
{
    [Activity(Label = "FifaApp", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App(new PlatformInitializer()));
        }
        public class PlatformInitializer : IPlatformInitializer
        {
            public void RegisterTypes(IContainer container)
            {
                //có thể quản lý memory bằng reuse
                container.Register<IPlatformDataService,AndroidDataService>();
            }
        }
    }
}

