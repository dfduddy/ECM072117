Imports System.Data.SqlClient
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Shared
Imports System.Linq
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.Sql

Public Class db
    Public Shared Function GetConnection(ByVal strDatabase As String) As SqlConnection
        Return New SqlConnection(GetConnectionString(strDatabase))
    End Function
    Public Shared Function GetConnectionString(ByVal strDatabase As String) As String
        Dim strString As String
        strString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog="
        strString = strString & strDatabase & ";Data Source=OPSQLSVR001\SQLSVR2008"
        'strString = strString & strDatabase & ";Data Source=WS0392"
        Select Case strDatabase
            Case Is = "Ppress"
                strString = My.Settings.PPressConnetion
            Case Is = "Ppress2"
                strString = My.Settings.PpressConnection2
        End Select
        Return strString
    End Function
    Public Shared Function get_tblECMmast_linq() As Object
        Dim dc As New DataClasses1DataContext
        Dim query = From c In dc.tblECMmasts Order By c.Type, c.Location, c.Customer, c.MA, c.Recipent Select c.Recid, c.Type, c.Location, c.Customer, c.MA, c.Recipent, c.User, c.Chgdate, c.Trader, c.Pflag
        Return query
    End Function
    Public Shared Function get_tblECMmast(sql) As DataTable
        Dim ds As New DataSet
        Dim con As SqlConnection = GetConnection("Ppress")
        'Dim con As SqlConnection = GetConnection("Ppress2") 'test db *** test
        '!!! BE SURE TO CHANGE DATACONTEXT DBML  !!!
        Dim cmd As New SqlCommand(sql, con)
        cmd.CommandType = CommandType.Text
        Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
        Dim dt As New DataTable("tblECMmast")
        ds.Tables.Add("tblECMmast")
        da.Fill(dt)
        da.Dispose()
        con.Close()
        Return dt
    End Function
    Public Shared Function get_tblECMType() As Object
        'Dim dc As New DataClasses1DataContext
        'Dim query = From c In dc.tblECMtypes Select c.Type Distinct
        'Return query
        Dim dc As New DataClasses1DataContext
        Dim type = From c In dc.tblECMtypes
                   Order By c.Type
                  Select New With {.Type = c.Type, c.Desc} Distinct
        Return type
    End Function
    Public Shared Function get_tblECMLocation() As Object
        Dim dc As New DataClasses1DataContext
        Dim location = From c In dc.tblECMlocations
                  Select New With {.Location = c.Location} Distinct
        Return location
    End Function
    Public Shared Function get_tblECMMA() As Object
        Dim dc As New DataClasses1DataContext
        Dim ID = From c In dc.tblECMmaids
                  Select New With {.id = c.ID} Distinct
        Return ID
    End Function
    Public Shared Function get_tblECMCustomer() As Object
        Dim dc As New DataClasses1DataContext
        Dim customer = From c In dc.tblECMcustomers
                  Select New With {.ma = c.CustID}
        Return customer
    End Function
    Public Shared Function get_merchandiser() As DataTable
        Dim ds As New DataSet
        Dim oCNiseries As New OdbcConnection("Driver={iSeries Access ODBC Driver};SYSTEM=S10B1350;UID=MSOLAP;PWD=STAR@84;")
        oCNiseries.Open()
        Dim ocmd As New OdbcCommand
        ocmd.Connection = oCNiseries
        ocmd.CommandText = "Select distinct VCDDES from S10B1350.TSCPRDLIB.GNP004 WHERE (VPREFX = 'TR') ORDER BY VCDDES"
        ocmd.CommandType = CommandType.Text
        Dim da As OdbcDataAdapter = New OdbcDataAdapter(ocmd)
        Dim dt As New DataTable("Merchandiser")
        ds.Tables.Add("Merchandiser")
        da.Fill(dt)
        oCNiseries.Close()
        Return dt
    End Function
    Public Shared Function get_merchandiser_code() As DataTable
        Dim ds As New DataSet
        Dim oCNiseries As New OdbcConnection("Driver={iSeries Access ODBC Driver};SYSTEM=S10B1350;UID=MSOLAP;PWD=STAR@84;")
        oCNiseries.Open()
        Dim ocmd As New OdbcCommand
        ocmd.Connection = oCNiseries
        ocmd.CommandText = "Select VALIDC,VCDDES from S10B1350.TSCPRDLIB.GNP004 WHERE (VPREFX = 'TR') ORDER BY VALIDC"
        ocmd.CommandType = CommandType.Text
        Dim da As OdbcDataAdapter = New OdbcDataAdapter(ocmd)
        Dim dt As New DataTable("Name")
        ds.Tables.Add("Name")
        da.Fill(dt)
        oCNiseries.Close()
        Return dt
    End Function
    Public Shared Function check_customer(cust As String) As Boolean
        Dim dc As New DataClasses1DataContext
        Dim query = (From c In dc.GetTable(Of tblECMcustomer)()
                    Order By c.CustID Where c.CustID = cust Select c).Count
        If query = 0 Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Shared Function get_tblECMMastr(r As Decimal) As tblECMmast
        Dim dc As New DataClasses1DataContext
        Dim e As tblECMmast
        e = (From c In dc.tblECMmasts
         Where (c.Recid = r)
                    Select c).SingleOrDefault()
        Return e
    End Function
    Public Shared Function get_tblECMMasto(r As Decimal) As Object
        Dim dc As New DataClasses1DataContext
        Dim e As tblECMmast
        e = (From c In dc.tblECMmasts
         Where (r = c.Recid)
                    Select c).SingleOrDefault()
        Return e
    End Function
    Public Shared Function get_tblECMmast_type() As Object
        Dim dc As New DataClasses1DataContext
        Dim type = (From c In dc.tblECMmasts
                    Select New With {c.Type}).Distinct.OrderBy(Function(c) c.Type)
        Return type
    End Function
    Public Shared Function get_tblECMmast_location() As Object
        'use lambda expression
        Dim dc As New DataClasses1DataContext
        Dim location = (From c In dc.tblECMmasts
                         Select New With {c.Location}).Distinct().OrderBy(Function(c) c.Location)
        Return location
    End Function

    Public Shared Function get_tblECMmast_customer() As Object
        Dim dc As New DataClasses1DataContext
        Dim customer = (From c In dc.tblECMmasts
                     Select New With {c.Customer}).Distinct.OrderBy(Function(c) c.Customer)
        Return customer
    End Function
    Public Shared Function get_tblECMmast_MA() As Object
        Dim dc As New DataClasses1DataContext
        Dim ma = (From c In dc.tblECMmasts
                    Select New With {c.MA}).Distinct.OrderBy(Function(c) c.MA)
        Return ma
    End Function
    Public Shared Function get_tblECMmast_Recipent() As Object
        Dim dc As New DataClasses1DataContext
        Dim recipent = (From c In dc.tblECMmasts
                    Select New With {c.Recipent}).Distinct.OrderBy(Function(c) c.Recipent)
        Return recipent
    End Function
    Public Shared Function get_tblECMmast_Trader() As Object
        Dim dc As New DataClasses1DataContext
        Dim trader = (From c In dc.tblECMmasts
                    Select New With {c.Trader}).Distinct.OrderBy(Function(c) c.Trader)
        Return trader
    End Function
    'Public Shared Function get_view_CustConf_Customer() As Object
    '    Dim dc As New DataClasses1DataContext
    '    Dim query = From c In dc.view_CustConf_Customers Order By c.Custid Select c
    '    Return query
    'End Function

    Public Shared Function get_CustConf() As Object
        Dim dc As New DataClasses1DataContext
        Dim query = (From c In dc.tblECMCustConfs Join o In dc.tblECMcustomers On o.CustID Equals c.Custid Select c.Location, c.Custid, c.ConfDate, c.Adddate, c.User, o.Name).OrderBy(Function(c) c.Location).ThenBy(Function(c) c.Custid)
        Return query
    End Function

    Public Shared Function get_tblECMCustConf(l As String, cust As String) As tblECMCustConf
        Dim dc As New DataClasses1DataContext
        Dim e As tblECMCustConf
        e = (From c In dc.tblECMCustConfs
         Where (c.Location = l And c.Custid = cust)
                    Select c).SingleOrDefault
        Return e
    End Function
    Public Shared Function get_tblECMprcntl3_linq() As Object
        Dim dc As New DataClasses1DataContext
        Dim query = From c In dc.tblecmprcntl3s Order By c.Refid, c.Loc Select c
        Return query
    End Function
    Public Shared Function get_tblECMprcntl2_linq() As Object
        Dim dc As New DataClasses1DataContext
        Dim query = From c In dc.tblECMprcntl2s Order By c.MAid, c.Zipcode Select c
        Return query
    End Function
    Public Shared Function get_tblECMprcntl3_refid() As Object
        'use lambda expression
        Dim dc As New DataClasses1DataContext
        Dim refid = (From c In dc.tblecmprcntl3s
                         Select New With {c.Refid}).Distinct().OrderBy(Function(c) c.Refid)
        Return refid
    End Function
    Public Shared Function get_tblECMprcntl3_loc() As Object
        'use lambda expression
        Dim dc As New DataClasses1DataContext
        Dim loc = (From c In dc.tblecmprcntl3s
                         Select New With {c.Loc}).Distinct().OrderBy(Function(c) c.Loc)
        Return loc
    End Function
    Public Shared Function get_tblECMprcntl3_zipcode() As Object
        'use lambda expression
        Dim dc As New DataClasses1DataContext
        Dim zipcode = (From c In dc.tblecmprcntl3s
                         Select New With {c.Zipcode}).Distinct().OrderBy(Function(c) c.Zipcode)
        Return zipcode
    End Function
    Public Shared Function get_tblECMprcntl3_formid() As Object
        'use lambda expression
        Dim dc As New DataClasses1DataContext
        Dim formid = (From c In dc.tblecmprcntl3s
                         Select New With {c.Formid}).Distinct().OrderBy(Function(c) c.Formid)
        Return formid
    End Function
    Public Shared Function get_tblECMprcntl3_printerid() As Object
        'use lambda expression
        Dim dc As New DataClasses1DataContext
        Dim printerid = (From c In dc.tblecmprcntl3s
                         Select New With {c.PrinterID}).Distinct().OrderBy(Function(c) c.PrinterID)
        Return printerid
    End Function
    Public Shared Function get_tblECMprcntl3r(r As Decimal) As tblecmprcntl3
        Dim dc As New DataClasses1DataContext
        Dim e As tblecmprcntl3
        e = (From c In dc.tblecmprcntl3s
         Where (c.Recid = r)
                    Select c).SingleOrDefault()
        Return e
    End Function
    Public Shared Function get_prcntl3_change_linq() As Object
        Dim dc As New DataClasses1DataContext
        Dim query = From c In dc.prcntl3_changes Order By c.Refid, c.Loc Select c
        Return query
    End Function
    Public Shared Function get_MAJoin() As Object
        Dim dc As New DataClasses1DataContext
        Dim query = (From c In dc.tblECMmaids Group Join o In dc.tblECMmamasts On o.MA Equals c.ID Into mas = Group From m In mas.DefaultIfEmpty Select New With {c.ID, c.name, .p = CType(m.Pcopy, Global.System.Nullable(Of Int16))}).OrderBy(Function(c) c.ID)
        Return query
    End Function
    Public Shared Function get_tblECMMamast(m As String) As tblECMmamast
        Dim dc As New DataClasses1DataContext
        Dim e As tblECMmamast
        e = (From c In dc.tblECMmamasts
         Where (c.MA = m)
                    Select c).SingleOrDefault()
        Return e
    End Function
    Public Shared Function get_tblECMMaid(m As String) As tblECMmaid
        Dim dc As New DataClasses1DataContext
        Dim e As tblECMmaid
        e = (From c In dc.tblECMmaids
         Where (c.ID = m)
                    Select c).SingleOrDefault()
        Return e
    End Function
    Public Shared Function check_maid(id As String) As Boolean
        Dim dc As New DataClasses1DataContext
        Dim query = (From c In dc.GetTable(Of tblECMmaid)()
                    Order By c.ID Where c.ID = id Select c).Count
        If query = 0 Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Shared Function check_mamast(id As String) As Boolean
        Dim dc As New DataClasses1DataContext
        Dim query = (From c In dc.GetTable(Of tblECMmamast)()
                    Order By c.MA Where c.MA = id Select c).Count
        If query = 0 Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Shared Function get_maid() As DataTable
        Dim ds As New DataSet
        Dim oCNiseries As New OdbcConnection("Driver={iSeries Access ODBC Driver};SYSTEM=S10B1350;UID=MSOLAP;PWD=STAR@84;")
        oCNiseries.Open()
        Dim ocmd As New OdbcCommand
        ocmd.Connection = oCNiseries
        'ocmd.CommandText = "Select User from S10B1350.TSCPRDLIB.USERPROF ORDER BY User"
        ocmd.CommandText = "Select UPUPRF from S10B1350.TSCPRDLIB.USERPROF WHERE (UPPSOD > '100101') ORDER BY UPUPRF"
        ocmd.CommandType = CommandType.Text
        Dim da As OdbcDataAdapter = New OdbcDataAdapter(ocmd)
        Dim dt As New DataTable("User")
        ds.Tables.Add("User")
        da.Fill(dt)
        oCNiseries.Close()
        Return dt
    End Function
    Public Shared Function check_iseries_id(id As String) As Boolean
        Dim ds As New DataSet
        Dim oCNiseries As New OdbcConnection("Driver={iSeries Access ODBC Driver};SYSTEM=S10B1350;UID=MSOLAP;PWD=STAR@84;")
        oCNiseries.Open()
        Dim ocmd As New OdbcCommand
        ocmd.Connection = oCNiseries
        'ocmd.CommandText = "Select User from S10B1350.TSCPRDLIB.USERPROF ORDER BY User"
        ocmd.CommandText = "Select UPUPRF from S10B1350.TSCPRDLIB.USERPROF WHERE (UPUPRF='" & id & "') ORDER BY UPUPRF"
        ocmd.CommandType = CommandType.Text
        Dim da As OdbcDataAdapter = New OdbcDataAdapter(ocmd)
        Dim dt As New DataTable("User")
        ds.Tables.Add("User")
        da.Fill(dt)
        oCNiseries.Close()
        If dt.Rows.Count <= 0 Then
            Return False
        Else
            Return True
        End If
        Return True
    End Function
    Public Shared Function get_tblECMprcntl2_maid() As Object
        'use lambda expression
        Dim dc As New DataClasses1DataContext
        Dim refid = (From c In dc.tblECMprcntl2s
                         Select New With {c.MAid}).Distinct().OrderBy(Function(c) c.MAid)
        Return refid
    End Function
    Public Shared Function get_tblECMprcntl2_printerid() As Object
        'use lambda expression
        Dim dc As New DataClasses1DataContext
        Dim refid = (From c In dc.tblECMprcntl2s
                         Select New With {c.PrinterID}).Distinct().OrderBy(Function(c) c.PrinterID)
        Return refid
    End Function
    Public Shared Function get_tblECMprcntl2_zipcode() As Object
        'use lambda expression
        Dim dc As New DataClasses1DataContext
        Dim refid = (From c In dc.tblECMprcntl2s
                         Select New With {c.Zipcode}).Distinct().OrderBy(Function(c) c.Zipcode)
        Return refid
    End Function
    Public Shared Function get_tblECMprcntl2_desc() As Object
        'use lambda expression
        Dim dc As New DataClasses1DataContext
        Dim refid = (From c In dc.tblECMprcntl2s
                         Select New With {c.Desc}).Distinct().OrderBy(Function(c) c.Desc)
        Return refid
    End Function
    Public Shared Function get_tblECMprcntl2r(r As Decimal) As tblECMprcntl2
        Dim dc As New DataClasses1DataContext
        Dim e As tblECMprcntl2
        e = (From c In dc.tblECMprcntl2s
         Where (c.Recid = r)
                    Select c).SingleOrDefault()
        Return e
    End Function
    Public Shared Function get_prcntl2_change_linq() As Object
        Dim dc As New DataClasses1DataContext
        Dim query = From c In dc.prcntl2_changes Order By c.MAid, c.Zipcode, c.PrinterID Select c
        Return query
    End Function
    Public Shared Function get_ECMmast_change_linq() As Object
        Dim dc As New DataClasses1DataContext
        Dim query = From c In dc.ECMmast_changes Order By c.Type, c.Location, c.Customer, c.MA Select c
        Return query
    End Function
    Public Shared Function get_tblECMecosign_linq() As Object
        Dim dc As New DataClasses1DataContext
        Dim query = From c In dc.tblECMecosigns Order By c.TRid Select c
        Return query
    End Function
    Public Shared Function get_tblECMecosign_TRid() As Object
        'use lambda expression
        Dim dc As New DataClasses1DataContext
        Dim refid = (From c In dc.tblECMecosigns
                         Select New With {c.TRid}).Distinct().OrderBy(Function(c) c.TRid)
        Return refid
    End Function
    Public Shared Function get_tblECMecosign_customer() As Object
        'use lambda expression
        Dim dc As New DataClasses1DataContext
        Dim refid = (From c In dc.tblECMecosigns
                         Select New With {c.Customer}).Distinct().OrderBy(Function(c) c.Customer)
        Return refid
    End Function
    Public Shared Function get_tblECMecosign_TRname() As Object
        'use lambda expression
        Dim dc As New DataClasses1DataContext
        Dim refid = (From c In dc.tblECMecosigns
                         Select New With {c.TRname}).Distinct().OrderBy(Function(c) c.TRname)
        Return refid
    End Function

    Public Shared Function get_tblECMecosignr(r As Decimal) As tblECMecosign
        Dim dc As New DataClasses1DataContext
        Dim e As tblECMecosign
        e = (From c In dc.tblECMecosigns
         Where (c.Recid = r)
                    Select c).SingleOrDefault()
        Return e
    End Function
    Public Shared Function get_tblECMecosign_Trname(t As String) As String
        Dim dc As New DataClasses1DataContext
        Dim e As tblECMecosign
        e = (From c In dc.tblECMecosigns
         Where (c.TRid = t)
                    Select c).SingleOrDefault

        Dim name As String = e.TRname
        Return name
    End Function
    Public Shared Function get_tblECMcustomer_linq() As Object
        Dim dc As New DataClasses1DataContext
        Dim query = From c In dc.tblECMcustomers Order By c.CustID Select c
        Return query
    End Function
    Public Shared Function insert_ecm_change(r As UltraGridRow, u As String)
        'populate work table (user id)
        Dim sqlcmd As New SqlCommand
        Dim con As SqlConnection = GetConnection("Ppress")
        con.Open()
        sqlcmd.CommandType = CommandType.Text
        sqlcmd.Connection = con
        sqlcmd.CommandText = "insert into " & u & " values ('" & r.Cells(1).Value & "','" & r.Cells(2).Value & _
            "','" & r.Cells(3).Value & "','" & r.Cells(4).Value & "','" & r.Cells(5).Value & "','" & Today & _
            "','" & u & "','" & r.Cells(8).Value & "','" & r.Cells(9).Value & "','" & r.Cells(0).Value & "')"
        sqlcmd.ExecuteNonQuery()
        con.Close()
        Return 0
    End Function
    Public Shared Function get_ecm_change(u As String)
        'get ecm selected change rows
        Dim ds As New DataSet
        Dim sqlcmd As New SqlCommand
        Dim con As SqlConnection = GetConnection("Ppress")
        con.Open()
        sqlcmd.CommandText = "select * from " & u
        sqlcmd.CommandType = CommandType.Text
        sqlcmd.Connection = con
        sqlcmd.ExecuteNonQuery()
        Dim da As SqlDataAdapter = New SqlDataAdapter(sqlcmd)
        Dim dt As New DataTable("ecm_changes")
        ds.Tables.Add(u)
        da.Fill(dt)
        da.Dispose()
        con.Close()
        Return dt
    End Function
    Public Shared Function get_tblECMPrinter_Settings_linq() As Object
        Dim dc As New DataClasses1DataContext
        Dim query = From c In dc.tblECMPrinter_Settings Order By c.Printer_Name Select c
        Return query
    End Function
    Public Shared Function get_tblECMPrinter_Settingsr(r As Decimal) As tblECMPrinter_Setting
        Dim dc As New DataClasses1DataContext
        Dim e As tblECMPrinter_Setting
        e = (From c In dc.tblECMPrinter_Settings
         Where (c.Recid = r)
                    Select c).SingleOrDefault()
        Return e
    End Function
End Class
