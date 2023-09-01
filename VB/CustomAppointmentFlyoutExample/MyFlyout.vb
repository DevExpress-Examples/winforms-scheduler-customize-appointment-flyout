Imports System.ComponentModel
Imports System.Drawing
Imports DevExpress.XtraEditors

Namespace CustomAppointmentFlyoutExample

    Public Partial Class MyFlyout
        Inherits XtraUserControl

        Public Sub New()
            InitializeComponent()
        End Sub

        Public Sub New(ByVal subject As String, ByVal start As Date, ByVal [end] As Date)
            InitializeComponent()
            labelControl1.Text = subject
            labelControl2.Text = start.ToString()
            labelControl3.Text = [end].ToString()
        End Sub
    End Class
End Namespace
