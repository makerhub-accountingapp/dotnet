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
    public interface ICategoryService : IService<Category, CategoryCreateForm, CategoryUpdateForm>
    {
		/// <summary>
		/// Adds a new entity to the database.
		/// </summary>
		/// <param name="entity">Entity to add.</param>
		/// <param name="userId">Condition to test entities if the data already exists in the DB.</param>
		/// <returns>The added entity, or null.</returns>
		IEnumerable<Category> Get(int id);
	}
}
