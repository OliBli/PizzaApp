using System.Text.RegularExpressions;
using Microsoft.Maui.Storage;
using System.Security.Cryptography;
using System.Text;

namespace PizzaApp
{
    public partial class RegisterPage : ContentPage
    {


        public RegisterPage()
        {
            InitializeComponent();
        }


        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            User user = new User
            {
                Email = EmailEntry.Text,
                Password = PassEntry.Text.Trim(),
                ConfirmPassword = PassEntryconfomation.Text.Trim(),
                Username = UserEntry.Text
            };


            string error = user.GetValidationError();

            await Shell.Current.GoToAsync("//MenuPage");

            if (error != null)
            {
                await DisplayAlert("Error", error, "OK");
                return;
            }


            Preferences.Set("savedEmail", user.Email);
            Preferences.Set("savedPassword", user.Password);

        }

        private async void OnLoginTapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("MainPage");
        }



    }





}


