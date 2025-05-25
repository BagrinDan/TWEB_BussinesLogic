using WEB_Proje.Domain.Entities.User;
using System.Web;


namespace WEB_Proje.BussinesLogic {
    public class Session {
        public static UserDateLogin GetLoggedInUser(HttpContextBase context) {
            if(context == null) return null;

            var username = context.Session["Username"] as string;
            var password = context.Session["Password"] as string;

            if(string.IsNullOrEmpty(username)) return null;

            return new UserDateLogin {
                Username = username,
                Password = password
            };
        }
    }
}
