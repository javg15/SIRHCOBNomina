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
Partial Class PlazasBaseReportes
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
    Private Sub CreaLinkParaImpresion2(ByVal gvr As GridViewRow)
        Dim lblIdQuincena As Label = CType(Me.gvQuincenas.SelectedRow.FindControl("lblIdQuincena"), Label)
        Dim lblIdReporte As Label = CType(gvr.FindControl("lblIdReporte"), Label)
        'Dim lblImplicaMeses As Label = CType(gvr.FindControl("lblImplicaMeses"), Label)
        'Dim lblExportarAExcel As Label = CType(gvr.FindControl("lblExportarAExcel"), Label)



        Select Case lblIdReporte.Text
            Case "1", "123" 'Institucional de percepciones y deducciones
                Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                            + "?IdQuincena=" + lblIdQuincena.Text _
                            + "&IdReporte=" + lblIdReporte.Text + "','NominaInstitucional_" + lblIdQuincena.Text.Replace("-", "_") + "'); return false;"
            Case "161" 'Conciliación Financieros
                Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                            + "?IdQuincena=" + lblIdQuincena.Text _
                            + "&IdReporte=" + lblIdReporte.Text + "','NominaInstitucional_" + lblIdQuincena.Text.Replace("-", "") + "'); return false;"
            Case "164" 'CFDI
                Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                    + "?Anio=" + Me.ddlAños.SelectedItem.Text _
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

        Me.ibImprimir.Visible = CType(lblExportarAPDF.Text, Boolean)
        Me.ibExportarExcel.Visible = CType(lblExportarAExcel.Text, Boolean)
        If CType(lblExportarAExcel.Text, Boolean) Then
            CreaLinkParaImpresion2(gvr)
        End If
        Me.lblMsj.Enabled = CType(lblImplicaQuincenas.Text, Boolean)
        Me.gvQuincenas.Enabled = CType(lblImplicaQuincenas.Text, Boolean)

        Me.pnlOpcDeImpresion.Enabled = CType(lblImplicaPlantel.Text, Boolean)
        Me.pnlPlanteles_ZonasGeo.Enabled = CType(lblImplicaPlantel.Text, Boolean)

        'Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx"
        'Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx"

        'If CType(lblImplicaQuincenas.Text, Boolean) Then
        '    strOnClientClick = "?IdQuincena=" + lblIdQuincena.Text
        'End If

        Me.ddlPlanteles_ZonasGeo.Visible = True

        Select Case lblIdReporte.Text
            Case "1", "123" 'Institucional de percepciones y deducciones
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                            + "?IdQuincena=" + lblIdQuincena.Text _
                            + "&IdReporte=" + lblIdReporte.Text + "','NominaInstitucional_" + lblIdQuincena.Text.Replace("-", "_") + "'); return false;"
            Case "21" 'Concentrado de Conciliaciones
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                            + "?IdQuincena=" + lblIdQuincena.Text _
                            + "&IdReporte=" + lblIdReporte.Text + "','ConcentradoConciliacion_" + lblIdQuincena.Text.Replace("-", "_") + "'); return false;"
            Case "22" 'Resúmen de Conciliaciones
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                            + "?IdQuincena=" + lblIdQuincena.Text _
                            + "&IdReporte=" + lblIdReporte.Text + "','ResumenConciliacion_" + lblIdQuincena.Text.Replace("-", "_") + "'); return false;"
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
                BindQuincenas()
                BindddlPlanteles_ZonasGeo(True)
                BindgvReportes()

                Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
                CreaLinkParaImpresion(gvr)

            End If
        End If
    End Sub

    Protected Sub btnConsultarQuincenas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultarQuincenas.Click
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

            Session.Remove("pFchImpRpt")
        End If

        itemSel = Me.ddlTiposDeImpresion.SelectedValue


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
        Else
            Me.ddlTiposDeImpresion.Items(0).Enabled = False
            Me.ddlTiposDeImpresion.Items(2).Enabled = False
            Me.ddlTiposDeImpresion.Items(0).Selected = False
            Me.ddlTiposDeImpresion.Items(2).Selected = False
            Me.ddlTiposDeImpresion.Items(1).Selected = True

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

End Class