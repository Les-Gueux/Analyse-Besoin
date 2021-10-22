﻿using System;
using System.Collections.Generic;
using ClosedXML.Excel;

namespace Cognac_Behourd.Utils
{
    class AdherentManager
    {
        public AdherentManager(XLWorkbook wbook, List<IXLCells> collectionCells, string path, List<Personne> collectionPersonnes)
        {
            while (true)
            {
                Console.WriteLine("Est ce un nouvel adhérent ou un visiteur ? \n 1. Adhérent \n 2. Visiteur");
                var input = Console.ReadLine();
                if (input == "1") { AddNewMember(wbook, collectionCells, path, collectionPersonnes); Console.Clear(); Console.WriteLine("Le nouvel adhérent à été ajouté!"); return; }
                else if (input == "2") { AddNewVisitor(collectionPersonnes); Console.Clear(); Console.WriteLine("Le nouveau visiteur à été ajouté!"); return; }
                else { Console.Clear(); Console.WriteLine("Veuillez indiquer une réponse valide!"); }
            }
        }

        public static string InputAdherent(string prop, string type)
        {
            string errorMessage = "";
            bool isValid = false;
            string input = "";
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
            var nom = InputAdherent("Nom", "sring");
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