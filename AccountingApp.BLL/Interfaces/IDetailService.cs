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
	public interface IDetailService : IService<Detail>
	{
		/// <summary>
		/// Adds a new entity to the database.
		/// </summary>
		/// <param name="detail">Form to add.</param>
		/// <returns>The added entity, or null.</returns>
		public Detail? Create(DetailForm detail);

		/// <summary>
		/// Deletes an entity from the database.
		/// </summary>
		/// <param name="id">Id of an entity to remove.</param>
		/// <returns>The removed entity.</returns>
		public void Delete(int id);

		/// <summary>
		/// Retrieves entities that match the given condition.
		/// </summary>
		/// <param name="detail">Condition to filter entities (optional).</param>
		/// <returns>A collection of matching entities.</returns>
		public IEnumerable<Detail> Get(DetailGetForm detail);

		/// <summary>
		/// Updates an existing entity in the repository.
		/// </summary>
		/// <param name="detail">Form to update values.</param>
		/// <returns>The updated entity.</returns>
		public Detail? Update(DetailUpdateForm detail);
	}
}
