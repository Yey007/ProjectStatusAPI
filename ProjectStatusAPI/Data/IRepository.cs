using System.Threading.Tasks;

namespace ProjectStatusAPI.Data
{
    public interface IRepository<T>
    {
        Task Create(T entity);
        Task<T> GetById(int id);
        Task<T> Update(T entity);
        Task<T> DeleteById(int id);
    }
}