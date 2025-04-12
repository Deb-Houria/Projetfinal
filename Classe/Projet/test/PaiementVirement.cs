using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projetfinal.Classe.Projet.test
{
    public class PaiementVirement : IPaiement
    {
        public void EffectuerPaiement(double montant)
        {
            Console.WriteLine("=== Paiement par virement bancaire ===");
            Console.WriteLine("Merci d’effectuer le virement vers notre compte :");
            Console.WriteLine("IBAN : FR00 1234 5678 9101 1121 3141 516");
            Console.WriteLine("BIC : ABCDFRPPXXX");
            Console.WriteLine($"Le montant à transférer est : {montant}€");
            Console.WriteLine("Paiement en attente de confirmation.");
        }
    }

}
