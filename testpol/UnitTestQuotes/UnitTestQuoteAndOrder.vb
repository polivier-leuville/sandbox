Imports System.Text
Imports System.IO
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Quotes

<TestClass()> Public Class UnitTestQuoteAndOrder

    Private Function CreateQuote() As Quote
        Dim propale As New Quote()

        Dim p = New ProductLineItem("ART001", 10.0, TaxeEnum.Normal)

        propale.AddProduct(New ProductLineItem("ART001", 100.0, TaxeEnum.Normal))
        propale.AddProduct(New ServiceLineItem("SRV001", 9.99, TaxeEnum.Reduite))
        propale.AddProduct(New ServiceLineItem("SRV001", 0.0, TaxeEnum.None))

        Return propale

    End Function

    <TestMethod()> Public Sub CreateEmptyQuote()

        Dim propale As New Quote()
        Assert.IsNotNull(propale, "Instance de la proposition non crée!")
        Assert.AreNotEqual(String.Empty, propale.Id)

    End Sub

    <TestMethod()> Public Sub DeleteProductLinesFromQuote()

        Dim q As New Quote()
        Assert.AreEqual(q.ProductLines.Count, 0)
        q.ProductLines.Add(New ProductLineItem())
        Assert.AreEqual(q.ProductLines.Count, 1)
        q.ProductLines.Clear()
        Assert.AreEqual(q.ProductLines.Count, 0)

    End Sub

    <TestMethod()> Public Sub CreateQuoteWithProductLines()

        Dim propale = CreateQuote()
        Dim amount As Double

        Assert.AreEqual(propale.ProductLines.Count, 3)

        amount = propale.GetHT()
        Assert.AreEqual(amount, 109.99)

        amount = propale.GetTVA()
        Assert.AreEqual(amount, 20.999)

        amount = propale.GetTTC()
        Assert.AreEqual(amount, 130.989)


    End Sub


    <TestMethod()> Public Sub CreateOrderFromQuote()

        Dim propale = CreateQuote()
        Dim amount As Double

        Dim cde = New Order(propale)

        amount = cde.GetHT()
        Assert.AreEqual(amount, 109.99)

        amount = cde.GetTVA()
        Assert.AreEqual(amount, 20.999)

        amount = cde.GetTTC()
        Assert.AreEqual(amount, 130.989)


    End Sub


    <TestMethod()> Public Sub InvalidQuoteReuseAfterCreatingOrder()

        Dim propale = CreateQuote()

        Dim cde1 = New Order(propale)
        Try
            Dim cde2 = New Order(propale)
            Assert.Fail("Problème, manque l'exception")

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

    End Sub


    <TestMethod()> Public Sub InvalidDuplicateOrder()

        Dim propale = CreateQuote()

        Try
            Dim cde As Order = New Order(propale)
            Dim cde2 As Order = cde.Clone()
            Assert.Fail("Problème, manque l'exception")

        Catch ex As Exception

        End Try

    End Sub
    <TestMethod()> Public Sub AllowDuplicateQuote()

        Dim propale = CreateQuote()
        Dim duplicatePropale As Quote = propale.Clone()

        Assert.AreNotEqual(propale.Id, duplicatePropale.Id)
        Assert.AreEqual(propale.GetTTC(), duplicatePropale.GetTTC())

    End Sub

    <TestMethod()> Public Sub JSONMemorySerializeQuote()

        Dim propale = CreateQuote()

        Dim s = propale.toJSON()

        Assert.IsNotNull(s)

    End Sub

    <TestMethod()> Public Sub QuoteAndOrderSerializeToXMLTextFile()

        Dim propale = CreateQuote()

        propale.toXMLFile("D:\propale.xml")
        Assert.IsTrue(File.Exists("D:\propale.xml"))

        Dim commande = New Order(propale)
        commande.toXMLFile("D:\commande.xml")
        Assert.IsTrue(File.Exists("D:\commande.xml"))

    End Sub

    <TestMethod()> Public Sub QuoteAndOrderSerializeToJSONTextFile()

        Dim propale = CreateQuote()

        propale.toJSONFile("D:\propale.json")
        Assert.IsTrue(File.Exists("D:\propale.json"))

        Dim commande = New Order(propale)
        commande.toJSONFile("D:\commande.json")
        Assert.IsTrue(File.Exists("D:\commande.json"))

    End Sub

End Class