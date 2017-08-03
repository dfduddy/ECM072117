Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Shared
Public Class FrmPrcntl3
    Dim appid As String = "FrmPrcntl3"
    Dim userid As String = System.Environment.UserName
    Private Sub FrmPrcntl3_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If ops.check_authority(9) = True Then
            set_datasource()
            setup_grid()
            set_display()
        Else
            Me.Dispose()
        End If
    End Sub
    Private Sub set_datasource()
    End Sub
    Private Sub setup_grid()
        Me.UltraGrid1.SetDataBinding(db.get_tblECMprcntl3_linq, Nothing)
        Me.UltraGrid1.DataBind()
    End Sub

    Private Sub UltraGrid1_DoubleClickRow(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles UltraGrid1.DoubleClickRow
        If Me.UltraGrid1.Selected.Rows.Count > 0 Then
            If check_row_count() = False Then
                Dim r As UltraGridRow
                r = Me.UltraGrid1.Selected.Rows(0)
                Dim f As New FrmPrcntl3AC(r.Cells(0).Value)
                f.ShowDialog()
                If f.DialogResult = Windows.Forms.DialogResult.OK Then
                    'update db
                    update_record(f)
                End If
                setup_grid()
            End If
        End If
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
            '.DisplayLayout.Override.SelectTypeRow = SelectType.Single
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

    Private Sub UltraBtnExit_Click(sender As System.Object, e As System.EventArgs) Handles UltraBtnExit.Click
        Me.Dispose()
    End Sub
    Private Sub UltraBtnAdd_Click(sender As System.Object, e As System.EventArgs) Handles UltraBtnAdd.Click
        Dim f As New FrmPrcntl3AC(0)
        f.ShowDialog()
        If f.DialogResult = Windows.Forms.DialogResult.OK Then
            'add record
            insert_record(f)
        End If
        setup_grid()
    End Sub

    Private Sub UltraGrid1_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles UltraGrid1.DoubleClick
        
    End Sub


    Private Sub UltraBtnSelect_Click(sender As System.Object, e As System.EventArgs) Handles UltraBtnSelect.Click
        If Me.UltraGrid1.Selected.Rows.Count > 0 Then
            If check_row_count() = False Then
                Dim rc As Integer = Me.UltraGrid1.Selected.Rows(0).Index
                Dim r As UltraGridRow
                r = Me.UltraGrid1.Selected.Rows(0)
                Dim f As New FrmPrcntl3AC(r.Cells(0).Value)
                f.ShowDialog()
                If f.DialogResult = Windows.Forms.DialogResult.OK Then
                    'update db
                    update_record(f)
                End If
                setup_grid()
                Me.UltraGrid1.Rows(rc).Activate()
            End If
        End If
    End Sub
    Private Sub insert_record(f As FrmPrcntl3AC)
        Dim dc As New DataClasses1DataContext
        Dim rec As New tblecmprcntl3 With {.Refid = f.UltraComboEditor1.Text, .Loc = f.UltraComboEditor2.Text, _
                                          .Zipcode = f.UltraTextEditor1.Text, .Formid = f.UltraComboEditor3.Text, _
                                           .PrinterID = f.UltraComboEditor4.Text, .Desc = f.UltraTextEditor2.Text, _
                                           .User = userid, .Chgdate = Today, .Pcopy = f.UltraComboEditor5.Text}
        dc.tblecmprcntl3s.InsertOnSubmit(rec)
        Try
            dc.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("Insert failed contact IT for assistance " & vbCrLf & "Message Code " & ex.Message, "Insert Failure (tblECMmprcntl3)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    Private Sub delete_record(r As Decimal)
        Dim dc As New DataClasses1DataContext
        Dim e As tblecmprcntl3
        e = (From c In dc.tblecmprcntl3s
                 Where c.Recid = r Select c).SingleOrDefault
        dc.tblecmprcntl3s.DeleteOnSubmit(e)
        Try
            dc.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("Delete failed contact IT for assistance " & vbCrLf & "Message Code " & ex.Message, "Delete Failure (tblECMprcntl3)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    Private Sub UltraGrid1_BeforeRowsDeleted(sender As Object, e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles UltraGrid1.BeforeRowsDeleted
        e.DisplayPromptMsg = False
        'If check_row_count() = True Then
        '    e.Cancel = True
        '    Exit Sub
        'End If
        'If MessageBox.Show("Delete selected row? ", "Delete Row", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
        '    If Me.UltraGrid1.Selected.Rows.Count > 0 Then
        '        delete_record(Me.UltraGrid1.Selected.Rows(0).Cells(0).Value)
        '    End If
        'End If
        If MessageBox.Show("Delete selected row(s)? ", "Delete Row(s)", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            If Me.UltraGrid1.Selected.Rows.Count > 0 Then
                For x As Integer = 0 To Me.UltraGrid1.Selected.Rows.Count - 1
                    delete_record(Me.UltraGrid1.Selected.Rows(x).Cells(0).Value)
                Next
            End If
        End If
    End Sub
    Private Sub update_record(f As FrmPrcntl3AC)
        Dim r As UltraGridRow
        Dim rr As Decimal
        r = Me.UltraGrid1.Selected.Rows(0)
        rr = r.Cells(0).Value
        Dim dc As New DataClasses1DataContext
        Dim rec = (From c In dc.tblecmprcntl3s
                 Where (rr = c.Recid)).SingleOrDefault
        rec.Refid = f.UltraComboEditor1.Text
        rec.Loc = f.UltraComboEditor2.Text
        rec.Zipcode = f.UltraTextEditor1.Text
        rec.Formid = f.UltraComboEditor3.Text
        rec.PrinterID = f.UltraComboEditor4.Text
        rec.Desc = f.UltraTextEditor2.Text
        rec.Chgdate = Today
        rec.User = System.Environment.UserName
        rec.Pcopy = f.UltraComboEditor5.TextLength
        Try
            dc.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("Update failed contact IT for assistance " & vbCrLf & "Message Code " & ex.Message, "Update Failure (tblERCMprcntl3)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub UltraBtnCopy_Click(sender As System.Object, e As System.EventArgs) Handles UltraBtnCopy.Click
        If Me.UltraGrid1.Selected.Rows.Count > 0 Then
            Dim rc As Integer = Me.UltraGrid1.Selected.Rows.Count
            Dim rr As Integer = Me.UltraGrid1.Selected.Rows(0).Index 'first selected row
            post_requested_changes()
            Dim f As New FrmPrcntl3CM()
            f.ShowDialog()
            If f.DialogResult = Windows.Forms.DialogResult.OK Then
                'update db
                'update_record(f)
            End If
            setup_grid()
            For c = 1 To rc
                Me.UltraGrid1.Rows(rr).Selected = True
                Me.UltraGrid1.Rows(rr).Activate()
                rr += 1
            Next
        End If
    End Sub
    Public Sub post_requested_changes()
        Dim dc As New DataClasses1DataContext
        dc.ExecuteCommand("truncate table prcntl3_change")
        Dim r As UltraGridRow
        For Each r In UltraGrid1.Selected.Rows
            Dim rec As New prcntl3_change With {.Refid = r.Cells(1).Value, .Loc = r.Cells(2).Value, _
                                              .Zipcode = r.Cells(3).Value, .Formid = r.Cells(4).Value, _
                                               .PrinterID = r.Cells(5).Value, .Desc = r.Cells(6).Value, .User = userid, .Chgdate = Today, .Pcopy = r.Cells(9).Value, .Orecid = r.Cells(0).Value}
            dc.prcntl3_changes.InsertOnSubmit(rec)
            Try
                dc.SubmitChanges()
            Catch ex As Exception
                MessageBox.Show("Insert failed contact IT for assistance " & vbCrLf & "Message Code " & ex.Message, "Insert Failure (tblECMmprcntl3)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        Next
    End Sub
    Private Function check_row_count() As Boolean
        If Me.UltraGrid1.Selected.Rows.Count > 1 Then
            MessageBox.Show("Multiple rows cannot be selected for editing/deleting, please reselect", "Invalid Row Selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub UltraBtnUser_Click(sender As System.Object, e As System.EventArgs) Handles UltraBtnUser.Click
        'Postions to user
        If Not String.IsNullOrEmpty(Me.UltraTextEditor1.Text) Then
            Dim r As UltraGridRow
            'Me.UltraTextEditor1.Text = Me.UltraTextEditor1.Text.ToUpper
            For Each r In Me.UltraGrid1.Rows
                If String.Compare(Me.UltraTextEditor1.Text, r.Cells("refid").Text.Substring(0, Trim(Me.UltraTextEditor1.Text).Length), True) = 0 Then
                    'If Trim(Me.UltraTextEditor1.Text) = r.Cells("refid").Text.Substring(0, Trim(Me.UltraTextEditor1.Text).Length) Then
                    Me.UltraGrid1.Rows(r.Index).Activate()
                    Exit Sub
                End If
            Next
        End If
    End Sub

End Class