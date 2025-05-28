using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEB_Proje.Domain.Models.Product;

namespace WEB_Proje.BussinesLogic.Interface.ProductInterface {
    public interface IOrderInterface {
        bool OrderClient(OrderModel order);
    }
}
