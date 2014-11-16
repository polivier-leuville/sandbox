<Serializable()> _
Public Class AmountReduct
    Inherits ReductBase
    ''' <summary>
    ''' Constructeur
    ''' </summary>
    ''' <param name="pValue"></param>
    ''' <remarks></remarks>
    Public Sub New(pValue As Double)

        MyBase.New(ReductEnum.Amount, pValue)

    End Sub
    ''' <summary>
    ''' Constructeur
    ''' </summary>
    ''' <param name="pName"></param>
    ''' <param name="pDescr"></param>
    ''' <param name="pValue"></param>
    ''' <remarks></remarks>
    Public Sub New(pName As String, pDescr As String, pValue As Double)

        MyBase.New(pName, pDescr, ReductEnum.Percentage, pValue)

    End Sub
    ''' <summary>
    ''' Calcul de la réduction par rapport a un prix de base
    ''' EXIGENCE N° 1 : La réduction ne peut-etre supérieur au prix de bas
    ''' </summary>
    ''' <param name="basePrice"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function GetAmount(basePrice As Double) As Double

        If basePrice < MyBase.Value Then Throw New Exception("La réduction doit être inférieure au prix de base !")

        Return MyBase.Value

    End Function

End Class
