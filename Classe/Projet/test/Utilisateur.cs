using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Projetfinal.Classe.Projet.test;

namespace Projet.test
{
    public abstract class Utilisateur
    {
        public string Id { get; set; }
        public string motdepasse { get; set; }
        public string role { get; set; } 


        public static UtilisateurData AuthentifierUtilisateur()
        {
            string chemin = "C:\\Users\\X415\\source\\repos\\Projetfinal\\Classe\\Projet\\test\\utilisateurs.json";

            if (!File.Exists(chemin))
            {
                Console.WriteLine(" Fichier introuvable.");
                return null;
            }

            string json = File.ReadAllText(chemin);
            var utilisateurs = JsonConvert.DeserializeObject<List<UtilisateurData>>(json);

            Console.Write(" Veuillez saisir votre ID : ");
            string id = Console.ReadLine();

            Console.Write("Veuillez saisir votre mot de passe : ");
            string motdepasse = Console.ReadLine();

            var utilisateur = utilisateurs.FirstOrDefault(u => u.Id == id && u.motdepasse == motdepasse);

            if (utilisateur == null)
            {
                Console.WriteLine(" Identifiant ou mot de passe incorrect.");
                return null;
            }

            Console.WriteLine($" Vous êtes Connecter en tant que {utilisateur.role} !");
            return utilisateur;
        }

        virtual public void Afficher()
        {
        }
    }
}
