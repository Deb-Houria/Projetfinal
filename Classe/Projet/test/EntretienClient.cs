using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Projetfinal.Classe.Projet.test
{
    public class EntretienClient
    {
        public string IdClient { get; set; }
        public string Voiture { get; set; } 
        public string TypeEntretien { get; set; } 
        public DateTime DatePrevue { get; set; }

        private static string chemin = "C:\\Users\\X415\\source\\repos\\Projetfinal\\Classe\\Projet\\test\\entretiens.json";

        public static List<EntretienClient> ChargerEntretiens()
        {
            if (File.Exists(chemin))
            {
                string json = File.ReadAllText(chemin);
                return JsonConvert.DeserializeObject<List<EntretienClient>>(json) ?? new List<EntretienClient>();
            }
            return new List<EntretienClient>();
        }

        public static void SauvegarderEntretiens(List<EntretienClient> entretiens)
        {
            string json = JsonConvert.SerializeObject(entretiens, Formatting.Indented);
            File.WriteAllText(chemin, json);
        }

        public static void AjouterEntretien(string id)
        {
            var entretiens = ChargerEntretiens();
            EntretienClient e = new EntretienClient();

            e.IdClient = id;
            Console.Write("Voiture concernée : ");
            e.Voiture = Console.ReadLine();

            Console.Write("Type d'entretien : ");
            e.TypeEntretien = Console.ReadLine();

            Console.Write("Date prévue (jj-mm-aaaa) : ");
            e.DatePrevue = DateTime.Parse(Console.ReadLine());

            entretiens.Add(e);
            SauvegarderEntretiens(entretiens);
            Console.WriteLine("Entretien enregistré avec succés.");
        }

        public static void VoirEntretiensClient(string id)
        {
            var entretiens = ChargerEntretiens().Where(ent => ent.IdClient == id).ToList();

            if (entretiens.Count == 0)
            {
                Console.WriteLine(" Aucun entretien enregistré.");
                return;
            }

            Console.WriteLine(" Entretiens planifiés :");
            foreach (var ent in entretiens)
            {
                Console.WriteLine($"{ent.DatePrevue.ToShortDateString()} - {ent.Voiture} - {ent.TypeEntretien}");
            }
        }
    }

}
