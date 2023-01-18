Imports DataAccessLayer.COBAEV.Empleados
Partial Class Consultas_Empleados_ConReduccionDeSueldo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim oEmp As New Empleado
            With Me.gvEmps
                .DataSource = oEmp.ConReduccionDeSdo()
                .DataBind()
            End With
        End If
    End Sub

    Protected Sub gvEmps_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvEmps.RowCommand
        Select Case e.CommandName
            Case "CmdRFC"
                Session.Add("RFCParaCons", CType(gvEmps.Rows(e.CommandArgument).FindControl("lbRFC"), LinkButton).Text)
                Session.Add("CURPParaCons", CType(gvEmps.Rows(e.CommandArgument).FindControl("lblCURP"), Label).Text)
                Session.Add("ApePatParaCons", CType(gvEmps.Rows(e.CommandArgument).FindControl("lblApePat"), Label).Text)
                Session.Add("ApeMatParaCons", CType(gvEmps.Rows(e.CommandArgument).FindControl("lblApeMat"), Label).Text)
                Session.Add("NombreParaCons", CType(gvEmps.Rows(e.CommandArgument).FindControl("lblNombre"), Label).Text)
                Session.Add("NumEmpParaCons", CType(gvEmps.Rows(e.CommandArgument).FindControl("lblNumEmp"), Label).Text)
        End Select
    End Sub

    Protected Sub gvEmps_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvEmps.RowDataBound
        Dim lbRFC As LinkButton
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                lbRFC = CType(e.Row.FindControl("lbRFC"), LinkButton)
                lbRFC.CommandArgument = e.Row.RowIndex.ToString
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvEmps, "Select$" + e.Row.RowIndex.ToString)
        End Select
    End Sub
End Class
