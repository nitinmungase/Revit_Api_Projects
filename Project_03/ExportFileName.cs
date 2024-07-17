using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

#region Revit Api Namespaces
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;
#endregion

namespace Revit_API
{
    [Transaction(TransactionMode.Manual)]
    public class ExportFileName : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uiDoc = commandData.Application.ActiveUIDocument;
            Document doc = uiDoc.Document;

            Autodesk.Revit.UI.Selection.Selection selection = uiDoc.Selection;

            Reference selectionRef = selection.PickObject(ObjectType.Element);

            Element selectedElement = doc.GetElement(selectionRef);

            StringBuilder exportData = new StringBuilder();

            ElementData data = new ElementData
            {
                ElementName = selectedElement.Name,
                Id = selectedElement.Id.ToString(),
                CategoryName = selectedElement.Category.Name
            };

            exportData.AppendLine(data.ElementName);
            exportData.AppendLine(data.Id);
            exportData.AppendLine(data.CategoryName);

            /// Write the data to a text file 
            string filePath = @"C:\Users\Ni3\Desktop\ASP.NET\.NET CLASS\Text.txt";
            File.WriteAllText(filePath, exportData.ToString());

            /// Notify the user that the export is complete
            TaskDialog.Show("Export Complete", $"Name,ID & Category Exported to {filePath}");

            return Result.Succeeded;
        }
        public class ElementData
        {
            public string ElementName { get; set; }
            public string Id { get; set; }
            public string CategoryName { get; set; }
        }
    }
}