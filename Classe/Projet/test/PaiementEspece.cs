using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projetfinal.Classe.Projet.test
{
    public class PaiementEspeces : IPaiement
    {
        public void EffectuerPaiement(double montant)
        {
            Console.WriteLine("=== Paiement en espèces ===");
            Console.WriteLine($"Merci de mettre les {montant}€ au comptoir.");
            Console.WriteLine(" Paiement en espèces enregistré.");
        }
    }

}
