using DevExpress.XtraScheduler;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace CustomAppointmentFlyoutExample {
    static class DataHelper {

        public static Random RandomInstance = new Random();

        public static List<CustomResourceSourceObject> CustomResourceCollection = new List<CustomResourceSourceObject>();
        public static List<CustomAppointmentSourceObject> CustomEventList = new List<CustomAppointmentSourceObject>();


        public static  void InitResources(SchedulerStorage storage) {
            ResourceMappingInfo mappings = storage.Resources.Mappings;
            mappings.Id = "ResID";
            mappings.Caption = "Name";

            CustomResourceCollection.Add(CreateCustomResource(1, "Max Fowler", Color.PowderBlue));
            CustomResourceCollection.Add(CreateCustomResource(2, "Nancy Drewmore", Color.PaleVioletRed));
            CustomResourceCollection.Add(CreateCustomResource(3, "Pak Jang", Color.PeachPuff));
            storage.Resources.DataSource = CustomResourceCollection;
        }

        public static CustomResourceSourceObject CreateCustomResource(int res_id, string caption, Color ResColor) {
            CustomResourceSourceObject cr = new CustomResourceSourceObject();
            cr.ResID = res_id;
            cr.Name = caption;
            return cr;
        }



        public static void InitAppointments(SchedulerStorage storage) {
            AppointmentMappingInfo mappings = storage.Appointments.Mappings;
            mappings.Start = "StartTime";
            mappings.End = "EndTime";
            mappings.Subject = "Subject";
            mappings.AllDay = "AllDay";
            mappings.Description = "Description";
            mappings.Label = "Label";
            mappings.Location = "Location";
            mappings.RecurrenceInfo = "RecurrenceInfo";
            mappings.ReminderInfo = "ReminderInfo";
            mappings.ResourceId = "OwnerId";
            mappings.Status = "Status";
            mappings.Type = "EventType";

            GenerateEvents(CustomEventList, storage);
            storage.Appointments.DataSource = CustomEventList;
        }


        public static void GenerateEvents(List<CustomAppointmentSourceObject> eventList, SchedulerStorage storage) {
            int count = storage.Resources.Count;

            for (int i = 0; i < count; i++) {
                Resource resource = storage.Resources[i];
                string subjPrefix = resource.Caption + "'s ";
                eventList.Add(CreateEvent(subjPrefix + "meeting", resource.Id, 2, 5, 14));
                eventList.Add(CreateEvent(subjPrefix + "travel", resource.Id, 3, 6, 10));
                eventList.Add(CreateEvent(subjPrefix + "talk", resource.Id, 0, 4, 16));
            }
        }
        public static CustomAppointmentSourceObject CreateEvent(string subject, object resourceId, int status, int label, int sHour) {
            CustomAppointmentSourceObject apt = new CustomAppointmentSourceObject();
            apt.Subject = subject;
            apt.OwnerId = resourceId;
            apt.StartTime = DateTime.Today.AddHours(RandomInstance.Next(12));
            apt.EndTime = apt.StartTime.AddHours(RandomInstance.Next(4) + 1);
            apt.Status = status;
            apt.Label = label;
            return apt;
        }
    }
}
