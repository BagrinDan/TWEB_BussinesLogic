
using WEB_Proje.Domain.Product;
using WEB_Proje.Domain.ShopStuff;

namespace WEB_Proje.BussinesLogic.Interface.ProductInterface {
    public interface IProductInterface {
        void AddToCart(ProductModel product);

        ShopStuff GetCart();

        void ClearCart();

        void RemoveFromCart(int productId);
    }
}
