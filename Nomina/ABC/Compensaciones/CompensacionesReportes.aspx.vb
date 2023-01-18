Imports DataAccessLayer.COBAEV.Administracion
Imports DataAccessLayer.COBAEV.InformacionAcademica
Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV
Imports System.Data
Imports System.IO
Partial Class CompensacionesReportes
    Inherits System.Web.UI.Page
    Private Sub CreaLinkParaImpresion2(ByVal gvr As GridViewRow)
        Dim lblIdReporte As Label = CType(gvr.FindControl("lblIdReporte"), Label)
        Dim Meses As String = String.Empty
        Dim Item As ListItem

        For Each Item In ddlMeses.Items
            If Item.Selected Then
                Meses = Meses + Item.Value + ","
            End If
        Next
        Meses = Meses.Remove(Meses.Length - 1, 1)
        Select Case lblIdReporte.Text
            Case "146" 'Reporte mensual institucional de compensaciones
                Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                            + "?Anio=" + Me.ddlAños.SelectedValue _
                            + "&IdMes=" + ddlMeses.SelectedValue.Replace("-", "_") _
                            + "&IdReporte=" + lblIdReporte.Text + "','CompeInstituc_" + Me.ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue.Replace("-", "_") + "'); return false;"
            Case "144" 'Reporte para la autorización de compensaciones (BLOQUE SELECCIONADO)
                Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                            + "?Anio=" + Me.ddlAños.SelectedValue _
                            + "&IdMes=" + ddlMeses.SelectedValue.Replace("-", "_") _
                            + "&InfComp=B" _
                            + "&IdReporte=" + lblIdReporte.Text + "','CompeAutBS_" + Me.ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue.Replace("-", "_") + "'); return false;"
            Case "137" 'Reporte para la autorización de compensaciones (GENERAL)
                Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                            + "?Anio=" + Me.ddlAños.SelectedValue _
                            + "&IdMes=" + ddlMeses.SelectedValue.Replace("-", "_") _
                            + "&InfComp=G" _
                            + "&IdReporte=" + lblIdReporte.Text + "','CompeAutGral_" + Me.ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue.Replace("-", "_") + "'); return false;"
            Case "138" 'Reporte para cuadrar compensaciones (GENERAL)
                Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                            + "?Anio=" + Me.ddlAños.SelectedValue _
                            + "&IdMes=" + ddlMeses.SelectedValue.Replace("-", "_") _
                            + "&InfComp=G" _
                            + "&IdReporte=" + lblIdReporte.Text + "','CompeCuadre_" + Me.ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue.Replace("-", "_") + "'); return false;"
            Case "145" 'Reporte para cuadrar compensaciones (BLOQUE SELECCIONADO)
                Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                            + "?Anio=" + Me.ddlAños.SelectedValue _
                            + "&IdMes=" + ddlMeses.SelectedValue.Replace("-", "_") _
                            + "&InfComp=B" _
                            + "&IdReporte=" + lblIdReporte.Text + "','CompeCuadre_" + Me.ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue.Replace("-", "_") + "'); return false;"
            Case "147" 'Reporte para cuadrar compensaciones con adscripción (GENERAL)
                Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                            + "?Anio=" + Me.ddlAños.SelectedValue _
                            + "&IdMes=" + ddlMeses.SelectedValue.Replace("-", "_") _
                            + "&InfComp=G" _
                            + "&IdReporte=" + lblIdReporte.Text + "','CompeCuadre_" + Me.ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue.Replace("-", "_") + "'); return false;"
            Case "148" 'Reporte para cuadrar compensaciones con adscripción (BLOQUE SELECCIONADO)
                Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                            + "?Anio=" + Me.ddlAños.SelectedValue _
                            + "&IdMes=" + ddlMeses.SelectedValue.Replace("-", "_") _
                            + "&InfComp=B" _
                            + "&IdReporte=" + lblIdReporte.Text + "','CompeCuadre_" + Me.ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue.Replace("-", "_") + "'); return false;"
            Case "149" 'Reporte RESUMEN DE COMPENSACIONES DEL MES
                ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                            + "?Anio=" + Me.ddlAños.SelectedValue _
                            + "&IdMes=" + ddlMeses.SelectedValue.Replace("-", "_") _
                            + "&InfComp=G" _
                            + "&IdReporte=" + lblIdReporte.Text + "','CompeResumen_" + Me.ddlAños.SelectedItem.Text + "_G'); return false;"
            Case "139" 'Reporte para la coniciliación de compensaciones
                Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                            + "?Anio=" + Me.ddlAños.SelectedValue _
                            + "&IdMes=" + ddlMeses.SelectedValue.Replace("-", "_") _
                            + "&SoloAltas=False&SoloBajas=False&SoloIncDec=False" _
                            + "&IdReporte=" + lblIdReporte.Text + "','CompeConciliacion_" + Me.ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue.Replace("-", "_") + "'); return false;"
            Case "140" 'Reporte para impresión de recibos
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                            + "?Anio=" + Me.ddlAños.SelectedValue _
                            + "&Meses=" + Meses.Replace("-", "_") _
                            + "&IdEmp=" + ddlMeses.SelectedValue.Replace("-", "_") _
                            + "&IdReporte=" + lblIdReporte.Text + "','CompeRecibos_" + Me.ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue.Replace("-", "_") + "'); return false;"
            Case "141" 'Reporte para la coniciliación de compensaciones (Solo altas)
                Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                            + "?Anio=" + Me.ddlAños.SelectedValue _
                            + "&IdMes=" + ddlMeses.SelectedValue.Replace("-", "_") _
                            + "&SoloAltas=True&SoloBajas=False&SoloIncDec=False" _
                            + "&IdReporte=" + lblIdReporte.Text + "','CompeConciliacion_" + Me.ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue.Replace("-", "_") + "'); return false;"
            Case "142" 'Reporte para la coniciliación de compensaciones (Solo bajas)
                Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                            + "?Anio=" + Me.ddlAños.SelectedValue _
                            + "&IdMes=" + ddlMeses.SelectedValue.Replace("-", "_") _
                            + "&SoloAltas=False&SoloBajas=True&SoloIncDec=False" _
                            + "&IdReporte=" + lblIdReporte.Text + "','CompeConciliacion_" + Me.ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue.Replace("-", "_") + "'); return false;"
            Case "143" 'Reporte para la coniciliación de compensaciones (Solo Inc/Dec)
                Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                            + "?Anio=" + Me.ddlAños.SelectedValue _
                            + "&IdMes=" + ddlMeses.SelectedValue.Replace("-", "_") _
                            + "&SoloAltas=False&SoloBajas=False&SoloIncDec=True" _
                            + "&IdReporte=" + lblIdReporte.Text + "','CompeConciliacion_" + Me.ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue.Replace("-", "_") + "'); return false;"
            Case "152" 'CONCILIACIÓN DE COMPENSACIONES PARA RECURSOS FINANCIEROS (GENERAL)
                Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                            + "?Anio=" + Me.ddlAños.SelectedValue _
                            + "&IdMes=" + ddlMeses.SelectedValue.Replace("-", "_") _
                            + "&InfComp=G&ResumenPorNumAfect=False" _
                            + "&IdReporte=" + lblIdReporte.Text + "','CompeConcilRFGralSinNumAfect_" + Me.ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue.Replace("-", "_") + "'); return false;"
            Case "153" 'CONCILIACIÓN DE COMPENSACIONES PARA RECURSOS FINANCIEROS (BLOQUE SELECCIONADO)
                Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                            + "?Anio=" + Me.ddlAños.SelectedValue _
                            + "&IdMes=" + ddlMeses.SelectedValue.Replace("-", "_") _
                            + "&InfComp=B&ResumenPorNumAfect=False" _
                            + "&IdReporte=" + lblIdReporte.Text + "','CompeConcilRFBloqueSelSinNumAfect_" + Me.ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue.Replace("-", "_") + "'); return false;"
            Case "154" 'CONCILIACIÓN DE COMPENSACIONES PARA RECURSOS FINANCIEROS (POR NÚMERO DE AFECTACIÓN))
                Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                            + "?Anio=" + Me.ddlAños.SelectedValue _
                            + "&IdMes=" + ddlMeses.SelectedValue.Replace("-", "_") _
                            + "&InfComp=G&ResumenPorNumAfect=True" _
                            + "&IdReporte=" + lblIdReporte.Text + "','CompeConcilRFPorNumAfect_" + Me.ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue.Replace("-", "_") + "'); return false;"

        End Select
    End Sub
    Private Sub CreaLinkParaImpresion(ByVal gvr As GridViewRow)
        Dim lblIdReporte As Label = CType(gvr.FindControl("lblIdReporte"), Label)
        Dim lblImplicaMeses As Label = CType(gvr.FindControl("lblImplicaMeses"), Label)
        Dim lblExportarAExcel As Label = CType(gvr.FindControl("lblExportarAExcel"), Label)
        Dim lblImplicaQuincenas As Label = CType(gvr.FindControl("lblImplicaQuincenas"), Label)
        Dim lblImplicaFondoPresup As Label = CType(gvr.FindControl("lblImplicaFondoPresup"), Label)
        Dim lblImplicaPlantel As Label = CType(gvr.FindControl("lblImplicaPlantel"), Label)
        Dim Meses As String = String.Empty
        Dim Item As ListItem

        For Each Item In ddlMeses.Items
            If Item.Selected Then
                Meses = Meses + Item.Value + ","
            End If
        Next
        Meses = Meses.Remove(Meses.Length - 1, 1)

        If CType(lblExportarAExcel.Text, Boolean) Then
            CreaLinkParaImpresion2(gvr)
        End If
        Me.pnlMeses.Enabled = CType(lblImplicaMeses.Text, Boolean)
        Me.ibImprimir.Visible = True
        Me.ibExportarExcel.Visible = CType(lblExportarAExcel.Text, Boolean)
        '+ "&IdMes=" + Me.ddlMeses.SelectedValue.Replace("-", "_") _
        Select Case lblIdReporte.Text
            Case "146" 'Reporte mensual institucional de compensaciones
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                            + "?Anio=" + Me.ddlAños.SelectedValue _
                            + "&IdMes=" + ddlMeses.SelectedValue.Replace("-", "_") _
                            + "&IdReporte=" + lblIdReporte.Text + "','CompeInstituc_" + Me.ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue.Replace("-", "_") + "'); return false;"
            Case "144" 'Reporte para la autorización de compensaciones (BLOQUE SELECCIONADO)
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                            + "?Anio=" + Me.ddlAños.SelectedValue _
                            + "&IdMes=" + ddlMeses.SelectedValue.Replace("-", "_") _
                            + "&InfComp=B" _
                            + "&IdReporte=" + lblIdReporte.Text + "','CompeAutBS_" + Me.ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue.Replace("-", "_") + "'); return false;"
            Case "137" 'Reporte para la autorización de compensaciones (GENERAL)
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                            + "?Anio=" + Me.ddlAños.SelectedValue _
                            + "&IdMes=" + ddlMeses.SelectedValue.Replace("-", "_") _
                            + "&InfComp=G" _
                            + "&IdReporte=" + lblIdReporte.Text + "','CompeAutGral_" + Me.ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue.Replace("-", "_") + "'); return false;"
            Case "138" 'Reporte para cuadrar compensaciones (GENERAL)
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                            + "?Anio=" + Me.ddlAños.SelectedValue _
                            + "&IdMes=" + ddlMeses.SelectedValue.Replace("-", "_") _
                            + "&InfComp=G" _
                            + "&IdReporte=" + lblIdReporte.Text + "','CompeCuadre_" + Me.ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue.Replace("-", "_") + "'); return false;"
            Case "145" 'Reporte para cuadrar compensaciones  (BLOQUE SELECCIONADO)
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                            + "?Anio=" + Me.ddlAños.SelectedValue _
                            + "&IdMes=" + ddlMeses.SelectedValue.Replace("-", "_") _
                            + "&InfComp=B" _
                            + "&IdReporte=" + lblIdReporte.Text + "','CompeCuadre_" + Me.ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue.Replace("-", "_") + "'); return false;"
            Case "147" 'Reporte para cuadrar compensaciones con adscripción (GENERAL)
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                            + "?Anio=" + Me.ddlAños.SelectedValue _
                            + "&IdMes=" + ddlMeses.SelectedValue.Replace("-", "_") _
                            + "&InfComp=G" _
                            + "&IdReporte=" + lblIdReporte.Text + "','CompeCuadre_" + Me.ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue.Replace("-", "_") + "'); return false;"
            Case "149" 'Reporte RESUMEN DE COMPENSACIONES DEL MES
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                            + "?Anio=" + ddlAños.SelectedValue _
                            + "&IdMes=" + ddlMeses.SelectedValue.Replace("-", "_") _
                            + "&InfComp=G" _
                            + "&IdReporte=" + lblIdReporte.Text + "','CompeResumen_" + Me.ddlAños.SelectedItem.Text + "_G'); return false;"
            Case "148" 'Reporte para cuadrar compensaciones con adscripción (BLOQUE SELECCIONADO)
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                            + "?Anio=" + Me.ddlAños.SelectedValue _
                            + "&IdMes=" + ddlMeses.SelectedValue.Replace("-", "_") _
                            + "&InfComp=B" _
                            + "&IdReporte=" + lblIdReporte.Text + "','CompeCuadre_" + Me.ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue.Replace("-", "_") + "'); return false;"
            Case "139" 'Reporte para la coniciliación de compensaciones
                'Me.ibImprimir.Visible = Me.lbMeses.SelectedValue.Substring(3, 1) = "0"
                Me.ibExportarExcel.Visible = ddlMeses.SelectedValue.Substring(3, 2) = "00"
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                            + "?Anio=" + Me.ddlAños.SelectedValue _
                            + "&IdMes=" + ddlMeses.SelectedValue.Replace("-", "_") _
                            + "&SoloAltas=False&SoloBajas=False&SoloIncDec=False" _
                            + "&IdReporte=" + lblIdReporte.Text + "','CompeConciliacion_" + Me.ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue.Replace("-", "_") + "'); return false;"
            Case "140" 'Reporte para impresión de recibos
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                            + "?Anio=" + Me.ddlAños.SelectedValue _
                            + "&Meses=" + Meses.Replace("-", "_") _
                            + "&IdReporte=" + lblIdReporte.Text + "','CompeRecibos_" + Me.ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue.Replace("-", "_") + "'); return false;"
            Case "141" 'Reporte para la coniciliación de compensaciones (Solo altas)
                'Me.ibImprimir.Visible = Me.lbMeses.SelectedValue.Substring(3, 1) = "0"
                'Me.ibExportarExcel.Visible = Me.lbMeses.SelectedValue.Substring(3, 1) = "0"
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                            + "?Anio=" + Me.ddlAños.SelectedValue _
                            + "&IdMes=" + ddlMeses.SelectedValue.Replace("-", "_") _
                            + "&SoloAltas=True&SoloBajas=False&SoloIncDec=False" _
                            + "&IdReporte=" + lblIdReporte.Text + "','CompeConciliacion_" + Me.ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue.Replace("-", "_") + "'); return false;"
            Case "142" 'Reporte para la coniciliación de compensaciones (Solo bajas)
                'Me.ibImprimir.Visible = Me.lbMeses.SelectedValue.Substring(3, 1) = "0"
                'Me.ibExportarExcel.Visible = Me.lbMeses.SelectedValue.Substring(3, 1) = "0"
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                            + "?Anio=" + Me.ddlAños.SelectedValue _
                            + "&IdMes=" + ddlMeses.SelectedValue.Replace("-", "_") _
                            + "&SoloAltas=False&SoloBajas=True&SoloIncDec=False" _
                            + "&IdReporte=" + lblIdReporte.Text + "','CompeConciliacion_" + Me.ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue.Replace("-", "_") + "'); return false;"
            Case "143" 'Reporte para la coniciliación de compensaciones (Solo inc/dec)
                'Me.ibImprimir.Visible = Me.lbMeses.SelectedValue.Substring(3, 1) = "0"
                'Me.ibExportarExcel.Visible = Me.lbMeses.SelectedValue.Substring(3, 1) = "0"
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                            + "?Anio=" + Me.ddlAños.SelectedValue _
                            + "&IdMes=" + ddlMeses.SelectedValue.Replace("-", "_") _
                            + "&SoloAltas=False&SoloBajas=False&SoloIncDec=True" _
                            + "&IdReporte=" + lblIdReporte.Text + "','CompeConciliacion_" + Me.ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue.Replace("-", "_") + "'); return false;"
            Case "152" 'CONCILIACIÓN DE COMPENSACIONES PARA RECURSOS FINANCIEROS (GENERAL)
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                            + "?Anio=" + Me.ddlAños.SelectedValue _
                            + "&IdMes=" + ddlMeses.SelectedValue.Replace("-", "_") _
                            + "&InfComp=G&ResumenPorNumAfect=False" _
                            + "&IdReporte=" + lblIdReporte.Text + "','CompeConcilRFGralSinNumAfect_" + Me.ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue.Replace("-", "_") + "'); return false;"
            Case "153" 'CONCILIACIÓN DE COMPENSACIONES PARA RECURSOS FINANCIEROS (BLOQUE SELECCIONADO)
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                            + "?Anio=" + Me.ddlAños.SelectedValue _
                            + "&IdMes=" + ddlMeses.SelectedValue.Replace("-", "_") _
                            + "&InfComp=B&ResumenPorNumAfect=False" _
                            + "&IdReporte=" + lblIdReporte.Text + "','CompeConcilRFBloqueSelSinNumAfect_" + Me.ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue.Replace("-", "_") + "'); return false;"
            Case "154" 'CONCILIACIÓN DE COMPENSACIONES PARA RECURSOS FINANCIEROS (POR NÚMERO DE AFECTACIÓN))
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                            + "?Anio=" + Me.ddlAños.SelectedValue _
                            + "&IdMes=" + ddlMeses.SelectedValue.Replace("-", "_") _
                            + "&InfComp=G&ResumenPorNumAfect=True" _
                            + "&IdReporte=" + lblIdReporte.Text + "','CompeConcilRFPorNumAfect_" + Me.ddlAños.SelectedItem.Text + "_" + ddlMeses.SelectedValue.Replace("-", "_") + "'); return false;"

        End Select
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
        BindgvReportes()
        Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
        CreaLinkParaImpresion(gvr)
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

    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, ByVal dt As DataTable, ByVal SelectedValue As String)
        ddl.DataSource = dt
        ddl.DataTextField = TextField
        ddl.DataValueField = ValueField
        ddl.DataBind()
        If SelectedValue Is Nothing = False Then ddl.SelectedValue = SelectedValue
    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then

            Dim oBanco As New Bancos
            BindddlAños()
            If Me.ddlAños.SelectedValue <> -1 Then
                BindddlMeses()
                BindgvCompensaciones()

                BindgvReportes()
                Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
                CreaLinkParaImpresion(gvr)
            End If
        End If
    End Sub

    Protected Sub btnConsultar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        BindgvCompensaciones()
        Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
        CreaLinkParaImpresion(gvr)
    End Sub

    Protected Sub ddlAños_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlAños.SelectedIndexChanged
        BindddlMeses()
    End Sub

    Protected Sub gvReportes_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvReportes.SelectedIndexChanged
        Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
        Dim oUsr As New Usuario
        Dim oReporte As New Reportes
        Dim drReporte As DataRow
        Dim vlIdReporte As Short = CShort(CType(gvr.FindControl("lblIdReporte"), Label).Text)

        If oUsr.EsAdministrador(Session("Login")) Or oUsr.EsVIP(Session("Login")) Then
            drReporte = oReporte.ObtenOpcionesVarias(vlIdReporte)
            pnlFchImpRpt.Visible = CBool(drReporte("PedirFechaDeImp"))

            Session.Remove("pFchImpRpt")
            txtbxFchImpRpt.Text = String.Empty
        End If

        CreaLinkParaImpresion(gvr)
    End Sub
    Protected Sub ddlMeses_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlMeses.SelectedIndexChanged
        BindgvCompensaciones()
        Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
        CreaLinkParaImpresion(gvr)
    End Sub
    Protected Sub txtbxFchImpRpt_TextChanged(sender As Object, e As System.EventArgs) Handles txtbxFchImpRpt.TextChanged
        If IsDate(txtbxFchImpRpt.Text.Trim) Then
            Session.Add("pFchImpRpt", txtbxFchImpRpt.Text)
        Else
            Session.Remove("pFchImpRpt")
        End If
    End Sub
End Class