Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

<Serializable()> _
Public Class Order
    Inherits OrderBase

    Public Property SubscriptionDate As DateTime
    Public Property ValidationDate As DateTime
    Public Property ValidatorID As Guid
    Public Property Number As Integer

    Public Sub New()

    End Sub

    Public Sub New(quote As Quote)
        MyBase.New()

        If quote.Statut >= StatutEnum.Ordered Then Throw New Exception("Déjà commandée !")

        MyBase.Name = quote.Name
        MyBase.ProductLines.AddRange(quote.ProductLines)
        MyBase.Statut = StatutEnum.Ordered
        MyBase.OwneID = quote.OwneID
        MyBase.CreatedDate = quote.CreatedDate

        SubscriptionDate = DateTime.Now()
        Number = 1

        quote.Statut = StatutEnum.Ordered

    End Sub


    Public Overrides Function Clone() As Object

        Throw New Exception("Une commande ne peut être dupliquée !")

        Return Nothing
    End Function


End Class
