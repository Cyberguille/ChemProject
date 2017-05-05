using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chem.DataBase.Repository
{
    public class EFRepository<T> : IDisposable, IRepository<T> where T : class
    {
        public EFRepository(DbContext dbContext)
        {
            if (dbContext == null)
                throw new ArgumentNullException("dbContext");
            DbContext = dbContext;
            DbSet = dbContext.Set<T>();
        }
        public Guid GetId() 
        {
            var id = Guid.NewGuid();
            while(GetById(id)!=null)
                id = Guid.NewGuid();
            return id;
        }
        protected DbContext DbContext { get; set; }

        protected DbSet<T> DbSet { get; set; }

        public IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public virtual T GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual T Add(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
                return (T)dbEntityEntry.Entity;
            }
            else
                return DbSet.Add(entity);
        }

        public void Update(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            dbEntityEntry.State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
                dbEntityEntry.State = EntityState.Deleted;
            else
            {
                DbSet.Attach(entity);
                DbSet.Remove(entity);
            }
        }

        public void Delete(Guid id)
        {
            var entity = GetById(id);
            if (entity == null) return;
            Delete(entity);
        }

        public void SubmitChanges()
        {
            DbContext.SaveChanges();
        }

        public void Dispose()
        {

        }
    }

}
