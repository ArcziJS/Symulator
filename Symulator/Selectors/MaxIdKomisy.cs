using Oracle.ManagedDataAccess.Client;

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
