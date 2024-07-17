using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region RevitApi namespaces
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.UI.Selection;
#endregion

namespace Revit_API
{
    [Transaction(TransactionMode.Manual)]
    public class PickObject : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDocument = commandData.Application.ActiveUIDocument;
            Document document = uIDocument.Document;

            ///Selection class
            Autodesk.Revit.UI.Selection.Selection selection = uIDocument.Selection;

            /// Pickobject
            Reference selectionRef = selection.PickObject(ObjectType.Element);

            ///GetElement
            Element selectedElement = document.GetElement(selectionRef);

            TaskDialog.Show("Information", selectedElement.Category.Name);

            return Result.Succeeded;
        }
    }
}
