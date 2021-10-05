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

            
            List<String> datas = new();

            var arrayPath = Directory.GetCurrentDirectory().Split('\\');
            string path = "";

            for(var i = 0; i < arrayPath.Length; i++)
            {
                if(i < arrayPath.Length - 3)
                {
                    path += i == 0 ? $"{arrayPath[i]}" : $"\\{arrayPath[i]}";
                }
            }

            path = $"{path}\\Files\\test.xlsx";

            using var wbook = new XLWorkbook(path);

            var ws1 = wbook.Worksheet(1);
            var data = ws1.Cell("A2").GetValue<string>();

            Console.WriteLine("Yo mec \n Veuillez choisir un menu : \n\n 1. Afficher les adhérents \n 2. Ajouter un nouvel adhérent \n 3. Créer une session");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    break;
                case "2":
                    break;
                case "3":
                    break;
                default:
                    break;
            }
        }
    }
}
