Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Shared
Public Class FrmPrinter_Settings
    Dim appid As String = "FrmPrinter_Settings"
    Dim userid As String = System.Environment.UserName

    Private Sub FrmPrinter_Settings_Load(sender As Object, e As System.EventArgs) Handles Me.Load
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
        Me.UltraGrid1.SetDataBinding(db.get_tblECMPrinter_Settings_linq, Nothing)
        Me.UltraGrid1.DataBind()
    End Sub

    Private Sub UltraGrid1_DoubleClickRow(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles UltraGrid1.DoubleClickRow
        If Me.UltraGrid1.Selected.Rows.Count > 0 Then
            If check_row_count() = False Then
                Dim r As UltraGridRow
                r = Me.UltraGrid1.Selected.Rows(0)
                Dim f As New FrmPrinter_SettingsAC(r.Cells(0).Value)
                f.ShowDialog()
                If f.DialogResult = Windows.Forms.DialogResult.OK Then
                    'update db
                    'update_record(f)
                End If
                setup_grid()
            End If
        End If
    End Sub
    Private Sub UltraGrid1_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles UltraGrid1.InitializeLayout
        e.Layout.Bands(0).Columns(0).Hidden = True
        'e.Layout.Bands(0).Columns(1).Hidden = True
        'e.Layout.Bands(0).Columns(2).Hidden = True
        e.Layout.Bands(0).Columns(3).Hidden = True
        e.Layout.Bands(0).Columns(4).Hidden = True
        'e.Layout.Bands(0).Columns(5).Hidden = True
        'e.Layout.Bands(0).Columns(5).Hidden = True
        'e.Layout.Bands(0).Columns(6).Hidden = True
        'e.Layout.Bands(0).Columns(8).Hidden = True
        'e.Layout.Bands(0).Columns(9).Hidden = True
        'e.Layout.Bands(0).Columns(10).Hidden = True
    End Sub
    Private Sub set_display()
        With Me.UltraGrid1
            '.DisplayLayout.Bands(0).Columns(1).Header.Caption = "MA ID"
            '.DisplayLayout.Bands(0).Columns(2).Header.Caption = "Location"
            '.DisplayLayout.Bands(0).Columns(5).Header.Caption = "Recipient Email"
            '.DisplayLayout.Bands(0).Columns(8).Header.Caption = "Merchandiser Name"
            '.DisplayLayout.Bands(0).Columns(7).Header.Caption = "Pct/Batch"
            '.DisplayLayout.Bands(0).Columns(8).Header.Caption = "Cost/Batch"
            .DisplayLayout.Bands(0).Columns(1).Width = 200
            '.DisplayLayout.Bands(0).Columns(4).Width = 200
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
        Dim f As New FrmPrinter_SettingsAC(0)
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
                Dim f As New FrmPrinter_SettingsAC(r.Cells(0).Value)
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
    Private Sub UltraBtnCopy_Click(sender As System.Object, e As System.EventArgs) Handles UltraBtnCopy.Click
        If Me.UltraGrid1.Selected.Rows.Count > 0 Then
            If check_row_count() = False Then
                Dim rc As Integer = Me.UltraGrid1.Selected.Rows(0).Index
                Dim r As UltraGridRow
                r = Me.UltraGrid1.Selected.Rows(0)
                Dim f As New FrmPrinter_SettingsAC(r.Cells(0).Value)
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
    Private Function check_row_count() As Boolean
        If Me.UltraGrid1.Selected.Rows.Count > 1 Then
            MessageBox.Show("Multiple rows cannot be selected for editing/deleting, please reselect", "Invalid Row Selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub insert_record(f As FrmPrinter_SettingsAC)
        Dim dc As New DataClasses1DataContext
        Dim rec As New tblECMPrinter_Setting With {.Printer_Name = f.UltraComboEditor1.Text, _
                                          .Postscript_Flag = f.UltraCheckEditor1.CheckedValue, _
                                           .User = userid, .Chgdate = Today}
        dc.tblECMPrinter_Settings.InsertOnSubmit(rec)
        Try
            dc.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("Insert failed contact IT for assistance " & vbCrLf & "Message Code " & ex.Message, "Insert Failure (tblECMmprcntl2)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    Private Sub delete_record(r As Decimal)
        Dim dc As New DataClasses1DataContext
        Dim e As tblECMPrinter_Setting
        e = (From c In dc.tblECMPrinter_Settings
                 Where c.Recid = r Select c).SingleOrDefault
        dc.tblECMPrinter_Settings.DeleteOnSubmit(e)
        Try
            dc.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("Delete failed contact IT for assistance " & vbCrLf & "Message Code " & ex.Message, "Delete Failure (tblECMprcntl2)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    Private Sub UltraGrid1_BeforeRowsDeleted(sender As Object, e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles UltraGrid1.BeforeRowsDeleted
        e.DisplayPromptMsg = False
        If check_row_count() = True Then
            e.Cancel = True
            Exit Sub
        End If
        If MessageBox.Show("Delete selected row? ", "Delete Row", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            If Me.UltraGrid1.Selected.Rows.Count > 0 Then
                delete_record(Me.UltraGrid1.Selected.Rows(0).Cells(0).Value)
            End If
        End If
    End Sub
    Private Sub update_record(f As FrmPrinter_SettingsAC)
        Dim r As UltraGridRow
        Dim rr As Decimal
        r = Me.UltraGrid1.Selected.Rows(0)
        rr = r.Cells(0).Value
        Dim dc As New DataClasses1DataContext
        Dim rec = (From c In dc.tblECMPrinter_Settings
                 Where (rr = c.Recid)).SingleOrDefault
        rec.Printer_Name = f.UltraComboEditor1.Text
        rec.Postscript_Flag = f.UltraCheckEditor1.CheckedValue
        rec.Chgdate = Today
        rec.User = System.Environment.UserName
        Try
            dc.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("Update failed contact IT for assistance " & vbCrLf & "Message Code " & ex.Message, "Update Failure (tblERCMprcntl2)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    Private Sub UltraBtnPrinter_Click(sender As System.Object, e As System.EventArgs) Handles UltraBtnPrinter.Click
        'Postions to printer
        Dim l As Integer
        If Not String.IsNullOrEmpty(Me.UltraTextEditor1.Text) Then
            Dim r As UltraGridRow
            'Me.UltraTextEditor1.Text = Me.UltraTextEditor1.Text.ToUpper
            For Each r In Me.UltraGrid1.Rows
                If Trim(Me.UltraTextEditor1.Text).Length > r.Cells("Printer_Name").Text.Length Then
                    l = r.Cells("Printer_Name").Text.Length
                Else
                    l = Trim(Me.UltraTextEditor1.Text).Length
                End If
                If String.Compare(Me.UltraTextEditor1.Text, r.Cells("Printer_Name").Text.Substring(0, l), True) = 0 Then
                    'If Trim(Me.UltraTextEditor1.Text) = r.Cells("refid").Text.Substring(0, Trim(Me.UltraTextEditor1.Text).Length) Then
                    Me.UltraGrid1.Rows(r.Index).Activate()
                    Exit Sub
                End If
            Next
        End If
    End Sub
    
End Class