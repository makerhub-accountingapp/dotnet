using AccountingApp.TL.Templates;

namespace AccountingApp.API.Templates
{
	public interface IGenericController<TEntity, TCreateForm, TUpdateForm>
		where TEntity : class, IIdentifiable
		where TCreateForm : class, IConvertibleToEntity<TEntity, TCreateForm>
		where TUpdateForm : class, IConvertibleToEntity<TEntity, TUpdateForm>, IIdentifiable
	{
		/// <summary>
		/// Adds a new entity to the database.
		/// </summary>
		/// <param name="entity">Entity to add.</param>
		/// <param name="predicate">Condition to test entities.</param>
		/// <returns>The added entity, or null.</returns>
		TEntity? Create(TCreateForm form, Func<TEntity, bool>? predicate);

		/// <summary>
		/// Deletes an entity from the database.
		/// </summary>
		/// <param name="id">Id to remove.</param>
		/// <returns>The removed entity.</returns>
		TEntity? Delete(int id);

		/// <summary>
		/// Retrieves all.
		/// </summary>
		/// <returns>A collection of matching entities.</returns>
		IEnumerable<TEntity> Get();

		/// <summary>
		/// Retrieves a single entity that matches the condition.
		/// </summary>
		/// <param name="predicate">Id to test the entity.</param>
		/// <returns>The matching entity, or null.</returns>
		TEntity? GetById(int id);

		/// <summary>
		/// Updates an existing entity in the repository.
		/// </summary>
		/// <param name="entity">Entity with updated values.</param>
		/// <returns>The updated entity.</returns>
		TEntity? Update(TUpdateForm form);
	}
}
