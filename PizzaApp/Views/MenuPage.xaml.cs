using PizzaApp.Models;
using PizzaApp.Views;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.Json;


namespace PizzaApp.Views
{
    public partial class MenuPage : ContentPage
    {
        public ObservableCollection<MenuItemModel> MenuItems { get; set; } = new ObservableCollection<MenuItemModel>();

        public MenuPage()
        {
            InitializeComponent();       
            BindingContext = this;
            LoadMenuData();
        }

        private async void LoadMenuData()
        {
            try
            {
                string? url = "PizzaApp.api.menu.json";
                var assembly = Assembly.GetExecutingAssembly();
                using Stream? stream = assembly.GetManifestResourceStream(url);

                if (stream == null)
                {
                    await DisplayAlert("Fel", "Kunde inte hitta menu.json!", "OK");
                    return;
                }

                using StreamReader reader = new StreamReader(stream);
                string json = await reader.ReadToEndAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var allItems = JsonSerializer.Deserialize<List<MenuItemModel>>(json, options);

                if (allItems == null || allItems.Count == 0)
                {
                    await DisplayAlert("Varning", "Ingen menydata hittades.", "OK");
                    return;
                }

                foreach (var item in allItems)
                {               
                    MenuItems.Add(item);
                }

                menuList.ItemsSource = MenuItems;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Fel", $"Ett fel inträffade: {ex.Message}", "OK");
            }

            
        }

        private void UppdateButton()
        {
            cartButton.Text = $"Se your cart({CartService.GetQuantity()})";
        }
        private async void OnAddCart(object sender, EventArgs e)
        {
           
            if(sender is Button button && button.BindingContext is MenuItemModel selectedItem)
            {
                var cartItem = CartService.CartItems.FirstOrDefault(c => c.ItemModel.Name == selectedItem.Name);

                if (cartItem != null)
                {
                    
                    cartItem.Quantity++;
                }
                else
                {
                    
                    var newCartItem = new CartItem
                    {
                        ItemModel = selectedItem,
                        Quantity = 1
                    };
                    CartService.CartItems.Add(newCartItem);
                }
                UppdateButton();
                await DisplayAlert("Order", $"You have Orderd: {selectedItem.Name} ({selectedItem.Price} kr)", "Ok");
            }
        }
        private async void OnCartClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//CartPage");
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            UppdateButton();
        }
    }
}
