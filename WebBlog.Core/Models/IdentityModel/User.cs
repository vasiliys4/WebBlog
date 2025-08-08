using System.ComponentModel.DataAnnotations;

namespace WebBlog.Server.Models.IdentityModel
{
    public class User
    {
        public User(){}
        private User(Guid id, string userName, string email, string hashedPassword)
        {
            Id = id;
            UserName = userName;
            Email = email;
            PasswordHash = hashedPassword;            
        }
        public Guid Id { get; set; }
        public string? UserName { get;  set; }
        public string? Email {  get;  set; }
        //public string? Password { get; private set; }
        public string? PasswordHash { get;  set; }
        public static  User Create(Guid id, string userName, string email, string hashedPassword) 
        {
            return new User(id, userName, hashedPassword, email);
        }
    }
}
