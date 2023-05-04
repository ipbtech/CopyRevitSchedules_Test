using System.Diagnostics;
using System.Windows;
using System.Windows.Interop;
using SysForms = System.Windows.Forms;

#region IWin32Window
//https://jeremytammik.github.io/tbc/a/0088_revit_window_handle.htm
public class WindowHandle : SysForms.IWin32Window
{
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
    public static WindowHandle? GettingRevitProcess()
    {
        WindowHandle? hWndRevit = null;
        Process[] processes = Process.GetProcessesByName("Revit");
        if (0 < processes.Length)
        {
            IntPtr h = processes[0].MainWindowHandle;
            hWndRevit = new WindowHandle(h);
        }
        return hWndRevit;
    }
    public static Window? GettingRevitWindow()
    {
        Window? WndRevit = null;
        Process[] processes = Process.GetProcessesByName("Revit");
        if (0 < processes.Length)
        {
            IntPtr h = processes[0].MainWindowHandle;
            HwndSource hwndSource = HwndSource.FromHwnd(h);
            WndRevit = (Window)hwndSource.RootVisual;
        }
        return WndRevit;
    }
}
#endregion
