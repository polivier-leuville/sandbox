Imports System.Runtime.Serialization

<Serializable()>
Public Class QuoteException
    Inherits Exception
    Implements ISerializable

    Public Sub New()
        MyBase.New()
        ' Add implementation.
    End Sub

    Public Sub New(ByVal message As String)
        MyBase.New(message)
        ' Add implementation.
    End Sub

    Public Sub New(ByVal message As String, ByVal inner As Exception)
        MyBase.New()
        ' Add implementation.
    End Sub

    ' This constructor is needed for serialization.
    Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
        MyBase.New(info, context)
        ' Add implementation.
    End Sub

End Class
