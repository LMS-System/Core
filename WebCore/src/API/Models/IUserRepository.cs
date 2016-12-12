using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public interface IUserRepository
    {
        void Add(UserModel item);
        IEnumerable<UserModel> GetAll();
        UserModel Find(string key);
        UserModel Remove(string key);
        void Update(UserModel item);
    }

    public class UserRepository : IUserRepository
    {
        private static ConcurrentDictionary<string, UserModel> _users =
              new ConcurrentDictionary<string, UserModel>();

        public UserRepository()
        {
            Add(new UserModel { Name = "User1" });
        }

        public IEnumerable<UserModel> GetAll()
        {
            return _users.Values;
        }

        public void Add(UserModel item)
        {
            item.ID = Guid.NewGuid().ToString();
            _users[item.ID] = item;
        }

        public UserModel Find(string key)
        {
            UserModel item;
            _users.TryGetValue(key, out item);
            return item;
        }

        public UserModel Remove(string key)
        {
            UserModel item;
            _users.TryGetValue(key, out item);
            _users.TryRemove(key, out item);
            return item;
        }

        public void Update(UserModel item)
        {
            _users[item.ID] = item;
        }
    }
}
