using WEB_Proje.Domain.Entities.User;

namespace WEB_Proje.BussinesLogic.Core {
    public class ClientAPI : UserEntity {
        public ClientAPI(UserDateLogin user) : base(user){
            Username = user.Username;
            Password = user.Password;
        }

        // Cosul

    }
}
