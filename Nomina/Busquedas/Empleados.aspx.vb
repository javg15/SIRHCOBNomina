Imports DataAccessLayer.COBAEV.Empleados
Imports System.Data
Imports DataAccessLayer.COBAEV.Administracion
Partial Class Empleados
    Inherits System.Web.UI.Page
    Private Sub BuscarEmpleado()
        Dim oEmp As New Empleado
        Dim oUsr As New Usuario
        Dim dr As DataRow
        oUsr.Login = Session("Login")
        dr = oUsr.ObtenerPropiedadesDelRol().Rows(0)
        If Request.Params("LlamadoDesde") = "AdministracionCargaHoraria" Or Request.Params("LlamadoDesde") = "AdministracionPlazas" Then
            If ddltipobusqueda.SelectedValue.ToUpper = "NOMBRE" Then
                oEmp.NomEmp = txtbxtextoabuscar.Text.Trim.ToUpper
                Me.gvEmpleados.DataSource = oEmp.Buscar(Empleado.TipoBusqueda.Nombre, CByte(dr("IdRol")), CBool(dr("ConsultaZonasEspecificas")), CBool(dr("ConsultaPlantelesEspecificos")), Session("Login"), True)
            ElseIf ddltipobusqueda.SelectedValue.ToUpper = "RFC" Then   'RFC
                oEmp.RFC = txtbxtextoabuscar.Text.Trim.ToUpper
                Me.gvEmpleados.DataSource = oEmp.Buscar(Empleado.TipoBusqueda.RFC, CByte(dr("IdRol")), CBool(dr("ConsultaZonasEspecificas")), CBool(dr("ConsultaPlantelesEspecificos")), Session("Login"), True)
            Else 'Número de empleado
                oEmp.NumEmp = txtbxtextoabuscar.Text.Trim
                Me.gvEmpleados.DataSource = oEmp.Buscar(Empleado.TipoBusqueda.NumeroDeEmpleado, CByte(dr("IdRol")), CBool(dr("ConsultaZonasEspecificas")), CBool(dr("ConsultaPlantelesEspecificos")), Session("Login"), True)
            End If
        Else
            If ddltipobusqueda.SelectedValue.ToUpper = "NOMBRE" Then
                oEmp.NomEmp = txtbxtextoabuscar.Text.Trim.ToUpper
                Me.gvEmpleados.DataSource = oEmp.Buscar(Empleado.TipoBusqueda.Nombre, CByte(dr("IdRol")), CBool(dr("ConsultaZonasEspecificas")), CBool(dr("ConsultaPlantelesEspecificos")), Session("Login"))
            ElseIf ddltipobusqueda.SelectedValue.ToUpper = "RFC" Then   'RFC
                oEmp.RFC = txtbxtextoabuscar.Text.Trim.ToUpper
                Me.gvEmpleados.DataSource = oEmp.Buscar(Empleado.TipoBusqueda.RFC, CByte(dr("IdRol")), CBool(dr("ConsultaZonasEspecificas")), CBool(dr("ConsultaPlantelesEspecificos")), Session("Login"))
            Else 'Número de empleado
                oEmp.NumEmp = txtbxtextoabuscar.Text.Trim
                Me.gvEmpleados.DataSource = oEmp.Buscar(Empleado.TipoBusqueda.NumeroDeEmpleado, CByte(dr("IdRol")), CBool(dr("ConsultaZonasEspecificas")), CBool(dr("ConsultaPlantelesEspecificos")), Session("Login"))
            End If
        End If
        Me.gvEmpleados.DataBind()
        Me.gvEmpleados.SelectedIndex = -1
        lbltipobusqueda.Text = "Última búsqueda realizada por " + ddltipobusqueda.SelectedItem.Text.ToLower + ". Texto buscado: " + txtbxtextoabuscar.Text.Trim.ToUpper
    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        If Not IsPostBack Then
            rfvtextoabuscar.ErrorMessage = "Olvidó escribir el " + ddltipobusqueda.SelectedItem.Text.ToLower + " a buscar"
            txtbxtextoabuscar.MaxLength = 5
        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbuscar.Click
        Try
            BuscarEmpleado()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ddlTipoBusqueda_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddltipobusqueda.SelectedIndexChanged
        txtbxtextoabuscar.Text = String.Empty
        If ddltipobusqueda.SelectedValue.ToUpper = "NOMBRE" Then
            txtbxtextoabuscar.MaxLength = 90
            Me.TxtBxWtrMrkExtNombre.Enabled = True
            Me.TxtBxWtrMrkExtRFC.Enabled = False
            Me.TxtBxWtrMrkExtNumEmp.Enabled = False
        ElseIf ddltipobusqueda.SelectedValue.ToUpper = "RFC" Then 'RFC
            txtbxtextoabuscar.MaxLength = 13
            Me.TxtBxWtrMrkExtNombre.Enabled = False
            Me.TxtBxWtrMrkExtRFC.Enabled = True
            Me.TxtBxWtrMrkExtNumEmp.Enabled = False
        Else
            txtbxtextoabuscar.MaxLength = 5
            Me.TxtBxWtrMrkExtNombre.Enabled = False
            Me.TxtBxWtrMrkExtRFC.Enabled = False
            Me.TxtBxWtrMrkExtNumEmp.Enabled = True
        End If
        rfvtextoabuscar.ErrorMessage = "Olvidó escribir el " + ddltipobusqueda.SelectedItem.Text.ToLower + " a buscar"
    End Sub

    Protected Sub gvEmpleados_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvEmpleados.RowCommand
        Select Case e.CommandName
            Case "CmdRFC", "Select"
                If Request.Params("LlamadoDesde") = "AdministracionCargaHoraria" Or Request.Params("LlamadoDesde") = "AdministracionPlazas" Then
                    If Me.chbxGuardaEmp.Checked Then
                        Session.Add("RFCParaCons2", CType(gvEmpleados.Rows(e.CommandArgument).FindControl("LnkBtnRFC"), LinkButton).Text)
                        Session.Add("CURPParaCons2", CType(gvEmpleados.Rows(e.CommandArgument).FindControl("lblCURP"), Label).Text)
                        Session.Add("ApePatParaCons2", CType(gvEmpleados.Rows(e.CommandArgument).FindControl("lblApePat"), Label).Text)
                        Session.Add("ApeMatParaCons2", CType(gvEmpleados.Rows(e.CommandArgument).FindControl("lblApeMat"), Label).Text)
                        Session.Add("NombreParaCons2", CType(gvEmpleados.Rows(e.CommandArgument).FindControl("lblNombre"), Label).Text)
                        Session.Add("NumEmpParaCons2", CType(gvEmpleados.Rows(e.CommandArgument).FindControl("lblNumEmp"), Label).Text)
                    Else
                        Session.Remove("RFCParaCons2")
                        Session.Remove("CURPParaCons2")
                        Session.Remove("ApePatParaCons2")
                        Session.Remove("ApeMatParaCons2")
                        Session.Remove("NombreParaCons2")
                        Session.Remove("NumEmpParaCons2")
                    End If
                Else
                    If Me.chbxGuardaEmp.Checked Then
                        Session.Add("RFCParaCons", CType(gvEmpleados.Rows(e.CommandArgument).FindControl("LnkBtnRFC"), LinkButton).Text)
                        Session.Add("CURPParaCons", CType(gvEmpleados.Rows(e.CommandArgument).FindControl("lblCURP"), Label).Text)
                        Session.Add("ApePatParaCons", CType(gvEmpleados.Rows(e.CommandArgument).FindControl("lblApePat"), Label).Text)
                        Session.Add("ApeMatParaCons", CType(gvEmpleados.Rows(e.CommandArgument).FindControl("lblApeMat"), Label).Text)
                        Session.Add("NombreParaCons", CType(gvEmpleados.Rows(e.CommandArgument).FindControl("lblNombre"), Label).Text)
                        Session.Add("NumEmpParaCons", CType(gvEmpleados.Rows(e.CommandArgument).FindControl("lblNumEmp"), Label).Text)
                        Session.Remove("RFCParaCons2")
                        Session.Remove("CURPParaCons2")
                        Session.Remove("ApePatParaCons2")
                        Session.Remove("ApeMatParaCons2")
                        Session.Remove("NombreParaCons2")
                        Session.Remove("NumEmpParaCons2")
                    Else
                        Session.Remove("RFCParaCons")
                        Session.Remove("CURPParaCons")
                        Session.Remove("ApePatParaCons")
                        Session.Remove("ApeMatParaCons")
                        Session.Remove("NombreParaCons")
                        Session.Remove("NumEmpParaCons")
                    End If
                End If
        End Select
    End Sub

    Protected Sub gvEmpleados_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvEmpleados.RowDataBound
        Dim LnkBtn As LinkButton
        Dim Celda As Byte
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                For Celda = 0 To e.Row.Cells.Count - 1
                    e.Row.Cells(Celda).Attributes.Add("id", "f" + e.Row.RowIndex.ToString + "c" + Celda.ToString + "")
                    If Celda = 0 Then
                        LnkBtn = CType(e.Row.FindControl("LnkBtnRFC"), LinkButton)
                        LnkBtn.CommandArgument = e.Row.RowIndex.ToString
                        LnkBtn.Attributes.Add("onclick", "seleccionaEmpleado('f" + e.Row.RowIndex.ToString + "c0', 'f" + e.Row.RowIndex.ToString + "c2', 'f" + e.Row.RowIndex.ToString + "c3', 'f" + e.Row.RowIndex.ToString + "c4')")
                    End If
                Next
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvEmpleados, "Select$" + e.Row.RowIndex.ToString)
        End Select
    End Sub
End Class
