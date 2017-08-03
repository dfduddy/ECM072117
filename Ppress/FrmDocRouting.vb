Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Shared

Public Class FrmDocRouting
    Dim sql As String
    Dim fflag As Boolean
    Dim pflag As Boolean
    Dim user As String = System.Environment.UserName

    Private Sub FrmDocRouting_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Delete Then
            If MessageBox.Show("Delete selected rows? ", "Delete Rows", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                delete_rows()
            End If
        End If
    End Sub

    Private Sub FrmDocRouting_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        fflag = False
        set_sql()
        Me.UltraGrid1.DisplayLayout.GroupByBox.Hidden = True
        set_filter()
        set_datasource()
        setup_grid()
        set_display()
    End Sub
    Private Sub set_datasource()
    End Sub
    Private Sub setup_grid()
        Me.UltraGrid1.SetDataBinding(db.get_tblECMmast(sql), Nothing)
        Me.UltraGrid1.DataBind()
    End Sub
    Private Sub reset_grid()
        Me.UltraCombo1.Value = Nothing
        Me.UltraCombo2.Value = Nothing
        Me.UltraCombo3.Value = Nothing
        Me.UltraCombo4.Value = Nothing
        Me.UltraCombo5.Value = Nothing
        Me.UltraCombo6.Value = Nothing
        fflag = False
        set_sql()
        setup_grid()
        set_filter()
    End Sub
   
    Private Sub delete_rows()
        If Me.UltraGrid1.Selected.Rows.Count > 0 Then
            Dim r As UltraGridRow
            For Each r In Me.UltraGrid1.Selected.Rows
                delete_record(r.Cells(0).Value)
            Next
        End If
    End Sub

    Private Sub UltraGrid1_BeforeRowsDeleted(sender As Object, e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles UltraGrid1.BeforeRowsDeleted
        e.DisplayPromptMsg = False
        'Dim dflag As Boolean = False
        'If Me.UltraGrid1.Selected.Rows.Count > 0 Then
        '    If MessageBox.Show("Delete selected rows? ", "Delete Row", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
        '        'Me.UltraGrid1.DeleteSelectedRows()
        '        'delete_record(Me.UltraGrid1.Selected.Rows(0).Cells(0).Value)
        '        dflag = True
        '    Else
        '        e.Cancel = True
        '    End If
        '    If dflag = True Then Me.UltraGrid1.DeleteSelectedRows()
        '    e.Cancel = True
        'End If
    End Sub

    Private Sub UltraGrid1_DoubleClickRow(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles UltraGrid1.DoubleClickRow
        If Me.UltraGrid1.Selected.Rows.Count > 0 Then
            Dim r As UltraGridRow
            r = Me.UltraGrid1.Selected.Rows(0)
            Dim f As New FrmDocRoutingAC(r.Cells(0).Value)
            f.ShowDialog()
            If f.DialogResult = Windows.Forms.DialogResult.OK Then
                'update db
                update_record(f)
            End If
            setup_grid()
        End If
    End Sub
    Private Sub UltraGrid1_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles UltraGrid1.InitializeLayout
        e.Layout.Bands(0).Columns(0).Hidden = True
        'e.Layout.Bands(0).Columns(1).Hidden = True
        e.Layout.Bands(0).Columns(2).Hidden = True
        ' ''e.Layout.Bands(0).Columns(3).Hidden = True
        ' ''e.Layout.Bands(0).Columns(4).Hidden = True
        'e.Layout.Bands(0).Columns(5).Hidden = True
        e.Layout.Bands(0).Columns(6).Hidden = True
        e.Layout.Bands(0).Columns(7).Hidden = True
        'e.Layout.Bands(0).Columns(8).Hidden = True
        'e.Layout.Bands(0).Columns(9).Hidden = True
        'e.Layout.Bands(0).Columns(10).Hidden = True

    End Sub
    Private Sub set_display()
        Me.UltraGrid1.DisplayLayout.Bands(0).Columns(3).Header.Caption = "Customer ID"
        Me.UltraGrid1.DisplayLayout.Bands(0).Columns(4).Header.Caption = "User ID"
        Me.UltraGrid1.DisplayLayout.Bands(0).Columns(5).Header.Caption = "Recipient Email"
        Me.UltraGrid1.DisplayLayout.Bands(0).Columns(8).Header.Caption = "Merchandiser Name"
        'Me.UltraGrid1.DisplayLayout.Bands(0).Columns(7).Header.Caption = "Pct/Batch"
        'Me.UltraGrid1.DisplayLayout.Bands(0).Columns(8).Header.Caption = "Cost/Batch"
        'Me.UltraGrid1.DisplayLayout.Bands(0).Columns(1).Width = 250
        Me.UltraGrid1.DisplayLayout.Bands(0).Columns(5).Width = 250
        'Me.UltraGrid1.DisplayLayout.Override.AllowAddNew = AllowAddNew.Yes
        'Me.UltraGrid1.DisplayLayout.AddNewBox.Hidden = False
        'Me.UltraGrid1.DisplayLayout.Bands(0).Columns(0).CellActivation = Activation.Disabled
        Me.UltraGrid1.DisplayLayout.GroupByBox.Hidden = True
        Me.UltraGrid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True
        Me.UltraGrid1.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.XPThemed
        Me.UltraGrid1.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
        Me.UltraGrid1.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        Me.UltraGrid1.DisplayLayout.Override.SelectTypeRow = SelectType.Default
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
        Dim f As New FrmDocRoutingAC(0)
        f.ShowDialog()
        If f.DialogResult = Windows.Forms.DialogResult.OK Then
            'add record
            insert_record(f)
        End If
        setup_grid()
    End Sub

    Private Sub UltraGrid1_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles UltraGrid1.MouseDoubleClick
        
    End Sub
    Private Sub UltraBtnSelect_Click(sender As System.Object, e As System.EventArgs) Handles UltraBtnSelect.Click
        If check_rows = 1 Then
            Dim r As UltraGridRow
            r = Me.UltraGrid1.Selected.Rows(0)
            Dim f As New FrmDocRoutingAC(r.Cells(0).Value)
            f.ShowDialog()
            If f.DialogResult = Windows.Forms.DialogResult.OK Then
                'update db
                update_record(f)
            End If
            setup_grid()
        End If
    End Sub
    Private Sub insert_record(f As FrmDocRoutingAC)
        Dim c As UltraGridRow
        Dim MA As String
        Dim TRADER As String
        Select Case f.UltraCombo1.Value
            Case "FS", "CC", "CO", "CP"
                If f.UltraGrid1.Selected.Rows.Count > 0 Then
                    For Each c In f.UltraGrid1.Selected.Rows 'LOOP NEW MA'S & Traders
                        MA = c.Cells(0).Value.ToString
                        TRADER = Nothing
                        Insert_Selected_Records(f, MA, TRADER)
                    Next
                Else
                    MA = " "
                    TRADER = Nothing
                    Insert_Selected_Records(f, MA, TRADER)
                End If
            Case Else
                MA = " "  'Loop traders only TYPE=CO
                TRADER = Nothing
                Insert_Selected_Records(f, MA, TRADER)
        End Select
    End Sub
    Private Sub delete_record(r As Decimal)
        Dim dc As New DataClasses1DataContext
        Dim e As tblECMmast
        e = (From c In dc.tblECMmasts
                 Where c.Recid = r Select c).SingleOrDefault
        dc.tblECMmasts.DeleteOnSubmit(e)
        Try
            dc.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("Delete failed contact IT for assistance " & vbCrLf & "Message Code " & ex.Message, "Delete Failure (tblRCMmast)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    Private Sub update_record(f As FrmDocRoutingAC)
        Dim r As UltraGridRow
        Dim rr As Decimal
        r = Me.UltraGrid1.Selected.Rows(0)
        rr = r.Cells(0).Value
        Dim dc As New DataClasses1DataContext
        Dim rec = (From c In dc.tblECMmasts
                 Where (rr = c.Recid)).SingleOrDefault
        rec.Type = f.UltraCombo1.Text
        rec.Location = f.UltraCombo2.Text
        rec.Customer = f.UltraTextEditor1.Text
        If f.UltraGrid1.Selected.Rows.Count > 0 Then
            rec.MA = f.UltraGrid1.Selected.Rows(0).Cells(0).Value
        Else
            rec.MA = f.UltraTextEditor3.Text
        End If
        'rec.MA = f.UltraCombo4.Text
        rec.Recipent = f.UltraTextEditor2.Text
        rec.Chgdate = Today
        'rec.User = System.Environment.UserName
        If f.UltraGrid2.Selected.Rows.Count > 0 Then
            rec.Trader = f.UltraGrid2.Selected.Rows(0).Cells(0).Value
        Else
            rec.Trader = f.UltraTextEditor4.Text
        End If
        'rec.Trader = f.UltraGrid2.Selected.Rows(0).Cells(0).Value
        'rec.Trader = f.UltraCombo6.Text
        rec.Pflag = f.UltraComboEditor1.Text
        Try
            dc.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("Update failed contact IT for assistance " & vbCrLf & "Message Code " & ex.Message, "Update Failure (tblRCMmast)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
        dc.SubmitChanges()
    End Sub

    Private Sub UltraBtnFilter_Click(sender As System.Object, e As System.EventArgs) Handles UltraBtnFilter.Click
        set_sql()
        setup_grid()
        fflag = True
    End Sub
    Public Sub set_filter()
        Me.UltraCombo1.DataSource = db.get_tblECMmast_type
        Me.UltraCombo1.ValueMember = "Type"
        Me.UltraCombo1.DisplayMember = "Type"
        Me.UltraCombo2.DataSource = db.get_tblECMmast_location
        Me.UltraCombo2.ValueMember = "Location"
        Me.UltraCombo2.DisplayMember = "Location"
        ' Me.UltraCombo2.DisplayLayout.Bands(0).Columns(0).SortIndicator = SortIndicator.Ascending
        Me.UltraCombo3.DataSource = db.get_tblECMmast_customer
        Me.UltraCombo3.ValueMember = "Customer"
        Me.UltraCombo3.DisplayMember = "Customer"
        Me.UltraCombo4.DataSource = db.get_tblECMmast_MA
        Me.UltraCombo4.ValueMember = "MA"
        Me.UltraCombo4.DisplayMember = "MA"
        Me.UltraCombo5.DataSource = db.get_tblECMmast_Recipent
        Me.UltraCombo5.ValueMember = "Recipent"
        Me.UltraCombo5.DisplayMember = "Recipent"
        Me.UltraCombo5.Rows.Band.Columns(0).Width = "200"
        Me.UltraCombo6.DataSource = db.get_tblECMmast_Trader
        Me.UltraCombo6.ValueMember = "Trader"
        Me.UltraCombo6.DisplayMember = "Trader"
        Me.UltraCombo6.Rows.Band.Columns(0).Width = "200"
        Me.UltraCombo6.Rows.Band.Columns(0).Header.Caption = "Merchandiser"
        'Me.UltraCombo6.DataSource = db.get_merchandiser
        'Me.UltraCombo6.ValueMember = "VCDDES"
        'Me.UltraCombo6.DisplayMember = "VCDDES"
        'Me.UltraCombo6.Rows.Band.Columns(0).Width = "200"
    End Sub

    Private Sub UltraCombo6_InitializeLayout(sender As System.Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles UltraCombo6.InitializeLayout

    End Sub

    Private Sub UltraBtnReset_Click(sender As System.Object, e As System.EventArgs) Handles UltraBtnReset.Click
        Me.UltraCombo1.Value = Nothing
        Me.UltraCombo2.Value = Nothing
        Me.UltraCombo3.Value = Nothing
        Me.UltraCombo4.Value = Nothing
        Me.UltraCombo5.Value = Nothing
        Me.UltraCombo6.Value = Nothing
        fflag = False
        set_sql()
        setup_grid()
    End Sub
    Public Sub set_sql()
        sql = "Select Recid,Type,Location,Customer,MA,Recipent,Chgdate,User,Trader,Pflag from tblECMmast where "
        If String.IsNullOrEmpty(Me.UltraCombo1.Text) Then
            sql = sql & " type >='" & Me.UltraCombo1.Text & "'"
        Else
            sql = sql & " type='" & Me.UltraCombo1.Text & "'"
        End If
        If Not String.IsNullOrEmpty(Me.UltraCombo2.Text) Then
            sql = sql & " and location ='" & Me.UltraCombo2.Text & "'"
        End If
        If Not String.IsNullOrEmpty(Me.UltraCombo3.Text) Then
            sql = sql & " and customer ='" & Me.UltraCombo3.Text & "'"
        End If
        If Not String.IsNullOrEmpty(Me.UltraCombo4.Text) Then
            sql = sql & " and MA='" & Me.UltraCombo4.Text & "'"
        End If
        If Not String.IsNullOrEmpty(Me.UltraCombo5.Text) Then
            sql = sql & " and Recipent='" & Me.UltraCombo5.Text & "'"
        End If
        If Not String.IsNullOrEmpty(Me.UltraCombo6.Text) Then
            sql = sql & " and Trader='" & Me.UltraCombo6.Text & "'"
        End If
        sql = sql & " order by Type,Location,Customer,MA"
    End Sub
    Private Sub Insert_Selected_Records(f As FrmDocRoutingAC, MA As String, Trader As String)
        Dim dc As New DataClasses1DataContext
        Dim t As UltraGridRow
        Select Case f.UltraCombo1.Value
            Case "CO", "CP"  'contract
                For Each t In f.UltraGrid2.Selected.Rows 'LOOP NEW TRADERS
                    Trader = t.Cells(0).Value
                    Dim rec As New tblECMmast With
                    {.Type = f.UltraCombo1.Value, .Location = f.UltraCombo2.Value, .Customer = f.UltraTextEditor1.Text, _
                     .MA = MA, .Recipent = f.UltraTextEditor2.Text, .Chgdate = Today, .User = System.Environment.UserName, _
                     .Trader = Trader, .Pflag = f.UltraComboEditor1.Text}
                    dc.tblECMmasts.InsertOnSubmit(rec)
                    Try
                        dc.SubmitChanges()
                    Catch ex As Exception
                        MessageBox.Show("Insert failed contact IT for assistance " & vbCrLf & "Message Code " & ex.Message, "Insert Failure (tblRCMmast)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End Try
                Next
            Case Else  'others
                Dim rec As New tblECMmast With
                    {.Type = f.UltraCombo1.Value, .Location = f.UltraCombo2.Value, .Customer = f.UltraTextEditor1.Text, _
                     .MA = MA, .Recipent = f.UltraTextEditor2.Text, .Chgdate = Today, .User = System.Environment.UserName, _
                     .Trader = Trader, .Pflag = f.UltraComboEditor1.Text}
                dc.tblECMmasts.InsertOnSubmit(rec)
                Try
                    dc.SubmitChanges()
                Catch ex As Exception
                    MessageBox.Show("Insert failed contact IT for assistance " & vbCrLf & "Message Code " & ex.Message, "Insert Failure (tblRCMmast)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End Try
        End Select
    End Sub

    Private Sub UltraButton1_Click(sender As System.Object, e As System.EventArgs) Handles UltraButton1.Click
        If Me.UltraGrid1.Selected.Rows.Count > 0 Then
            Dim rc As Integer = Me.UltraGrid1.Selected.Rows.Count
            Dim rr As Integer = Me.UltraGrid1.Selected.Rows(0).Index 'first selected row
            post_requested_changes()
            If pflag = False Then
                Dim f As New FrmDocRoutingCM()
                f.ShowDialog()
                If f.DialogResult = Windows.Forms.DialogResult.OK Then
                    'update db
                    'update_record(f)
                End If
                reset_grid()
                'For c = 1 To rc
                '    Me.UltraGrid1.Rows(rr).Selected = True
                '    Me.UltraGrid1.Rows(rr).Activate()
                '    rr += 1
                'Next
            End If
        End If

    End Sub
    Public Sub post_requested_changes()
        Dim dc As New DataClasses1DataContext
        'dc.ExecuteCommand("truncate table ECMmast_change")
        dc.sp_create_mast_change(user)
        Dim ptype As String = Me.UltraGrid1.Selected.Rows(0).Cells("type").Value
        pflag = False 'error flag for multiple document types
        Dim r As UltraGridRow
        For Each r In UltraGrid1.Selected.Rows
            If ptype <> r.Cells("Type").Value Then
                MessageBox.Show("Only one document type may be changed per request, please reselect.", "Multiple Document Types", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                pflag = True
                Exit Sub
            End If
            Try
                db.insert_ecm_change(r, user)
            Catch ex As Exception
                MessageBox.Show("Insert failed contact IT for assistance " & vbCrLf & "Message Code " & ex.Message, "Insert Failure (tblECMmprcntl2)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try

            'Dim rec As New ECMmast_change With {.Type = r.Cells(1).Value, _
            '                                  .Location = r.Cells(2).Value, _
            '                                   .Customer = r.Cells(3).Value, .MA = r.Cells(4).Value, .Recipent = r.Cells(5).Value, .User = System.Environment.UserName, .Chgdate = Today, .Trader = r.Cells(8).Value.ToString, .Pflag = r.Cells(9).Value.ToString, .Orecid = r.Cells(0).Value}
            'dc.ECMmast_changes.InsertOnSubmit(rec)
            'Try
            '    dc.SubmitChanges()
            'Catch ex As Exception
            '    MessageBox.Show("Insert failed contact IT for assistance " & vbCrLf & "Message Code " & ex.Message, "Insert Failure (tblECMmprcntl2)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'End Try
        Next
    End Sub
    Private Function check_rows() As Integer
        If Me.UltraGrid1.Selected.Rows.Count > 1 Then
            MessageBox.Show("Multiple Row selection not allowed", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        Return Me.UltraGrid1.Selected.Rows.Count
    End Function
End Class

