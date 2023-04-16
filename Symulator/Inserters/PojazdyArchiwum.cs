﻿using Oracle.ManagedDataAccess.Client;
using Symulator.Generators;
using Symulator.Selectors;

namespace Symulator.Inserters
{
    internal class PojazdyArchiwum : OracleDBConnector
    {
        public PojazdyArchiwum(int rekordy)
        {
            int maxIdPojazdy = MaxIdPojazdy.GetMaxIdPojazdy();
            int maxIdKomisy = MaxIdKomisy.GetMaxIdKomisy();
            int maxIdMarki = MaxIdMarki.GetMaxIdMarki();
            int maxIdWyposazenie = MaxIdWyposazenie.GetMaxIdWyposazenie();
            int maxIdUmowy = MaxIdUmowy.GetMaxIdUmowy();

            Console.WriteLine("Dodawanie rekordów:");

            Random rnd = new Random();
            for (int i = 1; i <= rekordy; i++)
            {
                int nextIdPojazdy = maxIdPojazdy + i;
                int randomMarka = rnd.Next(1, maxIdMarki);
                string randomModel = GeneratorModeli.WybierzModel();
                string randomKolor = GeneratorKolorow.WybierzKolor();
                int randomRokProdukcji = rnd.Next(2000, 2023);
                string randomVIN = GeneratorVIN.WygenerujVIN();
                int randomPrzebieg = rnd.Next(10000, 250000);
                int randomWyposazenie = rnd.Next(1, maxIdWyposazenie + 1);
                int randomPojemnosc = rnd.Next(1000, 5000);
                int randomKonieMechaniczne = rnd.Next(100, 400);
                int randomMomentObrotowy = rnd.Next(180, 660);
                int randomIdMarki = rnd.Next(1, maxIdMarki + 1);
                int randomIdKomisy = rnd.Next(1, maxIdKomisy + 1);
                int nextIdUmowy = maxIdUmowy + i;

                string query = "INSERT into \"Pojazdy-Archiwum\" " +
                    "(id_pojazdu, marka, model, kolor, rok_produkcji, VIN, przebieg, wyposazenie, pojemnosc, km, nm, marki_id_marki, komisy_id_komisu, umowy_id_umowy)" +
                    "Values" +
                    "(" + nextIdPojazdy + ", " + randomMarka + ", :randomModel, :randomKolor," + randomRokProdukcji + ", :randomVIN, " + randomPrzebieg + "," + randomWyposazenie + ", " + randomPojemnosc + ", " + randomKonieMechaniczne + ", " + randomMomentObrotowy + ", " + randomIdMarki + ", " + randomIdKomisy + "," + nextIdUmowy + ")";

                using (OracleCommand AddPojazdy = GetConnection().CreateCommand())
                {
                    AddPojazdy.CommandText = query;
                    //AddPojazdy.Parameters.Add("randomMarka", randomMarka);
                    AddPojazdy.Parameters.Add("randomModel", randomModel);
                    AddPojazdy.Parameters.Add("randomKolor", randomKolor);
                    AddPojazdy.Parameters.Add("randomVIN", randomVIN);
                    AddPojazdy.ExecuteNonQuery();
                    Console.WriteLine("Dodano rekord.");
                }

            }
        }
    }
}