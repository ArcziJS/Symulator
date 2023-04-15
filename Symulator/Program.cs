//using Oracle.DataAccess.Client;
//using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Client;
using Symulator;
using System.Data.OracleClient;

class Program
{
    static void Main()
    {

        Console.WriteLine("Starting.\r\n");
        using (var _db = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=217.173.198.135)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=tpdb)));User Id=s101700; Password=s101700;"))
        {
            Console.WriteLine("Open connection...");
            _db.Open();
            Console.WriteLine("Connected to:" + _db.ServerVersion);
            Console.WriteLine("\r\nDone. Press key for exit");
            Console.ReadKey();
        }

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
