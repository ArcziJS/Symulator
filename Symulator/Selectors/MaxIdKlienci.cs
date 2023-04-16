using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symulator.Selectors
{
    internal class MaxIdKlienci : OracleDBConnector
    {
        public static int GetMaxIdKlienci()
        {
            string idKlienci = "select max(id_klienta) from Klienci";
            int maxIdKlienci = 0;
            OracleCommand GetMaxIdKlienci = GetConnection().CreateCommand();
            GetMaxIdKlienci.CommandText = idKlienci;

            OracleDataReader readerKlienci = GetMaxIdKlienci.ExecuteReader();
            while (readerKlienci.Read())
            {
                maxIdKlienci = Convert.ToInt32(readerKlienci[0]);
            }
            readerKlienci.Close();

            return maxIdKlienci;
        }
    }
}
