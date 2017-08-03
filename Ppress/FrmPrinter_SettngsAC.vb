Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Shared
Imports System.Text.RegularExpressions
Public Class FrmPrinter_SettingsAC
    Private a_recid As Decimal
    Dim eflag As Boolean
    Public Sub New(r As Decimal)
        ' This call is required by the designer.
        ' Add any initialization after the InitializeComponent() call.
        InitializeComponent()
        a_recid = r
        setup_panel()
        ' Add any initialization after the InitializeComponent() call.
        Select Case a_recid
            Case Is = "0"  'add
                Me.UltraLabel8.Text = "Add Mode"
                init_panel()
            Case Is > "0"  'update
                Me.UltraLabel8.Text = "Change Mode"
                update_panel()
        End Select
    End Sub

    Sub setup_panel()
        Dim tt6 As New UltraWinToolTip.UltraToolTipInfo
        tt6.ToolTipText = "Used to print copy automatically when emailed to customer." & vbCrLf & "P=print 1 copy." & vbCrLf & "blank=no print."
        'Me.UltraComboEditor1.SetDataBinding(db.get_tblECMprcntl3_refid, Nothing)
        Me.UltraComboEditor1.DataSource = db.get_tblECMprcntl3_printerid
        Me.UltraComboEditor1.ValueMember = "PrinterID"
        Me.UltraComboEditor1.DisplayMember = "PrinterID"
        'Me.UltraCombo1.Rows.Band.Columns(1).Width = "200"
    End Sub
    Public Sub init_panel()
        Me.UltraComboEditor1.Text = ""
    End Sub
    Public Sub update_panel()
        Dim R As tblECMPrinter_Setting = db.get_tblECMPrinter_Settingsr(a_recid)
        Me.UltraComboEditor1.Value = R.Printer_Name
        Me.UltraCheckEditor1.CheckedValue = R.Postscript_Flag
    End Sub

    Private Sub UltraBtnCancel_Click(sender As System.Object, e As System.EventArgs) Handles UltraBtnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Dispose()
    End Sub

    Private Sub UltaBtnOK_Click(sender As System.Object, e As System.EventArgs) Handles UltaBtnOK.Click
        'change_case()  removed 11/01/12
        edit_data()
        If eflag = False Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If
    End Sub
    Public Sub edit_data()
        eflag = False
        Me.UltraComboEditor1.Text = UCase(Me.UltraComboEditor1.Text)
        If String.IsNullOrEmpty(Me.UltraComboEditor1.Text) Or Me.UltraComboEditor1.Text = " " Then
            MessageBox.Show(Me.UltraLabel1.Text & " is required, please enter", "Invalid " & Me.UltraLabel1.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            eflag = True
            Me.UltraComboEditor1.Focus()
            Exit Sub
        End If
    End Sub

End Class