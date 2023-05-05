using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using CopyRevitSchedules.WPF.Views;

namespace CopyRevitSchedules
{
    [Transaction(TransactionMode.Manual)]
    public class CopyRevitSchedules : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            UIApplication uiapp = commandData.Application;
            Application app = uiapp.Application;
            //IntPtr h = commandData.Application.MainWindowHandle;

            CopySchedulesWPF window = new CopySchedulesWPF(app, uiapp, doc, uidoc);
            try
            {
                System.Windows.Window wndRevit = WindowHandle.GettingRevitWindow(commandData);
                window.Owner = wndRevit;
            }
            catch (NullReferenceException) { }

            window.ShowDialog();
            window.Close();
            return Result.Succeeded;
        }
    }
}