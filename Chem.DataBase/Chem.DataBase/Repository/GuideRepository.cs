using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chem.DataBase.Repository
{
    public class GuideRepository : EFRepository<Guide>
    {
        public GuideRepository(DbContext dbContext)
            : base(dbContext)
        {

        }

        public Guide FindByName(string name)
        {
            return GetAll().SingleOrDefault(p => p.Name == name);
        }

        public override Guide Add(Guide entity)
        {
            var x = FindByName(entity.Name);
            if (x == null)
                return base.Add(entity);
            return x;
        }
    }
}
