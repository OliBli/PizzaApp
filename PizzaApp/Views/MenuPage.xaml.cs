using System.Collections.ObjectModel;
using System.Text.Json;
using System.Reflection;
using System.IO;

namespace PizzaApp.Views
{
    public partial class MenuPage : ContentPage
    {
        public ObservableCollection<Pizza> Pizzas { get; set; } = new ObservableCollection<Pizza>();

        public MenuPage()
        {
            InitializeComponent();  
            LoadMenuData();  
        }

        private async void LoadMenuData()
        {
            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                using Stream? stream = assembly.GetManifestResourceStream("PizzaApp.api.menu.json");

                if (stream == null)
                {
                    await DisplayAlert("Fel", "Kunde inte hitta menu.json!", "OK");  
                    return;
                }

                using StreamReader reader = new StreamReader(stream);
                string json = await reader.ReadToEndAsync();

                if (string.IsNullOrEmpty(json))
                {
                    await DisplayAlert("Fel", "Menyn är tom eller JSON-filen är ogiltig.", "OK");
                    return;
                }

                var pizzas = JsonSerializer.Deserialize<List<Pizza>>(json);

                if (pizzas == null)
                {
                    await DisplayAlert("Fel", "Det gick inte att deserialisera menyn.", "OK");
                    return;
                }

                foreach (var pizza in pizzas)
                {
                    Pizzas.Add(pizza);
                }

                menuList.ItemsSource = Pizzas;
                if (Pizzas.Count == 0)
                {
                    await DisplayAlert("Varning", "Ingen pizza hittades i menyn!", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Fel", $"Ett fel inträffade: {ex.Message}", "OK");  
            }
        }
    }
}
