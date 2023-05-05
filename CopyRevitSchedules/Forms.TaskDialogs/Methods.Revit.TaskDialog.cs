#region Библиотеки
using SysDraw = System.Drawing;
using SysForms = System.Windows.Forms;

using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Diagnostics;
#endregion

#region TaskDialog
#region Test
public static class Test
{
    #region Show
    public static void Show(String val)
    {
        TaskDialog.Show("Проверка", val);
    }
    public static void Show(int val)
    {
        TaskDialog.Show("Проверка", val.ToString());
    }
    public static void Show(double val)
    {
        TaskDialog.Show("Проверка", val.ToString());
    }
    public static void Show(ElementId val)
    {
        TaskDialog.Show("Проверка", val.ToString());
    }
    public static void Show(WorksetId val)
    {
        TaskDialog.Show("Проверка", val.ToString());
    }
    public static void Show(bool val)
    {
        TaskDialog.Show("Проверка", val.ToString());
    }
    public static void Show(List<String> list)
    {
        TaskDialog.Show("Проверка", String.Join("\n", list));
    }
    public static void Show(List<int> list)
    {
        TaskDialog.Show("Проверка", String.Join("\n", list));
    }
    public static void Show(List<double> list)
    {
        TaskDialog.Show("Проверка", String.Join("\n", list));
    }
    public static void Show(List<ElementId> list)
    {
        TaskDialog.Show("Проверка", String.Join("\n", list));
    }
    public static void Show(ICollection<ElementId> list)
    {
        TaskDialog.Show("Проверка", String.Join("\n", list));
    }
    public static void Show(IEnumerable<ElementId> list)
    {
        TaskDialog.Show("Проверка", String.Join("\n", list));
    }
    #endregion
    #region ShowElName
    public static void ShowElName(Element val)
    {
        TaskDialog.Show("Проверка", val.Name);
    }
    public static void ShowElName(List<Element> ElementList)
    {
        string testtext = "";
        testtext += Environment.NewLine;
        for (int i = 0; i < ElementList.Count; i++)
        {
            testtext += ElementList[i].Name;
            testtext += Environment.NewLine;
        }
        TaskDialog.Show("Проверка", testtext);
    }
    public static void ShowElName(IList<Element> ElementList)
    {
        string testtext = "";
        testtext += Environment.NewLine;
        for (int i = 0; i < ElementList.Count; i++)
        {
            testtext += ElementList[i].Name;
            testtext += Environment.NewLine;
        }
        TaskDialog.Show("Проверка", testtext);
    }
    public static void ShowElName(IEnumerable<Element> ElementList)
    {
        string testtext = "";
        testtext += Environment.NewLine;
        for (int i = 0; i < ElementList.Count(); i++)
        {
            testtext += ElementList.ElementAt(i).Name;
            testtext += Environment.NewLine;
        }
        TaskDialog.Show("Проверка", testtext);
    }
    #endregion
    #region ShowElId
    public static void ShowElId(Element val)
    {
        TaskDialog.Show("Проверка", val.Id.ToString());
    }
    public static void ShowElId(List<Element> ElementList)
    {
        string testtext = "";
        testtext += Environment.NewLine;
        for (int i = 0; i < ElementList.Count; i++)
        {
            testtext += ElementList[i].Id.ToString();
            testtext += Environment.NewLine;
        }
        TaskDialog.Show("Проверка", testtext);
    }
    public static void ShowElId(IList<Element> ElementList)
    {
        string testtext = "";
        testtext += Environment.NewLine;
        for (int i = 0; i < ElementList.Count; i++)
        {
            testtext += ElementList.ElementAt(i).Id.ToString();
            testtext += Environment.NewLine;
        }
        TaskDialog.Show("Проверка", testtext);
    }
    public static void ShowElId(IEnumerable<Element> ElementList)
    {
        string testtext = "";
        testtext += Environment.NewLine;
        for (int i = 0; i < ElementList.Count(); i++)
        {
            testtext += ElementList.ElementAt(i).Id.ToString();
            testtext += Environment.NewLine;
        }
        TaskDialog.Show("Проверка", testtext);
    }
    #endregion

