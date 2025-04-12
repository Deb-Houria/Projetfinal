using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Projetfinal.Classe.Projet.test
{
    public class VoitureClient
    {
        public string IdClient { get; set; }
        public string marque { get; set; }
        public string modele { get; set; }
        public string annee { get; set; }
        public string categorie { get; set; }
        public int kilometrage { get; set; }
        public int prix_approximatif { get; set; }

        private static string DossierBase = "C:\\Users\\X415\\source\\repos\\Projetfinal\\Classe\\Projet\\test\\clients_voitures";

        private static string ObtenirChemin(string idClient)
        {
            Directory.CreateDirectory(DossierBase);
            return Path.Combine(DossierBase, $"voitures_client_{idClient}.json");
        }

        public static List<VoitureClient> LireDepuisJson(string idClient)
        {
            string chemin = ObtenirChemin(idClient);

            if (File.Exists(chemin))
            {
                string json = File.ReadAllText(chemin);
                return JsonConvert.DeserializeObject<List<VoitureClient>>(json) ?? new List<VoitureClient>();
            }

            return new List<VoitureClient>();
        }

        public static void SauvegarderDansJson(List<VoitureClient> voitures, string idClient)
        {
            string chemin = ObtenirChemin(idClient);
            string json = JsonConvert.SerializeObject(voitures, Formatting.Indented);
            File.WriteAllText(chemin, json);
        }

        public static void AjouterVoiture(string idClient)
        {
            var voitures = LireDepuisJson(idClient);

            VoitureClient voiture = new VoitureClient();
            voiture.IdClient = idClient;

            Console.Write("Marque : "); voiture.marque = Console.ReadLine();
            Console.Write("Modèle : "); voiture.modele = Console.ReadLine();
            Console.Write("Année : "); voiture.annee = Console.ReadLine();
            Console.Write("Catégorie : "); voiture.categorie = Console.ReadLine();
            Console.Write("Kilométrage : "); voiture.kilometrage = int.Parse(Console.ReadLine());
            Console.Write("Prix approximatif : "); voiture.prix_approximatif = int.Parse(Console.ReadLine());

            voitures.Add(voiture);
            SauvegarderDansJson(voitures, idClient);

            Console.WriteLine("Voiture ajoutée avec succés.");
        }

        public static void ModifierVoiture(string idClient)
        {
            var voitures = LireDepuisJson(idClient);

            if (!voitures.Any())
            {
                Console.WriteLine("Voiture introuvable.");
                return;
            }

            var voiture = voitures[0];

            Console.Write("Nouvelle marque : "); voiture.marque = Console.ReadLine();
            Console.Write("Nouveau modèle : "); voiture.modele = Console.ReadLine();
            Console.Write("Nouvelle année : "); voiture.annee = Console.ReadLine();
            Console.Write("Nouvelle catégorie : "); voiture.categorie = Console.ReadLine();
            Console.Write("Nouveau kilométrage : "); voiture.kilometrage = int.Parse(Console.ReadLine());
            Console.Write("Nouveau prix approximatif : "); voiture.prix_approximatif = int.Parse(Console.ReadLine());

            SauvegarderDansJson(voitures, idClient);
            Console.WriteLine(" Voiture modifiée !");
        }

        public static void SupprimerVoiture(string idClient)
        {
            var voitures = LireDepuisJson(idClient);

            if (!voitures.Any())
            {
                Console.WriteLine("Il n'y aucune voiture à supprimer.");
                return;
            }

            voitures.RemoveAt(0);
            SauvegarderDansJson(voitures, idClient);

            Console.WriteLine("Voiture supprimée avec succés.");
        }

        public static void ConsulterVoitures(string idClient)
        {
            var voitures = LireDepuisJson(idClient);

            if (voitures.Count == 0)
            {
                Console.WriteLine(" Aucune voiture enregistrée.");
                return;
            }

            Console.WriteLine("========= Vos voitures =========");
            foreach (var v in voitures)
            {
                Console.WriteLine($"{v.marque} - {v.modele} ({v.annee}) | {v.kilometrage} km | {v.prix_approximatif}€");
            }
        }

        public static void ImporterDepuisJson(string idClient)
        {
            var voitures = LireDepuisJson(idClient);

            if (voitures.Count > 0)
            {
                Console.WriteLine(" Importation réussie.");
                ConsulterVoitures(idClient);
            }
            else
            {
                Console.WriteLine(" Aucune voiture à importer pour ce client.");
            }
        }
    }
}
