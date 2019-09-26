using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWordWebAplication.Entidades
{
    public class UserRepository : IUserRepositorycs
    {
        private static readonly List<User> users = new List<User>();
        private static int Next = 0;
        public void ADD(User user)
        {
            user.UserId = Next;
            Next++;
            users.Add(user);
        }

        public ReadOnlyCollection<User> GetAll()
        {
            return users.AsReadOnly();
        }

        public User GetById(int ID)
        {
            var user = users.SingleOrDefault(u=>u.UserId==ID);
            if (user==null)
            {
                return null;
            }
            else
            {
                return new User { Goal = user.Goal, Name = user.Name, Total = user.Total };
            }
        }

        public void Save(User UpdateUser)
        {
            var user = users.SingleOrDefault(u => u.UserId == UpdateUser.UserId);
            if (user == null)
                return;
            user.Name = UpdateUser.Name;
            user.Goal = UpdateUser.Goal;
            user.Total = UpdateUser.Total;

        }
    }
}
