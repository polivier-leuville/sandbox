<Serializable()> _
Public MustInherit Class LineItem
    Inherits ObjectBase

    Public Property BasePrice As Double
    Public Property ArticleID As String
    Public Property Taxe As TaxeEnum
    Public Property Quantity As Integer
    Public Property Comment As String
    Public Property Reduction As ReductBase

    Public Sub New(pID As String, pPrice As Double, pTaxe As TaxeEnum)

        ArticleID = pID
        BasePrice = pPrice
        Taxe = pTaxe
        Quantity = 1
        Comment = String.Empty

    End Sub


    Public Sub New(pID As String, pPrice As Double, pTaxe As TaxeEnum, qte As Integer)

        ArticleID = pID
        BasePrice = pPrice
        Taxe = pTaxe
        Quantity = qte
        Comment = String.Empty

    End Sub


    Public Sub New(pID As String, pPrice As Double, pTaxe As TaxeEnum, qte As Integer, pTyReduct As ReductEnum, pValueReduct As Double)

        ArticleID = pID
        BasePrice = pPrice
        Taxe = pTaxe
        Quantity = qte
        Comment = String.Empty

    End Sub

    Public Function GetPrice() As Double

        If Not Reduction Is Nothing Then

            Return (BasePrice - Reduction.GetAmount(BasePrice))

        Else
            Return BasePrice
        End If

    End Function

End Class
