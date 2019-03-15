Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Shared
Imports System.Text.RegularExpressions
Imports System.Net.Mail
Imports Infragistics.Win.UltraWinEditors
Imports Infragistics.Win.UltraWinStatusBar
Imports System.Threading
Imports System.ComponentModel

Public Class FrmMobCustomerXrefAC
    Private a_rec As Integer
    Dim a_mn As String
    Dim a_xr As String
    Private a_mode As String
    Dim eflag As Boolean
    Dim user As String = System.Environment.UserName
    Dim curdate As Date = DateTime.Now
    Dim appid As String = "FrmMobCustomerXrefAC"






    Public Sub New(mode As String, mn As String, xr As String)
        ' This call is required by the designer.
        InitializeComponent()
        a_mn = mn
        a_xr = xr
        a_mode = mode
        'setup_panel()
        ' Add any initialization after the InitializeComponent() call.
        'setup_grid()
        'set_display()
        Select Case a_mode
            Case Is = "add"  'add
                Me.UltraLabel5.Text = "Add Mode"
                UltraTextEditor2.ReadOnly = True
                Init_panel()

            Case Is <> "add"  'update
                Me.UltraLabel5.Text = "Change Mode"
                Update_Panel()
                UltraTextEditor2.ReadOnly = True
                'Me.UltraGrid1.DisplayLayout.Override.SelectTypeRow = SelectType.Single
                'Me.UltraGrid2.DisplayLayout.Override.SelectTypeRow = SelectType.Single
                'Me.UltraCombo1.Enabled = False
        End Select
        ' Add any initialization after the InitializeComponent() call.
        UltraGrid1.Visible = False

    End Sub

    Private Sub Init_panel()
        UltraTextEditor2.Text = a_mn
        UltraCombo1.Value = "A"
        UltraTextEditor1.Text = Nothing

    End Sub

    Private Sub Update_Panel()
        Dim R As tblMobile_Customer_Xref = db.Get_tblMobile_Customer_Xref_Mobile_Number(a_mn, a_xr)
        Dim n As tblECMcustomer = db.get_tblECMCustomer_Name(R.customer_id)
        UltraTextEditor2.Text = R.mobile_number
        UltraCombo1.Value = R.xref_status
        UltraLabel4.Text = n.Name
        UltraTextEditor1.Text = R.customer_id

    End Sub


    Private Sub UltraButtonCancel_Click(sender As Object, e As EventArgs) Handles UltraButtonCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
    Private Sub UltraButtonOK_Click(sender As Object, e As EventArgs) Handles UltraButtonOK.Click
        'Edit Data
        Edit_Data()
        If eflag = 0 Then
            'Output Data
            Select Case a_mode
                Case Is = "add"
                    Insert_Customer_Xfer()
                Case Is = "change"
                    If UltraTextEditor1.Text <> a_xr Then  'If FK value changes delete and re-add for linq to sql
                        Delete_Customer_Xfer()
                        Insert_Customer_Xfer()
                    Else
                        Update_Customer_Xfer()  'no changes to FK
                    End If
            End Select
            FrmMobCustomerUserAC.uflag = True
        End If
    End Sub
    Private Sub Insert_Customer_Xfer()
        Dim dc As New DataClasses1DataContext
        Try
            Dim rec As New tblMobile_Customer_Xref With
                {.mobile_number = UltraTextEditor2.Text, .customer_id = UltraTextEditor1.Text.ToUpper,
                .xref_status = UltraCombo1.Value, .created_user = user,
                .created_date = curdate, .change_user = user, .change_date = curdate}
            dc.tblMobile_Customer_Xrefs.InsertOnSubmit(rec)
            dc.SubmitChanges()
            UltraStatusBar1.Panels("Text").Text = "Customer ID " & UltraTextEditor1.Text.ToUpper & " added"
            UltraStatusBar1.Show()
            'DialogResult = DialogResult.OK  'hold dialog open
            Init_panel()
        Catch ex As Exception
            MessageBox.Show("Insert failed contact IT for assistance " & vbCrLf & "Message Code " & ex.Message, "Insert Failure (tblMobile_Customer_Xrefs)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    Private Sub Update_Customer_Xfer()
        Dim dc As New DataClasses1DataContext
        Dim rec = (From c In dc.tblMobile_Customer_Xrefs Where c.mobile_number = a_mn And c.customer_id = a_xr).ToList()(0)
        With rec
            .mobile_number = a_mn
            .customer_id = UltraTextEditor1.Text.ToUpper
            .xref_status = UltraCombo1.Value
            .change_user = user
            .change_date = curdate
        End With
        Try
            dc.SubmitChanges()
            DialogResult = DialogResult.OK
        Catch ex As Exception
            MessageBox.Show("Update failed contact IT for assistance " & vbCrLf & "Message Code " & ex.Message, "Update Failure (tblMobile_Customer_Xrefs)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    Private Sub Delete_Customer_Xfer()
        Dim dc As New DataClasses1DataContext
        Dim rec = (From c In dc.tblMobile_Customer_Xrefs Where c.mobile_number = a_mn And c.customer_id = a_xr).FirstOrDefault
        dc.tblMobile_Customer_Xrefs.DeleteOnSubmit(rec)
        Try
            dc.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("Delete failed contact IT for assistance " & vbCrLf & "Message Code " & ex.Message, "Delete Failure (tblMobile_Customer_Xrefs)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    Private Sub Edit_Data()
        eflag = 0
        If String.IsNullOrEmpty(UltraTextEditor2.Text) Then
            MessageBox.Show("Mobile Number is required, please enter", "Invalid or missing input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            eflag = 1
            UltraTextEditor2.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(UltraTextEditor1.Text) Then
            MessageBox.Show("Customer ID is required, please enter", "Invalid or missing input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            eflag = 1
            UltraTextEditor1.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(UltraCombo1.Value) Then
            MessageBox.Show("Statis Code is required, please enter", "Invalid or missing input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            eflag = 1
            UltraCombo1.Focus()
        End If
        'edit customer id
        If db.check_customer(UltraTextEditor1.Text) = 0 Then
            MessageBox.Show("Customer ID invalid, please retry or search for value", "Invalid or missing input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            eflag = 1
            UltraTextEditor1.Focus()
        End If
    End Sub
    Public Function check_email(ea As String) As Boolean
        'dfd01 changed edit for email format
        Try
            Dim tea As String = New MailAddress(ea).Address
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Private Sub FrmMobCustomerXref_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'PpressDataSet1.tblECMcustomer' table. You can move, or remove it, as needed.
        'Me.TblECMcustomerTableAdapter.Fill(Me.PpressDataSet1.tblECMcustomer)
        'TODO: This line of code loads data into the 'PpressDataSet.tblMobile_Statis_Codes' table. You can move, or remove it, as needed.
        Me.TblMobile_Statis_CodesTableAdapter.Fill(Me.PpressDataSet.tblMobile_Statis_Codes)
        UltraStatusBar1.Panels.Add("Text", PanelStyle.Text)
        UltraStatusBar1.Panels("Text").Width = 500
        UltraStatusBar1.Text = " "
        UltraStatusBar1.Show()
        Setup_grid1
        UltraGrid1.SetDataBinding(db.get_tblECMCustomer, Nothing)
        UltraGrid1.DataBind()
    End Sub



    Private Sub UltraButton1_Click(sender As Object, e As EventArgs)
        'Me.Cursor = Cursors.WaitCursor
        'UltraCombo2.DisplayMember = "custid"
        'UltraCombo2.ValueMember = "custid"
        'UltraCombo2.SetDataBinding(db.get_tblECMCustomer, Nothing)
        'UltraCombo2.DataBind()

        'Me.Cursor = Cursors.Default
    End Sub

    Private Sub UltraGrid1_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles UltraGrid1.InitializeLayout
        'e.Layout.Bands(0).Columns(0).Hidden = True
        e.Layout.Bands(0).Override.HeaderAppearance.BackColor = Color.LightBlue

    End Sub

    Private Sub UltraTextEditor1_EditorButtonClick(sender As Object, e As EditorButtonEventArgs) Handles UltraTextEditor1.EditorButtonClick
        'Setup Grid
        'Load grid
        If UltraGrid1.Visible = True Then
            UltraGrid1.Visible = False
        Else
            UltraGrid1.Visible = True
        End If


    End Sub


    Private Sub Load_Grid()

        If Me.UltraGrid1.Visible = True Then
            'Me.UltraGrid1.Visible = False
            If Me.UltraGrid1.Selected.Rows.Count = 1 Then
                Me.UltraTextEditor1.Text = Me.UltraGrid1.Selected.Rows(0).Cells(0).Value
                Get_Customer_Name(Me.UltraTextEditor1.Text)
            End If
        Else
            Me.UltraGrid1.Visible = True
        End If

    End Sub
    Private Sub Setup_grid1()

        UltraGrid1.DisplayLayout.GroupByBox.Hidden = True
        UltraGrid1.DisplayLayout.Bands(0).Override.CellClickAction = CellClickAction.RowSelect
        UltraGrid1.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
        UltraGrid1.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        UltraGrid1.DisplayLayout.Override.SelectTypeRow = SelectType.Default
        UltraGrid1.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False

    End Sub

    Private Sub UltraGrid1_Click(sender As Object, e As EventArgs) Handles UltraGrid1.Click
        Load_Grid()
    End Sub
    Private Sub Get_Customer_Name(s As String)
        Dim n As tblECMcustomer = db.get_tblECMCustomer_Name(s)
        Me.UltraLabel4.Text = n.Name
    End Sub
End Class