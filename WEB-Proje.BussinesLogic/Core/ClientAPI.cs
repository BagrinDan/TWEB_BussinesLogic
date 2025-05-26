using System.Web;
using WEB_Proje.BussinesLogic.BlStructure;
using WEB_Proje.BussinesLogic.Interface.ProductInterface;
using WEB_Proje.Domain.Entities.User;
using WEB_Proje.Domain.Product;
using WEB_Proje.Domain.ShopStuff;

namespace WEB_Proje.BussinesLogic.Core {
    public class ClientAPI : UserEntity, IProductInterface {

        public readonly CartLogic _cartLogic;

        public ClientAPI(UserDateLogin user, HttpSessionStateBase session) : base(user){
            Username = user.Username;
            Password = user.Password;
            _cartLogic = new CartLogic(session);
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
    }
}
