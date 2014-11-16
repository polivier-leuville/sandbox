Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

<Serializable()> _
Public Class Order
    Inherits OrderBase

    Public Property SubscriptionDate As DateTime
    Public Property ValidationDate As DateTime
    Public Property ValidatorID As Guid
    Public Property Number As Integer
    Public Property Promos As new List(Of ReductBase)

    Public Sub New()

    End Sub

    Public Sub New(quote As Quote)
        MyBase.New()

        If quote.Statut >= StatutEnum.Ordered Then Throw New OrderException("Déjà commandée !")

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

        Throw New OrderException("Une commande ne peut être dupliquée !")

        Return Nothing
    End Function

    ''' <summary>
    ''' Calcul du TTC
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetPromos() As Double

        Dim totalPromos = 0.0

        For Each p In Promos

            totalPromos = totalPromos + p.GetAmount(GetGrandTotalWithoutPromo())

        Next

        Return Math.Round(totalPromos, 2)

    End Function


    ''' <summary>
    ''' Calcul du TTC
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetGrandTotal() As Double

        Return Math.Round(GetGrandTotalWithoutPromo() - GetPromos(), 2)

    End Function
End Class
