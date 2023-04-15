using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Symulator
{
    internal class Miasta
    {
        string[] miasta = { "Warszawa", "Kraków", "Opole", "Poznań", "Katowice"};

        public string WybierzMiasto()
        {
            Random random = new Random();
            return miasta[random.Next(miasta.Length)];
        }
    }
}
