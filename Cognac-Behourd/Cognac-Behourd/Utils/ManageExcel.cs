using ClosedXML.Excel;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Cognac_Behourd.Utils
{
    public class ManageExcel
    {
        private XLWorkbook excelFile;
        private string path;

        public ManageExcel()
        {
            this.path = BuildPathToExcel();
            this.excelFile = new XLWorkbook(this.path);
        }

        private string BuildPathToExcel()
        {
            var dirPath = Path.DirectorySeparatorChar;

            var arrayPath = Directory.GetCurrentDirectory().Split(dirPath);
            string path = string.Join(dirPath, arrayPath.SkipLast(3));

            return $"{path}{dirPath}Files{dirPath}test.xlsx";
        }


        public List<Personne> GetPersonnes()
        {
            var ws1 = this.excelFile.Worksheet(1).Rows();
            List<Personne> CollectionPersonne = new();


            foreach (var collumn in ws1.Skip(1))
            {
                var CollectionCells = collumn.Group().AsRange().CellsUsed().ToList();

                if (!CollectionCells.Any())
                {
                    break;
                }

                var nom = CollectionCells.ElementAt(0).Value.ToString();
                var prenom = CollectionCells.ElementAt(1).Value.ToString();
                var poids = CollectionCells.ElementAt(2).Value.ToString();
                var annneeAdhesion = CollectionCells.ElementAt(3).Value.ToString();

                CollectionPersonne.Add(new Personne(nom, prenom, int.Parse(poids), int.Parse(annneeAdhesion)));
            }

            return CollectionPersonne;
        }

        public XLWorkbook GetExcelFile() 
        {
            return this.excelFile;
        }

        public string GetPath()
        {
            return this.path;
        }

    }
}
