namespace CustomAppointmentFlyoutExample {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraScheduler.TimeRuler timeRuler1 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler2 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler3 = new DevExpress.XtraScheduler.TimeRuler();
            this.schedulerControl1 = new DevExpress.XtraScheduler.SchedulerControl();
            this.schedulerStorage1 = new DevExpress.XtraScheduler.SchedulerStorage(this.components);
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.chkBtnAppointmentFlyoutShowing = new DevExpress.XtraEditors.CheckButton();
            this.chkBtnCustomizeAppointmentFlyout = new DevExpress.XtraEditors.CheckButton();
            this.chkBtnCustomDrawAppointmentFlyoutSubject = new DevExpress.XtraEditors.CheckButton();
            this.chkBtnTooltips = new DevExpress.XtraEditors.CheckButton();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // schedulerControl1
            // 
            this.schedulerControl1.DataStorage = this.schedulerStorage1;
            this.schedulerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.schedulerControl1.Location = new System.Drawing.Point(0, 105);
            this.schedulerControl1.Name = "schedulerControl1";
            this.schedulerControl1.Size = new System.Drawing.Size(784, 456);
            this.schedulerControl1.Start = new System.DateTime(2017, 11, 23, 0, 0, 0, 0);
            this.schedulerControl1.TabIndex = 0;
            this.schedulerControl1.Text = "schedulerControl1";
            this.schedulerControl1.Views.DayView.TimeRulers.Add(timeRuler1);
            this.schedulerControl1.Views.FullWeekView.Enabled = true;
            this.schedulerControl1.Views.FullWeekView.TimeRulers.Add(timeRuler2);
            this.schedulerControl1.Views.WeekView.Enabled = false;
            this.schedulerControl1.Views.WorkWeekView.TimeRulers.Add(timeRuler3);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.chkBtnTooltips);
            this.panelControl1.Controls.Add(this.chkBtnCustomDrawAppointmentFlyoutSubject);
            this.panelControl1.Controls.Add(this.chkBtnCustomizeAppointmentFlyout);
            this.panelControl1.Controls.Add(this.chkBtnAppointmentFlyoutShowing);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(784, 105);
            this.panelControl1.TabIndex = 1;
            // 
            // chkBtnAppointmentFlyoutShowing
            // 
            this.chkBtnAppointmentFlyoutShowing.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.chkBtnAppointmentFlyoutShowing.Location = new System.Drawing.Point(231, 11);
            this.chkBtnAppointmentFlyoutShowing.Name = "chkBtnAppointmentFlyoutShowing";
            this.chkBtnAppointmentFlyoutShowing.Size = new System.Drawing.Size(265, 23);
            this.chkBtnAppointmentFlyoutShowing.TabIndex = 0;
            this.chkBtnAppointmentFlyoutShowing.Text = "Handle AppointmentFlyoutShowing Event";
            this.chkBtnAppointmentFlyoutShowing.CheckedChanged += new System.EventHandler(this.chkBtnAppointmentFlyoutShowing_CheckedChanged);
            // 
            // chkBtnCustomizeAppointmentFlyout
            // 
            this.chkBtnCustomizeAppointmentFlyout.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.chkBtnCustomizeAppointmentFlyout.Location = new System.Drawing.Point(231, 40);
            this.chkBtnCustomizeAppointmentFlyout.Name = "chkBtnCustomizeAppointmentFlyout";
            this.chkBtnCustomizeAppointmentFlyout.Size = new System.Drawing.Size(265, 23);
            this.chkBtnCustomizeAppointmentFlyout.TabIndex = 1;
            this.chkBtnCustomizeAppointmentFlyout.Text = "Handle CustomizeAppointmentFlyout Event";
            this.chkBtnCustomizeAppointmentFlyout.CheckedChanged += new System.EventHandler(this.chkBtnCustomizeAppointmentFlyout_CheckedChanged);
            // 
            // chkBtnCustomDrawAppointmentFlyoutSubject
            // 
            this.chkBtnCustomDrawAppointmentFlyoutSubject.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.chkBtnCustomDrawAppointmentFlyoutSubject.Location = new System.Drawing.Point(231, 69);
            this.chkBtnCustomDrawAppointmentFlyoutSubject.Name = "chkBtnCustomDrawAppointmentFlyoutSubject";
            this.chkBtnCustomDrawAppointmentFlyoutSubject.Size = new System.Drawing.Size(265, 23);
            this.chkBtnCustomDrawAppointmentFlyoutSubject.TabIndex = 2;
            this.chkBtnCustomDrawAppointmentFlyoutSubject.Text = "Handle CustomDrawAppointmentFlyoutSubject Event";
            this.chkBtnCustomDrawAppointmentFlyoutSubject.CheckedChanged += new System.EventHandler(this.chkBtnCustomDrawAppointmentFlyoutSubject_CheckedChanged);
            // 
            // chkBtnTooltips
            // 
            this.chkBtnTooltips.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.chkBtnTooltips.Location = new System.Drawing.Point(7, 11);
            this.chkBtnTooltips.Name = "chkBtnTooltips";
            this.chkBtnTooltips.Size = new System.Drawing.Size(205, 23);
            this.chkBtnTooltips.TabIndex = 3;
            this.chkBtnTooltips.Text = "Use Tooltips Instead of Flyouts";
            this.chkBtnTooltips.CheckedChanged += new System.EventHandler(this.chkBtnTooltips_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.schedulerControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "Form1";
            this.Text = "CustomAppointmentFlyoutExample";
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraScheduler.SchedulerControl schedulerControl1;
        private DevExpress.XtraScheduler.SchedulerStorage schedulerStorage1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.CheckButton chkBtnAppointmentFlyoutShowing;
        private DevExpress.XtraEditors.CheckButton chkBtnTooltips;
        private DevExpress.XtraEditors.CheckButton chkBtnCustomDrawAppointmentFlyoutSubject;
        private DevExpress.XtraEditors.CheckButton chkBtnCustomizeAppointmentFlyout;
    }
}

