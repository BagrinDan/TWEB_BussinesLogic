using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEB_Proje.Domain.Product;

namespace WEB_Proje.BussinesLogic.Interface.ProductInterface {
    public interface IAddProduct {
        bool AddProduct(ProductModel model, string serverRootPath, out string errorMessage);

    }
}
