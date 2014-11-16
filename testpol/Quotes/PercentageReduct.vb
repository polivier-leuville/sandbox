<Serializable()> _
Public Class PercentageReduct
    Inherits ReductBase
    ''' <summary>
    ''' Constructeur minimal
    ''' </summary>
    ''' <param name="pValue"></param>
    ''' <remarks></remarks>
    Public Sub New(pValue As Double)

        MyBase.New(ReductEnum.Percentage, pValue)

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
    ''' Calcul du prix par rapport a une base fournie en paramètre
    ''' </summary>
    ''' <param name="basePrice"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function GetAmount(basePrice As Double) As Double

        If basePrice <= 0.0 Then Throw New Exception("La réduction ne s'applique pas sur une valeur <= 0 !")

        Return Math.Round(((basePrice * MyBase.Value) / 100.0), 2)

    End Function

End Class
