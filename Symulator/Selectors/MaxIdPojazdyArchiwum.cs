using Oracle.ManagedDataAccess.Client;

namespace Symulator.Selectors
{
    internal class MaxIdPojazdyArchiwum : OracleDBConnector
    {
        public static int GetMaxIdPojazdyArchiwum()
        {
            string idPojazdyArchiwum = "select max(id_pojazdu) from \"Pojazdy-Archiwum\"";
            int maxIdPojazdyArchiwum = 0;
            OracleCommand GetMaxIdPojazdyArchiwum = GetConnection().CreateCommand();
            GetMaxIdPojazdyArchiwum.CommandText = idPojazdyArchiwum;

            OracleDataReader readerPojazdyArchiwum = GetMaxIdPojazdyArchiwum.ExecuteReader();
            while (readerPojazdyArchiwum.Read())
            {
                maxIdPojazdyArchiwum = Convert.ToInt32(readerPojazdyArchiwum[0]);
            }
            readerPojazdyArchiwum.Close();

            return maxIdPojazdyArchiwum;
        }
    }
}
