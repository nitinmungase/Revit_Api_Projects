using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Revit Api Namesapces
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
#endregion


namespace Assignment_05
{
    [Transaction(TransactionMode.Manual)]
    public class FilterByCategory : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uiDoc = commandData.Application.ActiveUIDocument;
            Document doc = uiDoc.Document;

            Selection selRef = uiDoc.Selection;

            FilteredElementCollector collector = new FilteredElementCollector(doc);

            List<ElementId> ids = collector.OfCategory(BuiltInCategory.OST_Walls).Select(wall => wall.Id).ToList();

            selRef.SetElementIds(ids);

            return Result.Succeeded;
        }
    }
}
