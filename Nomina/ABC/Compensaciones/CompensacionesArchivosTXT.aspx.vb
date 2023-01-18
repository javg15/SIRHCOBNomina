Imports DataAccessLayer.COBAEV.Administracion
Imports DataAccessLayer.COBAEV.InformacionAcademica
Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV
Imports System.Data
Imports System.IO
Partial Class CompensacionesArchivosTXT
    Inherits System.Web.UI.Page
    Private Sub DescargaArchivo(ByVal pFile As String)
        Response.ContentType = "text/plain"
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + pFile)
        Response.TransmitFile(Server.MapPath("~/Pagomatico/" + pFile))
        Response.End()
    End Sub
    'Private Sub CreaLinkParaImpresion2(ByVal gvr As GridViewRow)
    '    Dim lblIdReporte As Label = CType(gvr.FindControl("lblIdReporte"), Label)
    '    Dim Meses As String = String.Empty
    '    Dim Item As ListItem

    '    For Each Item In ddlMeses.Items 'lbMeses.Items
    '        If Item.Selected Then
    '            Meses = Meses + Item.Value + ","
    '        End If
    '    Next
    '    Meses = Meses.Remove(Meses.Length - 1, 1)
    '    Select Case lblIdReporte.Text
    '        Case "127" 'Reporte mensual institucional de compensaciones
    '            Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
    '                        + "?Anio=" + Me.ddlAños.SelectedValue _
    '                        + "&IdMes=" + ddlMeses.SelectedValue.Replace("-", "_") _
    '                        + "&IdReporte=" + lblIdReporte.Text + "','CompeInstituc_" + Me.ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue.Replace("-", "_") + "'); return false;"
    '        Case "125" 'Reporte para la autorización de compensaciones (BLOQUE SELECCIONADO)
    '            Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
    '                        + "?Anio=" + Me.ddlAños.SelectedValue _
    '                        + "&IdMes=" + ddlMeses.SelectedValue.Replace("-", "_") _
    '                        + "&InfComp=B" _
    '                        + "&IdReporte=" + lblIdReporte.Text + "','CompeAutBS_" + Me.ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue.Replace("-", "_") + "'); return false;"
    '        Case "26" 'Reporte para la autorización de compensaciones (GENERAL)
    '            Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
    '                        + "?Anio=" + Me.ddlAños.SelectedValue _
    '                        + "&IdMes=" + ddlMeses.SelectedValue.Replace("-", "_") _
    '                        + "&InfComp=G" _
    '                        + "&IdReporte=" + lblIdReporte.Text + "','CompeAutGral_" + Me.ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue.Replace("-", "_") + "'); return false;"
    '        Case "27" 'Reporte para cuadrar compensaciones (GENERAL)
    '            Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
    '                        + "?Anio=" + Me.ddlAños.SelectedValue _
    '                        + "&IdMes=" + ddlMeses.SelectedValue.Replace("-", "_") _
    '                        + "&InfComp=G" _
    '                        + "&IdReporte=" + lblIdReporte.Text + "','CompeCuadre_" + Me.ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue.Replace("-", "_") + "'); return false;"
    '        Case "126" 'Reporte para cuadrar compensaciones (BLOQUE SELECCIONADO)
    '            Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
    '                        + "?Anio=" + Me.ddlAños.SelectedValue _
    '                        + "&IdMes=" + ddlMeses.SelectedValue.Replace("-", "_") _
    '                        + "&InfComp=B" _
    '                        + "&IdReporte=" + lblIdReporte.Text + "','CompeCuadre_" + Me.ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue.Replace("-", "_") + "'); return false;"
    '        Case "135" 'Reporte para cuadrar compensaciones con adscripción (GENERAL)
    '            Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
    '                        + "?Anio=" + Me.ddlAños.SelectedValue _
    '                        + "&IdMes=" + ddlMeses.SelectedValue.Replace("-", "_") _
    '                        + "&InfComp=G" _
    '                        + "&IdReporte=" + lblIdReporte.Text + "','CompeCuadre_" + Me.ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue.Replace("-", "_") + "'); return false;"
    '        Case "136" 'Reporte para cuadrar compensaciones con adscripción (BLOQUE SELECCIONADO)
    '            Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
    '                        + "?Anio=" + Me.ddlAños.SelectedValue _
    '                        + "&IdMes=" + ddlMeses.SelectedValue.Replace("-", "_") _
    '                        + "&InfComp=B" _
    '                        + "&IdReporte=" + lblIdReporte.Text + "','CompeCuadre_" + Me.ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue.Replace("-", "_") + "'); return false;"

    '        Case "28" 'Reporte para la coniciliación de compensaciones
    '            Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
    '                        + "?Anio=" + Me.ddlAños.SelectedValue _
    '                        + "&IdMes=" + ddlMeses.SelectedValue.Replace("-", "_") _
    '                        + "&SoloAltas=False&SoloBajas=False&SoloIncDec=False" _
    '                        + "&IdReporte=" + lblIdReporte.Text + "','CompeConciliacion_" + Me.ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue.Replace("-", "_") + "'); return false;"
    '        Case "34" 'Reporte para impresión de recibos
    '            Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
    '                        + "?Anio=" + Me.ddlAños.SelectedValue _
    '                        + "&Meses=" + Meses.Replace("-", "_") _
    '                        + "&IdEmp=" + ddlMeses.SelectedValue.Replace("-", "_") _
    '                        + "&IdReporte=" + lblIdReporte.Text + "','CompeRecibos_" + Me.ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue.Replace("-", "_") + "'); return false;"
    '        Case "40" 'Reporte para la coniciliación de compensaciones (Solo altas)
    '            Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
    '                        + "?Anio=" + Me.ddlAños.SelectedValue _
    '                        + "&IdMes=" + ddlMeses.SelectedValue.Replace("-", "_") _
    '                        + "&SoloAltas=True&SoloBajas=False&SoloIncDec=False" _
    '                        + "&IdReporte=" + lblIdReporte.Text + "','CompeConciliacion_" + Me.ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue.Replace("-", "_") + "'); return false;"
    '        Case "41" 'Reporte para la coniciliación de compensaciones (Solo bajas)
    '            Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
    '                        + "?Anio=" + Me.ddlAños.SelectedValue _
    '                        + "&IdMes=" + ddlMeses.SelectedValue.Replace("-", "_") _
    '                        + "&SoloAltas=False&SoloBajas=True&SoloIncDec=False" _
    '                        + "&IdReporte=" + lblIdReporte.Text + "','CompeConciliacion_" + Me.ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue.Replace("-", "_") + "'); return false;"
    '        Case "42" 'Reporte para la coniciliación de compensaciones (Solo Inc/Dec)
    '            Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
    '                        + "?Anio=" + Me.ddlAños.SelectedValue _
    '                        + "&IdMes=" + ddlMeses.SelectedValue.Replace("-", "_") _
    '                        + "&SoloAltas=False&SoloBajas=False&SoloIncDec=True" _
    '                        + "&IdReporte=" + lblIdReporte.Text + "','CompeConciliacion_" + Me.ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue.Replace("-", "_") + "'); return false;"
    '    End Select
    'End Sub
    'Private Sub CreaLinkParaImpresion(ByVal gvr As GridViewRow)
    '    Dim lblIdReporte As Label = CType(gvr.FindControl("lblIdReporte"), Label)
    '    Dim lblImplicaMeses As Label = CType(gvr.FindControl("lblImplicaMeses"), Label)
    '    Dim lblExportarAExcel As Label = CType(gvr.FindControl("lblExportarAExcel"), Label)
    '    Dim lblImplicaQuincenas As Label = CType(gvr.FindControl("lblImplicaQuincenas"), Label)
    '    Dim lblImplicaFondoPresup As Label = CType(gvr.FindControl("lblImplicaFondoPresup"), Label)
    '    Dim lblImplicaPlantel As Label = CType(gvr.FindControl("lblImplicaPlantel"), Label)
    '    Dim Meses As String = String.Empty
    '    Dim Item As ListItem

    '    For Each Item In ddlMeses.Items
    '        If Item.Selected Then
    '            Meses = Meses + Item.Value + ","
    '        End If
    '    Next
    '    Meses = Meses.Remove(Meses.Length - 1, 1)

    '    If CType(lblExportarAExcel.Text, Boolean) Then
    '        CreaLinkParaImpresion2(gvr)
    '    End If
    '    Me.pnlMeses.Enabled = CType(lblImplicaMeses.Text, Boolean)
    '    Me.ibImprimir.Visible = True
    '    Me.ibExportarExcel.Visible = CType(lblExportarAExcel.Text, Boolean)
    '    '+ "&IdMes=" + Me.ddlMeses.SelectedValue.Replace("-", "_") _
    '    Select Case lblIdReporte.Text
    '        Case "127" 'Reporte mensual institucional de compensaciones
    '            Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
    '                        + "?Anio=" + Me.ddlAños.SelectedValue _
    '                        + "&IdMes=" + ddlMeses.SelectedValue.Replace("-", "_") _
    '                        + "&IdReporte=" + lblIdReporte.Text + "','CompeInstituc_" + Me.ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue.Replace("-", "_") + "'); return false;"
    '        Case "125" 'Reporte para la autorización de compensaciones (BLOQUE SELECCIONADO)
    '            Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
    '                        + "?Anio=" + Me.ddlAños.SelectedValue _
    '                        + "&IdMes=" + ddlMeses.SelectedValue.Replace("-", "_") _
    '                        + "&InfComp=B" _
    '                        + "&IdReporte=" + lblIdReporte.Text + "','CompeAutBS_" + Me.ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue.Replace("-", "_") + "'); return false;"
    '        Case "26" 'Reporte para la autorización de compensaciones (GENERAL)
    '            Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
    '                        + "?Anio=" + Me.ddlAños.SelectedValue _
    '                        + "&IdMes=" + ddlMeses.SelectedValue.Replace("-", "_") _
    '                        + "&InfComp=G" _
    '                        + "&IdReporte=" + lblIdReporte.Text + "','CompeAutGral_" + Me.ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue.Replace("-", "_") + "'); return false;"
    '        Case "27" 'Reporte para cuadrar compensaciones (GENERAL)
    '            Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
    '                        + "?Anio=" + Me.ddlAños.SelectedValue _
    '                        + "&IdMes=" + ddlMeses.SelectedValue.Replace("-", "_") _
    '                        + "&InfComp=G" _
    '                        + "&IdReporte=" + lblIdReporte.Text + "','CompeCuadre_" + Me.ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue.Replace("-", "_") + "'); return false;"
    '        Case "126" 'Reporte para cuadrar compensaciones  (BLOQUE SELECCIONADO)
    '            Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
    '                        + "?Anio=" + Me.ddlAños.SelectedValue _
    '                        + "&IdMes=" + ddlMeses.SelectedValue.Replace("-", "_") _
    '                        + "&InfComp=B" _
    '                        + "&IdReporte=" + lblIdReporte.Text + "','CompeCuadre_" + Me.ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue.Replace("-", "_") + "'); return false;"
    '        Case "135" 'Reporte para cuadrar compensaciones con adscripción (GENERAL)
    '            Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
    '                        + "?Anio=" + Me.ddlAños.SelectedValue _
    '                        + "&IdMes=" + ddlMeses.SelectedValue.Replace("-", "_") _
    '                        + "&InfComp=G" _
    '                        + "&IdReporte=" + lblIdReporte.Text + "','CompeCuadre_" + Me.ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue.Replace("-", "_") + "'); return false;"
    '        Case "136" 'Reporte para cuadrar compensaciones con adscripción (BLOQUE SELECCIONADO)
    '            Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
    '                        + "?Anio=" + Me.ddlAños.SelectedValue _
    '                        + "&IdMes=" + ddlMeses.SelectedValue.Replace("-", "_") _
    '                        + "&InfComp=B" _
    '                        + "&IdReporte=" + lblIdReporte.Text + "','CompeCuadre_" + Me.ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue.Replace("-", "_") + "'); return false;"
    '        Case "28" 'Reporte para la coniciliación de compensaciones
    '            'Me.ibImprimir.Visible = Me.lbMeses.SelectedValue.Substring(3, 1) = "0"
    '            Me.ibExportarExcel.Visible = ddlMeses.SelectedValue.Substring(3, 1) = "0"
    '            Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
    '                        + "?Anio=" + Me.ddlAños.SelectedValue _
    '                        + "&IdMes=" + ddlMeses.SelectedValue.Replace("-", "_") _
    '                        + "&SoloAltas=False&SoloBajas=False&SoloIncDec=False" _
    '                        + "&IdReporte=" + lblIdReporte.Text + "','CompeConciliacion_" + Me.ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue.Replace("-", "_") + "'); return false;"
    '        Case "34" 'Reporte para impresión de recibos
    '            Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
    '                        + "?Anio=" + Me.ddlAños.SelectedValue _
    '                        + "&Meses=" + Meses.Replace("-", "_") _
    '                        + "&IdReporte=" + lblIdReporte.Text + "','CompeRecibos_" + Me.ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue.Replace("-", "_") + "'); return false;"
    '        Case "40" 'Reporte para la coniciliación de compensaciones (Solo altas)
    '            'Me.ibImprimir.Visible = Me.lbMeses.SelectedValue.Substring(3, 1) = "0"
    '            'Me.ibExportarExcel.Visible = Me.lbMeses.SelectedValue.Substring(3, 1) = "0"
    '            Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
    '                        + "?Anio=" + Me.ddlAños.SelectedValue _
    '                        + "&IdMes=" + ddlMeses.SelectedValue.Replace("-", "_") _
    '                        + "&SoloAltas=True&SoloBajas=False&SoloIncDec=False" _
    '                        + "&IdReporte=" + lblIdReporte.Text + "','CompeConciliacion_" + Me.ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue.Replace("-", "_") + "'); return false;"
    '        Case "41" 'Reporte para la coniciliación de compensaciones (Solo bajas)
    '            'Me.ibImprimir.Visible = Me.lbMeses.SelectedValue.Substring(3, 1) = "0"
    '            'Me.ibExportarExcel.Visible = Me.lbMeses.SelectedValue.Substring(3, 1) = "0"
    '            Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
    '                        + "?Anio=" + Me.ddlAños.SelectedValue _
    '                        + "&IdMes=" + ddlMeses.SelectedValue.Replace("-", "_") _
    '                        + "&SoloAltas=False&SoloBajas=True&SoloIncDec=False" _
    '                        + "&IdReporte=" + lblIdReporte.Text + "','CompeConciliacion_" + Me.ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue.Replace("-", "_") + "'); return false;"
    '        Case "42" 'Reporte para la coniciliación de compensaciones (Solo inc/dec)
    '            'Me.ibImprimir.Visible = Me.lbMeses.SelectedValue.Substring(3, 1) = "0"
    '            'Me.ibExportarExcel.Visible = Me.lbMeses.SelectedValue.Substring(3, 1) = "0"
    '            Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
    '                        + "?Anio=" + Me.ddlAños.SelectedValue _
    '                        + "&IdMes=" + ddlMeses.SelectedValue.Replace("-", "_") _
    '                        + "&SoloAltas=False&SoloBajas=False&SoloIncDec=True" _
    '                        + "&IdReporte=" + lblIdReporte.Text + "','CompeConciliacion_" + Me.ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue.Replace("-", "_") + "'); return false;"
    '    End Select
    'End Sub
    'Private Sub BindgvReportes()
    '    Dim oAplic As New Aplicacion
    '    Dim drPagina As DataRow
    '    Dim oReporte As New Reportes
    '    drPagina = oAplic.ObtenInfSobrePagina(Request.Url.Segments(Request.Url.Segments.Length - 1).ToString)
    '    Me.gvReportes.DataSource = oReporte.ObtenPorPagina(CShort(drPagina("IdPagina")))
    '    Me.gvReportes.DataBind()
    '    Me.gvReportes.SelectedIndex = 0
    'End Sub
    Private Sub BindddlAños()
        Dim oCompensacion As New Compensacion
        With Me.ddlAños
            .DataSource = oCompensacion.ObtenAñosPagados()
            .DataTextField = "Anio"
            .DataValueField = "Anio"
            .DataBind()
            If .Items.Count = 0 Then
                .Items.Insert(0, "No existe información de años")
                .Items(0).Value = -1
                Me.btnConsultar.Enabled = False
            Else
                Me.btnConsultar.Enabled = True
            End If
        End With
    End Sub
    Private Sub BindddlMeses()
        Dim oCompensacion As New Compensacion
        With ddlMeses
            .DataSource = oCompensacion.ObtenMesesPagadosPorAño(CShort(Me.ddlAños.SelectedValue), False)
            .DataTextField = "NombreMes"
            .DataValueField = "IdMes"
            .DataBind()
            .SelectedIndex = 0
        End With
        BindgvCompensaciones()
        BindddlBancos()
    End Sub
    Private Sub BindgvCompensaciones(Optional ByVal IdEmp As Integer = 0, Optional ByVal Origen As String = "")
        Dim oCompensacion As New Compensacion
        Dim ds As DataSet
        Dim lblImporteTotal, lblTotalEmpsTotal, lblImporteTotal2, lblTotalEmpsTotal2 As Label
        ds = oCompensacion.ObtenEmpsPorAñoMes(CShort(Me.ddlAños.SelectedValue), ddlMeses.SelectedValue)
        pnlMeses.GroupingText = "Pagos realizados durante " + ddlAños.SelectedValue
        Me.gvResumen.DataSource = ds.Tables(1)
        Me.gvResumen.DataBind()
        If ds.Tables(1).Rows.Count > 0 Then
            lblImporteTotal = CType(Me.gvResumen.FooterRow.FindControl("lblImporteTotal"), Label)
            lblTotalEmpsTotal = CType(Me.gvResumen.FooterRow.FindControl("lblTotalEmpsTotal"), Label)
            lblImporteTotal.Text = Format(ds.Tables(1).Compute("Sum(Importe)", ""), "$ ###,###,##0.00")
            lblTotalEmpsTotal.Text = ds.Tables(1).Compute("Sum(TotalEmps)", "")
        End If
        Me.gvResumen2.DataSource = ds.Tables(2)
        Me.gvResumen2.DataBind()
        If ds.Tables(2).Rows.Count > 0 Then
            lblImporteTotal2 = CType(Me.gvResumen2.FooterRow.FindControl("lblImporteTotal"), Label)
            lblTotalEmpsTotal2 = CType(Me.gvResumen2.FooterRow.FindControl("lblTotalEmpsTotal"), Label)
            lblImporteTotal2.Text = Format(ds.Tables(2).Compute("Sum(Importe)", ""), "$ ###,###,##0.00")
            lblTotalEmpsTotal2.Text = ds.Tables(2).Compute("Sum(TotalEmps)", "")
        End If
        Me.lblMsj2.Text = "Resúmen de compensaciones por tipo de pago en " + ddlMeses.SelectedItem.Text.ToUpper + " de " + Me.ddlAños.SelectedItem.Text
        Me.lblMsj4.Text = "Resúmen de compensaciones por tipo de empleado en " + ddlMeses.SelectedItem.Text.ToUpper + " de " + Me.ddlAños.SelectedItem.Text
    End Sub
    Private Sub ArchivosTXT()
        Dim oBanco As New Bancos
        Dim drBanco As DataRow
        Dim drBanco2 As DataRow
        Dim vlCompNomArchDisp As String

        drBanco = oBanco.ObtenPorId(CByte(ddlBancos.SelectedValue))

        vlCompNomArchDisp = String.Empty
        If drBanco("NombreCortoBanco").ToString = "BANORTE" Then
            drBanco2 = oBanco.ObtenSecuencialBANORTE(CByte(ddlBancos.SelectedValue), CShort(ddlAños.SelectedValue), ddlMeses.SelectedValue, "C")
            vlCompNomArchDisp = drBanco2("CompParaNombreArchivDisp").ToString
            If File.Exists(ConfigurationManager.AppSettings("RutaPagomatico") + drBanco("NombreParaArchivosDisp").ToString + vlCompNomArchDisp + "_" + ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue.Replace("-", "_") + drBanco("ExtensionArchivoDisp").ToString) Then
                Me.ibDescargar.Enabled = True
                lblMsjDescargar.Text = "Descargar archivo"
            Else
                Me.ibDescargar.Enabled = False
                lblMsjDescargar.Text = "Archivo sin generar"
            End If
        Else
            If File.Exists(ConfigurationManager.AppSettings("RutaPagomatico") + "Compe_" + ddlBancos.SelectedItem.Text + "_" + ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue.Replace("-", "_") + ".txt") Then
                Me.ibDescargar.Enabled = True
                lblMsjDescargar.Text = "Descargar archivo"
            Else
                Me.ibDescargar.Enabled = False
                lblMsjDescargar.Text = "Archivo sin generar"
            End If
        End If


    End Sub
    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, ByVal dt As DataTable, ByVal SelectedValue As String)
        ddl.DataSource = dt
        ddl.DataTextField = TextField
        ddl.DataValueField = ValueField
        ddl.DataBind()
        If SelectedValue Is Nothing = False Then ddl.SelectedValue = SelectedValue
    End Sub
    Private Sub BindddlBancos()
        Dim oBanco As New Bancos
        Dim ddlAux As New DropDownList
        Dim li As ListItem
        LlenaDDL(ddlBancos, "NombreCortoBanco", "IdBanco", oBanco.ObtenTodos(), Nothing)
        LlenaDDL(ddlAux, "NombreCortoBanco", "IdBanco", oBanco.ObtenTodos(), Nothing)
        li = ddlBancos.Items.FindByText("SIN DEFINIR")
        If li Is Nothing = False Then
            ddlBancos.Items.Remove(li)
            ddlAux.Items.Remove(li)
        End If

        'Código agregado para los casos de pensión alimenticia
        For Each Item As ListItem In ddlAux.Items
            If Item.Text.Contains("BANAMEX") Then
                'ddlBancos.Items.Add(New ListItem(Item.Text.Trim + " (CLABE)", Item.Value + ".CLABE"))
            ElseIf Item.Text.Contains("BANCOMER") Then
                'ddlBancos.Items.Add(New ListItem(Item.Text.Trim + " (CLABE)", Item.Value + ".CLABE"))
            ElseIf Item.Text.Contains("BANORTE") Then
                ddlBancos.Items.Add(New ListItem(Item.Text.Trim + " (CLABE)", Item.Value + ".CLABE"))
            End If
        Next
        'Código agregado para los casos de pensión alimenticia
    End Sub
    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            Dim drBanco As DataRow
            Dim oBanco As New Bancos
            BindddlAños()
            If Me.ddlAños.SelectedValue <> -1 Then
                BindddlMeses()
                BindgvCompensaciones()
                BindddlBancos()

                drBanco = oBanco.ObtenPorId(CByte(Left(ddlBancos.SelectedValue, 1)))
                ddlCons.Enabled = CBool(drBanco("ReqConsecutivo"))
                ddlCons.SelectedIndex = 0
                txtbxFecha.Text = String.Empty
                txtbxFecha.Enabled = CBool(drBanco("ReqFechaPago"))
            End If
        End If
    End Sub

    Protected Sub btnConsultar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        BindgvCompensaciones()
    End Sub

    Protected Sub ddlAños_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlAños.SelectedIndexChanged
        BindddlMeses()
    End Sub

    Protected Sub ibGenerarTXT_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibGenerarTXT.Click
        Dim strStreamW As Stream
        Dim strStreamWriter As StreamWriter = Nothing
        Dim oNomina As New Nomina

        Dim drBanco As DataRow
        Dim oBanco As New Bancos

        Dim FilePath As String
        Dim File As String = String.Empty
        Dim vlSecuencial As String = String.Empty
        Dim vlSecuencial2 As String = String.Empty
        Dim vlFechaPago As Date = "31/12/2099"
        Dim dt As DataTable

        Try
            drBanco = oBanco.ObtenPorId(CByte(Left(ddlBancos.SelectedValue, 1)))

            If ddlCons.Enabled Then
                If Me.ddlBancos.SelectedItem.Text.Contains("BANORTE") Then
                    vlSecuencial = ddlCons.SelectedValue
                End If
                vlSecuencial2 = ddlCons.SelectedValue
                vlFechaPago = CDate(IIf(txtbxFecha.Text.Trim = String.Empty, "31/12/2099", txtbxFecha.Text))
            End If

            If Me.ddlBancos.SelectedItem.Text.Contains("(CLABE)") Then
                File = drBanco("NombreParaArchivosDisp").ToString + vlSecuencial + "_CLABE_" + Me.ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue.Replace("-", "_") + drBanco("ExtensionArchivoDisp").ToString
                FilePath = ConfigurationManager.AppSettings("RutaPagomatico") + File
            Else
                File = drBanco("NombreParaArchivosDisp").ToString + vlSecuencial + "_" + Me.ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue.Replace("-", "_") + drBanco("ExtensionArchivoDisp").ToString
                FilePath = ConfigurationManager.AppSettings("RutaPagomatico") + File
            End If

            System.IO.File.Delete(FilePath)
            strStreamW = System.IO.File.OpenWrite(FilePath)
            strStreamWriter = New System.IO.StreamWriter(strStreamW, System.Text.Encoding.ASCII)

            If Me.ddlBancos.SelectedItem.Text.Contains("(CLABE)") Then
                If ddlCons.Enabled Then
                    dt = oNomina.GeneraTXTPagomaticoCompenCLABE(CByte(Left(ddlBancos.SelectedValue, 1)), CShort(ddlAños.SelectedValue), ddlMeses.SelectedValue, ddlBancosInfComp.SelectedValue, vlSecuencial2, vlFechaPago)
                Else
                    dt = oNomina.GeneraTXTPagomaticoCompenCLABE(CByte(Left(ddlBancos.SelectedValue, 1)), CShort(ddlAños.SelectedValue), ddlMeses.SelectedValue, ddlBancosInfComp.SelectedValue)
                End If
            Else
                If ddlCons.Enabled Then
                    dt = oNomina.GeneraTXTPagomaticoCompensacion2(CByte(Left(ddlBancos.SelectedValue, 1)), CShort(ddlAños.SelectedValue), ddlMeses.SelectedValue, ddlBancosInfComp.SelectedValue, vlSecuencial2, vlFechaPago)
                Else
                    dt = oNomina.GeneraTXTPagomaticoCompensacion2(CByte(Left(ddlBancos.SelectedValue, 1)), CShort(ddlAños.SelectedValue), ddlMeses.SelectedValue, ddlBancosInfComp.SelectedValue)
                End If
            End If

            Dim dr As System.Data.DataRow

            For Each dr In dt.Rows
                strStreamWriter.WriteLine(dr(0).ToString)
            Next

            strStreamWriter.Close()

            DescargaArchivo(File)

        Catch ext As Threading.ThreadAbortException
            strStreamWriter = Nothing
        Catch ex As Exception
            strStreamWriter = Nothing
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub ddlBancos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBancos.SelectedIndexChanged
        Dim drBanco As DataRow
        Dim oBanco As New Bancos

        drBanco = oBanco.ObtenPorId(CByte(Left(ddlBancos.SelectedValue, 1)))
        ddlCons.Enabled = CBool(drBanco("ReqConsecutivo"))
        ddlCons.SelectedIndex = 0
        txtbxFecha.Text = String.Empty
        txtbxFecha.Enabled = CBool(drBanco("ReqFechaPago"))
    End Sub

    Protected Sub ibDescargar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibDescargar.Click
        Dim oBanco As New Bancos
        Dim drBanco As DataRow
        Dim drBanco2 As DataRow
        Dim vlCompNomArchDisp As String

        drBanco = oBanco.ObtenPorId(CByte(ddlBancos.SelectedValue))

        vlCompNomArchDisp = String.Empty
        If drBanco("NombreCortoBanco").ToString = "BANORTE" Then
            drBanco2 = oBanco.ObtenSecuencialBANORTE(CByte(ddlBancos.SelectedValue), CShort(ddlAños.SelectedValue), ddlMeses.SelectedValue, "C")
            vlCompNomArchDisp = drBanco2("CompParaNombreArchivDisp").ToString
            If File.Exists(ConfigurationManager.AppSettings("RutaPagomatico") + drBanco("NombreParaArchivosDisp").ToString + vlCompNomArchDisp + "_" + ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue.Replace("-", "_") + drBanco("ExtensionArchivoDisp").ToString) Then
                Response.ContentType = "text/plain"
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + drBanco("NombreParaArchivosDisp").ToString + vlCompNomArchDisp + "_" + ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue.Replace("-", "_") + drBanco("ExtensionArchivoDisp").ToString)
                Response.TransmitFile(Server.MapPath("~/Pagomatico/" + drBanco("NombreParaArchivosDisp").ToString + vlCompNomArchDisp + "_" + ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue.Replace("-", "_") + drBanco("ExtensionArchivoDisp").ToString))
                Response.End()
            End If
        Else
            If File.Exists(ConfigurationManager.AppSettings("RutaPagomatico") + "Compe_" + Me.ddlBancos.SelectedItem.Text + "_" + Me.ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue.Replace("-", "_") + ".txt") Then
                Response.ContentType = "text/plain"
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + "Compe_" + Me.ddlBancos.SelectedItem.Text + "_" + Me.ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue + ".txt")
                Response.TransmitFile(Server.MapPath("~/Pagomatico/" + "Compe_" + Me.ddlBancos.SelectedItem.Text + "_" + ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue.Replace("-", "_") + ".txt"))
                Response.End()
            End If
        End If
    End Sub
    Protected Sub ddlMeses_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlMeses.SelectedIndexChanged
        BindgvCompensaciones()
    End Sub
End Class