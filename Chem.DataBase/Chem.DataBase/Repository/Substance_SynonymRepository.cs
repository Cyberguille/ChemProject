using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chem.DataBase.Repository
{
    public class Substance_SynonymRepository : EFRepository<Substance_Synonym 
       >
    {
        public Substance_SynonymRepository(DbContext dbContext)
            : base(dbContext)
        {
        }

        public override Substance_Synonym Add(Substance_Synonym entity)
        {
            var x = GetAll().SingleOrDefault(p => p.IdSynonym.Equals(entity.IdSynonym) &&
                    p.IdSubstance.Equals(entity.IdSubstance));
            if (x == null)
                return base.Add(entity);
            return x;
        }
    }
}
