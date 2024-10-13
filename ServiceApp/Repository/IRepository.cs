using System.Collections.Generic;

namespace ServiceApp.Repository
{
    public interface IRepository <T> where T : class
    {
        IEnumerable<T> GetAllAsync();
        Task<T?> GetByIdAsynk(int id);
        Task<Task> InsertAsync(T entity);
        void UpdateAsync(T entity);
        void DeleteAsync(int id);
        void SaveAsync();
    }
}
