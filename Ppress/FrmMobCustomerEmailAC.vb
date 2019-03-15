'01/07/19  form was deactived will not be used  DFD
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Shared
Imports System.Text.RegularExpressions
Imports System.Net.Mail
Imports Newtonsoft.Json
Public Class FrmMobCustomerEmailAC
    Private a_rec As Integer
    Private a_mn As String
    Private a_em As String
    Private a_mode As String
    Dim eflag As Boolean
    Dim user As String = System.Environment.UserName
    Dim curdate As Date = DateTime.Now
    Dim appid As String = "FrmModCustomerEmailAC"
    Public Sub New(mode As String, mn As String, em As String)

        ' This call is required by the designer.
        InitializeComponent()
        a_mn = mn
        a_em = em
        a_mode = mode
        'setup_panel()
        ' Add any initialization after the InitializeComponent() call.
        'setup_grid()
        'set_display()
        Select Case a_mode
            Case Is = "add"  'add
                Me.UltraLabel5.Text = "Add Mode"
                UltraTextEditor2.ReadOnly = True
                init_panel()
            Case Is <> "add"  'update
                Me.UltraLabel5.Text = "Change Mode"
                UltraTextEditor2.ReadOnly = True
                Update_Panel1()
                'Me.UltraGrid1.DisplayLayout.Override.SelectTypeRow = SelectType.Single
                'Me.UltraGrid2.DisplayLayout.Override.SelectTypeRow = SelectType.Single
                'Me.UltraCombo1.Enabled = False
        End Select
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub init_panel()
        UltraTextEditor1.Text = Nothing
        UltraTextEditor2.Text = a_mn
        'UltraTextEditor3.Text = Nothing
        UltraTextEditor4.Text = Nothing
        UltraCombo1.Text = "A"

    End Sub
    Private Sub Update_Panel1()
        Dim R As tblMobile_Customer_Email = db.Get_tblMobile_Customer_Email_Mobile_Number(a_mn, a_em)
        UltraTextEditor1.Text = R.email_address
        UltraTextEditor2.Text = R.mobile_number
        UltraCombo1.Value = R.email_status
        'UltraTextEditor3.Text = R.email_status
        UltraTextEditor4.Text = R.comment

    End Sub

    Private Sub UltraButtonCancel_Click(sender As Object, e As EventArgs) Handles UltraButtonCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub UltraLabel3_Click(sender As Object, e As EventArgs) Handles UltraLabel3.Click

    End Sub

    Private Sub UltraButtonOK_Click(sender As Object, e As EventArgs) Handles UltraButtonOK.Click
        'Edit Data
        Edit_Data
        If eflag = 0 Then
            'Output Data
            Select Case a_mode
                Case Is = "add"
                    Insert_Customer_User()
                Case Is = "change"
                    If UltraTextEditor1.Text <> a_em Then  'If FK value changes delete and re-add for linq to sql
                        Delete_Customer_User()
                        Insert_Customer_User()
                    Else
                        Update_Customer_User()  'no changes to FK
                    End If
            End Select
            Post_Data()

        End If
    End Sub
    Private Sub Insert_Customer_User()
        Dim dc As New DataClasses1DataContext
        Try
            Dim rec As New tblMobile_Customer_Email With
                {.mobile_number = UltraTextEditor2.Text, .email_address = UltraTextEditor1.Text,
                .email_status = UltraCombo1.Value, .comment = UltraTextEditor4.Text, .created_user = user,
                .created_date = curdate, .changed_user = user, .changed_date = curdate}
            dc.tblMobile_Customer_Emails.InsertOnSubmit(rec)
            dc.SubmitChanges()
            DialogResult = DialogResult.OK
        Catch ex As Exception
            MessageBox.Show("Insert failed contact IT for assistance " & vbCrLf & "Message Code " & ex.Message, "Insert Failure (tblMobile_Customer_User)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    Private Sub Update_Customer_User()
        Dim dc As New DataClasses1DataContext
        Dim rec = (From c In dc.tblMobile_Customer_Emails Where c.mobile_number = a_mn And c.email_address = a_em).ToList()(0)
        With rec
            .mobile_number = a_mn
            .email_address = UltraTextEditor1.Text
            .email_status = UltraCombo1.Value
            .comment = UltraTextEditor4.Text
            .changed_user = user
            .changed_date = curdate
        End With
        Try
            dc.SubmitChanges()
            DialogResult = DialogResult.OK
        Catch ex As Exception
            MessageBox.Show("Update failed contact IT for assistance " & vbCrLf & "Message Code " & ex.Message, "Update Failure (tblMobile_Customer_User)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    Private Sub Delete_Customer_User()
        Dim dc As New DataClasses1DataContext
        Dim rec = (From c In dc.tblMobile_Customer_Emails Where c.mobile_number = a_mn And c.email_address = a_em).FirstOrDefault
        dc.tblMobile_Customer_Emails.DeleteOnSubmit(rec)
        Try
            dc.SubmitChanges()
        Catch ex As Exception
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
            MessageBox.Show("email address is required, please enter", "Invalid or missing input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            eflag = 1
            UltraTextEditor1.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(UltraCombo1.Value) Then
            MessageBox.Show("Statis Code is required, please enter", "Invalid or missing input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            eflag = 1
            UltraCombo1.Focus()
        End If
        If check_email(UltraTextEditor1.Text) = False Then
            MessageBox.Show(UltraTextEditor1.Text & " = Invalid email address, please correct", "Invalid email address", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            eflag = True
            Exit Sub
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

    Private Sub FrmMobCustomerEmailAC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'PpressDataSet.tblMobile_Statis_Codes' table. You can move, or remove it, as needed.
        Me.TblMobile_Statis_CodesTableAdapter.Fill(Me.PpressDataSet.tblMobile_Statis_Codes)

    End Sub
    Private Sub Post_Data() 'post info via API
        'Dim Mobitem As New Ecmdb
        'Dim result = JsonConvert.SerializeObject(Mobitem)
    End Sub

End Class