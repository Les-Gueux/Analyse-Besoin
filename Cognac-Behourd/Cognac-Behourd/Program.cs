using System;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;

namespace Cognac_Behourd
{
    class Program
    {
        static void Main(string[] args)
        {
            ManageMenu();
            
        }

        public static void ManageMenu()
        {
            List<IXLCells> collectionCells = new();
            var path = BuildPathToExcel();
            using var wbook = new XLWorkbook(path);
            collectionCells = GetCollectionCellsByRowssUsed(collectionCells, wbook);

            Console.WriteLine("Yo mec \n Veuillez choisir un menu : \n\n 1. Afficher les adhérents \n 2. Ajouter un nouvel adhérent \n 3. Créer une session");
            string choice = Console.ReadLine();

            if(choice == "1")
            {
                BuildMenuPrintAdherent(collectionCells);
            }
            if(choice == "2")
            {
                AddAdherent();
            }
            
            switch (choice)
            {
                case "1":
                    BuildMenuPrintAdherent(collectionCells);
                    break;
                case "2":
                    break;
                case "3":
                    break;
                default:
                    break;
            }
        }


        public static void SaveExcel()
        {

        }

        public static string InputAdherent(string prop)
        {
            Console.WriteLine($"{prop}");
            return Console.ReadLine();
        }

        public static void AddAdherent()
        {
            var lastNameAdherent = InputAdherent("Nom");
            var firstNameAdherent = InputAdherent("Prenom");
            var weightAdherent = InputAdherent("Poids");
            var yearAdherent = InputAdherent("Date d'adhesion");
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
    }
}
