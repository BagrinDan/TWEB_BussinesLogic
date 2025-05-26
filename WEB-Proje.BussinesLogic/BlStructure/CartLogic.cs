
using System.Web;
using WEB_Proje.BussinesLogic.Interface.ProductInterface;
using WEB_Proje.Domain.Product;
using WEB_Proje.Domain.ShopStuff;

namespace WEB_Proje.BussinesLogic.BlStructure {
    public class CartLogic : IProductInterface{
        private readonly HttpSessionStateBase _session;
        public CartLogic(HttpSessionStateBase session) {
            _session = session;
        }

        public void AddToCart(ProductModel product) {
            var cart = GetCart();
            cart.AddItem(product);
            //var productModel = new ProductModel {
            //    Id = product.Id,
            //    Name = product.Name,
            //    Price = product.Price.ToString(),
            //    ImagePath = $"/Content/Images/product-item{product.Id}.jpg"
            //};
            SaveCart(cart);
        }

        public ShopStuff GetCart() {
            var cart = _session["Cart"] as ShopStuff;
            if(cart == null) {
                cart = new ShopStuff();
                _session["Cart"] = cart;
            }
            return cart;
        }

        public void SaveCart(ShopStuff cart) {
            _session["Cart"] = cart;
        }
        public void RemoveFromCart(int productId) {
            var cart = GetCart();
            cart.Items.RemoveAll(i => i.ProductId == productId);
            SaveCart(cart);
        }

        public void ClearCart() {
            _session["Cart"] = new ShopStuff();
        }

    }
}
