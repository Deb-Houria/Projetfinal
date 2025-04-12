using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Projetfinal.Classe.Projet.test
{
    public class ReparationClient
    {
        public string IdClient { get; set; }                  
        public string Voiture { get; set; }                   
        public string TypeIntervention { get; set; }          
        public string Description { get; set; }               
        public double CoutEstime { get; set; }                
        public List<string> PiecesUtilisees { get; set; }    
        public DateTime DateReparation { get; set; }

        static string chemin = "C:\\Users\\X415\\source\\repos\\Projetfinal\\Classe\\Projet\\test\\reparations.json";

        public static List<ReparationClient> LireReparation()
        {
            if (File.Exists(chemin))
            {
                string contenu = File.ReadAllText(chemin);
                return JsonConvert.DeserializeObject<List<ReparationClient>>(contenu) ?? new List<ReparationClient>();
            }
            return new List<ReparationClient>();
        }

        public static void SauvegarderReparation(List<ReparationClient> reparations)
        {
            string json = JsonConvert.SerializeObject(reparations, Formatting.Indented);
            File.WriteAllText(chemin, json);
        }

        public static void AjouterReparation(string idClient)
        {
            var liste = LireReparation();
            ReparationClient r = new ReparationClient();
            r.IdClient = idClient;

            Console.Write("Voiture : ");
            r.Voiture = Console.ReadLine();

            Console.Write("Type d'intervention : ");
            r.TypeIntervention = Console.ReadLine();

            Console.Write("Description : ");            
            r.Description = Console.ReadLine();         

            Console.Write("Coût estimé : ");
            r.CoutEstime = double.Parse(Console.ReadLine());

            liste.Add(r);
            SauvegarderReparation(liste);

            Console.WriteLine(" Réparation ajoutée avec succés.");
        }
        public static void AfficherHistorique(string idClient)
        {
            var liste = LireReparation().Where(r => r.IdClient == idClient).ToList();

            if (!liste.Any())
            {
                Console.WriteLine(" Aucune réparation trouvée.");
                return;
            }

            foreach (var r in liste)
            {
                Console.WriteLine($"{r.DateReparation:jj/mm/aaaa} | {r.Voiture} | {r.TypeIntervention} | {r.CoutEstime} €");
                Console.WriteLine($"Description : {r.Description}");
                
            }
        }



    }

}
