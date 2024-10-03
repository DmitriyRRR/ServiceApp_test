using System.Collections.Generic;

namespace ServiceApp.Repository
{
    public interface IRepository <T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsynk(int id);
        void InsertAsync(T entity);
        void UpdateAsync(T entity);
        void DeleteAsync(int id);
        void SaveAsync();
    }
}
