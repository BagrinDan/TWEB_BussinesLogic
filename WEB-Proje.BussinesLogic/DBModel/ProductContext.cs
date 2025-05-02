using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEB_Proje.Domain.Entities;

namespace WEB_Proje.BussinesLogic.DBModel {
    internal class ProductContext : DbContext{
        public ProductContext() : base("name=Electroland") {

        }
        public virtual DbSet<UDdProducts> Users { get; set; }
    }
}
