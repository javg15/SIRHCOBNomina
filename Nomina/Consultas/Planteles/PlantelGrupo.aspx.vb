Imports DataAccessLayer.COBAEV
Imports System.Data
Imports DataAccessLayer.COBAEV.Nominas
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.html
Imports iTextSharp.text.html.simpleparser
Imports System.IO
Imports DataAccessLayer.COBAEV.Administracion

Partial Class Consulta_PlantelGrupo
    Inherits System.Web.UI.Page
    Private Sub BindgvPlantel(pIdPlantel As Short)
        Dim oPlantel As New Plantel

        If pIdPlantel <> 0 Then
            gvPlantel.DataSource = oPlantel.ObtenPorId(pIdPlantel)
        Else
            gvPlantel.EmptyDataText = "Sin información de plantel"
        End If

        gvPlantel.DataBind()
    End Sub
    Private Sub BindgvMaterias()
        Dim oPlantel As New Plantel
        Dim dtMaterias As DataTable
        Dim vlIdPlantel As Short
        Dim drQna As DataRow
        Dim oQna As New Quincenas
        Dim lblHoras2 As Label

        'If Request.Params("IdQuincena") Is Nothing Then
        drQna = oQna.ObtenQnaParaConsultaDeDatosDeCargaHoraria(CShort(Request.Params("IdSemestre")))
        lblInfRelQna.Text = "INFORMACIÓN RELACIONADA CON LA QUINCENA " + drQna("Quincena")
        dtMaterias = oPlantel.ObtenMaterias(CShort(Request.Params("IdPlantel")), CShort(Request.Params("IdGrupo")), CShort(drQna("IdQuincena")))
        'Else
        '    lblInfRelQna.Text = "INFORMACIÓN RELACIONADA CON LA QUINCENA X"
        '    dtMaterias = Nothing
        'End If

        If dtMaterias.Rows.Count > 0 Then
            vlIdPlantel = CShort(dtMaterias.Rows(0).Item("IdPlantel"))
            BindgvPlantel(vlIdPlantel)
        Else
            BindgvPlantel(0)
        End If

        Me.gvMaterias.DataSource = dtMaterias
        Me.gvMaterias.DataBind()
        If Me.gvMaterias.Rows.Count > 0 Then
            lblHoras2 = CType(Me.gvMaterias.FooterRow.FindControl("lblHoras2"), Label)
            lblHoras2.Text = dtMaterias.Compute("Sum(Horas)", "")
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim oUsr As New Usuario
            Dim dt As DataTable
            dt = oUsr.ObtenPermisosSobreTabla(Session("Login"), "Materias")

            If Not CBool(dt.Rows(0).Item("Consulta")) Then Response.Redirect("~/SinPermiso.aspx")

            BindgvMaterias()
        End If
    End Sub
    Protected Sub gvMaterias_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvMaterias.SelectedIndexChanged
    End Sub

    Protected Sub gvMaterias_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvMaterias.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                Dim lblIdMateria As Label = CType(e.Row.FindControl("lblIdMateria"), Label)
                Dim lbClaveMateria As LinkButton = CType(e.Row.FindControl("lbClaveMateria"), LinkButton)
                Dim lblIdPlantel As Label = CType(gvPlantel.Rows(0).FindControl("lblIdPlantel"), Label)

                lbClaveMateria.OnClientClick = "javascript:abreVentanaImpresion('MateriaEnPlantel.aspx?IdPlantel=" + lblIdPlantel.Text + "&IdMateria=" + lblIdMateria.Text + "&IdSemestre=" + Request.Params("IdSemestre") + "','VentanaPlantel_" + lblIdPlantel.Text + "_Materia'); return false;"

                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End Select
    End Sub

    Protected Sub btnExport_Click(sender As Object, e As System.EventArgs) Handles btnExport.Click
        gvMaterias.Columns(0).Visible = False
        'gvMaterias.Columns(2).Visible = True
        gvMaterias.Columns(3).Visible = False


        Dim sb As StringBuilder = New StringBuilder()
        Dim sw As StringWriter = New StringWriter(sb)
        Dim htw As HtmlTextWriter = New HtmlTextWriter(sw)
        Dim pagina As Page = New Page
        Dim form = New HtmlForm
        gvPlantel.EnableViewState = False
        gvMaterias.EnableViewState = False
        'gvEmpleados.EnableViewState = False
        pagina.EnableEventValidation = False
        pagina.DesignerInitialize()
        pagina.Controls.Add(form)
        form.Controls.Add(gvPlantel)
        form.Controls.Add(gvMaterias)
        'form.Controls.Add(gvEmpleados)
        pagina.RenderControl(htw)
        Response.Clear()
        Response.Buffer = True
        Response.ContentType = "application/excel"
        Response.AddHeader("Content-Disposition", "attachment;filename=SinNombre.xls")
        Response.Charset = "UTF-8"

        Response.ContentEncoding = Encoding.Default
        Response.Write(sb.ToString())
        Response.End()

        'btnExport.Visible = False
        'btnExport0.Visible = False

        'Response.Clear()
        'Response.Buffer = True

        'Response.ContentType = "application/ms-excel"
        'Response.AddHeader("Content-disposition", "filename=PlantelGrupoMaterias.xls")
        'Response.ContentEncoding = System.Text.Encoding.UTF8
        'Response.BinaryWrite(System.Text.Encoding.UTF8.GetPreamble())
        'Dim stringWriter As System.IO.StringWriter = New System.IO.StringWriter

        'Dim htmlTextWriter As HtmlTextWriter = New HtmlTextWriter(stringWriter)
        ''htmlTextWriter.

        'Me.RenderControl(htmlTextWriter)
        'Response.Write(stringWriter.ToString())
        'Response.End()

        'gvMaterias.Columns(0).Visible = True
        ''gvMaterias.Columns(2).Visible = False
        ''gvMaterias.Columns(3).Visible = True
        'btnExport.Visible = True
        'btnExport0.Visible = False
    End Sub

    Protected Sub btnExport0_Click(sender As Object, e As System.EventArgs) Handles btnExport0.Click
        Dim sw As StringWriter = New StringWriter()
        Dim hw As HtmlTextWriter = New HtmlTextWriter(sw)
        Dim frm As HtmlForm = New HtmlForm()

        gvPlantel.HeaderStyle.ForeColor = Drawing.Color.Black
        gvMaterias.HeaderStyle.ForeColor = Drawing.Color.Black
        gvMaterias.Columns(0).Visible = False
        gvMaterias.Columns(2).Visible = True
        gvMaterias.Columns(3).Visible = False
        btnExport.Visible = False
        btnExport0.Visible = False

        Response.ContentType = "application/pdf"
        Response.AddHeader("content-disposition", "attachment;filename=Export.pdf")
        Response.Cache.SetCacheability(HttpCacheability.NoCache)

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

        gvPlantel.HeaderStyle.ForeColor = Drawing.Color.White
        gvMaterias.HeaderStyle.ForeColor = Drawing.Color.White
        gvMaterias.Columns(0).Visible = True
        gvMaterias.Columns(2).Visible = False
        gvMaterias.Columns(3).Visible = True
        btnExport.Visible = True
        btnExport0.Visible = True
    End Sub
End Class
