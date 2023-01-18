Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.Empleados
Imports System.Data
Imports DataAccessLayer.COBAEV.Administracion

Partial Class PenAlimBuscarBeneficiarios
    Inherits System.Web.UI.Page
    Protected Sub btnbuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnbuscar.Click
        If txtStrABuscar.Text.Trim <> String.Empty Then
            Dim oPenAlim As New BeneficiariosPensionAlimenticia
            Dim oUsr As New Usuario
            Dim dr As DataRow
            oUsr.Login = Session("Login")
            dr = oUsr.ObtenerPropiedadesDelRol().Rows(0)

            If ddlTipoBusqueda.SelectedValue.ToUpper = "2" Then 'Nombre
                gvEmpleados.DataSource = oPenAlim.BuscarBenefPenAlim(txtStrABuscar.Text.Trim.ToUpper, CByte(dr("IdRol")), CBool(dr("ConsultaZonasEspecificas")), CBool(dr("ConsultaPlantelesEspecificos")), Session("Login"))
            End If
            Me.gvEmpleados.DataBind()
            Me.gvEmpleados.SelectedIndex = -1
            lbltipobusqueda.Text = "Última búsqueda realizada por " + ddlTipoBusqueda.SelectedItem.Text.ToLower + ". Texto buscado: " + Me.txtStrABuscar.Text.Trim.ToUpper
        End If
    End Sub

    Protected Sub gvEmpleados_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvEmpleados.RowCommand
        Select Case e.CommandName
            Case "CmdRFCEmp"
                Session.Add("RFCParaCons", CType(gvEmpleados.Rows(e.CommandArgument).FindControl("LnkBtnRFCEmp"), LinkButton).Text)
                Session.Add("CURPParaCons", CType(gvEmpleados.Rows(e.CommandArgument).FindControl("lblCURPEmp"), Label).Text)
                Session.Add("ApePatParaCons", CType(gvEmpleados.Rows(e.CommandArgument).FindControl("lblApePatEmp"), Label).Text)
                Session.Add("ApeMatParaCons", CType(gvEmpleados.Rows(e.CommandArgument).FindControl("lblApeMatEmp"), Label).Text)
                Session.Add("NombreParaCons", CType(gvEmpleados.Rows(e.CommandArgument).FindControl("lblNombreEmp"), Label).Text)
                Session.Add("NumEmpParaCons", CType(gvEmpleados.Rows(e.CommandArgument).FindControl("lblNumEmp"), Label).Text)
        End Select
    End Sub

    Protected Sub gvEmpleados_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvEmpleados.RowDataBound
        Dim LnkBtn As LinkButton
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                LnkBtn = CType(e.Row.FindControl("LnkBtnRFCEmp"), LinkButton)
                LnkBtn.CommandArgument = e.Row.RowIndex.ToString
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                'e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvEmpleados, "Select$" + e.Row.RowIndex.ToString)
        End Select
    End Sub

    Protected Sub gvEmpleados_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvEmpleados.SelectedIndexChanged
        Dim lblNumEmp As Label = CType(gvEmpleados.SelectedRow.FindControl("lblNumEmp"), Label)

        'BindgvAnios(lblNumEmp.Text)
    End Sub

    Protected Sub ddlTipoBusqueda_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlTipoBusqueda.SelectedIndexChanged
        'txtStrABuscar.Text = String.Empty
    End Sub

    Protected Sub txtStrABuscar_TextChanged(sender As Object, e As System.EventArgs) Handles txtStrABuscar.TextChanged
        If txtStrABuscar.Text.Trim <> String.Empty Then
            btnbuscar_Click(sender, e)
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txtStrABuscar.Text = String.Empty
        End If
    End Sub
End Class