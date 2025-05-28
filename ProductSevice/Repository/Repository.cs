using System.Runtime.InteropServices;
using ProductService.DataAccess;
using ProductService.Repository.Interfaces;

namespace ProductService.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity :class
    {
        protected readonly ProductDbContext Context;

        public Repository(ProductDbContext context)
        {
            Context = context;
        }


        public void Add(TEntity entity) => Context.Set<TEntity>().Add(entity);


        public async Task AddAsync(TEntity entity) => await Context.Set<TEntity>().AddAsync(entity);


        public void Update(TEntity entity) => Context.Set<TEntity>().Update(entity);

        public IQueryable<TEntity> GetAll() => Context.Set<TEntity>().AsQueryable();

        public TEntity GetById(int id) => Context.Set<TEntity>().Find(id);


        public async Task<TEntity> GetByIdAsync(int id) => await Context.Set<TEntity>().FindAsync(id);


        public void Delete(TEntity entity) => Context.Set<TEntity>().Remove(entity);


        public int SaveChanges() => Context.SaveChanges();

        public async Task<int> SaveChangesAsync() => await Context.SaveChangesAsync();

    }
}
