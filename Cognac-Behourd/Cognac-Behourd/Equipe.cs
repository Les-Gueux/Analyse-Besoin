using System;
using System.Collections.Generic;
using System.Text;

namespace Cognac_Behourd
{
    public class Equipe
    {
        private string Numero;
        private List<Personne> ListePersonne;

        public Equipe( string numero, List<Personne> listePersonne)
        {
            Numero = numero;
            ListePersonne = listePersonne;
        }
    }
}
