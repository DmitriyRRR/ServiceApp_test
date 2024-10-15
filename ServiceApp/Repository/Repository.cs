
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

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
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

        public async void Save()
        {
            _context.SaveChanges();
        }
    }
}
