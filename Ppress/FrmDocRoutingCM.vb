Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Shared
Imports System.Text.RegularExpressions
Public Class FrmDocRoutingCM
    Private grid As UltraGrid
    Dim eflag As Boolean
    Dim appid As String = "FrmDocRoutingCM"
    Dim user As String = System.Environment.UserName
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        setup_panel()
        ' Add any initialization after the InitializeComponent() call.
    End Sub
    Private Sub setup_grid()
        Me.UltraGrid1.SetDataBinding(db.get_ecm_change(user), Nothing)
        Me.UltraGrid1.DataBind()
    End Sub

    Private Sub FrmPrcntl2CM_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        set_datasource()
        setup_grid()
        set_display()
        init_panel()
        Me.UltraOptionSet1.CheckedIndex = 0
    End Sub
    Private Sub set_datasource()
        Me.UltraComboEditor2.DataSource = db.get_tblECMMA
        Me.UltraComboEditor2.ValueMember = "ID"
        Me.UltraComboEditor2.DisplayMember = "ID"
        Me.UltraComboEditor3.DataSource = db.get_merchandiser_code
        Me.UltraComboEditor3.ValueMember = "VCDDES"
        Me.UltraComboEditor3.DisplayMember = "VCDDES"
    End Sub
    Private Sub UltraGrid1_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles UltraGrid1.InitializeLayout
        e.Layout.Bands(0).Columns(0).Hidden = True
        'e.Layout.Bands(0).Columns(1).Hidden = True
        e.Layout.Bands(0).Columns(2).Hidden = True
        'e.Layout.Bands(0).Columns(4).Hidden = True
        'e.Layout.Bands(0).Columns(5).Hidden = True
        e.Layout.Bands(0).Columns(6).Hidden = True
        e.Layout.Bands(0).Columns(7).Hidden = True
        e.Layout.Bands(0).Columns(10).Hidden = True
        ' e.Layout.Bands(0).Columns(8).Hidden = True
        'e.Layout.Bands(0).Columns(8).Hidden = True
        'e.Layout.Bands(0).Columns(9).Hidden = True
        'e.Layout.Bands(0).Columns(10).Hidden = True
    End Sub
    Private Sub set_display()
        With Me.UltraGrid1
            .DisplayLayout.Bands(0).Columns(3).Header.Caption = "Customer ID"
            .DisplayLayout.Bands(0).Columns(4).Header.Caption = "User ID"
            .DisplayLayout.Bands(0).Columns(5).Header.Caption = "Recipient Email"
            .DisplayLayout.Bands(0).Columns(8).Header.Caption = "Merchandiser Name"
            'Me.UltraGrid1.DisplayLayout.Bands(0).Columns(7).Header.Caption = "Pct/Batch"
            'Me.UltraGrid1.DisplayLayout.Bands(0).Columns(8).Header.Caption = "Cost/Batch"
            'Me.UltraGrid1.DisplayLayout.Bands(0).Columns(1).Width = 250
            .DisplayLayout.Bands(0).Columns(5).Width = 250
            'Me.UltraGrid1.DisplayLayout.Override.AllowAddNew = AllowAddNew.Yes
            'Me.UltraGrid1.DisplayLayout.AddNewBox.Hidden = False
            'Me.UltraGrid1.DisplayLayout.Bands(0).Columns(0).CellActivation = Activation.Disabled
            .DisplayLayout.GroupByBox.Hidden = True
            .DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True
            .DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.XPThemed
            .DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
            .DisplayLayout.Override.AllowAddNew = AllowAddNew.No
            .DisplayLayout.Override.SelectTypeRow = SelectType.Single
            'Me.UltraGrid1.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False
            .DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False
        End With
        set_col_headers(Me.UltraGrid1)
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

    Private Sub UltraBtnCancel_Click(sender As System.Object, e As System.EventArgs) Handles UltraBtnCancel.Click
        Dim dc As New DataClasses1DataContext
        dc.sp_drop_mast_change(user) 'drop table
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Dispose()
    End Sub

    Private Sub UltraBtnOK_Click(sender As System.Object, e As System.EventArgs) Handles UltraBtnOK.Click
        If Me.UltraGrid1.Rows.Count > 0 Then
            edit_data()
            If eflag = False Then
                Select Case Me.UltraOptionSet1.CheckedIndex
                    Case Is = 0   'process change request
                        'process change 
                        If MessageBox.Show("Change " & Me.UltraGrid1.Rows.Count & " rows", "Confirm Change", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                            process_change()
                        End If
                    Case Is = 1   'process copy request
                        If MessageBox.Show("Copy " & Me.UltraGrid1.Rows.Count & " rows", "Confirm Copy", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                            process_copy()
                        End If
                End Select
                Me.DialogResult = Windows.Forms.DialogResult.OK
            End If
        End If
        Dim dc As New DataClasses1DataContext
        dc.sp_drop_mast_change(user) 'drop table
    End Sub
    Sub setup_panel()
        Dim tt1 As New UltraWinToolTip.UltraToolTipInfo
        tt1.ToolTipText = "* Uses value from row on grid"
        Dim tt2 As New UltraWinToolTip.UltraToolTipInfo
        tt2.ToolTipText = "Select values to change or copy." & vbCrLf & "Note User ID(s) cannot be changed for multiple rows!!"
        'Me.UltraComboEditor1.SetDataBinding(db.get_tblECMprcntl3_refid, Nothing)
        'Me.UltraCombo1.DataSource = db.get_tblECMType
        'Me.UltraCombo1.ValueMember = "Type"
        'Me.UltraCombo1.DisplayMember = "Type"
        'Me.UltraCombo1.Rows.Band.Columns(1).Width = "200"
        'Me.UltraCombo2.DataSource = db.get_tblECMLocation
        'Me.UltraCombo2.ValueMember = "Location"
        'Me.UltraCombo2.DisplayMember = "Location"
        Me.UltraToolTipManager1.SetUltraToolTip(Me.UltraTextEditor1, tt1)
        Me.UltraToolTipManager1.SetUltraToolTip(Me.UltraComboEditor2, tt1)
        Me.UltraToolTipManager1.SetUltraToolTip(Me.UltraTextEditor2, tt1)
        Me.UltraToolTipManager1.SetUltraToolTip(Me.UltraComboEditor3, tt1)
        'Me.UltraToolTipManager1.SetUltraToolTip(Me.UltraGroupBox2, tt2)
    End Sub
    Public Sub init_panel()
        Me.UltraComboEditor1.Text = " "
        Dim type As String = Me.UltraGrid1.Rows(0).Cells("Type").Value
        'Me.UltraCombo1.Text = Me.UltraGrid1.Rows(0).Cells("Type").Value
        'Me.UltraCombo2.Text = "*"
        Me.UltraTextEditor1.Text = "*"
        Me.UltraTextEditor2.Text = "*"
        Me.UltraComboEditor2.Text = "*"
        Me.UltraComboEditor3.Text = "*"
        Me.UltraComboEditor1.Text = "*"
        Select Case type
            Case "FS", "CC"
                Me.UltraComboEditor3.Enabled = False
            Case "CP"
                Me.UltraComboEditor2.Enabled = False
        End Select
    End Sub
    Public Sub process_change()
        Dim r As UltraGridRow
        Dim rr As Integer
        For Each r In UltraGrid1.Rows
            rr = r.Cells("Orecid").Value
            Dim dc As New DataClasses1DataContext
            Dim rec = (From c In dc.tblECMmasts
                     Where (rr = c.Recid)).SingleOrDefault
            'Customer
            If Not Me.UltraTextEditor1.Text = "*" Then
                rec.Customer = Me.UltraTextEditor1.Text
            End If
            'MA
            If Not Me.UltraComboEditor2.Text = "*" Then
                rec.MA = Me.UltraComboEditor2.Text
            End If
            'If r.Cells("Type").Value = "CO" Or r.Cells("Type").Value = "CP" Then
            '    rec.MA = " "
            'End If
            'Recipient
            If Not Me.UltraTextEditor2.Text = "*" Then
                rec.Recipent = Me.UltraTextEditor2.Text
            End If
            'Trader
            If Not Me.UltraComboEditor3.Text = "*" Then
                rec.Trader = Me.UltraComboEditor3.Text
            End If
            If r.Cells("Type").Value = "FS" Or r.Cells("Type").Value = "CC" Then
                rec.Trader = Nothing
            End If
            If Not Me.UltraComboEditor1.Text = "*" Then
                rec.Pflag = Me.UltraComboEditor1.Text
            End If
            rec.Chgdate = Today
            rec.User = System.Environment.UserName
            Try
                dc.SubmitChanges()
            Catch ex As Exception
                MessageBox.Show("Update failed contact IT for assistance " & vbCrLf & "Message Code " & ex.Message, "Update Failure (tblERCMprcntl3)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Exit Sub
            End Try
        Next
    End Sub
    Public Sub process_copy()
        Dim r As UltraGridRow
        For Each r In UltraGrid1.Rows
            Dim dc As New DataClasses1DataContext
            Dim rec As New tblECMmast
            rec.Type = r.Cells("Type").Text
            rec.Location = r.Cells("Location").Text
            'Customer
            If Not Me.UltraTextEditor1.Text = "*" Then
                rec.Customer = Me.UltraTextEditor1.Text
            Else
                rec.Customer = r.Cells("customer").Text
            End If
            'MA
            If Not Me.UltraComboEditor2.Text = "*" Then
                rec.MA = Me.UltraComboEditor2.Text
            Else
                rec.MA = r.Cells("MA").Text
            End If
            'If r.Cells("Type").Value = "CO" Or r.Cells("Type").Value = "CP" Then
            '    rec.MA = " "
            'End If
            'Recipient
            If Not Me.UltraTextEditor2.Text = "*" Then
                rec.Recipent = Me.UltraTextEditor2.Text
            Else
                rec.Recipent = r.Cells("Recipent").Text
            End If
            'Trader
            If Not Me.UltraComboEditor3.Text = "*" Then
                rec.Trader = Me.UltraComboEditor3.Text
            Else
                rec.Trader = r.Cells("Trader").Text
            End If
            If r.Cells("Type").Value = "FS" Or r.Cells("Type").Value = "CC" Then
                rec.Trader = Nothing
            End If
            If Not Me.UltraComboEditor1.Text = "*" Then
                rec.Pflag = Me.UltraComboEditor1.Text
            Else
                rec.Pflag = r.Cells("Pflag").Text
            End If
            rec.Chgdate = Today
            rec.User = System.Environment.UserName
            dc.tblECMmasts.InsertOnSubmit(rec)

            Try
                dc.SubmitChanges()
            Catch ex As Exception
                MessageBox.Show("Insert failed contact IT for assistance " & vbCrLf & "Message Code " & ex.Message, "Insert Failure (tblECMMast)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Exit Sub
            End Try
        Next
    End Sub
    
    Public Sub edit_data()
        Dim type As String = Me.UltraGrid1.Rows(0).Cells("Type").Value
        eflag = False
        If Me.UltraTextEditor1.Text = "*" And _
            Me.UltraComboEditor2.Text = "*" And _
            Me.UltraTextEditor2.Text = "*" And _
            Me.UltraComboEditor3.Text = "*" And _
            Me.UltraComboEditor1.Text = "*" Then
            MessageBox.Show("At least one value must be selected for copy/change", "Missing Selection", MessageBoxButtons.OK)
            eflag = True
            Exit Sub
        End If

        Select Case type
            Case "FS", "CC" 'edit final settlement
                If String.IsNullOrEmpty(Me.UltraTextEditor1.Text) Then
                    MessageBox.Show(Me.UltraLabel4.Text & " invalid or missing, please retry", "Invalid " & Me.UltraLabel4.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    eflag = True
                    Exit Sub
                End If
                If String.IsNullOrEmpty(Me.UltraComboEditor2.Value) Then
                    MessageBox.Show(Me.UltraLabel5.Text & " invalid or missing, please retry", "Invalid " & Me.UltraLabel5.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    eflag = True
                    Exit Sub
                End If
                If String.IsNullOrEmpty(Me.UltraTextEditor2.Text) Then
                    MessageBox.Show(Me.UltraLabel6.Text & " invalid or missing, please retry", "Invalid " & Me.UltraLabel6.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    eflag = True
                    Exit Sub
                End If
            Case "CO", "CP"
                If String.IsNullOrEmpty(Me.UltraTextEditor1.Text) Then
                    MessageBox.Show(Me.UltraLabel4.Text & " invalid or missing, please retry", "Invalid " & Me.UltraLabel4.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    eflag = True
                    Exit Sub
                End If
                'If String.IsNullOrEmpty(Me.UltraTextEditor2.Text) Then
                '    MessageBox.Show(Me.UltraLabel6.Text & " invalid or missing, please retry", "Invalid " & Me.UltraLabel6.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                '    eflag = True
                '    Exit Sub
                'End If
                If String.IsNullOrEmpty(Me.UltraComboEditor3.Value) Then
                    MessageBox.Show(Me.UltraLabel7.Text & " invalid or missing, please retry", "Invalid " & Me.UltraLabel7.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    eflag = True
                    Exit Sub
                End If
                If String.IsNullOrEmpty(Me.UltraTextEditor2.Text) Then
                    MessageBox.Show(Me.UltraLabel6.Text & " invalid or missing, please retry", "Invalid " & Me.UltraLabel6.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    eflag = True
                    Exit Sub
                End If
        End Select
        'edit zip code
        'separate strings with comma delimiters
        If Me.UltraTextEditor2.Value <> "*" Then
            Dim e As String = Trim(Me.UltraTextEditor2.Text)
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
        End If
        'check customer confirmation
        If Me.UltraTextEditor1.Text <> "*" Then
            Dim msg As tblECMhelpcontact = ops.get_helpcontact(appid) 'contact info
            If ops.check_confirmation(Me.UltraTextEditor1.Text) = 0 Then
                MessageBox.Show("Customer Confirmation record not on file" & vbCrLf & "Please verify " & _
                    msg.Contact, "Customer Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                eflag = True
                Exit Sub
            End If
        End If

    End Sub
    Public Function check_email(ea As String) As Boolean
        Dim pattern As String = "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"
        'Dim pattern As String = "\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*([,;]\s*\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)*"
        Dim emailAddressMatch As Match = Regex.Match(ea, pattern)
        'Show result
        If Not emailAddressMatch.Success Then Return False
        Return True
    End Function

   
End Class
