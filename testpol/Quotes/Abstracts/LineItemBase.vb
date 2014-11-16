<Serializable()> _
Public MustInherit Class LineItemBase
    Inherits ObjectBase

    Public Property BasePrice As Double
    Public Property ArticleRef As String
    Public Property TypeTaxe As TaxeEnum
    Public Property Quantity As Integer
    Public Property Comment As String
    Public Property Reduction As ReductBase
    ''' <summary>
    ''' Constructeur
    ''' </summary>
    ''' <param name="pID"></param>
    ''' <param name="pPrice"></param>
    ''' <param name="pTaxe"></param>
    ''' <remarks></remarks>
    Public Sub New(pID As String, pPrice As Double, pTaxe As TaxeEnum)

        ArticleRef = pID
        BasePrice = pPrice
        TypeTaxe = pTaxe
        Quantity = 1
        Comment = String.Empty

    End Sub
    ''' <summary>
    ''' Constructeur
    ''' </summary>
    ''' <param name="pID"></param>
    ''' <param name="pPrice"></param>
    ''' <param name="pTaxe"></param>
    ''' <param name="qte"></param>
    ''' <remarks></remarks>
    Public Sub New(pID As String, pPrice As Double, pTaxe As TaxeEnum, qte As Integer)

        ArticleRef = pID
        BasePrice = pPrice
        TypeTaxe = pTaxe
        Quantity = qte
        Comment = String.Empty

    End Sub
    ''' <summary>
    ''' Constructeur
    ''' </summary>
    ''' <param name="pID"></param>
    ''' <param name="pPrice"></param>
    ''' <param name="pTaxe"></param>
    ''' <param name="qte"></param>
    ''' <param name="pTyReduct"></param>
    ''' <param name="pValueReduct"></param>
    ''' <remarks></remarks>
    Public Sub New(pID As String, pPrice As Double, pTaxe As TaxeEnum, qte As Integer, pTyReduct As ReductEnum, pValueReduct As Double)

        ArticleRef = pID
        BasePrice = pPrice
        TypeTaxe = pTaxe
        Quantity = qte
        Comment = String.Empty

    End Sub
    ''' <summary>
    ''' Calcul du prix - la remise
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetPrice() As Double

        If Not Reduction Is Nothing Then

            Return (BasePrice - Reduction.GetAmount(BasePrice))

        Else
            Return BasePrice
        End If

    End Function

End Class
