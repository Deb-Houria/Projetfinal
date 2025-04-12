using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Projet.test
{
    public class Facture
    {
        public string IdClient { get; set; }
        public string Voiture { get; set; }
        public string DescriptionTravaux { get; set; }
        public double CoutMainOeuvre { get; set; }
        public List<string> Pieces { get; set; }
        public double MontantTotal { get; set; }
        public string MoyenPaiement { get; set; }
        public DateTime DateFacture { get; set; }

        private static string chemin = "C:\\Users\\X415\\source\\repos\\Projetfinal\\Classe\\Projet\\test\\factures.json";

        public static List<Facture> Charger()
        {
            if (!File.Exists(chemin)) return new List<Facture>();
            string json = File.ReadAllText(chemin);
            return JsonConvert.DeserializeObject<List<Facture>>(json) ?? new List<Facture>();
        }

        public static void Sauvegarder(List<Facture> factures)
        {
            var json = JsonConvert.SerializeObject(factures, Formatting.Indented);
            File.WriteAllText(chemin, json);
        }

        public static void GenererFacture(DevisClient devis)
        {
            var factures = Charger();

            Console.Write("Mode de paiement (carte, espèces, virement...) : ");
            string paiement = Console.ReadLine();

            var facture = new Facture
            {
                IdClient = devis.IdClient,
                Voiture = devis.Voiture,
                DescriptionTravaux = devis.DescriptionTravaux,
                CoutMainOeuvre = devis.CoutMainOeuvre,
                Pieces = devis.Pieces,
                MontantTotal = devis.CoutEstime,
                MoyenPaiement = paiement,
                DateFacture = DateTime.Now
            };

            factures.Add(facture);
            Sauvegarder(factures);
            Console.WriteLine("Facture générée ");
        }

        public static void AfficherFacturesClient(string id)
        {
            var factures = Charger().Where(f => f.IdClient == id).ToList();
            if (factures.Count == 0)
            {
                Console.WriteLine("Aucune facture trouvée.");
                return;
            }

            foreach (var f in factures)
            {
                Console.WriteLine($"{f.DateFacture.ToShortDateString()} - {f.Voiture} - {f.MontantTotal}€ - payé par {f.MoyenPaiement}");
            }
        }
    }

}
