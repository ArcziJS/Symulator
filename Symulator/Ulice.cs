namespace Symulator
{
    internal class Ulice
    {
        string[] ulice = 
            { 
                "Nowy Świat", "Marszałkowska", "Chmielna", "Kościuszki", "Piłsudskiego", "Piotrkowska", "Grunwaldzka",
                "Długa", "Świętokrzyska", "Monte Cassino", "Floriańska", "Aleja Niepodległości", "Krakowskie Przedmieście",
                "Batorego", "Kazimierza Wielkiego", "Wita Stwosza", "Jana Pawła II", "Stary Rynek", "Chopina", "Mickiewicza" 
            };



        public string WybierzUlice()
        {
            Random random = new Random();
            return ulice[random.Next(ulice.Length)];
        }
    }
}
