using Oracle.ManagedDataAccess.Client;
using Symulator.Selectors;

namespace Symulator.Inserters
{
    internal class Komisy : OracleDBConnector
    {
        public Komisy(int rekordy)
        {
            int maxIdKomisy = MaxIdKomisy.GetMaxIdKomisy();
            int maxIdSprzedawcy = MaxIdSprzedawcy.GetMaxIdSprzedawcy();
            int maxIdPojazdy = MaxIdPojazdy.GetMaxIdPojazdy();
            int maxIdAdresy = MaxIdAdresy.GetMaxIdAdresy();

            Console.WriteLine("Dodawanie rekordów:");

            Random rnd = new Random();
            for (int i = 1; i <= rekordy; i++)
            {
                int nextIdKomisy = maxIdKomisy + i;
                int randomIdSprzedawcy = rnd.Next(1, Convert.ToInt32(maxIdSprzedawcy) + 1);
                int randomIdPojazdy = rnd.Next(1, maxIdPojazdy + 1);
                int randomIdAdresy = rnd.Next(1, Convert.ToInt32(maxIdAdresy) + 1);

                string query = "INSERT into Komisy (id_komisu, sprzedawcy, pojazdy, adres) Values (" + nextIdKomisy + "," + randomIdSprzedawcy + "," + randomIdPojazdy + "," + randomIdAdresy + ")";

                OracleCommand AddKomisy = GetConnection().CreateCommand();
                AddKomisy.CommandText = query;
                AddKomisy.ExecuteNonQuery();

                Console.WriteLine("Dodano rekord.");
            }
        }
    }
}
