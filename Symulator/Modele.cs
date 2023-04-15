namespace Symulator
{
    internal class Modele
    {
        string[] modele =
            {
                "Golf", "Passat", "Polo", "Jetta", "Beetle", "Touareg", "Tiguan", "Transporter", "Civic", "Accord", "CR-V",
                "HR-V", "Civic Type R", "Focus", "Mondeo", "Fiesta", "Mustang", "Escape", "Explorer", "F-150", "C-Class",
                "E-Class", "S-Class", "CLA-Class", "GLA-Class", "GLC-Class", "GLE-Class", "GLS-Class", "A-Class", "B-Class",
                "Sprinter", "X3", "X5", "X7", "Z4", "Cayenne", "911", "Panamera", "Camaro", "Corvette", "Impala", "Malibu",
                "Silverado", "Challenger", "Charger", "Durango", "Wrangler", "Grand Cherokee", "Cherokee", "Compass",
                "Renegade", "Model 3", "Model S", "Model X", "Model Y"
            };

        public string WybierzModel()
        {
            Random random = new Random();
            return modele[random.Next(modele.Length)];
        }

    }
}
