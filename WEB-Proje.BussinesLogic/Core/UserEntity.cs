
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEB_Proje.Domain.Entities.User;
using WEB_Proje.BussinesLogic.Interface.LoginInterface;


namespace WEB_Proje.BussinesLogic.Core {
    public class UserEntity : UserDateLogin {
        
        // Constructor
        public UserEntity(UserDateLogin user){
            Username = user.Username;
            Password = user.Password;
        }

        // --- Actiuni Generice ---
        // Autorizatie
        public bool IUserAuthorization(UserDateLogin user) {
            if (user.Username != null && user.Password != null) {
                if(user.Username == Username && user.Password == Password) {
                    return true;
                }
            }
            return false;
        }

        // Registrare
        public bool IUserRegistration(UserDateLogin user) {
            if(user.Username == Username && user.Password == Password) {
                return false;
            }

            return true;
        }
    }
}
