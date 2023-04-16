using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symulator.Generators
{
    internal class GeneratorVIN
    {
        public static string WygenerujVIN()
        {
            string[] znaki =
            {
                "A", "B", "C", "D", "E", "F", "G", "H", "J", "K", "L",
                "M", "N", "P", "R", "S", "T", "U", "V", "W", "X", "Y",
                "Z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"
            };
            string vin = "";
            Random random = new Random();
            for (int i = 0; i < 17; i++)
            {
                vin += znaki[random.Next(znaki.Length)];
            }
            return vin.ToString();
        }
    }
}
