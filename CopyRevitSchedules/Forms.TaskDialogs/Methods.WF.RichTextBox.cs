#region Библиотеки
using SysDraw = System.Drawing;
using SysForms = System.Windows.Forms;
#endregion

#region Rtb
public static class Rtb
{
    #region RtbContextMenu
    public static SysForms.ContextMenu RtbContextMenu(SysForms.RichTextBox rtb, SysForms.MouseEventArgs e)
    {
        SysForms.ContextMenu m = new SysForms.ContextMenu();
        try
        {
            m.MenuItems.Add(new SysForms.MenuItem("Вырезать"));
            m.MenuItems.Add(new SysForms.MenuItem("Копировать"));
            m.MenuItems.Add(new SysForms.MenuItem("Вставить"));
            m.MenuItems.Add(new SysForms.MenuItem("Удалить"));

            m.MenuItems[0].Click += Cut_Click;
            m.MenuItems[1].Click += Copy_Click;
            m.MenuItems[2].Click += Paste_Click;
            m.MenuItems[3].Click += Del_Click;
        }
        catch (System.NullReferenceException) { }

        void Copy_Click(object sender, EventArgs q)
        { Rtb.CopyFromRtb(rtb); }
        void Cut_Click(object sender, EventArgs q)
        { Rtb.CutFromRtb(rtb); }
        void Paste_Click(object sender, EventArgs q)
        { Rtb.PasteToRtb(rtb); }
        void Del_Click(object sender, EventArgs q)
        { Rtb.DelFromRtb(rtb); }

        return m;
    }
    #endregion
    #region CopyFromRtb
    public static String CopyFromRtb(SysForms.RichTextBox rtb)
    {
        String val = rtb.SelectedText;
        SysForms.Clipboard.SetText(val);
        return (String)val;
    }
    #endregion
    #region CutFromRtb
    public static String CutFromRtb(SysForms.RichTextBox rtb)
    {
        bool ro = false;
        if (rtb.ReadOnly == true)
        {
            ro = true;
            rtb.ReadOnly = false;
        }
        String val = rtb.SelectedText;
        rtb.SelectedText = "";
        SysForms.Clipboard.SetText(val);
        if (ro) { rtb.ReadOnly = true; }
        return (String)val;
    }
    #endregion
    #region PasteToRtb
    public static String PasteToRtb(SysForms.RichTextBox rtb)
    {
        bool ro = false;
        if (rtb.ReadOnly == true)
        {
            ro = true;
            rtb.ReadOnly = false;
        }
        String val = SysForms.Clipboard.GetText();
        rtb.SelectedText = val;
        if (ro) { rtb.ReadOnly = true; }
        return (String)val;
    }
    #endregion
    #region DelFromRtb
    public static String DelFromRtb(SysForms.RichTextBox rtb)
    {
        bool ro = false;
        if (rtb.ReadOnly == true)
        {
            ro = true;
            rtb.ReadOnly = false;
        }
        String val = rtb.SelectedText;
        rtb.SelectedText = "";
        if (ro) { rtb.ReadOnly = true; }
        return (String)val;
    }
    #endregion
    #region ShowRtbContextMenu
    public static bool ShowRtbContextMenu(SysForms.RichTextBox rtb, SysForms.MouseEventArgs e)
    {
        try
        {
            SysForms.ContextMenu m = new SysForms.ContextMenu();
            m.MenuItems.Add(new SysForms.MenuItem("Вырезать"));
            m.MenuItems.Add(new SysForms.MenuItem("Копировать"));
            m.MenuItems.Add(new SysForms.MenuItem("Вставить"));
            m.MenuItems.Add(new SysForms.MenuItem("Удалить"));
            m.Show(rtb, new SysDraw.Point(e.X, e.Y));

            m.MenuItems[0].Click += Cut_Click;
            m.MenuItems[1].Click += Copy_Click;
            m.MenuItems[2].Click += Paste_Click;
            m.MenuItems[3].Click += Del_Click;
        }
        catch (System.NullReferenceException) { }

        void Copy_Click(object sender, EventArgs q)
        { Rtb.CopyFromRtb(rtb); }
        void Cut_Click(object sender, EventArgs q)
        { Rtb.CutFromRtb(rtb); }
        void Paste_Click(object sender, EventArgs q)
        { Rtb.PasteToRtb(rtb); }
        void Del_Click(object sender, EventArgs q)
        { Rtb.DelFromRtb(rtb); }

        return (bool)true;
    }
    #endregion
}
#endregion