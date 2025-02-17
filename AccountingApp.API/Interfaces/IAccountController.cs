using AccountingApp.DB.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AccountingApp.API.Interfaces
{
	public interface IAccountController
	{
		/// <summary>
		/// Adds a new entity to the database.
		/// </summary>
		/// <param name="entity">Entity to add.</param>
		/// <param name="userId">Condition to test entities if the data already exists in the DB.</param>
		/// <returns>The added entity, or null.</returns>
		IActionResult Get(int userId);
	}
}
