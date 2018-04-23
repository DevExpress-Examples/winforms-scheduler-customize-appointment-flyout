using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace CustomAppointmentFlyoutExample {
    public partial class MyFlyout : XtraUserControl {

        public MyFlyout() {
            InitializeComponent();
        }

        public MyFlyout(string subject, DateTime start, DateTime end) {
            InitializeComponent();

            this.labelControl1.Text = subject;
            this.labelControl2.Text = start.ToString();
            this.labelControl3.Text = end.ToString();
        }
    }
}
