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

		await Navigation.PopAsync();
	}

}
