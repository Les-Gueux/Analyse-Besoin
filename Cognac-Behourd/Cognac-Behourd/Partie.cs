using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognac_Behourd
{
    public class Partie
    {
        public List<Personne> CollectionPersonnes { get; set; }

        private List<List<Equipe>> CollectionEquipes;

        public Partie(List<Personne> collectionPersonne)
        {
            this.CollectionPersonnes = collectionPersonne;
        }

        // Poids des 2 Equipes doivent être équilibré
        // Les 2 equipes doivent avoir le même nombre de personnes

        public void GenerateEquipes()
        {
            // Calculer la moitié de la liste de personnes
            // Calculer la moyenne global de combien doit être

            var nbrPersonneByEquipe = this.CollectionPersonnes.Count / 2;
            
        }
    }
}
