Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Shared
Public Class FrmPrcntl3CM
    Private grid As UltraGrid
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        setup_panel()
        ' Add any initialization after the InitializeComponent() call.
    End Sub
    
    Private Sub setup_grid()
        Me.UltraGrid1.SetDataBinding(db.get_prcntl3_change_linq, Nothing)
        Me.UltraGrid1.DataBind()
    End Sub

    Private Sub FrmPrcntl3CM_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        set_datasource()
        setup_grid()
        set_display()
        init_panel()
        Me.UltraOptionSet1.CheckedIndex = 0
    End Sub
    Private Sub set_datasource()
    End Sub
    Private Sub UltraGrid1_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles UltraGrid1.InitializeLayout
        e.Layout.Bands(0).Columns(0).Hidden = True
        'e.Layout.Bands(0).Columns(1).Hidden = True
        'e.Layout.Bands(0).Columns(2).Hidden = True
        ' ''e.Layout.Bands(0).Columns(3).Hidden = True
        ' ''e.Layout.Bands(0).Columns(4).Hidden = True
        'e.Layout.Bands(0).Columns(5).Hidden = True
        e.Layout.Bands(0).Columns(7).Hidden = True
        e.Layout.Bands(0).Columns(8).Hidden = True
        'e.Layout.Bands(0).Columns(8).Hidden = True
        'e.Layout.Bands(0).Columns(9).Hidden = True
        'e.Layout.Bands(0).Columns(10).Hidden = True
    End Sub
    Private Sub set_display()
        With Me.UltraGrid1
            .DisplayLayout.Bands(0).Columns(1).Header.Caption = "User/Reference ID"
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Location"
            '.DisplayLayout.Bands(0).Columns(5).Header.Caption = "Recipient Email"
            '.DisplayLayout.Bands(0).Columns(8).Header.Caption = "Merchandiser Name"
            '.DisplayLayout.Bands(0).Columns(7).Header.Caption = "Pct/Batch"
            '.DisplayLayout.Bands(0).Columns(8).Header.Caption = "Cost/Batch"
            .DisplayLayout.Bands(0).Columns(1).Width = 150
            .DisplayLayout.Bands(0).Columns(5).Width = 150
            '.DisplayLayout.Override.AllowAddNew = AllowAddNew.Yes
            '.DisplayLayout.AddNewBox.Hidden = False
            '.DisplayLayout.Bands(0).Columns(0).CellActivation = Activation.Disabled
            .DisplayLayout.GroupByBox.Hidden = True
            .DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True
            .DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.XPThemed
            .DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
            .DisplayLayout.Override.AllowAddNew = AllowAddNew.No
            .DisplayLayout.Override.SelectTypeRow = SelectType.Single
            'Me.UltraGrid1.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False
            .DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False
        End With
        set_col_headers()
    End Sub
    Private Sub set_col_headers()
        Dim col As UltraGridColumn
        For Each col In Me.UltraGrid1.DisplayLayout.Bands(0).Columns
            col.Header.Appearance.ThemedElementAlpha = Alpha.Transparent
            col.Header.Appearance.BackColor = Color.Black
            col.Header.Appearance.ForeColor = Color.White
        Next
    End Sub

    Private Sub UltraBtnCancel_Click(sender As System.Object, e As System.EventArgs) Handles UltraBtnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Dispose()
    End Sub

    Private Sub UltraBtnOK_Click(sender As System.Object, e As System.EventArgs) Handles UltraBtnOK.Click
        If Me.UltraGrid1.Rows.Count > 0 Then
             Select Me.UltraOptionSet1.CheckedIndex
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
    End Sub
    Sub setup_panel()
        Dim tt6 As New UltraWinToolTip.UltraToolTipInfo
        tt6.ToolTipText = "Used to print copy automatically when emailed to customer." & vbCrLf & "P=print 1 copy." & vbCrLf & "blank=no print."
        'Me.UltraComboEditor1.SetDataBinding(db.get_tblECMprcntl3_refid, Nothing)
        Me.UltraComboEditor1.DataSource = db.get_tblECMprcntl3_refid
        Me.UltraComboEditor1.ValueMember = "Refid"
        Me.UltraComboEditor1.DisplayMember = "Refid"
        'Me.UltraCombo1.Rows.Band.Columns(1).Width = "200"
        Me.UltraComboEditor2.DataSource = db.get_tblECMprcntl3_loc
        Me.UltraComboEditor2.ValueMember = "Loc"
        Me.UltraComboEditor2.DisplayMember = "Loc"
        Me.UltraComboEditor3.DataSource = db.get_tblECMprcntl3_zipcode
        Me.UltraComboEditor3.ValueMember = "ZipCode"
        Me.UltraComboEditor3.DisplayMember = "ZipCode"
        Me.UltraComboEditor4.DataSource = db.get_tblECMprcntl3_formid
        Me.UltraComboEditor4.ValueMember = "formid"
        Me.UltraComboEditor4.DisplayMember = "formid"
        Me.UltraComboEditor5.DataSource = db.get_tblECMprcntl3_printerid
        Me.UltraComboEditor5.ValueMember = "printerid"
        Me.UltraComboEditor5.DisplayMember = "printerid"
    End Sub
    Public Sub init_panel()
        Me.UltraComboEditor1.Text = "*"
        Me.UltraComboEditor2.Text = "*"
        Me.UltraComboEditor3.Text = "*"
        Me.UltraComboEditor4.Text = "*"
        Me.UltraComboEditor5.Text = "*"
        Me.UltraComboEditor6.Text = "*"
        Me.UltraComboEditor7.Text = "*"
    End Sub
    Public Sub process_change()
        Dim r As UltraGridRow
        Dim rr As Integer
        For Each r In UltraGrid1.Rows
            rr = r.Cells("Orecid").Value
            Dim dc As New DataClasses1DataContext
            Dim rec = (From c In dc.tblecmprcntl3s
                     Where (rr = c.Recid)).SingleOrDefault
            If Not Me.UltraComboEditor1.Text = "*" Then
                rec.Refid = Me.UltraComboEditor1.Text
            End If
            If Not Me.UltraComboEditor2.Text = "*" Then
                rec.Loc = Me.UltraComboEditor2.Text
            End If
            If Not Me.UltraComboEditor3.Text = "*" Then
                rec.Zipcode = Me.UltraComboEditor3.Text
            End If
            If Not Me.UltraComboEditor4.Text = "*" Then
                rec.Formid = Me.UltraComboEditor4.Text
            End If
            If Not Me.UltraComboEditor5.Text = "*" Then
                rec.PrinterID = Me.UltraComboEditor5.Text
            End If
            If Not Me.UltraComboEditor6.Text = "*" Then
                rec.Desc = Me.UltraComboEditor6.Text
            End If
            rec.Chgdate = Today
            rec.User = System.Environment.UserName
            If Not Me.UltraComboEditor7.Text = "*" Then
                rec.Pcopy = Me.UltraComboEditor7.Text
            End If
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
            Dim rec As New tblecmprcntl3
            If Not Me.UltraComboEditor1.Text = "*" Then
                rec.Refid = Me.UltraComboEditor1.Text
            Else
                rec.Refid = r.Cells("refid").Text
            End If
            If Not Me.UltraComboEditor2.Text = "*" Then
                rec.Loc = Me.UltraComboEditor2.Text
            Else
                rec.Loc = r.Cells("loc").Text
            End If
            If Not Me.UltraComboEditor3.Text = "*" Then
                rec.Zipcode = Me.UltraComboEditor3.Text
            Else
                rec.Zipcode = r.Cells("zipcode").Text
            End If
            If Not Me.UltraComboEditor4.Text = "*" Then
                rec.Formid = Me.UltraComboEditor4.Text
            Else
                rec.Formid = r.Cells("formid").Text
            End If
            If Not Me.UltraComboEditor5.Text = "*" Then
                rec.PrinterID = Me.UltraComboEditor5.Text
            Else
                rec.PrinterID = r.Cells("printerid").Text
            End If
            If Not Me.UltraComboEditor6.Text = "*" Then
                rec.Desc = Me.UltraComboEditor6.Text
            Else
                rec.Desc = r.Cells("desc").Text
            End If
            rec.Chgdate = Today
            rec.User = System.Environment.UserName
            If Not Me.UltraComboEditor7.Text = "*" Then
                rec.Pcopy = Me.UltraComboEditor7.Text
            Else
                rec.Pcopy = r.Cells("pcopy").Text
            End If
            dc.tblecmprcntl3s.InsertOnSubmit(rec)
            Try
                dc.SubmitChanges()
            Catch ex As Exception
                MessageBox.Show("Insert failed contact IT for assistance " & vbCrLf & "Message Code " & ex.Message, "Insert Failure (tblECMmprcntl3)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Exit Sub
            End Try
        Next
    End Sub
End Class