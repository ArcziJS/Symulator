using Oracle.ManagedDataAccess.Client;

namespace Symulator
{
    internal class Adresy
    {
        public Adresy(int rekordy)
        {
            Console.WriteLine("Connecting to db...");
            string connectionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=217.173.198.135)(PORT=1521)))(CONNECT_DATA=(Service_name=tpdb)));User ID=s101700;Password=s101700;";
            OracleConnection connection = new OracleConnection(connectionString);
            connection.Open();
            Console.WriteLine("Connected!");

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

            #region Komisy
            string idKomisy = "select max(id_komisu) from komisy";
            string maxIdKomisy = "";
            OracleCommand GetMaxIdKomisy = connection.CreateCommand();
            GetMaxIdKomisy.CommandText = idKomisy;

            OracleDataReader readerKomisy = GetMaxIdKomisy.ExecuteReader();
            while (readerKomisy.Read())
            {
                maxIdKomisy = readerKomisy[0].ToString();
            }
            readerKomisy.Close();

            #endregion


            Console.WriteLine("Dodawanie rekordów:");

            Random rnd = new Random();
            for (int i = 0; i < rekordy; i++)
            {
                int nextIdAdresy = Convert.ToInt32(maxIdAdresy) + i;
                string randomMiasto;
                string randomUlica;
                int randomNumerDomu = rnd.Next(1, 999);
                int randomNumerMieszkania = rnd.Next(1, 99);
                string randomKodPocztowy = rnd.Next(10, 99) + "-" + rnd.Next(100, 999);
                int randomIdKomisy = rnd.Next(1, Convert.ToInt32(maxIdKomisy) + 1);

                string query = "INSERT into Adresy (id_adresu, miasto, ulica, nr_domu, nr_mieszkania, kod_pocztowy, komisy_id_komisu) Values (" + nextIdAdresy + "," + randomMiasto + ", " + randomUlica + ", " + randomNumerDomu + ", " + randomNumerMieszkania + "," + randomKodPocztowy + "," + randomIdKomisy + ");";

                OracleCommand AddAdresy = connection.CreateCommand();
                AddAdresy.CommandText = query;
                AddAdresy.ExecuteNonQuery();
                Console.WriteLine("Dodano rekord.");
            }
            connection.Close();
        }
    }
}