using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaApp.Models
{
    public class CartItem
    {
        public MenuItemModel ItemModel { get; set; }
        public int Quantity { get; set; }

        public double TotalPrice => (double)(ItemModel.Price * Quantity);

        public string DisplayName => $"{Quantity}x {ItemModel.Name} ";
    }
}