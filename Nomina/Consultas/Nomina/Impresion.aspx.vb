Imports DataAccessLayer.COBAEV.Administracion
Imports DataAccessLayer.COBAEV.InformacionAcademica
Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV
Imports System.Data
Imports iTextSharp.text.pdf.parser
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO
Imports Microsoft.Reporting.WebForms
Partial Class ImpresionDeQuincenas
    Inherits System.Web.UI.Page
    Private Sub GeneraPDF(ByVal pIdReporte As Short, ByVal pIdQuincena As Short, ByVal pIdFondoPresup As Byte, ByVal pIdPlantel As Short)
        Dim rview As New ReportViewer
        Dim mimeType As String = String.Empty
        Dim encoding As String = String.Empty
        Dim extension As String = String.Empty
        Dim deviceInfo As String = String.Empty
        Dim streamids As String() = Nothing
        Dim warnings As Microsoft.Reporting.WebForms.Warning() = Nothing
        Dim format As String = "PDF"
        Dim paramList As New System.Collections.Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
        Dim bytes As Byte()
        Dim dt As DataTable
        Dim oReporte As New Reportes

        If Request.Params("SubTipoReporte") Is Nothing Then
            dt = oReporte.ObtenInfParaImpresion(pIdReporte)
        Else
            dt = oReporte.ObtenInfParaImpresion(pIdReporte, CByte(Request.Params("SubTipoReporte")))
        End If

        deviceInfo = "<DeviceInfo>" + "<SimplePageHeaders>True</SimplePageHeaders>" + "</DeviceInfo>"

        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("pIdQuincena", pIdQuincena.ToString))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("pIdFondoPresup", pIdFondoPresup.ToString))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("pstrPlanteles", pIdPlantel.ToString))

        If Session("pFchImpRpt") Is Nothing = False Then
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("pFchImpRpt", CDate(Session("pFchImpRpt"))))
        End If

        rview.ServerReport.ReportServerUrl = New Uri(ConfigurationManager.AppSettings("ServerReportes"))
        rview.ServerReport.ReportPath = "/Reportes/" + dt.Rows(0).Item("NombreReporte").ToString

        rview.ServerReport.SetParameters(paramList)
        bytes = rview.ServerReport.Render(format, deviceInfo, mimeType, encoding, extension, streamids, warnings)

        Dim vlDirs() As String
        Dim vlFile As String

        vlDirs = Directory.GetFiles(ConfigurationManager.AppSettings("RutaPagomatico"), "*.pdf")
        For Each vlFile In vlDirs
            If vlFile.Contains("NomIndice_" + pIdPlantel.ToString) Then File.Delete(vlFile)
        Next

        'If (file.Exists(ConfigurationManager.AppSettings("RutaPagomatico") + "NomIndice_" + _
        '                     pIdPlantel.ToString + "_" + pIdFondoPresup.ToString() + "_" + pIdQuincena.ToString + ".pdf")) Then
        '    file.Delete(ConfigurationManager.AppSettings("RutaPagomatico") + "NomIndice_" + _
        '                     pIdPlantel.ToString + "_" + pIdFondoPresup.ToString() + "_" + pIdQuincena.ToString + ".pdf")
        'End If

        Dim fs As New FileStream(ConfigurationManager.AppSettings("RutaPagomatico") + "NomIndice_" +
                             pIdPlantel.ToString + "_" + pIdFondoPresup.ToString() + "_" + pIdQuincena.ToString + ".pdf", FileMode.Create)
        fs.Write(bytes, 0, bytes.Length)
        fs.Close()
    End Sub
    Public Function SeparaPDFEnHojas(ByVal pNombreArchivo As String) As String()
        Dim vlPagina As Integer
        Dim vlPDFReader As PdfReader
        Dim vlTxtHoja As String
        Dim arrayHojas(1) As String

        If (File.Exists(pNombreArchivo)) Then
            vlPDFReader = New PdfReader(pNombreArchivo)
            ReDim arrayHojas(vlPDFReader.NumberOfPages - 1)

            For vlPagina = 1 To vlPDFReader.NumberOfPages Step 1
                Dim strategy As New SimpleTextExtractionStrategy()
                vlTxtHoja = PdfTextExtractor.GetTextFromPage(vlPDFReader, vlPagina, strategy)

                vlTxtHoja = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(vlTxtHoja)))
                arrayHojas(vlPagina - 1) = vlTxtHoja
            Next
            vlPDFReader.Close()
        Else
            arrayHojas(0) = ""
        End If
        Return arrayHojas
    End Function
    Private Sub BindgvReportes()
        Dim oAplic As New Aplicacion
        Dim drPagina As DataRow
        Dim oReporte As New Reportes

        Dim oUsr As New Usuario
        Dim dr As DataRow

        oUsr.Login = Session("Login")
        dr = oUsr.ObtenerPropiedadesDelRol().Rows(0)

        drPagina = oAplic.ObtenInfSobrePagina(Request.Url.Segments(Request.Url.Segments.Length - 1).ToString)
        Me.gvReportes.DataSource = oReporte.ObtenPorPagina(CShort(drPagina("IdPagina")), CByte(dr("IdRol")))
        Me.gvReportes.DataBind()

        If gvReportes.Rows.Count > 0 Then
            gvReportes.SelectedIndex = 0
        Else
            gvReportes.EmptyDataText = "Usuario sin permisos para utilizar los reportes disponibles en esta página."
            Me.gvReportes.DataBind()
        End If

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
                Me.btnConsultarQuincenas.Enabled = False
            Else
                Me.btnConsultarQuincenas.Enabled = True
            End If
        End With
    End Sub
    Private Sub BindddlMeses()
        Dim oQna As New Quincenas
        With Me.ddlMeses
            .DataSource = oQna.ObtenMesesCalculadosPorAnio(CShort(Me.ddlAños.SelectedValue))
            .DataTextField = "NombreMes"
            .DataValueField = "IdMes"
            .DataBind()
        End With
    End Sub
    Private Sub BindQuincenas()
        Dim oQna As New Quincenas
        Me.gvQuincenas.DataSource = oQna.ObtenCalculadasPorAnio(CShort(Me.ddlAños.SelectedValue))
        Me.gvQuincenas.DataBind()
        Me.lblMsj.Text = "Quincenas pagadas durante el año " + Me.ddlAños.SelectedItem.Text
        If Me.gvQuincenas.Rows.Count > 0 Then
            Me.gvQuincenas.SelectedIndex = 0
        End If
    End Sub
    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, ByVal dt As DataTable, Optional ByVal SelectedValue As String = "")
        ddl.DataSource = dt
        ddl.DataTextField = TextField
        ddl.DataValueField = ValueField
        ddl.DataBind()
        If SelectedValue <> String.Empty Then ddl.SelectedValue = SelectedValue
    End Sub
    Private Sub BindddlPlanteles_ZonasGeo(Optional ByVal pCargando As Boolean = False)
        Dim lblIdQuincena As Label = CType(Me.gvQuincenas.SelectedRow.FindControl("lblIdQuincena"), Label)
        Me.ddlPlanteles_ZonasGeo.Enabled = True
        Select Case Me.ddlTiposDeImpresion.SelectedValue
            Case "1"  'Planteles
                Me.pnlPlanteles_ZonasGeo.GroupingText = "Seleccione plantel"
                Me.pnlPlanteles_ZonasGeo.Visible = True
                Dim oPlantel As New Plantel
                If pCargando = True Then
                    LlenaDDL(Me.ddlPlanteles_ZonasGeo, "DescPlantel", "IdPlantel", oPlantel.ObtenParaPagoPorUsr(Session("Login")))
                    LlenaDDL(Me.ddlPlantelesPensionAlimenticia, "DescPlantel", "IdPlantel", oPlantel.ObtenParaImpDePensionAlimPorUsr(Session("Login"), CShort(lblIdQuincena.Text)))
                    If Me.ddlPlantelesPensionAlimenticia.Items.Count = 0 Then
                        Me.ddlPlantelesPensionAlimenticia.Items.Add(New WebControls.ListItem("No hay planteles con pensión alimenticia en la quincena seleccionada", "-1"))
                    End If
                End If
            Case "2" 'Zonas geográficas
                Me.pnlPlanteles_ZonasGeo.GroupingText = "Seleccione zona geográfica"
                Me.pnlPlanteles_ZonasGeo.Visible = True
                Dim oZonaGeo As New Zonageografica
                If pCargando = True Then
                    LlenaDDL(Me.ddlPlanteles_ZonasGeo, "NombreZonaGeografica", "IdZonaGeografica", oZonaGeo.ObtenPorUsuario(Session("Login")))
                    If Me.ddlPlanteles_ZonasGeo.Items.Count = 0 Then
                        Me.ddlPlanteles_ZonasGeo.Items.Add(New WebControls.ListItem("No hay zonas geográficas disponibles para el usuario.", "0"))
                    End If
                End If
            Case "3" 'Zonas económicas
                Me.pnlPlanteles_ZonasGeo.GroupingText = "Seleccione zona económica"
                Me.pnlPlanteles_ZonasGeo.Visible = True
                Dim oZonaEco As New ZonaEconomica
                If pCargando = True Then
                    LlenaDDL(Me.ddlPlanteles_ZonasGeo, "DescZonaEco", "IdZonaEco", oZonaEco.ObtenTodas())
                    ddlPlanteles_ZonasGeo.Items.Add(New WebControls.ListItem("EMSAD", "4"))
                End If
            Case Else
                Me.pnlPlanteles_ZonasGeo.Visible = False
        End Select
    End Sub
    Private Sub BindddlTipoDeNomina()
        Dim oQna As New Nomina
        LlenaDDL(Me.ddlTipoDeNomina, "DescFondoPresup", "IdFondoPresup", oQna.GetFondosPresupuestales())
    End Sub

    Private Sub BindddlTipoDeFuente()
        Dim oQna As New Nomina
        LlenaDDL(Me.ddlTipoDeFuente, "DescFondoPresup", "IdFondoPresup", oQna.GetFuentesFinanciamiento())

    End Sub
    Private Sub CreaLinkParaImpresion2(ByVal gvr As GridViewRow)
        Dim lblIdQuincena As Label = CType(Me.gvQuincenas.SelectedRow.FindControl("lblIdQuincena"), Label)
        Dim lblIdReporte As Label = CType(gvr.FindControl("lblIdReporte"), Label)
        'Dim lblImplicaMeses As Label = CType(gvr.FindControl("lblImplicaMeses"), Label)
        'Dim lblExportarAExcel As Label = CType(gvr.FindControl("lblExportarAExcel"), Label)



        Select Case lblIdReporte.Text
            Case "1", "123" 'Institucional de percepciones y deducciones
                Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                            + "?IdQuincena=" + lblIdQuincena.Text _
                            + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                            + "&IdReporte=" + lblIdReporte.Text + "','NominaInstitucional_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
            Case "161" 'Conciliación Financieros
                Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                            + "?IdQuincena=" + lblIdQuincena.Text _
                            + "&IdReporte=" + lblIdReporte.Text + "','NominaInstitucional_" + lblIdQuincena.Text.Replace("-", "") + "" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
            Case "3" 'Nómina
                Select Case Me.ddlTiposDeImpresion.SelectedValue
                    Case "0"
                        Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                                    + "?SubTipoReporte=0" _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                                    + "&IdReporte=" + lblIdReporte.Text + "','Nomina_Gral_" + lblIdQuincena.Text + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
                    Case "1" 'Planteles
                        Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                                    + "?SubTipoReporte=1" _
                                    + "&strPlanteles=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                                    + "&IdReporte=" + lblIdReporte.Text + "','Nomina_" + lblIdQuincena.Text.Replace("-", "_") + "_Plantel_" + Me.ddlPlanteles_ZonasGeo.SelectedValue + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
                    Case "2" 'Zonas geográficas
                        Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                                    + "?SubTipoReporte=2" _
                                    + "&IdZonaGeografica=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                                    + "&IdReporte=" + lblIdReporte.Text + "','" + "Nomina_ZG_" + Me.ddlPlanteles_ZonasGeo.SelectedValue + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
                End Select
            Case "9" 'Nómina pensión alimenticia
                Select Case Me.ddlTiposDeImpresion.SelectedValue
                    Case "0" 'Impresión general por fondo presupuestal
                        Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                                    + "?IdPlantel=" + Me.ddlPlantelesPensionAlimenticia.SelectedValue _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdReporte=" + lblIdReporte.Text + "','NominaPAGral_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
                    Case "1" 'Planteles
                        Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                                    + "?IdPlantel=" + Me.ddlPlantelesPensionAlimenticia.SelectedValue _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdReporte=" + lblIdReporte.Text + "','NominaPA_" + lblIdQuincena.Text.Replace("-", "_") + "_Plantel_" + Me.ddlPlantelesPensionAlimenticia.SelectedValue + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
                    Case "2" 'Impresión de todos los planteles de una zona geográfica y fondo presupuestal
                        Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                                    + "?IdPlantel=" + Me.ddlPlantelesPensionAlimenticia.SelectedValue _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdReporte=" + lblIdReporte.Text + "','NominaPAG_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlPlanteles_ZonasGeo.SelectedValue + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
                End Select
            Case "10" 'Recibos de nómina
                Select Case Me.ddlTiposDeImpresion.SelectedValue
                    Case "0" 'Impresión general por fondo presupuestal
                        Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                                    + "?SubTipoReporte=0" _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                                    + "&IdReporte=" + lblIdReporte.Text + "','RecibosNominaGral_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
                    Case "1" 'Impresión de un plantel y fondo presupuestal
                        Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                                    + "?SubTipoReporte=1" _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdPlantel=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                                    + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                                    + "&IdReporte=" + lblIdReporte.Text + "','RecibosNominaPlantel_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlPlanteles_ZonasGeo.SelectedValue + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
                    Case "2" 'Impresión de todos los planteles de una zona geográfica y fondo presupuestal
                        Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                                    + "?SubTipoReporte=2" _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdZonaGeografica=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                                    + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                                    + "&IdReporte=" + lblIdReporte.Text + "','RecibosNominaZG_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlPlanteles_ZonasGeo.SelectedValue + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
                End Select
            Case "11" 'Recibos de nómina de pensión alimenticia
                Select Case Me.ddlTiposDeImpresion.SelectedValue
                    Case "1" 'Planteles
                        Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                                    + "?IdPlantel=" + Me.ddlPlantelesPensionAlimenticia.SelectedValue(
                                    +"&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdReporte=" + lblIdReporte.Text + "','RecibosNominaPA_" + lblIdQuincena.Text.Replace("-", "_") + "_Plantel_" + Me.ddlPlantelesPensionAlimenticia.SelectedValue + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;")
                End Select
            Case "12" 'Institucional, todos los planteles
                Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                            + "?IdQuincena=" + lblIdQuincena.Text _
                            + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                            + "&IdReporte=" + lblIdReporte.Text + "','InstitucionalTP_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
            Case "14" 'Institucional, todos los planteles de una zona geográfica
                Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                            + "?IdQuincena=" + lblIdQuincena.Text _
                            + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                            + "&IdPlantel=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                            + "&IdReporte=" + lblIdReporte.Text + "','InstitucionalZG_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
            Case "13" 'Institucional, un solo plantel
                Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                            + "?IdPlantel=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                            + "&IdQuincena=" + lblIdQuincena.Text _
                            + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                            + "&IdReporte=" + lblIdReporte.Text + "','InstitucionalPlantel_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
            Case "19" 'Conciliaciones
                Select Case Me.ddlTiposDeImpresion.SelectedValue
                    Case "0" 'General
                        Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                                    + "?SubTipoReporte=0" _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdReporte=" + lblIdReporte.Text + "','Conc_" + lblIdQuincena.Text.Replace("-", "_") + "_Gral_" + Me.ddlPlanteles_ZonasGeo.SelectedValue + "'); return false;"
                    Case "1" 'Plantel
                        Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                                    + "?SubTipoReporte=1" _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdPlantel=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                                    + "&IdReporte=" + lblIdReporte.Text + "','Conc_" + lblIdQuincena.Text.Replace("-", "_") + "_Pl_" + Me.ddlPlanteles_ZonasGeo.SelectedValue + "'); return false;"

                    Case "2" 'Zona geográfica
                        Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                                    + "?SubTipoReporte=2" _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdZonaGeografica=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                                    + "&IdReporte=" + lblIdReporte.Text + "','Conc_" + lblIdQuincena.Text.Replace("-", "_") + "_ZG_" + Me.ddlPlanteles_ZonasGeo.SelectedValue + "'); return false;"

                End Select
            Case "21" 'Concentrado de Conciliaciones
                Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                            + "?IdQuincena=" + lblIdQuincena.Text _
                            + "&IdReporte=" + lblIdReporte.Text + "','ConcentradoConciliacion_" + lblIdQuincena.Text.Replace("-", "_") + "'); return false;"
            Case "22" 'Resúmen de Conciliaciones
                Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                            + "?IdQuincena=" + lblIdQuincena.Text _
                            + "&IdReporte=" + lblIdReporte.Text + "','ResumenConciliacion_" + lblIdQuincena.Text.Replace("-", "_") + "'); return false;"
            Case "24"
                Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                                + "?Anio=" + Me.ddlAños.SelectedItem.Text _
                                + "&IdMes=" + Me.ddlMeses.SelectedValue _
                                + "&IdReporte=" + lblIdReporte.Text + "','ProvDosPorcNomina_" + Me.ddlAños.SelectedItem.Text + "_" + Me.ddlMeses.SelectedValue + "'); return false;"
                Me.ibExportarExcel.Visible = CShort(ddlAños.SelectedItem.Text) <= 2013
            Case "25"
                Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                    + "?Anio=" + Me.ddlAños.SelectedItem.Text _
                    + "&IdMes=" + Me.ddlMeses.SelectedValue _
                    + "&IdQuincena=" + lblIdQuincena.Text _
                    + "&IdReporte=" + lblIdReporte.Text + "','ProvDosPorcNomina_" + lblIdQuincena.Text.Replace("-", "_") + "'); return false;"
                Me.ibExportarExcel.Visible = CShort(ddlAños.SelectedItem.Text) <= 2013
            Case "29" 'Institucional, Recibos
                Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                            + "?IdQuincena=" + lblIdQuincena.Text _
                            + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                            + "&IdReporte=" + lblIdReporte.Text + "','InstitucionalRecibos_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
            Case "30" 'Institucional, devoluciones
                Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                            + "?IdQuincena=" + lblIdQuincena.Text _
                            + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                            + "&IdReporte=" + lblIdReporte.Text + "','InstitucionalDevoluciones_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
            Case "157" 'Afectaciones contables
                Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                            + "?IdQuincena=" + lblIdQuincena.Text _
                            + "&IdFondoPresup=" + Me.ddlTipoDeFuente.SelectedValue _
                            + "&IdFecha=NULL" _
                            + "&IdConcepto=NULL" _
                            + "&IdReporte=" + lblIdReporte.Text + "','Afectacion_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlTipoDeFuente.SelectedValue + "'); return false;"
            Case "94" 'Provisión del 2% a la nómina, anual
                Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                    + "?Anio=" + Me.ddlAños.SelectedItem.Text _
                    + "&IdReporte=" + lblIdReporte.Text + "','ProvDosPorcNominaAnual_" + Me.ddlAños.SelectedItem.Text + "'); return false;"
                Me.ibExportarExcel.Visible = CShort(ddlAños.SelectedItem.Text) <= 2013
            Case "95" 'Recibos de nómina con formato
                Select Case Me.ddlTiposDeImpresion.SelectedValue
                    Case "0" 'Impresión general por fondo presupuestal
                        Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                                    + "?SubTipoReporte=0" _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                                    + "&IdReporte=" + lblIdReporte.Text + "','RecibosNominaGralFormato_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
                    Case "1" 'Impresión de un plantel y fondo presupuestal
                        Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                                    + "?SubTipoReporte=1" _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdPlantel=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                                    + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                                    + "&IdReporte=" + lblIdReporte.Text + "','RecibosNominaPlantelFormato_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlPlanteles_ZonasGeo.SelectedValue + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
                    Case "2" 'Impresión de todos los planteles de una zona geográfica y fondo presupuestal
                        Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                                    + "?SubTipoReporte=2" _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdZonaGeografica=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                                    + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                                    + "&IdReporte=" + lblIdReporte.Text + "','RecibosNominaZGFormato_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlPlanteles_ZonasGeo.SelectedValue + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
                End Select
            Case "99" 'Nómina, para generar índice
                Dim dtEmps As DataTable
                Dim oNomina As New Nomina
                Dim arrayHojasNomina() As String
                dtEmps = oNomina.ObtenEmpsParaGenerarIndice(CShort(lblIdQuincena.Text), CByte(Me.ddlTipoDeNomina.SelectedValue), CShort(Me.ddlPlanteles_ZonasGeo.SelectedValue))
                GeneraPDF(3, CShort(lblIdQuincena.Text), CByte(Me.ddlTipoDeNomina.SelectedValue), CShort(Me.ddlPlanteles_ZonasGeo.SelectedValue))
                arrayHojasNomina = SeparaPDFEnHojas(ConfigurationManager.AppSettings("RutaPagomatico") + "NomIndice_" +
                                         Me.ddlPlanteles_ZonasGeo.SelectedValue + "_" + Me.ddlTipoDeNomina.SelectedValue + "_" +
                                         lblIdQuincena.Text + ".pdf")

                For Each drEmp As DataRow In dtEmps.Rows
                    For Hoja As Short = 0 To arrayHojasNomina.Length - 1
                        If arrayHojasNomina(Hoja).Contains(drEmp("RFCEmp")) Then
                            oNomina.InsertaEnNominaIndice(CShort(lblIdQuincena.Text), CByte(Me.ddlTipoDeNomina.SelectedValue), Hoja + 1, CInt(drEmp("IdEmp")))
                            Exit For
                        End If
                    Next
                Next

                Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                            + "?IdPlantel=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                            + "&IdQuincena=" + lblIdQuincena.Text _
                            + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                            + "&IdReporte=" + lblIdReporte.Text + "','NominaIndice_Pl_" + Me.ddlPlanteles_ZonasGeo.SelectedValue + "Qna_" + lblIdQuincena.Text.Replace("-", "_") + "_FP_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"

            Case "101" 'Nómina quincenal desglosada en Estatal y Federal (Cheques)
                Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                            + "?IdQuincena=" + lblIdQuincena.Text _
                            + "&IdReporte=" + lblIdReporte.Text + "','NomQnalDesgEnEstyFed_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
            Case "104"
                Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                                + "?Anio=" + Me.ddlAños.SelectedItem.Text _
                                + "&IdMes=" + Me.ddlMeses.SelectedValue _
                                + "&IdReporte=" + lblIdReporte.Text + "','ProvTresPorcNomina_" + Me.ddlAños.SelectedItem.Text + "_" + Me.ddlMeses.SelectedValue + "'); return false;"
                Me.ibExportarExcel.Visible = CShort(ddlAños.SelectedItem.Text) >= 2014
            Case "105"
                Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                    + "?Anio=" + Me.ddlAños.SelectedItem.Text _
                    + "&IdMes=" + Me.ddlMeses.SelectedValue _
                    + "&IdQuincena=" + lblIdQuincena.Text _
                    + "&IdReporte=" + lblIdReporte.Text + "','ProvTresPorcNomina_" + lblIdQuincena.Text.Replace("-", "_") + "'); return false;"
                Me.ibExportarExcel.Visible = CShort(ddlAños.SelectedItem.Text) >= 2014
            Case "106" 'Provisión del 3% a la nómina, anual
                Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                    + "?Anio=" + Me.ddlAños.SelectedItem.Text _
                    + "&IdReporte=" + lblIdReporte.Text + "','ProvTresPorcNominaAnual_" + Me.ddlAños.SelectedItem.Text + "'); return false;"
                Me.ibExportarExcel.Visible = CShort(ddlAños.SelectedItem.Text) >= 2014
            Case "164" 'CFDI
                Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                    + "?Anio=" + Me.ddlAños.SelectedItem.Text _
                    + "&IdMes=" + Me.ddlMeses.SelectedValue _
                    + "&OrigenRecurso=" + Me.ddlOrigenRecurso.SelectedValue _
                    + "&IdTipoNomina=" + Me.ddlTipoDeNomina.SelectedValue _
                    + "&IdPlantel=" + Me.ddlPlanteles_ZonasGeo.SelectedValue + "'" _
                    + "&IdReporte=" + lblIdReporte.Text + "'); return false;"
                Me.ibExportarExcel.Visible = CShort(ddlAños.SelectedItem.Text) >= 2014
            Case "173" 'nomina por categorias
                Dim myByte As Byte() = System.Text.Encoding.UTF8.GetBytes(If(ddlTipoConsulta.SelectedValue = "A", "&tc=A&Anio=" + Me.ddlAños.SelectedItem.Text + "&IdMes=" + Me.ddlMeses.SelectedValue, "") _
                    + If(ddlTipoConsulta.SelectedValue = "M", "&tc=M&Anio=" + Me.ddlAños.SelectedItem.Text + "&IdMes=" + Me.ddlMeses.SelectedValue, "") _
                    + If(ddlTipoConsulta.SelectedValue = "Q", "&tc=Q&IdQuincena=" + lblIdQuincena.Text, ""))
                '+ "&IdTipoFuente=" + Me.ddlTipoDeFuente.SelectedValue _
                '+ If(ddlTiposDeImpresion.SelectedValue = 1, "&IdPlantel=" + Me.ddlPlanteles_ZonasGeo.SelectedValue, "") _
                '+ If(ddlTiposDeImpresion.SelectedValue = 2, "&IdZonaGeografica=" + Me.ddlPlanteles_ZonasGeo.SelectedValue, "") _
                '+ If(ddlTiposDeImpresion.SelectedValue = 3, "&IdZonaEconomica=" + Me.ddlPlanteles_ZonasGeo.SelectedValue, "")

                '+ "&IdTipoNomina=" + Me.ddlTipoDeNomina.SelectedValue _
                Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                            + "?binario=1&IdReporte=173&parametros=" + Convert.ToBase64String(myByte) + "'); return false;"
                Me.ibExportarExcel.Visible = CShort(ddlAños.SelectedItem.Text) >= 2014
        End Select
    End Sub
    Private Sub CreaLinkParaImpresion(ByVal gvr As GridViewRow, Optional ByVal pFchImpRpt As String = "")

        If gvr Is Nothing Then Exit Sub

        Dim lblIdQuincena As Label = CType(Me.gvQuincenas.SelectedRow.FindControl("lblIdQuincena"), Label)
        Dim lblIdReporte As Label = CType(gvr.FindControl("lblIdReporte"), Label)
        Dim lblImplicaMeses As Label = CType(gvr.FindControl("lblImplicaMeses"), Label)
        Dim lblExportarAExcel As Label = CType(gvr.FindControl("lblExportarAExcel"), Label)
        Dim lblExportarAPDF As Label = CType(gvr.FindControl("lblExportarAPDF"), Label)
        Dim lblImplicaQuincenas As Label = CType(gvr.FindControl("lblImplicaQuincenas"), Label)
        Dim lblImplicaFondoPresup As Label = CType(gvr.FindControl("lblImplicaFondoPresup"), Label)
        Dim lblImplicaPlantel As Label = CType(gvr.FindControl("lblImplicaPlantel"), Label)
        'Dim strOnClientClick As String = String.Empty

        Me.pnlMeses.Enabled = CType(lblImplicaMeses.Text, Boolean)
        Me.ibImprimir.Visible = CType(lblExportarAPDF.Text, Boolean)
        Me.ibExportarExcel.Visible = CType(lblExportarAExcel.Text, Boolean)
        If CType(lblExportarAExcel.Text, Boolean) Then
            CreaLinkParaImpresion2(gvr)
        End If
        Me.lblMsj.Enabled = CType(lblImplicaQuincenas.Text, Boolean)
        Me.gvQuincenas.Enabled = CType(lblImplicaQuincenas.Text, Boolean)
        Me.pnlTipoDeNomina.Enabled = CType(lblImplicaFondoPresup.Text, Boolean)
        Me.pnlOpcDeImpresion.Enabled = CType(lblImplicaPlantel.Text, Boolean)
        Me.pnlPlanteles_ZonasGeo.Enabled = CType(lblImplicaPlantel.Text, Boolean)
        Me.pnlTipoDeFF.Visible = False
        'Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx"
        'Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx"

        'If CType(lblImplicaQuincenas.Text, Boolean) Then
        '    strOnClientClick = "?IdQuincena=" + lblIdQuincena.Text
        'End If

        Me.ddlPlanteles_ZonasGeo.Visible = True
        Me.ddlPlantelesPensionAlimenticia.Visible = False
        Me.ddlTipoConsulta.Visible = False
        Me.lblTipoConsulta.Visible = False

        Select Case lblIdReporte.Text
            Case "1", "123" 'Institucional de percepciones y deducciones
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                            + "?IdQuincena=" + lblIdQuincena.Text _
                            + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                            + "&IdReporte=" + lblIdReporte.Text + "','NominaInstitucional_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
            Case "3" 'Nómina
                Select Case Me.ddlTiposDeImpresion.SelectedValue
                    Case "0"
                        Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                                    + "?SubTipoReporte=0" _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                                    + "&IdReporte=" + lblIdReporte.Text + "','Nomina_Gral_" + lblIdQuincena.Text + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
                    Case "1" 'Planteles
                        Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                                    + "?SubTipoReporte=1" _
                                    + "&strPlanteles=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                                    + "&IdReporte=" + lblIdReporte.Text + "','Nomina_" + lblIdQuincena.Text.Replace("-", "_") + "_Plantel_" + Me.ddlPlanteles_ZonasGeo.SelectedValue + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
                    Case "2" 'Zonas geográficas
                        Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                                    + "?SubTipoReporte=2" _
                                    + "&IdZonaGeografica=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                                    + "&IdReporte=" + lblIdReporte.Text + "','" + "Nomina_ZG_" + Me.ddlPlanteles_ZonasGeo.SelectedValue + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
                End Select
            Case "9" 'Nómina pensión alimenticia
                Me.ibImprimir.Visible = Me.ddlPlantelesPensionAlimenticia.SelectedValue <> "-1" And CType(lblExportarAPDF.Text, Boolean)
                Me.ibExportarExcel.Visible = Me.ddlPlantelesPensionAlimenticia.SelectedValue <> "-1" And CType(lblExportarAExcel.Text, Boolean)
                Select Case Me.ddlTiposDeImpresion.SelectedValue
                    Case "0" 'Impresión general por quincena
                        Me.ddlPlanteles_ZonasGeo.Visible = False
                        Me.ddlPlantelesPensionAlimenticia.Visible = False
                        Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                                    + "?SubTipoReporte=0" _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdReporte=" + lblIdReporte.Text + "','NominaPAGral_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
                    Case "1" 'Planteles
                        Me.ddlPlanteles_ZonasGeo.Visible = False
                        Me.ddlPlantelesPensionAlimenticia.Visible = True
                        Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                                    + "?SubTipoReporte=1" _
                                    + "&IdPlantel=" + Me.ddlPlantelesPensionAlimenticia.SelectedValue _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdReporte=" + lblIdReporte.Text + "','NominaPA_" + lblIdQuincena.Text.Replace("-", "_") + "_Pl_" + Me.ddlPlantelesPensionAlimenticia.SelectedValue + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
                    Case "2" 'Impresión de todos los planteles de una zona geográfica
                        Me.ddlPlanteles_ZonasGeo.Visible = True
                        Me.ddlPlantelesPensionAlimenticia.Visible = False
                        Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                                    + "?SubTipoReporte=2" _
                                    + "&IdZonaGeografica=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdReporte=" + lblIdReporte.Text + "','NominaPA_" + lblIdQuincena.Text.Replace("-", "_") + "_ZG_" + Me.ddlPlanteles_ZonasGeo.SelectedValue + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
                End Select
            Case "10" 'Recibos de nómina
                Select Case Me.ddlTiposDeImpresion.SelectedValue
                    Case "0" 'Impresión general por fondo presupuestal
                        Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                                    + "?SubTipoReporte=0" _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                                    + "&IdReporte=" + lblIdReporte.Text + "','RecibosNominaGral_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
                    Case "1" 'Impresión de un plantel y fondo presupuestal
                        Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                                    + "?SubTipoReporte=1" _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdPlantel=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                                    + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                                    + "&IdReporte=" + lblIdReporte.Text + "','RecibosNominaPlantel_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlPlanteles_ZonasGeo.SelectedValue + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
                    Case "2" 'Impresión de todos los planteles de una zona geográfica y fondo presupuestal
                        Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                                    + "?SubTipoReporte=2" _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdZonaGeografica=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                                    + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                                    + "&IdReporte=" + lblIdReporte.Text + "','RecibosNominaZG_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlPlanteles_ZonasGeo.SelectedValue + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
                End Select
            Case "11" 'Recibos de nómina de pensión alimenticia
                Me.ddlPlanteles_ZonasGeo.Visible = False
                Me.ddlPlantelesPensionAlimenticia.Visible = True
                Me.ibImprimir.Visible = Me.ddlPlantelesPensionAlimenticia.SelectedValue <> "-1" And CType(lblExportarAPDF.Text, Boolean)
                Me.ibExportarExcel.Visible = Me.ddlPlantelesPensionAlimenticia.SelectedValue <> "-1" And CType(lblExportarAExcel.Text, Boolean)
                Select Case Me.ddlTiposDeImpresion.SelectedValue
                    Case "1" 'Planteles
                        Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                                    + "?IdPlantel=" + Me.ddlPlantelesPensionAlimenticia.SelectedValue _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdReporte=" + lblIdReporte.Text + "','RecibosNominaPA_" + lblIdQuincena.Text.Replace("-", "_") + "_Plantel_" + Me.ddlPlantelesPensionAlimenticia.SelectedValue + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
                End Select
            Case "12" 'Institucional, todos los planteles
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                            + "?IdQuincena=" + lblIdQuincena.Text _
                            + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                            + "&IdReporte=" + lblIdReporte.Text + "','InstitucionalTP_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
            Case "14" 'Institucional, todos los planteles de una zona geográfica
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                            + "?IdQuincena=" + lblIdQuincena.Text _
                            + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                            + "&IdPlantel=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                            + "&IdReporte=" + lblIdReporte.Text + "','InstitucionalZG_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
            Case "13" 'Institucional, un solo plantel
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                            + "?IdPlantel=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                            + "&IdQuincena=" + lblIdQuincena.Text _
                            + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                            + "&IdReporte=" + lblIdReporte.Text + "','InstitucionalPlantel_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
            Case "19" 'Conciliaciones
                Select Case Me.ddlTiposDeImpresion.SelectedValue
                    Case "0" 'General
                        Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                                    + "?SubTipoReporte=0" _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdReporte=" + lblIdReporte.Text + "','Conc_" + lblIdQuincena.Text.Replace("-", "_") + "_Gral_" + Me.ddlPlanteles_ZonasGeo.SelectedValue + "'); return false;"
                    Case "1" 'Plantel
                        Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                                    + "?SubTipoReporte=1" _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdPlantel=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                                    + "&IdReporte=" + lblIdReporte.Text + "','Conc_" + lblIdQuincena.Text.Replace("-", "_") + "_Pl_" + Me.ddlPlanteles_ZonasGeo.SelectedValue + "'); return false;"

                    Case "2" 'Zona geográfica
                        Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                                    + "?SubTipoReporte=2" _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdZonaGeografica=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                                    + "&IdReporte=" + lblIdReporte.Text + "','Conc_" + lblIdQuincena.Text.Replace("-", "_") + "_ZG_" + Me.ddlPlanteles_ZonasGeo.SelectedValue + "'); return false;"

                End Select
                'Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                '            + "?IdQuincena=" + lblIdQuincena.Text _
                '            + "&IdPlantel=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                '            + "&IdReporte=" + lblIdReporte.Text + "','Conciliacion_" + lblIdQuincena.Text.Replace("-", "_") + "_Plantel_" + Me.ddlPlanteles_ZonasGeo.SelectedValue + "'); return false;"
            Case "21" 'Concentrado de Conciliaciones
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                            + "?IdQuincena=" + lblIdQuincena.Text _
                            + "&IdReporte=" + lblIdReporte.Text + "','ConcentradoConciliacion_" + lblIdQuincena.Text.Replace("-", "_") + "'); return false;"
            Case "22" 'Resúmen de Conciliaciones
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                            + "?IdQuincena=" + lblIdQuincena.Text _
                            + "&IdReporte=" + lblIdReporte.Text + "','ResumenConciliacion_" + lblIdQuincena.Text.Replace("-", "_") + "'); return false;"
            Case "24" 'Provisión del 2% a la nómina, quincenal
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                                + "?Anio=" + Me.ddlAños.SelectedItem.Text _
                                + "&IdMes=" + Me.ddlMeses.SelectedValue _
                                + "&IdReporte=" + lblIdReporte.Text + "','ProvDosPorcNomina_" + Me.ddlAños.SelectedItem.Text + "_" + Me.ddlMeses.SelectedValue + "'); return false;"
                Me.ibImprimir.Visible = CShort(ddlAños.SelectedItem.Text) <= 2013
            Case "25" 'Provisión del 2% a la nómina, quincenal
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                    + "?Anio=" + Me.ddlAños.SelectedItem.Text _
                    + "&IdMes=" + Me.ddlMeses.SelectedValue _
                    + "&IdQuincena=" + lblIdQuincena.Text _
                    + "&IdReporte=" + lblIdReporte.Text + "','ProvDosPorcNomina_" + lblIdQuincena.Text.Replace("-", "_") + "'); return false;"
                Me.ibImprimir.Visible = CShort(ddlAños.SelectedItem.Text) <= 2013
            Case "29" 'Institucional, Recibos
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                            + "?IdQuincena=" + lblIdQuincena.Text _
                            + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                            + "&IdReporte=" + lblIdReporte.Text + "','InstitucionalRecibos_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
            Case "30" 'Institucional, devoluciones
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                            + "?IdQuincena=" + lblIdQuincena.Text _
                            + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                            + "&IdReporte=" + lblIdReporte.Text + "','InstitucionalDevoluciones_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
            Case "157" 'Afectaciones contables
                Me.pnlTipoDeFF.Visible = True
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                            + "?IdQuincena=" + lblIdQuincena.Text _
                            + "&IdFondoPresup=" + Me.ddlTipoDeFuente.SelectedValue _
                            + "&IdFecha=NULL" _
                            + "&IdConcepto=NULL" _
                            + "&IdReporte=" + lblIdReporte.Text + "','Afectacion_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlTipoDeFuente.SelectedValue + "'); return false;"

            Case "94" 'Provisión del 2% a la nómina, anual
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                    + "?Anio=" + Me.ddlAños.SelectedItem.Text _
                    + "&IdReporte=" + lblIdReporte.Text + "','ProvDosPorcNominaAnual_" + Me.ddlAños.SelectedItem.Text + "'); return false;"
                Me.ibImprimir.Visible = CShort(ddlAños.SelectedItem.Text) <= 2013
            Case "95" 'Recibos de nómina con formato
                Select Case Me.ddlTiposDeImpresion.SelectedValue
                    Case "0" 'Impresión general por fondo presupuestal
                        Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                                    + "?SubTipoReporte=0" _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                                    + "&IdReporte=" + lblIdReporte.Text + "','RecibosNominaGralFormato_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
                    Case "1" 'Impresión de un plantel y fondo presupuestal
                        Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                                    + "?SubTipoReporte=1" _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdPlantel=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                                    + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                                    + "&IdReporte=" + lblIdReporte.Text + "','RecibosNominaPlantelFormato_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlPlanteles_ZonasGeo.SelectedValue + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
                    Case "2" 'Impresión de todos los planteles de una zona geográfica y fondo presupuestal
                        Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                                    + "?SubTipoReporte=2" _
                                    + "&IdQuincena=" + lblIdQuincena.Text _
                                    + "&IdZonaGeografica=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                                    + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                                    + "&IdReporte=" + lblIdReporte.Text + "','RecibosNominaZGFormato_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlPlanteles_ZonasGeo.SelectedValue + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
                End Select
            Case "99" 'Nómina, para generar índice
                Dim dtEmps As DataTable
                Dim oNomina As New Nomina
                Dim arrayHojasNomina() As String
                dtEmps = oNomina.ObtenEmpsParaGenerarIndice(CShort(lblIdQuincena.Text), CByte(Me.ddlTipoDeNomina.SelectedValue), CShort(Me.ddlPlanteles_ZonasGeo.SelectedValue))
                GeneraPDF(3, CShort(lblIdQuincena.Text), CByte(Me.ddlTipoDeNomina.SelectedValue), CShort(Me.ddlPlanteles_ZonasGeo.SelectedValue))
                arrayHojasNomina = SeparaPDFEnHojas(ConfigurationManager.AppSettings("RutaPagomatico") + "NomIndice_" +
                                         Me.ddlPlanteles_ZonasGeo.SelectedValue + "_" + Me.ddlTipoDeNomina.SelectedValue + "_" +
                                         lblIdQuincena.Text + ".pdf")

                For Each drEmp As DataRow In dtEmps.Rows
                    For Hoja As Short = 0 To arrayHojasNomina.Length - 1
                        If arrayHojasNomina(Hoja).Contains(drEmp("RFCEmp")) Then
                            oNomina.InsertaEnNominaIndice(CShort(lblIdQuincena.Text), CByte(Me.ddlTipoDeNomina.SelectedValue), Hoja + 1, CInt(drEmp("IdEmp")))
                            Exit For
                        End If
                    Next
                Next

                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                            + "?IdPlantel=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                            + "&IdQuincena=" + lblIdQuincena.Text _
                            + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                            + "&IdReporte=" + lblIdReporte.Text + "','NominaIndice_Pl_" + Me.ddlPlanteles_ZonasGeo.SelectedValue + "Qna_" + lblIdQuincena.Text.Replace("-", "_") + "_FP_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
            Case "101" 'Nómina quincenal desglosada en Estatal y Federal (Cheques)
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                            + "?IdQuincena=" + lblIdQuincena.Text _
                            + "&IdReporte=" + lblIdReporte.Text + "','NomQnalDesgEnEstyFed_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
            Case "104" 'Provisión del 3% a la nómina, quincenal
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                                + "?Anio=" + Me.ddlAños.SelectedItem.Text _
                                + "&IdMes=" + Me.ddlMeses.SelectedValue _
                                + "&IdReporte=" + lblIdReporte.Text + "','ProvTresPorcNomina_" + Me.ddlAños.SelectedItem.Text + "_" + Me.ddlMeses.SelectedValue + "'); return false;"
                Me.ibImprimir.Visible = CShort(ddlAños.SelectedItem.Text) >= 2014
            Case "105" 'Provisión del 3% a la nómina, quincenal
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                    + "?Anio=" + Me.ddlAños.SelectedItem.Text _
                    + "&IdMes=" + Me.ddlMeses.SelectedValue _
                    + "&IdQuincena=" + lblIdQuincena.Text _
                    + "&IdReporte=" + lblIdReporte.Text + "','ProvTresPorcNomina_" + lblIdQuincena.Text.Replace("-", "_") + "'); return false;"
                Me.ibImprimir.Visible = CShort(ddlAños.SelectedItem.Text) >= 2014
            Case "106" 'Provisión del 3% a la nómina, anual
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                    + "?Anio=" + Me.ddlAños.SelectedItem.Text _
                    + "&IdReporte=" + lblIdReporte.Text + "','ProvTresPorcNominaAnual_" + Me.ddlAños.SelectedItem.Text + "'); return false;"
                Me.ibImprimir.Visible = CShort(ddlAños.SelectedItem.Text) >= 2014
            Case "173" 'nomina por categorias
                Dim oUsr As New Usuario
                Me.ddlTipoConsulta.Visible = True
                Me.lblTipoConsulta.Visible = True
        End Select
    End Sub

    Protected Sub gvQuincenas_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvQuincenas.RowCommand
        Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
        CreaLinkParaImpresion(gvr)
    End Sub

    Protected Sub gvQuincenas_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvQuincenas.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvQuincenas, "Select$" + e.Row.RowIndex.ToString)
        End Select
    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            BindddlAños()
            If Me.ddlAños.SelectedValue <> -1 Then
                BindddlMeses()
                BindQuincenas()
                BindddlPlanteles_ZonasGeo(True)
                BindddlTipoDeNomina()
                BindddlTipoDeFuente()
                BindgvReportes()

                Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
                CreaLinkParaImpresion(gvr)

            End If
        End If
    End Sub

    Protected Sub btnConsultarQuincenas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultarQuincenas.Click
        BindddlMeses()
        BindQuincenas()

        Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
        CreaLinkParaImpresion(gvr)

    End Sub

    Protected Sub ddlTiposDeImpresion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlTiposDeImpresion.SelectedIndexChanged
        BindddlPlanteles_ZonasGeo(True)

        Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
        CreaLinkParaImpresion(gvr)
    End Sub

    Protected Sub ddlTipoDeNomina_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
        CreaLinkParaImpresion(gvr)
    End Sub


    Protected Sub ddlTipoDeFuente_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
        CreaLinkParaImpresion(gvr)
    End Sub

    Protected Sub ddlPlanteles_ZonasGeo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
        CreaLinkParaImpresion(gvr)
    End Sub

    Protected Sub gvQuincenas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvQuincenas.SelectedIndexChanged
        Dim lblIdQuincena As Label = CType(Me.gvQuincenas.SelectedRow.FindControl("lblIdQuincena"), Label)
        Dim oPlantel As New Plantel
        LlenaDDL(Me.ddlPlantelesPensionAlimenticia, "DescPlantel", "IdPlantel", oPlantel.ObtenParaImpDePensionAlimPorUsr(Session("Login"), CShort(lblIdQuincena.Text)))
        If Me.ddlPlantelesPensionAlimenticia.Items.Count = 0 Then
            Me.ddlPlantelesPensionAlimenticia.Items.Add(New WebControls.ListItem("No hay planteles con pensión alimenticia en la quincena seleccionada", "-1"))
        End If

        Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
        CreaLinkParaImpresion(gvr)
    End Sub

    Protected Sub gvReportes_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvReportes.SelectedIndexChanged
        Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
        Dim oUsr As New Usuario
        Dim oReporte As New Reportes
        Dim drReporte As DataRow
        Dim itemSel As String

        Dim vlIdReporte As Short = CShort(CType(gvr.FindControl("lblIdReporte"), Label).Text)

        If oUsr.EsAdministrador(Session("Login")) Or oUsr.EsVIP(Session("Login")) Then
            drReporte = oReporte.ObtenOpcionesVarias(vlIdReporte)
            pnlFchImpRpt.Visible = CBool(drReporte("PedirFechaDeImp"))

            Session.Remove("pFchImpRpt")
            txtbxFchImpRpt.Text = String.Empty
        End If

        itemSel = Me.ddlTiposDeImpresion.SelectedValue

        Me.pnlOrigenRecurso.Visible = False
        If CType(gvr.FindControl("lblIdReporte"), Label).Text = "3" Or CType(gvr.FindControl("lblIdReporte"), Label).Text = "9" _
                Or CType(gvr.FindControl("lblIdReporte"), Label).Text = "10" _
                Or CType(gvr.FindControl("lblIdReporte"), Label).Text = "95" _
                Or CType(gvr.FindControl("lblIdReporte"), Label).Text = "19" Then
            Me.ddlTiposDeImpresion.Items(0).Enabled = oUsr.EsAdministrador(Session("Login")) Or oUsr.EsEnlaceContable(Session("Login"))
            Me.ddlTiposDeImpresion.Items(2).Enabled = True
            If itemSel <> Me.ddlTiposDeImpresion.SelectedValue Then
                BindddlPlanteles_ZonasGeo(True)
            Else
                BindddlPlanteles_ZonasGeo()
            End If
        ElseIf CType(gvr.FindControl("lblIdReporte"), Label).Text = "164" Then
            Me.pnlOrigenRecurso.Visible = True
        ElseIf CType(gvr.FindControl("lblIdReporte"), Label).Text = "173" Then
            Me.ddlTipoDeFuente.Items(0).Enabled = False
            Me.ddlTipoDeFuente.Items(1).Enabled = False
        Else
            Me.ddlTiposDeImpresion.Items(0).Enabled = False
            Me.ddlTiposDeImpresion.Items(2).Enabled = False
            Me.ddlTiposDeImpresion.Items(0).Selected = False
            Me.ddlTiposDeImpresion.Items(2).Selected = False
            Me.ddlTiposDeImpresion.Items(1).Selected = True

            Me.ddlTipoDeFuente.Items(0).Enabled = True
            Me.ddlTipoDeFuente.Items(1).Enabled = True

            If itemSel <> Me.ddlTiposDeImpresion.SelectedValue Then
                BindddlPlanteles_ZonasGeo(True)
            Else
                BindddlPlanteles_ZonasGeo()
            End If
        End If

        CreaLinkParaImpresion(gvr)
    End Sub

    Protected Sub ddlMeses_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlMeses.SelectedIndexChanged
        Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
        CreaLinkParaImpresion(gvr)
    End Sub

    Protected Sub chbxPrioridadQna_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
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
    Protected Sub ddlOrigenRecurso_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlOrigenRecurso.SelectedIndexChanged
        Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
        CreaLinkParaImpresion(gvr)
    End Sub

    Protected Sub ddlTipoConsulta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlTipoConsulta.SelectedIndexChanged
        Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
        CreaLinkParaImpresion2(gvr)
    End Sub
End Class