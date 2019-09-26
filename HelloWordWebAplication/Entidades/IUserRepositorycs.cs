using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWordWebAplication.Entidades
{
    public interface IUserRepositorycs
    {
        void ADD(User user);
        ReadOnlyCollection<User> GetAll();
        User GetById(int ID);
        void Save(User UpdateUser);
    }
}
