using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symulator.Generators
{
    internal class GeneratorMiast
    {
        public static string WybierzMiasto()
        {
            string[] miasta =
            {
                "Warszawa", "Kraków", "Gdańsk", "Poznań", "Wrocław", "Łódź", "Katowice", "Szczecin",
                "Bydgoszcz", "Gdynia", "Toruń", "Zakopane", "Krynica-Zdrój", "Kołobrzeg", "Sopot",
                "Zamość", "Zielona Góra", "Białystok", "Olsztyn", "Kielce"
            };
            Random random = new Random();
            return miasta[random.Next(miasta.Length)];
        }
    }
}
