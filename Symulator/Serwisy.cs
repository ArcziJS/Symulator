using Oracle.ManagedDataAccess.Client;

namespace Symulator
{
    internal class Serwisy
    {
        public Serwisy(OracleConnection connection, int rekordy)
        {

            #region Serwisy

            string idSerwisy = "select max(id_serwisu) from Serwisy";
            string maxIdSerwisy = "";
            OracleCommand GetMaxIdSerwisy = connection.CreateCommand();
            GetMaxIdSerwisy.CommandText = idSerwisy;

            OracleDataReader readerSerwisy = GetMaxIdSerwisy.ExecuteReader();
            while (readerSerwisy.Read())
            {
                maxIdSerwisy = readerSerwisy[0].ToString();
            }
            readerSerwisy.Close();

            #endregion

            #region Adresy
            string idAdresy = "select max(id_adresu) from adresy";
            string maxIdAdresy = "";
            OracleCommand GetMaxIdAdresy = connection.CreateCommand();
            GetMaxIdAdresy.CommandText = idAdresy;

            OracleDataReader readerAdresy = GetMaxIdAdresy.ExecuteReader();
            while (readerAdresy.Read())
            {
                maxIdAdresy = readerAdresy[0].ToString();
            }
            readerAdresy.Close();

            #endregion


            Console.WriteLine("Dodawanie rekordów:");

            Random rnd = new Random();
            for (int i = 1; i <= rekordy; i++)
            {
                int nextIdSerwisy = Convert.ToInt32(maxIdSerwisy) + i;
                int nextIdAdresy = rnd.Next(1,Convert.ToInt32(maxIdAdresy));
                int randomNumerTelefonuu = rnd.Next(100000000, 999999999);

                string query = "INSERT into serwisy (id_serwisu, adres, nr_telefonu, adresy_id_adresu) VALUES (" + nextIdSerwisy + "," + nextIdAdresy + "," + randomNumerTelefonuu + "," + nextIdAdresy + ")";

                OracleCommand AddSerwisy = connection.CreateCommand();
                AddSerwisy.CommandText = query;
                AddSerwisy.ExecuteNonQuery();
                Console.WriteLine("Dodano rekord.");
            }
            connection.Close();
        }
    }
}
