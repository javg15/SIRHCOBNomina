Imports DataAccessLayer.COBAEV
Imports DataAccessLayer.COBAEV.Administracion
Imports System.Data
Partial Class Administracion_EmpleadosPorCT
    Inherits System.Web.UI.Page
    Private Sub BindDatos()
        Dim oCT As New CentroDeTrabajo
        Dim oUsr As New Usuario
        Dim dr As DataRow
        oUsr.Login = Session("Login")
        dr = oUsr.ObtenerPropiedadesDelRol().Rows(0)

        oCT.IdCT = CShort(Request.Params("IdCT"))
        Me.gvCT.DataSource = oCT.ObtenPorId()
        Me.gvCT.DataBind()
        Me.gvEmpleados.DataSource = oCT.ObtenEmpleadosVigentes(CByte(dr("IdRol")), CBool(dr("ConsultaZonasEspecificas")), CBool(dr("ConsultaPlantelesEspecificos")), Session("Login"))
        Me.gvEmpleados.DataBind()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Response.Expires = 0
            BindDatos()
        End If
    End Sub

    Protected Sub gvEmpleados_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvEmpleados.RowDataBound
        Dim LnkBtn As LinkButton
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                LnkBtn = CType(e.Row.FindControl("LnkBtnRFC"), LinkButton)
                LnkBtn.CommandArgument = e.Row.RowIndex.ToString
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvEmpleados, "Select$" + e.Row.RowIndex.ToString)
        End Select
    End Sub
    Protected Sub gvEmpleados_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvEmpleados.RowCommand
        Select Case e.CommandName
            Case "CmdRFC"
                Session.Add("RFCParaCons", CType(gvEmpleados.Rows(e.CommandArgument).FindControl("LnkBtnRFC"), LinkButton).Text)
                Session.Add("CURPParaCons", CType(gvEmpleados.Rows(e.CommandArgument).FindControl("lblCURP"), Label).Text)
                Session.Add("ApePatParaCons", CType(gvEmpleados.Rows(e.CommandArgument).FindControl("lblApePat"), Label).Text)
                Session.Add("ApeMatParaCons", CType(gvEmpleados.Rows(e.CommandArgument).FindControl("lblApeMat"), Label).Text)
                Session.Add("NombreParaCons", CType(gvEmpleados.Rows(e.CommandArgument).FindControl("lblNombre"), Label).Text)
                Session.Add("NumEmpParaCons", CType(gvEmpleados.Rows(e.CommandArgument).FindControl("lblNumEmp"), Label).Text)
        End Select
    End Sub

End Class
