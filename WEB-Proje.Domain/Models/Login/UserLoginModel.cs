﻿
using System.ComponentModel.DataAnnotations;

namespace WEB_Proje.Domain.Login {
    public class UserLoginModel {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Nu-i coencidenta")]
        public string RepPassword { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}