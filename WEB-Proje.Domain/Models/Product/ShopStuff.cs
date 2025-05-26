
using WEB_Proje.Domain.Product;
using System.Collections.Generic;
using WEB_Proje.Domain.CartStuff;
using System.Linq;


namespace WEB_Proje.Domain.ShopStuff {
    // Models/ShoppingCart.cs
    public class ShopStuff {
        public List<CartStufff> Items { get; set; } = new List<CartStufff>();

        public void AddItem(ProductModel product, int quantity = 1) {
            var existingItem = Items.FirstOrDefault(i => i.ProductId == product.Id);
            if(existingItem != null) {
                existingItem.Quantity += quantity;
            } else {
                Items.Add(new CartStufff {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    Price = decimal.Parse(product.Price),
                    Quantity = quantity,
                    ImagePath = product.ImagePath
                });
            }
        }

        public decimal GetTotal() => Items.Sum(i => i.Price * i.Quantity);
    }
}