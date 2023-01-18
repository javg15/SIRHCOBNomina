Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.Empleados
Imports DataAccessLayer.COBAEV.Administracion
Imports System.Data
Partial Class Consultas_Nomina_Devoluciones
    Inherits System.Web.UI.Page
    Private Sub BindQnas()
        Dim oQna As New Quincenas
        Dim oUsr As New Usuario
        Dim dr As DataRow
        oUsr.Login = Session("Login")
        dr = oUsr.ObtenerPropiedadesDelRol().Rows(0)
        With Me.ddlQnas
            .DataSource = oQna.ObtenConDevoluciones(CByte(dr("IdRol")), CBool(dr("ConsultaZonasEspecificas")), CBool(dr("ConsultaPlantelesEspecificos")), Session("Login"))
            .DataTextField = "Quincena"
            .DataValueField = "IdQuincena"
            .DataBind()
            If .Items.Count = 0 Then
                .Items.Clear()
                .Items.Insert(0, "No hay quincenas disponibles para consulta.")
                .Items(0).Value = -1
                Me.btnConsultarQna.Enabled = False
            Else
                Me.btnConsultarQna.Enabled = True
                BindgvDevoluciones()
            End If
        End With
    End Sub
    Private Sub BindgvDevoluciones()
        Dim oEmp As New Empleado
        Dim oUsr As New Usuario
        Dim dr As DataRow
        oUsr.Login = Session("Login")
        dr = oUsr.ObtenerPropiedadesDelRol().Rows(0)
        With oEmp
            Me.gvDevoluciones.DataSource = .ConDevoluciones(CType(Me.ddlQnas.SelectedValue, Short), CByte(dr("IdRol")), CBool(dr("ConsultaZonasEspecificas")), CBool(dr("ConsultaPlantelesEspecificos")), Session("Login"))
            Me.gvDevoluciones.DataBind()
            Me.gvDevoluciones.Visible = True
        End With
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindQnas()
            Me.lbAgregarDevolucion.OnClientClick = "javascript:abreVentMedAncha('../../ABC/Nomina/AdmonDevoluciones.aspx?TipoOperacion=1'); return false;"
        End If
    End Sub

    Protected Sub btnConsultarQna_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultarQna.Click
        BindgvDevoluciones()
    End Sub

    Protected Sub gvDevoluciones_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvDevoluciones.RowCommand
        Select Case e.CommandName
            Case "CmdRFC"
                Session.Add("RFCParaCons", CType(Me.gvDevoluciones.Rows(e.CommandArgument).FindControl("lbRFC"), LinkButton).Text)
                Session.Add("CURPParaCons", CType(Me.gvDevoluciones.Rows(e.CommandArgument).FindControl("lblCURP"), Label).Text)
                Session.Add("ApePatParaCons", CType(Me.gvDevoluciones.Rows(e.CommandArgument).FindControl("lblApePat"), Label).Text)
                Session.Add("ApeMatParaCons", CType(Me.gvDevoluciones.Rows(e.CommandArgument).FindControl("lblApeMat"), Label).Text)
                Session.Add("NombreParaCons", CType(Me.gvDevoluciones.Rows(e.CommandArgument).FindControl("lblNombre"), Label).Text)
                Session.Add("NumEmpParaCons", CType(Me.gvDevoluciones.Rows(e.CommandArgument).FindControl("lblNumEmp"), Label).Text)
                Me.gvDevoluciones.SelectedIndex = CInt(e.CommandArgument)
            Case Else '"CmdEliminar", "CmdModificar"
                BindgvDevoluciones()
                If Me.gvDevoluciones.Rows.Count = 0 Then BindQnas()
        End Select
    End Sub

    Protected Sub gvDevoluciones_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvDevoluciones.RowDataBound
        Dim LnkBtn As LinkButton
        Dim ibModificar, ibEliminar As ImageButton
        Dim lblIdQnaAplicacion As Label
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                lblIdQnaAplicacion = CType(e.Row.FindControl("lblIdQnaAplicacion"), Label)
                LnkBtn = CType(e.Row.FindControl("lbRFC"), LinkButton)
                ibModificar = CType(e.Row.FindControl("ibModificar"), ImageButton)
                ibEliminar = CType(e.Row.FindControl("ibEliminar"), ImageButton)
                LnkBtn.CommandArgument = e.Row.RowIndex.ToString
                ibModificar.OnClientClick = "javascript:abreVentMedAncha('../../ABC/Nomina/AdmonDevoluciones.aspx?TipoOperacion=0&IdQnaAplicacion=" + lblIdQnaAplicacion.Text + "&RFC=" + LnkBtn.Text + "'); return false;"
                ibEliminar.OnClientClick = "javascript:abreVentMedAncha('../../ABC/Nomina/AdmonDevoluciones.aspx?TipoOperacion=3&IdQnaAplicacion=" + lblIdQnaAplicacion.Text + "&RFC=" + LnkBtn.Text + "'); return false;"
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvDevoluciones, "Select$" + e.Row.RowIndex.ToString)
        End Select
    End Sub

    Protected Sub lbAgregarDevolucion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbAgregarDevolucion.Click
        BindgvDevoluciones()
        If Me.gvDevoluciones.Rows.Count = 0 Then BindQnas()
    End Sub

    Protected Sub ibRefresh_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        BindQnas()
    End Sub
End Class
