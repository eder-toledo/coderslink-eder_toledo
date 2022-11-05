using BackEnd.Models;

namespace BackEnd.Context
{
    public class UserContext
    {
        private static List<User> _users = new List<User>();
        private static readonly UserContext _userContext = new UserContext();

        public User Add(User user) {
            _users.Add(user);
            return user;
        }

        public void Clear() {
            _users.Clear();
        }

        public List<User> GetUsers() { 
            return _users;
        }

        public static UserContext GetInstance() => _userContext;
    }
}
