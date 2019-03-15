
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Shared
Public Class FrmMobCust
    Dim sql As String
    Private Sub FrmMobCust_Load(sender As Object, e As EventArgs) Handles Me.Load
        RadioButton1.Checked = True
        Bind_Grid1()
        'Set_Display2()
        UltraGrid1.ActiveRow = Nothing
    End Sub

    Private Sub Bind_Grid1()
        Me.UltraGrid1.SetDataBinding(db.Get_view_Mobile_Customer_xref(sql), Nothing)
        Me.UltraGrid1.DataBind()
        Set_Display1()
    End Sub
    Private Sub Bind_Grid2()
        Me.UltraGrid2.SetDataBinding(db.get_View_Mobile_Email_Customer(sql), Nothing)
        Me.UltraGrid2.DataBind()
        Set_Display2()
    End Sub
    Private Sub Set_Display1()
        UltraGrid1.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Mobile No."
        UltraGrid1.DisplayLayout.Bands(0).Columns(1).Header.Caption = "First Name"
        UltraGrid1.DisplayLayout.Bands(0).Columns(2).Header.Caption = "Last Name"
        UltraGrid1.DisplayLayout.Bands(0).Columns(3).Header.Caption = "Mobile Status"
        UltraGrid1.DisplayLayout.Bands(0).Columns(4).Header.Caption = "Customer ID"
        UltraGrid1.DisplayLayout.Bands(0).Columns(5).Header.Caption = "Xref Stat"
        UltraGrid1.DisplayLayout.GroupByBox.Hidden = True
        UltraGrid1.DisplayLayout.Bands(0).Override.CellClickAction = CellClickAction.RowSelect
        'UltraGrid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True
        'UltraGrid1.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.XPThemed
        UltraGrid1.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
        UltraGrid1.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        UltraGrid1.DisplayLayout.Override.SelectTypeRow = SelectType.Default
        'UltraGrid1.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False
        UltraGrid1.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False
        UltraGrid1.Height = 250
    End Sub
    Private Sub Set_Display2()
        UltraGrid2.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Email"
        UltraGrid2.DisplayLayout.Bands(0).Columns(1).Header.Caption = "Email Status"
        UltraGrid2.DisplayLayout.Bands(0).Columns(2).Header.Caption = "Mobile Number"
        UltraGrid2.DisplayLayout.Bands(0).Columns(3).Header.Caption = "Mobile Status"
        'UltraGrid2.DisplayLayout.Bands(0).Columns(4).Header.Caption = "Customer ID"
        'UltraGrid2.DisplayLayout.Bands(0).Columns(5).Header.Caption = "Xref Stat"
        UltraGrid2.DisplayLayout.GroupByBox.Hidden = True
        UltraGrid2.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True
        UltraGrid2.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.XPThemed
        UltraGrid2.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
        UltraGrid2.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        UltraGrid2.DisplayLayout.Override.SelectTypeRow = SelectType.Default
        UltraGrid1.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False
        UltraGrid2.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False
        UltraGrid2.Height = 250
    End Sub

    Private Sub Set_cust_sql1()
        sql = "Select t1.mobile_number,first_name,last_name,mobile_status,customer_id,xref_status from View_Mobile_Users_Xref As t1 " &
        "where "

        If String.IsNullOrEmpty(Me.UltraCombo1.Text) Then
            sql = sql & " t1.mobile_number >='" & Me.UltraCombo1.Text & "'"
        Else
            sql = sql & " t1.mobile_number like'%" & Me.UltraCombo1.Text & "%'"
        End If
        If String.IsNullOrEmpty(Me.UltraCombo2.Text) Then
            sql = sql & " and t1.first_name >='" & Me.UltraCombo2.Text & "'"
        Else
            sql = sql & " and t1.first_name like '%" & Me.UltraCombo2.Text & "%'"
        End If
        If String.IsNullOrEmpty(Me.UltraCombo3.Text) Then
            sql = sql & " and t1.last_name >='" & Me.UltraCombo3.Text & "'"
        Else
            sql = sql & " and t1.last_name like '%" & Me.UltraCombo3.Text & "%'"
        End If

        If String.IsNullOrEmpty(Me.UltraCombo4.Text) Then
            'sql = sql & " and t1.customer_id >='" & Me.UltraCombo4.Text & "'"
            sql = sql
        Else
            sql = sql & " and t1.customer_id like '%" & Me.UltraCombo4.Text & "%'"
        End If
        sql = sql & " order by t1.mobile_number"
    End Sub
    Private Sub Set_cust_sql2()
        sql = "Select distinct email_address,email_status,mobile_number,mobile_status from View_Mobile_Email_Customer As t1 " &
        "where "

        If String.IsNullOrEmpty(Me.UltraCombo1.Text) Then
            sql = sql & " t1.email_address >='" & Me.UltraCombo1.Text & "'"
        Else
            sql = sql & " t1.email_address like '%" & Me.UltraCombo1.Text & "%'"
        End If

        If String.IsNullOrEmpty(Me.UltraCombo2.Text) Then
            sql = sql & " and t1.mobile_number >='" & Me.UltraCombo2.Text & "'"
        Else
            sql = sql & " and t1.mobile_number like '%" & Me.UltraCombo2.Text & "%'"

        End If
        sql = sql & " order by email_address"


    End Sub
    Private Sub Set_panel1()
        UltraLabel1.Text = "Mobile#"
        UltraLabel2.Text = "First Name"
        UltraLabel3.Text = "Last Name"
        UltraLabel4.Text = "Customer ID"
        UltraLabel5.Visible = False
    End Sub
    Private Sub Set_panel2()
        UltraLabel1.Text = "Email"
        UltraLabel2.Text = "Mobile #"
        UltraLabel3.Visible = False
        UltraLabel4.Visible = False
        UltraLabel5.Visible = False
    End Sub
    Private Sub Init_filters1()
        UltraCombo1.DataSource = Nothing
        UltraCombo1.ValueMember = Nothing
        UltraCombo1.DisplayMember = Nothing
        Me.UltraCombo1.DataSource = db.Get_tblMobile_Customer_Users_mobile_number
        Me.UltraCombo1.ValueMember = "mobile_number"
        Me.UltraCombo1.DisplayMember = "mobile_number"
        UltraCombo2.DataSource = Nothing
        UltraCombo2.ValueMember = Nothing
        UltraCombo2.DisplayMember = Nothing
        Me.UltraCombo2.DataSource = db.Get_tblMobile_Customer_Users_first_name
        Me.UltraCombo2.ValueMember = "first_name"
        Me.UltraCombo2.DisplayMember = "first_name"
        UltraCombo3.DataSource = Nothing
        UltraCombo3.ValueMember = Nothing
        UltraCombo3.DisplayMember = Nothing
        Me.UltraCombo3.DataSource = db.Get_tblMobile_Customer_Users_last_name
        Me.UltraCombo3.ValueMember = "last_name"
        Me.UltraCombo3.DisplayMember = "last_name"
        Me.UltraCombo4.DataSource = db.Get_tblMobile_Customer_ID
        Me.UltraCombo4.ValueMember = "Customer_ID"
        Me.UltraCombo4.DisplayMember = "Customer_ID"
        UltraCombo3.Visible = True
        UltraLabel3.Visible = True
        UltraCombo4.Visible = True
        UltraLabel4.Visible = True
        UltraCombo5.Visible = False
    End Sub
    Private Sub Init_filters2()
        UltraCombo1.DataSource = Nothing
        UltraCombo1.ValueMember = Nothing
        UltraCombo1.DisplayMember = Nothing
        Me.UltraCombo1.DataSource = db.Get_View_Customer_Emails_Email
        Me.UltraCombo1.ValueMember = "email_address"
        Me.UltraCombo1.DisplayMember = "email_address"
        UltraCombo2.DataSource = Nothing
        UltraCombo2.ValueMember = Nothing
        UltraCombo2.DisplayMember = Nothing
        Me.UltraCombo2.DataSource = db.Get_tblMobile_Customer_Emails_Mobile_Number()
        Me.UltraCombo2.ValueMember = "mobile_number"
        Me.UltraCombo2.DisplayMember = "mobile_number"
        UltraCombo3.Visible = False
        UltraCombo4.Visible = False

    End Sub

    Private Sub UltraButtonExit_Click(sender As Object, e As EventArgs) Handles UltraButtonExit.Click
        Me.Dispose()
    End Sub

    Private Sub UltraButtonFilter_Click(sender As Object, e As EventArgs) Handles UltraButtonFilter.Click
        If RadioButton1.Checked = True Then
            set_cust_sql1()
            Bind_Grid1()
        Else
            set_cust_sql2()
            Bind_Grid2()
        End If

    End Sub

    Private Sub UltraButtonReset_Click(sender As Object, e As EventArgs) Handles UltraButtonReset.Click
        reset()
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then

            Me.UltraGrid1.Visible = False
            Me.UltraGrid2.Visible = True
            Me.UltraGrid2.DisplayLayout.GroupByBox.Hidden = True
            Me.UltraGroupBox2.Visible = False
            Me.UltraGroupBox3.Visible = True
            Me.UltraGroupBox3.Height = 300
            UltraGroupBox3.Location = UltraGroupBox2.Location
            UltraGrid2.Location = UltraGrid1.Location
            UltraGrid2.Height = UltraGrid1.Height
            Set_panel2()
            Init_filters2()
            Reset()
            Set_cust_sql2()
            Bind_Grid2()
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            UltraGrid1.DisplayLayout.GroupByBox.Hidden = True
            UltraGrid2.Visible = False
            UltraGrid1.Visible = True
            UltraGroupBox2.Visible = True
            UltraGroupBox3.Visible = False
            UltraGroupBox2.Height = 300
            set_panel1()
            init_filters1()
            set_cust_sql1()
            Bind_Grid1()
            reset()
        End If
    End Sub
    Private Sub Reset()

        Me.UltraCombo1.Value = Nothing
        Me.UltraCombo2.Value = Nothing
        Me.UltraCombo3.Value = Nothing
        Me.UltraCombo4.Value = Nothing
        Me.UltraCombo5.Value = Nothing
        If RadioButton1.Checked = True Then
            Set_cust_sql1()
            Bind_Grid1()
        End If
        If RadioButton2.Checked = True Then
            Set_cust_sql2()
            Bind_Grid2()
        End If
    End Sub

    Private Sub UltraButtonSelect_Click(sender As Object, e As EventArgs) Handles UltraButtonSelect.Click
        Dim mode As String
        If RadioButton1.Checked = True Then
            If Check_rows(UltraGrid1) = 1 Then
                mode = "change"
                Dim r As UltraGridRow
                r = Me.UltraGrid1.Selected.Rows(0)
                Dim f As New FrmMobCustomerUserAC(mode, r.Cells(0).Value)
                f.ShowDialog()
                If f.DialogResult = Windows.Forms.DialogResult.OK Then
                    'update db
                    'update_record(f)
                End If
                refresh_grid()
            End If
        End If
        If RadioButton2.Checked = True Then
            If Check_rows(UltraGrid2) = 1 Then
                mode = "change"
                Dim r As UltraGridRow
                r = Me.UltraGrid2.Selected.Rows(0)
                Dim f As New FrmMobCustomerUserAC(mode, r.Cells(1).Value)
                f.ShowDialog()
                If f.DialogResult = Windows.Forms.DialogResult.OK Then
                    'update db
                    'update_record(f)
                End If
                'setup_grid()
            End If
        End If
    End Sub
    Private Function Check_rows(grid As UltraGrid) As Integer
        If grid.Selected.Rows.Count > 1 Then
            MessageBox.Show("Multiple Row selection not allowed", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        Return grid.Selected.Rows.Count
    End Function

    Private Sub UltraButtonAdd_Click_1(sender As Object, e As EventArgs) Handles UltraButtonAdd.Click
        If RadioButton1.Checked = True Then
            Dim f As New FrmMobCustomerUserAC("add", " ")
            f.ShowDialog()
            If f.DialogResult = Windows.Forms.DialogResult.OK Then
                'add record
                ' insert_record(f)
            End If
        End If
        If RadioButton2.Checked = True Then
            Dim f As New FrmMobCustomerUserAC("add", " ")
            f.ShowDialog()
            If f.DialogResult = Windows.Forms.DialogResult.OK Then
                'add record
                ' insert_record(f)
            End If
        End If
        refresh_grid()
    End Sub
    Private Sub refresh_grid()
        If RadioButton1.Checked = True Then
            Set_cust_sql1()
            Bind_Grid1()
        Else
            Set_cust_sql2()
            Bind_Grid2()
        End If
    End Sub

    Private Sub UltraGrid1_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles UltraGrid1.InitializeLayout
        e.Layout.Bands(0).Override.HeaderAppearance.BackColor = Color.LightBlue
    End Sub

    Private Sub UltraGrid2_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles UltraGrid2.InitializeLayout
        e.Layout.Bands(0).Override.HeaderAppearance.BackColor = Color.LightBlue
    End Sub
    'Private Sub Highlight_a_Selected_Row_with_Background_Color_Load(ByVal sender As System.Object,
    '  ByVal e As System.EventArgs) Handles MyBase.Load
    '    Me.UltraGrid1.DisplayLayout.Override.ActiveRowAppearance.BackColor = Color.LightBlue
    'End Sub
End Class