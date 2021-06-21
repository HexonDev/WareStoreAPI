using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WareStoreAPI.Repositories
{
    public class Repository<TAppDbContext> : IRepository where TAppDbContext : DbContext
    {
        private readonly TAppDbContext _dbContext;

        public Repository(TAppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public ICollection<T> SelectAll<T>() where T : class
        {
            return _dbContext.Set<T>().ToList();
        }

        public T SelectById<T>(long id) where T : class
        {
            return _dbContext.Set<T>().Find(id);
        }

        public void Create<T>(T entity) where T : class
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update<T>(T entity) where T : class
        {
            _dbContext.Set<T>().Update(entity);

            //_dbContext.Set<T>().Attach(entity);
            //_dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Delete<T>(T entity) where T : class
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}
