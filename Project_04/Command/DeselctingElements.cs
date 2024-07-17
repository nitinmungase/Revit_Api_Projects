using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Revit API Namespace
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;
#endregion

namespace Assignment_04.Command
{
    [Transaction(TransactionMode.Manual)]
    internal class DeselctingElements : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uiDoc = commandData.Application.ActiveUIDocument;

            Selection selection = uiDoc.Selection;

            List<ElementId> invalidId = new List<ElementId> { ElementId.InvalidElementId };
            
            selection.SetElementIds(invalidId);

            return Result.Succeeded;
        }
    }
}
