using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration;
using CsvHelper;
using Newtonsoft.Json;

namespace Projet.test
{
	public class Voiture
	{
        public string marque { get; set; }
        public string modele { get; set; }
        public string annee { get; set; }
        public string categorie { get; set; }
        public int prix_approximatif { get; set; }
        public int kilometrage { get; set; }
        public string couleur { get; set; }
        public string type_carburant { get; set; }
        public string transmission { get; set; }
        public string achat_general { get; set; }
        public string vin { get; set; }
        public string proprietaire { get; set; }
        public DateTime date_achat { get; set; }
        public DateTime derniere_revesion { get; set; }
        public string garantie_restante { get; set; }
        public string assurance { get; set; }



        public static List<Voiture> ChargerDepuisCSV()
        {
            try
            {
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HeaderValidated = null,
                    MissingFieldFound = null
                };

                using var reader = new StreamReader("C:\\Users\\X415\\source\\repos\\Projetfinal\\Classe\\Projet\\voitures_db.csv");
                using var csv = new CsvReader(reader, config);
                return csv.GetRecords<Voiture>().ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Erreur lors du chargement du fichier CSV : " + ex.Message);
                return new List<Voiture>();
            }
        }

        public static void SauvegarderDansCSV(List<Voiture> voitures)
        {
            string cheminFichier = "C:\\Users\\X415\\source\\repos\\Projetfinal\\Classe\\Projet\\voitures_db.csv";

            using var writer = new StreamWriter(cheminFichier);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords(voitures);
        }

    }
}
