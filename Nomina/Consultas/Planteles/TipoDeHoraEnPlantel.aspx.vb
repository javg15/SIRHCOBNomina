Imports DataAccessLayer.COBAEV
Imports System.Data
Imports DataAccessLayer.COBAEV.Nominas
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.html
Imports iTextSharp.text.html.simpleparser
Imports System.IO
Imports DataAccessLayer.COBAEV.InformacionAcademica
Imports DataAccessLayer.COBAEV.Administracion

Partial Class Consulta_TipoDeHoraEnPlantel
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
    Private Sub BindgvTipoHora(pTipoHora As String)
        Dim oTipoHora As New Hora

        If pTipoHora <> "0" Then
            gvTipoHora.DataSource = oTipoHora.ObtenPorTipoHora(pTipoHora).Table
        Else
            gvTipoHora.EmptyDataText = "Sin información de tipo de hora"
        End If

        gvTipoHora.DataBind()
    End Sub
    Private Sub BindgvEmpleados()
        Dim oPlantel As New Plantel
        Dim dtEmpleados As DataTable
        Dim vlTipoHora As String
        Dim drQna As DataRow
        Dim oQna As New Quincenas
        Dim lblHoras2 As Label

        'If Request.Params("IdQuincena") Is Nothing Then
        drQna = oQna.ObtenQnaParaConsultaDeDatosDeCargaHoraria(CShort(Request.Params("IdSemestre")))
        lblInfRelQna.Text = "INFORMACIÓN RELACIONADA CON LA QUINCENA " + drQna("Quincena")
        dtEmpleados = oPlantel.ObtenEmpsPorTipoDeHora(CShort(Request.Params("IdPlantel")), CStr(Request.Params("TipoHora")), CShort(drQna("IdQuincena")))
        'Else
        'oQna.IdQuincena = CShort(Request.Params("IdQuincena"))
        'drQna = oQna.ObtenPorId(False).Rows(0)
        'lblInfRelQna.Text = "INFORMACIÓN RELACIONADA CON LA QUINCENA " + drQna("Quincena")
        'dtEmpleados = oPlantel.ObtenEmpsPorTipoDeHora(CShort(Request.Params("IdPlantel")), CStr(Request.Params("TipoHora")), CShort(Request.Params("IdQuincena")))
        'End If

        If dtEmpleados.Rows.Count > 0 Then
            vlTipoHora = CStr(Request.Params("TipoHora"))
            BindgvPlantel(CShort(Request.Params("IdPlantel")))
            BindgvTipoHora(vlTipoHora)
        Else
            BindgvPlantel(0)
            BindgvTipoHora("0")
        End If

        Me.gvEmpleados.DataSource = dtEmpleados
        Me.gvEmpleados.DataBind()
        If Me.gvEmpleados.Rows.Count > 0 Then
            lblHoras2 = CType(Me.gvEmpleados.FooterRow.FindControl("lblHoras2"), Label)
            lblHoras2.Text = dtEmpleados.Compute("Sum(Horas)", "")
        End If
    End Sub

    Protected Sub Page_Init(sender As Object, e As System.EventArgs) Handles Me.Init

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim oUsr As New Usuario
            Dim dt As DataTable
            dt = oUsr.ObtenPermisosSobreTabla(Session("Login"), "Materias")

            If Not CBool(dt.Rows(0).Item("Consulta")) Then Response.Redirect("~/SinPermiso.aspx")
            BindgvEmpleados()
        End If
    End Sub
    Protected Sub gvEmpleados_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvEmpleados.SelectedIndexChanged
    End Sub

    Protected Sub gvEmpleados_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvEmpleados.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                Dim lblIdGrupo As Label = CType(e.Row.FindControl("lblIdGrupo"), Label)
                Dim lblIdMateria As Label = CType(e.Row.FindControl("lblIdMateria"), Label)
                Dim lblGrupoAux As Label = CType(e.Row.FindControl("lblGrupoAux"), Label)
                Dim lbGrupo As LinkButton = CType(e.Row.FindControl("lbGrupo"), LinkButton)
                Dim lbClaveMateria As LinkButton = CType(e.Row.FindControl("lbClaveMateria"), LinkButton)

                lbGrupo.Visible = lbGrupo.Text <> "N/D"
                lblGrupoAux.Visible = lbGrupo.Text = "N/D"

                lbGrupo.OnClientClick = "javascript:abreVentanaImpresion('PlantelGrupo.aspx?IdPlantel=" + Request.Params("IdPlantel") + "&IdGrupo=" + lblIdGrupo.Text + "&IdSemestre=" + Request.Params("IdSemestre") + "','VentanaPlantel_" + Request.Params("IdPlantel") + "_Grupo'); return false;"
                lbClaveMateria.OnClientClick = "javascript:abreVentanaImpresion('MateriaEnPlantel.aspx?IdPlantel=" + Request.Params("IdPlantel") + "&IdMateria=" + lblIdMateria.Text + "&IdSemestre=" + Request.Params("IdSemestre") + "','VentanaPlantel_" + Request.Params("IdPlantel") + "_Materia'); return false;"

                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End Select
    End Sub

    Protected Sub btnExport_Click(sender As Object, e As System.EventArgs) Handles btnExport.Click
        gvEmpleados.Columns(0).Visible = False
        gvEmpleados.Columns(2).Visible = True
        gvEmpleados.Columns(3).Visible = False
        gvEmpleados.Columns(5).Visible = False

        Dim sb As StringBuilder = New StringBuilder()
        Dim sw As StringWriter = New StringWriter(sb)
        Dim htw As HtmlTextWriter = New HtmlTextWriter(sw)
        Dim pagina As Page = New Page
        Dim form = New HtmlForm
        gvPlantel.EnableViewState = False
        gvTipoHora.EnableViewState = False
        gvEmpleados.EnableViewState = False
        pagina.EnableEventValidation = False
        pagina.DesignerInitialize()
        pagina.Controls.Add(form)
        form.Controls.Add(gvPlantel)
        form.Controls.Add(gvTipoHora)
        form.Controls.Add(gvEmpleados)
        pagina.RenderControl(htw)
        Response.Clear()
        Response.Buffer = True
        Response.ContentType = "application/excel"
        Response.AddHeader("Content-Disposition", "attachment;filename=SinNombre.xls")
        Response.Charset = "UTF-8"

        Response.ContentEncoding = Encoding.Default
        Response.Write(sb.ToString())
        Response.End()
        'gvEmpleados.Columns(0).Visible = False
        'gvEmpleados.Columns(2).Visible = True
        'gvEmpleados.Columns(3).Visible = False
        'btnExport.Visible = False
        'btnExport0.Visible = False

        'Response.Clear()
        'Response.Buffer = True

        'Response.ContentType = "application/ms-excel"
        'Response.AddHeader("Content-disposition", "filename=PlantelTipoHoraEmps.xls")
        'Response.ContentEncoding = System.Text.Encoding.UTF8
        'Response.BinaryWrite(System.Text.Encoding.UTF8.GetPreamble())
        'Dim stringWriter As System.IO.StringWriter = New System.IO.StringWriter

        'Dim htmlTextWriter As HtmlTextWriter = New HtmlTextWriter(stringWriter)
        'RenderControl(htmlTextWriter)
        'Response.Write(stringWriter.ToString())
        'Response.End()

        'gvEmpleados.Columns(0).Visible = True
        'gvEmpleados.Columns(2).Visible = False
        'gvEmpleados.Columns(3).Visible = True
        'btnExport.Visible = True
        'btnExport0.Visible = False
    End Sub

    Protected Sub btnExport0_Click(sender As Object, e As System.EventArgs) Handles btnExport0.Click
        Dim sw As StringWriter = New StringWriter()
        Dim hw As HtmlTextWriter = New HtmlTextWriter(sw)
        Dim frm As HtmlForm = New HtmlForm()

        'gvMateria.HeaderStyle.ForeColor = Drawing.Color.Black
        'gvEmpleados.HeaderStyle.ForeColor = Drawing.Color.Black
        'gvEmpleados.Columns(0).Visible = False
        'gvEmpleados.Columns(2).Visible = True
        'gvEmpleados.Columns(3).Visible = False
        'btnExport.Visible = False
        'btnExport0.Visible = False

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

        'gvMateria.HeaderStyle.ForeColor = Drawing.Color.White
        'gvEmpleados.HeaderStyle.ForeColor = Drawing.Color.White
        'gvEmpleados.Columns(0).Visible = True
        'gvEmpleados.Columns(2).Visible = False
        'gvEmpleados.Columns(3).Visible = True
        'btnExport.Visible = True
        'btnExport0.Visible = True
    End Sub
End Class
