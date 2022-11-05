using BackEnd.Context;
using BackEnd.Models;

namespace BackEnd.Services
{
    public class LocalUserService : IUserService
    {
        private UserContext userContext = UserContext.GetInstance();
        public User createUser(string firstName, string lastName, string email)
        {
            User user = new User() { 
                firstName = firstName,
                lastName = lastName,
                email = email
            };

            var findUser = getUsers().FirstOrDefault(x => x.email == email);
            if (findUser == null) {
                userContext.Add(user);
            }
            else {
                updateUser(user);
            }

            return user;
        }

        public User getUser(string email)
        {
            return getUsers().First(x => x.email == email);
        }

        public IEnumerable<User> getUsers(string? lastName = null, string? order = null)
        {
            var users = (lastName != null) ? userContext.GetUsers().Where(x => x.lastName == lastName) : userContext.GetUsers();

            users = (order == "desc") ?
                users.OrderByDescending(x => x.lastName).OrderBy(x => lastName) :
                users.OrderBy(x => x.lastName).OrderBy(x => lastName);
            
            return users;
        }

        public User updateUser(User user)
        {
            var index = userContext.GetUsers().FindIndex(x => x.email == user.email);
            if(index == -1)
            {
                userContext.GetUsers()[index] = user;
            }

            return user;
        }
    }
}
