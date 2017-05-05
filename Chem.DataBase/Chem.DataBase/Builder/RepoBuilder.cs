using Chem.DataBase.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chem.DataBase.Builder
{
    public class RepoBuilder
    {
        public static EntityRepository CreateEntityRepo()
        {
             var dataContex = new ChemDBEntities();

            return new EntityRepository(dataContex);
        }

        public static SynonymRepository CreateSynonymRepo()
        {
            var dataContex = new ChemDBEntities();

            return new SynonymRepository(dataContex);
        }

        public static SubstanceRepository CreateSubstanceRepo() 
        {
            var dataContex = new ChemDBEntities();

            return new SubstanceRepository(dataContex);
        }

        public static Substance_SynonymRepository CreateSubstance_SynonymRepo()
        {
            var dataContex = new ChemDBEntities();

            return new Substance_SynonymRepository(dataContex);
        }

        public static Substance_EntityRepository CreateSubstance_EntityRepo()
        {
            var dataContex = new ChemDBEntities();

            return new Substance_EntityRepository(dataContex);
        }

        public static Substance_GuideRepository CreateSubstance_GuideRepo()
        {
            var dataContex = new ChemDBEntities();

            return new Substance_GuideRepository(dataContex);
        }

        public static GuideRepository CreateGuideRepo()
        {
            var dataContex = new ChemDBEntities();

            return new GuideRepository(dataContex);
        }
    }
}
