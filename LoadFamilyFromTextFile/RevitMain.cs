using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

#region Revit API Namespace
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.ApplicationServices;
#endregion

namespace LoadFamilyFromTextFile
{
    [Transaction(TransactionMode.Manual)]
    public class RevitMain : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uiDoc = commandData.Application.ActiveUIDocument;
            Document doc = uiDoc.Document;

            #region Multiple Family Load
            
            ///rootpath of family for loading
            string rootpath = @"C:\Users\Ni3\Desktop\RevitFamily";

            /// Text file from which filter this family only
            string filename = @"C:\Users\Ni3\Desktop\RevitFamily\LoadthisFamily.txt";

            List<string> familyname = new List<string>();

            ///Read Text file and add line to familyname list
            using(StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                //while (!string.IsNullOrEmpty(reader.ReadLine()))
                {
                    familyname.Add(line);
                }
            }

            ///Filter families rootpath with familyname in text file
            List<string> families = Directory.GetFiles(rootpath, "*.rfa", SearchOption.AllDirectories)
                .Where(b => familyname.Any(a => b.Contains(a))).ToList();

            ///Check for rootpath name of filtered family
            foreach (string item in families)
            {
                TaskDialog.Show("Info", item);
            }

            ///Transaction for load Family
            using (Transaction loadFamily = new Transaction(doc,"Load Family"))
            {
                loadFamily.Start();

                foreach (string family in families)
                    {
                        doc.LoadFamily(family);
                    }

                loadFamily.Commit();
             }
                return Result.Succeeded;

            #endregion
        }
    }
}