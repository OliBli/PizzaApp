namespace PizzaApp.Views;
using PizzaApp.Models;

public partial class CartPage : ContentPage
{
	public CartPage()
	{
		InitializeComponent();
		cartList.ItemsSource = CartService.CartItems;
	}

	private async void OnBackClicked(object sender, EventArgs e)
	{

        await Shell.Current.GoToAsync("//MenuPage");
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        cartList.ItemsSource = null;
        cartList.ItemsSource = CartService.CartItems;
    }

    private async void onOrder(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//OrderPage");
    }

}
