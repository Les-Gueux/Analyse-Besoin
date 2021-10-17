using System;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using Cognac_Behourd.Utils;

namespace Cognac_Behourd
{
    class Program
    {
        static void Main(string[] args)
        {
            var manageExcel = new ManageExcel();

            var collectionPersonnes = manageExcel.GetPersonnes();

            ManageMenu();           
        }

        public static void ManageMenu()
        {
            List<IXLCells> collectionCells = new();
            var path = BuildPathToExcel();
            using var wbook = new XLWorkbook(path);

            while (true)
            {
                collectionCells = GetCollectionCellsByRowssUsed(collectionCells, wbook);
                Console.WriteLine("Yo mec \n Veuillez choisir un menu : \n\n 1. Afficher les adhérents \n 2. Ajouter un nouvel adhérent \n 3. Créer une session");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        BuildMenuPrintAdherent(collectionCells);
                        break;
                    case "2":
                        AddAdherent(wbook, collectionCells, path);
                        break;
                    case "3":
                        break;
                    default:
                        return;
                        break;
                }
            }
        }


        public static void SaveExcel()
        {

        }

        public static string InputAdherent(string prop)
        {
            Console.WriteLine($"{prop}:");
            return Console.ReadLine();
        }

        public static void AddAdherent(XLWorkbook wbook, List<IXLCells> CollectionCells, string path)
        {

            var ws1 = wbook.Worksheet(1);

            string columnNumber = Convert.ToString(getLastCell(CollectionCells) + 1);
            var nom = InputAdherent("Nom");
            var prenom = InputAdherent("Prenom");
            var poids = InputAdherent("Poids");
            var ancienete = InputAdherent("Date d'adhesion");
            ws1.Cell("A" + columnNumber).RichText.AddText(nom);
            ws1.Cell("B" + columnNumber).RichText.AddText(prenom);
            ws1.Cell("C" + columnNumber).RichText.AddText(poids);
            ws1.Cell("D" + columnNumber).RichText.AddText(ancienete);

            wbook.SaveAs(path); 

            Personne Personne = new Personne(nom, prenom, int.Parse(poids), int.Parse(ancienete));

        }

        public static string BuildPathToExcel()
        {
            var dirPath = Path.DirectorySeparatorChar;

            var arrayPath = Directory.GetCurrentDirectory().Split(dirPath);
            string path = "";

            for (var i = 0; i < arrayPath.Length; i++)
            {
                if (i < arrayPath.Length - 3)
                {
                    path += i == 0 ? $"{arrayPath[i]}" : $"{dirPath}{arrayPath[i]}";
                }
            }

            return $"{path}{dirPath}Files{dirPath}test.xlsx";
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

        public static void BuildMenuPrintAdherent(List<IXLCells> CollectionCells)
        {
            var menu = "";

            CollectionCells.ForEach(cells => { 
                
                foreach(var cell in cells)
                {
                    menu += $"{cell.Value}|";
                }
                
                menu += "\n";
                
            });

            Console.WriteLine(menu.Trim());
        }

        public static int getLastCell(List<IXLCells> CollectionCells)
        {
            var columnNumber = 1;

            CollectionCells.ForEach(cells => {

                foreach (var cell in cells)
                {
                    columnNumber = cell.Address.RowNumber;
                    
                }

            });
            return columnNumber;
        }
    }
}
