using Oracle.ManagedDataAccess.Client;

namespace Symulator
{
    internal class Sprzedawcy
    {
        Imiona Imiona = new Imiona();
        Nazwiska Nazwiska = new Nazwiska();
        public Sprzedawcy(OracleConnection connection, int rekordy)
        {

            #region Sprzedawcy

            string idSprzedawcy = "select max(id_sprzedawcy) from Sprzedawcy";
            int maxIdSprzedawcy = 0;
            OracleCommand GetMaxIdSprzedawcy = connection.CreateCommand();
            GetMaxIdSprzedawcy.CommandText = idSprzedawcy;

            OracleDataReader readerSprzedawcy = GetMaxIdSprzedawcy.ExecuteReader();
            while (readerSprzedawcy.Read())
            {
                maxIdSprzedawcy = Convert.ToInt32(readerSprzedawcy[0]);
            }
            readerSprzedawcy.Close();

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
            for (int i = 1; i <= rekordy; i++)
            {
                int nextIdSprzedawcy = maxIdSprzedawcy + i;
                string randomImie = Imiona.WybierzImie();
                string randomNazwisko = Nazwiska.WybierzNazwisko();
                string randomPESEL = rnd.Next(100000,999999).ToString()+rnd.Next(10000,99999).ToString();
                int randomIdKomisy = rnd.Next(1, Convert.ToInt32(maxIdKomisy) + 1);

                string query = "INSERT into Sprzedawcy (id_sprzedawcy, imie, nazwisko, PESEL, komisy_id_komisu)Values(" + nextIdSprzedawcy + ", :randomImie, :randomNazwisko, :randomPESEL ," + randomIdKomisy + ")";

                using (OracleCommand AddSprzedawcy = connection.CreateCommand())
                {
                    AddSprzedawcy.CommandText = query;
                    AddSprzedawcy.Parameters.Add("randomImie", randomImie);
                    AddSprzedawcy.Parameters.Add("randomNazwisko", randomNazwisko);
                    AddSprzedawcy.Parameters.Add("randomPESEL", randomPESEL);
                    AddSprzedawcy.ExecuteNonQuery();
                    Console.WriteLine("Dodano rekord.");
                }

            }
            connection.Close();
        }
    }
}

