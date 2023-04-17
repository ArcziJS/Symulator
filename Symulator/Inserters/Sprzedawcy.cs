using Oracle.ManagedDataAccess.Client;
using Symulator.Generators;
using Symulator.Selectors;

namespace Symulator.Inserters
{
    internal class Sprzedawcy : OracleDBConnector
    {
        public Sprzedawcy(int rekordy)
        {
            int maxIdSprzedawcy = MaxIdSprzedawcy.GetMaxIdSprzedawcy();
            int maxIdKomisy = MaxIdKomisy.GetMaxIdKomisy();

            Console.WriteLine("\nDodawanie Sprzedawców:");

            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            Random random = new Random();
            for (int i = 1; i <= rekordy; i++)
            {
                int nextIdSprzedawcy = maxIdSprzedawcy + i;
                string randomImie = GeneratorImion.WybierzImie();
                string randomNazwisko = GeneratorNazwisk.WybierzNazwisko();
                string randomPESEL = GeneratorPESEL.WygenerujPESEL();
                int randomIdKomisy = random.Next(1, maxIdKomisy + 1);

                string query = "INSERT into Sprzedawcy " +
                    "(id_sprzedawcy, imie, nazwisko, PESEL, komisy_id_komisu)" +
                    "Values" +
                    "(" + nextIdSprzedawcy + ", :randomImie, :randomNazwisko, :randomPESEL ," + randomIdKomisy + ")";

                using (OracleCommand AddSprzedawcy = GetConnection().CreateCommand())
                {
                    AddSprzedawcy.CommandText = query;
                    AddSprzedawcy.Parameters.Add(":randomImie", randomImie);
                    AddSprzedawcy.Parameters.Add(":randomNazwisko", randomNazwisko);
                    AddSprzedawcy.Parameters.Add(":randomPESEL", randomPESEL);
                    AddSprzedawcy.ExecuteNonQuery();

                    string executedQuery = AddSprzedawcy.CommandText;
                    foreach (OracleParameter param in AddSprzedawcy.Parameters)
                    {
                        executedQuery = executedQuery.Replace(param.ParameterName, $"'{param.Value}'");
                    }
                    executedQuery += ";";


                    using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "AddSprzedawcy.txt"), true))
                    {
                        outputFile.WriteLine(executedQuery);
                    }
                }
            }
            Console.Write("Dodano ");
            Console.Write(rekordy);
            Console.Write(" Sprzedawców.\n");
        }
    }
}

