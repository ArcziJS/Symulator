using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Symulator.Selectors
{
    internal class MaxIdKomisy : OracleDBConnector
    {
        public static int GetMaxIdKomisy()
        {
            string idKomisy = "select max(id_komisu) from komisy";
            int maxIdKomisy = 0;
            OracleCommand GetMaxIdKomisy = GetConnection().CreateCommand();
            GetMaxIdKomisy.CommandText = idKomisy;

            OracleDataReader readerKomisy = GetMaxIdKomisy.ExecuteReader();
            while (readerKomisy.Read())
            {
                maxIdKomisy = Convert.ToInt32(readerKomisy[0]);
            }
            readerKomisy.Close();

            return maxIdKomisy;
        }
    }
}
