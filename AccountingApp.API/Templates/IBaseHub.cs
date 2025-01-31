namespace AccountingApp.API.Templates
{
	public interface IBaseHub<TEntity> where TEntity : class
	{
		/// <summary>
		/// Notifies all connected clients about the creation of a new entity.
		/// </summary>
		/// <param name="entity">The created entity to notify about.</param>
		Task NotifyCreate(TEntity entity);

		/// <summary>
		/// Notifies all connected clients about the deletion of an entity.
		/// </summary>
		/// <param name="entity">The deleted entity to notify about.</param>
		Task NotifyDelete(TEntity entity);

		/// <summary>
		/// Notifies all connected clients about the retrieval of multiple entities.
		/// </summary>
		/// <param name="entities">The list of entities to notify about.</param>
		Task NotifyGet(TEntity[] entities);

		/// <summary>
		/// Notifies all connected clients about the retrieval of a specific entity by its ID.
		/// </summary>
		/// <param name="entity">The entity retrieved by ID to notify about.</param>
		Task NotifyGetById(TEntity entity);

	}
}
