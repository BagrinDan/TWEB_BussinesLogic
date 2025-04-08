using System.Data.Entity;
using WEB_Proje.Domain.Entities;

namespace WEB_Proje.BussinesLogic.DBModel {
    public class UserContent : DbContext{ // UserContext
        public UserContent() : base("name=Electroland") {
        
        }
        public virtual DbSet<UDdTable> Users { get; set; }
    }
}
