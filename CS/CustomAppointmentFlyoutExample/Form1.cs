using DevExpress.Utils.Drawing;
using DevExpress.Utils.Svg;
using DevExpress.XtraEditors;
using DevExpress.XtraScheduler;
using System;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace CustomAppointmentFlyoutExample {
    public partial class Form1 : XtraForm {
        readonly FontStorage fontStorage;

        public Form1() {
            this.fontStorage = new FontStorage();
            InitializeComponent();
            InitializeScheduler();
        }

        void InitializeScheduler() {
            DataHelper.InitResources(this.schedulerStorage1);
            DataHelper.InitAppointments(this.schedulerStorage1);
            this.schedulerControl1.Start = DateTime.Today;
            this.schedulerControl1.GroupType = SchedulerGroupType.Resource;
            #region #OptionsFlyout
            schedulerControl1.OptionsFlyout.SubjectAutoHeight = true;
            #endregion #OptionsFlyout
        }

        #region #CustomizeAppointmentFlyout
        void OnSchedulerControlCustomizeAppointmentFlyout(object sender, CustomizeAppointmentFlyoutEventArgs e) {
            e.ShowEndDate = false;
            e.ShowReminder = false;
            e.ShowLocation = true;
            e.SubjectAppearance.Font = fontStorage.SubjectAppearanceFont;
            e.Location = "N/A";
        }
        #endregion #CustomizeAppointmentFlyout

        #region #CustomDrawAppointmentFlyoutSubject
        void OnSchedulerControlCustomDrawAppointmentFlyoutSubject(object sender, CustomDrawAppointmentFlyoutSubjectEventArgs e) {
            e.Handled = true;
            CustomDrawAppointmentFlyoutSubject(e);
        }
        void CustomDrawAppointmentFlyoutSubject(CustomDrawAppointmentFlyoutSubjectEventArgs e) {
            AppointmentBandDrawerViewInfoBase viewInfo = (AppointmentBandDrawerViewInfoBase)e.ObjectInfo;
            e.DrawBackgroundDefault();
            CustomDrawAppointmentFlyoutSubject(e.Appointment, viewInfo);
        }
        void CustomDrawAppointmentFlyoutSubject(Appointment appointment, AppointmentBandDrawerViewInfoBase viewInfo) {
            GraphicsCache cache = viewInfo.Cache;
            StringFormat stringFormat = new StringFormat(viewInfo.View.Appearance.GetStringFormat());
            stringFormat.Alignment = stringFormat.LineAlignment = StringAlignment.Center;
            try {
                // Draw status
                Rectangle statusRect = GetStatusBounds(viewInfo);
                cache.FillRectangle(viewInfo.View.Status.GetBrush(), statusRect);

                if (viewInfo.View.Status.Type == AppointmentStatusType.Free) {
                    // Draw a warning
                    cache.DrawImage(GetWarningIcon(new Size(statusRect.Height, statusRect.Height)), statusRect.Location);
                    cache.DrawString("Status is unacceptable", fontStorage.StatusFont, Brushes.Red, statusRect, stringFormat);
                }
                // Draw subject                        
                cache.DrawString(appointment.Subject, fontStorage.SubjectFont, Brushes.Black, GetSubjectBounds(viewInfo), stringFormat);
            }
            finally {
                stringFormat.Dispose();
            }
        }
        Rectangle GetSubjectBounds(AppointmentBandDrawerViewInfoBase viewInfo) {
            Rectangle bounds = viewInfo.Bounds;
            if (viewInfo.View.Status.Type == AppointmentStatusType.Free) {
                bounds.Offset(0, 10);
            }
            return bounds;
        }
        Rectangle GetStatusBounds(AppointmentBandDrawerViewInfoBase viewInfo) {
            Rectangle bounds = Rectangle.Inflate(viewInfo.Bounds, -1, -1);
            if (viewInfo.View.Status.Type == AppointmentStatusType.Free) {
                bounds.Height = 20;
            }
            else {
                bounds.Height = 5;
            }
            return bounds;
        }
        Image GetWarningIcon(Size size) {
            using (Stream stream = AppAssembly.GetManifestResourceStream("CustomAppointmentFlyoutExample.warning.svg")) {
                var paletteProvider = SvgPaletteHelper.GetSvgPalette(schedulerControl1.LookAndFeel, ObjectState.Selected);
                return SvgBitmap.FromStream(stream).Render(size, paletteProvider);
            }
        }
        static readonly Assembly AppAssembly = Assembly.GetExecutingAssembly();
        #endregion #CustomDrawAppointmentFlyoutSubject

        #region #AppointmentFlyoutShowing
        void OnSchedulerControl1AppointmentFlyoutShowing(object sender, AppointmentFlyoutShowingEventArgs e) {
            e.Control = new MyFlyout(e.FlyoutData.Subject, e.FlyoutData.Start, e.FlyoutData.End);
        }
        #endregion #AppointmentFlyoutShowing

        private void chkBtnTooltips_CheckedChanged(object sender, EventArgs e) {
            if (chkBtnTooltips.Checked) {
                #region #AllowDisplayAppointmentFlyout
                schedulerControl1.OptionsCustomization.AllowDisplayAppointmentFlyout = false;
                schedulerControl1.OptionsView.ToolTipVisibility = ToolTipVisibility.Always;
                #endregion #AllowDisplayAppointmentFlyout
            }
            else {
                schedulerControl1.OptionsCustomization.AllowDisplayAppointmentFlyout = true;
                schedulerControl1.OptionsView.ToolTipVisibility = ToolTipVisibility.Never;
            }
        }
        private void chkBtnAppointmentFlyoutShowing_CheckedChanged(object sender, EventArgs e) {
            if (chkBtnAppointmentFlyoutShowing.Checked)
            schedulerControl1.AppointmentFlyoutShowing += OnSchedulerControl1AppointmentFlyoutShowing;
            else
                schedulerControl1.AppointmentFlyoutShowing -= OnSchedulerControl1AppointmentFlyoutShowing;
        }


        private void chkBtnCustomizeAppointmentFlyout_CheckedChanged(object sender, EventArgs e) {
            if (chkBtnCustomizeAppointmentFlyout.Checked)
                schedulerControl1.CustomizeAppointmentFlyout += OnSchedulerControlCustomizeAppointmentFlyout;
            else
                schedulerControl1.CustomizeAppointmentFlyout -= OnSchedulerControlCustomizeAppointmentFlyout;
        }

        private void chkBtnCustomDrawAppointmentFlyoutSubject_CheckedChanged(object sender, EventArgs e) {
            if (chkBtnCustomDrawAppointmentFlyoutSubject.Checked)
                schedulerControl1.CustomDrawAppointmentFlyoutSubject += OnSchedulerControlCustomDrawAppointmentFlyoutSubject;
            else
                schedulerControl1.CustomDrawAppointmentFlyoutSubject -= OnSchedulerControlCustomDrawAppointmentFlyoutSubject;
        }
    }

    public class FontStorage : IDisposable {
        readonly Font subjectFont;
        readonly Font statusFont;
        readonly Font subjectAppearanceFont;

        public FontStorage() {
            this.subjectFont = new Font("Tahoma", 10, FontStyle.Bold);
            this.statusFont = new Font("Tahoma", 8, FontStyle.Bold);
            this.subjectAppearanceFont = new Font("Arial", 24);
        }

        public void Dispose() {
            Dispose(true);
        }
        void Dispose(bool disposing) {
            if (disposing) {
                SubjectFont.Dispose();
                StatusFont.Dispose();
                SubjectAppearanceFont.Dispose();
            }
        }

        public Font SubjectFont { get { return subjectFont; } }
        public Font StatusFont { get { return statusFont; } }
        public Font SubjectAppearanceFont { get { return subjectAppearanceFont; } }
    }
}
