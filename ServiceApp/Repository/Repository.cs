
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ServiceApp.Database;
using ServiceApp.Database.Models;

namespace ServiceApp.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ServiceAppContext _context;

        public Repository(ServiceAppContext context)
        {
            _context = context;
        }

        public async  Task<IEnumerable<T>> GetAllAsync()
        {
            return  await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        
        public async Task  InsertAsync(T entity)
        {
          await  _context.AddAsync<T>(entity);
        }


        public T? GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }
        
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public void  Insert(T entity)
        {
            _context.Add<T>(entity);
        }

        public void Update(T entity)
        {
            _context.Entry<T>(entity).State = EntityState.Modified;
        }

        public void Delete(T t)//add check delete? exception

        {
            _context.Remove(t);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
           await _context.SaveChangesAsync();
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsynk(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
