﻿namespace WebBlog.Server.Models.IdentityModel
{
    public class UserEntity
    {
        public Guid? Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
    }
}
