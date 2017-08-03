Public Class Cls_ECMmast
    Private C_Recid
    Private C_Type As String
    Private C_Location As String
    Private C_Customer As String
    Private C_MA As String
    Private C_Recipent As String
    Private C_User As String
    Private C_Chgdate As Date
    Private C_Trader As String
    Private C_Pflag As String
    Public Sub New()

    End Sub
    Public Property Recid As String
        Get
            Return C_Recid
        End Get
        Set(value As String)
            C_Recid = value
        End Set
    End Property
    Public Property Type As String
        Get
            Return C_Type
        End Get
        Set(value As String)
            C_Type = value
        End Set
    End Property
    Public Property Location As String
        Get
            Return C_Location
        End Get
        Set(value As String)
            C_Location = value
        End Set
    End Property
    Public Property Customer As String
        Get
            Return C_Customer
        End Get
        Set(value As String)
            C_Customer = value
        End Set
    End Property
    Public Property MA As String
        Get
            Return C_MA
        End Get
        Set(value As String)
            C_MA = value
        End Set
    End Property
    Public Property Recipent As String
        Get
            Return C_Recipent
        End Get
        Set(value As String)
            C_Recipent = value
        End Set
    End Property
    Public Property Chgdate As Date
        Get
            Return C_Chgdate
        End Get
        Set(value As Date)
            C_Chgdate = value
        End Set
    End Property
    Public Property user As String
        Get
            Return C_User
        End Get
        Set(value As String)
            C_User = value
        End Set
    End Property
    Public Property Trader As String
        Get
            Return C_Trader
        End Get
        Set(value As String)
            C_Trader = value
        End Set
    End Property
    Public Property Plag As String
        Get
            Return C_Pflag
        End Get
        Set(value As String)
            C_Pflag = value
        End Set
    End Property

End Class
