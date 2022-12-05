using CleanArchitectrure.Domain.Entities;

namespace CleanArchitectrure.Application.Interface.Persistence
{
    public interface IUserRepository
    {
        Task<User> GetAsync(string client);
        Task<bool> InsertAsync(User user);
    }
}
