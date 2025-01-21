using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingApp.TL.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace OnlineRestaurant.TL.Templates
{
	public abstract class Service<TEntity> : IService<TEntity> where TEntity : class
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

		public virtual TEntity? Create(TEntity entity)
		{
			return _repo.Create(entity);
		}

		public virtual TEntity? Update(TEntity entity)
		{
			return _repo.Update(entity);
		}

        public virtual TEntity? Delete(TEntity entity)
		{
			return _repo.Delete(entity);
		}
	}
}
