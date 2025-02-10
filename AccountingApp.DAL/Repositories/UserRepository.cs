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
	}
}
