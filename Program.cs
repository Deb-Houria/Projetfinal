using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Projet.test;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("======== Menu Principal ========");
            Console.WriteLine("1. Se connecter");
            Console.WriteLine("0. Quitter");
            Console.Write("Veuillez saisir votre choix : ");
            string saisie = Console.ReadLine();

            if (saisie == "0") break;

            var utilisateur = Utilisateur.AuthentifierUtilisateur();

            if (utilisateur == null)
            {
                Console.WriteLine("Appuyez sur une touche pour réessayer....");
                Console.ReadKey();
                continue;
            }

            switch (utilisateur.role.ToLower())
            {
                case "proprietaire":
                    Proprietaire proprietaire = new Proprietaire();
                    proprietaire.Id = utilisateur.Id;
                    proprietaire.Afficher();
                    break;

                case "client":
                    Client client = new Client(utilisateur.Id);  
                    client.Afficher();
                    break;

                case "vendeur":
                    Vendeur vendeur = new Vendeur();
                    vendeur.Id = utilisateur.Id;
                    vendeur.Afficher();
                    break;

                case "fournisseur":
                    Fournisseur fournisseur = new Fournisseur();
                    fournisseur.Id = utilisateur.Id;
                    fournisseur.Afficher();
                    break;

                default:
                    Console.WriteLine(" Rôle indéfini.");
                    break;
            }

            Garage.Pause();
        }
    }
}
