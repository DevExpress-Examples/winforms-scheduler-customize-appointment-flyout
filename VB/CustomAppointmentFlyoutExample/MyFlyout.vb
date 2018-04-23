Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports DevExpress.XtraEditors

Namespace CustomAppointmentFlyoutExample
    Partial Public Class MyFlyout
        Inherits XtraUserControl

        Public Sub New()
            InitializeComponent()
        End Sub

        Public Sub New(ByVal subject As String, ByVal start As Date, ByVal [end] As Date)
            InitializeComponent()

            Me.labelControl1.Text = subject
            Me.labelControl2.Text = start.ToString()
            Me.labelControl3.Text = [end].ToString()
        End Sub
    End Class
End Namespace
