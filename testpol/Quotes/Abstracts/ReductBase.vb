<Serializable()> _
Public MustInherit Class ReductBase
    Inherits ObjectBase

    Public Property Type As ReductEnum
    Public Property Value As Double

    Public Sub New(pTypeReduct As ReductEnum, pValue As Double)

        Type = pTypeReduct
        Value = pValue

    End Sub

    Public Overridable Function GetAmount(basePrice As Double) As Double

        Return 0.0

    End Function

End Class
