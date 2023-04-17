using Oracle.ManagedDataAccess.Client;

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
