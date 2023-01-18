Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.Empleados
Imports System.Data
Imports DataAccessLayer.COBAEV.Administracion
Imports DataAccessLayer.COBAEV

Partial Class BusquedasVarias
    Inherits System.Web.UI.Page
    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, ByVal dt As DataTable, ByVal SelectedValue As String)
        ddl.DataSource = dt
        ddl.DataTextField = TextField
        ddl.DataValueField = ValueField
        ddl.DataBind()
        If SelectedValue Is Nothing = False Then ddl.SelectedValue = SelectedValue
    End Sub
    Protected Sub btnbuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnbuscar.Click
        If txtStrABuscar.Text.Trim <> String.Empty Then
            Dim oBusqueda As New Busquedas
            Dim oUsr As New Usuario
            Dim dr As DataRow
            oUsr.Login = Session("Login")
            dr = oUsr.ObtenerPropiedadesDelRol().Rows(0)

            gvResultadoBusqueda.DataSource = oBusqueda.RealiarPor(ddlTipoBusqueda.SelectedValue, txtStrABuscar.Text.Trim.ToUpper, CByte(dr("IdRol")), CBool(dr("ConsultaZonasEspecificas")), CBool(dr("ConsultaPlantelesEspecificos")), Session("Login"))
            gvResultadoBusqueda.DataBind()
            gvResultadoBusqueda.SelectedIndex = -1
            lbltipobusqueda.Text = "Última búsqueda realizada por " + ddlTipoBusqueda.SelectedItem.Text.ToLower + ". Texto buscado: " + Me.txtStrABuscar.Text.Trim.ToUpper
            If gvResultadoBusqueda.Rows.Count = 0 Then
                Select ddlTipoBusqueda.SelectedValue
                    Case "CtaBanc"
                        gvResultadoBusqueda.EmptyDataText = "No existen cuentas bancarias bajo ese criterio de búsqueda o no tiene permisos de visualización sobre ellas."
                    Case "ReciboFueraNom"
                        gvResultadoBusqueda.EmptyDataText = "No existen recibos fuera de nómina bajo ese criterio de búsqueda o no tiene permisos de visualización sobre ellos."
                    Case Else
                        gvResultadoBusqueda.EmptyDataText = "No existe información bajo ese criterio de búsqueda."
                End Select
                gvResultadoBusqueda.DataBind()
            End If
        End If
    End Sub

    Protected Sub gvEmpleados_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvResultadoBusqueda.RowCommand
        Select Case e.CommandName
            Case "CmdRFCEmp"
                Session.Add("RFCParaCons", CType(gvResultadoBusqueda.Rows(e.CommandArgument).FindControl("LnkBtnRFCEmp"), LinkButton).Text)
                Session.Add("CURPParaCons", CType(gvResultadoBusqueda.Rows(e.CommandArgument).FindControl("lblCURPEmp"), Label).Text)
                Session.Add("ApePatParaCons", CType(gvResultadoBusqueda.Rows(e.CommandArgument).FindControl("lblApePatEmp"), Label).Text)
                Session.Add("ApeMatParaCons", CType(gvResultadoBusqueda.Rows(e.CommandArgument).FindControl("lblApeMatEmp"), Label).Text)
                Session.Add("NombreParaCons", CType(gvResultadoBusqueda.Rows(e.CommandArgument).FindControl("lblNombreEmp"), Label).Text)
                Session.Add("NumEmpParaCons", CType(gvResultadoBusqueda.Rows(e.CommandArgument).FindControl("lblNumEmp"), Label).Text)
        End Select
    End Sub

    Protected Sub gvEmpleados_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvResultadoBusqueda.RowDataBound
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

    Protected Sub gvEmpleados_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvResultadoBusqueda.SelectedIndexChanged
        Dim lblNumEmp As Label = CType(gvResultadoBusqueda.SelectedRow.FindControl("lblNumEmp"), Label)

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
            Dim oBusqueda As New Busquedas

            LlenaDDL(ddlTipoBusqueda, "DescTipoBusqueda", "AbrevTipoBusqueda", oBusqueda.ObtenTipos(), Nothing)
            txtStrABuscar.Text = String.Empty
        End If
    End Sub
End Class