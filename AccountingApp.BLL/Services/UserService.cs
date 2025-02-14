using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingApp.BLL.Forms;
using AccountingApp.BLL.Interfaces;
using AccountingApp.DAL.Interfaces;
using AccountingApp.DB.Entities;
using OnlineRestaurant.TL.Templates;

namespace AccountingApp.BLL.Services
{
    public class UserService(IUserRepository repo) : Service<User, UserCreateForm, UserUpdateForm>(repo), IUserService
    {
        public User? Login(string email, string password)
        {
            Func<User, bool> predicate = u => u.Email == email && u.Password == password;

            return repo.GetOne(predicate);
        }
    }
}
