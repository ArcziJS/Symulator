//using Oracle.DataAccess.Client;
using Symulator;

class Program
{
    static void Main()
    {
        Console.WriteLine("Podaj nazwę tabeli: ");
        string tabela = Console.ReadLine().ToString();
        Console.WriteLine("Ile rekordów chcesz dodać?");
        int dodaj = int.Parse(Console.ReadLine());

        switch (tabela.ToLower())
        {
            case "komisy":
                Komisy Komisy = new Komisy(dodaj);
                break;
            case "adresy":
                Adresy Adresy = new Adresy(dodaj);
                break;
            case "serwisy":
                Serwisy Serwisy = new Serwisy(dodaj);
                break;
            case "marki":
                Marki Marki = new Marki(dodaj);
                break;

        }

    }
}
