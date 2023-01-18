Imports DataAccessLayer.COBAEV.Administracion
'Imports DataAccessLayer.COBAEV.InformacionAcademica
Imports DataAccessLayer.COBAEV.Nominas
'Imports DataAccessLayer.COBAEV
Imports System.Data
Imports DataAccessLayer.COBAEV
Partial Class Reportes_Categorias_TabuladoresPorCategoria
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
    Private Sub BindZonasEco()
        Dim oZonaEco As New ZonaEconomica
        With Me.ddlZonasEco
            .DataSource = oZonaEco.ObtenTodas()
            .DataTextField = "DescZonaEco"
            .DataValueField = "IdZonaEco"
            .DataBind()
        End With
    End Sub
    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, ByVal dt As DataTable, Optional ByVal SelectedValue As String = "")
        ddl.DataSource = dt
        ddl.DataTextField = TextField
        ddl.DataValueField = ValueField
        ddl.DataBind()
        If SelectedValue <> String.Empty Then ddl.SelectedValue = SelectedValue
    End Sub
    Private Sub CreaLinkParaImpresion2(ByVal gvr As GridViewRow)
        Dim lblIdQuincena As Label = CType(Me.gvQuincenas.SelectedRow.FindControl("lblIdQuincena"), Label)
        Dim lblIdReporte As Label = CType(gvr.FindControl("lblIdReporte"), Label)
        Dim AmbasZonas As Boolean

        If Me.ddlZonasEco.SelectedValue = 3 Then
            AmbasZonas = True
        Else
            AmbasZonas = False
        End If

        Select Case lblIdReporte.Text
            Case "35" 'Reporte de tabuladores por categoría con valores mensuales
                Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                            + "?IdQuincena=" + lblIdQuincena.Text _
                            + "&ImprimirAmbasZonas=" + AmbasZonas.ToString _
                            + "&IdZonaEco=" + Me.ddlZonasEco.SelectedValue _
                            + "&MoQ=M" _
                            + "&IdReporte=" + lblIdReporte.Text + "','TabsMens_" + lblIdQuincena.Text.Replace("-", "_") + Me.ddlZonasEco.SelectedValue + "'); return false;"
            Case "36" 'Reporte de tabuladores por categoría con valores quincenales
                Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                            + "?IdQuincena=" + lblIdQuincena.Text _
                            + "&ImprimirAmbasZonas=" + AmbasZonas.ToString _
                            + "&IdZonaEco=" + Me.ddlZonasEco.SelectedValue _
                            + "&MoQ=Q" _
                            + "&IdReporte=" + lblIdReporte.Text + "','TabsQnales_" + lblIdQuincena.Text.Replace("-", "_") + Me.ddlZonasEco.SelectedValue + "'); return false;"

            Case "67" 'Reporte de tabuladores RP por categoría con valores mensuales
                Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                            + "?IdQuincena=" + lblIdQuincena.Text _
                            + "&ImprimirAmbasZonas=" + AmbasZonas.ToString _
                            + "&IdZonaEco=" + Me.ddlZonasEco.SelectedValue _
                            + "&MoQ=M" _
                            + "&IdReporte=" + lblIdReporte.Text + "','TabsMensRP_" + lblIdQuincena.Text.Replace("-", "_") + Me.ddlZonasEco.SelectedValue + "'); return false;"
            Case "68" 'Reporte de tabuladores RP por categoría con valores quincenales
                Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                            + "?IdQuincena=" + lblIdQuincena.Text _
                            + "&ImprimirAmbasZonas=" + AmbasZonas.ToString _
                            + "&IdZonaEco=" + Me.ddlZonasEco.SelectedValue _
                            + "&MoQ=Q" _
                            + "&IdReporte=" + lblIdReporte.Text + "','TabsQnalesRP_" + lblIdQuincena.Text.Replace("-", "_") + Me.ddlZonasEco.SelectedValue + "'); return false;"
            Case "96" 'Reporte de catálogo de puestos por año
                Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                            + "?Anio=" + ddlAños.SelectedValue _
                            + "&IdReporte=" + lblIdReporte.Text + "','CatalogoPuestos_" + ddlAños.SelectedValue + "'); return false;"
        End Select
    End Sub
    Private Sub CreaLinkParaImpresion(ByVal gvr As GridViewRow)
        Dim lblIdQuincena As Label = CType(Me.gvQuincenas.SelectedRow.FindControl("lblIdQuincena"), Label)
        Dim lblIdReporte As Label = CType(gvr.FindControl("lblIdReporte"), Label)
        Dim lblExportarAExcel As Label = CType(gvr.FindControl("lblExportarAExcel"), Label)
        Dim lblImplicaQuincenas As Label = CType(gvr.FindControl("lblImplicaQuincenas"), Label)
        Dim AmbasZonas As Boolean

        Me.ibExportarExcel.Visible = CType(lblExportarAExcel.Text, Boolean)
        If CType(lblExportarAExcel.Text, Boolean) Then
            CreaLinkParaImpresion2(gvr)
        End If
        Me.lblMsj.Enabled = CType(lblImplicaQuincenas.Text, Boolean)
        Me.gvQuincenas.Enabled = CType(lblImplicaQuincenas.Text, Boolean)
        If Me.ddlZonasEco.SelectedValue = 3 Then
            AmbasZonas = True
        Else
            AmbasZonas = False
        End If

        'Me.pnlPlanteles_ZonasGeo.Enabled = CType(lblImplicaPlantel.Text, Boolean)

        Select Case lblIdReporte.Text
            Case "35" 'Reporte de tabuladores por categoría con valores mensuales
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                            + "?IdQuincena=" + lblIdQuincena.Text _
                            + "&ImprimirAmbasZonas=" + AmbasZonas.ToString _
                            + "&IdZonaEco=" + Me.ddlZonasEco.SelectedValue _
                            + "&MoQ=M" _
                            + "&IdReporte=" + lblIdReporte.Text + "','TabsMens_" + lblIdQuincena.Text.Replace("-", "_") + Me.ddlZonasEco.SelectedValue + "'); return false;"
            Case "36" 'Reporte de tabuladores por categoría con valores quincenales
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                            + "?IdQuincena=" + lblIdQuincena.Text _
                            + "&ImprimirAmbasZonas=" + AmbasZonas.ToString _
                            + "&IdZonaEco=" + Me.ddlZonasEco.SelectedValue _
                            + "&MoQ=Q" _
                            + "&IdReporte=" + lblIdReporte.Text + "','TabsQnales_" + lblIdQuincena.Text.Replace("-", "_") + Me.ddlZonasEco.SelectedValue + "'); return false;"
            Case "67" 'Reporte de tabuladores RP por categoría con valores mensuales
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                            + "?IdQuincena=" + lblIdQuincena.Text _
                            + "&ImprimirAmbasZonas=" + AmbasZonas.ToString _
                            + "&IdZonaEco=" + Me.ddlZonasEco.SelectedValue _
                            + "&MoQ=M" _
                            + "&IdReporte=" + lblIdReporte.Text + "','TabsMensRP_" + lblIdQuincena.Text.Replace("-", "_") + Me.ddlZonasEco.SelectedValue + "'); return false;"
            Case "68" 'Reporte de tabuladores RP por categoría con valores quincenales
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                            + "?IdQuincena=" + lblIdQuincena.Text _
                            + "&ImprimirAmbasZonas=" + AmbasZonas.ToString _
                            + "&IdZonaEco=" + Me.ddlZonasEco.SelectedValue _
                            + "&MoQ=Q" _
                            + "&IdReporte=" + lblIdReporte.Text + "','TabsQnalesRP_" + lblIdQuincena.Text.Replace("-", "_") + Me.ddlZonasEco.SelectedValue + "'); return false;"
            Case "96" 'Reporte de catálogo de puestos por año
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                            + "?Anio=" + ddlAños.SelectedValue _
                            + "&IdReporte=" + lblIdReporte.Text + "','CatalogoPuestos_" + ddlAños.SelectedValue + "'); return false;"
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
                BindZonasEco()
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

    Protected Sub gvQuincenas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvQuincenas.SelectedIndexChanged
        Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
        CreaLinkParaImpresion(gvr)
    End Sub

    Protected Sub gvReportes_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvReportes.SelectedIndexChanged
        Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
        CreaLinkParaImpresion(gvr)
    End Sub

    Protected Sub ddlZonasEco_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
        CreaLinkParaImpresion(gvr)
    End Sub
End Class