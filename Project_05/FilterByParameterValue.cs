using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Revit API Namespaces
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;
//using Autodesk.Revit.Creation;
#endregion

namespace Assignment_05
{
    [Transaction(TransactionMode.Manual)]
    internal class FilterByParameterValue : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uiDoc = commandData.Application.ActiveUIDocument;
            Document doc = uiDoc.Document;

            Selection selRef = uiDoc.Selection;
            
            /// Parameter Value Provider
            ParameterValueProvider pvp = new ParameterValueProvider(new ElementId(BuiltInParameter.DOOR_WIDTH));

            /// Numeric Evaluator
            FilterNumericRuleEvaluator fnrv = new FilterNumericGreaterOrEqual();

            /// rule value    
            double ruleValue = 3.0f;                                     
            FilterRule fRule = new FilterDoubleRule(pvp, fnrv, ruleValue, 1E-6);

            /// Create an ElementParameter filter
            ElementParameterFilter filter = new ElementParameterFilter(fRule);

            /// Filter door width greater than rulevalue
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            IList<ElementId> doors = collector
                .OfClass(typeof(FamilyInstance))
                .OfCategory(BuiltInCategory.OST_Doors)
                .WherePasses(filter)
                .ToElementIds().ToList();

            selRef.SetElementIds(doors);

            return Result.Succeeded;

        }
    }
}
