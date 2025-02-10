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
	public class UserCreateForm : IConvertibleToEntity<User, UserCreateForm>
	{
		[Required]
		public string Email { get; set; } = string.Empty;
		[Required]
		public string Password { get; set; } = string.Empty;

		public User ToEntity(UserCreateForm form)
		{
			return new User
			{
				Email = form.Email,
				Password = form.Password,
				IsActive = true
			};
		}
	}
	public class UserUpdateForm : IConvertibleToEntity<User, UserUpdateForm>, IIdentifiable
	{
		[Required]
		public int Id { get; set; }
		[Required]
		public string Email { get; set; } = string.Empty;
		[Required]
		public string Password { get; set; } = string.Empty;
		[Required]
		public bool IsActive { get; set; } = true;

		public User ToEntity(UserUpdateForm form)
		{
			return new User
			{
				Id = form.Id,
				Email = form.Email,
				Password = form.Password,
				IsActive = form.IsActive
			};
		}
	}
}
