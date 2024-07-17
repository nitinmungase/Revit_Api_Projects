using Autodesk.Revit.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Revit Api Namesapces
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.UI;
#endregion

namespace Assignment_04.Command
{
    [Transaction(TransactionMode.Manual)]
    internal class FilterWall : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uiDoc = commandData.Application.ActiveUIDocument;
            Document doc = uiDoc.Document;

            Selection selection = uiDoc.Selection;

            FilteredElementCollector collector = new FilteredElementCollector(doc);

            List<ElementId> ids = collector.OfClass(typeof(Wall)).Select(wall => wall.Id).ToList();

            selection.SetElementIds(ids);

            return Result.Succeeded;
        }
    }
}
