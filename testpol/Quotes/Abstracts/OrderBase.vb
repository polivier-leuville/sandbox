Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

<Serializable()> _
Public MustInherit Class OrderBase
    Inherits ObjectBase
    Implements ICloneable

    Public Property OwneID As Guid
    Public Property CustomerID As Guid
    Public Property ProductLines As New List(Of LineItemBase)
    Public Property Statut As StatutEnum

    ''' <summary>
    ''' Ajout d'un produit
    ''' </summary>
    ''' <param name="line"></param>
    ''' <remarks></remarks>
    Public Sub AddProduct(line As LineItemBase)
        ProductLines.Add(line)
    End Sub

    ''' <summary>
    ''' Calcul du pris hors taxe
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetHT() As Double

        Dim totalHT = 0.0

        For Each p In ProductLines

            totalHT += p.GetPrice()

        Next

        Return Math.Round(totalHT, 2)

    End Function

    ''' <summary>
    ''' Calcul de la TVA
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetTVA() As Double

        Dim totalTVA = 0.0

        For Each p In ProductLines

            totalTVA += (p.GetPrice() * p.TypeTaxe) / 100.0

        Next

        Return Math.Round(totalTVA, 2)

    End Function

    ''' <summary>
    ''' Calcul du TTC
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetGrandTotalWithoutPromo() As Double

        Dim totalTTC = 0.0

        For Each p In ProductLines

            totalTTC = totalTTC + (p.GetPrice() + ((p.GetPrice() * p.TypeTaxe) / 100.0))

        Next

        Return Math.Round(totalTTC, 2)

    End Function

    ''' <summary>
    ''' Duplicate
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function Clone() As Object Implements System.ICloneable.Clone
        Dim m As New MemoryStream()
        Dim f As New BinaryFormatter()
        f.Serialize(m, Me)
        m.Seek(0, SeekOrigin.Begin)
        Return f.Deserialize(m)
    End Function

End Class
