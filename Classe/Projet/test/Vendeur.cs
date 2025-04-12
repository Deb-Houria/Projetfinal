using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration;
using CsvHelper;

namespace Projet.test
{
	public class Vendeur : Utilisateur
	{
        public  override void Afficher()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("========= Menu Vendeur =========");
                Console.WriteLine("1. Afficher les voitures en stock");
                Console.WriteLine("2. Vendre une voiture");
                Console.WriteLine("3. Afficher les pièces en stock");
                Console.WriteLine("4. Vendre une pièce");
                Console.WriteLine("0. Retour");

                string choix = Console.ReadLine();

                if (choix == "0") break;

                switch (choix)
                {
                    case "1":
                        AfficherVoitures();
                        break;
                    case "2":
                        VendreVoiture();
                        break;
                    case "3":
                        AfficherPieces();
                        break;
                    case "4":
                        VendrePiece();
                        break;
                    default:
                        Console.WriteLine("Choix invalide.");
                        break;
                }

                Garage.Pause();
            }
        }
        private void AfficherVoitures()
        {
            var voitures = Voiture.ChargerDepuisCSV();
            Console.WriteLine("========= Voitures disponibles =========");
            foreach (var v in voitures)
            {
                Console.WriteLine($"{v.marque} {v.modele}, {v.annee}, {v.categorie},{v.prix_approximatif} EUR, {v.kilometrage} km," +
                    $"{v.couleur} ,{v.type_carburant},{ v.transmission},{v.achat_general},{v.vin},{v.proprietaire},{v.date_achat}," +
                    $"{v.derniere_revesion},{v.garantie_restante},{v.assurance}");
            }
        }

        private void VendreVoiture()
        {
            var voitures = Voiture.ChargerDepuisCSV();
            Console.Write("Entrez la marque : ");
            string marque = Console.ReadLine();
            Console.Write("Entrez le modèle : ");
            string modele = Console.ReadLine();
            Console.Write("Entrez le kilométrage : ");
            int km = int.Parse(Console.ReadLine());

            var voiture = voitures.FirstOrDefault(v => v.marque == marque && v.modele == modele && v.kilometrage == km);
            if (voiture != null)
            {
                voitures.Remove(voiture);
                Voiture.SauvegarderDansCSV(voitures);
                Console.WriteLine("Voiture vendue avec succès ");
            }
            else Console.WriteLine("Voiture introuvable.");
        }

        private void AfficherPieces()
        {
            var pieces = Proprietaire.LirePieces();
            Console.WriteLine("========= Pièces en stock =========");
            foreach (var p in pieces)
            {
                Console.WriteLine($"{p.nom_piece} - {p.prix} EUR");
            }
        }

        private void VendrePiece()
        {
            var pieces = Proprietaire.LirePieces();
            Console.Write("Nom de la pièce à vendre : ");
            string nom = Console.ReadLine();

            var piece = pieces.FirstOrDefault(p => p.nom_piece == nom);
            if (piece != null)
            {
                pieces.Remove(piece);
                Proprietaire.SauvegarderPieces(pieces);
                Console.WriteLine("Pièce vendue avec succès ");
            }
            else Console.WriteLine("Pièce introuvable.");
        }
    }
}


 