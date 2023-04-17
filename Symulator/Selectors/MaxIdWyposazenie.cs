using Oracle.ManagedDataAccess.Client;

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
