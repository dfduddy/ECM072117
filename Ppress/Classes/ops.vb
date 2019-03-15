Imports System.Data.SqlClient
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Shared
Imports System.Linq
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.Sql
Imports System.Net.Mail
Public Class ops
    Public Shared Function get_authority(u As String) As tblECMAuthority
        Dim dc As New DataClasses1DataContext
        Dim a As tblECMAuthority
        a = (From c In dc.tblECMAuthorities
         Where (c.Userid = u)
                    Select c).SingleOrDefault
        Return a
    End Function
    Public Shared Function check_confirmation(cust As String) As Integer
        Dim dc As New DataClasses1DataContext
        Dim a As Integer
        a = (From c In dc.tblECMCustConfs
         Where (c.Custid = cust)
                    Select c).Count
        Return a
    End Function
    Public Shared Function get_helpcontact(appid As String) As tblECMhelpcontact
        Dim dc As New DataClasses1DataContext
        Dim e As tblECMhelpcontact
        e = (From c In dc.tblECMhelpcontacts
         Where (c.Appid = appid)
                    Select c).SingleOrDefault
        Return e
    End Function
    Public Shared Function check_authority(l As Integer) As Boolean
        Dim userlist As New tblECMAuthority
        If IsNothing(ops.get_authority(System.Environment.UserName)) Then  'user not on file
            userlist.Authority = 0
        Else
            userlist = ops.get_authority(System.Environment.UserName)
        End If
        If userlist.Authority < l Then  'not authorized
            MessageBox.Show("You do not have authority to run this application" & vbCrLf & _
                             "Contact IT for assistance", "User Authorization", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        Else
            Return True
        End If
    End Function
    Public Shared Function get_active_row_count(g As UltraGrid) As Integer
        Return 0

    End Function
    Public Function send_email(recp As String, msg As String) As Boolean
        Dim SmtpServer As New SmtpClient()
        Dim mail As New MailMessage()
        SmtpServer.UseDefaultCredentials = True
        'Net.NetworkCredential()
        SmtpServer.Port = 25
        SmtpServer.Host = "op-mail"
        mail = New MailMessage()
        mail.From = New MailAddress("YOURusername@gmail.com")
        mail.To.Add("TOADDRESS")
        mail.Subject = "Test Mail"
        mail.Body = "This is for testing SMTP mail from GMAIL"
        SmtpServer.Send(mail)
        Return True
    End Function


End Class
