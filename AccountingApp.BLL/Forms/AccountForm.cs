using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingApp.DB.Entities;
using AccountingApp.TL.Templates;

namespace AccountingApp.BLL.Forms
{
	public class AccountCreateForm : IConvertibleToEntity<Account, AccountCreateForm>
	{
		[Required]
		public string Name { get; set; } = string.Empty;
		[Required]
		public decimal Balance { get; set; } = 0;
		[Required]
		public int UserId { get; set; }
		public Account ToEntity(AccountCreateForm form)
		{
			return new Account
			{
				Name = form.Name,
				Balance = form.Balance,
				UserId = form.UserId
			};
		}
	}

	public class AccountUpdateForm : IConvertibleToEntity<Account, AccountUpdateForm>, IIdentifiable
	{
		[Required]
		public int Id { get; set; }
		[Required]
		public string Name { get; set; } = string.Empty;
		[Required]
		public decimal Balance { get; set; } = 0;
		[Required]
		public int UserId { get; set; }
		public Account ToEntity(AccountUpdateForm form)
		{
			return new Account
			{
				Id = form.Id,
				Name = form.Name,
				Balance = form.Balance,
				UserId = form.UserId
			};
		}
	}
}
