namespace Symulator.Generators
{
    internal class GeneratorDomenEmail
    {
        public static string GenerujDomene()
        {
            string[] domeny =
            {
                "@gmail.com", "@yahoo.com", "@hotmail.com", "@outlook.com"
            };
            Random random = new Random();
            return domeny[random.Next(domeny.Length)];
        }
    }
}
