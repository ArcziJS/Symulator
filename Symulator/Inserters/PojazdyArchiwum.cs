using Oracle.ManagedDataAccess.Client;
using Symulator.Generators;
using Symulator.Selectors;

namespace Symulator.Inserters
{
    internal class PojazdyArchiwum : OracleDBConnector
    {
        public PojazdyArchiwum(int rekordy)
        {
            int maxIdPojazdy = MaxIdPojazdyArchiwum.GetMaxIdPojazdyArchiwum();
            int maxIdKomisy = MaxIdKomisy.GetMaxIdKomisy();
            int maxIdMarki = MaxIdMarki.GetMaxIdMarki();
            int maxIdWyposazenie = MaxIdWyposazenie.GetMaxIdWyposazenie();
            int maxIdUmowy = MaxIdUmowy.GetMaxIdUmowy();

            Console.WriteLine("\nDodawanie Pojazdy-Archiwum:");

            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            Random random = new Random();
            for (int i = 1; i <= rekordy; i++)
            {
                int nextIdPojazdy = maxIdPojazdy + i;
                string randomMarka = GeneratorMarek.WybierzMarke();
                string randomModel = GeneratorModeli.WybierzModel();
                string randomKolor = GeneratorKolorow.WybierzKolor();
                int randomRokProdukcji = random.Next(2000, 2023);
                string randomVIN = GeneratorVIN.WygenerujVIN();
                int randomPrzebieg = random.Next(10000, 250000);
                int randomWyposazenie = random.Next(1, maxIdWyposazenie + 1);
                int randomPojemnosc = random.Next(1000, 5000);
                int randomKonieMechaniczne = random.Next(100, 400);
                int randomMomentObrotowy = random.Next(180, 660);
                int randomIdMarki = random.Next(1, maxIdMarki + 1);
                int randomIdKomisy = random.Next(1, maxIdKomisy + 1);
                int randomIdUmowy = random.Next(1, maxIdUmowy + 1);

                string query = "INSERT into \"Pojazdy-Archiwum\" " +
                    "(id_pojazdu, marka, model, kolor, rok_produkcji, VIN, przebieg, wyposazenie, pojemnosc, km, nm, marki_id_marki, komisy_id_komisu, umowy_id_umowy)" +
                    "Values" +
                    "(" + nextIdPojazdy + ", :randomMarka, :randomModel, :randomKolor," + randomRokProdukcji + ", :randomVIN, " + randomPrzebieg + "," + randomWyposazenie + ", " + randomPojemnosc + ", " + randomKonieMechaniczne + ", " + randomMomentObrotowy + ", " + randomIdMarki + ", " + randomIdKomisy + "," + randomIdUmowy + ")";

                using (OracleCommand AddPojazdy = GetConnection().CreateCommand())
                {
                    AddPojazdy.CommandText = query;
                    AddPojazdy.Parameters.Add(":randomMarka", randomMarka);
                    AddPojazdy.Parameters.Add(":randomModel", randomModel);
                    AddPojazdy.Parameters.Add(":randomKolor", randomKolor);
                    AddPojazdy.Parameters.Add(":randomVIN", randomVIN);
                    AddPojazdy.ExecuteNonQuery();

                    string executedQuery = AddPojazdy.CommandText;
                    foreach (OracleParameter param in AddPojazdy.Parameters)
                    {
                        executedQuery = executedQuery.Replace(param.ParameterName, $"'{param.Value}'");
                    }
                    executedQuery += ";";


                    using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "AddPojazdyArchiwum.txt"), true))
                    {
                        outputFile.WriteLine(executedQuery);
                    }
                }
            }
            Console.Write("Dodano ");
            Console.Write(rekordy);
            Console.Write(" Pojazdy-Archiwum.\n");
        }
    }
}
