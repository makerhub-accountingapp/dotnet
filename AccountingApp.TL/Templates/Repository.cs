using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace OnlineRestaurant.TL.Templates
{
	public abstract class RepositoryBase(DbContext context)
	{
		protected readonly DbContext _context = context;

		public void Log(string message)
		{
			Console.WriteLine(message);
		}
	}

	public abstract class Repository<TEntity>

		// Dependecy injections
		(DbContext context)

		// Inheritances
		: RepositoryBase(context), IRepository<TEntity>

		// Generic class characteristics
		where TEntity : class
	{
		protected DbSet<TEntity> Entities => _context.Set<TEntity>();

		public virtual bool Any(Func<TEntity, bool> predicate)
		{
			return Entities.Any(predicate);
		}

		public virtual TEntity? Create(TEntity entity)
		{
			EntityEntry<TEntity> entry = _context.Add(entity);
			entry.State = EntityState.Added;
			_context.SaveChanges();
			return entry.Entity;
		}

		public virtual TEntity? Delete(TEntity entity)
		{
			EntityEntry<TEntity> entry = _context.Remove(entity);
			entry.State = EntityState.Deleted;
			_context.SaveChanges();
			return entry.Entity;
		}

		public virtual IEnumerable<TEntity> Get()
		{
			return Entities;
		}

		public virtual IEnumerable<TEntity> Get(Func<TEntity, bool>? predicate)
		{
			return predicate is null ?
				Entities : Entities.Where(predicate);
		}

		public virtual TEntity? GetOne(Func<TEntity, bool> predicate)
		{
			return Entities.FirstOrDefault(predicate);
		}

		public virtual TEntity? Update(TEntity entity)
		{
			EntityEntry<TEntity> entry = _context.Update(entity);
			entry.State = EntityState.Modified;
			_context.SaveChanges();
			return entry.Entity;
		}

		/********** Note **********/

		// RepositoryBase and Repository<TEntity> to separate roles.
		// Repository<TEntity> to work with database.

		// DbContext needs to track entities so it is better to store as Property of the class
		// DbConnection can be used without being stored as Property as it is one-time-use every time

		// Methods not related to the database will be written in RepositoryBase and not in Repository<TEntity>

		// TEntity is a type of class and cannot be int or string

		// EntityEntry<TEntity> contains TEntity and the metadata (state)
	}
}
