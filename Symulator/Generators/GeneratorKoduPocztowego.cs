using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symulator.Generators
{
    internal class GeneratorKoduPocztowego
    {
        public static string WygenerujKodPocztowy()
        {
            Random random = new Random();
            string randomKodPocztowy = random.Next(10, 99) + "-" + random.Next(100, 999);
            return randomKodPocztowy;
        }
    }
}
