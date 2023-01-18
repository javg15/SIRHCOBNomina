Imports DataAccessLayer.COBAEV.Administracion
Imports System.Data
Imports DataAccessLayer.COBAEV.Empleados
Imports DataAccessLayer.COBAEV.InformacionAcademica
Imports DataAccessLayer.COBAEV
Partial Class PlantelesHistoriaRespAdmvosAcadem
    Inherits System.Web.UI.Page

    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, ByVal dt As DataTable, Optional ByVal SelectedValue As String = "")
        ddl.DataSource = dt
        ddl.DataTextField = TextField
        ddl.DataValueField = ValueField
        ddl.DataBind()
        If SelectedValue <> String.Empty Then ddl.SelectedValue = SelectedValue
        If dt.Rows.Count = 0 Then ddl.Items.Add(New ListItem("No hubo coincidencias", "-1"))
    End Sub

    Private Sub BindDatos()
        'Dim oUsr As New Usuario
        'Dim dtUsr As DataTable
        Dim oPlantel As New Plantel

        'oUsr.Login = Session("Login")
        'dtUsr = oUsr.ObtenerPropiedadesDelRol()

        Me.gvHistorico.DataSource = oPlantel.ObtenHistoriaRespAdmvosAcad(CShort(ddlPlanteles.SelectedValue), CByte(ddlFuncionSec.SelectedValue))
        Me.gvHistorico.DataBind()

        If gvHistorico.Rows.Count = 0 Then
            gvHistorico.EmptyDataText = "No existe historia registrada en el sistema."
            gvHistorico.DataBind()
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim oPlantel As New Plantel
            Dim oEmp As New Empleado

            LlenaDDL(ddlPlanteles, "DescPlantel", "IdPlantel", oPlantel.ObtenPlantelesPorUsr2(Session("Login"), True), Nothing)
            LlenaDDL(ddlFuncionSec, "FuncionSec2", "IdFuncionSec", oEmp.ObtenFuncionesSecundarias(True), Nothing)
            BindDatos()
        End If
    End Sub

    Protected Sub gvHistorico_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvHistorico.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                Dim LnkBtn As LinkButton

                LnkBtn = CType(e.Row.FindControl("LnkBtnRFC"), LinkButton)
                LnkBtn.CommandArgument = e.Row.RowIndex.ToString

                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvHistorico, "Select$" + e.Row.RowIndex.ToString)
        End Select
    End Sub
    Protected Sub gvHistorico_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvHistorico.RowCommand
        Select Case e.CommandName
            Case "CmdRFC"
                Session.Add("RFCParaCons", CType(gvHistorico.Rows(e.CommandArgument).FindControl("LnkBtnRFC"), LinkButton).Text)
                Session.Add("CURPParaCons", CType(gvHistorico.Rows(e.CommandArgument).FindControl("lblCURP"), Label).Text)
                Session.Add("ApePatParaCons", CType(gvHistorico.Rows(e.CommandArgument).FindControl("lblApePat"), Label).Text)
                Session.Add("ApeMatParaCons", CType(gvHistorico.Rows(e.CommandArgument).FindControl("lblApeMat"), Label).Text)
                Session.Add("NombreParaCons", CType(gvHistorico.Rows(e.CommandArgument).FindControl("lblNombre"), Label).Text)
                Session.Add("NumEmpParaCons", CType(gvHistorico.Rows(e.CommandArgument).FindControl("lblNumEmp"), Label).Text)
        End Select
    End Sub

    Protected Sub ddlFuncionSec_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlFuncionSec.SelectedIndexChanged
        BindDatos()
    End Sub

    Protected Sub ddlPlanteles_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlPlanteles.SelectedIndexChanged
        BindDatos()
    End Sub
End Class
