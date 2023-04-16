using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symulator.Generators
{
    internal class GeneratorPESEL
    {
        public static string WygenerujPESEL()
        {
            Random random = new Random();
            string randomPESEL = random.Next(100000, 999999).ToString() + random.Next(10000, 99999).ToString();
            return randomPESEL;
        }
    }
}
