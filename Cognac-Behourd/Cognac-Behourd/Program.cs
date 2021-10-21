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

            ManageMenu(collectionPersonnes);           
        }

        public static void ManageMenu(List<Personne> collectionPersonnes)
        {
            List<IXLCells> collectionCells = new();
            var path = BuildPathToExcel();
            using var wbook = new XLWorkbook(path);

            while (true)
            {
                collectionCells = GetCollectionCellsByRowssUsed(collectionCells, wbook);
                Console.WriteLine("Veuillez choisir un menu : \n\n 1. Afficher les adhérents \n 2. Ajouter un nouvel adhérent \n 3. Créer une session");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        BuildMenuPrintAdherent(collectionCells);
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Est ce un nouvel adhérent ou un visiteur ? \n 1. Adhérent \n 2. Visiteur");
                        var input = Console.ReadLine();
                        if (input == "1") AddNewMember(wbook, collectionCells, path, collectionPersonnes);
                        else if (input == "2") AddNewVisitor(collectionPersonnes);
                        else Console.WriteLine("Veuillez indiquer une réponse valide!");
                        break;
                    case "3":
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Veuillez indiquer une réponse valide!");
                        break;
                }
            }
        }


        public static void SaveExcel()
        {

        }

        public static string InputAdherent(string prop, string type)
        {
            string errorMessage = "";
            bool isValid = false;
            string input= "";
            Console.WriteLine($"{prop}:");
            while (!isValid)
            {
                Console.WriteLine($"{errorMessage}");
                input = Console.ReadLine();
                if (type == "int")
                {
                    try
                    {
                        int.Parse(input);
                        // S'il ne génère pas d'erreur, alors l'input sera considéré comme valide
                        isValid = true;

                    }
                    catch (Exception ex)
                    {
                        errorMessage = "Veuillez indiquer une réponse dans un format correcte :";
                    }
                }
                else
                {
                    isValid = true;
                }
            }
            return input;
        }

        public static void AddNewMember(XLWorkbook wbook, List<IXLCells> CollectionCells, string path, List<Personne> collectionPersonnes)
        {

            var ws1 = wbook.Worksheet(1);

            string columnNumber = Convert.ToString(getLastCell(CollectionCells) + 1);
            var nom = InputAdherent("Nom","sring");
            var prenom = InputAdherent("Prenom", "sring");
            var poids = InputAdherent("Poids", "int");
            var ancienete = InputAdherent("Date d'adhesion", "int");
            ws1.Cell("A" + columnNumber).RichText.AddText(nom);
            ws1.Cell("B" + columnNumber).RichText.AddText(prenom);
            ws1.Cell("C" + columnNumber).RichText.AddText(poids);
            ws1.Cell("D" + columnNumber).RichText.AddText(ancienete);

            wbook.SaveAs(path);

            collectionPersonnes.Add(new Personne(nom, prenom, int.Parse(poids), int.Parse(ancienete)));

        }

        public static void AddNewVisitor(List<Personne> collectionPersonnes)
        {
            bool isValidAge = AgeCheck();
            if (isValidAge)
            {
                var nom = InputAdherent("Nom", "sring");
                var prenom = InputAdherent("Prenom", "sring");
                var poids = InputAdherent("Poids", "int");
                var ancienete = InputAdherent("Date d'adhesion", "int");

                collectionPersonnes.Add(new Personne(nom, prenom, int.Parse(poids), int.Parse(ancienete)));
            }
            else Console.WriteLine("Vous n'avez pas l'âge requis pour jouer");

        }

        public static bool AgeCheck()
        {
            Console.WriteLine("Veuillez indiquer votre âge :");
            string errorMessage = "";
            while (true)
            {
                Console.WriteLine($"{errorMessage}");
                var input = Console.ReadLine();
                try
                {
                    int age = int.Parse(input);
                    if (age >= 16) return true;
                    else if (age < 16) return false;

                }
                catch (Exception ex)
                {
                    errorMessage = "Veuillez indiquer une réponse dans un format correcte :";
                }
            }
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
