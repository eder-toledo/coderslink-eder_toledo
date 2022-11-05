using BackEnd.Models;

namespace BackEnd.Services
{
    public interface IUserService
    {
        User createUser(string firstName, string lastName, string email);
        User getUser(string email);
        User updateUser(User user);
        IEnumerable<User> getUsers(string? firstName, string? order);
    }
}
