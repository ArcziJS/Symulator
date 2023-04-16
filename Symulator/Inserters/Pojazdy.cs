using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Oracle.ManagedDataAccess.Client;
using Symulator.Generators;
using Symulator.Selectors;

namespace Symulator.Inserters
{
    internal class Pojazdy : OracleDBConnector
    {
        public Pojazdy(int rekordy)
        {
            int maxIdPojazdy = MaxIdPojazdy.GetMaxIdPojazdy();
            int maxIdKomisy = MaxIdKomisy.GetMaxIdKomisy();
            int maxIdMarki = MaxIdMarki.GetMaxIdMarki();
            int maxIdWyposazenie = MaxIdWyposazenie.GetMaxIdWyposazenie();

            Console.WriteLine("Dodawanie rekordów:");

            Random random = new Random();
            for (int i = 1; i <= rekordy; i++)
            {
                int nextIdPojazdy = maxIdPojazdy + i;
                int randomMarka = random.Next(1, maxIdMarki);
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

                string query = "INSERT into Pojazdy " +
                    "(id_pojazdu, marka, model, kolor, rok_produkcji, VIN, przebieg, wyposazenie, pojemnosc, km, nm, marki_id_marki, komisy_id_komisu)" +
                    "Values" +
                    "(" + nextIdPojazdy + ", " + randomMarka + ", :randomModel, :randomKolor," + randomRokProdukcji + ", :randomVIN, " + randomPrzebieg + "," + randomWyposazenie + ", " + randomPojemnosc + ", " + randomKonieMechaniczne + ", " + randomMomentObrotowy + ", " + randomIdMarki + ", " + randomIdKomisy + ")";

                using (OracleCommand AddPojazdy = GetConnection().CreateCommand())
                {
                    AddPojazdy.CommandText = query;
                    //AddPojazdy.Parameters.Add("randomMarka", randomMarka);
                    AddPojazdy.Parameters.Add("randomModel", randomModel);
                    AddPojazdy.Parameters.Add("randomKolor", randomKolor);
                    AddPojazdy.Parameters.Add("randomVIN", randomVIN);
                    AddPojazdy.ExecuteNonQuery();
                    Console.WriteLine("Dodano rekord.");
                }

            }
        }
    }
}
