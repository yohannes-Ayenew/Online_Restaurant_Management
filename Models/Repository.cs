

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
        public Task<T> GetByIdAsync(int id, QueryOptions<T> options)
        {
            throw new NotImplementedException();
        }
       
        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }

}