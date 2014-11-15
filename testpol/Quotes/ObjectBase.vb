
Public MustInherit Class ObjectBase

    Public Property Id As Guid
    Public Property Name As String
    Public Property Description As String
    Public Property CreatedDate As DateTime

    Public Sub New()
        Id = New Guid()
    End Sub

    Public Sub New(pName As String, pDescription As String)

        Id = New Guid()
        Name = pName
        Description = pDescription

    End Sub


End Class
