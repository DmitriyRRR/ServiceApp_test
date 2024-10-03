
using ServiceApp.Database;

namespace ServiceApp.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ServiceAppContext _context = null;

        public Repository(ServiceAppContext context)
        {
            _context = context;
        }

        public void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T?> GetByIdAsynk(int id)
        {
            throw new NotImplementedException();
        }

        public void InsertAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public void SaveAsync()
        {
            throw new NotImplementedException();
        }

        public void UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
