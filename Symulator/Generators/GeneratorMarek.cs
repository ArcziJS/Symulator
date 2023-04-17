namespace Symulator.Generators
{
    internal class GeneratorMarek
    {
        public static string WybierzMarke()
        {
            string[] marka =
            {
                "Abarth", "Alfa Romeo", "Aston Martin", "Audi", "Bentley", "BMW", "Bugatti", "Cadillac", "Chevrolet", "Chrysler",
                "Citroën", "Dacia", "Daewoo", "Daihatsu", "Dodge", "DS Automobiles", "Ferrari", "Fiat", "Ford", "Honda",
                "Hummer", "Hyundai", "Infiniti", "Jaguar", "Jeep", "Kia", "Lamborghini", "Lancia", "Land Rover", "Lexus",
                "Lotus", "Maserati", "Mazda", "Mercedes-Benz", "MG", "Mini", "Mitsubishi", "Nissan", "Opel", "Peugeot",
                "Porsche", "Renault", "Rolls-Royce", "Rover", "Saab", "Seat", "Škoda", "Smart", "SsangYong", "Subaru",
                "Suzuki", "Tesla", "Toyota", "Volkswagen", "Volvo"
            };
            Random random = new Random();
            return marka[random.Next(marka.Length)];
        }
    }
}
