﻿using System;
using System.Linq;
using System.Web.Security;
using System.Web;
using WEB_Proje.BussinesLogic.DBModel;
using WEB_Proje.BussinesLogic.Interface.LoginInterface;
using WEB_Proje.Domain.Entities;
using WEB_Proje.Domain.Entities.User;


namespace WEB_Proje.BussinesLogic.BlStructure {
    public class LoginBL : IUserLoginInterface{
        
        // --- Actiuni Generice ---
        public bool IUserAuthorization(UserDateLogin user) { // Try-catch
            using(var db = new UserContent()) {
                var userInDb = db.Users.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);
                return userInDb != null;
            }
        }


        // Inregistrare
        public bool IUserRegistration(UserDateLogin user) {
            using(var db = new UserContent()) {
                var existingUser = db.Users.FirstOrDefault(u => u.Username == user.Username);

                if(existingUser != null) {
                    return false;
                }

                var newUser = new UDdTable {
                    Username = user.Username,
                    Password = user.Password,
                    userRole = Domain.Enums.URole.User
                };

                db.Users.Add(newUser);
                db.SaveChanges();

                return true;
            }
        }


        // Validate Auth
        public UserDateLogin ValidateAuth(UserDateLogin user) {
            using(var db = new UserContent()) {
                var userInDb = db.Users.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);

                if(userInDb != null) {
                    user.Username = userInDb.Username;
                    user.Password = userInDb.Password;
                    return user;
                }

                return null;
            }
        }


        // Validate Register
        public UserDateLogin ValidateRegister(UserDateLogin user) {
            using(var db = new UserContent()) {
                var existingUser = db.Users.FirstOrDefault(u => u.Username == user.Username);

                if(existingUser != null) {
                    return null;
                }

                return user;
            }
        }

        //!!!
        public bool ValidatePassword(string Pass1, string Pass2) {
            if(Pass1 == Pass2) {
                return true;
            } else {
                return false;
            }
        }

        public void SetAuthenticationCookies(HttpResponseBase response, HttpRequestBase request, FormsAuthenticationTicket ticket) {
            string encryptedTicket = FormsAuthentication.Encrypt(ticket);
            var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            response.Cookies.Add(authCookie);

            HttpCookie userLoginInfoCookie = new HttpCookie("UserLoginInfo");
            userLoginInfoCookie["IP"] = request.UserHostAddress;
            userLoginInfoCookie["LoginTime"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            userLoginInfoCookie.Expires = DateTime.Now.AddDays(7);
            userLoginInfoCookie.Path = "/";
            userLoginInfoCookie.Domain = "localhost"; 
            response.Cookies.Add(userLoginInfoCookie);
        }

    }
}
