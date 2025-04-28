using PizzaApp.Views;

namespace PizzaApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnNavigateToMenuPage(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//MenuPage");
        }
    }
}
