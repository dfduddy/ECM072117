Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Shared
Public Class FrmMRmaster
    Dim appid As String = "FrmMAmaster"
    Private Sub FrmMRmaster_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If ops.check_authority(9) = True Then
            Me.UltraGrid1.DisplayLayout.GroupByBox.Hidden = True
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
        Me.UltraGrid1.SetDataBinding(db.get_MRMast, Nothing)
        Me.UltraGrid1.DataBind()
    End Sub
    Private Sub set_display()
        'With Me.UltraGrid1
        Me.UltraGrid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True
        Me.UltraGrid1.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.XPThemed
        Me.UltraGrid1.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
        Me.UltraGrid1.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        Me.UltraGrid1.DisplayLayout.Override.SelectTypeRow = SelectType.Single
        Me.UltraGrid1.DisplayLayout.Override.AllowDelete = DefaultableBoolean.True
        Me.UltraGrid1.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False
        Me.UltraGrid1.DisplayLayout.Bands(0).Columns(0).Hidden = True
        Me.UltraGrid1.DisplayLayout.Bands(0).Columns(1).Header.Caption = "Merch ID"
        Me.UltraGrid1.DisplayLayout.Bands(0).Columns(2).Header.Caption = "Merch Name"
        Me.UltraGrid1.DisplayLayout.Bands(0).Columns(3).Header.Caption = "Merch Email"
        Me.UltraGrid1.DisplayLayout.Bands(0).Columns(4).Header.Caption = "Flag 1"
        Me.UltraGrid1.DisplayLayout.Bands(0).Columns(5).Hidden = True
        Me.UltraGrid1.DisplayLayout.Bands(0).Columns(6).Hidden = True
        'Me.UltraGrid1.DisplayLayout.Bands(0).Columns.Add()
        Me.UltraGrid1.DisplayLayout.GroupByBox.Hidden = True
        

        'End With
        set_active_column()
    End Sub
    Private Sub set_active_column()
        'Me.UltraGrid1.DisplayLayout.Bands(0).Columns(3).Style = ColumnStyle.CheckBox
        'Dim r As UltraGridRow
        'For Each r In Me.UltraGrid1.Rows
        '    If Not IsNothing(r.Cells(2).Value) Then
        '        r.Cells(3).Value = True
        '    End If
        'Next
    End Sub

    Private Sub UltraBtnExit_Click(sender As System.Object, e As System.EventArgs) Handles UltraBtnExit.Click
        Me.Dispose()
    End Sub

    Private Sub UltraBtnSelect_Click(sender As System.Object, e As System.EventArgs) Handles UltraBtnSelect.Click
        If Me.UltraGrid1.Selected.Rows.Count > 0 Then
            Dim r As UltraGridRow
            r = Me.UltraGrid1.Selected.Rows(0)
            Dim f As New FrmMRmasterAC(r.Cells(0).Value)
            f.ShowDialog()
            If f.DialogResult = Windows.Forms.DialogResult.OK Then
                'update db
                update_record(f)
            End If
            setup_grid()
            set_display()
        End If

    End Sub
    Private Sub UltraGrid1_AfterRowsDeleted(sender As Object, e As System.EventArgs) Handles UltraGrid1.AfterRowsDeleted
        If Me.UltraGrid1.Selected.Rows.Count > 0 Then
            delete_record(Me.UltraGrid1.Selected.Rows(0).Cells(0).Value)
        End If
    End Sub
    Private Sub UltraGrid1_BeforeRowsDeleted(sender As Object, e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles UltraGrid1.BeforeRowsDeleted
        e.DisplayPromptMsg = False
        If MessageBox.Show("Delete selected row? ", "Delete Row", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            If Me.UltraGrid1.Selected.Rows.Count > 0 Then
                delete_record(Me.UltraGrid1.Selected.Rows(0).Cells(0).Value)
            End If
        End If
    End Sub

    Private Sub UltraBtnAdd_Click(sender As System.Object, e As System.EventArgs) Handles UltraBtnAdd.Click
        Dim f As New FrmMRmasterAC(" ")
        f.ShowDialog()
        If f.DialogResult = Windows.Forms.DialogResult.OK Then
            'add record
            insert_record(f)
        End If
        setup_grid()
        set_display()
    End Sub
    Private Sub insert_record(f As FrmMRmasterAC)
        Dim dc As New DataClasses1DataContext
        'add mamast
        Dim rec1 As New tblMerchMast With
        {.fldMerchID = f.UltraTextEditor1.Text, .fldMerchName = f.UltraTextEditor2.Text, .fldMerchEmail = f.UltraTextEditor3.Text, .fldFlag1 = f.UltraComboEditor1.Text, .fldUser = System.Environment.UserName, .fldChangeDate = Today}
        dc.tblMerchMasts.InsertOnSubmit(rec1)
        Try
            dc.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("Insert failed contact IT for assistance " & vbCrLf & "Message Code " & ex.Message, "Insert Failure (tblECMmamast)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    Private Sub update_record(f As FrmMRmasterAC)
        Dim r As UltraGridRow
        Dim rr As String
        r = Me.UltraGrid1.Selected.Rows(0)
        rr = r.Cells(0).Value
        'Update MA id
        Dim dc As New DataClasses1DataContext
        Dim rec = (From c In dc.tblMerchMasts
                 Where (c.fldRecid = rr)).SingleOrDefault
        If Not IsNothing(rec) Then
            rec.fldmerchid = f.UltraTextEditor1.Text
            rec.fldMerchName = f.UltraTextEditor2.Text
            rec.fldMerchEmail = f.UltraTextEditor3.Text
            rec.fldFlag1 = f.UltraComboEditor1.Text
            rec.fldChangeDate = Today
            rec.fldUser = System.Environment.UserName
            Try
                dc.SubmitChanges()
            Catch ex As Exception
                MessageBox.Show("Update failed contact IT for assistance " & vbCrLf & "Message Code " & ex.Message, "Update Failure (tblMerchMast)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
            'dc.SubmitChanges()
        End If


        
    End Sub
    Private Sub delete_record(r As String)
        Dim dc As New DataClasses1DataContext
        If db.check_reid(Me.UltraGrid1.Selected.Rows(0).Cells(0).Value) = True Then
            Dim e As tblMerchMast
            e = (From c In dc.tblMerchMasts
                     Where c.fldRecid = r Select c).SingleOrDefault
            dc.tblMerchMasts.DeleteOnSubmit(e)
            Try
                dc.SubmitChanges()
            Catch ex As Exception
                MessageBox.Show("Delete failed contact IT for assistance " & vbCrLf & "Message Code " & ex.Message, "Delete Failure (tblECMmamast)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        End If
    End Sub

    Private Sub UltraGrid1_DoubleClickRow(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles UltraGrid1.DoubleClickRow
        If Me.UltraGrid1.Selected.Rows.Count > 0 Then
            Dim r As UltraGridRow
            r = Me.UltraGrid1.Selected.Rows(0)
            Dim f As New FrmMRmasterAC(r.Cells(0).Value)
            f.ShowDialog()
            If f.DialogResult = Windows.Forms.DialogResult.OK Then
                'update db
                update_record(f)
            End If
            setup_grid()
            set_display()
        End If
    End Sub

    Private Sub FrmMRmaster_LostFocus(sender As Object, e As EventArgs) Handles Me.LostFocus

    End Sub
End Class