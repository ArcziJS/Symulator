using Oracle.ManagedDataAccess.Client;

namespace Symulator
{
    internal class Serwisy
    {
        public Serwisy(int rekordy)
        {
            Console.WriteLine("Connecting to db...");
            string connectionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=217.173.198.135)(PORT=1521)))(CONNECT_DATA=(Service_name=tpdb)));User ID=s101700;Password=s101700;";
            OracleConnection connection = new OracleConnection(connectionString);
            connection.Open();
            Console.WriteLine("Connected!");

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
            for (int i = 0; i < rekordy; i++)
            {
                int nextIdSerwisy = Convert.ToInt32(maxIdSerwisy) + ++i;
                int nextIdAdresy = rnd.Next(Convert.ToInt32(maxIdAdresy) + i, Convert.ToInt32(maxIdAdresy) + rekordy);
                int randomNumerTelefonuu = rnd.Next(1000000000, 999999999);

                string query = "INSERT into serwisy (id_serwisu, adres, nr_telefonu, Serwisy_id_adresu) VALUES ("+nextIdSerwisy+","+nextIdAdresy+","+randomNumerTelefonuu+ ","+nextIdAdresy+");";

                OracleCommand AddSerwisy = connection.CreateCommand();
                AddSerwisy.CommandText = query;
                AddSerwisy.ExecuteNonQuery();
                Console.WriteLine("Dodano rekord.");
            }
            connection.Close();
        }
    }
}
