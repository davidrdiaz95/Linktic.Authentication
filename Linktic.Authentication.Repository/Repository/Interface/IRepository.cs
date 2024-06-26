using System.Linq.Expressions;

namespace Linktic.Authentication.Repository.Repository.Interface
{
	public interface IRepository<T>
	{
		T SingleFindBy(Expression<Func<T, bool>> predicate);
		IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
		IEnumerable<T> FindByInclude(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
	}
}
