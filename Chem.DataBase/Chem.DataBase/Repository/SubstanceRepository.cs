using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chem.DataBase.Repository
{
    public class SubstanceRepository : EFRepository<Substance>
    {
        public SubstanceRepository(DbContext dbContext)
            : base(dbContext)
        {
        }

        public Substance FindByName(string name)
        {
            return GetAll().SingleOrDefault(p => p.ProductName == name);
        }

        public override Substance Add(Substance entity)
        {
            var x = FindByName(entity.ProductName);
            if (x == null)
                return base.Add(entity);
            return x;
        }
    }
}
