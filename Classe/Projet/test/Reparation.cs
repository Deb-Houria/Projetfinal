using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration;
using CsvHelper;
using Newtonsoft.Json;
using Projetfinal.Classe.Projet.test;

namespace Projet.test
{
	public class Reparation
	{
        public string categorie { get; set; }
        public string nom_de_piece { get; set; }
        public int prix_approx { get; set; }
        public string description { get; set; }
        public string reparation_associe { get; set; }
        public static List<Reparation> ChargerDepuisCSV()
        {
            try
            {
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HeaderValidated = null,
                    MissingFieldFound = null
                };

                using var reader = new StreamReader("C:\\Users\\X415\\source\\repos\\Projetfinal\\Classe\\Projet\\reparations_db.csv");
                using var csv = new CsvReader(reader, config);
                return csv.GetRecords<Reparation>().ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Erreur lors du chargement du fichier CSV : " + ex.Message);
                return new List<Reparation>();
            }
        }
	}
}
