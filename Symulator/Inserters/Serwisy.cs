using Oracle.ManagedDataAccess.Client;
using Symulator.Selectors;

namespace Symulator.Inserters
{
    internal class Serwisy : OracleDBConnector
    {
        public Serwisy(int rekordy)
        {
            int maxIdSerwisy = MaxIdSerwisy.GetMaxIdSerwisy();
            int maxIdAdresy = MaxIdAdresy.GetMaxIdAdresy();

            Console.WriteLine("Dodawanie rekordów:");

            Random rnd = new Random();
            for (int i = 1; i <= rekordy; i++)
            {
                int nextIdSerwisy = Convert.ToInt32(maxIdSerwisy) + i;
                int nextIdAdresy = rnd.Next(1, Convert.ToInt32(maxIdAdresy));
                int randomNumerTelefonu = rnd.Next(100000000, 999999999);

                string query = "INSERT into serwisy " +
                    "(id_serwisu, adres, nr_telefonu, adresy_id_adresu)" +
                    " VALUES " +
                    "(" + nextIdSerwisy + "," + nextIdAdresy + "," + randomNumerTelefonu + "," + nextIdAdresy + ")";

                OracleCommand AddSerwisy = GetConnection().CreateCommand();
                AddSerwisy.CommandText = query;
                AddSerwisy.ExecuteNonQuery();
                Console.WriteLine("Dodano rekord.");
            }
        }
    }
}
