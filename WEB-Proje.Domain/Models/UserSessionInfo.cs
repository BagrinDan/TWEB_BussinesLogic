using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEB_Proje.Domain.Enums;

namespace WEB_Proje.Domain.Models {
    public class UserSessionInfo { 
            public string Username { get; set; }
            public URole Role { get; set; }
    }
}
