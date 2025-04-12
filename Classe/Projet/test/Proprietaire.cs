using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using Newtonsoft.Json;

using Projetfinal.Classe.Projet.test;

namespace Projet.test
{
	public class Proprietaire : Utilisateur
	{
        public override void Afficher()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("========= Menu Propriétaire =========");
                Console.WriteLine("1. Gérer les voitures");
                Console.WriteLine("2. Gérer les utilisateurs");
                Console.WriteLine("3. Gérer les pièces");
                Console.WriteLine("0. Retour");

                string choix = Console.ReadLine();

                if (choix == "0") break;

                switch (choix)
                {
                    case "1": GererVoitures(); break;
                    case "2": GererUtilisateurs(); break;
                    case "3": CompleterPiecesDepuisCSV(); GererPieces(); break;
                    default: Console.WriteLine("Choix invalide"); break;
                }
            }
        }

/*------------------------------------------------------------------------------------------------------------------------------------------------*/
        static void GererVoitures()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("========= Gestion des Voitures =========");
                Console.WriteLine("1. Ajouter une voiture");
                Console.WriteLine("2. Modifier une voiture");
                Console.WriteLine("3. Supprimer une voiture");
                Console.WriteLine("0. Retour");
                string choix = Console.ReadLine();

                if (choix == "0") break;
                Voiture v = new Voiture();
                switch (choix)
                {
                    case "1": AjouterAuCSV(v); break;
                    case "2": ModifierVoiture(); break;
                    case "3": SupprimerVoiture(); break;
                    default: Console.WriteLine("Choix invalide"); break;
                }

                Console.WriteLine("Appuyez sur une touche pour continuer...");
                Console.ReadKey();
            }
        }
        public static void AjouterAuCSV(Voiture voiture)
        {
            Console.WriteLine("Entrez la marque de la voiture :");
            voiture.marque = Console.ReadLine();
            Console.WriteLine("Entrez le modele  de la voiture :");
            voiture.modele = Console.ReadLine();
            Console.WriteLine("Entrez l'annee de la voiture :");
            voiture.annee = Console.ReadLine();
            Console.WriteLine("Entrez la categorie de la voiture :");
            voiture.categorie = Console.ReadLine();
            Console.WriteLine("Entrez le prix approximatif de la voiture :");
            voiture.prix_approximatif = int.Parse(Console.ReadLine());
            Console.WriteLine("Entrez le kilometrage de la voiture :");
            voiture.kilometrage = int.Parse(Console.ReadLine());
            Console.WriteLine("Entrez la couleur de la voiture :");
            voiture.couleur = Console.ReadLine();
            Console.WriteLine("Entrez le type de carburant de la voiture :");
            voiture.type_carburant = Console.ReadLine();
            Console.WriteLine("Entrez la transmission de la voiture :");
            voiture.transmission = Console.ReadLine();
            Console.WriteLine("Entrez l'achat général de la voiture :");
            voiture.achat_general = Console.ReadLine();
            Console.WriteLine("Entrez le vin de la voiture :");
            voiture.vin = Console.ReadLine();
            Console.WriteLine("Entrez le proprietaire  de la voiture :");
            voiture.proprietaire = Console.ReadLine();
            Console.WriteLine("Entrez la date d'achat de la voiture :");
            voiture.date_achat = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Entrez la derniere révision de la voiture :");
            voiture.derniere_revesion = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Entrez la garantie restante de la voiture :");
            voiture.garantie_restante = Console.ReadLine();
            Console.WriteLine("Entrez l'assurance de la voiture :");
            voiture.assurance = Console.ReadLine();

            string cheminFichier = "C:\\Users\\X415\\source\\repos\\Projetfinal\\Classe\\Projet\\voitures_db.csv";

            using (var stream = File.Open(cheminFichier, FileMode.Append))
            using (var writer = new StreamWriter(stream))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecord(voiture);
                writer.WriteLine();
            }
        }

        public static void ModifierVoiture()
        {
            Console.Write("Entrez la marque de la voiture : ");
            string marque = Console.ReadLine();

            Console.Write("Entrez le modèle de la voiture : ");
            string modele = Console.ReadLine();

            Console.Write("Entrez le kilométrage de la voiture : ");
            int kilometrage = int.Parse(Console.ReadLine());

            var voitures = Voiture.ChargerDepuisCSV();

            Voiture voiture = null;
            foreach (var v in voitures)
            {
                if (v.marque == marque && v.modele == modele && v.kilometrage == kilometrage)
                {
                    voiture = v;
                    break;
                }
            }

            if (voiture == null)
            {
                Console.WriteLine(" Voiture introuvable.");
                return;
            }

            Console.WriteLine(" Voiture trouvée.Veuillez modifier ses informations  :");

            Console.Write("Nouvelle marque : ");
            string saisie = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(saisie)) voiture.marque = saisie;

            Console.Write("Nouveau modèle : ");
            saisie = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(saisie)) voiture.modele = saisie;

            Console.Write("Nouvelle année : ");
            saisie = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(saisie)) voiture.annee = saisie;

            Console.Write("Nouvelle catégorie : ");
            saisie = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(saisie)) voiture.categorie = saisie;

            Console.Write("Nouveau prix approximatif : ");
            saisie = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(saisie)) voiture.prix_approximatif = int.Parse(saisie);

            Console.Write("Nouveau kilométrage : ");
            saisie = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(saisie)) voiture.kilometrage = int.Parse(saisie);

            Console.Write("Nouvelle couleur : ");
            saisie = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(saisie)) voiture.couleur = saisie;

            Console.Write("Nouveau type de carburant : ");
            saisie = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(saisie)) voiture.type_carburant = saisie;

            Console.Write("Nouvelle transmission : ");
            saisie = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(saisie)) voiture.transmission = saisie;

            Console.Write("Nouvel achat général : ");
            saisie = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(saisie)) voiture.achat_general = saisie;

            Console.Write("Nouveau VIN : ");
            saisie = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(saisie)) voiture.vin = saisie;

            Console.Write("Nouveau propriétaire : ");
            saisie = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(saisie)) voiture.proprietaire = saisie;

            Console.Write("Nouvelle date d'achat (jj-mm-aaaa) : ");
            saisie = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(saisie)) voiture.date_achat = DateTime.Parse(saisie);

            Console.Write("Nouvelle date de révision (jj-mm-aaaa) : ");
            saisie = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(saisie)) voiture.derniere_revesion = DateTime.Parse(saisie);

            Console.Write("Nouvelle garantie restante : ");
            saisie = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(saisie)) voiture.garantie_restante = saisie;

            Console.Write("Nouvelle assurance : ");
            saisie = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(saisie)) voiture.assurance = saisie;

            // Réécriture du fichier CSV
            string cheminFichier = "C:\\Users\\X415\\source\\repos\\Projetfinal\\Classe\\Projet\\voitures_db.csv";
            using var writer = new StreamWriter(cheminFichier);
            using var csv = new CsvHelper.CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords(voitures);

            Console.WriteLine(" Modifications enregistrées avec succès.");
        }

        public static void SupprimerVoiture()
        {
            List<Voiture> voitures;
            using (var reader = new StreamReader("C:\\Users\\X415\\source\\repos\\Projetfinal\\Classe\\Projet\\voitures_db.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                voitures = csv.GetRecords<Voiture>().ToList();
            }

            Console.Write("Marque de la voiture : ");
            string marque = Console.ReadLine();

            Console.Write("Modèle : ");
            string modele = Console.ReadLine();

            Console.Write("Kilométrage : ");
            if (!int.TryParse(Console.ReadLine(), out int kilometrage))
            {
                Console.WriteLine(" Kilométrage invalide.");
                return;
            }
            var voiture = voitures.FirstOrDefault(v =>
                v.marque == marque &&
                v.modele == modele &&
                v.kilometrage == kilometrage
            );

            if (voiture == null)
            {
                Console.WriteLine(" Voiture introuvable.");
                return;
            }

            voitures.Remove(voiture);

            using (var writer = new StreamWriter("C:\\Users\\X415\\source\\repos\\Projetfinal\\Classe\\Projet\\voitures_db.csv"))
            using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csvWriter.WriteRecords(voitures);
            }

            Console.WriteLine(" Voiture supprimée avec succès .");
        }

