using ECommerce.Domain.Common;

namespace ECommerce.Application.Contract
{
    public interface IQueryDatabaseService<T> where T : class, IEntity
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
    }
}
