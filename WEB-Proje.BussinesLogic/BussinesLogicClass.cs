using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEB_Proje.BussinesLogic.BlStructure;
using WEB_Proje.BussinesLogic.Interface.LoginInterface;
using WEB_Proje.Domain.Entities.User;

namespace WEB_Proje.BussinesLogic {

    public class BussinesLogicClass {

        public IUserLoginInterface GetUserLogin() {
            return new LoginBL();
        }
    }
}
