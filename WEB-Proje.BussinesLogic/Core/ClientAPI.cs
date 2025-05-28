
using System.Linq;
using System.Web;
using WEB_Proje.BussinesLogic.BlStructure;
using WEB_Proje.BussinesLogic.Interface.ProductInterface;
using WEB_Proje.Domain.Entities.User;
using WEB_Proje.Domain.Models.Product;
using WEB_Proje.Domain.Product;
using WEB_Proje.Domain.ShopStuff;

namespace WEB_Proje.BussinesLogic.Core {
    public class ClientAPI : UserEntity, IProductInterface, IOrderInterface {
        public readonly CartLogic _cartLogic;
        public readonly OrderLogic _orderLogic;

        public ClientAPI(UserDateLogin user, HttpSessionStateBase session) : base(user){
            Username = user.Username;
            Password = user.Password;
            _cartLogic = new CartLogic(session);
            _orderLogic = new OrderLogic();
        }

        // --Cosul--
        // Adaugare
        public void AddToCart(ProductModel product) {
            _cartLogic.AddToCart(product);
        }

        // Get Cosul
        public ShopStuff GetCart() {
            return _cartLogic.GetCart();
        }

        // Stergere cosului
        public void ClearCart() {
            _cartLogic.SaveCart(new ShopStuff());
        }

        // Stergere continutului cosului
        public void RemoveFromCart(int productId) {
            var cart = _cartLogic.GetCart();
            cart.Items.RemoveAll(i => i.ProductId == productId);
            _cartLogic.SaveCart(cart);
        }

        // -- TEST ---
        public void IncreaseQuantity(int productId) {
            var cart = _cartLogic.GetCart();
            var item = cart.Items.FirstOrDefault(i => i.ProductId == productId);
            if(item != null) {
                item.Quantity++;
                _cartLogic.SaveCart(cart);
            }
        }

        public void DecreaseQuantity(int productId) {
            var cart = _cartLogic.GetCart();
            var item = cart.Items.FirstOrDefault(i => i.ProductId == productId);
            if(item != null && item.Quantity > 1) {
                item.Quantity--;
                _cartLogic.SaveCart(cart);
            } else if(item != null && item.Quantity == 1) {
                cart.Items.Remove(item);
                _cartLogic.SaveCart(cart);
            }
        }

        // --- Comanda ---
        public bool OrderClient(OrderModel order) {
            if(order == null) return false;

            _orderLogic.OrderClient(order);
            return true;
        }
    }
}
