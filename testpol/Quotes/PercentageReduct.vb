<Serializable()> _
Public Class PercentageReduct
    Inherits ReductBase

    Public Sub New(pValue As Double)

        MyBase.New(ReductEnum.Percentage, pValue)

    End Sub

    Public Overrides Function GetAmount(basePrice As Double) As Double

        If basePrice <= 0.0 Then Throw New Exception("La réduction ne s'applique pas sur une valeur <= 0 !")

        Return Math.Round(((basePrice * MyBase.Value) / 100.0), 2)

    End Function

End Class
