//using Oracle.DataAccess.Client;
//using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Client;
using Symulator;


class Program
{
    static void Main()
    {
        using (var _db = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=217.173.198.135)(PORT=1521)))(CONNECT_DATA=(Service_name=tpdb)));User ID=s101700;Password=s101700;"))
        {
            Console.WriteLine("Open connection...");
            _db.Open();
            Console.WriteLine("Connected to: " + _db.ServerVersion);

            Console.WriteLine("Podaj nazwę tabeli: ");
            string tabela = Console.ReadLine().ToString();
            Console.WriteLine("Ile rekordów chcesz dodać?");
            int dodaj = int.Parse(Console.ReadLine());

            switch (tabela.ToLower())
            {
                case "komisy":
                    Komisy Komisy = new Komisy(_db, dodaj);
                    break;
                case "adresy":
                    Adresy Adresy = new Adresy(_db, dodaj);
                    break;
                case "serwisy":
                    Serwisy Serwisy = new Serwisy(_db, dodaj);
                    break;
                case "marki":
                    Marki Marki = new Marki(_db, dodaj);
                    break;
                case "sprzedawcy":
                    Sprzedawcy sprzedawcy = new Sprzedawcy(_db, dodaj);
                    break;

            }
        }



    }
}
