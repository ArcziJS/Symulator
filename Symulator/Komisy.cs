using Oracle.ManagedDataAccess.Client;

namespace Symulator
{
    internal class Komisy
    {
        public Komisy(int rekordy)
        {
            Console.WriteLine("Connecting to db...");
            string connectionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=217.173.198.135)(PORT=1521)))(CONNECT_DATA=(Service_name=tpdb)));User ID=s101700;Password=s101700;";
            OracleConnection connection = new OracleConnection(connectionString);
            connection.Open();
            Console.WriteLine("Connected!");





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

            #region Sprzedawcy
            string idSprzedawcy = "select max(id_sprzedawcy) from sprzedawcy";
            string maxIdSprzedawcy = "";
            OracleCommand GetMaxIdSprzedawcy = connection.CreateCommand();
            GetMaxIdSprzedawcy.CommandText = idSprzedawcy;

            OracleDataReader readerSprzedawcy = GetMaxIdSprzedawcy.ExecuteReader();
            while (readerSprzedawcy.Read())
            {
                maxIdSprzedawcy = readerSprzedawcy[0].ToString();
            }
            readerSprzedawcy.Close();

            #endregion

            #region Pojazdy

            string idPojazdy = "select max(id_pojazdu) from pojazdy";
            string maxIdPojazdy = "";
            OracleCommand GetMaxIdPojazdy = connection.CreateCommand();
            GetMaxIdPojazdy.CommandText = idPojazdy;

            OracleDataReader readerPojazdy = GetMaxIdPojazdy.ExecuteReader();
            while (readerPojazdy.Read())
            {
                maxIdPojazdy = readerPojazdy[0].ToString();
            }
            readerPojazdy.Close();

            #endregion

            #region Adresy

            string idAdresy = "select max(id_adresu) from adresy";
            string maxIdAdresy = "";
            OracleCommand GetMaxIdAresy = connection.CreateCommand();
            GetMaxIdAresy.CommandText = idAdresy;

            OracleDataReader readerAdresy = GetMaxIdAresy.ExecuteReader();
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
                int randomIdKomisy = rnd.Next(Convert.ToInt32(maxIdKomisy) + 1, Convert.ToInt32(maxIdKomisy) + rekordy);
                int randomIdSprzedawcy = rnd.Next(1, Convert.ToInt32(maxIdSprzedawcy) + 1);
                int randomIdPojazdy = rnd.Next(1, Convert.ToInt32(maxIdPojazdy) + 1);
                int randomIdAdresy = rnd.Next(1, Convert.ToInt32(maxIdAdresy) + 1);

                string query = "INSERT into Komisy (id_komisu, sprzedawcy, pojazdy, adres) Values (" + randomIdKomisy + "," + randomIdSprzedawcy + "," + randomIdPojazdy + "," + randomIdAdresy + ");";

                OracleCommand AddKomisy = connection.CreateCommand();
                AddKomisy.CommandText = query;
                AddKomisy.ExecuteNonQuery();

                Console.WriteLine("Dodano rekord.");
            }







            connection.Close();
        }
    }
}
