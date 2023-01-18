Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.Empleados
Imports System.Data
Imports DataAccessLayer.COBAEV.Administracion

Partial Class EjercFiscReportesConstDeSdo
    Inherits System.Web.UI.Page
    Private Sub BindddlMeses()
        Dim oQna As New Quincenas
        With Me.ddlMeses
            .DataSource = oQna.ObtenMesesCalculadosPorAnio(CShort(Me.ddlAños.SelectedValue))
            .DataTextField = "NombreMes"
            .DataValueField = "IdMes"
            .DataBind()
        End With
    End Sub
    Private Sub CreaLinkParaImpresion(ByVal gvr As GridViewRow)
        Dim lblIdReporte As Label = CType(gvr.FindControl("lblIdReporte"), Label)
        Dim dt As DataTable
        Dim oReporte As New Reportes
        Dim strOnClientClick As String = String.Empty
        Dim Valor As String = String.Empty
        Dim lblExportarAExcel As Label = CType(gvr.FindControl("lblExportarAExcel"), Label)
        Dim lblExportarAPDF As Label = CType(gvr.FindControl("lblExportarAPDF"), Label)
        Dim lblRFC As Label = Nothing
        Dim lblImplicaMeses As Label = CType(gvr.FindControl("lblImplicaMeses"), Label)

        dt = Nothing

        Me.pnlMeses.Enabled = CType(lblImplicaMeses.Text, Boolean)

        If Me.gvEmpleados.SelectedIndex <> -1 Then
            lblRFC = CType(Me.gvEmpleados.SelectedRow.FindControl("lblRFC"), Label)
        Else
            lblRFC = New Label
        End If

        Select Case CShort(lblIdReporte.Text)
            Case 102
                Me.pnlBusquedaDePersonas.Enabled = False
                dt = oReporte.ObtenInfParaImpresion(CShort(lblIdReporte.Text), 1)
            Case 69, 72, 77, 124
                Me.pnlBusquedaDePersonas.Enabled = False
                dt = oReporte.ObtenInfParaImpresion(CShort(lblIdReporte.Text))
            Case 70, 78
                Me.pnlBusquedaDePersonas.Enabled = True
                dt = oReporte.ObtenInfParaImpresion(CShort(lblIdReporte.Text))
        End Select

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
                Case "Mes"
                    Valor = Me.ddlMeses.SelectedValue
                Case "RFCEmp"
                    If Me.pnlBusquedaDePersonas.Enabled = True And Me.gvEmpleados.SelectedIndex <> -1 Then
                        Valor = lblRFC.Text
                        ibExportPDF.Enabled = True
                    Else
                        If Me.pnlBusquedaDePersonas.Enabled = True Then
                            ibExportPDF.Enabled = False
                        Else
                            ibExportPDF.Enabled = True
                        End If
                    End If
            End Select
            If dr("ValorDefault").ToString <> String.Empty Then
                Valor = dr("ValorDefault").ToString
            End If
            strOnClientClick = strOnClientClick + "=" + Valor
        Next
        Select Case CShort(lblIdReporte.Text)
            Case 102
                Me.ibExportarExcel.Enabled = CType(lblExportarAExcel.Text, Boolean)
                strOnClientClick = strOnClientClick + "&SubTipoReporte=1&IdReporte=" + lblIdReporte.Text + "','" + lblIdReporte.Text + "_" + Me.ddlAños.SelectedItem.Text + "'); return false;"
            Case 69, 72, 77, 124
                Me.ibExportarExcel.Enabled = CType(lblExportarAExcel.Text, Boolean)
                strOnClientClick = strOnClientClick + "&IdReporte=" + lblIdReporte.Text + "','" + lblIdReporte.Text + "_" + Me.ddlAños.SelectedItem.Text + "'); return false;"
            Case 70, 78
                If CType(lblExportarAExcel.Text, Boolean) And lblRFC.Text.Trim <> String.Empty Then
                    Me.ibExportarExcel.Enabled = CType(lblExportarAExcel.Text, Boolean)
                Else
                    Me.ibExportarExcel.Enabled = False
                End If
                strOnClientClick = strOnClientClick + "&IdReporte=" + lblIdReporte.Text + "','" + lblIdReporte.Text + "_" + Me.ddlAños.SelectedItem.Text + "_" + lblRFC.Text + "'); return false;"
        End Select
        Me.ibExportarExcel.Visible = False
        Me.ibExportPDF.Visible = False
        If CType(lblExportarAExcel.Text, Boolean) Then
            Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../../../VisorDeReportesExcel.aspx" + strOnClientClick
            Me.ibExportarExcel.Visible = True
        End If
        If CType(lblExportarAPDF.Text, Boolean) Then
            Me.ibExportPDF.OnClientClick = "javascript:abreVentanaImpresion('../../../../VisorDeReportes.aspx" + strOnClientClick
            Me.ibExportPDF.Visible = True
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
    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, ByVal dt As DataTable, ByVal SelectedValue As String)
        ddl.DataSource = dt
        ddl.DataTextField = TextField
        ddl.DataValueField = ValueField
        ddl.DataBind()
        If SelectedValue Is Nothing = False Then ddl.SelectedValue = SelectedValue
    End Sub
    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            BindddlAños()
            BindddlMeses()
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

    Protected Sub ddlAños_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlAños.SelectedIndexChanged
        BindddlMeses()
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
        Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
        CreaLinkParaImpresion(gvr)
    End Sub

    Protected Sub gvEmpleados_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvEmpleados.SelectedIndexChanged
        Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
        CreaLinkParaImpresion(gvr)
    End Sub

    Protected Sub ddlMeses_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlMeses.SelectedIndexChanged
        Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
        CreaLinkParaImpresion(gvr)
    End Sub
End Class