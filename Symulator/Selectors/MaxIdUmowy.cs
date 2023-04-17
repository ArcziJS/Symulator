using Oracle.ManagedDataAccess.Client;

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
