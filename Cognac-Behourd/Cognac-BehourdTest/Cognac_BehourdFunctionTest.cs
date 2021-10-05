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

            partie.lancer_partie();

            Assert.Equals(partie.ListeEquipe[0].Count, partie.ListeEquipe[1].Count);
        }

        [TestMethod]
        public void Verifier_que_les_equipes_sont_equlibre_en_poid_quand_les_moyenne_ont_mois_de_10kg_de_difference()
        {

            List<Personne> ListeParticipant = new List<Personne>();

            ListeParticipant.Add(new Personne("Jo", "e", 65, 2004));

            ListeParticipant.Add(new Personne("Yank", "a", 75, 1993));

            ListeParticipant.Add(new Personne("Jack", "b", 52, 2005));

            ListeParticipant.Add(new Personne("Ber", "c", 70, 2001));

            ListeParticipant.Add(Personne("Frank", "d", 72, 1991));

            Partie partie = new Partie(ListeParticipant);

            partie.lancer_partie();

            int i1 = partie.ListeEquipe[0].ListePersonne.Count;
            int i2 = partie.ListeEquipe[1].ListePersonne.Count;
            float moyenne1 = 0;
            float moyenne2 = 0;

            foreach (Personne pe in partie.ListeEquipe[0].ListePersonne)
            {
                moyenne1 = moyenne1 + pe.Poid;
            }
            moyenne1 = moyenne1 / i1;
            foreach (Personne pe in partie.ListeEquipe[0].ListePersonne)
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


    }
}
