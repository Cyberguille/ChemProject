using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chem.DataBase.Repository
{
    public class SynonymRepository : EFRepository<Synonym>
    {
        public SynonymRepository(DbContext dbContext)
            : base(dbContext)
        {
        }

        public Synonym FindByName(string name)
        {
            return GetAll().SingleOrDefault(p => p.Name == name);
        }

        public override Synonym Add(Synonym entity)
        {
            var x = FindByName(entity.Name);
            if (x == null)
                return base.Add(entity);
            return x;
        }
    }
}
