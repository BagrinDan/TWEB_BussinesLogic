using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEB_Proje.BussinesLogic.Interface {
    public interface IUser {
         int Id { get; }
         string Username { get; }
         bool IsAdmin { get; }        
    }
}
