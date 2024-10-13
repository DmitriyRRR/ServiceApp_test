
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

        public IEnumerable<T> GetAllAsync()
        {
            return _context.Set<T>().ToList();
        }

        public async Task<T?> GetByIdAsynk(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<Task> InsertAsync(T entity)
        {
            _context.Add<T>(entity);
            return Task.CompletedTask;
        }

        public void UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void DeleteAsync(int id)//add check delete? exception

        {
            T t =_context.Set<T>().Find(id);
            _context.Remove(t);
        }

        public async void SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
