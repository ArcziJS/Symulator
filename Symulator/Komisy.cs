using Oracle.ManagedDataAccess.Client;

namespace Symulator
{
    internal class Komisy
    {
        public Komisy(OracleConnection connection, int rekordy)
        {

            #region Komisy

            string idKomisy = "select max(id_komisu) from komisy";
            int maxIdKomisy = 1;
            OracleCommand GetMaxIdKomisy = connection.CreateCommand();
            GetMaxIdKomisy.CommandText = idKomisy;

            OracleDataReader readerKomisy = GetMaxIdKomisy.ExecuteReader();
            while (readerKomisy.Read())
            {
                maxIdKomisy = Convert.ToInt32(readerKomisy[0]);
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
            for (int i = 1; i <= rekordy; i++)
            {
                int nextIdKomisy = maxIdKomisy + i;
                int randomIdSprzedawcy = rnd.Next(1, Convert.ToInt32(maxIdSprzedawcy) + 1);
                int randomIdPojazdy = rnd.Next(1, Convert.ToInt32(maxIdPojazdy) + 1);
                int randomIdAdresy = rnd.Next(1, Convert.ToInt32(maxIdAdresy) + 1);

                string query = "INSERT into Komisy (id_komisu, sprzedawcy, pojazdy, adres) Values (" + nextIdKomisy + "," + randomIdSprzedawcy + "," + randomIdPojazdy + "," + randomIdAdresy + ")";

                OracleCommand AddKomisy = connection.CreateCommand();
                AddKomisy.CommandText = query;
                AddKomisy.ExecuteNonQuery();

                Console.WriteLine("Dodano rekord.");
            }







            connection.Close();
        }
    }
}
