using Oracle.ManagedDataAccess.Client;
using Symulator.Selectors;

namespace Symulator.Inserters
{
    internal class Umowy : OracleDBConnector
    {
        public Umowy(int rekordy)
        {
            int maxIdUmowy = MaxIdUmowy.GetMaxIdUmowy();
            int maxIdSprzedawcy = MaxIdSprzedawcy.GetMaxIdSprzedawcy();
            int maxIdKlienci = MaxIdKlienci.GetMaxIdKlienci();
            int maxIdPojazdy = MaxIdPojazdy.GetMaxIdPojazdy();
            int maxIdKomisy = MaxIdKomisy.GetMaxIdKomisy();

            Console.WriteLine("\nDodawanie Umów:");

            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            Random random = new Random();
            for (int i = 1; i <= rekordy; i++)
            {
                int nextIdUmowy = maxIdUmowy + i;
                int randomSprzedawca = random.Next(1, maxIdSprzedawcy + 1);
                int randomKlient = random.Next(1, maxIdKlienci + 1);
                int randomPojazd = maxIdPojazdy + 1;
                DateTime dateTime = DateTime.Today;
                int randomIdKomisy = random.Next(1, maxIdKomisy + 1);



                string query = "INSERT into Umowy " +
                    "(id_umowy, sprzedawca, klient, pojazd, data_i_godzina, komis, komisy_id_komisu, pojazdy_archiwum_id_pojazdu, klienci_id_klienta, sprzedawcy_id_sprzedawcy)" +
                    "Values" +
                    "(" + nextIdUmowy + ", " + randomSprzedawca + ", " + randomKlient + ", " + randomPojazd + ", :data , " + randomIdKomisy + ", " + randomIdKomisy + ", " + randomPojazd + ", " + randomKlient + ", " + randomSprzedawca + ") ";

                using (OracleCommand AddUmowy = GetConnection().CreateCommand())
                {
                    AddUmowy.CommandText = query;
                    AddUmowy.Parameters.Add(":data", dateTime);
                    AddUmowy.ExecuteNonQuery();

                    string executedQuery = AddUmowy.CommandText;
                    foreach (OracleParameter param in AddUmowy.Parameters)
                    {
                        executedQuery = executedQuery.Replace(param.ParameterName, $"'{param.Value}'");
                    }
                    executedQuery += ";";


                    using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "AddUmowy.txt"), true))
                    {
                        outputFile.WriteLine(executedQuery);
                    }
                }
            }
            Console.Write("Dodano ");
            Console.Write(rekordy);
            Console.Write(" Umów.\n");
        }
    }
}
