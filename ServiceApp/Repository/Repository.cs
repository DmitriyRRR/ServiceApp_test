
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ServiceApp.Database;
using ServiceApp.Database.Models;

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
            _context.Add<T>(entity);
        }

        public void UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void DeleteAsync(int id)
        {
            var client = _context.Clients.FirstOrDefault(c => c.Id == id);
            _context.Remove<Client>(client);
        }

        public void SaveAsync()
        {
            _context.SaveChangesAsync();
        }
    }
}