    #region Msg
    public static void Msg(String val)
    {
        WindowHandle? hWndRevit = WindowHandle.GettingRevitProcess();
        MSG_wf Wf = new();
        Wf.MSG_rtb_text.Text = val;
        Wf.ColorTextInRTB();
        Wf.Show(hWndRevit);
    }
    public static void Msg(int val)
    {
        WindowHandle? hWndRevit = WindowHandle.GettingRevitProcess();
        MSG_wf Wf = new();
        Wf.MSG_rtb_text.Text = val.ToString();
        Wf.Show(hWndRevit);
    }
    public static void Msg(double val)
    {
        WindowHandle? hWndRevit = WindowHandle.GettingRevitProcess();
        MSG_wf Wf = new();
        Wf.MSG_rtb_text.Text = val.ToString();
        Wf.Show(hWndRevit);
    }
    public static void Msg(ElementId val)
    {
        WindowHandle? hWndRevit = WindowHandle.GettingRevitProcess();
        MSG_wf Wf = new();
        Wf.MSG_rtb_text.Text = val.ToString();
        Wf.Show(hWndRevit);
    }
    public static void Msg(WorksetId val)
    {
        WindowHandle? hWndRevit = WindowHandle.GettingRevitProcess();
        MSG_wf Wf = new();
        Wf.MSG_rtb_text.Text = val.ToString();
        Wf.Show(hWndRevit);
    }
    public static void Msg(bool val)
    {
        WindowHandle? hWndRevit = WindowHandle.GettingRevitProcess();
        MSG_wf Wf = new();
        Wf.MSG_rtb_text.Text = val.ToString();
        Wf.Show(hWndRevit);
    }
    public static void Msg(List<String> list)
    {
        string val = String.Join(",\n", list);
        WindowHandle? hWndRevit = WindowHandle.GettingRevitProcess();
        MSG_wf Wf = new();
        Wf.MSG_rtb_text.Text = val;
        Wf.Show(hWndRevit);
    }
    public static void Msg(List<int> list)
    {
        string val = String.Join(",\n", list);
        WindowHandle? hWndRevit = WindowHandle.GettingRevitProcess();
        MSG_wf Wf = new();
        Wf.MSG_rtb_text.Text = val;
        Wf.Show(hWndRevit);
    }
    public static void Msg(List<double> list)
    {
        string val = String.Join(",\n", list);
        WindowHandle? hWndRevit = WindowHandle.GettingRevitProcess();
        MSG_wf Wf = new();
        Wf.MSG_rtb_text.Text = val;
        Wf.Show(hWndRevit);
    }
    public static void Msg(List<ElementId> list)
    {
        string val = String.Join(",\n", list);
        WindowHandle? hWndRevit = WindowHandle.GettingRevitProcess();
        MSG_wf Wf = new();
        Wf.MSG_rtb_text.Text = val;
        Wf.Show(hWndRevit);
    }
    public static void Msg(ICollection<ElementId> list)
    {
        string val = String.Join(",\n", list);
        WindowHandle? hWndRevit = WindowHandle.GettingRevitProcess();
        MSG_wf Wf = new();
        Wf.MSG_rtb_text.Text = val;
        Wf.Show(hWndRevit);
    }
    public static void Msg(IEnumerable<ElementId> list)
    {
        string val = String.Join(",\n", list);
        WindowHandle? hWndRevit = WindowHandle.GettingRevitProcess();
        MSG_wf Wf = new();
        Wf.MSG_rtb_text.Text = val;
        Wf.Show(hWndRevit);
    }
    public static void Msg(Exception ex)
    {
        WindowHandle? hWndRevit = WindowHandle.GettingRevitProcess();
        MSG_wf Wf = new();

        StackTrace st = new StackTrace(ex, true);
        StackFrame frame = st.GetFrame(0);
        string methodName = string.Empty;
        try { methodName = $"Метод - {frame.GetMethod().Name}"; } catch { }

        Wf.MSG_rtb_text.Text = $"{ex.GetType().FullName}\n\n{ex.Message}\n\n{methodName}";
        Wf.Show(hWndRevit);
    }
    #endregion
    #region MsgForm
    partial class MSG_wf : SysForms.Form
    {
        #region Подготовка данных для формы
        private List<string> wordColors = new();
        private SysForms.Button MSG_bt_close;
        public SysForms.RichTextBox MSG_rtb_text;
        public MSG_wf()
        {
            InitializeComponent();
        }
        #endregion
        private void InitializeComponent()
        {
            #region Содержимое формы
            //System.ComponentModel.ComponentResourceManager resources = new(typeof(Methods.Media));
            this.MSG_bt_close = new SysForms.Button();
            this.MSG_rtb_text = new SysForms.RichTextBox();
            this.SuspendLayout();
            #endregion
            #region MSG_bt_close
            this.MSG_bt_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.MSG_bt_close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.MSG_bt_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.MSG_bt_close.Location = new System.Drawing.Point(820, 264);
            this.MSG_bt_close.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.MSG_bt_close.Name = "MSG_bt_close";
            this.MSG_bt_close.Size = new System.Drawing.Size(75, 25);
            this.MSG_bt_close.TabIndex = 14;
            this.MSG_bt_close.Text = "Закрыть";
            this.MSG_bt_close.UseVisualStyleBackColor = true;
            this.MSG_bt_close.Click += new EventHandler(this.MSG_bt_close_Click);
            #endregion
            #region MSG_rtb_text
            this.MSG_rtb_text.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MSG_rtb_text.Location = new System.Drawing.Point(0, 0);
            this.MSG_rtb_text.Name = "MSG_rtb_text";
            this.MSG_rtb_text.Size = new System.Drawing.Size(899, 259);
            this.MSG_rtb_text.TabIndex = 15;
            this.MSG_rtb_text.Text = "";
            this.MSG_rtb_text.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MSG_rtb_text_MouseDown);
            #endregion
            #region MSG_wf
            this.AllowDrop = true;
            this.AcceptButton = this.MSG_bt_close;
            this.ClientSize = new System.Drawing.Size(900, 295);
            this.Controls.Add(this.MSG_rtb_text);
            this.Controls.Add(this.MSG_bt_close);
            this.CancelButton = this.MSG_bt_close;
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.MinimumSize = new System.Drawing.Size(900, 295);
            this.Name = "MSG_wf";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Инфо";
            //this.Icon = ((SysDraw.Icon)(resources.GetObject("icon_SM_32")));
            this.ResumeLayout(false);
            #endregion
        }
        #region MSG_rtb_text_MouseDown
        private void MSG_rtb_text_MouseDown(object sender, SysForms.MouseEventArgs e)
        {
            if (e.Button == SysForms.MouseButtons.Right)
            {
                SysForms.ContextMenu m = Rtb.RtbContextMenu(MSG_rtb_text, e);
                m.Show(MSG_rtb_text, new SysDraw.Point(e.X, e.Y));
            }
        }
        #endregion
        #region MSG_bt_close_Click
        private void MSG_bt_close_Click(object sender, EventArgs e)
        { Close(); }
        #endregion
        #region ColorTextInRTB
        public void ColorTextInRTB()
        {
            wordColors.Add("Некорректно заполнен параметр \"СМ_Раздел\":");
            wordColors.Add("Некорректно заполнен параметр \"СМ_Блок\":");
            wordColors.Add("Некорректно заполнен параметр \"СМ_Этаж\":");

            for (int i = 0; i < wordColors.Count; i++)
            {
                string str = wordColors[i];
                int s = 0;
                while (s <= MSG_rtb_text.Text.Length - str.Length)
                {
                    s = MSG_rtb_text.Text.IndexOf(str, s);
                    if (s < 0) break;
                    MSG_rtb_text.SelectionStart = s;
                    MSG_rtb_text.SelectionLength = str.Length;
                    MSG_rtb_text.SelectionFont = new SysDraw.Font(
                        MSG_rtb_text.SelectionFont.FontFamily,
                        MSG_rtb_text.SelectionFont.Size,
                        SysDraw.FontStyle.Bold | SysDraw.FontStyle.Underline
                        );
                    s += str.Length;
                }
            }
        }
        #endregion
    }
    #endregion
}
#endregion
#region MsgShow
public static class MsgShow
{
    #region Info
    public static void Info(TaskDialogIcon icon, String mainTitle, String mainInstruction, String mainContent, String expandedContent)
    {
        TaskDialog td = new("NewTaskDialog");
        #region  Main info
        td.Id = "ID_TaskDialog";
        td.MainIcon = icon;
        td.Title = mainTitle;
        td.TitleAutoPrefix = true;
        td.AllowCancellation = true;
        #endregion
        #region Message
        td.MainInstruction = mainInstruction;
        td.MainContent = mainContent;
        td.ExpandedContent = expandedContent;
        #endregion

        //// VerificationText
        //td.VerificationText = "This is 'VerificationText'.";

        #region Command link
        //td.AddCommandLink(TaskDialogCommandLinkId.CommandLink1, "This is 'CommandLink1'.");
        //td.AddCommandLink(TaskDialogCommandLinkId.CommandLink2, "This is 'CommandLink2'.");
        //td.AddCommandLink(TaskDialogCommandLinkId.CommandLink3, "This is 'CommandLink3'.");
        //td.AddCommandLink(TaskDialogCommandLinkId.CommandLink4, "This is 'CommandLink4'.");
        #endregion
        #region Common button
        td.CommonButtons =
            //TaskDialogCommonButtons.Cancel | 
            //TaskDialogCommonButtons.Ok | 
            TaskDialogCommonButtons.Close;
        //TaskDialogCommonButtons.No | 
        //TaskDialogCommonButtons.Yes | 
        //TaskDialogCommonButtons.Retry |
        //TaskDialogCommonButtons.None;
        td.DefaultButton = TaskDialogResult.Close;
        #endregion
        // Dialog
        TaskDialogResult tdRes = td.Show();
        //SysForms.MessageBox.Show(string.Format("Button result: {0}\nVerifictionText checked: {1}", tdRes.ToString(), td.WasVerificationChecked()));
    }
    #endregion
    #region YesNo
    public static TaskDialog YesNo(TaskDialogIcon icon, String mainTitle, String mainInstruction, String mainContent, String expandedContent)
    {
        TaskDialog td = new("NewTaskDialog");
        #region  Main info
        td.Id = "ID_TaskDialog";
        td.MainIcon = icon;
        td.Title = mainTitle;
        td.TitleAutoPrefix = true;
        td.AllowCancellation = true;
        #endregion
        #region Message
        td.MainInstruction = mainInstruction;
        td.MainContent = mainContent;
        td.ExpandedContent = expandedContent;
        #endregion

        //// VerificationText
        //td.VerificationText = "This is 'VerificationText'.";

        #region Command link
        //td.AddCommandLink(TaskDialogCommandLinkId.CommandLink1, "This is 'CommandLink1'.");
        //td.AddCommandLink(TaskDialogCommandLinkId.CommandLink2, "This is 'CommandLink2'.");
        //td.AddCommandLink(TaskDialogCommandLinkId.CommandLink3, "This is 'CommandLink3'.");
        //td.AddCommandLink(TaskDialogCommandLinkId.CommandLink4, "This is 'CommandLink4'.");
        #endregion
        #region Common button
        td.CommonButtons =
            //TaskDialogCommonButtons.Cancel | 
            //TaskDialogCommonButtons.Ok | 
            //TaskDialogCommonButtons.Close |
            TaskDialogCommonButtons.Yes |
            TaskDialogCommonButtons.No; 
            //TaskDialogCommonButtons.Retry |
            //TaskDialogCommonButtons.None;
        td.DefaultButton = TaskDialogResult.Yes;
        #endregion
        return (TaskDialog)td;
        //SysForms.MessageBox.Show(string.Format("Button result: {0}\nVerifictionText checked: {1}", tdRes.ToString(), td.WasVerificationChecked()));
    }
    #endregion
    #region InfoDialog
    public static TaskDialog InfoDialog(TaskDialogIcon icon, String mainTitle, String mainInstruction, String mainContent, String expandedContent)
    {
        TaskDialog td = new("NewTaskDialog");
        #region  Main info
        td.Id = "ID_TaskDialog";
        td.MainIcon = icon;
        td.Title = mainTitle;
        td.TitleAutoPrefix = true;
        td.AllowCancellation = true;
        #endregion
        #region Message
        td.MainInstruction = mainInstruction;
        td.MainContent = mainContent;
        td.ExpandedContent = expandedContent;
        #endregion
        #region Common button
        td.CommonButtons = TaskDialogCommonButtons.Close;
        td.DefaultButton = TaskDialogResult.Close;
        #endregion
        return (TaskDialog)td;
    }
    #endregion
}
#endregion
#endregion