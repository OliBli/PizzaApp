namespace PizzaApp.Models
{
    public class MenuItemModel
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public List<string> Topping { get; set; }
        public string ToppingText => Topping != null ? string.Join(", ", Topping) : string.Empty;
        public decimal Price { get; set; }
        public int? Rank { get; set; }
        
    }
}
