using Microsoft.Maui.Storage;
using System.Security.Cryptography;
using System.Text;



namespace PizzaApp
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
        }


        private async void OnloginTapped(object sender, EventArgs e)
        {

            string savedEmail = Preferences.Get("savedEmail", string.Empty);
            string savedPassword = Preferences.Get("savedPassword", string.Empty);


            User user = new User
            {
                Email = EmailEntry.Text,
                Password = MainPasswordEntry.Text.Trim(),

            };

            if (user.Email == savedEmail && user.Password == savedPassword)
            {
                await Shell.Current.GoToAsync("MenuPage");
            }
            else
            {
                await DisplayAlert("Error", "Invalid email or password", "OK");


            }

            EmailEntry.Text = string.Empty;
            MainPasswordEntry.Text = string.Empty;



        }



        private async void OnRegisterTapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("RegisterPage");
        }

    }

}
