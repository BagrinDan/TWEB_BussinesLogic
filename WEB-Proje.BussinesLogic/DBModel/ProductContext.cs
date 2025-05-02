using System.Data.Entity;
using WEB_Proje.Domain.Entities;

namespace WEB_Proje.BussinesLogic.DBModel {
    public class ProductContext : DbContext{
        public ProductContext() : base("name=Electroland") {

        }
        public virtual DbSet<UDdProducts> Products { get; set; }
    }
}
