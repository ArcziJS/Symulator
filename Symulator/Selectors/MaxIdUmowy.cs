using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symulator.Selectors
{
    internal class MaxIdUmowy : OracleDBConnector
    {
        public static int GetMaxIdUmowy()
        {
            string idUmowy = "select max(id_umowy) from Umowy";
            int maxIdUmowy = 0;
            OracleCommand GetMaxIdUmowy = GetConnection().CreateCommand();
            GetMaxIdUmowy.CommandText = idUmowy;

            OracleDataReader readerUmowy = GetMaxIdUmowy.ExecuteReader();
            while (readerUmowy.Read())
            {
                maxIdUmowy = Convert.ToInt32(readerUmowy[0]);
            }
            readerUmowy.Close();

            return maxIdUmowy;
        }
    }
}
