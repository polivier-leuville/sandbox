
Public MustInherit Class LineItem
    Inherits ObjectBase

    Public Property UnitPrice As Double
    Public Property ArticleID As String
    Public Property Taxe As TaxeEnum

    Public Sub New()

    End Sub

    Public Sub New(pID As String, pPrice As Double, pTaxe As TaxeEnum)

        ArticleID = pID
        UnitPrice = pPrice
        Taxe = pTaxe

    End Sub

End Class
