using Oracle.ManagedDataAccess.Client;

namespace Symulator
{
    internal class Marki
    {
        string[] marki =
            {
                "Abarth", "Alfa Romeo", "Aston Martin", "Audi", "Bentley", "BMW", "Bugatti", "Cadillac", "Chevrolet", "Chrysler",
                "Citroën", "Dacia", "Daewoo", "Daihatsu", "Dodge", "DS Automobiles", "Ferrari", "Fiat", "Ford", "Honda",
                "Hummer", "Hyundai", "Infiniti", "Jaguar", "Jeep", "Kia", "Lamborghini", "Lancia", "Land Rover", "Lexus",
                "Lotus", "Maserati", "Mazda", "Mercedes-Benz", "MG", "Mini", "Mitsubishi", "Nissan", "Opel", "Peugeot",
                "Porsche", "Renault", "Rolls-Royce", "Rover", "Saab", "Seat", "Škoda", "Smart", "SsangYong", "Subaru",
                "Suzuki", "Tesla", "Toyota", "Volkswagen", "Volvo"
            };


        public string WybierzMarke()
        {
            Random random = new Random();
            return marki[random.Next(marki.Length)];
        }
        public Marki(OracleConnection connection, int rekordy)
        {
            #region Marki

            string idMarki = "select max(id_marki) from Marki";
            string maxIdMarki = "";
            OracleCommand GetMaxIdMarki = connection.CreateCommand();
            GetMaxIdMarki.CommandText = idMarki;

            OracleDataReader readerMarki = GetMaxIdMarki.ExecuteReader();
            while (readerMarki.Read())
            {
                maxIdMarki = readerMarki[0].ToString();
            }
            readerMarki.Close();

            #endregion

            Console.WriteLine("Dodawanie rekordów:");

            Random rnd = new Random();
            for (int i = 1; i <= rekordy; i++)
            {
                int nextIdMarki = Convert.ToInt32(maxIdMarki) + i;
                string randomMarka = WybierzMarke();

                string query = "INSERT into Marki (id_marki, marka) Values(" + nextIdMarki + ", :marka)";

                OracleCommand AddMarki = connection.CreateCommand();
                AddMarki.CommandText = query;
                AddMarki.Parameters.Add("marka", randomMarka);
                AddMarki.ExecuteNonQuery();
                Console.WriteLine("Dodano rekord.");
            }
            connection.Close();
        }
    }
}

