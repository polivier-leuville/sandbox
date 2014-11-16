Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports Newtonsoft.Json

<Serializable()> _
Public Class Quote
    Inherits OrderBase
    Implements ICloneable

    Public Property ProposalDate As DateTime

    Public Overrides Function Clone() As Object
        Dim m As New MemoryStream()
        Dim f As New BinaryFormatter()

        f.Serialize(m, Me)
        m.Seek(0, SeekOrigin.Begin)

        Dim newQuote As Quote = f.Deserialize(m)
        newQuote.Id = System.Guid.NewGuid()
        newQuote.CreatedDate = DateTime.Now()

        Return newQuote
    End Function

    Public Shared Function LoadFrom(jsonStr As String) As Quote

        Return JsonConvert.DeserializeObject(Of Quote)(jsonStr)

    End Function

End Class
