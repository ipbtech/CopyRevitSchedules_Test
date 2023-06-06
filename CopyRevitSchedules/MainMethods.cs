﻿using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyRevitSchedules
{
    public class MainMethods
    {
        public static Document OpenRevitModel(Application app, ModelPath mpath)
        {
            OpenOptions options = new OpenOptions();
            WorksetConfiguration openConfig = new WorksetConfiguration(WorksetConfigurationOption.CloseAllWorksets);
            options.SetOpenWorksetsConfiguration(openConfig);

            Document opendoc = app.OpenDocumentFile(mpath, options);

            return opendoc;
        }

        public static string CheckModelRazdel(Document doc)
        {
            if (doc.Title.Contains("АР"))
            {
                return "АР";
            }
            else if (doc.Title.Contains("КР"))
            {
                return "КР";
            }
            else
            {
                return "None";
            }
        }
        public static string CheckComplectKZH(Document doc)
        {
            string value = string.Empty;
            string docTitle = doc.Title;

            string[] docTitleFields = docTitle.Split('_');
            foreach (string field in docTitleFields)
            {
                if (field.Contains("КЖ"))
                {
                    value = field.Substring(2);
                }
            }
            return value;
        }

        public static void SynchronizeModifiedFile(Document opendoc, ModelPath mpath)
        {
            RelinquishOptions linq = new RelinquishOptions(true);
            SynchronizeWithCentralOptions synchro = new SynchronizeWithCentralOptions();
            synchro.SetRelinquishOptions(linq);

            opendoc.SynchronizeWithCentral(new TransactWithCentralOptions(), synchro);
        }

        public static void ChangeFilterScheduele(Document doc)
        {
            string complect = CheckComplectKZH(doc);
            List<ElementId> elementIds = new List<ElementId>();

            IList<Element> schedulesKR = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Schedules).ToElements();
            foreach (Element schedule in schedulesKR)
            {
                if (schedule.Name.StartsWith("КЖ_Анализ_Всего арматуры") || schedule.Name.StartsWith("КЖ_Анализ_Всего бетона"))
                {
                    elementIds.Add(schedule.Id);
                }
            }

            foreach (ElementId elId in elementIds)
            {
                ViewSchedule schedule = doc.GetElement(elId) as ViewSchedule;
                ScheduleFilter scheduleFilter = schedule.Definition.GetFilters()[1];
                scheduleFilter.SetValue(complect);
                schedule.Definition.SetFilter(1, scheduleFilter);
            }
        }

    }
}
