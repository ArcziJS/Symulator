namespace Symulator
{
    internal class Ulice
    {
        string[] ulice = { "Asfaltowa", "Kwiatowa", "Lipowa", "Brzozowa", "Ta", "Tamta", "Dziurawa" };

        public string WybierzUlice()
        {
            Random random = new Random();
            return ulice[random.Next(ulice.Length)];
        }
    }
}
