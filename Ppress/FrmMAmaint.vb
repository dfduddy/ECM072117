Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Shared
Public Class FrmMAmaint
    Dim appid As String = "FrmMAmaint"
    Private Sub FrmMAmaint_Load(sender As Object, e As System.EventArgs) Handles Me.Load
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
        Me.UltraGrid1.SetDataBinding(db.get_MAJoin, Nothing)
        Me.UltraGrid1.DataBind()
    End Sub
    Private Sub set_display()
        With Me.UltraGrid1
            .DisplayLayout.Bands(0).Columns(0).Header.Caption = "MA ID"
            .DisplayLayout.Bands(0).Columns(1).Header.Caption = "MA Name"
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Print Copies"
            .DisplayLayout.Bands(0).Columns.Add()
            .DisplayLayout.Bands(0).Columns(3).Header.Caption = "Active"
            '.DisplayLayout.Bands(0).Columns(7).Header.Caption = "Pct/Batch"
            '.DisplayLayout.Bands(0).Columns(8).Header.Caption = "Cost/Batch"
            '.DisplayLayout.Bands(0).Columns(1).Width = 250
            '.DisplayLayout.Bands(0).Columns(5).Width = 250
            '.DisplayLayout.Override.AllowAddNew = AllowAddNew.Yes
            '.DisplayLayout.AddNewBox.Hidden = False
            '.DisplayLayout.Bands(0).Columns(0).CellActivation = Activation.Disabled
            Me.UltraGrid1.DisplayLayout.GroupByBox.Hidden = True
            Me.UltraGrid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True
            Me.UltraGrid1.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.XPThemed
            Me.UltraGrid1.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
            Me.UltraGrid1.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
            Me.UltraGrid1.DisplayLayout.Override.SelectTypeRow = SelectType.Single
            'Me.UltraGrid1.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False
            Me.UltraGrid1.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False
        End With
        set_active_column()
    End Sub
    Private Sub set_active_column()
        Me.UltraGrid1.DisplayLayout.Bands(0).Columns(3).Style = ColumnStyle.CheckBox
        Dim r As UltraGridRow
        For Each r In Me.UltraGrid1.Rows
            If Not IsNothing(r.Cells(2).Value) Then
                r.Cells(3).Value = True
            End If
        Next
    End Sub

    Private Sub UltraBtnExit_Click(sender As System.Object, e As System.EventArgs) Handles UltraBtnExit.Click
        Me.Dispose()
    End Sub

    Private Sub UltraBtnSelect_Click(sender As System.Object, e As System.EventArgs) Handles UltraBtnSelect.Click
        
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
        Dim f As New FrmMAmaintAC(" ")
        f.ShowDialog()
        If f.DialogResult = Windows.Forms.DialogResult.OK Then
            'add record
            insert_record(f)
        End If
        setup_grid()
        set_display()
    End Sub
    Private Sub insert_record(f As FrmMAmaintAC)
        Dim dc As New DataClasses1DataContext
        'add maid
        If db.check_maid(f.UltraTextEditor1.Text) = False Then
            Dim rec As New tblECMmaid With
            {.ID = f.UltraTextEditor1.Text, .name = f.UltraTextEditor2.Text, .Pcopy = 0, .User = System.Environment.UserName, .Chgdate = Today}
            dc.tblECMmaids.InsertOnSubmit(rec)
            Try
                dc.SubmitChanges()
            Catch ex As Exception
                MessageBox.Show("Insert failed contact IT for assistance " & vbCrLf & "Message Code " & ex.Message, "Insert Failure (tblECMmaid)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        End If
        'add mamast
        If f.UltraCheckEditor1.CheckedValue = True Then   'active
            If db.check_mamast(f.UltraTextEditor1.Text) = False Then
                Dim rec1 As New tblECMmamast With
            {.MA = f.UltraTextEditor1.Text, .Name = f.UltraTextEditor2.Text, .Pcopy = f.UltraComboEditor1.Text, .User = System.Environment.UserName, .Chgdate = Today}
                dc.tblECMmamasts.InsertOnSubmit(rec1)
                Try
                    dc.SubmitChanges()
                Catch ex As Exception
                    MessageBox.Show("Insert failed contact IT for assistance " & vbCrLf & "Message Code " & ex.Message, "Insert Failure (tblECMmamast)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End Try
            End If
        End If

    End Sub
    Private Sub update_record(f As FrmMAmaintAC)
        Dim r As UltraGridRow
        Dim rr As String
        r = Me.UltraGrid1.Selected.Rows(0)
        rr = r.Cells(0).Value
        'Update MA id
        Dim dc As New DataClasses1DataContext
        Dim rec = (From c In dc.tblECMmaids
                 Where (rr = c.ID)).SingleOrDefault
        If Not IsNothing(rec) Then
            rec.ID = f.UltraTextEditor1.Text
            rec.name = f.UltraTextEditor2.Text
            rec.Pcopy = 0
            rec.Chgdate = Today
            rec.User = System.Environment.UserName
            rec.ECMflag = False
            Try
                dc.SubmitChanges()
            Catch ex As Exception
                MessageBox.Show("Update failed contact IT for assistance " & vbCrLf & "Message Code " & ex.Message, "Update Failure (tblECMMAid)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
            'dc.SubmitChanges()
        End If
        'update MAmast

        If f.UltraCheckEditor1.CheckedValue = True Then   'active
            Dim rec1 = (From c In dc.tblECMmamasts
                 Where (rr = c.MA)).SingleOrDefault
            If Not IsNothing(rec1) Then  'update record
                rec1.MA = f.UltraTextEditor1.Text
                rec1.Name = f.UltraTextEditor2.Text
                rec1.Pcopy = f.UltraComboEditor1.Text
                rec1.Chgdate = Today
                rec1.User = System.Environment.UserName
                Try
                    dc.SubmitChanges()
                Catch ex As Exception
                    MessageBox.Show("Update failed contact IT for assistance " & vbCrLf & "Message Code " & ex.Message, "Update Failure (tblECMmamast)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End Try
            Else
                If db.check_mamast(f.UltraTextEditor1.Text) = False Then 'add record
                    Dim rec2 As New tblECMmamast With
                {.MA = f.UltraTextEditor1.Text, .Name = f.UltraTextEditor2.Text, .Pcopy = f.UltraComboEditor1.Text, .User = System.Environment.UserName, .Chgdate = Today}
                    dc.tblECMmamasts.InsertOnSubmit(rec2)
                    Try
                        dc.SubmitChanges()
                    Catch ex As Exception
                        MessageBox.Show("Insert failed contact IT for assistance " & vbCrLf & "Message Code " & ex.Message, "Insert Failure (tblECMmamast)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End Try
                End If
            End If
        Else
            'delete mamast record
            If db.check_mamast(f.UltraTextEditor1.Text) = True Then
                Dim ddt As tblECMmamast = (From d In dc.tblECMmamasts
                       Where (d.MA = f.UltraTextEditor1.Text) Select d).SingleOrDefault
                dc.tblECMmamasts.DeleteOnSubmit(ddt)
                Try
                    dc.SubmitChanges()
                Catch ex As Exception
                End Try
            End If
        End If
    End Sub
    Private Sub delete_record(r As String)
        Dim dc As New DataClasses1DataContext
        If db.check_mamast(Me.UltraGrid1.Selected.Rows(0).Cells(0).Value) = True Then
            Dim e As tblECMmamast
            e = (From c In dc.tblECMmamasts
                     Where c.MA = r Select c).SingleOrDefault
            dc.tblECMmamasts.DeleteOnSubmit(e)
            Try
                dc.SubmitChanges()
            Catch ex As Exception
                MessageBox.Show("Delete failed contact IT for assistance " & vbCrLf & "Message Code " & ex.Message, "Delete Failure (tblECMmamast)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        End If
        If db.check_maid(Me.UltraGrid1.Selected.Rows(0).Cells(0).Value) = True Then
            Dim ee As tblECMmaid
            ee = (From c In dc.tblECMmaids
                     Where c.ID = r Select c).SingleOrDefault
            dc.tblECMmaids.DeleteOnSubmit(ee)
            Try
                dc.SubmitChanges()
            Catch ex As Exception
                MessageBox.Show("Delete failed contact IT for assistance " & vbCrLf & "Message Code " & ex.Message, "Delete Failure (tblECMmamaid)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        End If
    End Sub

    Private Sub UltraGrid1_DoubleClickRow(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles UltraGrid1.DoubleClickRow
        If Me.UltraGrid1.Selected.Rows.Count > 0 Then
            Dim r As UltraGridRow
            r = Me.UltraGrid1.Selected.Rows(0)
            Dim f As New FrmMAmaintAC(r.Cells(0).Value)
            f.ShowDialog()
            If f.DialogResult = Windows.Forms.DialogResult.OK Then
                'update db
                update_record(f)
            End If
            setup_grid()
            set_display()
        End If
    End Sub
End Class