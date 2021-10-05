using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;


namespace Cognac_BehourdTest
{
    [TestClass]
    public class Cognac_BehourdFunctionTest
    {
        [TestMethod]
        public void verifier_que_les_equipes_sont_equlibre_en_nombre_quand_les_joueur_sont_paire()
        {
            Session s = new Session();

            List<Personne> ListePaticipant = new List<Personne>();

            Personne p = new Personne("Jo", "e", 65, 2004);
            ListePaticipant.Add(p);

            p = new Personne("Yank", "a", 75, 1993);
            ListePaticipant.Add(p);

            p = new Personne("Jack", "b", 52, 2005);
            ListePaticipant.Add(p);

            p = new Personne("Ber", "c", 70, 2001);
            ListePaticipant.Add(p);

            s.creation_equipe(ListePaticipant);

            Assert.Equals(s.ListeEquipe[0].ListePersonne.Count, s.ListeEquipe[1].ListePersonne.Count);
        }

        
    }
}
