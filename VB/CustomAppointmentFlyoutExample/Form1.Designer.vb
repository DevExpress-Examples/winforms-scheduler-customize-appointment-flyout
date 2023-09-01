Namespace CustomAppointmentFlyoutExample

    Partial Class Form1

        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Me.components IsNot Nothing) Then
                Me.components.Dispose()
            End If

            MyBase.Dispose(disposing)
        End Sub

#Region "Windows Form Designer generated code"
        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim timeRuler1 As DevExpress.XtraScheduler.TimeRuler = New DevExpress.XtraScheduler.TimeRuler()
            Dim timeRuler2 As DevExpress.XtraScheduler.TimeRuler = New DevExpress.XtraScheduler.TimeRuler()
            Dim timeRuler3 As DevExpress.XtraScheduler.TimeRuler = New DevExpress.XtraScheduler.TimeRuler()
            Me.schedulerControl1 = New DevExpress.XtraScheduler.SchedulerControl()
            Me.schedulerStorage1 = New DevExpress.XtraScheduler.SchedulerStorage(Me.components)
            Me.panelControl1 = New DevExpress.XtraEditors.PanelControl()
            Me.chkBtnAppointmentFlyoutShowing = New DevExpress.XtraEditors.CheckButton()
            Me.chkBtnCustomizeAppointmentFlyout = New DevExpress.XtraEditors.CheckButton()
            Me.chkBtnCustomDrawAppointmentFlyoutSubject = New DevExpress.XtraEditors.CheckButton()
            Me.chkBtnTooltips = New DevExpress.XtraEditors.CheckButton()
            CType((Me.schedulerControl1), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((Me.schedulerStorage1), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((Me.panelControl1), System.ComponentModel.ISupportInitialize).BeginInit()
            Me.panelControl1.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' schedulerControl1
            ' 
            Me.schedulerControl1.DataStorage = Me.schedulerStorage1
            Me.schedulerControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.schedulerControl1.Location = New System.Drawing.Point(0, 105)
            Me.schedulerControl1.Name = "schedulerControl1"
            Me.schedulerControl1.Size = New System.Drawing.Size(784, 456)
            Me.schedulerControl1.Start = New System.DateTime(2017, 11, 23, 0, 0, 0, 0)
            Me.schedulerControl1.TabIndex = 0
            Me.schedulerControl1.Text = "schedulerControl1"
            Me.schedulerControl1.Views.DayView.TimeRulers.Add(timeRuler1)
            Me.schedulerControl1.Views.FullWeekView.Enabled = True
            Me.schedulerControl1.Views.FullWeekView.TimeRulers.Add(timeRuler2)
            Me.schedulerControl1.Views.WeekView.Enabled = False
            Me.schedulerControl1.Views.WorkWeekView.TimeRulers.Add(timeRuler3)
            ' 
            ' panelControl1
            ' 
            Me.panelControl1.Controls.Add(Me.chkBtnTooltips)
            Me.panelControl1.Controls.Add(Me.chkBtnCustomDrawAppointmentFlyoutSubject)
            Me.panelControl1.Controls.Add(Me.chkBtnCustomizeAppointmentFlyout)
            Me.panelControl1.Controls.Add(Me.chkBtnAppointmentFlyoutShowing)
            Me.panelControl1.Dock = System.Windows.Forms.DockStyle.Top
            Me.panelControl1.Location = New System.Drawing.Point(0, 0)
            Me.panelControl1.Name = "panelControl1"
            Me.panelControl1.Size = New System.Drawing.Size(784, 105)
            Me.panelControl1.TabIndex = 1
            ' 
            ' chkBtnAppointmentFlyoutShowing
            ' 
            Me.chkBtnAppointmentFlyoutShowing.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
            Me.chkBtnAppointmentFlyoutShowing.Location = New System.Drawing.Point(231, 11)
            Me.chkBtnAppointmentFlyoutShowing.Name = "chkBtnAppointmentFlyoutShowing"
            Me.chkBtnAppointmentFlyoutShowing.Size = New System.Drawing.Size(265, 23)
            Me.chkBtnAppointmentFlyoutShowing.TabIndex = 0
            Me.chkBtnAppointmentFlyoutShowing.Text = "Handle AppointmentFlyoutShowing Event"
            AddHandler Me.chkBtnAppointmentFlyoutShowing.CheckedChanged, New System.EventHandler(AddressOf Me.chkBtnAppointmentFlyoutShowing_CheckedChanged)
            ' 
            ' chkBtnCustomizeAppointmentFlyout
            ' 
            Me.chkBtnCustomizeAppointmentFlyout.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
            Me.chkBtnCustomizeAppointmentFlyout.Location = New System.Drawing.Point(231, 40)
            Me.chkBtnCustomizeAppointmentFlyout.Name = "chkBtnCustomizeAppointmentFlyout"
            Me.chkBtnCustomizeAppointmentFlyout.Size = New System.Drawing.Size(265, 23)
            Me.chkBtnCustomizeAppointmentFlyout.TabIndex = 1
            Me.chkBtnCustomizeAppointmentFlyout.Text = "Handle CustomizeAppointmentFlyout Event"
            AddHandler Me.chkBtnCustomizeAppointmentFlyout.CheckedChanged, New System.EventHandler(AddressOf Me.chkBtnCustomizeAppointmentFlyout_CheckedChanged)
            ' 
            ' chkBtnCustomDrawAppointmentFlyoutSubject
            ' 
            Me.chkBtnCustomDrawAppointmentFlyoutSubject.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
            Me.chkBtnCustomDrawAppointmentFlyoutSubject.Location = New System.Drawing.Point(231, 69)
            Me.chkBtnCustomDrawAppointmentFlyoutSubject.Name = "chkBtnCustomDrawAppointmentFlyoutSubject"
            Me.chkBtnCustomDrawAppointmentFlyoutSubject.Size = New System.Drawing.Size(265, 23)
            Me.chkBtnCustomDrawAppointmentFlyoutSubject.TabIndex = 2
            Me.chkBtnCustomDrawAppointmentFlyoutSubject.Text = "Handle CustomDrawAppointmentFlyoutSubject Event"
            AddHandler Me.chkBtnCustomDrawAppointmentFlyoutSubject.CheckedChanged, New System.EventHandler(AddressOf Me.chkBtnCustomDrawAppointmentFlyoutSubject_CheckedChanged)
            ' 
            ' chkBtnTooltips
            ' 
            Me.chkBtnTooltips.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
            Me.chkBtnTooltips.Location = New System.Drawing.Point(7, 11)
            Me.chkBtnTooltips.Name = "chkBtnTooltips"
            Me.chkBtnTooltips.Size = New System.Drawing.Size(205, 23)
            Me.chkBtnTooltips.TabIndex = 3
            Me.chkBtnTooltips.Text = "Use Tooltips Instead of Flyouts"
            AddHandler Me.chkBtnTooltips.CheckedChanged, New System.EventHandler(AddressOf Me.chkBtnTooltips_CheckedChanged)
            ' 
            ' Form1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(784, 561)
            Me.Controls.Add(Me.schedulerControl1)
            Me.Controls.Add(Me.panelControl1)
            Me.Name = "Form1"
            Me.Text = "CustomAppointmentFlyoutExample"
            CType((Me.schedulerControl1), System.ComponentModel.ISupportInitialize).EndInit()
            CType((Me.schedulerStorage1), System.ComponentModel.ISupportInitialize).EndInit()
            CType((Me.panelControl1), System.ComponentModel.ISupportInitialize).EndInit()
            Me.panelControl1.ResumeLayout(False)
            Me.ResumeLayout(False)
        End Sub

#End Region
        Private schedulerControl1 As DevExpress.XtraScheduler.SchedulerControl

        Private schedulerStorage1 As DevExpress.XtraScheduler.SchedulerStorage

        Private panelControl1 As DevExpress.XtraEditors.PanelControl

        Private chkBtnAppointmentFlyoutShowing As DevExpress.XtraEditors.CheckButton

        Private chkBtnTooltips As DevExpress.XtraEditors.CheckButton

        Private chkBtnCustomDrawAppointmentFlyoutSubject As DevExpress.XtraEditors.CheckButton

        Private chkBtnCustomizeAppointmentFlyout As DevExpress.XtraEditors.CheckButton
    End Class
End Namespace
