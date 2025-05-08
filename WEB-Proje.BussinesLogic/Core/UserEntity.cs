
using WEB_Proje.Domain.Entities.User;



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
