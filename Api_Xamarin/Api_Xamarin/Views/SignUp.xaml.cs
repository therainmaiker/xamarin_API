using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api_Xamarin.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Api_Xamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUp : ContentPage
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private async void BtnSignup_OnClicked(object sender, EventArgs e)
        {
            var resp = await AuthApiService.Register(FName.Text, LName.Text, Username.Text, Email.Text, Password.Text,
                Address.Text);
            if (!resp)
            {
                await DisplayAlert("Errors", "Something went wrong", "Ok");
                return;
            }

            await DisplayAlert("", "Your account has been created", "Ok");
            await Navigation.PushModalAsync(new Home());
        }
    }
}