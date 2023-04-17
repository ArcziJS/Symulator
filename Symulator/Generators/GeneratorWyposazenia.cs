namespace Symulator.Generators
{
    internal class GeneratorWyposazenia
    {


        public static string WybierzElementWyposazenia()
        {
            string[] wyposazenie =
            {
                "klimatyzacja", "radio", "nawigacja", "tempomat", "skórzana tapicerka", "podgrzewane fotele",
                "elektrycznie sterowane szyby", "elektrycznie sterowane lusterka", "centralny zamek", "alarm",
                "kamera cofania", "czujniki parkowania", "ABS", "kontrola trakcji", "poduszki powietrzne", "felgi aluminiowe",
                "start-stop", "monitorowanie martwego pola", "rozpoznawanie znaków drogowych", "automatyczne parkowanie",
                "rozpoznawanie pieszych", "skórzana kierownica", "wyświetlacz Head-Up", "podgrzewana przednia szyba"
            };
            Random random = new Random();
            return wyposazenie[random.Next(wyposazenie.Length)];
        }
    }
}
