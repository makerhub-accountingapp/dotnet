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
	public interface IDetailService : IService<Detail, DetailCreateForm, DetailUpdateForm>
	{
		/// <summary>
		/// Retrieves entities that match the given condition.
		/// </summary>
		/// <param name="detail">Condition to filter entities (optional).</param>
		/// <returns>A collection of matching entities.</returns>
		public IEnumerable<Detail> Get(DetailGetForm detail);
	}
}
