using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DryIoc;
using FifaApp.Client;
using FifaApp.ViewModels;
using FifaApp.Views;
using Prism.DryIoc;
using Xamarin.Forms;

namespace FifaApp
{
    public partial class App
    {
        public App()
        {

            MainPage = new NavigationPage(new HomePage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("/Navigation/HomePage");

            //if (Used is Logged)
            //{
            //    NavigationService.NavigateAsync("/Navigation/HomePage");
            //}
            //else
            //{
            //    NavigationService.NavigateAsync("/Navigation/LoginPage");
            //}
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>("Navigation");

            //mac dinh viewmodel map theo ten, tuy nhien su dung nhu vay cung co the gan cung
            Container.RegisterTypeForNavigationOnIdiom<HomePage,HomePageViewModel>("Home",typeof(HomeTabletPage),typeof(HomePage));

            Container.RegisterTypeForNavigation<HomePage>();
            Container.RegisterTypeForNavigation<CompetitionPage>();

            //ham khoi tao client
            Container.RegisterInstance(new FifaClient(), Reuse.Singleton);
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
