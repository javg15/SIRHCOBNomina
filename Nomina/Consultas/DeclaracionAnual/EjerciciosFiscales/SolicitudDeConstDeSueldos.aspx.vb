Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.Empleados
Imports System.Data
Imports DataAccessLayer.COBAEV.Administracion

Partial Class EjercFiscSolicitudDeConstDeSdo
    Inherits System.Web.UI.Page
    Private Sub CreaLinkParaImpresion(ByVal gvr As GridViewRow)
        Dim lblIdReporte As Label = CType(gvr.FindControl("lblIdReporte"), Label)
        Dim dt As DataTable
        Dim oReporte As New Reportes
        Dim strOnClientClick As String = String.Empty
        Dim Valor As String = String.Empty
        Dim lblExportarAExcel As Label = CType(gvr.FindControl("lblExportarAExcel"), Label)
        Dim lblExportarAPDF As Label = CType(gvr.FindControl("lblExportarAPDF"), Label)

        dt = oReporte.ObtenInfParaImpresion(CShort(lblIdReporte.Text))

        For Each dr As DataRow In dt.Rows
            Valor = String.Empty
            If strOnClientClick = String.Empty Then
                strOnClientClick = "?" + dr("VariableAsociada")
            Else
                strOnClientClick = strOnClientClick + "&" + dr("VariableAsociada")
            End If
            Select Case dr("VariableAsociada").ToString
                Case "Ejercicio"
                    Valor = Me.ddlAños.SelectedItem.Text
            End Select
            If dr("ValorDefault").ToString <> String.Empty Then
                Valor = dr("ValorDefault").ToString
            End If
            strOnClientClick = strOnClientClick + "=" + Valor
        Next
        strOnClientClick = strOnClientClick + "&IdReporte=" + lblIdReporte.Text + "','" + lblIdReporte.Text + "_" + Me.ddlAños.SelectedItem.Text + "'); return false;"
        Me.ibExportarExcel.Visible = CType(lblExportarAExcel.Text, Boolean) 'False
        Me.ibExportPDF.Visible = CType(lblExportarAPDF.Text, Boolean) 'False
        If CType(lblExportarAExcel.Text, Boolean) Then
            Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../../VisorDeReportesExcel.aspx" + strOnClientClick
        End If
        If CType(lblExportarAPDF.Text, Boolean) Then
            Me.ibExportPDF.OnClientClick = "javascript:abreVentanaImpresion('../../../VisorDeReportes.aspx" + strOnClientClick
        End If
    End Sub
    Private Sub BindgvReportes()
        Dim oAplic As New Aplicacion
        Dim drPagina As DataRow
        Dim oReporte As New Reportes
        drPagina = oAplic.ObtenInfSobrePagina(Request.Url.Segments(Request.Url.Segments.Length - 1).ToString)
        Me.gvReportes.DataSource = oReporte.ObtenPorPagina(CShort(drPagina("IdPagina")))
        Me.gvReportes.DataBind()
        Me.gvReportes.SelectedIndex = 0
    End Sub
    Private Sub BindddlAños()
        Dim oEjercicioFiscal As New EjercicioFiscal
        With Me.ddlAños
            .DataSource = oEjercicioFiscal.ObtenAños()
            .DataTextField = "Anio"
            .DataValueField = "Anio"
            .DataBind()
            If .Items.Count = 0 Then
                .Items.Insert(0, New ListItem("No existe información de años", "-1"))
                Me.btnConsultar.Enabled = False
            Else
                Me.btnConsultar.Enabled = True
            End If
        End With
    End Sub
    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            BindddlAños()
            BindgvReportes()
            Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
            CreaLinkParaImpresion(gvr)
        End If
    End Sub
    Protected Sub gvReportes_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
        CreaLinkParaImpresion(gvr)
    End Sub

    Protected Sub gvReportes_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvReportes, "Select$" + e.Row.RowIndex.ToString)
        End Select
    End Sub

    Protected Sub ddlAños_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim dr As DataRow = Nothing
        Dim lblRFC As Label = Nothing
        Dim dtPermisos As DataTable
        Dim oUsr As New Usuario
        Dim oEjercicioFiscal As New EjercicioFiscal
        Dim drEjericioFiscal As DataRow

        drEjericioFiscal = oEjercicioFiscal.ObtenDetalles(CShort(Me.ddlAños.SelectedValue))
        dtPermisos = oUsr.ObtenPermisosSobreTabla(Session("Login"), "EmpsExcParaCalculoDeDeclaracionAnual")

        If Me.gvEmpleados.SelectedIndex <> -1 Then
            lblRFC = CType(Me.gvEmpleados.SelectedRow.FindControl("lblRFC"), Label)
            dr = oEjercicioFiscal.ValidaSiEmpSolicitoConst(CShort(Me.ddlAños.SelectedItem.Text), lblRFC.Text)

            Me.chbxSolicitoConstancia.Checked = CBool(dr("TieneSolicitudDeConstancia"))
            Me.chbxSolicitoConstancia.Text = "Costancia solicitada para el ejercicio " + Me.ddlAños.SelectedItem.Text
            Me.chbxSolicitoConstancia.Enabled = False
            Me.chbxSolicitoConstancia.Visible = True
            Me.btnModificar.Enabled = CBool(drEjericioFiscal("PermiteCapturaDeConstancias")) And CBool(dtPermisos.Rows(0).Item("Actualizacion"))
            Me.btnModificar.Text = "Modificar"
            Me.btnModificar.Visible = True
            Me.btnGuardar.Visible = False
        Else
            Me.chbxSolicitoConstancia.Checked = False
            Me.chbxSolicitoConstancia.Text = "Costancia solicitada para el ejercicio"
            Me.chbxSolicitoConstancia.Visible = False
            Me.btnModificar.Text = "Modificar"
            Me.btnModificar.Visible = False
            Me.btnGuardar.Visible = False
        End If

        Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
        CreaLinkParaImpresion(gvr)
    End Sub

    Protected Sub btnbuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnbuscar.Click
        Dim oEmp As New Empleado
        Dim oUsr As New Usuario
        Dim dr As DataRow
        oUsr.Login = Session("Login")
        dr = oUsr.ObtenerPropiedadesDelRol().Rows(0)
        If ddlTipoBusqueda.SelectedValue.ToUpper = "2" Then 'Nombre
            oEmp.NomEmp = Me.txtStrABuscar.Text.Trim.ToUpper
            Me.gvEmpleados.DataSource = oEmp.Buscar(Empleado.TipoBusqueda.Nombre, CByte(dr("IdRol")), CBool(dr("ConsultaZonasEspecificas")), CBool(dr("ConsultaPlantelesEspecificos")), Session("Login"), True)
        ElseIf ddlTipoBusqueda.SelectedValue.ToUpper = "1" Then   'RFC
            oEmp.RFC = Me.txtStrABuscar.Text.Trim.ToUpper
            Me.gvEmpleados.DataSource = oEmp.Buscar(Empleado.TipoBusqueda.RFC, CByte(dr("IdRol")), CBool(dr("ConsultaZonasEspecificas")), CBool(dr("ConsultaPlantelesEspecificos")), Session("Login"), True)
        Else 'Número de empleado
            oEmp.NumEmp = Me.txtStrABuscar.Text.Trim
            Me.gvEmpleados.DataSource = oEmp.Buscar(Empleado.TipoBusqueda.NumeroDeEmpleado, CByte(dr("IdRol")), CBool(dr("ConsultaZonasEspecificas")), CBool(dr("ConsultaPlantelesEspecificos")), Session("Login"), True)
        End If
        Me.gvEmpleados.DataBind()
        Me.gvEmpleados.SelectedIndex = -1
        lbltipobusqueda.Text = "Última búsqueda realizada por " + ddlTipoBusqueda.SelectedItem.Text.ToLower + ". Texto buscado: " + Me.txtStrABuscar.Text.Trim.ToUpper
        Me.chbxSolicitoConstancia.Checked = False
        Me.chbxSolicitoConstancia.Text = "Costancia solicitada para el ejercicio"
        Me.chbxSolicitoConstancia.Visible = False
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.Visible = False
        Me.btnGuardar.Visible = False
    End Sub

    Protected Sub gvEmpleados_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvEmpleados.SelectedIndexChanged
        Dim oEjerFisc As New EjercicioFiscal
        Dim dr As DataRow
        Dim lblRFC As Label = CType(Me.gvEmpleados.SelectedRow.FindControl("lblRFC"), Label)
        Dim dtPermisos As DataTable
        Dim oUsr As New Usuario
        Dim oEjercicioFiscal As New EjercicioFiscal
        Dim drEjericioFiscal As DataRow

        dr = oEjerFisc.ValidaSiEmpSolicitoConst(CShort(Me.ddlAños.SelectedItem.Text), lblRFC.Text)
        drEjericioFiscal = oEjercicioFiscal.ObtenDetalles(CShort(Me.ddlAños.SelectedValue))
        dtPermisos = oUsr.ObtenPermisosSobreTabla(Session("Login"), "EmpsExcParaCalculoDeDeclaracionAnual")

        Me.chbxSolicitoConstancia.Checked = CBool(dr("TieneSolicitudDeConstancia"))
        Me.chbxSolicitoConstancia.Text = "Costancia solicitada para el ejercicio " + Me.ddlAños.SelectedItem.Text
        Me.chbxSolicitoConstancia.Enabled = False
        Me.chbxSolicitoConstancia.Visible = True
        Me.btnModificar.Enabled = CBool(drEjericioFiscal("PermiteCapturaDeConstancias")) And CBool(dtPermisos.Rows(0).Item("Actualizacion"))
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.Visible = True
        Me.btnGuardar.Visible = False

        Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
        CreaLinkParaImpresion(gvr)
    End Sub

    Protected Sub btnModificar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim lblRFC As Label = CType(Me.gvEmpleados.SelectedRow.FindControl("lblRFC"), Label)
        Dim dr As DataRow
        Dim oEjerFisc As New EjercicioFiscal
        Dim aEnabled As Boolean

        aEnabled = (Me.btnModificar.Text = "Modificar")

        Me.btnModificar.Text = IIf(aEnabled, "Cancelar", "Modificar")
        Me.chbxSolicitoConstancia.Enabled = aEnabled
        Me.btnGuardar.Enabled = aEnabled
        Me.btnGuardar.Visible = aEnabled

        If aEnabled = False Then
            dr = oEjerFisc.ValidaSiEmpSolicitoConst(CShort(Me.ddlAños.SelectedItem.Text), lblRFC.Text)
            Me.chbxSolicitoConstancia.Checked = CBool(dr("TieneSolicitudDeConstancia"))
        End If
    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim lblRFC As Label = CType(Me.gvEmpleados.SelectedRow.FindControl("lblRFC"), Label)
            Dim oEjerFisc As New EjercicioFiscal
            Dim dr As DataRow

            oEjerFisc.UpdEmpsExcParaCalculoDeDecAnual(lblRFC.Text, CShort(Me.ddlAños.SelectedItem.Text), Me.chbxSolicitoConstancia.Checked, CType(Session("ArregloAuditoria"), String()))
            dr = oEjerFisc.ValidaSiEmpSolicitoConst(CShort(Me.ddlAños.SelectedItem.Text), lblRFC.Text)

            Me.chbxSolicitoConstancia.Checked = CBool(dr("TieneSolicitudDeConstancia"))
            Me.chbxSolicitoConstancia.Enabled = False
            Me.btnModificar.Text = "Modificar"
            Me.btnGuardar.Enabled = False
            Me.btnGuardar.Visible = False
        Catch ex As Exception
            Throw (New System.Exception(ex.Message.ToString))
        End Try
    End Sub
End Class