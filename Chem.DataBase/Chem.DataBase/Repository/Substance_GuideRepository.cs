using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chem.DataBase.Repository
{
    public class Substance_GuideRepository : EFRepository<Substance_Guide>
    {
        public Substance_GuideRepository(DbContext dbContext)
            : base(dbContext)
        {
        }

        public override Substance_Guide Add(Substance_Guide entity)
        {
            var x = GetAll().SingleOrDefault(p => p.IdGuide.Equals(entity.IdGuide) &&
                    p.IdSubstance.Equals(entity.IdSubstance));
            if (x == null)
                return base.Add(entity);
            return x;
        }
    }
}
