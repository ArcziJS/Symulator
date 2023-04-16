﻿using Oracle.ManagedDataAccess.Client;
using Symulator.Generators;
using Symulator.Selectors;

namespace Symulator.Inserters
{
    internal class Klienci : OracleDBConnector
    {
        public Klienci(int rekordy)
        {
            int maxIdKlienci = MaxIdKlienci.GetMaxIdKlienci();
            int maxIdAdresy = MaxIdAdresy.GetMaxIdAdresy();

            Console.WriteLine("Dodawanie rekordów:");

            Random rnd = new Random();
            for (int i = 1; i <= rekordy; i++)
            {
                int nextIdKlienci = maxIdKlienci + i;
                string randomImie = GeneratorImion.WybierzImie();
                string randomNazwisko = GeneratorNazwisk.WybierzNazwisko();
                int randomNumerTelefonu = rnd.Next(100000000, 999999999);
                string randomPESEL = rnd.Next(100000, 999999).ToString() + rnd.Next(10000, 99999).ToString();
                string randomEmail = randomImie.ToLower() + "." + randomNazwisko + GeneratorDomenEmail.GenerujDomene();
                int IdAdresy = rnd.Next(1, Convert.ToInt32(maxIdAdresy) + 1);

                string query = "INSERT into Klienci " +
                    "(id_klienta, imie, nazwisko, nr_telefonu, PESEL, email, adres, adresy_id_adresu)" +
                    "Values" +
                    "(" + nextIdKlienci + ", :randomImie , :randomNazwisko , " + randomNumerTelefonu + " ,  :randomPESEL, :email, " + IdAdresy + ", " + IdAdresy + ")";

                using (OracleCommand AddKlienci = GetConnection().CreateCommand())
                {
                    AddKlienci.CommandText = query;
                    AddKlienci.Parameters.Add("randomImie", randomImie);
                    AddKlienci.Parameters.Add("randomNazwisko", randomNazwisko);
                    AddKlienci.Parameters.Add("randomPESEL", randomPESEL);
                    AddKlienci.Parameters.Add("email", randomEmail);
                    AddKlienci.ExecuteNonQuery();
                    Console.WriteLine("Dodano rekord.");
                }

            }
        }
    }
}