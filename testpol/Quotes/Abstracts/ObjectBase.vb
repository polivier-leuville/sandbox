Imports Newtonsoft.Json
Imports System.IO

<Serializable()> _
Public MustInherit Class ObjectBase

    Public Property Id As Guid
    Public Property Name As String
    Public Property Description As String
    Public Property CreatedDate As DateTime
    ''' <summary>
    ''' Constructeur
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        Id = System.Guid.NewGuid()
    End Sub
    ''' <summary>
    ''' Constructeur
    ''' </summary>
    ''' <param name="pName"></param>
    ''' <param name="pDescription"></param>
    ''' <remarks></remarks>
    Public Sub New(pName As String, pDescription As String)

        Id = System.Guid.NewGuid()
        Name = pName
        Description = pDescription

    End Sub
    ''' <summary>
    ''' Conversion de l'objet en JSON
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function toJSON() As String

        Return JsonConvert.SerializeObject(Me)

    End Function
    ''' <summary>
    ''' Conversion de l'objet en XML
    ''' </summary>
    ''' <param name="filename"></param>
    ''' <remarks></remarks>
    Public Sub toXMLFile(filename As String)

        Dim node As XNode = JsonConvert.DeserializeXNode(JsonConvert.SerializeObject(Me, Formatting.Indented), "Root")

        File.WriteAllText(filename, node.ToString())

    End Sub
    ''' <summary>
    ''' Conversion de l'objet en JSON puis sortie dans un fichier
    ''' </summary>
    ''' <param name="filename"></param>
    ''' <remarks></remarks>
    Public Sub toJSONFile(filename As String)

        File.WriteAllText(filename, JsonConvert.SerializeObject(Me, Formatting.Indented))

    End Sub

End Class
