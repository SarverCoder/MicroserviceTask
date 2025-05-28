using OrderService.DataAccess;
using OrderService.Repository.Interfaces;

namespace OrderService.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly OrderDbContext _context;

        public Repository(OrderDbContext context)
        {
            _context = context;
        }


        public void Add(TEntity entity) => _context.Set<TEntity>().Add(entity);

        public async Task AddAsync(TEntity entity) => await _context.Set<TEntity>().AddAsync(entity);

        public void Update(TEntity entity) => _context.Set<TEntity>().Update(entity);

        public IQueryable<TEntity> GetAll() => _context.Set<TEntity>().AsQueryable();

        public TEntity GetById(int id) => _context.Set<TEntity>().Find(id) ?? throw new ArgumentNullException(nameof(id), "Entity not found.");

        public async Task<TEntity> GetByIdAsync(int id) => await _context.Set<TEntity>().FindAsync(id).AsTask() ?? throw new ArgumentNullException(nameof(id), "Entity not found.");

        public void Delete(TEntity entity) => _context.Set<TEntity>().Remove(entity);

        public int SaveChanges() => _context.SaveChanges();

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

    }
   
}
