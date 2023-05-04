using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;
using RevitFailureHandleServices;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using Application = Autodesk.Revit.ApplicationServices.Application;

namespace CopyRevitSchedules.WPF.Views
{
    public partial class CopySchedulesWPF : Window
    {
        Application app;
        UIApplication uiapp;
        Document doc;
        UIDocument uidoc;
        List<ViewSchedule> schedulesARList;
        List<ViewSchedule> schedulesKRList;
        List<string> openModelList;
        public CopySchedulesWPF(Application _app, UIApplication _uiapp, Document _doc, UIDocument _uidoc)
        {
            InitializeComponent();

            app = _app;
            uiapp = _uiapp;
            doc = _doc;
            uidoc = _uidoc;

            schedulesARList = new List<ViewSchedule>();
            schedulesKRList = new List<ViewSchedule>();
            openModelList = new List<string>();
        }

        private void GetModelList_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            List<string> openModelPaths = new List<string>();
            List<string> modelNames = new List<string>();
            if (Convert.ToBoolean(openFileDialog.ShowDialog()) == true)
            {
                try
                {
                    string[] modelPaths = File.ReadAllLines(openFileDialog.FileName);
                    foreach (string modelPath in modelPaths)
                    {
                        openModelPaths.Add(modelPath);

                        string modelName = modelPath.Split('/')[modelPath.Split('/').Length - 1];
                        if (modelName == modelPath)
                        {
                            modelName = modelPath.Split('\\')[modelPath.Split('\\').Length - 1];
                            modelNames.Add(modelName);
                        }
                        else
                        {
                            modelNames.Add(modelName);
                        }
                    }
                }
                catch (ArgumentException)
                {
                    TaskDialog.Show("Ошибка", "Вы ничего не выбрали.");
                }
                ModelNameList.ItemsSource = modelNames;
                openModelList = openModelPaths;
            }
        }
        private void SchedulesAR_checked(object sender, RoutedEventArgs e)
        {
            IList<Element> schedulesAR = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Schedules).ToElements();
            foreach (Element schedule in schedulesAR) 
            { 
                if (schedule.Name == "Служебная_Площадь для бетоноёмкости")
                {
                    schedulesARList.Add(schedule as ViewSchedule);
                }
            }
            if (schedulesARList.Count() == 0)
            {
                TaskDialog.Show("Ошибка", "Cпецификация \"Служебная_Площадь для бетоноёмкости\" в текущем проекте не найдена.");
            }
        }
        private void SchedulesAR_Unchecked(object sender, RoutedEventArgs e)
        {
            schedulesARList.Clear();
        }
        private void SchedulesKR_checked(object sender, RoutedEventArgs e)
        {
            IList<Element> schedulesKR = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Schedules).ToElements();
            foreach (Element schedule in schedulesKR)
            {
                if (schedule.Name == "КЖ_Арматура для ключевых показателей" || schedule.Name == "КЖ_Бетон для ключевых показателей")
                {
                    schedulesKRList.Add(schedule as ViewSchedule);
                }

            }
            if (!schedulesKRList.Any(value => value.Name == "КЖ_Арматура для ключевых показателей") || 
                !schedulesKRList.Any(value => value.Name == "КЖ_Бетон для ключевых показателей"))
            {
                TaskDialog.Show("Ошибка", "Cпецификации \"КЖ_Арматура для ключевых показателей\" и/или " +
                    "\"КЖ_Бетон для ключевых показателей\" в текущем проекте не найдена.");
            }
        }
        private void SchedulesKR_Unchecked(object sender, RoutedEventArgs e)
        {
            schedulesKRList.Clear();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (openModelList.Count() != 0)
            {
                if (schedulesARList.Count() != 0 || schedulesKRList.Count() != 0)
                {
                    #region Запуск общего счетчика времени выполнения 
                    Stopwatch timeFull = new Stopwatch();
                    timeFull.Start();
                    #endregion

                    StringBuilder report = new StringBuilder();
                    foreach (string modelPath in openModelList)
                    {
                        #region Запуск счетчика времени выполнения обработки файла
                        Stopwatch timeFile = new Stopwatch();
                        timeFile.Start();
                        #endregion

                        // Подписка на обработку событий 
                        uiapp.Application.FailuresProcessing += new EventHandler<FailuresProcessingEventArgs>(Helper.DeleteAllWarnings);
                        uiapp.DialogBoxShowing += new EventHandler<DialogBoxShowingEventArgs>(DialogBoxHandler.DialogBoxShowing);

                        report.Append($" • Обрабатываемая модель: {modelPath} {Environment.NewLine}");
                        ModelPath mpath = ModelPathUtils.ConvertUserVisiblePathToModelPath(modelPath);
                        Document opendoc = MainMethods.OpenRevitModel(app, mpath);

                        string modelRazdel = MainMethods.CheckModelRazdel(opendoc);
                        if (modelRazdel == "АР")
                        {
                            if (schedulesARList.Count != 0)
                            {
                                ICollection<ElementId> scheduleIds = new List<ElementId>();
                                foreach (ViewSchedule schedule in schedulesARList)
                                {
                                    scheduleIds.Add(schedule.Id);
                                }
                                using (Transaction trans = new Transaction(opendoc))
                                {
                                    trans.Start("Копируем спеки");
                                    ElementTransformUtils.CopyElements(doc, scheduleIds, opendoc, null, new CopyPasteOptions());
                                    trans.Commit();
                                }
                                report.Append($"   Спецификация успешно скопирована. {Environment.NewLine}");
                            }
                            else
                            {
                                report.Append($"   Спецификация не скопирована, так как отсутствует в выборке исходного проекта. {Environment.NewLine}");
                            }
                        }
                        else if (modelRazdel == "КР")
                        {
                            if (schedulesKRList.Count != 0)
                            {
                                ICollection<ElementId> scheduleIds = new List<ElementId>();
                                foreach (ViewSchedule schedule in schedulesKRList)
                                {
                                    scheduleIds.Add(schedule.Id);
                                }
                                using (Transaction trans = new Transaction(opendoc))
                                {
                                    trans.Start("Копируем спеки");
                                    ElementTransformUtils.CopyElements(doc, scheduleIds, opendoc, null, new CopyPasteOptions());
                                    MainMethods.ChangeFilterScheduele(opendoc);
                                    
                                    trans.Commit();
                                }
                                report.Append($"   Спецификация успешно скопирована. {Environment.NewLine}");
                            }
                            else
                            {
                                report.Append($"   Спецификация не скопирована, так как отсутствует в выборке исходного проекта. {Environment.NewLine}");
                            }
                        }
                        else
                        {
                            report.Append($"   Модель не соответствует разделу АР или КР {Environment.NewLine}");
                        }

                        MainMethods.SynchronizeModifiedFile(opendoc, mpath);
                        opendoc.Close();

                        #region Фиксация счетчика времени выполнения обработки файла
                        timeFile.Stop();
                        TimeSpan tsFileElapsed = timeFile.Elapsed;
                        string timeFileElapsed = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                            tsFileElapsed.Hours, tsFileElapsed.Minutes, tsFileElapsed.Seconds, tsFileElapsed.Milliseconds / 10);
                        report.Append($"     Время обработки файла: {timeFileElapsed} {Environment.NewLine}{Environment.NewLine}");
                        #endregion

                        // Подписка от событий 
                        uiapp.Application.FailuresProcessing -= new EventHandler<FailuresProcessingEventArgs>(Helper.DeleteAllWarnings);
                        uiapp.DialogBoxShowing -= new EventHandler<DialogBoxShowingEventArgs>(DialogBoxHandler.DialogBoxShowing);
                    }
                    #region Фиксация общего счетчика времени выполнения 
                    timeFull.Stop();
                    TimeSpan tsFullElapsed = timeFull.Elapsed;
                    string timeFullElapsed = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                        tsFullElapsed.Hours, tsFullElapsed.Minutes, tsFullElapsed.Seconds, tsFullElapsed.Milliseconds / 10);
                    report.Append($"Общее время обработки: {timeFullElapsed} {Environment.NewLine}");
                    #endregion
                    Test.Msg(report.ToString());
                }
                else
                {
                    TaskDialog.Show("Ошибка", "Вы не выбрали ни один тип спецификаций (чекбоксы АР/КР), либо необходимых спецификаций нет в текущем проекте");
                }
            }
            else
            {
                TaskDialog.Show("Ошибка", "Вы не загрузили ни одной модели для обработки");
            }
        }
    }
}
