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

            Console.WriteLine("\nDodawanie Serwisów:");

            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            Random rnd = new Random();
            for (int i = 1; i <= rekordy; i++)
            {
                int nextIdSerwisy = maxIdSerwisy + i;
                int nextIdAdresy = rnd.Next(1, maxIdAdresy + 1);
                int randomNumerTelefonu = rnd.Next(100000000, 999999999);

                string query = "INSERT into serwisy " +
                    "(id_serwisu, adres, nr_telefonu, adresy_id_adresu)" +
                    " VALUES " +
                    "(" + nextIdSerwisy + "," + nextIdAdresy + "," + randomNumerTelefonu + "," + nextIdAdresy + ")";

                OracleCommand AddSerwisy = GetConnection().CreateCommand();
                AddSerwisy.CommandText = query;
                AddSerwisy.ExecuteNonQuery();

                string executedQuery = AddSerwisy.CommandText;
                foreach (OracleParameter param in AddSerwisy.Parameters)
                {
                    executedQuery = executedQuery.Replace(param.ParameterName, $"'{param.Value}'");
                }
                executedQuery += ";";


                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "AddSerwisy.txt"), true))
                {
                    outputFile.WriteLine(executedQuery);
                }
            }

            Console.Write("Dodano ");
            Console.Write(rekordy);
            Console.Write(" Serwisów.\n");
        }
    }
}
