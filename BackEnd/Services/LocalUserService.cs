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

        public IEnumerable<User> getUsers()
        {
            return userContext.GetUsers();
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
