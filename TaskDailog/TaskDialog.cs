using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Revit API NameSpaces
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.UI;
#endregion


namespace Revit_API
{
    [Transaction(TransactionMode.Manual)]
    public class TaskDialog : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            ///Creating TaskDialog 
            Autodesk.Revit.UI.TaskDialog newDialog = new Autodesk.Revit.UI.TaskDialog("This is MainInstruction")
            {
                Title = "Command 17 - This is 'Title'",
                MainInstruction = "This is 'MainInstruction'",
                MainContent = "This is 'Main Content'."
            };

            ///Adding commandlink
            newDialog.AddCommandLink(TaskDialogCommandLinkId.CommandLink1, "This is 'CommandLink1'");
            newDialog.AddCommandLink(TaskDialogCommandLinkId.CommandLink2, "This is 'CommandLink2'");
            newDialog.AddCommandLink(TaskDialogCommandLinkId.CommandLink3, "This is 'CommandLink3'");
            newDialog.AddCommandLink(TaskDialogCommandLinkId.CommandLink4, "This is 'CommandLink4'");

            ///Adding Buttons
            newDialog.CommonButtons = TaskDialogCommonButtons.Ok | TaskDialogCommonButtons.Yes | TaskDialogCommonButtons.No | TaskDialogCommonButtons.Retry | TaskDialogCommonButtons.Close | TaskDialogCommonButtons.Cancel;

            ///setting footer
            newDialog.FooterText = "This is 'Footer Text'";

            ///Verification text
            newDialog.ExpandedContent = "Show Details";
            newDialog.VerificationText = "This is Verification";

            newDialog.Show();

            return Result.Succeeded;
        }
    }
}
