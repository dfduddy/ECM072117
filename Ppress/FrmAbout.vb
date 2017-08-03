Public Class FrmAbout

    Private Sub FrmAbout_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Me.UltraLabel1.Text = "Date: " & Date.Today
        Me.UltraLabel4.Text = "Time: " & TimeOfDay
        'Me.UltraLabel3.Text = "Version: " & System.Windows.Forms.Application.ProductVersion
        Me.UltraLabel3.Text = "Version: 1.0.16.4"
        Me.UltraLabel5.Text = "All rights reserved The Scoular Company"
    End Sub
End Class