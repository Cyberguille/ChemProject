using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImporterExcelData;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            ExcelDB excel = new ExcelDB();
            Table table = excel.LoadExcelFile("Bases de datos GPQ.xlsx");
            foreach (var item in table.Data)
            {
                for (int i = 0; i < table.Header.Count; i++)
                {
                    Console.WriteLine("{0}-->{1} ", table.Header[i],item.CellData[i]);
                }
            }
            Console.ReadLine();
        }
    }
}
