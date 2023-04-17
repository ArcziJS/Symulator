using Oracle.ManagedDataAccess.Client;
using Symulator.Generators;
using Symulator.Selectors;

namespace Symulator.Inserters
{
    internal class Marki : OracleDBConnector
    {
        public Marki(int rekordy)
        {
            int maxIdMarki = MaxIdMarki.GetMaxIdMarki();

            Console.WriteLine("\nDodawanie Marek:");

            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            for (int i = 1; i <= rekordy; i++)
            {
                int nextIdMarki = maxIdMarki + i;
                string randomMarka = GeneratorMarek.WybierzMarke();

                string query = "INSERT into Marki " +
                    "(id_marki, marka)" +
                    "Values" +
                    "(" + nextIdMarki + ", :marka)";

                OracleCommand AddMarki = GetConnection().CreateCommand();
                AddMarki.CommandText = query;
                AddMarki.Parameters.Add(":marka", randomMarka);
                AddMarki.ExecuteNonQuery();

                string executedQuery = AddMarki.CommandText;
                foreach (OracleParameter param in AddMarki.Parameters)
                {
                    executedQuery = executedQuery.Replace(param.ParameterName, $"'{param.Value}'");
                }
                executedQuery += ";";


                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "AddMarki.txt"), true))
                {
                    outputFile.WriteLine(executedQuery);
                }
            }

            Console.Write("Dodano ");
            Console.Write(rekordy);
            Console.Write(" Marek.\n");
        }
    }
}