/*-------------------------------------------------------------------------------------------------------------------------------------------------*/

        static void GererUtilisateurs()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("========= Gestion des Utilisateurs =========");
                Console.WriteLine("1. Ajouter un utilisateur");
                Console.WriteLine("2. Modifier un utilisateur");
                Console.WriteLine("3. Supprimer un utilisateur");
                Console.WriteLine("0. Retour");

                string choix = Console.ReadLine();

                if (choix == "0") break;

                switch (choix)
                {
                    case "1": AjouterUtilisateur(); break;
                    case "2": ModifierUtilisateur(); break;
                    case "3": SupprimerUtilisateur(); break;
                    default: Console.WriteLine("Choix invalide"); break;
                }

                Console.WriteLine("Appuyez sur une touche pour continuer...");
                Console.ReadKey();
            }
        }
        public static List<UtilisateurData> LireUtilisateurs()
        {
            string chemin = "C:\\Users\\X415\\source\\repos\\Projetfinal\\Classe\\Projet\\test\\utilisateurs.json";

            if (File.Exists(chemin))
            {
                string json = File.ReadAllText(chemin);
                return JsonConvert.DeserializeObject<List<UtilisateurData>>(json);
            }

            return new List<UtilisateurData>();
        }

        public static void SauvegarderUtilisateurs(List<UtilisateurData> utilisateurs)
        {
            string json = JsonConvert.SerializeObject(utilisateurs, Formatting.Indented);
            File.WriteAllText("C:\\Users\\X415\\source\\repos\\Projetfinal\\Classe\\Projet\\test\\utilisateurs.json", json);
        }

        public static void AjouterUtilisateur()
        {
            var utilisateurs = LireUtilisateurs();

            Console.Write("Id : ");
            string id = Console.ReadLine();
            Console.Write("Mot de passe : ");
            string mdp = Console.ReadLine();
            Console.Write("Rôle : ");
            string role = Console.ReadLine();

            utilisateurs.Add(new UtilisateurData { Id = id, motdepasse = mdp, role = role });
            SauvegarderUtilisateurs(utilisateurs);
            Console.WriteLine(" Utilisateur ajouté.");
        }

        public static void ModifierUtilisateur()
        {
            var utilisateurs = LireUtilisateurs();

            Console.Write("Id de l’utilisateur à modifier : ");
            string id = Console.ReadLine();

            var utilisateur = utilisateurs.Find(u => u.Id == id);
            if (utilisateur == null)
            {
                Console.WriteLine("Utilisateur introuvable.");
                return;
            }

            Console.Write("Nouveau mot de passe : ");
            utilisateur.motdepasse = Console.ReadLine();

            Console.Write("Nouveau rôle : ");
            utilisateur.role = Console.ReadLine();

            SauvegarderUtilisateurs(utilisateurs);
            Console.WriteLine(" Utilisateur modifié avec succés.");
        }

        public static void SupprimerUtilisateur()
        {
            var utilisateurs = LireUtilisateurs();

            Console.Write("Id à supprimer : ");
            string id = Console.ReadLine();

            var utilisateur = utilisateurs.Find(u => u.Id == id);
            if (utilisateur != null)
            {
                utilisateurs.Remove(utilisateur);
                SauvegarderUtilisateurs(utilisateurs);
                Console.WriteLine("✅ Supprimé.");
            }
            else
            {
                Console.WriteLine("Utilisateur introuvable.");
            }
        }

