using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using Projetfinal.Classe.Projet.test;

namespace Projet.test
{
	public class Fournisseur : Utilisateur
	{
        public override void Afficher()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("========= Menu Fournisseur =========");
                Console.WriteLine("1. Ajouter une voiture au stock");
                Console.WriteLine("2. Ajouter une pièce au stock");
                Console.WriteLine("0. Retour");

                string choix = Console.ReadLine();

                if (choix == "0") break;

                switch (choix)
                {
                    case "1": AjouterVoiture(); break;
                    case "2": AjouterPiece(); break;
                    default: Console.WriteLine("Choix invalide."); break;
                }

                Garage.Pause();
            }
        }
        public void AjouterVoiture()
        {
            Voiture v = new Voiture();

            Console.WriteLine("Entrez la marque de la voiture :");
            v.marque = Console.ReadLine();
            Console.WriteLine("Entrez le modèle :");
            v.modele = Console.ReadLine();
            Console.WriteLine("Entrez l'année :");
            v.annee = Console.ReadLine();
            Console.WriteLine("Entrez la catégorie :");
            v.categorie = Console.ReadLine();
            Console.WriteLine("Entrez le prix approximatif :");
            v.prix_approximatif = int.Parse(Console.ReadLine());
            Console.WriteLine("Entrez le kilométrage :");
            v.kilometrage = int.Parse(Console.ReadLine());
            Console.WriteLine("Entrez la couleur :");
            v.couleur = Console.ReadLine();
            Console.WriteLine("Entrez le type de carburant :");
            v.type_carburant = Console.ReadLine();
            Console.WriteLine("Entrez la transmission :");
            v.transmission = Console.ReadLine();
            Console.WriteLine("Entrez l'achat général :");
            v.achat_general = Console.ReadLine();
            Console.WriteLine("Entrez le VIN :");
            v.vin = Console.ReadLine();
            Console.WriteLine("Entrez le propriétaire :");
            v.proprietaire = Console.ReadLine();
            Console.WriteLine("Entrez la date d'achat (jj-mm-aaaa) :");
            v.date_achat = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Entrez la dernière révision (jj-mm-aaaa) :");
            v.derniere_revesion = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Entrez la garantie restante :");
            v.garantie_restante = Console.ReadLine();
            Console.WriteLine("Entrez l'assurance :");
            v.assurance = Console.ReadLine();

            string chemin = "C:\\Users\\X415\\source\\repos\\Projetfinal\\Classe\\Projet\\voitures_db.csv";
            using (var stream = File.Open(chemin, FileMode.Append))
            using (var writer = new StreamWriter(stream))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecord(v);
                writer.WriteLine(); 
            }
            Console.WriteLine("Voiture ajoutée au stock avec succés.");
        }
        public void AjouterPiece()
        {
            var pieces = Proprietaire.LirePieces();

            Console.Write("Nom de la pièce : ");
            string nom = Console.ReadLine();

            Console.Write("Prix : ");
            int prix = int.Parse(Console.ReadLine());

            pieces.Add(new PieceData { nom_piece = nom, prix = prix });
            Proprietaire.SauvegarderPieces(pieces);

            Console.WriteLine(" Pièce ajoutée au stock avec succés.");
        }
    }
}
