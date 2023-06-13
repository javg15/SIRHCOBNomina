Imports DataAccessLayer.COBAEV.Administracion
Imports DataAccessLayer.COBAEV.Nominas
Imports System.Data
Imports DataAccessLayer.COBAEV
Partial Class ReportesIncidencias
    Inherits System.Web.UI.Page
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
        Dim oQna As New Quincenas
        With Me.ddlAños
            .DataSource = oQna.ObtenAños(True)
            .DataTextField = "Anio"
            .DataValueField = "Anio"
            .DataBind()
            If .Items.Count = 0 Then
                .Items.Insert(0, "No existe información de años")
                .Items(0).Value = -1
            Else
                BindddlQuincenas()
            End If
        End With
    End Sub

    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, ByVal dt As DataTable, Optional ByVal SelectedValue As String = "")
        Dim R As DataRow = dt.NewRow

        If ddl.ID = "ddlPlantel" Then
            R(TextField) = "-"
            R(ValueField) = "0"
            dt.Rows.InsertAt(R, 0)
        End If

        ddl.DataSource = dt
        ddl.DataTextField = TextField
        ddl.DataValueField = ValueField
        ddl.DataBind()
        If SelectedValue <> String.Empty Then ddl.SelectedValue = SelectedValue
    End Sub
    Private Sub BindddlPlanteles()
        Dim oPlantel As New Plantel
        LlenaDDL(ddlPlantel, "DescPlantel", "IdPlantel", oPlantel.ObtenParaPagoPorUsr2(Session("Login"), True))
    End Sub
    Private Sub BindddlTipoDeNomina()
        Dim oQna As New Nomina
        LlenaDDL(Me.ddlTipoDeNomina, "DescFondoPresup", "IdFondoPresup", oQna.GetFondosPresupuestales())
    End Sub
    Private Sub BindddlTipoReporteEmpleadoLM()
        Me.ddlPeriodoEmpleadoLM.Items.Clear()
        Me.ddlPeriodoEmpleadoLM.Items.Add(New ListItem("Periodo anterior", "0"))
        Me.ddlPeriodoEmpleadoLM.Items.Add(New ListItem("Periodo actual", "1"))
    End Sub
    Private Sub BindddlTipoUsuario()
        Dim oUsr As New Usuario
        Dim drUsuario As DataRow

        oUsr.Login = Session("Login")
        drUsuario = oUsr.ObtenerPorLogin()

        Me.ddlUsuario.Items.Clear()

        If oUsr.EsSuperAdmin(oUsr.Login) Or oUsr.EsAdministrador(oUsr.Login) Or drUsuario("IdRol") = 3 Then 'ADMIN OR Archivo e incidencias (Responsable)
            Me.ddlUsuario.Items.Add(New ListItem("Todos", "0"))
        End If

        Me.ddlUsuario.Items.Add(New ListItem("Usuario actual", "1"))
    End Sub

    'Private Sub CreaLinkParaImpresion2(ByVal gvr As GridViewRow)
    ' Dim lblIdReporte As Label = CType(gvr.FindControl("lblIdReporte"), Label)

    '    Select Case lblIdReporte.Text
    '   Case "150" 'REPORTE ANUAL DE PERMISOS ECONÓMICOS DESGLOSADO POR EMPLEADO Y MESES
    '              ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
    '                         + "?Anio=" + ddlAños.SelectedValue _
    '                        + "&IdReporte=" + lblIdReporte.Text + "','RptPermEco_" + ddlAños.SelectedValue + "'); return false;"
    'Case "159" 'REPORTE ANUAL DE LICENCIAS MÉDICAS DESGLOSADO POR EMPLEADO Y MESES
    '           ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
    '                      + "?Anio=" + ddlAños.SelectedValue _
    '                       + "&IdReporte=" + lblIdReporte.Text + "','RptPermEco_" + ddlAños.SelectedValue + "'); return false;"
    ' End Select
    'End Sub
    Private Sub CreaLinkParaImpresion(ByVal gvr As GridViewRow)
        Dim oUsr As New Usuario
        Dim drUsuario As DataRow
        Dim lblIdReporte As Label = CType(gvr.FindControl("lblIdReporte"), Label)
        Dim lblExportarAExcel As Label = CType(gvr.FindControl("lblExportarAExcel"), Label)
        Dim lblExportarAPDF As Label = CType(gvr.FindControl("lblExportarAPDF"), Label)
        Dim dt As DataTable
        Dim oReporte As New Reportes
        Dim strOnClientClick As String = String.Empty
        Dim Valor As String = String.Empty
        Dim lblPorEmpleado As Label = CType(gvr.FindControl("lblPorEmpleado"), Label)
        Dim txtbxNumEmp As TextBox = CType(Me.wucSearchEmps1.FindControl("txtbxNumEmp"), TextBox)

        Dim RFCEmp As String
        Dim hfRFC As HiddenField = CType(wucSearchEmps1.FindControl("hfRFC"), HiddenField)
        'Imprime reporte
        RFCEmp = hfRFC.Value.Trim


        oUsr.Login = Session("Login")
        drUsuario = oUsr.ObtenerPorLogin()

        dt = oReporte.ObtenInfParaImpresion(CShort(lblIdReporte.Text))

        For Each dr As DataRow In dt.Rows
            If strOnClientClick = String.Empty Then
                strOnClientClick = "?" + dr("VariableAsociada")
            Else
                strOnClientClick = strOnClientClick + "&" + dr("VariableAsociada")
            End If
            Select Case dr("VariableAsociada").ToString
                Case "Ejercicio"
                    Valor = ddlAños.SelectedValue
                Case "Anio"
                    Valor = ddlAños.SelectedValue
                Case "NumEmp"
                    Valor = IIf(txtbxNumEmp.Text.Trim <> String.Empty, txtbxNumEmp.Text.Trim, Nothing)
                Case "IdQuincena"
                    Valor = ddlQuincena.SelectedValue
                Case "IdUsuario"
                    Valor = IIf(ddlUsuario.SelectedValue = 0, 0, CShort(drUsuario("IdUsuario")))
                Case "TipoFecha"
                    Valor = ddlTipoFecha.SelectedValue
                Case "PeriodoActual"
                    Valor = ddlPeriodoEmpleadoLM.SelectedValue
                Case "RFCEmp"
                    Valor = IIf(String.IsNullOrEmpty(RFCEmp), "NULL", RFCEmp)
                Case "IdPlantel"
                    Valor = ddlPlantel.SelectedValue

            End Select
            If dr("ValorDefault").ToString <> String.Empty Then
                Valor = dr("ValorDefault").ToString
            End If
            If Valor Is Nothing = False Then
                strOnClientClick = strOnClientClick + "=" + Valor
            Else
                strOnClientClick = strOnClientClick.Replace("?" + dr("VariableAsociada").ToString, String.Empty)
                strOnClientClick = strOnClientClick.Replace("&" + dr("VariableAsociada").ToString, String.Empty)
            End If
        Next
        strOnClientClick = strOnClientClick + "&IdReporte=" + lblIdReporte.Text + "','" + lblIdReporte.Text + "_" + "'); return false;"

        Me.ibExportarExcel.Visible = False
        Me.ibExportPDF.Visible = False

        If CType(lblExportarAExcel.Text, Boolean) Then
            Select Case lblIdReporte.Text
                Case "150" 'REPORTE ANUAL DE PERMISOS ECONÓMICOS DESGLOSADO POR EMPLEADO Y MESES
                    ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                                             + "?Anio=" + ddlAños.SelectedValue _
                                            + "&IdReporte=" + lblIdReporte.Text + "','RptPermEco_" + ddlAños.SelectedValue + "'); return false;"
                    ibExportarExcel.Visible = True
                Case "159" 'REPORTE ANUAL DE LICENCIAS MÉDICAS DESGLOSADO POR EMPLEADO Y MESES
                    ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                                          + "?Anio=" + ddlAños.SelectedValue _
                                           + "&IdReporte=" + lblIdReporte.Text + "','RptPermEco_" + ddlAños.SelectedValue + "'); return false;"
                    ibExportarExcel.Visible = True
                Case "160" 'RESUMEN DE LICENCIAS MÉDICAS POR EMPLEADO
                    ibExportPDF.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" + strOnClientClick
                    ibExportPDF.Visible = True
                    'If chbxRptParaEmp.Checked Then ibExportarExcel.Visible = txtbxRFC.Text <> String.Empty
                Case "163" 'REGISTROS
                    ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" + strOnClientClick
                    ibExportarExcel.Visible = True

                Case "166" 'RESUMEN ANUAL DE INCIDENCIAS
                    ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" + strOnClientClick
                    ibExportarExcel.Visible = True
            End Select

            'ibExportarExcel.Visible = True
            'If chbxRptParaEmp.Checked Then ibExportarExcel.Visible = txtbxRFC.Text <> String.Empty
        End If


    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            BindddlAños()
            BindddlTipoDeNomina()
            BindddlTipoUsuario()
            BindddlTipoReporteEmpleadoLM()
            BindddlPlanteles()
            If ddlAños.SelectedValue <> -1 Then
                BindgvReportes()
                Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
                ActivarControles(gvr)
                CreaLinkParaImpresion(gvr)
            End If
        End If
    End Sub

    Protected Sub ddlAños_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlAños.SelectedIndexChanged
        Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
        CreaLinkParaImpresion(gvr)

        BindddlQuincenas()
    End Sub
    Public Sub BindddlQuincenas()
        Dim oAnio As New Anios
        Dim oQuincena As New Quincenas
        Dim dt As DataTable = oAnio.ObtenQnasOrdinariasPagadas(ddlAños.SelectedValue)
        Dim drQnaActual As DataRow = oQuincena.ObtenQnaActual()
        Dim dr As DataRow = dt.NewRow
        dr("IdQuincena") = drQnaActual("IdQuincena")
        dr("Quincena") = drQnaActual("Quincena")
        dt.Rows.Add(dr)
        dt.DefaultView.Sort = "IdQuincena DESC"
        dt = dt.DefaultView.ToTable

        With Me.ddlQuincena
            .DataSource = dt
            .DataTextField = "Quincena"
            .DataValueField = "IdQuincena"
            .DataBind()
            If .Items.Count = 0 Then
                .Items.Clear()
                .Items.Add(New System.Web.UI.WebControls.ListItem("Información no disponible", "-1"))
            End If
        End With
    End Sub

    Protected Sub ddlTipoDeNomina_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
        CreaLinkParaImpresion(gvr)

    End Sub
    Protected Sub gvReportes_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvReportes.SelectedIndexChanged
        Dim gvr As GridViewRow = Me.gvReportes.SelectedRow

        ActivarControles(gvr)
        CreaLinkParaImpresion(gvr)
        gvReportesSelectedIndexChanged(gvr)
    End Sub
    Private Sub ActivarControles(ByVal gvr As GridViewRow)

        Dim lblIdReporte As Label = CType(gvr.FindControl("lblIdReporte"), Label)
        Dim dt As DataTable
        Dim oReporte As New Reportes
        dt = oReporte.ObtenInfParaImpresion(CShort(lblIdReporte.Text))

        chbxRptParaEmp.Visible = False
        chbxRptParaEmp.Checked = False
        pnlEmp.Visible = False
        pnlQuincena.Visible = False
        pnlTipoReporte.Visible = False
        pnlPlantel.Visible = False

        Select Case lblIdReporte.Text
            Case "150" 'REPORTE ANUAL DE PERMISOS ECONÓMICOS DESGLOSADO POR EMPLEADO Y MESES

            Case "159" 'REPORTE ANUAL DE LICENCIAS MÉDICAS DESGLOSADO POR EMPLEADO Y MESES

            Case "160" 'RESUMEN DE LICENCIAS MÉDICAS POR EMPLEADO
                chbxRptParaEmp.Visible = True
                chbxRptParaEmp.Checked = True

                pnlTipoReporte.Visible = chbxRptParaEmp.Checked
                pnlEmp.Visible = chbxRptParaEmp.Checked
                wucSearchEmps1.Visible = chbxRptParaEmp.Checked
            Case "163" 'REGISTROS
                pnlQuincena.Visible = True
            Case "166" 'RESUMEN ANUAL DE INCIDENCIAS POR EMPLEADO
                chbxRptParaEmp.Visible = True
                chbxRptParaEmp.Checked = True

                pnlEmp.Visible = True
                pnlPlantel.Visible = True
                wucSearchEmps1.Visible = True
        End Select
    End Sub
    Private Sub gvReportesSelectedIndexChanged(ByVal gvr As GridViewRow)
        Dim oUsr As New Usuario
        Dim oReporte As New Reportes
        Dim drReporte As DataRow

        Dim vlIdReporte As Short = CShort(CType(gvr.FindControl("lblIdReporte"), Label).Text)

        If oUsr.EsAdministrador(Session("Login")) Or oUsr.EsVIP(Session("Login")) Or oUsr.EsAnalistaDeSegSoc(Session("Login")) Then
            drReporte = oReporte.ObtenOpcionesVarias(vlIdReporte)
            chbxRptParaEmp.Enabled = CBool(drReporte("PermiteImpPorEmp"))
            Session.Remove("pFchImpRpt")
        Else
            chbxRptParaEmp.Enabled = False
        End If

    End Sub
    Protected Sub chbxRptParaEmp_CheckedChanged(sender As Object, e As System.EventArgs) Handles chbxRptParaEmp.CheckedChanged
        Dim gvr As GridViewRow = gvReportes.SelectedRow
        Dim oUsr As New Usuario
        Dim oReporte As New Reportes
        Dim drReporte As DataRow

        'Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
        CreaLinkParaImpresion(gvr)

        Dim vlIdReporte As Short = CShort(CType(gvr.FindControl("lblIdReporte"), Label).Text)

        pnlEmp.Visible = chbxRptParaEmp.Checked
        wucSearchEmps1.Visible = chbxRptParaEmp.Checked

        If oUsr.EsAdministrador(Session("Login")) Or oUsr.EsVIP(Session("Login")) Or oUsr.EsAnalistaDeSegSoc(Session("Login")) Then
            drReporte = oReporte.ObtenOpcionesVarias(vlIdReporte)
            chbxRptParaEmp.Enabled = CBool(drReporte("PermiteImpPorEmp"))
            Session.Remove("pFchImpRpt")
        End If

    End Sub

    Protected Sub wucSearchEmps1_PreRender(sender As Object, e As System.EventArgs) Handles wucSearchEmps1.PreRender
        If IsPostBack Then
            Dim txtbxRFC As TextBox = CType(Me.wucSearchEmps1.FindControl("txtbxRFC"), TextBox)
            If Request.Params(1).Contains("BtnSearch") Then
                If txtbxRFC.Text.Trim <> String.Empty Then
                    Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
                    CreaLinkParaImpresion(gvr)
                    gvReportesSelectedIndexChanged(gvr)
                Else
                    'pnl1.Visible = False
                End If
            ElseIf Request.Params(1).Contains("BtnNewSearch") Then
                Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
                CreaLinkParaImpresion(gvr)
                gvReportesSelectedIndexChanged(gvr)
            ElseIf Request.Params(1).Contains("BtnCancelSearch") Then
                Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
                CreaLinkParaImpresion(gvr)
                gvReportesSelectedIndexChanged(gvr)
            ElseIf Request.Params("__EVENTTARGET") Is Nothing = False Then
                If Request.Params("__EVENTTARGET").Contains("lnkbtnrfc") Then
                    Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
                    CreaLinkParaImpresion(gvr)
                    gvReportesSelectedIndexChanged(gvr)
                End If
            End If
        End If
    End Sub
    Protected Sub ddlQuincena_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlQuincena.SelectedIndexChanged
        Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
        CreaLinkParaImpresion(gvr)
    End Sub
    Protected Sub ddlTipoFecha_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlTipoFecha.SelectedIndexChanged
        Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
        CreaLinkParaImpresion(gvr)
    End Sub
    Protected Sub ddlUsuario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlUsuario.SelectedIndexChanged
        Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
        CreaLinkParaImpresion(gvr)
    End Sub
    Protected Sub ddlPeriodoEmpleadoLM_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlPeriodoEmpleadoLM.SelectedIndexChanged
        Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
        CreaLinkParaImpresion(gvr)
    End Sub
End Class