using Cognac_Behourd;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;


namespace Cognac_BehourdTest
{
    [TestClass]
    public class Cognac_BehourdFunctionTest
    {
        [TestMethod]
        public void vérifier_que_les_équipes_sont_equlibré_en_nombre_quand_les_joueur_sont_paire()
        {

            List<Personne> ListeParticipant = new List<Personne>();

            ListeParticipant.Add(new Personne("Jo", "e", 65, 2004));

            ListeParticipant.Add(new Personne("Yank", "a", 75, 1993));

            ListeParticipant.Add(new Personne("Jack", "b", 52, 2005));

            ListeParticipant.Add(new Personne("Ber", "c", 70, 2001));

            Partie partie = new Partie(ListeParticipant);

            partie.GenerateCollectionEquipe();

            Assert.AreEqual(partie.CollectionEquipes[0].ListePersonne.Count, partie.CollectionEquipes[1].ListePersonne.Count);
        }

        [TestMethod]
        public void Verifier_que_les_equipes_sont_equlibre_en_poid_quand_les_moyenne_ont_mois_de_10kg_de_difference()
        {

            List<Personne> ListeParticipant = new List<Personne>();

            ListeParticipant.Add(new Personne("Jo", "e", 65, 2004));

            ListeParticipant.Add(new Personne("Yank", "a", 75, 1993));

            ListeParticipant.Add(new Personne("Jack", "b", 52, 2005));

            ListeParticipant.Add(new Personne("Ber", "c", 70, 2001));


            Partie partie = new Partie(ListeParticipant);

            partie.GenerateCollectionEquipe();

            int i1 = partie.CollectionEquipes[0].ListePersonne.Count;
            int i2 = partie.CollectionEquipes[1].ListePersonne.Count;
            float moyenne1 = 0;
            float moyenne2 = 0;

            foreach (Personne pe in partie.CollectionEquipes[0].ListePersonne)
            {
                moyenne1 = moyenne1 + pe.Poid;
            }
            moyenne1 = moyenne1 / i1;
            foreach (Personne pe in partie.CollectionEquipes[0].ListePersonne)
            {
                moyenne2 = moyenne2 + pe.Poid;
            }
            moyenne2 = moyenne2 / i2;

            Assert.IsTrue(moyenne1<52 && moyenne2<52 ||
                moyenne1<57 && moyenne1>52 && moyenne2 < 57 && moyenne2 > 52 ||
                moyenne1 <= 63 && moyenne1 > 57 && moyenne2 <= 63 && moyenne2 > 57 ||
                moyenne1 <= 69 && moyenne1 > 63 && moyenne2 <= 69 && moyenne2 > 63 ||
                moyenne1 <= 75 && moyenne1 > 69 && moyenne2 <= 75 && moyenne2 > 69 ||
                moyenne1 <= 81 && moyenne1 > 75 && moyenne2 <= 81 && moyenne2 > 75 ||
                moyenne1 <= 91 && moyenne1 > 81 && moyenne2 <= 91 && moyenne2 > 81 ||
                moyenne1 > 91 && moyenne2 > 91);
        }

        [TestMethod]
        public void Verifier_que_les_equipes_sont_equlibre_en_age()
        {
            List<Personne> ListeParticipant = new List<Personne>();

            ListeParticipant.Add(new Personne("Jo", "e", 65, 2004));

            ListeParticipant.Add(new Personne("Yank", "a", 75, 1993));

            ListeParticipant.Add(new Personne("Jack", "b", 52, 2005));

            ListeParticipant.Add(new Personne("Ber", "c", 70, 2001));


            Partie partie = new Partie(ListeParticipant);

            partie.GenerateCollectionEquipe();

            int i1 = partie.CollectionEquipes[0].ListePersonne.Count;
            int i2 = partie.CollectionEquipes[1].ListePersonne.Count;
            float moyenne1 = 0;
            float moyenne2 = 0;

            foreach (Personne pe in partie.CollectionEquipes[0].ListePersonne)
            {
                moyenne1 = moyenne1 + pe.Anciente;
            }
            moyenne1 = moyenne1 / i1;
            foreach (Personne pe in partie.CollectionEquipes[0].ListePersonne)
            {
                moyenne2 = moyenne2 + pe.Anciente;
            }
            moyenne2 = moyenne2 / i2;

            Assert.IsTrue(moyenne1 - 5 <= moyenne2 && moyenne2 <= moyenne1 + 5);
        }


    }
}
