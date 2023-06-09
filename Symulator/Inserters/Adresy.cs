﻿using Oracle.ManagedDataAccess.Client;
using Symulator.Generators;
using Symulator.Selectors;

namespace Symulator.Inserters
{
    internal class Adresy : OracleDBConnector
    {
        public Adresy(int rekordy)
        {
            int maxIdAdresy = MaxIdAdresy.GetMaxIdAdresy();
            int maxIdKomisy = MaxIdKomisy.GetMaxIdKomisy();

            Console.WriteLine("\nDodawanie Adresów:");

            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            Random random = new Random();
            for (int i = 1; i <= rekordy; i++)
            {
                int nextIdAdresy = maxIdAdresy + i;
                string randomMiasto = GeneratorMiast.WybierzMiasto();
                string randomUlica = GeneratorUlic.WybierzUlice();
                int randomNumerDomu = random.Next(1, 999);
                int randomNumerMieszkania = random.Next(1, 99);
                string randomKodPocztowy = GeneratorKoduPocztowego.WygenerujKodPocztowy();
                int randomIdKomisy = random.Next(1, maxIdKomisy + 1);

                string query = "INSERT into Adresy " +
                    "(id_adresu, miasto, ulica, nr_domu, nr_mieszkania, kod_pocztowy, komisy_id_komisu) " +
                    "Values " +
                    "(" + nextIdAdresy + ",:randomMiasto, :randomUlica, " + randomNumerDomu + ", " + randomNumerMieszkania + ",:randomKodPocztowy," + randomIdKomisy + ")";

                using (OracleCommand AddAdresy = GetConnection().CreateCommand())
                {
                    AddAdresy.CommandText = query;
                    AddAdresy.Parameters.Add(":randomMiasto", randomMiasto);
                    AddAdresy.Parameters.Add(":randomUlica", randomUlica);
                    AddAdresy.Parameters.Add(":randomKodPocztowy", randomKodPocztowy);
                    AddAdresy.ExecuteNonQuery();

                    string executedQuery = AddAdresy.CommandText;
                    foreach (OracleParameter param in AddAdresy.Parameters)
                    {
                        executedQuery = executedQuery.Replace(param.ParameterName, $"'{param.Value}'");
                    }
                    executedQuery += ";";


                    using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "AddAdresy.txt"), true))
                    {
                        outputFile.WriteLine(executedQuery);
                    }
                }
            }
            Console.Write("Dodano ");
            Console.Write(rekordy);
            Console.Write(" Adresów.\n");
        }
    }
}