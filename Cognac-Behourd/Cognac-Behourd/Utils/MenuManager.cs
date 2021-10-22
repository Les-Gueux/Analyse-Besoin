using System;
using System.Collections.Generic;
using ClosedXML.Excel;
namespace Cognac_Behourd.Utils
{
    public class MenuManager
    {

        private List<Personne> collectionPersonne;
        private ManageExcel manageExcel;

        public MenuManager()
        {
            this.manageExcel = new ManageExcel();
            this.collectionPersonne = this.manageExcel.GetPersonnes();

            PrintPrincipalMenu();
        }

        private void PrintPrincipalMenu()
        {
            List<IXLCells> collectionCells = new();
            var path = this.manageExcel.GetPath();
            using var wbook = this.manageExcel.GetExcelFile();

            while (true)
            {
                collectionCells = GetCollectionCellsByRowssUsed(collectionCells, wbook);
                Console.WriteLine("Veuillez choisir un menu : \n\n 1. Afficher les adhérents \n 2. Ajouter un nouvel adhérent \n 3. Créer une session");

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
                            Console.Clear();
                            new AdherentManager(wbook, collectionCells, path, this.collectionPersonne);
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
                    Console.Clear();
                    Console.WriteLine("Veuillez indiquer une réponse dans un format correcte :");
                }
            }
        }

        private void CreateSession()
        {
            Console.WriteLine("Une session a été créé !");

            Session session = new Session(this.collectionPersonne);
            session.GeneratePartie();

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
        }

        public static List<IXLCells> GetCollectionCellsByRowssUsed(List<IXLCells> CollectionCells, XLWorkbook wbook)
        {
            var ws1 = wbook.Worksheet(1).Rows();

            foreach (var collumn in ws1)
            {
                CollectionCells.Add(collumn.Group().AsRange().CellsUsed());
            }

            return CollectionCells;
        }
    }
}
