using Oracle.ManagedDataAccess.Client;

namespace Symulator
{
    internal class Adresy
    {
        Miasta Miasto = new Miasta();
        Ulice Ulica = new Ulice();
        public Adresy(OracleConnection connection, int rekordy)
        {

            #region Adresy

            string idAdresy = "select max(id_adresu) from adresy";
            int maxIdAdresy = 0;
            OracleCommand GetMaxIdAdresy = connection.CreateCommand();
            GetMaxIdAdresy.CommandText = idAdresy;

            OracleDataReader readerAdresy = GetMaxIdAdresy.ExecuteReader();
            while (readerAdresy.Read())
            {
                maxIdAdresy = Convert.ToInt32(readerAdresy[0]);
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
            for (int i = 1; i <= rekordy; i++)
            {
                int nextIdAdresy = maxIdAdresy + i;
                string randomMiasto = Miasto.WybierzMiasto();
                string randomUlica = Ulica.WybierzUlice();
                int randomNumerDomu = rnd.Next(1, 999);
                int randomNumerMieszkania = rnd.Next(1, 99);
                string randomKodPocztowy = rnd.Next(10, 99) + "-" + rnd.Next(100, 999);
                int randomIdKomisy = rnd.Next(1, Convert.ToInt32(maxIdKomisy) + 1);

                string query = "INSERT into Adresy (id_adresu, miasto, ulica, nr_domu, nr_mieszkania, kod_pocztowy, komisy_id_komisu) Values (" + nextIdAdresy + ",:randomMiasto, :randomUlica, " + randomNumerDomu + ", " + randomNumerMieszkania + ",:randomKodPocztowy," + randomIdKomisy + ")";

                using (OracleCommand AddAdresy = connection.CreateCommand())
                {
                    AddAdresy.CommandText = query;
                    AddAdresy.Parameters.Add("randomMiasto", randomMiasto);
                    AddAdresy.Parameters.Add("randomUlica", randomUlica);
                    AddAdresy.Parameters.Add("randomKodPocztowy", randomKodPocztowy);
                    AddAdresy.ExecuteNonQuery();
                    Console.WriteLine("Dodano rekord.");
                }

            }
            connection.Close();
        }
    }
}