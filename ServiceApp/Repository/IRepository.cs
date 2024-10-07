using System.Collections.Generic;

namespace ServiceApp.Repository
{
    public interface IRepository <T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsynk(int id);
        Task<Task> InsertAsync(T entity);
        void UpdateAsync(T entity);
        Task<Task> DeleteAsync(int id);
        void SaveAsync();
    }
}
