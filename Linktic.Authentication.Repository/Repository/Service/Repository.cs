using Linktic.Authentication.Repository.Context;
using Linktic.Authentication.Repository.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Linktic.Authentication.Repository.Repository.Service
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly AuthenticationContext contextDataBase;
		private readonly DbSet<T> entity;

		public Repository(AuthenticationContext contextDataBase)
		{
			this.contextDataBase = contextDataBase;
			this.entity = this.contextDataBase.Set<T>();
		}

		public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
		{
			IQueryable<T> query = this.entity
				.AsNoTracking()
				.Where(predicate);

			return query.ToList();
		}

		public IEnumerable<T> FindByInclude(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
		{
			IQueryable<T> query = this.entity
				.AsNoTracking()
				.Where(predicate);

			foreach (var include in includes)
			{
				query = query.Include(include);
			}

			return query.ToList();
		}

		public T SingleFindBy(Expression<Func<T, bool>> predicate)
		{
			return this.entity
				.SingleOrDefault(predicate);
		}

	}
}
