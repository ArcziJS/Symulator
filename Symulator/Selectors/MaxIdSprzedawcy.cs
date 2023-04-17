using Oracle.ManagedDataAccess.Client;

namespace Symulator.Selectors
{
    internal class MaxIdSprzedawcy : OracleDBConnector
    {
        public static int GetMaxIdSprzedawcy()
        {
            string idSprzedawcy = "select max(id_sprzedawcy) from sprzedawcy";
            int maxIdSprzedawcy = 0;
            OracleCommand GetMaxIdSprzedawcy = GetConnection().CreateCommand();
            GetMaxIdSprzedawcy.CommandText = idSprzedawcy;

            OracleDataReader readerSprzedawcy = GetMaxIdSprzedawcy.ExecuteReader();
            while (readerSprzedawcy.Read())
            {
                maxIdSprzedawcy = Convert.ToInt32(readerSprzedawcy[0]);
            }
            readerSprzedawcy.Close();

            return maxIdSprzedawcy;
        }
    }
}
