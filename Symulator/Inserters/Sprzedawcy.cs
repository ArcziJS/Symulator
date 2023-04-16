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

            Console.WriteLine("Dodawanie rekordów:");

            Random rnd = new Random();
            for (int i = 1; i <= rekordy; i++)
            {
                int nextIdSprzedawcy = maxIdSprzedawcy + i;
                string randomImie = GeneratorImion.WybierzImie();
                string randomNazwisko = GeneratorNazwisk.WybierzNazwisko();
                string randomPESEL = rnd.Next(100000, 999999).ToString() + rnd.Next(10000, 99999).ToString();
                int randomIdKomisy = rnd.Next(1, Convert.ToInt32(maxIdKomisy) + 1);

                string query = "INSERT into Sprzedawcy (id_sprzedawcy, imie, nazwisko, PESEL, komisy_id_komisu)Values(" + nextIdSprzedawcy + ", :randomImie, :randomNazwisko, :randomPESEL ," + randomIdKomisy + ")";

                using (OracleCommand AddSprzedawcy = GetConnection().CreateCommand())
                {
                    AddSprzedawcy.CommandText = query;
                    AddSprzedawcy.Parameters.Add("randomImie", randomImie);
                    AddSprzedawcy.Parameters.Add("randomNazwisko", randomNazwisko);
                    AddSprzedawcy.Parameters.Add("randomPESEL", randomPESEL);
                    AddSprzedawcy.ExecuteNonQuery();
                    Console.WriteLine("Dodano rekord.");
                }

            }
        }
    }
}

