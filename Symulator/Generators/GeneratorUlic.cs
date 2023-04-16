using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symulator.Generators
{
    internal class GeneratorUlic
    {
        public static string WybierzUlice()
        {
            string[] ulice =
            {
                "Nowy Świat", "Marszałkowska", "Chmielna", "Kościuszki", "Piłsudskiego", "Piotrkowska", "Grunwaldzka",
                "Długa", "Świętokrzyska", "Monte Cassino", "Floriańska", "Aleja Niepodległości", "Krakowskie Przedmieście",
                "Batorego", "Kazimierza Wielkiego", "Wita Stwosza", "Jana Pawła II", "Stary Rynek", "Chopina", "Mickiewicza"
            };
            Random random = new Random();
            return ulice[random.Next(ulice.Length)];
        }
    }
}
