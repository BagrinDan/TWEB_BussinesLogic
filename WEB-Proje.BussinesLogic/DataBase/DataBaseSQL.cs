using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using WEB_Proje.Domain.Entities.User;

namespace WEB_Proje.BussinesLogic.DataBase {
    public class DataBaseSQL : DbContext{
        public DbSet<UserDateLogin> UserDateLogins  { get; set; } // Din domain/entities/user/UserDateLogin
    }
}
