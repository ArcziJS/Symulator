using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symulator.Generators
{
    internal class GeneratorImion
    {
        public static string WybierzImie()
        {
            string[] imiona =
            {
                "Adam", "Aleksander", "Aleksandra", "Alicja", "Amelia", "Andrzej", "Anna", "Antoni", "Agnieszka", "Barbara",
                "Bartosz", "Beata", "Bernadetta", "Bolesław", "Cezary", "Dagmara", "Damian", "Daniel", "Dariusz", "Dominika",
                "Dorota", "Edward", "Elżbieta", "Emilia", "Filip", "Franciszek", "Gabriela", "Grzegorz", "Halina", "Henryk",
                "Hubert", "Irena", "Iwona", "Jacek", "Jakub", "Jan", "Joanna", "Jerzy", "Józef", "Julia", "Juliusz", "Justyna",
                "Kacper", "Kamila", "Karol", "Karolina", "Katarzyna", "Kazimierz", "Kinga", "Krzysztof", "Konrad", "Lidia",
                "Łukasz", "Magdalena", "Maja", "Marek", "Maria", "Mariusz", "Martyna", "Małgorzata", "Michał", "Monika",
                "Natalia", "Nikodem", "Norbert", "Olga", "Oskar", "Paweł", "Patrycja", "Piotr", "Przemysław", "Renata",
                "Robert", "Radosław", "Rafał", "Szymon", "Stanisław", "Stefan", "Tadeusz", "Tomasz", "Teresa", "Urszula",
                "Weronika", "Wiktoria", "Wiesław", "Wiktor", "Wioletta", "Władysław", "Zbigniew", "Zdzisław", "Zofia","Zuzanna"
            };
            Random random = new Random();
            return imiona[random.Next(imiona.Length)];
        }
    }
}