/*-------------------------------------------------------------------------------------------------------------------------------------------------*/

        static void GererPieces()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("== Gestion des Pièces ==");
                Console.WriteLine("1. Ajouter une piece)");
                Console.WriteLine("2. Modifierr une pièce");
                Console.WriteLine("3. Supprimer une pièce");
                Console.WriteLine("0. Retour");

                string choix = Console.ReadLine();

                if (choix == "0") break;
               
                switch (choix)
                {
                    case "1": AjouterPiece(); break;
                    case "2": ModifierPiece(); break;
                    case "3": SupprimerPiece(); break;
                    default: Console.WriteLine("Choix invalide"); break;
                }

                Console.WriteLine("Appuyez sur une touche pour continuer...");
                Console.ReadKey();
            }
        }
        

        public static void CompleterPiecesDepuisCSV()
        {
            string cheminCSV = "C:\\Users\\X415\\source\\repos\\Projetfinal\\Classe\\Projet\\reparations_db.csv";
            string cheminJSON = "C:\\Users\\X415\\source\\repos\\Projetfinal\\Classe\\Projet\\test\\pieces.json";

            try
            {
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HeaderValidated = null,
                    MissingFieldFound = null
                };

                using var reader = new StreamReader(cheminCSV);
                using var csv = new CsvReader(reader, config);
                var reparations = csv.GetRecords<Reparation>().ToList();

                // Charger les pièces déjà présentes dans le JSON
                List<PieceData> piecesExistantes = new List<PieceData>();
                if (File.Exists(cheminJSON))
                {
                    var contenuJson = File.ReadAllText(cheminJSON);
                    piecesExistantes = JsonConvert.DeserializeObject<List<PieceData>>(contenuJson);
                }

                
                foreach (var rep in reparations)
                {
                    bool existe = piecesExistantes.Any(p => p.nom_piece == rep.nom_de_piece);
                    if (!existe)
                    {
                        piecesExistantes.Add(new PieceData
                        {
                            nom_piece = rep.nom_de_piece,
                            prix = rep.prix_approx
                        });
                    }
                }

                
                string jsonFinal = JsonConvert.SerializeObject(piecesExistantes, Formatting.Indented);
                File.WriteAllText(cheminJSON, jsonFinal);

                Console.WriteLine(" Données du CSV ajoutées dans pieces.json .");
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Erreur : " + ex.Message);
            }
        }

        public static List<PieceData> LirePieces()
        {
            string chemin = "C:\\Users\\X415\\source\\repos\\Projetfinal\\Classe\\Projet\\test\\pieces.json";

            if (File.Exists(chemin))
            {
                string json = File.ReadAllText(chemin);
                return JsonConvert.DeserializeObject<List<PieceData>>(json);
            }

            return new List<PieceData>();
        }
        public static void SauvegarderPieces(List<PieceData> pieces)
        {
            string chemin = "C:\\Users\\X415\\source\\repos\\Projetfinal\\Classe\\Projet\\test\\pieces.json";
            string json = JsonConvert.SerializeObject(pieces, Formatting.Indented);
            File.WriteAllText(chemin, json);
        }

        public static void AjouterPiece()
        {
            var pieces = LirePieces();

            Console.Write("Nom de la pièce : ");
            string nom = Console.ReadLine();

            Console.Write("Prix : ");
            int prix = int.Parse(Console.ReadLine());

            pieces.Add(new PieceData { nom_piece = nom, prix = prix });
            SauvegarderPieces(pieces);

            Console.WriteLine("Pièce ajoutée avec succés.");
        }

        public static void ModifierPiece()
        {
            var pieces = LirePieces();

            Console.Write("Nom de la pièce à modifier : ");
            string nom = Console.ReadLine();

            var piece = pieces.Find(p => p.nom_piece == nom);
            if (piece == null)
            {
                Console.WriteLine("Pièce introuvable.");
                return;
            }

            Console.Write("Nouveau prix : ");
            int nouveauPrix = int.Parse(Console.ReadLine());

            piece.prix = nouveauPrix;
            SauvegarderPieces(pieces);

            Console.WriteLine("Pièce modifiée avec succés .");
        }

        public static void SupprimerPiece()
        {
            var pieces = LirePieces();

            Console.Write("Nom de la pièce à supprimer : ");
            string nom = Console.ReadLine();

            var piece = pieces.Find(p => p.nom_piece == nom);
            if (piece != null)
            {
                pieces.Remove(piece);
                SauvegarderPieces(pieces);
                Console.WriteLine("Pièce supprimée avec succés.");
            }
            else
            {
                Console.WriteLine("Pièce introuvable.");
            }
        }

    }
}
