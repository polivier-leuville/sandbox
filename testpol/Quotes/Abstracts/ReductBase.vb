<Serializable()> _
Public MustInherit Class ReductBase
    Inherits ObjectBase

    Public Property Type As ReductEnum
    Public Property Value As Double
    ''' <summary>
    ''' Constructeur
    ''' </summary>
    ''' <param name="pTypeReduct"></param>
    ''' <param name="pValue"></param>
    ''' <remarks></remarks>
    Public Sub New(pTypeReduct As ReductEnum, pValue As Double)

        MyBase.Name = String.Empty
        MyBase.Description = String.Empty
        Type = pTypeReduct
        Value = pValue

    End Sub
    ''' <summary>
    ''' Constructeur
    ''' </summary>
    ''' <param name="pName"></param>
    ''' <param name="pDescr"></param>
    ''' <param name="pTypeReduct"></param>
    ''' <param name="pValue"></param>
    ''' <remarks></remarks>
    Public Sub New(pName As String, pDescr As String, pTypeReduct As ReductEnum, pValue As Double)

        MyBase.Name = pName
        MyBase.Description = pDescr
        Type = pTypeReduct
        Value = pValue

    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="basePrice"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function GetAmount(basePrice As Double) As Double

        Return 0.0

    End Function

End Class
