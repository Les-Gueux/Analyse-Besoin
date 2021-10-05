using System;
using System.Collections.Generic;
using System.Text;

namespace Cognac_Behourd
{
    public class Personne
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int Poid { get; set; }
        public int Anciente { get; set; }

        public Personne(string nom, string prenom, int poid, int anciente)
        {
            Nom = nom;
            Prenom = prenom;
            Poid = poid;
            Anciente = anciente;
        }
    }
}
