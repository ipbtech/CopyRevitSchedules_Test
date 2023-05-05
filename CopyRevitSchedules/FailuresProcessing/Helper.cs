using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Events;
using System;
using System.Collections.Generic;

namespace RevitFailureHandleServices
{
    public class Helper
    {
        public const string Caption = "Revit API";
        //test
        public static void DeleteAllWarnings(object sender, FailuresProcessingEventArgs e)
        {
            FailuresAccessor fa = e.GetFailuresAccessor();
            IList<FailureMessageAccessor> failList = new List<FailureMessageAccessor>();
            failList = fa.GetFailureMessages();

            String transactionName = fa.GetTransactionName();
            if (failList.Count == 0)
            {
                // FailureProcessingResult.Continue is to let
                // the failure cycle continue next step.
                e.SetProcessingResult(FailureProcessingResult.Continue);
                return;
            }
            foreach (FailureMessageAccessor failure in failList)
            {
                fa.DeleteAllWarnings();
            }
            fa.ResolveFailures(failList);
            //e.SetProcessingResult(FailureProcessingResult.Continue);
            e.SetProcessingResult(FailureProcessingResult.ProceedWithCommit);
        }
    }
}