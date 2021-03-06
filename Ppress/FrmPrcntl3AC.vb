﻿Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Shared
Imports System.Text.RegularExpressions
Public Class FrmPrcntl3AC
    Private a_rec As Integer
    Dim eflag As Boolean
    

    Public Sub New(rec As Integer)
        ' This call is required by the designer.
        ' Add any initialization after the InitializeComponent() call.
        InitializeComponent()
        a_rec = rec
        setup_panel()
        ' Add any initialization after the InitializeComponent() call.
        Select Case a_rec
            Case Is = 0  'add
                Me.UltraLabel8.Text = "Add Mode"
                init_panel()
            Case Is > 0  'update
                Me.UltraLabel8.Text = "Change Mode"
                update_panel()
        End Select
    End Sub

    Sub setup_panel()
        Dim tt6 As New UltraWinToolTip.UltraToolTipInfo
        tt6.ToolTipText = "Used to print copy automatically when emailed to customer." & vbCrLf & "P=print 1 copy." & vbCrLf & "blank=no print."
        'Me.UltraComboEditor1.SetDataBinding(db.get_tblECMprcntl3_refid, Nothing)
        Me.UltraComboEditor1.DataSource = db.get_tblECMprcntl3_refid
        Me.UltraComboEditor1.ValueMember = "Refid"
        Me.UltraComboEditor1.DisplayMember = "Refid"
        'Me.UltraCombo1.Rows.Band.Columns(1).Width = "200"
        Me.UltraComboEditor2.DataSource = db.get_tblECMLocation
        Me.UltraComboEditor2.ValueMember = "Location"
        Me.UltraComboEditor2.DisplayMember = "Location"
        Me.UltraComboEditor3.DataSource = db.get_tblECMprcntl3_formid
        Me.UltraComboEditor3.ValueMember = "formid"
        Me.UltraComboEditor3.DisplayMember = "formid"
        Me.UltraComboEditor4.DataSource = db.get_tblECMprcntl3_printerid
        Me.UltraComboEditor4.ValueMember = "printerid"
        Me.UltraComboEditor4.DisplayMember = "printerid"
    End Sub
    Public Sub init_panel()
        Me.UltraComboEditor1.Text = " "
        Me.UltraComboEditor2.Text = " "
        Me.UltraComboEditor3.Text = " "
        Me.UltraComboEditor4.Text = " "
        Me.UltraComboEditor5.Text = "1"
        Me.UltraTextEditor1.Text = " "
        Me.UltraTextEditor2.Text = " "
    End Sub
    Public Sub update_panel()
        Dim R As tblecmprcntl3 = db.get_tblECMprcntl3r(a_rec)
        Me.UltraComboEditor1.Value = R.Refid
        Me.UltraComboEditor2.Value = R.Loc
        Me.UltraTextEditor1.Text = R.Zipcode
        Me.UltraComboEditor3.Value = R.Formid
        Me.UltraComboEditor4.Value = R.PrinterID
        Me.UltraComboEditor5.Value = R.Pcopy
        Me.UltraTextEditor2.Value = R.Desc
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
        If String.IsNullOrEmpty(Me.UltraComboEditor1.Text) Or Me.UltraComboEditor1.Text = " " Then
            MessageBox.Show(Me.UltraLabel1.Text & " is required, please enter", "Invalid " & Me.UltraLabel1.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            eflag = True
            Me.UltraComboEditor1.Focus()
            Exit Sub
        End If
        If Not String.IsNullOrEmpty(Me.UltraTextEditor1.Text) And Me.UltraTextEditor1.Text <> " " Then
            If edit_zip_code(Me.UltraTextEditor1.Text) = False Then
                MessageBox.Show(Me.UltraLabel3.Text & " invalid, please verify", Me.UltraLabel3.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                eflag = True
                Me.UltraTextEditor1.Focus()
                Exit Sub
            End If
        End If
        If String.IsNullOrEmpty(Me.UltraComboEditor3.Text) Then
            MessageBox.Show(Me.UltraLabel4.Text & " cannot be null, please verify", Me.UltraLabel4.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            eflag = True
            Me.UltraComboEditor3.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(Me.UltraComboEditor4.Text) Then
            MessageBox.Show(Me.UltraLabel5.Text & " cannot be null, please verify", Me.UltraLabel5.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            eflag = True
            Me.UltraComboEditor3.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(Me.UltraTextEditor2.Text) Then
            MessageBox.Show(Me.UltraLabel6.Text & " cannot be null, please verify", Me.UltraLabel6.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            eflag = True
            Me.UltraTextEditor2.Focus()
            Exit Sub
        End If
    End Sub
    Public Sub change_case()
        Dim cControl As Control
        For Each cControl In Me.UltraGroupBox1.Controls
            If (TypeOf cControl Is Infragistics.Win.UltraWinEditors.UltraTextEditor) Then
                cControl.Text = cControl.Text.ToUpper
            End If
            If (TypeOf cControl Is Infragistics.Win.UltraWinEditors.UltraComboEditor) Then
                cControl.Text = cControl.Text.ToUpper
            End If
        Next
    End Sub
    
    Public Function edit_zip_code(zip As String) As Boolean
        Dim spattern As String = "\d{5}(-\d{4})?"
        If Regex.IsMatch(zip, spattern) Then
            Return True
        Else
            Return False
        End If
    End Function

End Class