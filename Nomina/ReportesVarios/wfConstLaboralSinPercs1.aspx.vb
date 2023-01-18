Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.html
Imports iTextSharp.text.html.simpleparser
Imports System.IO

Partial Class ReportesVarios_wfConstLaboralSinPercs1
    Inherits System.Web.UI.Page

    Protected Sub btnExport1_Click(sender As Object, e As System.EventArgs) Handles btnExport1.Click
        btnExport1.Visible = False

        Image1.ImageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.IndexOf("Nomina")) + "Nomina/Imagenes/HeaderDocsOficiales.jpg"
        Image1.Height = System.Web.UI.WebControls.Unit.Parse("2.9464cm")
        Image1.Width = System.Web.UI.WebControls.Unit.Parse("2.1463cm")
        Image2.ImageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.IndexOf("Nomina")) + "Nomina/Imagenes/HeaderDocsOficiales2.jpg"
        Image2.Height = System.Web.UI.WebControls.Unit.Parse("2.16323cm")
        Image2.Width = System.Web.UI.WebControls.Unit.Parse("4.38997cm")

        Response.ContentType = "application/pdf"
        Response.AddHeader("content-disposition", "inline;filename=Export.pdf")
        Response.Cache.SetCacheability(HttpCacheability.NoCache)

        Dim sw As StringWriter = New StringWriter()
        Dim hw As HtmlTextWriter = New HtmlTextWriter(sw)
        Dim frm As HtmlForm = New HtmlForm()

        divExport.Parent.Controls.Add(frm)
        frm.Attributes("runat") = "server"

        frm.Controls.Add(divExport)
        frm.RenderControl(hw)

        Dim sr As StringReader = New StringReader(sw.ToString())
        Dim pdfDoc As Document = New Document(PageSize.LETTER, 10.0F, 10.0F, 10.0F, 10.0F)
        Dim htmlparser As HTMLWorker = New HTMLWorker(pdfDoc)
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream)

        pdfDoc.Open()
        htmlparser.Parse(sr)
        pdfDoc.Close()
        Response.Write(pdfDoc)
        Response.End()

        btnExport1.Visible = True
    End Sub
    Public Overrides Sub VerifyRenderingInServerForm(control As Control)
        'Verifies that the control is rendered
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Image1.ImageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.IndexOf("Nomina")) + "Nomina/Imagenes/HeaderDocsOficiales.jpg"
            Image1.Height = System.Web.UI.WebControls.Unit.Parse("2.9464cm")
            Image1.Width = System.Web.UI.WebControls.Unit.Parse("2.1463cm")
            Image2.ImageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.IndexOf("Nomina")) + "Nomina/Imagenes/HeaderDocsOficiales2.jpg"
            Image2.Height = System.Web.UI.WebControls.Unit.Parse("2.16323cm")
            Image2.Width = System.Web.UI.WebControls.Unit.Parse("4.38997cm")
        End If
    End Sub
End Class
