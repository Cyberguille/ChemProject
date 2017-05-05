using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Chem.DataBase.Repository
{
    public class EntityRepository:EFRepository<Entity>
    {
        public EntityRepository(DbContext dbContext)
            : base(dbContext)
        {
        }

        public Entity FindByName(string name)
        {
            return GetAll().SingleOrDefault(p => p.Name == name);           
        }

        public override Entity Add(Entity entity)
        {
            var x = FindByName(entity.Name);
            if(x==null)
                return base.Add(entity);
            return x; 
        }
    }
}
