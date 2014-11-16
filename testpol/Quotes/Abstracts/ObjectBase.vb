Imports Newtonsoft.Json
Imports System.IO

<Serializable()> _
Public MustInherit Class ObjectBase

    Public Property Id As Guid
    Public Property Name As String
    Public Property Description As String
    Public Property CreatedDate As DateTime

    Public Sub New()
        Id = System.Guid.NewGuid()
    End Sub

    Public Sub New(pName As String, pDescription As String)

        Id = System.Guid.NewGuid()
        Name = pName
        Description = pDescription

    End Sub

    Public Function toJSON() As String

        Return JsonConvert.SerializeObject(Me)

    End Function

    Public Sub toXMLFile(filename As String)

        Dim node As XNode = JsonConvert.DeserializeXNode(JsonConvert.SerializeObject(Me, Formatting.Indented), "Root")

        File.WriteAllText(filename, node.ToString())

    End Sub
    Public Sub toJSONFile(filename As String)

        File.WriteAllText(filename, JsonConvert.SerializeObject(Me, Formatting.Indented))

    End Sub

End Class
