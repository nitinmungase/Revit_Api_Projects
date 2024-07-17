using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Revit Api Namespaces
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;
#endregion

namespace Revit_API
{
    [Transaction(TransactionMode.Manual)]
    public class Selection : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uiDoc = commandData.Application.ActiveUIDocument;
            Document doc = uiDoc.Document;

            Autodesk.Revit.UI.Selection.Selection selection = uiDoc.Selection;

            Reference selectionRef = selection.PickObject(ObjectType.Element);

            Element selectedElement = doc.GetElement(selectionRef);

            TaskDialog taskDialog = new TaskDialog("Assignment 03")
            {
                MainInstruction = selectedElement.Id.ToString(),
                MainContent = selectedElement.Name,
                FooterText = selectedElement.Category.Name
            };

            taskDialog.Show();

            return Result.Succeeded;
        }
    }
}
