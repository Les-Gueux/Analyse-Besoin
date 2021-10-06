using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognac_Behourd.Utils
{
    public class MenuManager
    {

        private List<Personne> collectionPersonne;
        private ManageExcel manageExcel;

        public MenuManager()
        {
            this.manageExcel = new ManageExcel();
            
            PrintPrincipalMenu();
        }

        private void PrintPrincipalMenu()
        {
            this.collectionPersonne = this.manageExcel.GetPersonnes();

            Console.WriteLine("Yo mec \n Veuillez choisir un menu : \n\n 1. Afficher les adhérents \n 2. Ajouter un nouvel adhérent \n 3. Créer une session");

            try
            {
                string choice = Console.ReadLine();

                if (choice != "1" && choice != "2" && choice != "3") throw new ArgumentException();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        PrintMenuAdherent();
                        break;
                    case "2":
                        AddAdherent();
                        break;
                    case "3":
                        Console.Clear();
                        CreateSession();
                        break;
                    default:
                        break;
                }
            }
            catch(ArgumentException e)
            {
                PrintPrincipalMenu();
            }
        }

        private void CreateSession()
        {
            Console.WriteLine("Une session a été créé !");

            Session session = new Session(this.collectionPersonne);
            session.GeneratePartie();

            PrintPrincipalMenu();
        }

        private void AddAdherent()
        {
            Personne Personne = new Personne(InputAdherent("Nom"), InputAdherent("Prenom"), int.Parse(InputAdherent("Poids")), int.Parse(InputAdherent("Date d'adhesion")));
            PrintPrincipalMenu();
        }


        private string InputAdherent(string prop)
        {
            Console.WriteLine($"{prop}:");
            return Console.ReadLine();
        }

        private void PrintMenuAdherent()
        {

            var collumnName = "Nom";
            var collumnFirstName = "Prenom";
            var collumnWeight = "Poids";
            var collumnAncient = "Annee Adhesion";

            var menu = $"{collumnName}|{collumnFirstName}|{collumnWeight}|{collumnAncient}\n";

            this.collectionPersonne.ForEach(personne => {
                menu += $"{personne.Nom}|{personne.Prenom}|{personne.Poid}|{personne.Anciente}\n";
            });

            Console.WriteLine(menu);
            PrintPrincipalMenu();
        }
    }
}
