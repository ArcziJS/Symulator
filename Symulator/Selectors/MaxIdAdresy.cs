using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Symulator.Selectors
{
    internal class MaxIdAdresy : OracleDBConnector
    {
        public static int GetMaxIdAdresy()
        {
            string idAdresy = "select max(id_adresu) from adresy";
            int maxIdAdresy = 0;
            OracleCommand GetMaxIdAresy = GetConnection().CreateCommand();
            GetMaxIdAresy.CommandText = idAdresy;

            OracleDataReader readerAdresy = GetMaxIdAresy.ExecuteReader();
            while (readerAdresy.Read())
            {
                maxIdAdresy = Convert.ToInt32(readerAdresy[0]);
            }
            readerAdresy.Close();

            return maxIdAdresy;
        }
    }
}
