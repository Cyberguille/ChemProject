using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImporterExcelData
{
    public class ExcelDB
    {
        public Table LoadExcelFile(string path)
        {

            // Load Excel file.
            var workbook = Codaxy.Xlio.Workbook.Load(path);

            // Select active worksheet from the file.
            var worksheet = workbook.Sheets.First();
            // Extract the data from the worksheet to newly created DataTable starting at 
            // first row and first column for 10 rows or until the first empty row appears.
            var excel = new Dictionary<string, List<string>>();
            Table table = new Table() { Header = new List<string>(), Data = new List<Row>() };
           
            foreach (var item in worksheet.Data)
            {
                Row row = new Row() { RowNumber = item.Key, CellData = new List<string>() };
                int col=0;
                foreach (var item1 in item.Value)
                {
                    if (item.Key == 0)
                        table.Header.Add(item1.Value.Value.ToString());
                    else 
                    {
                        if(col<item1.Key)
                            FillRow(row,item1.Key-col);
                        row.CellData.Add(item1.Value.Value.ToString());
                        col++;
                    }
                        
                }

                if (item.Key != 0)
                    table.Data.Add(row);
            }
            return table;
        }

        private void FillRow(Row row, int count)
        {
            for (int i = 0; i < count; i++)
            {
                row.CellData.Add(string.Empty);
            }
        }
    }
}
