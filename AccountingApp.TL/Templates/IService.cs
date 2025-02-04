﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingApp.TL.Templates;

namespace OnlineRestaurant.TL.Templates
{
	public interface IService<TEntity, TCreateForm, TUpdateForm>
		where TEntity : class
		where TCreateForm : class, IConvertibleToEntity<TEntity, TCreateForm>
		where TUpdateForm : class, IConvertibleToEntity<TEntity, TUpdateForm>, IIdentifiable
	{
		/// <summary>
		/// Checks if any entity matches the given condition.
		/// </summary>
		/// <param name="predicate">Condition to test entities.</param>
		/// <returns>True if any entity matches, otherwise false.</returns>
		bool Any(Func<TEntity, bool> predicate);

        /// <summary>
        /// Adds a new entity to the database.
        /// </summary>
        /// <param name="entity">Entity to add.</param>
        /// <returns>The added entity, or null.</returns>
        TEntity? Create(TCreateForm form);

        /// <summary>
        /// Adds a new entity to the database.
        /// </summary>
        /// <param name="entity">Entity to add.</param>
        /// <param name="predicate">Condition to test entities if the data already exists in the DB.</param>
        /// <returns>The added entity, or null.</returns>
        TEntity? Create(TCreateForm form, Func<TEntity, bool> predicate);

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
		/// Retrieves entities that match the given condition.
		/// </summary>
		/// <param name="predicate">Condition to filter entities (optional).</param>
		/// <returns>A collection of matching entities.</returns>
		IEnumerable<TEntity> Get(Func<TEntity, bool>? predicate);

		/// <summary>
		/// Retrieves a single entity that matches the condition.
		/// </summary>
		/// <param name="predicate">Id to test the entity.</param>
		/// <returns>The matching entity, or null.</returns>
		TEntity? GetById(int id);

		/// <summary>
		/// Retrieves a single entity that matches the condition.
		/// </summary>
		/// <param name="predicate">Condition to test the entity.</param>
		/// <returns>The matching entity, or null.</returns>
		TEntity? GetOne(Func<TEntity, bool> predicate);

		/// <summary>
		/// Updates an existing entity in the repository.
		/// </summary>
		/// <param name="entity">Entity with updated values.</param>
		/// <returns>The updated entity.</returns>
		TEntity? Update(TUpdateForm form);

    }
}
