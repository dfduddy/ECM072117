Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Shared
Imports System.Text.RegularExpressions
Imports System.Net.Mail

Public Class FrmDocRoutingAC
    Private a_rec As Integer
    Private a_key As String
    Dim eflag As Boolean
    Dim appid As String = "FrmDocRoutingAC"

    Public Sub New(rec As Integer)
        ' This call is required by the designer.
        InitializeComponent()
        a_rec = rec
        setup_panel()
        ' Add any initialization after the InitializeComponent() call.
        setup_grid()
        set_display()
        Select Case a_rec
            Case Is = 0   'add
                Me.UltraLabel1.Text = "Add Mode"
                init_panel()
            Case Is > 0      'update
                Me.UltraLabel1.Text = "Change Mode"
                update_panel()
                Me.UltraGrid1.DisplayLayout.Override.SelectTypeRow = SelectType.Single
                Me.UltraGrid2.DisplayLayout.Override.SelectTypeRow = SelectType.Single
                'Me.UltraCombo1.Enabled = False
        End Select
    End Sub
    Private Sub UltraBtnOK_Click(sender As System.Object, e As System.EventArgs) Handles UltraBtnOK.Click
        change_case()
        edit_data()
        If eflag = False Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If
    End Sub
    Sub setup_panel()
        Dim tt6 As New UltraWinToolTip.UltraToolTipInfo
        tt6.ToolTipText = "Used to print copy automatically when emailed to customer." & vbCrLf & "P=print 1 copy." & vbCrLf & "blank=no print."
        'Me.UltraCombo1.SetDataBinding(db.get_tblECMType, Nothing)
        Me.UltraCombo1.DataSource = db.get_tblECMType
        Me.UltraCombo1.ValueMember = "Type"
        Me.UltraCombo1.DisplayMember = "Type"
        Me.UltraCombo1.Rows.Band.Columns(1).Width = "200"
        Me.UltraCombo2.DataSource = db.get_tblECMLocation
        Me.UltraCombo2.ValueMember = "Location"
        Me.UltraCombo2.DisplayMember = "Location"
        Me.UltraToolTipManager1.SetUltraToolTip(Me.UltraComboEditor1, tt6)
    End Sub
    Public Sub edit_data()
        eflag = False
        If Me.UltraCombo1.Value = Nothing Then
            MessageBox.Show("Type is required, please select", "Invalid Type", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            eflag = True
            Me.UltraCombo1.Focus()
            Exit Sub
        End If
        If Me.UltraCombo2.Value = Nothing Then
            MessageBox.Show("Location is required, please select", "Invalid Type", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            eflag = True
            Me.UltraCombo2.Focus()
            Exit Sub
        End If
        Select Case Me.UltraCombo1.Text
            Case "FS", "CC", "DE"
                If Me.UltraGrid1.Selected.Rows.Count = 0 Then
                    MessageBox.Show("MA is required for Document Type, please select", "Invalid MA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    eflag = True
                    Me.UltraTextEditor3.Focus()
                    Exit Sub
                End If
        End Select
        Select Me.UltraCombo1.Text
            Case "CO", "CP"
                If Me.UltraGrid2.Selected.Rows.Count = 0 Then
                    MessageBox.Show("Merchandiser is required for Docutment Type, please select", "Invalid Merchandiser", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    eflag = True
                    Me.UltraGrid1.Focus()
                    Exit Sub
                End If
        End Select
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
        If String.IsNullOrEmpty(Me.UltraTextEditor2.Value) Then
            MessageBox.Show("Recipient is required, please retry", "Invalid Recipient", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            eflag = True
            Me.UltraTextEditor2.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(Me.UltraComboEditor1.Value) Then
            MessageBox.Show("Print Flag is invalid, please verify", "Invalid Print Flag", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            eflag = True
            Me.UltraComboEditor1.Focus()
            Exit Sub
        End If
        'edit zip code
        'separate strings with comma delimiters
        Dim e As String = Trim(Me.UltraTextEditor2.Value)
        Dim ea As String() = e.Split(New Char() {","})
        Dim eadr As String
        'edit email addresses in array
        For Each eadr In ea
            If check_email(eadr) = False Then
                MessageBox.Show(eadr & " = Invalid email address, please correct", "Invalid email address", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                eflag = True
                Exit Sub
            End If
        Next
        'check customer confirmation
        'Dim msg As tblECMhelpcontact = ops.get_helpcontact(appid) 'contact info
        'If ops.check_confirmation(Me.UltraTextEditor1.Text) = 0 Then
        '    MessageBox.Show("Customer Confirmation record not on file" & vbCrLf & "Please verify " & _
        '        msg.Contact, "Customer Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    eflag = True
        '    Exit Sub
        'End If
    End Sub
    Public Sub init_panel()
        Me.UltraCombo1.Value = Nothing
        Me.UltraCombo2.Text = "    "
        Me.UltraTextEditor1.Value = Nothing
        Me.UltraCombo4.Value = " "
        Me.UltraTextEditor2.Value = Nothing
        Me.UltraCombo6.Value = Nothing
        Me.UltraComboEditor1.Value = "P"
        Me.UltraComboEditor1.Text = "P"
        Me.UltraComboEditor2.Value = "N"
        Me.UltraComboEditor2.Text = "N"
        Me.UltraComboEditor3.Value = "N"
        Me.UltraComboEditor3.Text = "N"
        Me.UltraTextEditor3.Enabled = False
        Me.UltraTextEditor4.Enabled = False
    End Sub
    Public Sub setup_grid()
        Me.UltraGrid1.SetDataBinding(db.get_tblECMMA, Nothing)
        Me.UltraGrid1.DataBind()
        Me.UltraGrid2.SetDataBinding(db.get_merchandiser, Nothing)
        Me.UltraGrid2.DataBind()
    End Sub
    Private Sub UltraGrid1_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles UltraGrid1.InitializeLayout
        'e.Layout.Bands(0).Override.HeaderAppearance.BackColor = Color.LightBlue
        e.Layout.GroupByBox.Hidden = True
        e.Layout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False
        e.Layout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.XPThemed
        e.Layout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
        e.Layout.Override.AllowAddNew = AllowAddNew.No
        e.Layout.Override.SelectTypeRow = SelectType.Default
        e.Layout.Override.AllowUpdate = DefaultableBoolean.False
        e.Layout.Bands(0).Override.CellClickAction = CellClickAction.RowSelect
    End Sub
    Private Sub UltraGrid2_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles UltraGrid2.InitializeLayout
        'e.Layout.Bands(0).Override.HeaderAppearance.BackColor = Color.LightBlue
        e.Layout.GroupByBox.Hidden = True
        e.Layout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False
        e.Layout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.XPThemed
        e.Layout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
        e.Layout.Override.AllowAddNew = AllowAddNew.No
        e.Layout.Override.SelectTypeRow = SelectType.Default
        e.Layout.Override.AllowUpdate = DefaultableBoolean.False
        e.Layout.Bands(0).Override.CellClickAction = CellClickAction.RowSelect
    End Sub
    Private Sub set_display()
        With UltraGrid1
            .DisplayLayout.Bands(0).Columns(0).Header.Caption = "User ID"
            set_col_headers(Me.UltraGrid1)
        End With
        With UltraGrid2
            .DisplayLayout.Bands(0).Columns(0).Header.Caption = "Merchandiser Name"
            .DisplayLayout.Bands(0).Columns(0).Width = 250
            set_col_headers(Me.UltraGrid2)
        End With
    End Sub
    Private Sub set_col_headers(grid As UltraGrid)
        Dim col As UltraGridColumn
        With grid
            For Each col In .DisplayLayout.Bands(0).Columns
                col.Header.Appearance.ThemedElementAlpha = Alpha.Transparent
                col.Header.Appearance.BackColor = Color.Black
                col.Header.Appearance.ForeColor = Color.White
            Next
        End With
    End Sub
    Private Sub UltraCombo1_RowSelected(sender As Object, e As Infragistics.Win.UltraWinGrid.RowSelectedEventArgs) Handles UltraCombo1.RowSelected
        Me.UltraTextEditor3.Enabled = False
        Me.UltraCombo2.Enabled = True 'enable location
        Me.UltraComboEditor2.Enabled = True
        Me.UltraComboEditor3.Enabled = True
        Me.UltraTextEditor4.Enabled = False
        'If Me.UltraCombo1.Value = "CP" Then 'Or Me.UltraCombo1.Value = "CC"
        '    'Me.UltraCombo4.Enabled = False
        '    'Me.UltraCombo4.Value = "          "
        '    Me.UltraTextEditor3.Value = "          "
        '    Exit Sub
        'End If
        Select Case Me.UltraCombo1.Value
            Case "FS", "CO"
                Me.UltraTextEditor3.Enabled = True
        End Select
        If Me.UltraCombo1.Value = "CO" And a_rec = 0 Then 'restrict access for add
            Me.UltraTextEditor3.Enabled = False
        End If
        Select Case Me.UltraCombo1.Value
            Case "CO"
                Me.UltraTextEditor4.Enabled = True
                ' Me.UltraTextEditor4.Value = ""
        End Select
        If Me.UltraCombo1.Value = "FS" Then
            Me.UltraComboEditor2.Enabled = False
            Me.UltraComboEditor3.Enabled = False
        End If
        'If Me.UltraCombo1.Value = "FS" Then
        'Me.UltraCombo6.Enabled = False
        'Me.UltraCombo6.Value = "          "
        'Exit Sub
        'End If
    End Sub
    Public Sub update_panel()
        Dim R As tblECMmast = db.get_tblECMMastr(a_rec)
        Me.UltraCombo1.Value = R.Type
        Me.UltraCombo2.Value = R.Location
        Me.UltraTextEditor1.Text = R.Customer
        Me.UltraCombo4.Value = R.MA
        Me.UltraTextEditor2.Value = R.Recipent
        Me.UltraCombo6.Value = R.Trader
        Me.UltraComboEditor1.Text = R.Pflag.ToString
        Me.UltraTextEditor3.Text = R.MA
        Me.UltraTextEditor4.Text = R.Trader
        Me.UltraComboEditor2.Text = R.ESFlag
        Me.UltraComboEditor3.Text = R.RMflag
        set_grid_values(R.MA, R.Trader)
    End Sub

    Public Sub change_case()
        Me.UltraTextEditor1.Text = Me.UltraTextEditor1.Text.ToUpper
        Me.UltraTextEditor2.Text = Me.UltraTextEditor2.Text.ToUpper
        Me.UltraTextEditor4.Text = Me.UltraTextEditor4.Text.ToUpper
        'Dim cControl As Control
        'For Each cControl In Me.UltraGroupBox1.Controls
        '    If (TypeOf cControl Is Infragistics.Win.UltraWinEditors.UltraTextEditor) Then
        '        cControl.Text = cControl.Text.ToUpper
        '    End If
        '    If (TypeOf cControl Is Infragistics.Win.UltraWinGrid.UltraCombo) Then
        '        cControl.Text = cControl.Text.ToUpper
        '    End If
        'Next
    End Sub
    Public Function check_email(ea As String) As Boolean
        'dfd01 changed edit for email format
        Try
            Dim tea As String = New MailAddress(ea).Address
        Catch ex As Exception
            Return False
        End Try
        'Dim pattern As String = "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"
        'Dim pattern As String = "\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*([,;]\s*\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)*"
        'Dim emailAddressMatch As Match = Regex.Match(ea, pattern)
        'Show result
        'If Not emailAddressMatch.Success Then Return False
        Return True
    End Function
    
    Private Sub UltraBtnCancel_Click(sender As System.Object, e As System.EventArgs) Handles UltraBtnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    
    Private Sub UltraTextEditor3_EditorButtonClick(sender As Object, e As Infragistics.Win.UltraWinEditors.EditorButtonEventArgs) Handles UltraTextEditor3.EditorButtonClick
        If Me.UltraGrid1.Visible = True Then
            Me.UltraGrid1.Visible = False
            If Me.UltraGrid1.Selected.Rows.Count = 1 Then
                Me.UltraTextEditor3.Text = Me.UltraGrid1.Selected.Rows(0).Cells(0).Value
            Else
                If Me.UltraGrid1.Selected.Rows.Count > 1 Then
                    Me.UltraTextEditor3.Text = "**Multi**"
                End If
            End If
        Else
            Me.UltraGrid1.Visible = True
        End If
    End Sub

    Private Sub UltraGrid1_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles UltraGrid1.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Me.UltraGrid1.Visible = False
        End If
    End Sub

    Private Sub UltraTextEditor4_EditorButtonClick(sender As Object, e As Infragistics.Win.UltraWinEditors.EditorButtonEventArgs) Handles UltraTextEditor4.EditorButtonClick
        If Me.UltraGrid2.Visible = True Then
            Me.UltraGrid2.Visible = False
            If Me.UltraGrid2.Selected.Rows.Count = 1 Then
                Me.UltraTextEditor4.Text = Me.UltraGrid2.Selected.Rows(0).Cells(0).Value
            Else
                If Me.UltraGrid2.Selected.Rows.Count > 1 Then
                    Me.UltraTextEditor4.Text = "**Multi**"
                End If
            End If
        Else
                Me.UltraGrid2.Visible = True
        End If
    End Sub
    Private Sub set_grid_values(maid As String, merc As String)
        Dim r As UltraGridRow
        For Each r In Me.UltraGrid1.Rows
            If r.Cells(0).Value = maid Then
                r.Selected = True
            End If
        Next
        For Each r In Me.UltraGrid2.Rows
            If r.Cells(0).Value = merc Then
                r.Selected = True
            End If
        Next
    End Sub


End Class