using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Symulator.Selectors
{
    internal class MaxIdPojazdy : OracleDBConnector
    {
        public static int GetMaxIdPojazdy()
        {
            string idPojazdy = "select max(id_pojazdu) from Pojazdy";
            int maxIdPojazdy = 0;
            OracleCommand GetMaxIdPojazdy = GetConnection().CreateCommand();
            GetMaxIdPojazdy.CommandText = idPojazdy;

            OracleDataReader readerPojazdy = GetMaxIdPojazdy.ExecuteReader();
            while (readerPojazdy.Read())
            {
                maxIdPojazdy = Convert.ToInt32(readerPojazdy[0]);
            }
            readerPojazdy.Close();

            return maxIdPojazdy;
        }
    }
}
