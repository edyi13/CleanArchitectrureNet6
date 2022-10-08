using CleanArchitectrure.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectrure.Application.Interface.Persistence
{
    public interface IUserRepository
    {
        Task<User> GetAync(string client);
        Task<bool> InsertAync(User user);
    }
}
