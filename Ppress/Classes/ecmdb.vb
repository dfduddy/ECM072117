Imports Newtonsoft.Json

Class Bushel
    <JsonProperty(PropertyName:="data")>
    Public Property Phonenumber As List(Of Phonenumber) = New List(Of Phonenumber)
    '<JsonProperty(PropertyName:="customer")>
    'Public Property Customer As List(Of Customer) = New List(Of Customer)


End Class

Public Class CustList
    <JsonProperty(PropertyName:="customers")>
    Public Property customers As List(Of Customer) = New List(Of Customer)
End Class
Public Class Phonenumbers
    <JsonProperty(PropertyName:="phonenumber")>
    Public Property phonenumbers As List(Of Phonenumber) = New List(Of Phonenumber)
End Class


Public Class Customer
    <JsonProperty(PropertyName:="id")>
    Public Property Id As String
    <JsonProperty(PropertyName:="first_name")>
    Public Property First_name As String
    <JsonProperty(PropertyName:="last_name")>
    Public Property Last_name As String
End Class
Public Class Phonenumber
    <JsonProperty(PropertyName:="phonenumber")>
    Public Property Phoneno As String
    <JsonProperty(PropertyName:="customers")>
    Public Property Customer As List(Of Customer) = New List(Of Customer)

End Class










