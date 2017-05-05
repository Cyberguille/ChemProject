using Chem.DataBase;
using Chem.DataBase.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chem.Managment.Visual.Controllers
{
    public class EntityController
    {
        // ChemDBEntities dataContex;
        MyDatabaseEntities dataContex;
          public EntityController() 
        {
            // dataContex = new ChemDBEntities();
            dataContex = new MyDatabaseEntities();
            Entities = GetAll();
        }
        
        public IEnumerable<Entity> GetAll() 
        {
            
            var substanceRepo = new EntityRepository(dataContex);
            Substance s = new Substance();            
            return substanceRepo.GetAll().ToList();
        }

        public IEnumerable<Entity> Entities { get; set; }

        internal void Reset()
        {
            Entities = GetAll();
        }

      public void GetByName(string name)
      {
        Entities = GetAll().Where(p=>p.Name==name);
      }

      internal void Filter(string pattern,string section)
        {
            if (section == "Nombre")
                Entities = GetAll().Where(p => p.Name.ToLower().Contains(pattern.ToLower())).OrderBy(p => p.Name, new Comparer(pattern));
            else if (section == "Dirección")
                Entities = GetAll().Where(p => p.Address.ToLower().Contains(pattern.ToLower())).OrderBy(p => p.Address, new Comparer(pattern));
            else if (section == "Municipio")
                Entities = GetAll().Where(p => p.Town.ToLower().Contains(pattern.ToLower())).OrderBy(p => p.Town, new Comparer(pattern));
            else if (section == "Organización")
                Entities = GetAll().Where(p => p.Organization.ToLower().Contains(pattern.ToLower())).OrderBy(p => p.Organization, new Comparer(pattern));
        
        }
    }
}
