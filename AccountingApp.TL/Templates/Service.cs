using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingApp.TL.Exceptions;
using AccountingApp.TL.Templates;
using Microsoft.EntityFrameworkCore;

namespace OnlineRestaurant.TL.Templates
{
	public abstract class Service<TEntity, TCreateForm, TUpdateForm> : IService<TEntity, TCreateForm, TUpdateForm> 
		where TEntity : class, IIdentifiable
		where TCreateForm : class, IConvertibleToEntity<TEntity, TCreateForm>
		where TUpdateForm : class, IConvertibleToEntity<TEntity, TUpdateForm>, IIdentifiable
	{
		private readonly IRepository<TEntity> _repo;
		private readonly Func<TEntity, int> _idPredicate;

		protected Service(IRepository<TEntity> repo, Func<TEntity, int> idPredicate)
		{
			_repo = repo;
			_idPredicate = idPredicate;
		}

		public virtual bool Any(Func<TEntity, bool> predicate)
		{
			return _repo.Any(predicate);
		}

		public virtual TEntity? Create(TCreateForm form, Func<TEntity, bool>? predicate)
		{
			// Checks if the detail exists
			if (predicate is not null && Any(predicate))
			{
				throw new AlreadyExistException($"{ typeof(TEntity).Name } already registered.");
			}

			return _repo.Create(form.ToEntity(form));
		}

		public virtual TEntity? Delete(int id)
		{
			// Checks if the detail exists
			TEntity? entityToDelete = GetById(id);

			if (entityToDelete is null)
			{
				throw new NotFoundException($"{ typeof(TEntity).Name } not found.");
			}

			return _repo.Delete(entityToDelete);
		}

		public virtual IEnumerable<TEntity> Get()
		{
			return _repo.Get();
		}

		public virtual IEnumerable<TEntity> Get(Func<TEntity, bool>? predicate)
		{
			return _repo.Get(predicate);
		}

		public virtual TEntity? GetById(int id)
		{
			return _repo.GetOne(entity => _idPredicate(entity) == id);
		}
		
		public virtual TEntity? GetOne(Func<TEntity, bool> predicate)
		{
			return _repo.GetOne(predicate);
		}

		public virtual TEntity? Update(TUpdateForm form)
		{
			// Checks if the detail exists
			TEntity? foundEntity = GetById(form.Id);

			if (foundEntity is null)
			{
				throw new NotFoundException($"{ typeof(TEntity).Name } not found.");
			}

			return _repo.Update(form.ToEntity(form));
		}
	}
}
