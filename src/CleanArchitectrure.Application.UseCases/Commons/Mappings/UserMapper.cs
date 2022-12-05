using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitectrure.Application.Dto;
using CleanArchitectrure.Application.UseCases.Users.Commands.CreateUserCommand;
using CleanArchitectrure.Domain.Entities;

namespace CleanArchitectrure.Application.UseCases.Commons.Mappings
{
    public class UserMapper: Profile
    {
        public UserMapper()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, CreateUserCommand>().ReverseMap();
        }
    }
}
