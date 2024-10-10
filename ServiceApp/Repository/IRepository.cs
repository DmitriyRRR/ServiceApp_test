using System.Collections.Generic;

namespace ServiceApp.Repository
{
    public interface IRepository <T> where T : class
    {
        IEnumerable<T> GetAllItems();
        Task<T?> GetByIdAsynk(int id);
        Task<Task> InsertAsync(T entity);
        void UpdateAsync(T entity);
        void DeleteAsync(T entity);
        void SaveAsync();
    }
}
