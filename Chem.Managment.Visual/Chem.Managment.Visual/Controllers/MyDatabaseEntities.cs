using Chem.DataBase;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chem.Managment.Visual.Controllers
{
    public class MyDatabaseEntities : ChemDBEntities
    {
        public MyDatabaseEntities()
        {
            // Initialize the connection string builder for the 
            // underlying provider.
             EntityConnectionStringBuilder sqlBuilder =
                new  EntityConnectionStringBuilder();
            sqlBuilder.ConnectionString = GetConnectionString();
            base.Database.Connection.ConnectionString = sqlBuilder.ProviderConnectionString;
        }

        public static string GetConnectionString()
        {
            var conStr = System.Configuration.ConfigurationManager.ConnectionStrings["ChemDBEntities"].ConnectionString;
            return conStr.Replace("%APPDATA%",
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
        }
    }
}
