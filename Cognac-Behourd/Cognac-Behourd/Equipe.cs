using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cognac_Behourd
{
    public class Equipe
    {
        public string Numero { get; set; }
        public List<Personne> ListePersonne { get; set; }

        public int TotalWeight { get => this.ListePersonne.Sum(p => p.Poid); }

        public bool IsMinWeight { get; set; }

        public Equipe( string numero, List<Personne> listePersonne)
        {
            Numero = numero;
            ListePersonne = listePersonne;
            this.IsMinWeight = false;
        }
    }
}
