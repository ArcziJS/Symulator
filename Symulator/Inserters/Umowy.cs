using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using Symulator.Selectors;

namespace Symulator.Inserters
{
    internal class Umowy : OracleDBConnector
    {
        public Umowy(int rekordy)
        {
            int maxIdUmowy = MaxIdUmowy.GetMaxIdUmowy();
            int maxIdSprzedawcy = MaxIdSprzedawcy.GetMaxIdSprzedawcy();
            int maxIdKlienci = MaxIdKlienci.GetMaxIdKlienci();
            int maxIdPojazdy = MaxIdPojazdy.GetMaxIdPojazdy();
            int maxIdKomisy = MaxIdKomisy.GetMaxIdKomisy();

            Console.WriteLine("Dodawanie rekordów:");

            Random rnd = new Random();
            for (int i = 1; i <= rekordy; i++)
            {
                PojazdyArchiwum PojazdyArchiwum = new PojazdyArchiwum(1);

                int nextIdUmowy = maxIdUmowy + i;
                int randomSprzedawca = rnd.Next(1, maxIdSprzedawcy + 1);
                int randomKlient = rnd.Next(1, maxIdKlienci + 1);
                int randomPojazd = maxIdPojazdy + 1;
                DateTime dateTime = DateTime.Now;
                int randomIdKomisy = rnd.Next(1, maxIdKomisy + 1);



                string query = "INSERT into Umowy " +
                    "(id_umowy, sprzedawca, klient, pojazd, data_i_godzina, komis, komisy_id_komisu, pojazdy_archiwum_id_pojazdu, klienci_id_klienta, sprzedawcy_id_sprzedawcy)" +
                    "Values" +
                    "(" + nextIdUmowy + ", " + randomSprzedawca + ", " + randomKlient + ", " + randomPojazd + ", :data , " + randomIdKomisy + ", " + randomIdKomisy + ", " + randomPojazd + ", " + randomKlient + ", " + randomSprzedawca + ") ";

                using (OracleCommand AddUmowy = GetConnection().CreateCommand())
                {
                    AddUmowy.CommandText = query;
                    AddUmowy.Parameters.Add("data", dateTime);
                    AddUmowy.ExecuteNonQuery();
                    Console.WriteLine("Dodano rekord.");
                }

            }
        }
    }
}
