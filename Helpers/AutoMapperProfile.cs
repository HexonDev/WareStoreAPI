using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WareStoreAPI.DTO;
using WareStoreAPI.Models;

namespace WareStoreAPI.Helper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<RegisterDTO, User>();
            CreateMap<UpdateDTO, User>();
        }
    }
}