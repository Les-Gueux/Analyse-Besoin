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

            session.lancer_partie();

            Assert.Equals(partie.ListeEquipe[0].Count, partie.ListeEquipe[1].Count);
        }

        
    }
}
