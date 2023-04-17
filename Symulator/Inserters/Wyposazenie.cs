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

            Console.WriteLine("\nDodawanie Elementów Wyposażenia:");

            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            for (int i = 1; i <= rekordy; i++)
            {
                int nextIdWyposazenie = maxIdWyposazenie + i;
                string randomWyposazenie = GeneratorWyposazenia.WybierzElementWyposazenia();

                string query = "INSERT into Wyposazenie " +
                    "(id_wyposazenia, element) " +
                    "Values" +
                    "(" + nextIdWyposazenie + ", :element)";

                OracleCommand AddWyposazenie = GetConnection().CreateCommand();
                AddWyposazenie.CommandText = query;
                AddWyposazenie.Parameters.Add("element", randomWyposazenie);
                AddWyposazenie.ExecuteNonQuery();

                string executedQuery = AddWyposazenie.CommandText;
                foreach (OracleParameter param in AddWyposazenie.Parameters)
                {
                    executedQuery = executedQuery.Replace(param.ParameterName, $"'{param.Value}'");
                }
                executedQuery += ";";


                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "AddWyposazenie.txt"), true))
                {
                    outputFile.WriteLine(executedQuery);
                }
            }

            Console.Write("Dodano ");
            Console.Write(rekordy);
            Console.Write(" Elementów Wyposażenia.\n");
        }
    }
}
