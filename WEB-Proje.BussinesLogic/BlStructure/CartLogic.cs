
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

        // Adauga produs
        public void AddToCart(ProductModel product) {
            var cart = GetCart();
            cart.AddItem(product);

            SaveCart(cart);
        }

        // Get Cosul
        public ShopStuff GetCart() {
            var cart = _session["Cart"] as ShopStuff;
            if(cart == null) {
                cart = new ShopStuff();
                _session["Cart"] = cart;
            }
            return cart;
        }

        // Salvare cosu
        public void SaveCart(ShopStuff cart) {
            _session["Cart"] = cart;
        }

        // Sterge ceva din cosu
        public void RemoveFromCart(int productId) {
            var cart = GetCart();
            cart.Items.RemoveAll(i => i.ProductId == productId);
            SaveCart(cart);
        }

        // Sterge tot din cos
        public void ClearCart() {
            _session["Cart"] = new ShopStuff();
        }

    }
}
