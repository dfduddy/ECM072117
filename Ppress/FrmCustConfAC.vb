Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Shared
Public Class FrmCustConfAC
    Private a_location As String
    Private a_customer As String
    Dim eflag As Boolean
    Public Sub New(loc As String, cust As String)

        ' This call is required by the designer.
        InitializeComponent()
        a_location = loc
        a_customer = cust
        setup_panel()

        ' Add any initialization after the InitializeComponent() call.
        Select Case a_customer
            Case Is = " "  'add
                Me.UltraLabel1.Text = "Add Mode"
                init_panel()
            Case Is <> " "  'update
                Me.UltraLabel1.Text = "Change Mode"
                Me.UltraCombo2.Enabled = False
                Me.UltraTextEditor1.Enabled = False
                update_panel()
        End Select
    End Sub
    Private Sub UltraButton1_Click(sender As System.Object, e As System.EventArgs) Handles UltraBtnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub UltraBtnOK_Click(sender As System.Object, e As System.EventArgs) Handles UltraBtnOK.Click
        change_case()
        edit_data()
        If eflag = False Then
            Me.UltraCombo2.Value = "    "  'set default value
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If
    End Sub
    Sub setup_panel()
        'Me.UltraCombo1.SetDataBinding(db.get_tblECMType, Nothing)
        Me.UltraCombo2.DataSource = db.get_tblECMLocation
        Me.UltraCombo2.ValueMember = "Location"
        Me.UltraCombo2.DisplayMember = "Location"
        Me.UltraTextEditor1.Focus()
    End Sub
    Public Sub edit_data()
        eflag = False
        'If Me.UltraCombo2.Value = Nothing Then
        '    MessageBox.Show("Location is required, please select", "Invalid Type", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    eflag = True
        '    Me.UltraCombo2.Focus()
        '    Exit Sub
        'End If
        If Me.UltraTextEditor1.Value = Nothing Then
            MessageBox.Show("Customer is required, please input", "Invalid Customer", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            eflag = True
            Me.UltraTextEditor1.Focus()
            Exit Sub
        End If
        If db.check_customer(Me.UltraTextEditor1.Value) = False Then
            MessageBox.Show("Customer is invalid, please verify", "Invalid Customer", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            eflag = True
            Me.UltraTextEditor1.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(Me.UltraDateTimeEditor1.Value) Then
            MessageBox.Show("Confirmation date invalid, please verify", "Invalid Confirmation Date", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            eflag = True
            Me.UltraDateTimeEditor1.Focus()
            Exit Sub
        End If
    End Sub
    Public Sub init_panel()
        Me.UltraTextEditor1.Value = Nothing
        Me.UltraCombo2.Value = Nothing
        Me.UltraDateTimeEditor1.Value = Today
    End Sub
    Public Sub update_panel()
        Dim R As tblECMCustConf = db.get_tblECMCustConf(a_location, a_customer)
        Me.UltraCombo2.Value = R.Location
        Me.UltraTextEditor1.Value = R.Custid
        Me.UltraDateTimeEditor1.Value = R.confdate
        If IsNothing(R.RFlag) Then
            R.RFlag = False
        End If
        Me.CheckBox1.Checked = R.RFlag
    End Sub
    Public Sub change_case()
        Dim cControl As Control
        For Each cControl In Me.UltraGroupBox1.Controls
            If (TypeOf cControl Is Infragistics.Win.UltraWinEditors.UltraTextEditor) Then
                cControl.Text = cControl.Text.ToUpper
            End If
            If (TypeOf cControl Is Infragistics.Win.UltraWinGrid.UltraCombo) Then
                cControl.Text = cControl.Text.ToUpper
            End If
        Next
    End Sub


    Private Sub UltraTextEditor1_ValueChanged(sender As Object, e As EventArgs) Handles UltraTextEditor1.ValueChanged

    End Sub
End Class