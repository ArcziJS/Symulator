using Oracle.ManagedDataAccess.Client;
using Symulator.Generators;
using Symulator.Selectors;

namespace Symulator.Inserters
{
    internal class Wyposazenie : OracleDBConnector
    {
        public Wyposazenie(int rekordy)
        {
            int maxIdWyposazenie = MaxIdWyposazenie.GetMaxIdWyposazenie();

            Console.WriteLine("Dodawanie rekordów:");

            for (int i = 1; i <= rekordy; i++)
            {
                int nextIdWyposazenie = maxIdWyposazenie + i;
                string randomWyposazenie = GeneratorWyposazenia.WybierzElementWyposazenia();

                string query = "INSERT into Wyposazenie (id_wyposazenia, element) Values(" + nextIdWyposazenie + ", :element)";

                OracleCommand AddWyposazenie = GetConnection().CreateCommand();
                AddWyposazenie.CommandText = query;
                AddWyposazenie.Parameters.Add("element", randomWyposazenie);
                AddWyposazenie.ExecuteNonQuery();
                Console.WriteLine("Dodano rekord.");
            }
        }
    }
}
