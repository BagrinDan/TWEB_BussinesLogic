
using System.Linq;
using WEB_Proje.Domain.Entities.User;
using WEB_Proje.BussinesLogic.Interface.LoginInterface;
using WEB_Proje.BussinesLogic.DBModel;
using WEB_Proje.Domain.Entities;


namespace WEB_Proje.BussinesLogic.Core {
    public abstract class UserEntity : UserDateLogin{
        
        // Constructor
        public UserEntity(UserDateLogin user){
            Username = user.Username;
            Password = user.Password;
        }

        // Actiuni generice a utilizatorilor
    }
}
