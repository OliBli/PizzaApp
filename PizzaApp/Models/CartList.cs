using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaApp.Models
{
    public static class CartService
    {
        public static List<MenuItemModel> CartItems { get; } = new();
    }
}
