Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.Empleados
Imports System.Data
Imports DataAccessLayer.COBAEV.Administracion

Partial Class CompenHistoriaPlazas
    Inherits System.Web.UI.Page
    Private Sub BindgvPlazas(pNumEmp As String)
        Dim oCompen As New Compensacion
        Dim oNomina As New Nomina

        gvPlazas.DataSource = oCompen.BuscaPlazasPorEmp(pNumEmp)
        gvPlazas.DataBind()

        If gvPlazas.Rows.Count = 0 Then
            If oNomina.ValidaSimEmpTienePlazaVigente(pNumEmp) = True Then
                gvPlazas.EmptyDataText = "El empleado seleccionado tiene plaza vigente en Nómina."
            Else
                gvPlazas.EmptyDataText = "No hay información de nomobramientos para el empleado seleccionado."
            End If
            gvPlazas.DataBind()
        End If

        gvPlazas.Visible = True

        ConfiguraPermisos(pNumEmp)
    End Sub
    Private Sub ConfiguraPermisos(pNumEmp As String)
        Dim oUsr As New Usuario
        Dim dt As DataTable
        Dim oCompen As New Compensacion
        Dim oNomina As New Nomina

        dt = oUsr.ObtenPermisosSobreTabla(Session("Login"), "EmpsSoloCompenPlazas")

        lblAdvertencia.Text = "El empleado actualmente cubre una plaza en nómina, "
        lblAdvertencia.Visible = oNomina.ValidaSimEmpTienePlazaVigente(pNumEmp) = True And _
                                oCompen.ValidaSimEmpTienePlazaVigente(pNumEmp) = False And _
                                CBool(dt.Rows(0).Item("Insercion")) = True

        If lblAdvertencia.Visible = True Then
            lbAddPlaza.Text = "¿Agregar nombramiento en Compensación?"
        Else
            lbAddPlaza.Text = "Agregar nombramiento"
        End If

        lbAddPlaza.Visible = CBool(dt.Rows(0).Item("Insercion")) And _
                            oCompen.ValidaSimEmpTienePlazaVigente(pNumEmp) = False 'And _
        'oNomina.ValidaSimEmpTienePlazaVigente(pNumEmp) = False

        Me.gvPlazas.Columns(13).Visible = CBool(dt.Rows(0).Item("Actualizacion"))
        Me.gvPlazas.Columns(14).Visible = CBool(dt.Rows(0).Item("Eliminacion"))
    End Sub
    Protected Sub btnbuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnbuscar.Click
        Dim oCompen As New Compensacion
        If ddlTipoBusqueda.SelectedValue.ToUpper = "2" Then 'Nombre
            Me.gvEmpleados.DataSource = oCompen.BuscarEmpleados(Empleado.TipoBusqueda.Nombre, String.Empty, Me.txtStrABuscar.Text.Trim.ToUpper, String.Empty)
        ElseIf ddlTipoBusqueda.SelectedValue.ToUpper = "1" Then   'RFC
            Me.gvEmpleados.DataSource = oCompen.BuscarEmpleados(Empleado.TipoBusqueda.RFC, Me.txtStrABuscar.Text.Trim.ToUpper, String.Empty, String.Empty)
        Else 'Número de empleado
            Me.gvEmpleados.DataSource = oCompen.BuscarEmpleados(Empleado.TipoBusqueda.NumeroDeEmpleado, String.Empty, String.Empty, Me.txtStrABuscar.Text.Trim.ToUpper)
        End If
        Me.gvEmpleados.DataBind()
        Me.gvEmpleados.SelectedIndex = -1
        lbltipobusqueda.Text = "Última búsqueda realizada por " + ddlTipoBusqueda.SelectedItem.Text.ToLower + ". Texto buscado: " + Me.txtStrABuscar.Text.Trim.ToUpper
        lblAdvertencia.Visible = False
        lbAddPlaza.Visible = False
        Me.gvPlazas.DataBind()
        Me.gvPlazas.Visible = False
    End Sub

    Protected Sub gvEmpleados_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvEmpleados.SelectedIndexChanged
        Dim lblNumEmp As Label = CType(gvEmpleados.SelectedRow.FindControl("lblNumEmp"), Label)
        Dim oCompen As New Compensacion
        Dim oNomina As New Nomina
        Dim vlEmpTienePlazaVigEnNomina As String

        vlEmpTienePlazaVigEnNomina = "NO"
        If oNomina.ValidaSimEmpTienePlazaVigente(lblNumEmp.Text) = True Then vlEmpTienePlazaVigEnNomina = "SI"

        lbAddPlaza.OnClientClick = "javascript:abreVentanaMediana('../../ABC/Compensaciones/AdmonCompenPlazas.aspx?TipoOperacion=1&NumEmp=" + lblNumEmp.Text + "&EmpTienePlazaVigEnNomina=" + vlEmpTienePlazaVigEnNomina + "');"

        BindgvPlazas(lblNumEmp.Text)
    End Sub

    Protected Sub ddlTipoBusqueda_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlTipoBusqueda.SelectedIndexChanged
        txtStrABuscar.Text = String.Empty
    End Sub

    Protected Sub gvPlazas_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvPlazas.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                Dim lblIdPlaza As Label = CType(e.Row.FindControl("lblIdPlaza"), Label)
                Dim ibModify As ImageButton = CType(e.Row.FindControl("ibModify"), ImageButton)
                Dim ibDelete As ImageButton = CType(e.Row.FindControl("ibDelete"), ImageButton)

                ibModify.OnClientClick = "javascript:abreVentanaMediana('../../ABC/Compensaciones/AdmonCompenPlazas.aspx?TipoOperacion=0&IdPlaza=" + lblIdPlaza.Text + "');"
                ibDelete.OnClientClick = "javascript:abreVentanaMediana('../../ABC/Compensaciones/AdmonCompenPlazas.aspx?TipoOperacion=3&IdPlaza=" + lblIdPlaza.Text + "');"

                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvPlazas, "Select$" + e.Row.RowIndex.ToString)
        End Select
    End Sub
    Protected Sub lbAddPlaza_Click(sender As Object, e As System.EventArgs) Handles lbAddPlaza.Click
        Dim lblNumEmp As Label = CType(gvEmpleados.SelectedRow.FindControl("lblNumEmp"), Label)

        BindgvPlazas(lblNumEmp.Text)
    End Sub

    Protected Sub ibModify_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs)
        Dim gvr As GridViewRow = CType(sender, ImageButton).DataItemContainer
        Dim lblNumEmp As Label = CType(gvEmpleados.Rows(gvr.DataItemIndex).FindControl("lblNumEmp"), Label)

        BindgvPlazas(lblNumEmp.Text)
    End Sub

    Protected Sub ibDelete_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs)
        Dim gvr As GridViewRow = CType(sender, ImageButton).DataItemContainer
        Dim lblNumEmp As Label = CType(gvEmpleados.Rows(gvr.DataItemIndex).FindControl("lblNumEmp"), Label)

        BindgvPlazas(lblNumEmp.Text)
    End Sub
End Class