using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;


namespace Cognac_BehourdTest
{
    [TestMethod]
    public void verifier_que_les_equipes_sont_equlibre_en_nombre_quand_les_joueur_sont_paire()
    {
        Session s = new Session();

        List<Personne> ListePaticipant = new List<Personne>();

        Personne p = new Personne("Jo", 65, 17);
        ListePaticipant.Add(p);

        p = new Personne("Yank", 75, 27);
        ListePaticipant.Add(p);

        p = new Personne("Ber", 70, 20);
        ListePaticipant.Add(p);

        p = new Personne("Frank", 72, 30);
        ListePaticipant.Add(p);

        s.creation_equipe(ListePaticipant);

        Assert.Equals(s.ListeEquipe[0].ListePersonne.Count, s.ListeEquipe[1].ListePersonne.Count);
    }
}
}
