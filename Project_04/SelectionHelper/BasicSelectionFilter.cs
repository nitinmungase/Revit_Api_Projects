using System;
using System.Collections.Generic;
using System.Linq;

#region RevitApi Namespace
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
#endregion

namespace Assignment_04.SelectionHelper
{
    internal class BasicSelectionFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            Category category = elem.Category;

            if (category != null)
            {
                return category.BuiltInCategory == BuiltInCategory.OST_Walls ? true : false;
            }
            else
            {
                return false;
            }
        }
        public bool AllowReference(Reference reference, XYZ position)
        {
            return true;
        }
    }
}