Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.Empleados
Imports System.Data
Imports DataAccessLayer.COBAEV.Administracion

Partial Class CompenBuscarEmps
    Inherits System.Web.UI.Page
    Private Sub BindgvAnios(pNumEmp As String)
        Dim oCompen As New Compensacion
        Dim oNomina As New Nomina

        gvAnios.DataSource = oCompen.BuscaAniosConCompensacionPorEmp(pNumEmp)
        gvAnios.DataBind()

        If gvAnios.Rows.Count = 0 Then
            gvAnios.EmptyDataText = "No existen empleados con compensación bajo ese criterio de búsqueda."
            gvAnios.DataBind()
        End If

        gvAnios.Visible = True
    End Sub

    Protected Sub btnbuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnbuscar.Click
        Dim oCompen As New Compensacion
        If ddlTipoBusqueda.SelectedValue.ToUpper = "2" Then 'Nombre
            Me.gvEmpleados.DataSource = oCompen.BuscarEmpleados(Empleado.TipoBusqueda.Nombre, String.Empty, Me.txtStrABuscar.Text.Trim.ToUpper, String.Empty)
        ElseIf ddlTipoBusqueda.SelectedValue.ToUpper = "1" Then   'RFC
            Me.gvEmpleados.DataSource = oCompen.BuscarEmpleados(Empleado.TipoBusqueda.RFC, Me.txtStrABuscar.Text.Trim.ToUpper, String.Empty, String.Empty)
        Else 'Número de empleado
            Me.gvEmpleados.DataSource = oCompen.BuscarEmpleados2(Empleado.TipoBusqueda.NumeroDeEmpleado, String.Empty, String.Empty, Me.txtStrABuscar.Text.Trim.ToUpper)
        End If
        Me.gvEmpleados.DataBind()
        Me.gvEmpleados.SelectedIndex = -1
        lbltipobusqueda.Text = "Última búsqueda realizada por " + ddlTipoBusqueda.SelectedItem.Text.ToLower + ". Texto buscado: " + Me.txtStrABuscar.Text.Trim.ToUpper
        Me.gvAnios.DataBind()
        Me.gvAnios.Visible = False
    End Sub

    Protected Sub gvEmpleados_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvEmpleados.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvEmpleados, "Select$" + e.Row.RowIndex.ToString)
        End Select
    End Sub

    Protected Sub gvEmpleados_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvEmpleados.SelectedIndexChanged
        Dim lblNumEmp As Label = CType(gvEmpleados.SelectedRow.FindControl("lblNumEmp"), Label)

        BindgvAnios(lblNumEmp.Text)
    End Sub

    Protected Sub ddlTipoBusqueda_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlTipoBusqueda.SelectedIndexChanged
        txtStrABuscar.Text = String.Empty
    End Sub

    Protected Sub gvAnios_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvAnios.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                Dim lblAnio As Label = CType(e.Row.FindControl("lblAnio"), Label)
                Dim ibDetalle As ImageButton = CType(e.Row.FindControl("ibDetalle"), ImageButton)
                Dim lblNumEmp As Label = CType(gvEmpleados.SelectedRow.FindControl("lblNumEmp"), Label)
                Dim lblOrigen As Label = CType(gvEmpleados.SelectedRow.FindControl("lblOrigen"), Label)

                ibDetalle.OnClientClick = "javascript:abreVentMedAncha('../../ABC/Compensaciones/CompeAcumuladaPorAnio.aspx?TipoOperacion=0&NumEmp=" + lblNumEmp.Text _
                                            + "&Origen=" + lblOrigen.Text + "&Anio=" + lblAnio.Text + "'); return false"
                ibDetalle.ToolTip = "Consultar el detalle de pagos recibidos durante " + lblAnio.Text

                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvAnios, "Select$" + e.Row.RowIndex.ToString)
        End Select
    End Sub
End Class