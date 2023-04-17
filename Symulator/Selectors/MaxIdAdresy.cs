using Oracle.ManagedDataAccess.Client;

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
