using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Revit Api Namespaces
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.ApplicationServices;
#endregion

namespace Revit_API
{
    [Transaction(TransactionMode.Manual)]
    public class HelloRevit : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            TaskDialog.Show("Introduction", "Hello Revit");

            return Result.Succeeded;
        }
    }
}
