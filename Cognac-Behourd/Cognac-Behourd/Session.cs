using Cognac_Behourd.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cognac_Behourd
{
    class Session
    {
        private List<Personne> ListePersonnes;
        private AdherentManager managerAdherent;


        public Session(List<Personne> listePersonnes)
        {
            this.ListePersonnes = listePersonnes;
        }

        public void GeneratePartie()
        {
            var choice = "";
            while (choice != "q")
            {
                try
                {
                    Console.WriteLine("Voulez vous créer une partie ? oui: o, non: n, quiter: q");
                    choice = Console.ReadLine();

                    if (choice != "o" && choice != "n" && choice != "q") throw new ArgumentException();

                    if (choice == "o")
                    {
                        Console.WriteLine("Voulez vous ajouter un visiteur ? oui: o, non: n");
                        choice = Console.ReadLine();

                        if (choice != "o" && choice != "n") throw new ArgumentException();

                        if( choice == "o")
                        {
                            AdherentManager.AddNewVisitor(this.ListePersonnes);
                        }
                             
                        Partie partie = new(this.ListePersonnes);
                        partie.GenerateCollectionEquipe();
                        printEquipesPartie(partie);
                    }

                }
                catch (ArgumentException)
                {
                    Console.Clear();
                    GeneratePartie();
                }

            }
        }

        private void printEquipesPartie(Partie partie)
        {
            
            var collumnName = "Nom";
            var collumnFirstName = "Prenom";
            var collumnWeight = "Poids";
            var collumnAncient = "Année Adhesion";

            var menu = "";

            partie.CollectionEquipes.ForEach(equipe =>
            {
                menu += $"Numero de l'équipe: {equipe.Numero}\n{collumnName}|{collumnFirstName}|{collumnWeight}|{collumnAncient}\n";
                equipe.ListePersonne.ForEach(personne => {
                    menu += $"{personne.Nom}|{personne.Prenom}|{personne.Poid}|{personne.Anciente}\n";
                });
                menu += "\n";
            });

            Console.WriteLine(menu);
        }
    }
}
