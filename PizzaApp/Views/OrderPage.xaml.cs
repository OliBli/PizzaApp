using System.Formats.Tar;
using PizzaApp.Models;
using PizzaApp.Views;

namespace PizzaApp.Views;

public partial class OrderPage : ContentPage
{
	public OrderPage()
	{
		InitializeComponent();
	}

	private void Numbers_TextChanged(object sender, TextChangedEventArgs e)
	{
		string digitsOnly = new string(e.NewTextValue.Where(char.IsDigit).ToArray());

		if (digitsOnly.Length > 16)
		{
			digitsOnly = digitsOnly.Substring(0, 16);

			if (CardEntry.Text != digitsOnly)
				CardEntry.Text = digitsOnly;


		}
	}

	private void Date_TextChanged(object sender, TextChangedEventArgs e)
	{
		var entry = sender as Entry;
		string digitalsOnly = new string(e.NewTextValue.Where(char.IsDigit).ToArray());

		if (digitalsOnly.Length > 4)
			digitalsOnly = digitalsOnly.Substring(0,4);
		string formatted = digitalsOnly.Length switch
		{
			<= 2 => digitalsOnly,
			> 2 => digitalsOnly.Insert(2, "/")
		};

        if (entry.Text != formatted)
        {
            entry.Text = formatted;
			entry.CursorPosition = formatted.Length;
        }
    }


	private void CVV_TextChanged(object sender, TextChangedEventArgs e)
	{
        string digitsOnly = new string(e.NewTextValue.Where(char.IsDigit).ToArray());

		if(digitsOnly.Length > 3)
			digitsOnly = digitsOnly.Substring(0,3);
		if(CvvEntry.Text != digitsOnly)
			CvvEntry.Text = digitsOnly;
    }

    

	private async void onOrderdClicked(object sender, EventArgs e)
	{

        if (string.IsNullOrWhiteSpace(CardEntry.Text))
        {
            await DisplayAlert("Fel", "Please enter card number", "Ok");
            return;
        }

        if (string.IsNullOrWhiteSpace(DateEntry.Text))
        {
            await DisplayAlert("Fel", "Please enter expiry date", "Ok");
            return;
        }

        if (string.IsNullOrWhiteSpace(CvvEntry.Text))
        {
            await DisplayAlert("Fel", "Please enter CVV", "Ok");
            return;
        }

        if (string.IsNullOrWhiteSpace(Address.Text))
        {
            await DisplayAlert("Fel", "Please enter delivery address", "Ok");
            return;
        }

        if (CardEntry.Text.Length != 16)
        {
            await DisplayAlert("Fel", "Card number must be 16 digits", "Ok");
            return;
        }

        if (!DateEntry.Text.Contains("/")) 
        {
            await DisplayAlert("Fel", "Expiry date must be in MM/YY format", "Ok");
            return;
        }

        if (CvvEntry.Text.Length != 3)
        {
            await DisplayAlert("Fel", "CVV must be 3 digits", "Ok");
            return;
        }

        if (CartService.CartItems.Count == 0) 
		{ 
			await DisplayAlert("Fel", "Your cart is eampty", "Ok");
			return;
		}
		string orderDetails = string.Join(Environment.NewLine, CartService.CartItems.Select(ci => $"{ci.Quantity}x {ci.ItemModel.Name} ({ci.TotalPrice}kr)"));

		double totalSum = CartService.CartItems.Sum(ci => ci.TotalPrice);

		await DisplayAlert("Order Conformation", $"You have orderd: \n\n{orderDetails}\n\nTotal: {totalSum} kr", "Ok");

		
	    CartService.CartItems.Clear();

		await Shell.Current.GoToAsync("//MenuPage");
	}
}