Imports DevExpress.XtraScheduler
Imports System
Imports System.Collections.Generic
Imports System.Drawing

Namespace CustomAppointmentFlyoutExample
    Friend NotInheritable Class DataHelper

        Private Sub New()
        End Sub


        Public Shared RandomInstance As New Random()

        Public Shared CustomResourceCollection As New List(Of CustomResourceSourceObject)()
        Public Shared CustomEventList As New List(Of CustomAppointmentSourceObject)()


        Public Shared Sub InitResources(ByVal storage As SchedulerStorage)
            Dim mappings As ResourceMappingInfo = storage.Resources.Mappings
            mappings.Id = "ResID"
            mappings.Caption = "Name"

            CustomResourceCollection.Add(CreateCustomResource(1, "Max Fowler", Color.PowderBlue))
            CustomResourceCollection.Add(CreateCustomResource(2, "Nancy Drewmore", Color.PaleVioletRed))
            CustomResourceCollection.Add(CreateCustomResource(3, "Pak Jang", Color.PeachPuff))
            storage.Resources.DataSource = CustomResourceCollection
        End Sub

        Public Shared Function CreateCustomResource(ByVal res_id As Integer, ByVal caption As String, ByVal ResColor As Color) As CustomResourceSourceObject
            Dim cr As New CustomResourceSourceObject()
            cr.ResID = res_id
            cr.Name = caption
            Return cr
        End Function



        Public Shared Sub InitAppointments(ByVal storage As SchedulerStorage)
            Dim mappings As AppointmentMappingInfo = storage.Appointments.Mappings
            mappings.Start = "StartTime"
            mappings.End = "EndTime"
            mappings.Subject = "Subject"
            mappings.AllDay = "AllDay"
            mappings.Description = "Description"
            mappings.Label = "Label"
            mappings.Location = "Location"
            mappings.RecurrenceInfo = "RecurrenceInfo"
            mappings.ReminderInfo = "ReminderInfo"
            mappings.ResourceId = "OwnerId"
            mappings.Status = "Status"
            mappings.Type = "EventType"

            GenerateEvents(CustomEventList, storage)
            storage.Appointments.DataSource = CustomEventList
        End Sub


        Public Shared Sub GenerateEvents(ByVal eventList As List(Of CustomAppointmentSourceObject), ByVal storage As SchedulerStorage)
            Dim count As Integer = storage.Resources.Count

            For i As Integer = 0 To count - 1
                Dim resource As Resource = storage.Resources(i)
                Dim subjPrefix As String = resource.Caption & "'s "
                eventList.Add(CreateEvent(subjPrefix & "meeting", resource.Id, 2, 5, 14))
                eventList.Add(CreateEvent(subjPrefix & "travel", resource.Id, 3, 6, 10))
                eventList.Add(CreateEvent(subjPrefix & "talk", resource.Id, 0, 4, 16))
            Next i
        End Sub
        Public Shared Function CreateEvent(ByVal subject As String, ByVal resourceId As Object, ByVal status As Integer, ByVal label As Integer, ByVal sHour As Integer) As CustomAppointmentSourceObject
            Dim apt As New CustomAppointmentSourceObject()
            apt.Subject = subject
            apt.OwnerId = resourceId
            apt.StartTime = Date.Today.AddHours(RandomInstance.Next(12))
            apt.EndTime = apt.StartTime.AddHours(RandomInstance.Next(4) + 1)
            apt.Status = status
            apt.Label = label
            Return apt
        End Function
    End Class
End Namespace
