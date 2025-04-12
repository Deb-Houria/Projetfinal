using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projetfinal.Classe.Projet.test
{
    public class PaiementClient :IPaiement 
    {
        public static void PayerFacture(string idClient)
        {
            Console.Write("Montant à payer : ");
            double montant = double.Parse(Console.ReadLine());

            Console.WriteLine("Méthode de paiement : ");
            Console.WriteLine("1. Carte");
            Console.WriteLine("2. Espèces");
            Console.WriteLine("3. Virement");
            Console.Write("Votre choix : ");
            string choix = Console.ReadLine();

            IPaiement paiement = choix switch
            {
                "1" => new PaiementCarte(),
                "2" => new PaiementEspeces(),
                "3" => new PaiementVirement(),
                _ => null
            };

            if (paiement != null)
            {
                paiement.EffectuerPaiement(montant);
            }
            else
            {
                Console.WriteLine(" Méthode de paiement invalide.");
            }
        }
        public void EffectuerPaiement(double montant) { }
    }

}
