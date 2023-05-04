using Autodesk.Revit.UI.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RevitFailureHandleServices
{
    public class DialogBoxHandler
    {
        public static void DialogBoxShowing(object sender, DialogBoxShowingEventArgs e)
        {
            
            TaskDialogShowingEventArgs taskDialogArgs = e as TaskDialogShowingEventArgs;


            if (taskDialogArgs != null)
            {
                taskDialogArgs.OverrideResult((int)DialogResult.Yes);
            }
            else
            {
                if (e != null)
                {
                    if (e.DialogId == "Dialog_Revit_ExtendedErrorDialog")
                    {
                        e.OverrideResult((int)DialogResult.Cancel);
                    }
                    else if (e.DialogId == "Dialog_Revit_DocWarnDialog")
                    {
                        e.OverrideResult((int)DialogResult.Cancel);
                    }
                    else
                    {
                        e.OverrideResult((int)DialogResult.Yes);
                    }
                }
            }


            //TaskDialogShowingEventArgs taskDialogArgs = e as TaskDialogShowingEventArgs;


            //if (taskDialogArgs != null)
            //{
            //    taskDialogArgs.OverrideResult((int)DialogResult.Yes);
            //}
            //else
            //{
            //    if (e != null)
            //    {
            //        if (e.DialogId == "Dialog_Revit_ExtendedErrorDialog" && e.Cancellable == false)
            //        {
            //            e.OverrideResult((int)DialogResult.Cancel);
            //        }
            //        else if (e.DialogId == "Dialog_Revit_DocWarnDialog")
            //        {

            //        }
            //        else
            //        {
            //            e.OverrideResult((int)DialogResult.Yes);
            //        }
            //    }
            //}


            //TaskDialogShowingEventArgs taskDialogArgs = e as TaskDialogShowingEventArgs;

            //string s = string.Empty;

            //if (taskDialogArgs != null)
            //{
            //    s = string.Format(
            //      ", dialog id {0}, message '{1}'",
            //      e2.DialogId, e2.Message);

            //    bool isConfirm = e2.DialogId.Equals(
            //      "TaskDialog_Nested_Links_Invisible");

            //    if (isConfirm)
            //    {
            //        e2.OverrideResult((int)DialogResult.Yes);

            //        s += ", auto-confirmed.";
            //    }
            //}


        }
    }
}
