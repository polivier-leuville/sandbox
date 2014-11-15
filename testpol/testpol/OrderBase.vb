
Public MustInherit Class OrderBase
    Inherits ObjectBase

    Public Property OwneID As Guid
    Public Property ProductLines As New List(Of LineItems)
    Public Property Statut As StatutEnum

End Class
