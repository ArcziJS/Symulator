using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Symulator.Selectors
{
    internal class MaxIdSerwisy : OracleDBConnector
    {
        public static int GetMaxIdSerwisy()
        {
            string idSerwisy = "select max(id_serwisu) from Serwisy";
            int maxIdSerwisy = 0;
            OracleCommand GetMaxIdSerwisy = GetConnection().CreateCommand();
            GetMaxIdSerwisy.CommandText = idSerwisy;

            OracleDataReader readerSerwisy = GetMaxIdSerwisy.ExecuteReader();
            while (readerSerwisy.Read())
            {
                maxIdSerwisy = Convert.ToInt32(readerSerwisy[0]);
            }
            readerSerwisy.Close();

            return maxIdSerwisy;
        }
    }
}
