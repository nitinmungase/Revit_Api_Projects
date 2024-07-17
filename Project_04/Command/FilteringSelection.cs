using System;
using System.Collections.Generic;
using System.Linq;

#region Revit Api Namesapces
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.UI;
#endregion

namespace Assignment_04.Command
{
    [Transaction(TransactionMode.Manual)]
    internal class FilteringSelection : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uiDoc = commandData.Application.ActiveUIDocument;
            Document doc = uiDoc.Document;
            Selection selection = uiDoc.Selection;
            try
            {
                FilteredElementCollector collector = new FilteredElementCollector(doc);
                List<ElementId> ids = collector
                    .OfClass(typeof(FamilyInstance))
                    .OfCategory(BuiltInCategory.OST_Doors)
                    .ToElementIds().ToList();

                if (ids.Count> 0)
                {
                    selection.SetElementIds(ids);
                    TaskDialog.Show("Element Count", ids.Count.ToString());
                    return Result.Succeeded;
                }
                else
                {
                    return Result.Cancelled;
                }
            }
            catch (Exception)
            {
                return Result.Cancelled;   
            }
        }
    }
}