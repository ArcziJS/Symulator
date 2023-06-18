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

            Console.WriteLine("\nDodawanie pojazd-wyposazenie:");

            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            Random random = new Random();
            for (int i = 1; i <= rekordy; i++)
            {
                int randomIdWyposazenie = random.Next(1, maxIdWyposazenie + 1);
                int randomIdPojazdu = random.Next(1, maxIdPojazdy + 1 );

                string query = "INSERT into \"pojazd-wyposazenie\" " +
                    "(pojazdy_id_pojazdu, wyposazenie_id_wyposazenia)" +
                    "Values" +
                    "(" + randomIdPojazdu + ", " + randomIdWyposazenie + ") ";

                OracleCommand AddWyposazenie = GetConnection().CreateCommand();
                AddWyposazenie.CommandText = query;
                AddWyposazenie.ExecuteNonQuery();

                string executedQuery = AddWyposazenie.CommandText;
                foreach (OracleParameter param in AddWyposazenie.Parameters)
                {
                    executedQuery = executedQuery.Replace(param.ParameterName, $"'{param.Value}'");
                }
                executedQuery += ";";


                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "AddPojazdWyposazenie.txt"), true))
                {
                    outputFile.WriteLine(executedQuery);
                }
            }

            Console.Write("Dodano ");
            Console.Write(rekordy);
            Console.Write(" pojazd-wyposazenie.\n");
        }
    }
}
