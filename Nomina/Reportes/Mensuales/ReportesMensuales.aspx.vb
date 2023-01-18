Imports DataAccessLayer.COBAEV.Administracion
Imports DataAccessLayer.COBAEV.Nominas
Imports System.Data
Imports DataAccessLayer.COBAEV
Partial Class Reportes_Mensuales
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
    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, ByVal dt As DataTable, Optional ByVal SelectedValue As String = "")
        ddl.DataSource = dt
        ddl.DataTextField = TextField
        ddl.DataValueField = ValueField
        ddl.DataBind()
        If SelectedValue <> String.Empty Then ddl.SelectedValue = SelectedValue
    End Sub
    Private Sub BindddlTipoDeNomina()
        Dim oQna As New Nomina
        LlenaDDL(Me.ddlTipoDeNomina, "DescFondoPresup", "IdFondoPresup", oQna.GetFondosPresupuestales())
    End Sub

    Private Sub CreaLinkParaImpresion2(ByVal gvr As GridViewRow)
        Dim lblIdReporte As Label = CType(gvr.FindControl("lblIdReporte"), Label)

        Select Case lblIdReporte.Text
            Case "129" 'Reporte institucional anual de percepciones y deducciones
                ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                            + "?Anio=" + ddlAños.SelectedValue _
                            + "&Mes=" + ddlMeses.SelectedValue _
                            + "&IdFondoPresup=" + ddlTipoDeNomina.SelectedValue _
                            + "&IdReporte=" + lblIdReporte.Text + "','RptInst_" + ddlAños.SelectedValue + "_" + ddlMeses.SelectedItem.Text + "_FP_" + ddlTipoDeNomina.SelectedValue + "'); return false;"
            Case "134" 'Reporte mensual de impuestos
                ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                            + "?Anio=" + ddlAños.SelectedValue _
                            + "&Mes=" + ddlMeses.SelectedValue _
                            + "&IdReporte=" + lblIdReporte.Text + "','RptImpuestos_" + ddlAños.SelectedValue + "_" + ddlMeses.SelectedItem.Text + "'); return false;"

        End Select
    End Sub
    Private Sub CreaLinkParaImpresion(ByVal gvr As GridViewRow)
        Dim lblIdReporte As Label = CType(gvr.FindControl("lblIdReporte"), Label)
        Dim lblExportarAExcel As Label = CType(gvr.FindControl("lblExportarAExcel"), Label)
        Dim lblExportarAPDF As Label = CType(gvr.FindControl("lblExportarAPDF"), Label)
        Dim lblImplicaFondoPresup As Label = CType(gvr.FindControl("lblImplicaFondoPresup"), Label)

        Me.ibExportarExcel.Visible = CType(lblExportarAExcel.Text, Boolean)
        ibImprimir.Visible = CType(lblExportarAPDF.Text, Boolean)
        If CType(lblExportarAExcel.Text, Boolean) Then
            CreaLinkParaImpresion2(gvr)
        End If
        Me.pnlTipoDeNomina.Enabled = CType(lblImplicaFondoPresup.Text, Boolean)

        Select Case lblIdReporte.Text
            Case "129" 'Reporte institucional anual de percepciones y deducciones
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                            + "?Anio=" + ddlAños.SelectedValue _
                            + "&Mes=" + ddlMeses.SelectedValue _
                            + "&IdFondoPresup=" + ddlTipoDeNomina.SelectedValue _
                            + "&IdReporte=" + lblIdReporte.Text + "','RptInst_" + ddlAños.SelectedValue + "_" + ddlMeses.SelectedItem.Text + "_FP_" + ddlTipoDeNomina.SelectedValue + "'); return false;"
            Case "134" 'Reporte mensual de impuestos
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                            + "?Anio=" + ddlAños.SelectedValue _
                            + "&Mes=" + ddlMeses.SelectedValue _
                            + "&IdReporte=" + lblIdReporte.Text + "','RptImpuestos_" + ddlAños.SelectedValue + "_" + ddlMeses.SelectedItem.Text + "'); return false;"


        End Select
    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            BindddlAños()
            BindddlMeses()
            BindddlTipoDeNomina()
            If Me.ddlAños.SelectedValue <> -1 Then
                BindgvReportes()
                Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
                CreaLinkParaImpresion(gvr)
            End If
        End If
    End Sub

    Protected Sub ddlAños_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlAños.SelectedIndexChanged
        BindddlMeses()
        Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
        CreaLinkParaImpresion(gvr)
    End Sub
    Protected Sub ddlMeses_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlMeses.SelectedIndexChanged
        Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
        CreaLinkParaImpresion(gvr)
    End Sub
    Protected Sub ddlTipoDeNomina_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
        CreaLinkParaImpresion(gvr)
    End Sub
    Protected Sub gvReportes_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvReportes.SelectedIndexChanged
        Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
        CreaLinkParaImpresion(gvr)
    End Sub
End Class