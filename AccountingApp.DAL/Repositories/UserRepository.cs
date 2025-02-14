using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingApp.DAL.Interfaces;
using AccountingApp.DB.Contexts;
using AccountingApp.DB.Entities;
using Microsoft.EntityFrameworkCore;
using OnlineRestaurant.TL.Templates;

namespace AccountingApp.DAL.Repositories
{
	public class UserRepository(MainContext context) : Repository<User>(context), IUserRepository
	{
        public override User? GetOne(Func<User, bool> predicate)
        {
            if (predicate is not null)
            {
                return Entities.Include(u => u.Accounts).FirstOrDefault(predicate);
            }
            else
            {
                return Entities.Include(u => u.Accounts).FirstOrDefault();
            }
        }
    }
}
