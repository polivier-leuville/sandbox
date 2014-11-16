<Serializable()> _
Public MustInherit Class LineItem
    Inherits ObjectBase

    Public Property UnitPrice As Double
    Public Property ArticleID As String
    Public Property Taxe As TaxeEnum
    Public Property Quantity As Integer

    Public Sub New()

    End Sub

    Public Sub New(pID As String, pPrice As Double, pTaxe As TaxeEnum)

        ArticleID = pID
        UnitPrice = pPrice
        Taxe = pTaxe
        Quantity = 1

    End Sub


    Public Sub New(pID As String, pPrice As Double, pTaxe As TaxeEnum, qte As Integer)

        ArticleID = pID
        UnitPrice = pPrice
        Taxe = pTaxe
        Quantity = qte

    End Sub

End Class
