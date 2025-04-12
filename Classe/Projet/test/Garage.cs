using System;
using Projetfinal.Classe.Projet.test;

namespace Projet.test
{
    public static class Garage
    {

        public static void Pause()
        {
            Console.WriteLine("\nAppuyez sur une touche pour continuer...");
            Console.ReadKey();
        }
        public static void AfficherReparation(ReparationClient r)
        {
            Console.WriteLine($"{r.DateReparation.ToShortDateString()} |  {r.Voiture} |  {r.TypeIntervention} |  {r.CoutEstime} €");
            Console.WriteLine($" Description : {r.Description}");
            if (r.PiecesUtilisees != null && r.PiecesUtilisees.Count > 0)
                Console.WriteLine($" Pièces : {string.Join(", ", r.PiecesUtilisees)}");
            
        }


    }
}