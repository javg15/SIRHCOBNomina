Imports DataAccessLayer.COBAEV.Administracion
Imports System.Data
Imports DataAccessLayer.COBAEV.Empleados
Partial Class InconsistenciasSobrePlazas
    Inherits System.Web.UI.Page
    Private Sub BindDatos()
        Dim oUsr As New Usuario
        Dim dtUsr As DataTable
        Dim oPlaza As New EmpleadoPlazas

        oUsr.Login = Session("Login")
        dtUsr = oUsr.ObtenerPropiedadesDelRol()

        Me.gvInconsistencias.DataSource = oPlaza.ObtenTodasLasObservaciones(dtUsr)
        Me.gvInconsistencias.DataBind()

        If gvInconsistencias.Rows.Count = 0 Then
            gvInconsistencias.EmptyDataText = "No se han detectado inconsistencias."
            gvInconsistencias.DataBind()
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.gvInconsistencias.EmptyDataText = "Haga click en el botón actualizar para generar un listado de inconsistencias basado en las plazas de los empleados"
            Me.gvInconsistencias.DataBind()
        End If
    End Sub

    Protected Sub gvInconsistencias_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvInconsistencias.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                Dim lblIdPlaza As Label = CType(e.Row.FindControl("lblIdPlaza"), Label)
                Dim ibWarning As ImageButton = CType(e.Row.FindControl("ibWarning"), ImageButton)
                Dim LnkBtn As LinkButton

                LnkBtn = CType(e.Row.FindControl("LnkBtnRFC"), LinkButton)
                LnkBtn.CommandArgument = e.Row.RowIndex.ToString

                ibWarning.OnClientClick = "javascript:abreVentMedAncha('ObservacionesSobrePlazas.aspx?TipoOperacion=4&IdPlaza=" + lblIdPlaza.Text + "'); return false;"

                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                'e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvInconsistencias, "Select$" + e.Row.RowIndex.ToString)
        End Select
    End Sub
    Protected Sub gvInconsistenciass_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvInconsistencias.RowCommand
        Select Case e.CommandName
            Case "CmdRFC"
                Session.Add("RFCParaCons", CType(gvInconsistencias.Rows(e.CommandArgument).FindControl("LnkBtnRFC"), LinkButton).Text)
                Session.Add("CURPParaCons", CType(gvInconsistencias.Rows(e.CommandArgument).FindControl("lblCURP"), Label).Text)
                Session.Add("ApePatParaCons", CType(gvInconsistencias.Rows(e.CommandArgument).FindControl("lblApePat"), Label).Text)
                Session.Add("ApeMatParaCons", CType(gvInconsistencias.Rows(e.CommandArgument).FindControl("lblApeMat"), Label).Text)
                Session.Add("NombreParaCons", CType(gvInconsistencias.Rows(e.CommandArgument).FindControl("lblNombre"), Label).Text)
                Session.Add("NumEmpParaCons", CType(gvInconsistencias.Rows(e.CommandArgument).FindControl("lblNumEmp"), Label).Text)
        End Select
    End Sub
    Protected Sub ibActualizar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibActualizar.Click
        BindDatos()
    End Sub

    Protected Sub lbVentanaInd_Click(sender As Object, e As System.EventArgs) Handles lbVentanaInd.Click
        Response.Redirect("../Empleados/DatosCOBAEV.aspx?TipoOperacion=4")
    End Sub

    Protected Sub gvInconsistencias_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvInconsistencias.SelectedIndexChanged

    End Sub
End Class
