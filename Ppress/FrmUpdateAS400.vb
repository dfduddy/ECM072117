Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Shared
Imports Infragistics.Win.UltraMessageBox
Imports Microsoft.Win32
Imports System.Threading

'uses thread safe operation for messages

Public Class FrmUpdateAS400
    Dim r As Boolean
    Dim appid As String = "FrmPrcntl3"
    Dim userid As String = System.Environment.UserName
    Dim demoThread As Thread
    Dim BoxManager As UltraMessageBoxManager
    Dim textbox As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Dim rstat As Integer

    Private Sub FrmUpdateAS400_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If ops.check_authority(9) = True Then
        Else
            Me.Dispose()
        End If
    End Sub
    Private Sub UltraBtnYes_Click(sender As System.Object, e As System.EventArgs) Handles UltraBtnYes.Click
        Me.UltraBtnYes.Enabled = False
        Me.UltraBTnNo.Enabled = False
        Me.UltraLabel2.Visible = True
        Me.Cursor = Cursors.WaitCursor
        Me.Refresh()
        runproc()
        Me.Dispose()
    End Sub

    Private Sub UltraBTnNo_Click(sender As System.Object, e As System.EventArgs) Handles UltraBTnNo.Click
        Me.Dispose()
    End Sub
    Private Sub runproc()
        Dim dc As New DataClasses1DataContext
        If dc.sp_rebuild_iseries_cust() = 1 Then
            MessageBox.Show("An error has occurred on rebuild!" & vbCrLf & "Contact IT for assitance", "File Rebuild Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub
    'Private Sub Showmessage()
    '    Me.BoxManager = New UltraMessageBoxManager
    '    Using ultraMessageBoxInfo As New UltraMessageBoxInfo()
    '        ' Set the general display style 
    '        ultraMessageBoxInfo.Style = MessageBoxStyle.Standard

    '        ' Set the text for the Text, Caption, Header and Footer 
    '        ultraMessageBoxInfo.Text = "Rebuild AS400 Customers?"
    '        ultraMessageBoxInfo.Caption = "Update AS400"


    '        ' Specify which buttons should be used and which is the default button 
    '        ultraMessageBoxInfo.Buttons = MessageBoxButtons.YesNo
    '        ultraMessageBoxInfo.DefaultButton = MessageBoxDefaultButton.Button1
    '        ultraMessageBoxInfo.ShowHelpButton = Infragistics.Win.DefaultableBoolean.[False]

    '        ' Display the OS Error Icon 
    '        ultraMessageBoxInfo.Icon = MessageBoxIcon.Asterisk

    '        ' Disable the default sounds 
    '        ultraMessageBoxInfo.EnableSounds = Infragistics.Win.DefaultableBoolean.[False]

    '        ' Show the UltraMessageBox 
    '        If Me.BoxManager.ShowMessageBox(ultraMessageBoxInfo) = Windows.Forms.DialogResult.Yes Then
    '            showstatus()
    '            'run proc
    '            ' runproc()
    '            ultraMessageBoxInfo.Buttons = MessageBoxButtons.OK
    '            ultraMessageBoxInfo.Text = "AS400 records updated"
    '            Me.BoxManager.ShowMessageBox(ultraMessageBoxInfo)
    '            r = True
    '        End If
    '    End Using
    'End Sub
    '' This event handler creates a thread that calls a 
    '' Windows Forms control in a thread-safe way.
    'Private Sub setTextSafe()
    '    Me.demoThread = New Thread( _
    '    New ThreadStart(AddressOf Me.Showmessage))
    '    Me.demoThread.Start()
    'End Sub
    'Private Sub runproc()
    '    Dim dc As New DataClasses1DataContext
    '    dc.sp_rebuild_iseries_cust()
    'End Sub
    'Private Sub showstatus()
    '    If Me.InvokeRequired Then
    '        Me.Invoke(New MethodInvoker(AddressOf showstatus))
    '    Else

    '    End If
    'End Sub
End Class
