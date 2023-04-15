namespace Symulator
{
    internal class Miasta
    {
        string[] miasta = { "Warszawa", "Kraków", "Opole", "Poznań", "Katowice" };

        public string WybierzMiasto()
        {
            Random random = new Random();
            return miasta[random.Next(miasta.Length)];
        }
    }
}
