
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsynk(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public void InsertAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
