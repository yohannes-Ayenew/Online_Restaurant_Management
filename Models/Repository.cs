

using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Online_Restaurant_Management.Data;

namespace Online_Restaurant_Management.Models
{
    public class Repository<T> : IRepository<T> where T : class
    {

        protected ApplicationDbContext _context { get; set; }
        private DbSet<T> _dbset { get; set; }

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbset = context.Set<T>();
        }

        public Task AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbset.ToListAsync();
        }
        public async Task<T> GetByIdAsync(int id, QueryOptions<T> options)
        {
            IQueryable<T> query = _dbset;
            if (options.HasWhere)
            {
                query = query.Where(options.Where);
            }
            if (options.HasOrderBy)
            {
                query = query.OrderBy(options.OrderBy);
            }
            foreach (string include in options.GetIncludes())
            {
                query = query.Include(include);
            }

            var key = _context.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties.FirstOrDefault();
            string primaryKeyName = key?.Name;
            return await query.FirstOrDefaultAsync(e => EF.Property<int>(e, primaryKeyName) == id);
        }
        public async Task UpdateAsync(T entity)
        {
            _dbset.Update(entity);
            await _context.SaveChangesAsync();
        }
    }

}