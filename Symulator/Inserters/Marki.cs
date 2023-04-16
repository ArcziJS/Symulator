using Oracle.ManagedDataAccess.Client;
using Symulator.Generators;
using Symulator.Selectors;
using System.Security.Cryptography.X509Certificates;

namespace Symulator.Inserters
{
    internal class Marki : OracleDBConnector
    {
        public Marki(int rekordy)
        {
            int maxIdMarki = MaxIdMarki.GetMaxIdMarki();

            Console.WriteLine("Dodawanie rekordów:");

            for (int i = 1; i <= rekordy; i++)
            {
                int nextIdMarki = maxIdMarki + i;
                string randomMarka = GeneratorMarek.WybierzMarke();

                string query = "INSERT into Marki (id_marki, marka) Values(" + nextIdMarki + ", :marka)";

                OracleCommand AddMarki = GetConnection().CreateCommand();
                AddMarki.CommandText = query;
                AddMarki.Parameters.Add("marka", randomMarka);
                AddMarki.ExecuteNonQuery();
                Console.WriteLine("Dodano rekord.");
            }
        }
    }
}

