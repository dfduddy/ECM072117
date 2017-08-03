Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Shared
Imports System.Text.RegularExpressions
Public Class FrmEcoSignAC
    Private a_recid As Decimal
    Dim eflag As Boolean
    Public Sub New(r As Decimal)
        ' This call is required by the designer.
        ' Add any initialization after the InitializeComponent() call.
        InitializeComponent()
        a_recid = r
        setup_panel()
        ' setup_validation_group()
        ' setup_validator()
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
        tt6.ToolTipText = "Right click outside box to select iSeries information"
        'Me.ultracombo2.SetDataBinding(db.get_tblECMprcntl3_refid, Nothing)
        Me.UltraCombo2.DataSource = db.get_tblECMecosign_linq
        Me.UltraCombo2.ValueMember = "TRid"
        Me.UltraCombo2.DisplayMember = "TRid"
        init_Combo2()
        Me.UltraComboEditor3.DataSource = db.get_tblECMecosign_customer
        Me.UltraComboEditor3.ValueMember = "Customer"
        Me.UltraComboEditor3.DisplayMember = "Customer"
        Me.UltraComboEditor5.DataSource = db.get_tblECMecosign_TRname
        Me.UltraComboEditor5.ValueMember = "TRname"
        Me.UltraComboEditor5.DisplayMember = "Trname"
        Me.UltraCombo1.DataSource = db.get_merchandiser_code
        Me.UltraCombo1.Rows.Band.Columns(1).Width = "200"
        Me.UltraCombo1.ValueMember = "VALIDC"
        Me.UltraComboEditor2.DataSource = db.get_tblECMmast_customer
        Me.UltraComboEditor2.DisplayMember = "Customer"
        Me.UltraComboEditor2.ValueMember = "Customer"
        Me.UltraToolTipManager1.SetUltraToolTip(Me.UltraCombo2, tt6)
    End Sub
    Public Sub init_panel()
        Me.UltraCombo2.Text = Nothing
        Me.UltraComboEditor3.Text = Nothing
        Me.UltraComboEditor5.Text = Nothing
    End Sub
    Public Sub init_Combo2()
        Me.UltraCombo2.DisplayLayout.Bands(0).Columns(0).Hidden = True
        Me.UltraCombo2.DisplayLayout.Bands(0).Columns(3).Hidden = True
        Me.UltraCombo2.DisplayLayout.Bands(0).Columns(4).Hidden = True
        Me.UltraCombo2.DisplayLayout.Bands(0).Columns(5).Hidden = True
        Me.UltraCombo2.Rows.Band.Columns(1).Width = "200"
        Me.UltraCombo2.Rows.Band.Columns(2).Width = "200"
    End Sub
    Public Sub update_panel()
        Dim R As tblECMecosign = db.get_tblECMecosignr(a_recid)
        Me.UltraCombo2.Value = R.TRid
        Me.UltraComboEditor3.Value = R.Customer
        Me.UltraComboEditor5.Value = R.TRname
    End Sub

    Private Sub UltraBtnCancel_Click(sender As System.Object, e As System.EventArgs) Handles UltraBtnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Dispose()
    End Sub

    Private Sub UltaBtnOK_Click(sender As System.Object, e As System.EventArgs) Handles UltaBtnOK.Click
        change_case()  'removed 11/01/12
        edit_data()
        If eflag = False Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If
    End Sub
    Private Sub UltraGroupBox1_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles UltraGroupBox1.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Me.UltraGroupBox2.Visible = True
            Me.UltraCombo1.Visible = True
            Me.UltraComboEditor2.Visible = True
        End If
    End Sub
    Public Sub edit_data()
        eflag = False
        'Dim vs As Infragistics.Win.Misc.ValidationSettings = Me.UltraValidator1.GetValidationSettings(Me.ultracombo2)
        'vs.ValidationTrigger = Misc.ValidationTrigger.Programmatic
        'vs.Condition = New Infragistics.Win.OperatorCondition(Infragistics.Win.ConditionOperator.IsNullOrEmpty, True)
        '' ''vs.Condition = New Infragistics.Win.OperatorCondition(Infragistics.Win.ConditionOperator.DoesNotStartWith, "abc", False)
        'Dim er As Boolean = Me.UltraValidator1.Validate(True, False).IsValid
        'If er = True Or Me.UltraComboEditor1.Text = " " Then
        '    MessageBox.Show(Me.UltraLabel1.Text & " is required, please enter", "Invalid " & Me.UltraLabel1.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    eflag = True
        '    Me.UltraComboEditor1.Focus()
        '    Exit Sub
        'End If
        '
        If String.IsNullOrEmpty(Me.UltraCombo2.Text) Or Me.UltraCombo2.Text = " " Then
            MessageBox.Show(Me.UltraLabel1.Text & " is required, please enter", "Invalid " & Me.UltraLabel1.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            eflag = True
            Me.UltraCombo2.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(Me.UltraComboEditor5.Text) Or Me.UltraComboEditor5.Text = " " Then
            MessageBox.Show(Me.UltraLabel4.Text & " is required, please verify", Me.UltraLabel4.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            eflag = True
            Me.UltraComboEditor5.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(Me.UltraComboEditor3.Text) Or Me.UltraComboEditor3.Text = " " Then
            MessageBox.Show(Me.UltraLabel3.Text & " is required, please enter", "Invalid " & Me.UltraLabel3.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            eflag = True
            Me.UltraComboEditor3.Focus()
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
    Public Sub setup_validation_group()
        'Me.UltraValidator1.ValidationGroups.Add(New Infragistics.Win.Misc.ValidationGroup("textgroup"))
        'Dim vs1 As Infragistics.Win.Misc.ValidationSettings = Me.UltraValidator1.GetValidationSettings(Me.UltraTextEditor2)
        'Dim blankcondition As Infragistics.Win.OperatorCondition =
        '    New Infragistics.Win.OperatorCondition(Infragistics.Win.ConditionOperator.DoesNotStartWith, "ABC")
        'vs1.Condition = blankcondition
    End Sub
    Public Sub setup_validator()
        'Dim vs As Infragistics.Win.Misc.ValidationSettings = Me.UltraValidator1.GetValidationSettings(Me.UltraTextEditor2)
        'vs.ValidationTrigger = Misc.ValidationTrigger.Programmatic
        'vs.Condition = New Infragistics.Win.OperatorCondition(Infragistics.Win.ConditionOperator.DoesNotStartWith, "ABC")
    End Sub

    Private Sub UltraCombo1_RowSelected(sender As Object, e As Infragistics.Win.UltraWinGrid.RowSelectedEventArgs) Handles UltraCombo1.RowSelected
        Dim row As UltraGridRow = Me.UltraCombo1.SelectedRow
        If Not row Is Nothing Then
            Me.UltraCombo2.Value = Me.UltraCombo1.SelectedRow.Cells(0).Text
            Me.UltraComboEditor5.Text = Me.UltraCombo1.SelectedRow.Cells(1).Text
        End If
    End Sub

    Private Sub UltraCombo2_RowSelected(sender As Object, e As Infragistics.Win.UltraWinGrid.RowSelectedEventArgs) Handles UltraCombo2.RowSelected
        If Not Me.UltraCombo2.SelectedRow Is Nothing Then
            Me.UltraComboEditor5.Text = Me.UltraCombo2.SelectedRow.Cells(2).Text
        End If
    End Sub

    Private Sub UltraComboEditor2_SelectionChangeCommitted(sender As Object, e As System.EventArgs) Handles UltraComboEditor2.SelectionChangeCommitted
        Me.UltraComboEditor3.Text = Me.UltraComboEditor2.Text
    End Sub
End Class
