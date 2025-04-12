using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Projet.test
{
    public class DevisClient
    {
        public string IdClient { get; set; }
        public string Voiture { get; set; }
        public string DescriptionTravaux { get; set; }
        public double CoutMainOeuvre { get; set; }
        public List<string> Pieces { get; set; }
        public double CoutEstime { get; set; }
        public bool EstValide { get; set; }

        private static string chemin = "C:\\Users\\X415\\source\\repos\\Projetfinal\\Classe\\Projet\\test\\devis.json";  

        public static List<DevisClient> Charger()
        {
            if (!File.Exists(chemin)) return new List<DevisClient>();
            var json = File.ReadAllText(chemin);
            return JsonConvert.DeserializeObject<List<DevisClient>>(json) ?? new List<DevisClient>();
        }

        public static void Sauvegarder(List<DevisClient> devis)
        {
            var json = JsonConvert.SerializeObject(devis, Formatting.Indented);
            File.WriteAllText(chemin, json);
        }

        public static void CreerDevis(string id)
        {
            var devis = Charger();
            DevisClient d = new DevisClient();

            d.IdClient = id;
            Console.Write("Voiture concernée : ");
            d.Voiture = Console.ReadLine();

            Console.Write("Description des travaux : ");
            d.DescriptionTravaux = Console.ReadLine();

            Console.Write("Coût main d'œuvre : ");
            d.CoutMainOeuvre = double.Parse(Console.ReadLine());

            Console.Write("Pièces nécessaires (Séparation avec virgule) : ");
            d.Pieces = Console.ReadLine().Split(',').Select(p => p.Trim()).ToList();

            Console.Write("Coût estimé total : ");
            d.CoutEstime = double.Parse(Console.ReadLine());

            d.EstValide = false;

            devis.Add(d);
            Sauvegarder(devis);
            Console.WriteLine("Devis enregistré.");
        }

        public static void ValiderDevis(string id)
        {
            var devis = Charger().Where(d => d.IdClient == id && !d.EstValide).ToList();

            if (devis.Count == 0)
            {
                Console.WriteLine("Aucun devis à valider.");
                return;
            }

            for (int i = 0; i < devis.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {devis[i].Voiture} | {devis[i].CoutEstime} €");
            }

            Console.Write("Choix du devis à valider : ");
            int choix = int.Parse(Console.ReadLine());

            devis[choix - 1].EstValide = true;
            Sauvegarder(Charger()); 
            Facture.GenererFacture(devis[choix - 1]); 

            Console.WriteLine(" Devis validé et transformé en facture.");
        }
    }
}
