﻿using System.ComponentModel.DataAnnotations;

namespace WebBlog.Server.Models.IdentityModel
{
    public class User
    {
        public string? Id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? NewPassword { get; set; }
        [Compare("NewPassword", ErrorMessage = "Пароли не совпадают")]
        public string? PasswordConfirm { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
