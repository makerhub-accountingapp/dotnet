using AccountingApp.TL.Templates;
using Microsoft.AspNetCore.Mvc;

namespace AccountingApp.API.Templates
{
	public interface IGenericController<TEntity, TCreateForm, TUpdateForm>

        /********** Generic characteristics **********/

        where TEntity : class, IIdentifiable
		where TCreateForm : class, IConvertibleToEntity<TEntity, TCreateForm>
		where TUpdateForm : class, IConvertibleToEntity<TEntity, TUpdateForm>, IIdentifiable
	{
		/// <summary>
		/// Adds a new entity to the database.
		/// </summary>
		/// <param name="entity">Entity to add.</param>
		/// <returns>The added entity, or null.</returns>
		IActionResult Create([FromBody]TCreateForm form);

		/// <summary>
		/// Deletes an entity from the database.
		/// </summary>
		/// <param name="id">Id to remove.</param>
		/// <returns>The removed entity.</returns>
		IActionResult Delete([FromRoute]int id);

		/// <summary>
		/// Retrieves all.
		/// </summary>
		/// <returns>A collection of matching entities.</returns>
		IActionResult Get();

		/// <summary>
		/// Retrieves a single entity that matches the condition.
		/// </summary>
		/// <param name="predicate">Id to test the entity.</param>
		/// <returns>The matching entity, or null.</returns>
		IActionResult GetById([FromRoute]int id);

		/// <summary>
		/// Updates an existing entity in the repository.
		/// </summary>
		/// <param name="entity">Entity with updated values.</param>
		/// <returns>The updated entity.</returns>
		IActionResult Update([FromBody]TUpdateForm form);
	}
}
