using Oracle.ManagedDataAccess.Client;
using Symulator.Selectors;

namespace Symulator.Inserters
{
    internal class PojazdWyposazenie : OracleDBConnector
    {
        public PojazdWyposazenie(int rekordy)
        {

            int maxIdWyposazenie = MaxIdWyposazenie.GetMaxIdWyposazenie();
            int maxIdPojazdy = MaxIdPojazdy.GetMaxIdPojazdy();

            Console.WriteLine("Dodawanie rekordów:");
            Random random = new Random();
            for (int i = 1; i <= rekordy; i++)
            {
                int randomIdWyposazenie = random.Next(1, maxIdWyposazenie + 1);
                int randomIdPojazdu = random.Next(maxIdPojazdy + 1, maxIdPojazdy + i);

                string query = "INSERT into \"pojazd-wyposazenie\" " +
                    "(pojazdy_id_pojazdu, wyposazenie_id_wyposazenia)" +
                    "Values" +
                    "(" + randomIdPojazdu + ", " + randomIdWyposazenie + ") ";

                OracleCommand AddWyposazenie = GetConnection().CreateCommand();
                AddWyposazenie.CommandText = query;
                AddWyposazenie.ExecuteNonQuery();
                Console.WriteLine("Dodano rekord.");
            }
        }
    }
}
