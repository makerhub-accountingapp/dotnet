using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingApp.BLL.Forms;
using AccountingApp.DB.Entities;
using OnlineRestaurant.TL.Templates;

namespace AccountingApp.BLL.Interfaces
{
	public interface IUserService : IService<User, UserCreateForm, UserUpdateForm>
	{
        /// <summary>
        /// Retrieves entity that match the given condition.
        /// </summary>
        /// <param name="email">Email to filter entities.</param>
        /// <param name="password">Password to filter entities.</param>
        /// <returns>A matching entity or null.</returns>
        User? Login(string email, string password);
	}
}
