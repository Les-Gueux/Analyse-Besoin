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

        public List<Equipe> CollectionEquipes { get; set; } = new();

        private const int NUMBER_MAX_BY_EQU = 2;

        public Partie(List<Personne> collectionPersonne)
        {
            this.CollectionPersonnes = collectionPersonne;
        }

        public void EquilibreWeightEquipes(Equipe minWeight, Equipe maxWeight)
        {
            this.CollectionEquipes.Add(minWeight);
            this.CollectionEquipes.Add(maxWeight);

            while (minWeight.TotalWeight > maxWeight.TotalWeight)
            {
                var minWeightPersonne = minWeight.ListePersonne.Min();
                minWeight.ListePersonne.Remove(minWeightPersonne);
                maxWeight.ListePersonne.Add(minWeightPersonne);

                var maxWeightPersonne = maxWeight.ListePersonne.Max();
                maxWeight.ListePersonne.Remove(maxWeightPersonne);
                minWeight.ListePersonne.Add(maxWeightPersonne);
            }
        }

        public void GenerateCollectionEquipe()
        {

            var nbrPersonneByEquipe = this.CollectionPersonnes.Count / NUMBER_MAX_BY_EQU;
            var moyenneWeightByEquipe = this.CollectionPersonnes.Sum(p => p.Poid) / nbrPersonneByEquipe;
            Personne personne = null;

            Equipe equipe1 = new("E1", this.CollectionPersonnes.Skip(nbrPersonneByEquipe).ToList());
            Equipe equipe2 = new("E2", this.CollectionPersonnes.SkipLast(nbrPersonneByEquipe).ToList());

            if (this.CollectionPersonnes.Count % NUMBER_MAX_BY_EQU != 0)
            {
                personne = this.CollectionPersonnes.ElementAt(nbrPersonneByEquipe + 1);
            }

            if(equipe1.TotalWeight == equipe2.TotalWeight && personne == null)
            {
                this.CollectionEquipes.Add(equipe1);
                this.CollectionEquipes.Add(equipe2);
            }

            if (equipe1.TotalWeight != equipe2.TotalWeight)
            {
                this.EquilibreWeightEquipes(equipe1.TotalWeight < equipe2.TotalWeight ? equipe1 : equipe2, equipe1.TotalWeight > equipe2.TotalWeight ? equipe1 : equipe2);
            }
            if(personne != null)
            {
                if(this.CollectionEquipes[0].TotalWeight < this.CollectionEquipes[1].TotalWeight)
                {
                    this.CollectionEquipes[0].ListePersonne.Add(personne);
                }
                else
                {
                    this.CollectionEquipes[1].ListePersonne.Add(personne);
                }
            }
        }
    }
}
