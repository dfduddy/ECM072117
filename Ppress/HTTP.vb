Imports System.IO
Imports System.Net
Imports System.Text
Imports Newtonsoft.Json

Public Class HTTP

    Private Shared lAPIUrl As String
    Public Shared Property APIUrl As String
        Get
            APIUrl = lAPIUrl
        End Get
        Set(value As String)
            lAPIUrl = value
        End Set
    End Property

    Private Shared lUsername As String
    Public Shared Property Username As String
        Get
            Username = lUsername
        End Get
        Set(value As String)
            lUsername = value
        End Set
    End Property

    Private Shared lPassword As String
    Public Shared Property Password As String
        Get
            Password = lPassword
        End Get
        Set(value As String)
            lPassword = value
        End Set
    End Property

    Private Shared token As String = ""

    Public Class jsonToken
        Public token As String
    End Class

    Public Shared Sub Login()

        Dim auth() As Byte = System.Text.Encoding.UTF8.GetBytes(username & ":" & password)
        Dim auth64 = System.Convert.ToBase64String(auth)

        Dim request As WebRequest = WebRequest.Create(APIUrl & "users/login")
        request.Method = "GET"
        request.Headers.Add("Authorization", "Basic " & auth64)

        Dim response As WebResponse = request.GetResponse()
        Dim dataStream As Stream = response.GetResponseStream()
        Dim reader As New StreamReader(dataStream)
        Dim responseFromServer As String = reader.ReadToEnd()

        Dim data As jsonToken = JsonConvert.DeserializeObject(Of jsonToken)(responseFromServer)

        Dim Tauth() As Byte = System.Text.Encoding.UTF8.GetBytes(Username & ":" & data.token)
        Dim Tauth64 = System.Convert.ToBase64String(Tauth)

        token = "Token " & Tauth64

    End Sub

    Public Shared Function HTTPRequest(uri As String, method As Methods, Optional postData As String = "") As String
        Dim request As WebRequest
        If uri.Substring(0, 4) = "http" Then
            request = WebRequest.Create(uri)
        Else
            request = WebRequest.Create(APIUrl & uri)
        End If

        Select Case method
            Case Methods.mGET
                request.Method = "GET"
            Case Methods.mPOST
                request.Method = "POST"
            Case Methods.mPUT
                request.Method = "PUT"
            Case Methods.mDELETE
                request.Method = "DELETE"
        End Select

        request.Headers.Add("Authorization", token) 'not needed


        If request.Method = "POST" Or request.Method = "PUT" Then
            Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)
            'request.Headers.Add("Ocp-Apim-Trace", "true") 'turn on for tracing
            request.Headers.Add("Ocp-Apim-Subscription-Key", "3f5dbf2a2cc942d3aa76125435999b69")
            request.ContentType = "application/json"
            request.ContentLength = byteArray.Length
            Dim ReqDataStream As Stream = request.GetRequestStream()
            Try
                ReqDataStream.Write(byteArray, 0, byteArray.Length)
            Catch
            End Try

            ReqDataStream.Close()
        End If

        Dim response As WebResponse = request.GetResponse()
        'Console.WriteLine(CType(response, HttpWebResponse).StatusCode & " - " & CType(response, HttpWebResponse).StatusDescription)
        Dim dataStream As Stream = response.GetResponseStream()
        Dim reader As New StreamReader(dataStream)
        Dim responseFromServer As String = reader.ReadToEnd()

        Return responseFromServer

    End Function

    Public Enum Methods
        mGET = 0
        mPOST = 1
        mPUT = 2
        mDELETE = 3
    End Enum

End Class
