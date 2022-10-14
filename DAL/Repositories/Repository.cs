using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly CashpointDBContext _dbContext;
        private DbSet<TEntity> _entities;
        public Repository(CashpointDBContext dbContext)
        {
            _dbContext = dbContext;
            _entities = dbContext.Set<TEntity>();
        }
        public IEnumerable<TEntity> GetAll()
        {
            return _entities.ToList();
        }
    }
}
