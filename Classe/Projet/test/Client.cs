using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projetfinal.Classe.Projet.test;

namespace Projet.test
{
    public class Client : Utilisateur
    {
        public Client(string id)
        {
            this.Id = id;
        }

        public override void Afficher()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Menu Client ===");
                Console.WriteLine("1. Consulter les voitures disponibles");
                Console.WriteLine("2. Consulter les pièces disponibles");
                Console.WriteLine("3. Acheter une voiture");
                Console.WriteLine("4. Acheter une pièce");
                Console.WriteLine("5. Soumettre une demande de réparation");
                Console.WriteLine("6. Ajouter une voiture personnelle");
                Console.WriteLine("7. Modifier une voiture personnelle");
                Console.WriteLine("8. Supprimer une voiture personnelle");
                Console.WriteLine("9. Voir mes voitures personnelles");
                Console.WriteLine("10. Importer mes voitures depuis un fichier JSON");
                Console.WriteLine("11. Ajouter une réparation");
                Console.WriteLine("12. Historique des réparations");
                Console.WriteLine("13. Planifier un entretien");
                Console.WriteLine("14. Voir mes entretiens");
                Console.WriteLine("15. Créer un devis");
                Console.WriteLine("16. Valider un devis");
                Console.WriteLine("17. Voir mes factures");
                Console.WriteLine("18. Payer une facture");
                Console.WriteLine("0. Retour");

                string choix = Console.ReadLine();
                if (choix == "0") break;

                switch (choix)
                {
                    case "1": ConsulterVoitures(); break;
                    case "2": ConsulterPieces(); break;
                    case "3": AcheterVoiture(); break;
                    case "4": AcheterPiece(); break;
                    case "5": DemanderReparation(); break;
                    case "6": VoitureClient.AjouterVoiture(Id); break;
                    case "7": VoitureClient.ModifierVoiture(Id); break;
                    case "8": VoitureClient.SupprimerVoiture(Id); break;
                    case "9": VoitureClient.ConsulterVoitures(Id); break;
                    case "10": VoitureClient.ImporterDepuisJson(Id); break;
                    case "11": ReparationClient.AjouterReparation(Id); break;
                    case "12": ReparationClient.AfficherHistorique(Id); break;
                    case "13": EntretienClient.AjouterEntretien(Id); break;
                    case "14": EntretienClient.VoirEntretiensClient(Id); break;
                    case "15": DevisClient.CreerDevis(Id); break;
                    case "16": DevisClient.ValiderDevis(Id); break;
                    case "17": Facture.AfficherFacturesClient(Id); break;
                    case "18": PaiementClient.PayerFacture(Id); break;
                    default: Console.WriteLine("Choix invalide."); break;
                }

                Garage.Pause();
            }
        }

        public void ConsulterVoitures()
        {
            var voitures = Voiture.ChargerDepuisCSV();
            Console.WriteLine("========= Voitures disponibles ==========");
            foreach (var v in voitures)
            {
                Console.WriteLine($"{v.marque} - {v.modele} ({v.annee}), Prix: {v.prix_approximatif}€");
            }
        }

        public void ConsulterPieces()
        {
            var pieces = Proprietaire.LirePieces();
            Console.WriteLine("========= Pièces disponibles ==========");
            foreach (var p in pieces)
            {
                Console.WriteLine($"{p.nom_piece} - Prix: {p.prix}€");
            }
        }

        public void AcheterVoiture()
        {
            var voitures = Voiture.ChargerDepuisCSV();

            Console.Write("Entrez la marque de la voiture : ");
            string marque = Console.ReadLine();

            Console.Write("Entrez le modèle : ");
            string modele = Console.ReadLine();

            var voiture = voitures.FirstOrDefault(v => v.marque == marque && v.modele == modele);
            if (voiture == null)
            {
                Console.WriteLine(" Voiture introuvable.");
                return;
            }

            Console.WriteLine($"Le prix est de {voiture.prix_approximatif}€. Veuillez effectuer le paiement.");
            PaiementClient paiementClient= new PaiementClient();
            paiementClient.EffectuerPaiement(voiture.prix_approximatif);

            voitures.Remove(voiture);
            Voiture.SauvegarderDansCSV(voitures);

            Console.WriteLine(" Achat confirmé. Merci .");
        }

        public void AcheterPiece()
        {
            var pieces = Proprietaire.LirePieces();

            Console.Write("Nom de la pièce à acheter : ");
            string nom = Console.ReadLine();

            var piece = pieces.FirstOrDefault(p => p.nom_piece == nom);
            if (piece == null)
            {
                Console.WriteLine(" Pièce introuvable.");
                return;
            }

            Console.WriteLine($"Le prix est de {piece.prix}€. Veuillez effectuer le paiement.");
            PaiementClient paiement= new PaiementClient();
            paiement.EffectuerPaiement(piece.prix);

            pieces.Remove(piece);
            Proprietaire.SauvegarderPieces(pieces);

            Console.WriteLine(" Pièce achetée avec succès .");
        }

        public void DemanderReparation()
        {
            Console.Write("Entrez la description du problème : ");
            string probleme = Console.ReadLine();

            Console.WriteLine("Demande de réparation enregistrée. Un technicien vous contactera bientôt !");
        }
    }
}
