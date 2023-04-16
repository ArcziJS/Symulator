using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symulator.Selectors
{
    internal class MaxIdWyposazenie : OracleDBConnector
    {
        public static int GetMaxIdWyposazenie()
        {
            string idWyposazenie = "select max(id_wyposazenia) from Wyposazenie";
            int maxIdWyposazenie = 0;
            OracleCommand GetMaxIdWyposazenie = GetConnection().CreateCommand();
            GetMaxIdWyposazenie.CommandText = idWyposazenie;

            OracleDataReader readerWyposazenie = GetMaxIdWyposazenie.ExecuteReader();
            while (readerWyposazenie.Read())
            {
                maxIdWyposazenie = Convert.ToInt32(readerWyposazenie[0]);
            }
            readerWyposazenie.Close();

            return maxIdWyposazenie;
        }
    }
}
