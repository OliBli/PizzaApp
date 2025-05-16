using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace PizzaApp.Models
{
    public static class CartService
    {
         public static ObservableCollection<CartItem> CartItems { get; } = new();

        public static void AddCart(MenuItemModel item)
        {
            var existingItem = CartItems.FirstOrDefault(c => c.ItemModel.Name == item.Name);
            if (existingItem != null) 
            { 
                existingItem.Quantity++; 
            }
            else 
            { 
                CartItems.Add(new CartItem
                {
                    ItemModel = item,
                    Quantity = 1
                }); 
            }
            
        }
        public static int GetQuantity() 
        { 
            return CartItems.Sum(c => c.Quantity); 
        }
    }
}
