Imports DevExpress.Utils.Drawing
Imports DevExpress.Utils.Svg
Imports DevExpress.XtraEditors
Imports DevExpress.XtraScheduler
Imports System
Imports System.Drawing
Imports System.IO
Imports System.Reflection

Namespace CustomAppointmentFlyoutExample

    Public Partial Class Form1
        Inherits XtraForm

        Private ReadOnly fontStorage As FontStorage

        Public Sub New()
            fontStorage = New FontStorage()
            InitializeComponent()
            InitializeScheduler()
        End Sub

        Private Sub InitializeScheduler()
            InitResources(schedulerStorage1)
            InitAppointments(schedulerStorage1)
            schedulerControl1.Start = Date.Today
            schedulerControl1.GroupType = SchedulerGroupType.Resource
#Region "#OptionsFlyout"
            schedulerControl1.OptionsFlyout.SubjectAutoHeight = True
#End Region  ' #OptionsFlyout
        End Sub

#Region "#CustomizeAppointmentFlyout"
        Private Sub OnSchedulerControlCustomizeAppointmentFlyout(ByVal sender As Object, ByVal e As CustomizeAppointmentFlyoutEventArgs)
            e.ShowEndDate = False
            e.ShowReminder = False
            e.ShowLocation = True
            e.SubjectAppearance.Font = fontStorage.SubjectAppearanceFont
            e.Location = "N/A"
        End Sub

#End Region  ' #CustomizeAppointmentFlyout
#Region "#CustomDrawAppointmentFlyoutSubject"
        Private Sub OnSchedulerControlCustomDrawAppointmentFlyoutSubject(ByVal sender As Object, ByVal e As CustomDrawAppointmentFlyoutSubjectEventArgs)
            e.Handled = True
            CustomDrawAppointmentFlyoutSubject(e)
        End Sub

        Private Sub CustomDrawAppointmentFlyoutSubject(ByVal e As CustomDrawAppointmentFlyoutSubjectEventArgs)
            Dim viewInfo As AppointmentBandDrawerViewInfoBase = CType(e.ObjectInfo, AppointmentBandDrawerViewInfoBase)
            e.DrawBackgroundDefault()
            CustomDrawAppointmentFlyoutSubject(e.Appointment, viewInfo)
        End Sub

        Private Sub CustomDrawAppointmentFlyoutSubject(ByVal appointment As Appointment, ByVal viewInfo As AppointmentBandDrawerViewInfoBase)
            Dim cache As GraphicsCache = viewInfo.Cache
            Dim stringFormat As StringFormat = New StringFormat(viewInfo.View.Appearance.GetStringFormat())
            stringFormat.LineAlignment = StringAlignment.Center
            stringFormat.Alignment = stringFormat.LineAlignment
            Try
                ' Draw status
                Dim statusRect As Rectangle = GetStatusBounds(viewInfo)
                cache.FillRectangle(viewInfo.View.Status.GetBrush(), statusRect)
                If viewInfo.View.Status.Type = AppointmentStatusType.Free Then
                    ' Draw a warning
                    cache.DrawImage(GetWarningIcon(New Size(statusRect.Height, statusRect.Height)), statusRect.Location)
                    cache.DrawString("Status is unacceptable", fontStorage.StatusFont, Brushes.Red, statusRect, stringFormat)
                End If

                ' Draw subject                        
                cache.DrawString(appointment.Subject, fontStorage.SubjectFont, Brushes.Black, GetSubjectBounds(viewInfo), stringFormat)
            Finally
                stringFormat.Dispose()
            End Try
        End Sub

        Private Function GetSubjectBounds(ByVal viewInfo As AppointmentBandDrawerViewInfoBase) As Rectangle
            Dim bounds As Rectangle = viewInfo.Bounds
            If viewInfo.View.Status.Type = AppointmentStatusType.Free Then
                bounds.Offset(0, 10)
            End If

            Return bounds
        End Function

        Private Function GetStatusBounds(ByVal viewInfo As AppointmentBandDrawerViewInfoBase) As Rectangle
            Dim bounds As Rectangle = Rectangle.Inflate(viewInfo.Bounds, -1, -1)
            If viewInfo.View.Status.Type = AppointmentStatusType.Free Then
                bounds.Height = 20
            Else
                bounds.Height = 5
            End If

            Return bounds
        End Function

        Private Function GetWarningIcon(ByVal size As Size) As Image
            Using stream As Stream = AppAssembly.GetManifestResourceStream("CustomAppointmentFlyoutExample.warning.svg")
                Dim paletteProvider = SvgPaletteHelper.GetSvgPalette(schedulerControl1.LookAndFeel, ObjectState.Selected)
                Return SvgBitmap.FromStream(stream).Render(size, paletteProvider)
            End Using
        End Function

        Private Shared ReadOnly AppAssembly As Assembly = Assembly.GetExecutingAssembly()

