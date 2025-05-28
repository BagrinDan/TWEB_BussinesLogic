using WEB_Proje.Domain.Entities.User;

namespace WEB_Proje.BussinesLogic.Interface.LoginInterface {
    public interface IUserLoginInterface {

        // Autorizatie
        bool IUserAuthorization(UserDateLogin user);

        // Inregistrare
        bool IUserRegistration(UserDateLogin user);

        // Validare Auth
        UserDateLogin ValidateAuth(UserDateLogin user);
        // Validate Register
        UserDateLogin ValidateRegister(UserDateLogin user);

        bool ValidatePassword(string Pass1, string Pass2);

    }
}
