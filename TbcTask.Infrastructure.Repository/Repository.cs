using Microsoft.EntityFrameworkCore;
using TbcTask.Domain.Models.Database;
using TbcTask.Domain.Repository;
using TbcTask.Infrastructure.Store;

namespace TbcTask.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseDatabase
    {
        private readonly PersonDbContext _PersonDbContext;
        private readonly DbSet<T> _DbSet;
        public Repository(PersonDbContext personDbContext) {
        
        _PersonDbContext = personDbContext;
            _DbSet = personDbContext.Set<T>();
        }
        public T Add(T entity)
        {
            _DbSet.Add(entity);
            return entity;

        }

        public IQueryable<T> GetAll()
        {
            return _DbSet.AsQueryable();
        }

        public T GetById(int id)
        {
            return _DbSet.Find(id);
        }

        public void Remove(T entity)
        {
            _DbSet.Remove(entity);
           
        }

        public void Update(T entity)
        {
            _PersonDbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}