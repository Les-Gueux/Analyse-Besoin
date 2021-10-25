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
            bool isGameIsEnd = false;
            while (isGameIsEnd == false)
            {
                try
                {
                    Console.WriteLine("Voulez vous créer une nouvelle manche ? oui: o, non: n");
                    choice = Console.ReadLine();

                    if (choice != "o" && choice != "n" ) throw new ArgumentException();

                    else if (choice == "o")
                    {
                        var inputVisitor = "";
                        while (inputVisitor != "3")
                        {
                            Console.WriteLine("Voulez vous avant de créer la manche : : \n\n 1. Ajouter un visiteur \n 2. Retirer un joueur \n 3. Continuer");
                            inputVisitor = Console.ReadLine();

                            if (inputVisitor != "1" && inputVisitor != "2" && inputVisitor != "3") throw new ArgumentException();

                            if (inputVisitor == "1")
                            {
                                AdherentManager.AddNewVisitor(this.ListePersonnes);
                            }
                            if (inputVisitor == "2")
                            {
                                Console.WriteLine("Veuillez indiquer le nom du joueur à retirer de la partie");
                                var inputRemovePersonne = "";
                                inputRemovePersonne = Console.ReadLine();
                                AdherentManager.RemoveUser(this.ListePersonnes, inputRemovePersonne);
                            }
                        }
                        Partie partie = new(this.ListePersonnes);
                        partie.GenerateCollectionEquipe();
                        printEquipesPartie(partie);
                    }

                    else if (choice == "n")
                    {
                        isGameIsEnd = true;
                    }

                }
                catch (ArgumentException)
                {
                    Console.Clear();
                    Console.WriteLine("Veuillez indiquer une réponse valide!");
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