#End Region  ' #CustomDrawAppointmentFlyoutSubject
#Region "#AppointmentFlyoutShowing"
        Private Sub OnSchedulerControl1AppointmentFlyoutShowing(ByVal sender As Object, ByVal e As AppointmentFlyoutShowingEventArgs)
            e.Control = New MyFlyout(e.FlyoutData.Subject, e.FlyoutData.Start, e.FlyoutData.End)
        End Sub

#End Region  ' #AppointmentFlyoutShowing
        Private Sub chkBtnTooltips_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
            If chkBtnTooltips.Checked Then
#Region "#AllowDisplayAppointmentFlyout"
                schedulerControl1.OptionsCustomization.AllowDisplayAppointmentFlyout = False
#End Region  ' #AllowDisplayAppointmentFlyout
                schedulerControl1.OptionsView.ToolTipVisibility = ToolTipVisibility.Always
            Else
                schedulerControl1.OptionsCustomization.AllowDisplayAppointmentFlyout = True
                schedulerControl1.OptionsView.ToolTipVisibility = ToolTipVisibility.Never
            End If
        End Sub

        Private Sub chkBtnAppointmentFlyoutShowing_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
            If chkBtnAppointmentFlyoutShowing.Checked Then
                AddHandler schedulerControl1.AppointmentFlyoutShowing, AddressOf OnSchedulerControl1AppointmentFlyoutShowing
            Else
                RemoveHandler schedulerControl1.AppointmentFlyoutShowing, AddressOf OnSchedulerControl1AppointmentFlyoutShowing
            End If
        End Sub

        Private Sub chkBtnCustomizeAppointmentFlyout_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
            If chkBtnCustomizeAppointmentFlyout.Checked Then
                AddHandler schedulerControl1.CustomizeAppointmentFlyout, AddressOf OnSchedulerControlCustomizeAppointmentFlyout
            Else
                RemoveHandler schedulerControl1.CustomizeAppointmentFlyout, AddressOf OnSchedulerControlCustomizeAppointmentFlyout
            End If
        End Sub

        Private Sub chkBtnCustomDrawAppointmentFlyoutSubject_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
            If chkBtnCustomDrawAppointmentFlyoutSubject.Checked Then
                AddHandler schedulerControl1.CustomDrawAppointmentFlyoutSubject, AddressOf OnSchedulerControlCustomDrawAppointmentFlyoutSubject
            Else
                RemoveHandler schedulerControl1.CustomDrawAppointmentFlyoutSubject, AddressOf OnSchedulerControlCustomDrawAppointmentFlyoutSubject
            End If
        End Sub
    End Class

    Public Class FontStorage
        Implements IDisposable

        Private ReadOnly subjectFontField As Font

        Private ReadOnly statusFontField As Font

        Private ReadOnly subjectAppearanceFontField As Font

        Public Sub New()
            subjectFontField = New Font("Tahoma", 10, FontStyle.Bold)
            statusFontField = New Font("Tahoma", 8, FontStyle.Bold)
            subjectAppearanceFontField = New Font("Arial", 24)
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            Dispose(True)
        End Sub

        Private Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                SubjectFont.Dispose()
                StatusFont.Dispose()
                SubjectAppearanceFont.Dispose()
            End If
        End Sub

        Public ReadOnly Property SubjectFont As Font
            Get
                Return subjectFontField
            End Get
        End Property

        Public ReadOnly Property StatusFont As Font
            Get
                Return statusFontField
            End Get
        End Property

        Public ReadOnly Property SubjectAppearanceFont As Font
            Get
                Return subjectAppearanceFontField
            End Get
        End Property
    End Class
End Namespace
