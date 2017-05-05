using Chem.DataBase;
using Chem.DataBase.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Chem.Managment.Visual.Controllers
{
    public class SubstanceController
    {
       // ChemDBEntities dataContex;
        MyDatabaseEntities dataContex;
        public SubstanceController() 
        {           
           // dataContex = new ChemDBEntities();
            dataContex = new MyDatabaseEntities();
            Substances = GetAll();
        }
        
        public IEnumerable<Substance> GetAll() 
        {
            
            var substanceRepo = new SubstanceRepository(dataContex);
            Substance s = new Substance();            
            return substanceRepo.GetAll().ToList();
        }

        public IEnumerable<Substance> Substances { get; set; }

        internal void Reset()
        {
            Substances = GetAll();
        }

        internal void Filter(string pattern,string section)
        {
            if (section == "Producto Químico")
                 Substances = GetAll().Where(p => p.ProductName.ToLower().Contains(pattern.ToLower()));
            else
                Substances = GetAll().Where(p => p.FormulaHill.ToLower().Contains(pattern.ToLower())).OrderBy(p => p.FormulaHill, new Comparer(pattern));
        }
    }
}
