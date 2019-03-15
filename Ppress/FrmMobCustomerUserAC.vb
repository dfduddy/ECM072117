Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Shared
Imports System.Text.RegularExpressions
Imports System.Net.Mail
Imports System.Data.Entity
Imports Newtonsoft.Json
Imports System

Public Class FrmMobCustomerUserAC
    Private a_rec As Integer
    Private a_mn As String
    Private a_mode As String
    Dim eflag As Boolean
    Dim appid As String = "FrmMobCustomerUserAC"
    Dim user As String = System.Environment.UserName
    Dim curdate As Date = DateTime.Now
    Public Shared uflag As Boolean
    Public Sub New(mode As String, mn As String)
        ' This call is required by the designer.
        InitializeComponent()
        a_mn = mn
        a_mode = mode
        'setup_panel()
        ' Add any initialization after the InitializeComponent() call.
        'setup_grid()
        'set_display()
        Setup_grid1(a_mn)
        Setup_grid2(a_mn)
        Select Case a_mode
            Case Is = "add"  'add
                Me.UltraLabel5.Text = "Add Mode"
                Me.UltraGrid2.Enabled = False
                Init_Panel()
            Case Is <> "add"  'update
                Me.UltraLabel5.Text = "Change Mode"
                UltraTextEditor1.ReadOnly = True
                Me.UltraGrid2.Enabled = True
                Update_Panel()
                'Me.UltraGrid1.DisplayLayout.Override.SelectTypeRow = SelectType.Single
                'Me.UltraGrid2.DisplayLayout.Override.SelectTypeRow = SelectType.Single
                'Me.UltraCombo1.Enabled = False
        End Select
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub Init_Panel()
        UltraTextEditor1.Text = Nothing
        UltraTextEditor2.Text = Nothing
        UltraTextEditor3.Text = Nothing
        UltraTextEditor4.Text = Nothing
        UltraCombo1.Value = "A"
        'UltraTextEditor5.Text = Nothing
        UltraDateTimeEditor1.Value = Today

    End Sub
    Private Sub Update_Panel()
        Dim R As tblMobile_Customer_User = db.get_tblMobile_Customer_Users(a_mn)
        UltraTextEditor1.Text = R.mobile_number
        UltraTextEditor2.Text = R.first_name
        UltraTextEditor3.Text = R.last_name
        UltraCombo1.Value = R.mobile_status
        ' UltraTextEditor5.Text = R.mobile_status
        UltraTextEditor4.Text = R.comment
        UltraDateTimeEditor1.Value = R.last_verification

    End Sub

    Private Sub UltraButtonCancel_Click(sender As Object, e As EventArgs) Handles UltraButtonCancel.Click
        Build_Bushel_Data()
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
    Private Sub Setup_grid1(mn)
        Me.UltraGrid1.SetDataBinding(db.Get_tblMobile_Customer_Email(mn), Nothing)
        Me.UltraGrid1.DataBind()
    End Sub
    Private Sub Setup_grid2(mn)
        Me.UltraGrid2.SetDataBinding(db.Get_tblMobile_Customer_Xref(mn), Nothing)
        Me.UltraGrid2.DataBind()
        Set_Display2()

    End Sub
    Private Sub Set_Display2()
        UltraGrid2.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Mobile Number"
        UltraGrid2.DisplayLayout.Bands(0).Columns(1).Header.Caption = "Customer ID"
        UltraGrid2.DisplayLayout.Bands(0).Columns(2).Header.Caption = "Customer Status"
        UltraGrid2.ActiveRow = Nothing
        UltraGrid2.Selected.Rows.Clear()
        UltraGrid2.DisplayLayout.Bands(0).Override.CellClickAction = CellClickAction.RowSelect

    End Sub

    Private Sub UltraButtonAdd1_Click(sender As Object, e As EventArgs) Handles UltraButtonAdd1.Click
        Dim f As New FrmMobCustomerEmailAC("add", UltraTextEditor1.Text, " ")
        f.ShowDialog()
        If f.DialogResult = Windows.Forms.DialogResult.OK Then
            'add record
            ' insert_record(f)
            Setup_grid1(a_mn)
        End If

    End Sub

    Private Sub UltraButtonSelect1_Click(sender As Object, e As EventArgs) Handles UltraButtonSelect1.Click
        Dim mode As String
        If Check_Rows(UltraGrid1) = 1 Then
            mode = "change"
            Dim r As UltraGridRow
            r = Me.UltraGrid1.Selected.Rows(0)
            Dim f As New FrmMobCustomerEmailAC(mode, r.Cells(1).Value, r.Cells(0).Value)
            f.ShowDialog()
            If f.DialogResult = Windows.Forms.DialogResult.OK Then
                'update db
                'update_record(f)
                Setup_grid1(a_mn)
            End If
        End If
    End Sub
    Private Function Check_Rows(grid As UltraGrid) As Integer
        If grid.Selected.Rows.Count > 1 Then
            MessageBox.Show("Multiple Row selection not allowed", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        Return grid.Selected.Rows.Count
    End Function

    Private Sub UltraButtonAdd2_Click(sender As Object, e As EventArgs) Handles UltraButtonAdd2.Click
        Dim f As New FrmMobCustomerXrefAC("add", UltraTextEditor1.Text, " ")
        f.ShowDialog()
        If f.DialogResult = Windows.Forms.DialogResult.OK Then
            'add record
            ' insert_record(f)
        End If
        Setup_grid2(a_mn)
    End Sub

    Private Sub UltraButton2_Click(sender As Object, e As EventArgs) Handles UltraButtonSelect2.Click
        Dim mode As String
        If Check_Rows(UltraGrid2) = 1 Then
            mode = "change"
            Dim r As UltraGridRow
            r = Me.UltraGrid2.Selected.Rows(0)
            Dim f As New FrmMobCustomerXrefAC(mode, r.Cells(0).Value, r.Cells(1).Value)
            f.ShowDialog()
            If f.DialogResult = Windows.Forms.DialogResult.OK Then
                'update db
                'update_record(f)
                Setup_grid2(a_mn)
            End If
        End If
    End Sub

    Private Sub UltraGrid1_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles UltraGrid1.InitializeLayout
        'e.Layout.Bands(0).Columns(0).Hidden = True
    End Sub

    Private Sub UltraGrid2_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles UltraGrid2.InitializeLayout
        e.Layout.Bands(0).Override.HeaderAppearance.BackColor = Color.LightBlue
        'e.Layout.Bands(0).Columns(0).Hidden = True
        'e.Layout.Bands(0).Columns(7).Hidden = True
    End Sub

    Private Sub UltraButtonOK_Click(sender As Object, e As EventArgs) Handles UltraButtonOK.Click
        'Edit Data
        Edit_Data()
        If eflag = 0 Then
            'Output Data
            Select Case a_mode
                Case Is = "add"
                    Insert_Customer_User()
                Case Is = "change"
                    Update_Customer_User()
            End Select
            Build_Bushel_Data()
        End If

    End Sub


    Private Sub Insert_Customer_User()
        Dim dc As New DataClasses1DataContext
        Try
            Dim rec As New tblMobile_Customer_User With
                {.mobile_number = UltraTextEditor1.Text, .first_name = UltraTextEditor2.Text, .last_name = UltraTextEditor3.Text,
                .mobile_status = UltraCombo1.Value, .last_verification = UltraDateTimeEditor1.Value, .comment = UltraTextEditor4.Text, .created_user = user,
                .created_date = curdate, .change_user = user, .change_date = curdate}
            dc.tblMobile_Customer_Users.InsertOnSubmit(rec)
            dc.SubmitChanges()
            DialogResult = DialogResult.OK
        Catch ex As Exception
            MessageBox.Show("Insert failed contact IT for assistance " & vbCrLf & "Message Code " & ex.Message, "Insert Failure (tblMobile_Customer_User)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    Private Sub Update_Customer_User()
        Dim dc As New DataClasses1DataContext
        Dim rec = (From c In dc.tblMobile_Customer_Users Where c.mobile_number = a_mn).ToList()(0)
        With rec
            .mobile_number = UltraTextEditor1.Text
            .first_name = UltraTextEditor2.Text
            .last_name = UltraTextEditor3.Text
            .mobile_status = UltraCombo1.Value
            .last_verification = UltraDateTimeEditor1.Value
            .comment = UltraTextEditor4.Text
            .change_user = user
            .change_date = curdate
        End With
        Try
            dc.SubmitChanges()
            DialogResult = DialogResult.OK
        Catch ex As Exception
            MessageBox.Show("Update failed contact IT for assistance " & vbCrLf & "Message Code " & ex.Message, "Update Failure (tblMobile_Customer_User)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    Private Sub Edit_Data()
        eflag = 0
        If IsValidPhoneNumber(UltraTextEditor1.Text) = False Then
            MessageBox.Show("Invalid Mobile Number, plese retry", "Invalid Mobile Number", MessageBoxButtons.OK)
            eflag = 1
            UltraTextEditor1.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(UltraTextEditor2.Text) Then
            MessageBox.Show("First Name is required, please enter", "Invalid or missing input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            eflag = 1
            UltraTextEditor2.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(UltraTextEditor3.Text) Then
            MessageBox.Show("Last Name is required, please enter", "Invalid or missing input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            eflag = 1
            UltraTextEditor3.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(UltraCombo1.Value) Then
            MessageBox.Show("Statis Code is required, please enter", "Invalid or missing input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            eflag = 1
            UltraCombo1.Focus()
        End If
    End Sub

    Public Function IsValidPhoneNumber(ByVal phoneNumber As String) As Boolean
        'Dim pattern As String = "^[1-9]\d{2}-[1-9]\d{2}-\d{4}$"
        phoneNumber = phoneNumber.Trim
        Dim pattern As String = "^[1-9]\d{2}[1-9]\d{2}\d{4}$"
        Dim test As New Regex(pattern)
        Dim valid As Boolean = False
        valid = test.IsMatch(phoneNumber, 0)
        Return valid
    End Function

    Private Sub FrmMobCustomerUserAC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'PpressDataSet.tblMobile_Statis_Codes' table. You can move, or remove it, as needed.
        Me.TblMobile_Statis_CodesTableAdapter.Fill(Me.PpressDataSet.tblMobile_Statis_Codes)
    End Sub
    Private Sub Build_Bushel_Data() 'build data for Bushel Appplication
        If uflag Then  'update flag from customer update
            Dim rcnt As Integer
            Dim jstring As New Bushel
            'Dim custid As New Customer
            Dim phoneno As New Phonenumber
            Dim r As UltraGridRow
            For Each r In UltraGrid2.Rows
                If r.Cells(2).Text.Trim = "A" Then  'check active flag
                    Dim custid = New Customer
                    custid.First_name = UltraTextEditor2.Text
                    custid.Last_name = UltraTextEditor3.Text
                    custid.Id = r.Cells(1).Text
                    phoneno.Customer.Add(custid)
                    rcnt = ++1
                End If
            Next
            If rcnt > 0 Then  'send if active rows created
                phoneno.Phoneno = UltraTextEditor1.Text
                jstring.Phonenumber.Add(phoneno)
                'jstring.Customer.Add(custid)
                Dim result = JsonConvert.SerializeObject(jstring)
                Post_Api_Data(result)
            End If
            uflag = False
        End If
    End Sub
    Private Sub Post_Api_Data(jstring As String)
        HTTP.APIUrl = "https://scoularprod.azure-api.net/api/ecm/accounts"
        Dim result = HTTP.HTTPRequest(HTTP.APIUrl, HTTP.Methods.mPOST, jstring)
        If Not result.Contains("success") Then
            Dim mail As New MailMessage
            mail.From = New MailAddress("systems@scoular.com")
            mail.To.Add("scoularmobilesupport@scoular.com")
            mail.Subject() = "Mobile Enrollment API Failure"
            mail.Body() = "Failure with Mobile Enrollment API please confirm status"
            Dim smtp As New SmtpClient
            smtp.Host = "scoular.com"
            smtp.UseDefaultCredentials = True
            smtp.Port = 25
            smtp.Send(mail)
        End If
    End Sub
End Class