//using Oracle.DataAccess.Client;
//using Oracle.ManagedDataAccess.Client;
using Symulator;
using Symulator.Inserters;

class Program : OracleDBConnector
{
    static void Main()
    {
        Console.WriteLine("Connecting...");
        Connect();
        Console.WriteLine("Connected!");
        Wybierajka();
        GetConnection().Close();
    }

    static void Wybierajka()
    {
        Console.WriteLine("\n\nPodaj nazwę tabeli: ");
        string tabela = Console.ReadLine().ToString();
        Console.WriteLine("Ile rekordów chcesz dodać?");
        int dodaj = int.Parse(Console.ReadLine());

        switch (tabela.ToLower())
        {
            case "komisy":
                Komisy Komisy = new Komisy(dodaj);
                Wybierajka();
                break;
            case "adresy":
                Adresy Adresy = new Adresy(dodaj);
                Wybierajka();
                break;
            case "serwisy":
                Serwisy Serwisy = new Serwisy(dodaj);
                Wybierajka();
                break;
            case "marki":
                Marki Marki = new Marki(dodaj);
                Wybierajka();
                break;
            case "sprzedawcy":
                Sprzedawcy Sprzedawcy = new Sprzedawcy(dodaj);
                Wybierajka();
                break;
            case "pojazdy":
                Pojazdy Pojazdy = new Pojazdy(dodaj);
                Wybierajka();
                break;
            case "wyposazenie":
                Wyposazenie Wyposazenie = new Wyposazenie(dodaj);
                Wybierajka();
                break;
            case "klienci":
                Klienci Klienci = new Klienci(dodaj);
                Wybierajka();
                break;
            case "umowy":
                Umowy Umowy = new Umowy(dodaj);
                Wybierajka();
                break;
            case "pojazdy-archiwum":
                PojazdyArchiwum PojazdyArchiwum = new PojazdyArchiwum(dodaj);
                Wybierajka();
                break;
            case "pojazd-wyposazenie":
                PojazdWyposazenie PojazdWyposazenie = new PojazdWyposazenie(dodaj);
                Wybierajka();
                break;
            case "wszystkie":
                Komisy WszystkieKomisy = new Komisy(dodaj);
                Adresy WszystkieAdresy = new Adresy(dodaj);
                Serwisy WszystkieSerwisy = new Serwisy(dodaj);
                Marki WszystkieMarki = new Marki(dodaj);
                Sprzedawcy WszystkieSprzedawcy = new Sprzedawcy(dodaj);
                Pojazdy WszystkiePojazdy = new Pojazdy(dodaj);
                Wyposazenie WszystkieWyposazenie = new Wyposazenie(dodaj);
                Klienci WszystkieKlienci = new Klienci(dodaj);
                Umowy WszystkieUmowy = new Umowy(dodaj);
                PojazdyArchiwum WszystkiePojazdyArchiwum = new PojazdyArchiwum(dodaj);
                PojazdWyposazenie WszystkiePojazdWyposazenie = new PojazdWyposazenie(dodaj);
                Wybierajka();
                break;
            default:
                Console.WriteLine("Artur Siudak");
                break;
        }
    }
}
