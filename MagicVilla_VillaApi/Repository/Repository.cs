using MagicVilla_VillaApi.Data;
using MagicVilla_VillaApi.Models;
using MagicVilla_VillaApi.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace MagicVilla_VillaApi.Repository
{
    public class Repository<T> : IRepository<T> where T:class
    {
        private readonly AplicationDBContext _dbCon;
        internal DbSet<T> _db;
        public Repository(AplicationDBContext dbCon)
        {
            _dbCon = dbCon;
            //_dbCon.VillaNumbers.Include(n => n.Villa).ToList();
            _db = _dbCon.Set<T>();
        }
        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null
                , int pageSize = 0, int pageNumber = 1)
        {
            IQueryable<T> query = _db;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (pageSize > 0)
            {
                if (pageSize > 100)
                {
                    pageSize = 100;
                }
                query = query.Skip(pageSize * (pageNumber - 1)).Take(pageSize);
            }
            if (includeProperties != null)
            {
                foreach (var includProp in includeProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query.Include(includProp).ToList();
                }
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Expression<Func<T, bool>> filter = null, bool tracked = true, string? includeProperties = null)
        {

            IQueryable<T> query = _db;
            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }

            
            if (includeProperties != null)
            {
                foreach (var includProp in includeProperties.Split(new char[] {','},StringSplitOptions.RemoveEmptyEntries))
                {
                    query.Include(includProp).ToList();
                }
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task CreateAsync(T entity)
        {
            await _db.AddAsync(entity);
            await SaveAsync();
        }

       
        public async Task RemoveAsync(T entity)
        {
            _db.Remove(entity);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _dbCon.SaveChangesAsync();
        }
    }
}
