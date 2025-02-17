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
    public class CategoryService(ICategoryRepository repo) : Service<Category, CategoryCreateForm, CategoryUpdateForm>(repo), ICategoryService
    {
		public IEnumerable<Category> Get(int userId)
		{
			Func<Category, bool> predicate = c => c.UserId == userId;
			return base.Get(predicate);
		}
	}
}
