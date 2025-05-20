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
        var groupedItems = CartService.CartItems
       .GroupBy(ci => ci.ItemModel.Name)
       .Select(group => new
       {
           DisplayName = $"{group.Sum(ci => ci.Quantity)}x {group.Key}",
           TotalPrice = group.Sum(ci => ci.TotalPrice)
       })
       .ToList();

        cartList.ItemsSource = groupedItems;
    }

    private async void onOrder(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//OrderPage");
    }

}
