using Oracle.ManagedDataAccess.Client;

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
