namespace Symulator.Generators
{
    internal class GeneratorKolorow
    {
        public static string WybierzKolor()
        {
            string[] kolory =
            {
                "Czarny", "Biały", "Srebrny", "Szary", "Czerwony", "Niebieski",
                "Zielony", "Brązowy", "Żółty", "Pomarańczowy"
            };
            Random random = new Random();
            return kolory[random.Next(kolory.Length)];
        }
    }
}
