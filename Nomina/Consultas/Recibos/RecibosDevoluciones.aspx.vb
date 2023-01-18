Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.Administracion
Imports System.Data
Partial Class Consultas_RecibosDevoluciones
    Inherits System.Web.UI.Page
    Private Sub BindAnios()
        Dim oAnio As New Anios
        With Me.ddlAnios
            .DataSource = oAnio.ObtenParaConsultaDeRecibos()
            .DataTextField = "Anio"
            .DataValueField = "Anio"
            .DataBind()
            If .Items.Count = 0 Then
                .Items.Clear()
                .Items.Insert(0, "No hay años disponibles para consulta")
                .Items(0).Value = -1
            Else
                If Request.Params("Anio") Is Nothing = False Then
                    Try
                        ddlAnios.SelectedValue = Request.Params("Anio").ToString
                    Catch
                    End Try
                End If
                BindQnas()
            End If
        End With
    End Sub
    Private Sub BindQnas()
        Dim oRecibo As New Recibos
        With Me.ddlQuincenas
            .DataSource = oRecibo.ObtenQnasPorAnioParaConsulta(CShort(Me.ddlAnios.SelectedValue))
            .DataTextField = "Quincena"
            .DataValueField = "IdQuincena"
            .DataBind()
            If .Items.Count = 0 Or Me.ddlAnios.SelectedValue = "-1" Then
                .Items.Clear()
                .Items.Insert(0, "No hay quincenas disponibles para consulta")
                .Items(0).Value = -1
                Me.btnConsultarAnio.Enabled = False
            Else
                If Request.Params("IdQuincena") Is Nothing = False Then
                    Try
                        ddlQuincenas.SelectedValue = Request.Params("IdQuincena").ToString
                    Catch
                    End Try
                End If
                Me.btnConsultarAnio.Enabled = True
            End If
            BindgvRecibos()
        End With
    End Sub
    Private Sub BindgvRecibos()
        Dim oRecibo As New Recibos
        Dim oUsr As New Usuario
        Dim dr As DataRow
        oUsr.Login = Session("Login")
        dr = oUsr.ObtenerPropiedadesDelRol().Rows(0)
        With oRecibo
            If Me.ddlAnios.SelectedValue <> -1 Then
                Me.gvRecibos.DataSource = .ObtenRecibosPorAnio(CShort(Me.ddlAnios.SelectedValue), CShort(Me.ddlQuincenas.SelectedValue), _
                                            CByte(dr("IdRol")), CBool(dr("ConsultaZonasEspecificas")), CBool(dr("ConsultaPlantelesEspecificos")), Session("Login"))
            End If
            Me.gvRecibos.DataBind()
        End With
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindAnios()
        End If
    End Sub

    Protected Sub btnConsultarAnio_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        BindgvRecibos()
    End Sub
    Protected Sub ibRefresh_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        BindAnios()
    End Sub

    Protected Sub gvRecibos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs)
        Select Case e.CommandName
            Case "CmdRFC"
                Session.Add("RFCParaCons", CType(Me.gvRecibos.Rows(e.CommandArgument).FindControl("lbRFC"), LinkButton).Text)
                Session.Add("CURPParaCons", CType(Me.gvRecibos.Rows(e.CommandArgument).FindControl("lblCURP"), Label).Text)
                Session.Add("ApePatParaCons", CType(Me.gvRecibos.Rows(e.CommandArgument).FindControl("lblApePat"), Label).Text)
                Session.Add("ApeMatParaCons", CType(Me.gvRecibos.Rows(e.CommandArgument).FindControl("lblApeMat"), Label).Text)
                Session.Add("NombreParaCons", CType(Me.gvRecibos.Rows(e.CommandArgument).FindControl("lblNombre"), Label).Text)
                Session.Add("NumEmpParaCons", CType(Me.gvRecibos.Rows(e.CommandArgument).FindControl("lblNumEmp"), Label).Text)
                Me.gvRecibos.SelectedIndex = CInt(e.CommandArgument)
            Case Else '"CmdEliminar", "CmdModificar"
                BindgvRecibos()
                If Me.gvRecibos.Rows.Count = 0 Then BindAnios()
        End Select
    End Sub

    Protected Sub gvRecibos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        Dim oUsr As New Usuario
        Dim dr As DataRow
        Dim ibConsultaDetalles As ImageButton
        Dim lblIdRecibo, lblIdUsuario, lblUsuario As Label
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                lblIdRecibo = CType(e.Row.FindControl("lblIdRecibo"), Label)
                lblIdUsuario = CType(e.Row.FindControl("lblIdUsuario"), Label)
                lblUsuario = CType(e.Row.FindControl("lblUsuario"), Label)
                oUsr.IdUsuario = CShort(lblIdUsuario.Text)
                dr = oUsr.ObtenerPorId()
                lblUsuario.Text = dr("Login")
                lblUsuario.ToolTip = dr("ApellidoPaterno").ToString.Trim + " " + dr("ApellidoMaterno").ToString.Trim + " " + dr("Nombre").ToString.Trim
                ibConsultaDetalles = CType(e.Row.FindControl("ibConsultaDetalles"), ImageButton)
                'ibConsultaDetalles.OnClientClick = "javascript:abreVentanaImpresion('../../ABC/Recibos/AdmonDetallesRecibos.aspx?TipoOperacion=4&IdRecibo=" + lblIdRecibo.Text + "&Devolucion=SI','Recibo" + lblIdRecibo.Text + "');"
                ibConsultaDetalles.PostBackUrl = "../../ABC/Recibos/AdmonDetallesRecibos.aspx?TipoOperacion=4&IdRecibo=" + lblIdRecibo.Text + "&Devolucion=SI" + "&Anio=" + ddlAnios.SelectedValue + "&IdQuincena=" + ddlQuincenas.SelectedValue
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvRecibos, "Select$" + e.Row.RowIndex.ToString)
        End Select
    End Sub
    Protected Sub lbCrearRecibo_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.gvRecibos.Rows.Count = 0 Then BindAnios()
        BindgvRecibos()
    End Sub

    'Protected Sub gvRecibos_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvRecibos.PageIndexChanging
    '    Me.gvRecibos.PageIndex = e.NewPageIndex
    '    BindgvRecibos()
    'End Sub

    Protected Sub ddlAnios_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        BindQnas()
    End Sub
End Class
