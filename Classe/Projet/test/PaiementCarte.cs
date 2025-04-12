using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projetfinal.Classe.Projet.test
{
    public class PaiementCarte : IPaiement
    {
        public void EffectuerPaiement(double montant)
        {
            Console.WriteLine("=== Paiement par carte bancaire ===");
            Console.Write("Numéro de la  carte  : ");
            string numero = Console.ReadLine();

            Console.Write("Date d4expiration (MM/YY) : ");
            string date = Console.ReadLine();

            Console.Write("CVV : ");
            string cvv = Console.ReadLine();

            Console.WriteLine($" Paiement de {montant}€ effectué par votre carte.");
        }
    }

}
