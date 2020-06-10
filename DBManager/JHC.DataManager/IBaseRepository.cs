using System.Collections.Generic;
using System.Threading.Tasks;
namespace DBManager.JHC.DataManager
{
	public interface IBaseRepository<T>
	{
		Task Insert(T entity, string insertSql);

		Task Update(T entity, string updateSql);

		Task Delete(int Id, string deleteSql);

		Task<List<T>> SelectAsync(string selectSql);

		Task<T> GetOne(int Id, string selectOneSql);

		//Task<List<T>> GetProducts(int Id, string selectSql);
	}
}
