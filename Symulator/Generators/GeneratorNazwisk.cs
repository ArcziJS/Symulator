using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symulator.Generators
{
    internal class GeneratorNazwisk
    {
        public static string WybierzNazwisko()
        {
            string[] nazwiska =
            {
                "Adamczyk", "Bąk", "Bąkowski", "Czech", "Czerwiński", "Dziedzic", "Gajewski", "Górecki", "Górka", "Grabowski","Janik", "Jurek",
                "Klimek", "Kłos", "Knapik", "Kowalik", "Kozak", "Kozioł", "Krawczyk", "Kruk", "Krzemiński", "Książek","Kułak", "Łuczak",
                "Majewski", "Majka", "Malinowski", "Marcinkowski", "Marek", "Matusiak", "Mazurkiewicz", "Michalak","Michalski", "Mróz",
                "Musiał", "Nawrocki", "Niemiec", "Olszewski", "Orłowski", "Osiński", "Ossowski", "Pająk", "Pietrzak","Piwowarczyk", "Przybylski",
                "Ratajczak", "Romanowski", "Rutkowski", "Sadowski", "Sawicki", "Skiba", "Skowron", "Sobczak","Sokołowski", "Stachowiak", "Stefański",
                "Szulc", "Szymczak", "Szymczyk", "Tkacz", "Tomczak", "Urban", "Urbaniak", "Wawrzyniak","Wesołowski", "Wieczorek", "Wilczyński",
                "Wilk", "Witek", "Włodarczyk", "Wojtas", "Woźniak", "Wrona", "Zając", "Zalewski", "Zawadzki","Zieliński", "Żukowski"
            };
            Random random = new Random();
            return nazwiska[random.Next(nazwiska.Length)];
        }
    }
}
