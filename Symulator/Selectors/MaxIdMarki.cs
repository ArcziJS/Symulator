using Oracle.ManagedDataAccess.Client;

namespace Symulator.Selectors
{
    internal class MaxIdMarki : OracleDBConnector
    {
        public static int GetMaxIdMarki()
        {
            string idMarki = "select max(id_marki) from Marki";
            int maxIdMarki = 0;
            OracleCommand GetMaxIdMarki = GetConnection().CreateCommand();
            GetMaxIdMarki.CommandText = idMarki;

            OracleDataReader readerMarki = GetMaxIdMarki.ExecuteReader();
            while (readerMarki.Read())
            {
                maxIdMarki = Convert.ToInt32(readerMarki[0]);
            }
            readerMarki.Close();

            return maxIdMarki;
        }
    }
}
