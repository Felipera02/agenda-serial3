using Backend.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Backend.Repositories
{
    public abstract class GenericRepository<T>(AgendaContext context) where T : class
    {
        protected readonly AgendaContext _context 
            = context;

        public void Add(T model)
        {
            _context.Set<T>().Add(model);
            _context.SaveChanges();
        }

        public void AddRange(IEnumerable<T> model)
        {
            _context.Set<T>().AddRange(model);
            _context.SaveChanges();
        }

        public T? GetId(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public async Task<T?> GetIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public T? Get(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public IEnumerable<T> GetList(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where<T>(predicate).ToList();
        }

        public async Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> predicate)
        {
            return await Task.Run(() => _context.Set<T>().Where<T>(predicate));
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Task.Run(() => _context.Set<T>());
        }

        public int Count()
        {
            return _context.Set<T>().Count();
        }

        public async Task<int> CountAsync()
        {
            return await _context.Set<T>().CountAsync();
        }

        public void Update(T objModel)
        {
            _context.Entry(objModel).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remove(T objModel)
        {
            _context.Set<T>().Remove(objModel);
            _context.SaveChanges();
        }
    }
}

