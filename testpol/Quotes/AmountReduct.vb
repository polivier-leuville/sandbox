<Serializable()> _
Public Class AmountReduct
    Inherits ReductBase

    Public Sub New(pValue As Double)

        MyBase.New(ReductEnum.Amount, pValue)

    End Sub
    Public Overrides Function GetAmount(basePrice As Double) As Double

        If basePrice < MyBase.Value Then Throw New Exception("La réduction doit être inférieure au prix de base !")

        Return MyBase.Value

    End Function

End Class
