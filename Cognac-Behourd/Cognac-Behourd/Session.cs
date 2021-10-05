using System;
using System.Collections.Generic;
using System.Text;

namespace Cognac_Behourd
{
    class Session
    {
        private List<Personne> ListePersonnes;


        public Session(List<Personne> listePersonnes)
        {
            this.ListePersonnes = listePersonnes;
        }

        public void GeneratePartie()
        {
            Console.WriteLine("Voullez vous créer une partie ? 0: oui, N: non");
            Partie partie = new(this.ListePersonnes);
            partie.GenerateEquipes();
        }
    }
}
