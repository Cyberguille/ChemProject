using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chem.DataBase.Repository
{
    public class Substance_EntityRepository:EFRepository<Substance_Entity>
    {
        public Substance_EntityRepository(DbContext dbContext)
            : base(dbContext)
        {
        }


        public override Substance_Entity Add(Substance_Entity entity)
        {
            var x = GetAll().SingleOrDefault(p => p.IdEntity.Equals(entity.IdEntity) &&
                    p.IdSubstance.Equals(entity.IdSubstance));
            if (x == null)
                return base.Add(entity);
            return x;
        }
       
    }
}
