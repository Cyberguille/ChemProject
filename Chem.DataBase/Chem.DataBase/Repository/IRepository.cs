using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chem.DataBase.Repository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T GetById(Guid id);
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(Guid id);
        void SubmitChanges();
    }

}
