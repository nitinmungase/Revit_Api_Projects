using Assignment_04.SelectionHelper;
using System;
using System.Collections.Generic;

#region Revit Api Namesapces
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.UI;
#endregion

namespace Assignment_04.Command
{
    [Transaction(TransactionMode.Manual)]
    internal class _1_Basic_Selection_Retrieval : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            ///Document 
            UIDocument uiDoc = commandData.Application.ActiveUIDocument;
            Document doc = uiDoc.Document;

            try
            {
                /// PickObject method
                Reference selectionRef = uiDoc.Selection.PickObject(ObjectType.Element);

                Element selectedElement = doc.GetElement(selectionRef);

                TaskDialog.Show("Information", selectedElement.Name);
                TaskDialog.Show("Information", selectedElement.LevelId.ToString());

                return Result.Succeeded;
            }
            catch (Exception)
            {
                 return Result.Cancelled; ;
            }
        }
    }
}