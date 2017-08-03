Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Shared
Public Class FrmCustConf
    Dim sql As String

    Private Sub FrmCustConf_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If ops.check_authority(8) = True Then
            'Me.UltraGrid1.DisplayLayout.GroupByBox.Hidden = True
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
        Me.UltraGrid1.SetDataBinding(db.get_CustConf, Nothing)
        Me.UltraGrid1.DataBind()
    End Sub

    Private Sub UltraGrid1_DoubleClickRow(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles UltraGrid1.DoubleClickRow
        If Me.UltraGrid1.Selected.Rows.Count > 0 Then
            Dim r As UltraGridRow
            r = Me.UltraGrid1.Selected.Rows(0)
            Dim f As New FrmCustConfAC(r.Cells(0).Value, r.Cells(1).Value)
            f.ShowDialog()
            If f.DialogResult = Windows.Forms.DialogResult.OK Then
                'update db
                update_record(f)
            End If
            setup_grid()
        End If
    End Sub
    Private Sub UltraGrid1_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles UltraGrid1.InitializeLayout
        'e.Layout.Bands(0).Columns(0).Hidden = True
        'e.Layout.Bands(0).Columns(1).Hidden = True
        'e.Layout.Bands(0).Columns(2).Hidden = True
        e.Layout.Bands(0).Columns(3).Hidden = True
        e.Layout.Bands(0).Columns(4).Hidden = True
        'e.Layout.Bands(0).Columns(5).Hidden = True
        'e.Layout.Bands(0).Columns(6).Hidden = True
        'e.Layout.Bands(0).Columns(7).Hidden = True

        'e.Layout.Bands(0).Columns(8).Hidden = True
        'e.Layout.Bands(0).Columns(9).Hidden = True
        'e.Layout.Bands(0).Columns(10).Hidden = True

    End Sub
    Private Sub set_display()
        'Me.UltraGrid1.DisplayLayout.Bands(0).Columns(3).Header.Caption = "BOM"
        ' Me.UltraGrid1.DisplayLayout.Bands(0).Columns(5).Header.Caption = "Recipient"
        ' Me.UltraGrid1.DisplayLayout.Bands(0).Columns(8).Header.Caption = "Merchandiser"
        'Me.UltraGrid1.DisplayLayout.Bands(0).Columns(7).Header.Caption = "Pct/Batch"
        'Me.UltraGrid1.DisplayLayout.Bands(0).Columns(8).Header.Caption = "Cost/Batch"
        Me.UltraGrid1.DisplayLayout.Bands(0).Columns(0).Width = 50
        Me.UltraGrid1.DisplayLayout.Bands(0).Columns(5).Width = 250
        'Me.UltraGrid1.DisplayLayout.Override.AllowAddNew = AllowAddNew.Yes
        'Me.UltraGrid1.DisplayLayout.AddNewBox.Hidden = False
        'Me.UltraGrid1.DisplayLayout.Bands(0).Columns(0).CellActivation = Activation.Disabled
        Me.UltraGrid1.DisplayLayout.GroupByBox.Hidden = True
        Me.UltraGrid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True
        Me.UltraGrid1.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.XPThemed
        Me.UltraGrid1.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
        Me.UltraGrid1.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        Me.UltraGrid1.DisplayLayout.Override.SelectTypeRow = SelectType.Single
        'Me.UltraGrid1.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False
        Me.UltraGrid1.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False
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
        Dim r As UltraGridRow = Nothing
        Dim f As New FrmCustConfAC(" ", " ")
        f.ShowDialog()
        If f.DialogResult = Windows.Forms.DialogResult.OK Then
            'add record
            insert_record(f)
            setup_grid()
        End If
    End Sub
    Private Sub UltraGrid1_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles UltraGrid1.MouseDoubleClick
        
    End Sub
    Private Sub insert_record(f As FrmCustConfAC)
        Dim dc As New DataClasses1DataContext
        Dim rec As New tblecmCustConf With
        {.location = f.UltraCombo2.Value, .Custid = f.UltraTextEditor1.Value, .RFlag = f.CheckBox1.Checked,
         .confdate = f.UltraDateTimeEditor1.Value, .adddate = Today, .user = System.Environment.UserName}
        dc.tblECMCustConfs.InsertOnSubmit(rec)
        Try
            dc.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("Insert failed contact IT for assistance " & vbCrLf & "Message Code " & ex.Message, "Insert Failure (tblECMCustConf)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    Private Sub delete_record(loc As String, cust As String)
        Dim dc As New DataClasses1DataContext
        Dim e As tblECMCustConf
        e = (From c In dc.tblECMCustConfs
                 Where c.Location = loc And c.Custid = cust Select c).SingleOrDefault
        dc.tblECMCustConfs.DeleteOnSubmit(e)
        Try
            dc.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("Delete failed contact IT for assistance " & vbCrLf & "Message Code " & ex.Message, "Delete Failure (tblECMCustConf)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    Private Sub update_record(f As FrmCustConfAC)
        Dim r As UltraGridRow
        r = Me.UltraGrid1.Selected.Rows(0)
        Dim dc As New DataClasses1DataContext
        Dim rec = (From c In dc.tblECMCustConfs
                 Where c.Location.Equals(f.UltraCombo2.Value) AndAlso c.Custid.Equals(f.UltraTextEditor1.Value)).SingleOrDefault
        rec.Location = f.UltraCombo2.Text
        rec.Custid = f.UltraTextEditor1.Text
        rec.confdate = f.UltraDateTimeEditor1.Value
        If f.CheckBox1.Checked = True Then
            rec.RFlag = True
        Else
            rec.RFlag = False
        End If
        rec.RFlag = f.CheckBox1.Checked
        rec.Adddate = Today
        rec.User = System.Environment.UserName
        Try
            dc.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("Update failed contact IT for assistance " & vbCrLf & "Message Code " & ex.Message, "Update Failure (tblRCMmast)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
        dc.SubmitChanges()
    End Sub
    Private Sub UltraGrid1_BeforeRowsDeleted(sender As Object, e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles UltraGrid1.BeforeRowsDeleted
        e.DisplayPromptMsg = False
        If MessageBox.Show("Delete selected row? ", "Delete Row", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            If Me.UltraGrid1.Selected.Rows.Count > 0 Then
                delete_record(Me.UltraGrid1.Selected.Rows(0).Cells(0).Value, Me.UltraGrid1.Selected.Rows(0).Cells(1).Value)
            End If
        End If
    End Sub
    
End Class