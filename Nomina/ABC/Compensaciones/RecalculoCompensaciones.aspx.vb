Imports DataAccessLayer.COBAEV.Administracion
Imports DataAccessLayer.COBAEV.InformacionAcademica
Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV
Imports System.Data
Imports System.IO
Partial Class ABC_Compensaciones_RecalculoCompensaciones
    Inherits System.Web.UI.Page
    Private Sub CreaLinkParaImpresion2(ByVal gvr As GridViewRow)
        Dim lblIdReporte As Label = CType(gvr.FindControl("lblIdReporte"), Label)

        Select Case lblIdReporte.Text
            Case "33" 'Papel de trabajo
                Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                            + "?Anio=" + Me.ddlAños.SelectedValue _
                            + "&IdMes=" + CByte(Left(Me.ddlMeses.SelectedValue, 2)).ToString _
                            + "&IdReporte=" + lblIdReporte.Text + "','PapelTrabajo_" + Me.ddlAños.SelectedItem.Text + "_" + CByte(Left(Me.ddlMeses.SelectedValue, 2)).ToString + "'); return false;"
            Case "120" 'Papel de trabajo
                Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                            + "?Anio=" + Me.ddlAños.SelectedValue _
                            + "&IdMes=" + CByte(Left(Me.ddlMeses.SelectedValue, 2)).ToString _
                            + "&IdReporte=" + lblIdReporte.Text + "','PapelTrabajoEXCEL_" + Me.ddlAños.SelectedItem.Text + "_" + CByte(Left(Me.ddlMeses.SelectedValue, 2)).ToString + "'); return false;"
        End Select
    End Sub
    Private Sub CreaLinkParaImpresion(ByVal gvr As GridViewRow)
        Dim lblIdReporte As Label = CType(gvr.FindControl("lblIdReporte"), Label)
        Dim lblImplicaMeses As Label = CType(gvr.FindControl("lblImplicaMeses"), Label)
        Dim lblExportarAExcel As Label = CType(gvr.FindControl("lblExportarAExcel"), Label)
        Dim lblImplicaQuincenas As Label = CType(gvr.FindControl("lblImplicaQuincenas"), Label)
        Dim lblImplicaFondoPresup As Label = CType(gvr.FindControl("lblImplicaFondoPresup"), Label)
        Dim lblImplicaPlantel As Label = CType(gvr.FindControl("lblImplicaPlantel"), Label)
        Dim lblExportarAPDF As Label = CType(gvr.FindControl("lblExportarAPDF"), Label)

        If CType(lblExportarAExcel.Text, Boolean) Then
            CreaLinkParaImpresion2(gvr)
        End If
        Me.pnlMeses.Enabled = CType(lblImplicaMeses.Text, Boolean)
        Me.ibImprimir.Visible = CType(lblExportarAPDF.Text, Boolean)
        Me.ibExportarExcel.Visible = CType(lblExportarAExcel.Text, Boolean)

        Select Case lblIdReporte.Text
            Case "33" 'Papel de trabajo
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                            + "?Anio=" + Me.ddlAños.SelectedValue _
                            + "&IdMes=" + CByte(Left(Me.ddlMeses.SelectedValue, 2)).ToString _
                            + "&IdReporte=" + lblIdReporte.Text + "','PapelTrabajo_" + Me.ddlAños.SelectedItem.Text + "_" + Me.ddlMeses.SelectedValue.Replace("-", "_") + "'); return false;"
            Case "120" 'Papel de trabajo
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                            + "?Anio=" + Me.ddlAños.SelectedValue _
                            + "&IdMes=" + CByte(Left(Me.ddlMeses.SelectedValue, 2)).ToString _
                            + "&IdReporte=" + lblIdReporte.Text + "','PapelTrabajoEXCEL_" + Me.ddlAños.SelectedItem.Text + "_" + Me.ddlMeses.SelectedValue.Replace("-", "_") + "'); return false;"
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
            .DataSource = oCompensacion.ObtenAñosPagados(True)
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
        With Me.ddlMeses
            .DataSource = oCompensacion.ObtenMesesPagadosPorAño(CShort(Me.ddlAños.SelectedValue), True)
            .DataTextField = "NombreMes"
            .DataValueField = "IdMes"
            .DataBind()
        End With
    End Sub
    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            BindddlAños()
            If Me.ddlAños.SelectedValue <> -1 Then
                BindddlMeses()
                Me.btnRecalcular.Text = "Recalcular I.S.R. para " + Me.ddlMeses.SelectedItem.Text + " de " + Me.ddlAños.SelectedItem.Text

                Dim dtPermisos As DataTable
                Dim oUsr As New Usuario
                dtPermisos = oUsr.ObtenPermisosSobreTabla(Session("Login"), "Compensaciones")

                Dim oCompen As New Compensacion
                Me.btnRecalcular.Enabled = Not oCompen.TieneISRRecalculado(Me.ddlAños.SelectedItem.Text, Me.ddlMeses.SelectedValue) And CBool(dtPermisos.Rows(0).Item("Insercion"))

                Me.lblMsj.Text = "Información de " + Me.ddlMeses.SelectedItem.Text.ToUpper + " de " + Me.ddlAños.SelectedItem.Text
                BindgvReportes()
                Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
                CreaLinkParaImpresion(gvr)
            End If
        End If
    End Sub

    Protected Sub btnConsultar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        'System.Threading.Thread.Sleep(1000)
        Dim oCompen As New Compensacion
        Dim dtPermisos As DataTable
        Dim oUsr As New Usuario

        Me.btnRecalcular.Text = "Recalcular I.S.R. para " + Me.ddlMeses.SelectedItem.Text + " de " + Me.ddlAños.SelectedItem.Text

        dtPermisos = oUsr.ObtenPermisosSobreTabla(Session("Login"), "Compensaciones")

        Me.btnRecalcular.Enabled = Not oCompen.TieneISRRecalculado(CShort(Me.ddlAños.SelectedItem.Text), Me.ddlMeses.SelectedValue) And CBool(dtPermisos.Rows(0).Item("Insercion"))

        Me.lblMsj.Text = "Información de " + Me.ddlMeses.SelectedItem.Text.ToUpper + " de " + Me.ddlAños.SelectedItem.Text

        Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
        CreaLinkParaImpresion(gvr)
    End Sub

    Protected Sub ddlAños_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlAños.SelectedIndexChanged
        BindddlMeses()
    End Sub

    Protected Sub gvReportes_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
        CreaLinkParaImpresion(gvr)
    End Sub

    Protected Sub btnRecalcular_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRecalcular.Click
        Dim oCompen As New Compensacion
        Dim dtPermisos As DataTable
        Dim oUsr As New Usuario

        oCompen.RecalculaISR(CShort(Me.ddlAños.SelectedItem.Text), Me.ddlMeses.SelectedValue)

        Me.btnRecalcular.Text = "Recalcular I.S.R. para " + Me.ddlMeses.SelectedItem.Text + " de " + Me.ddlAños.SelectedItem.Text

        dtPermisos = oUsr.ObtenPermisosSobreTabla(Session("Login"), "Compensaciones")
        Me.btnRecalcular.Enabled = Not oCompen.TieneISRRecalculado(CShort(Me.ddlAños.SelectedItem.Text), Me.ddlMeses.SelectedValue) And CBool(dtPermisos.Rows(0).Item("Insercion"))

        Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
        CreaLinkParaImpresion(gvr)
    End Sub

    Protected Sub ddlMeses_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        btnConsultar_Click(sender, e)
    End Sub
End Class