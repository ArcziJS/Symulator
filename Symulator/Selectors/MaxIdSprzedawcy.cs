using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Symulator.Selectors
{
    internal class MaxIdSprzedawcy : OracleDBConnector
    {
        public static int GetMaxIdSprzedawcy()
        {
            string idSprzedawcy = "select max(id_sprzedawcy) from sprzedawcy";
            int maxIdSprzedawcy = 0;
            OracleCommand GetMaxIdSprzedawcy = GetConnection().CreateCommand();
            GetMaxIdSprzedawcy.CommandText = idSprzedawcy;

            OracleDataReader readerSprzedawcy = GetMaxIdSprzedawcy.ExecuteReader();
            while (readerSprzedawcy.Read())
            {
                maxIdSprzedawcy = Convert.ToInt32(readerSprzedawcy[0]);
            }
            readerSprzedawcy.Close();

            return maxIdSprzedawcy;
        }
    }
}
