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
	public class AccountService(IAccountRepository repo) : Service<Account, AccountCreateForm,  AccountUpdateForm>(repo), IAccountService
	{
		public IEnumerable<Account> Get(int userId)
		{
			Func<Account, bool> predicate = a => a.UserId == userId;
			return base.Get(predicate);
		}
	}
}
