using Api_Xamarin.Views;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Api_Xamarin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();


            var token = Preferences.Get("token", string.Empty);

            MainPage = string.IsNullOrEmpty(token) ? new NavigationPage(new SignUp()) : new NavigationPage(new Home());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
