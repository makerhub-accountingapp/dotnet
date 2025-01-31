using AccountingApp.TL.Templates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using OnlineRestaurant.TL.Templates;

namespace AccountingApp.API.Templates
{
	public interface IGenericHubController<TEntity, TCreateForm, TUpdateForm, THub>

        /********** Generic characteristics **********/

        where TEntity : class, IIdentifiable
		where TCreateForm : class, IConvertibleToEntity<TEntity, TCreateForm>
		where TUpdateForm : class, IConvertibleToEntity<TEntity, TUpdateForm>, IIdentifiable
		where THub : Hub
	{
		/// <summary>
		/// Asynchronously adds a new entity to the database.
		/// </summary>
		/// <param name="form">The form containing the data to create the entity.</param>
		/// <returns>A task representing the asynchronous operation. The task result contains the added entity, or null if the addition failed.</returns>
		Task<IActionResult> Create([FromBody]TCreateForm form);

		/// <summary>
		/// Asynchronously deletes an entity from the database by its ID.
		/// </summary>
		/// <param name="id">The ID of the entity to remove.</param>
		/// <returns>A task representing the asynchronous operation. The task result contains the removed entity, or null if no entity was found.</returns>
		Task<IActionResult?> Delete([FromRoute]int id);

		/// <summary>
		/// Asynchronously retrieves all entities from the database.
		/// </summary>
		/// <returns>A task representing the asynchronous operation. The task result contains a collection of all entities.</returns>
		Task<IActionResult> Get();

		/// <summary>
		/// Asynchronously retrieves a single entity by its ID.
		/// </summary>
		/// <param name="id">The ID of the entity to retrieve.</param>
		/// <returns>A task representing the asynchronous operation. The task result contains the matching entity, or null if no entity was found.</returns>
		Task<IActionResult> GetById([FromRoute]int id);

		/// <summary>
		/// Asynchronously updates an existing entity in the database.
		/// </summary>
		/// <param name="form">The form containing the updated data for the entity.</param>
		/// <returns>A task representing the asynchronous operation. The task result contains the updated entity, or null if the update failed.</returns>
		Task<IActionResult> Update([FromBody]TUpdateForm form);

	}
}
