using Autodesk.Revit.UI;
using System.Diagnostics;
using System.Windows;
using System.Windows.Interop;
using SysForms = System.Windows.Forms;

namespace CopyRevitSchedules
{

    #region IWin32Window
    //https://jeremytammik.github.io/tbc/a/0088_revit_window_handle.htm
    public class WindowHandle : SysForms.IWin32Window
    {
        #region Common

        IntPtr _hwnd;
        public WindowHandle(IntPtr h)
        {
            Debug.Assert(IntPtr.Zero != h, "expected non-null window handle");
            _hwnd = h;
        }
        public IntPtr Handle
        {
            get { return _hwnd; }
        }
        #endregion
        #region GettingRevitProcess
        public static WindowHandle? GettingRevitProcess(ExternalCommandData commandData)
        {
            WindowHandle? hWndRevit = null;
            Process[] processes = Process.GetProcessesByName("Revit");
            if (0 < processes.Length)
            {
                IntPtr h = commandData.Application.MainWindowHandle;
                hWndRevit = new WindowHandle(h);
            }
            return hWndRevit;
        }
        #endregion
        #region GettingRevitWindow
        public static Window? GettingRevitWindow(ExternalCommandData commandData)
        {
            Window? wndRevit = null;
            Process[] processes = Process.GetProcessesByName("Revit");
            if (0 < processes.Length)
            {
                IntPtr h = commandData.Application.MainWindowHandle;
                HwndSource hwndSource = HwndSource.FromHwnd(h);
                wndRevit = (Window)hwndSource.RootVisual;
            }
            return wndRevit;
        }
        #endregion
    }
}
#endregion