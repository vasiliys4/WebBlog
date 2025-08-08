using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBlog.Server.Models.IdentityModel;

namespace WebBlog.Persistance
{
    public class DataBaseMapping : Profile
    {
        public DataBaseMapping() 
        {
            CreateMap<UserEntity, User>();
        }
    }
}
