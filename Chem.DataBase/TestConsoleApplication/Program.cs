using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chem.DataBase;
using Chem.DataBase.Repository;
using System.IO;

namespace TestConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //AppDomain.CurrentDomain.SetData("DataDirectory", Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData));

            var dataContex = new ChemDBEntities();

            var entityRepo = new EntityRepository(dataContex);
            var subsRepo = new SubstanceRepository(dataContex);

            foreach (var item in subsRepo.GetAll())
            {
                Console.WriteLine(item.ProductName);
            }

            //entityRepo.Add(new Entity() { Id = Guid.NewGuid(), Name = "IGA1", Address = "La coronela", Coord_x = 19, Coord_y = 72, Email = "ceo@iga.cu", Fax = 1222, Organization = "AMA", Town = "La Habana" });
            //entityRepo.SubmitChanges();
            //var txt = File.CreateText("test");
            //for (int i = 0; i < 10; i++)
            //{
            //    txt.WriteLine(Guid.NewGuid());
            //}
            //txt.Close();

            //ExcelDB excelDB = new ExcelDB("Bases de datos GPQ.xlsx");
            //excelDB.MigrateSubstance();


            Console.WriteLine("Todo ok");
            Console.ReadLine();
        }
    }
}
