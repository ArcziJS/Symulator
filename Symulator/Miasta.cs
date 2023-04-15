namespace Symulator
{
    internal class Miasta
    {
        string[] miasta = 
            {
                "Warszawa", "Kraków", "Gdańsk", "Poznań", "Wrocław", "Łódź", "Katowice", "Szczecin",
                "Bydgoszcz", "Gdynia", "Toruń", "Zakopane", "Krynica-Zdrój", "Kołobrzeg", "Sopot",
                "Zamość", "Zielona Góra", "Białystok", "Olsztyn", "Kielce"
            };



        public string WybierzMiasto()
        {
            Random random = new Random();
            return miasta[random.Next(miasta.Length)];
        }
    }
}
