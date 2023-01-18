Imports DataAccessLayer.COBAEV.Administracion
Imports DataAccessLayer.COBAEV.InformacionAcademica
Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV
Imports System.Data
Partial Class RptsPlazasyHoras
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
        Me.gvQuincenas.DataSource = oQna.ObtenCalculadasPorAnio(CShort(Me.ddlAños.SelectedValue), False)
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
    Private Sub BindddlPlanteles_ZonasGeo()
        Dim lblIdQuincena As Label = CType(Me.gvQuincenas.SelectedRow.FindControl("lblIdQuincena"), Label)
        Me.ddlPlanteles_ZonasGeo.Enabled = True
        Select Case Me.ddlTiposDeImpresion.SelectedValue
            Case "1"  'Planteles
                Me.pnlPlanteles_ZonasGeo.GroupingText = "Seleccione plantel"
                Me.pnlPlanteles_ZonasGeo.Visible = True
                Dim oPlantel As New Plantel
                LlenaDDL(Me.ddlPlanteles_ZonasGeo, "DescPlantel", "IdPlantel", oPlantel.ObtenParaPagoPorUsr(Session("Login")))
                LlenaDDL(Me.ddlPlantelesPensionAlimenticia, "DescPlantel", "IdPlantel", oPlantel.ObtenParaImpDePensionAlimPorUsr(Session("Login"), CShort(lblIdQuincena.Text)))
                If Me.ddlPlantelesPensionAlimenticia.Items.Count = 0 Then
                    Me.ddlPlantelesPensionAlimenticia.Items.Add(New ListItem("No hay planteles con pensión alimenticia en la quincena seleccionada", "-1"))
                End If
            Case "2" 'Zonas geográficas
                Me.pnlPlanteles_ZonasGeo.GroupingText = "Seleccione zona geográfica"
                Me.pnlPlanteles_ZonasGeo.Visible = True
                Dim oZonaGeo As New Zonageografica
                LlenaDDL(Me.ddlPlanteles_ZonasGeo, "NombreZonaGeografica", "IdZonaGeografica", oZonaGeo.ObtenPorUsuario(Session("Login")))
                If Me.ddlPlanteles_ZonasGeo.Items.Count = 0 Then
                    Me.ddlPlanteles_ZonasGeo.Items.Add(New ListItem("No hay zonas geográficas disponibles para el usuario.", "0"))
                End If
            Case Else
                Me.pnlPlanteles_ZonasGeo.Visible = False
        End Select
    End Sub
    Private Sub BindddlTipoDeNomina()
        Dim oQna As New Nomina
        LlenaDDL(Me.ddlTipoDeNomina, "DescFondoPresup", "IdFondoPresup", oQna.GetFondosPresupuestales())
    End Sub
    Private Sub CreaLinkParaImpresion2(ByVal gvr As GridViewRow)
        Dim lblIdQuincena As Label = CType(Me.gvQuincenas.SelectedRow.FindControl("lblIdQuincena"), Label)
        Dim lblIdReporte As Label = CType(gvr.FindControl("lblIdReporte"), Label)

        Select Case lblIdReporte.Text
            Case "80" 'Concetrado de plazas y horas
                Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                            + "?IdQuincena=" + lblIdQuincena.Text _
                            + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                            + "&IdReporte=" + lblIdReporte.Text + "','ConcentradoPlazas_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
            Case "91" 'Estructura orgánica
                Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                            + "?IdQuincena=" + lblIdQuincena.Text _
                            + "&IdReporte=" + lblIdReporte.Text + "','Organigrama_" + lblIdQuincena.Text.Replace("-", "_") + "'); return false;"
        End Select
    End Sub
    Private Sub CreaLinkParaImpresion(ByVal gvr As GridViewRow)
        Dim lblIdQuincena As Label = CType(Me.gvQuincenas.SelectedRow.FindControl("lblIdQuincena"), Label)
        Dim lblIdReporte As Label = CType(gvr.FindControl("lblIdReporte"), Label)
        Dim lblImplicaMeses As Label = CType(gvr.FindControl("lblImplicaMeses"), Label)
        Dim lblExportarAExcel As Label = CType(gvr.FindControl("lblExportarAExcel"), Label)
        Dim lblExportarAPDF As Label = CType(gvr.FindControl("lblExportarAPDF"), Label)
        Dim lblImplicaQuincenas As Label = CType(gvr.FindControl("lblImplicaQuincenas"), Label)
        Dim lblImplicaFondoPresup As Label = CType(gvr.FindControl("lblImplicaFondoPresup"), Label)
        Dim lblImplicaPlantel As Label = CType(gvr.FindControl("lblImplicaPlantel"), Label)

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

        Me.ddlPlanteles_ZonasGeo.Visible = True
        Me.ddlPlantelesPensionAlimenticia.Visible = False
        Select Case lblIdReporte.Text
            Case "80" 'Concentrado de plazas y horas
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                            + "?IdQuincena=" + lblIdQuincena.Text _
                            + "&IdFondoPresup=" + Me.ddlTipoDeNomina.SelectedValue _
                            + "&IdReporte=" + lblIdReporte.Text + "','ConcentradoPlazas_" + lblIdQuincena.Text.Replace("-", "_") + "_" + Me.ddlTipoDeNomina.SelectedValue + "'); return false;"
            Case "91" 'Estructura orgánica
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                            + "?IdQuincena=" + lblIdQuincena.Text _
                            + "&IdReporte=" + lblIdReporte.Text + "','Organigrama_" + lblIdQuincena.Text.Replace("-", "_") + "'); return false;"

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
                BindddlPlanteles_ZonasGeo()
                BindddlTipoDeNomina()
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
        BindddlPlanteles_ZonasGeo()
        Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
        CreaLinkParaImpresion(gvr)
    End Sub

    Protected Sub ddlTipoDeNomina_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
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
            Me.ddlPlantelesPensionAlimenticia.Items.Add(New ListItem("No hay planteles con pensión alimenticia en la quincena seleccionada", "-1"))
        End If

        Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
        CreaLinkParaImpresion(gvr)
    End Sub

    Protected Sub gvReportes_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvReportes.SelectedIndexChanged
        Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
        Dim oUsr As New Usuario

        'If CType(gvr.FindControl("lblIdReporte"), Label).Text = "3" Or CType(gvr.FindControl("lblIdReporte"), Label).Text = "10" Then
        '    Me.ddlTiposDeImpresion.Items(0).Enabled = oUsr.EsAdministrador(Session("Login"))
        '    Me.ddlTiposDeImpresion.Items(2).Enabled = True
        '    BindddlPlanteles_ZonasGeo()
        'Else
        Me.ddlTiposDeImpresion.Items(0).Enabled = False
        Me.ddlTiposDeImpresion.Items(2).Enabled = False
        Me.ddlTiposDeImpresion.Items(0).Selected = False
        Me.ddlTiposDeImpresion.Items(2).Selected = False
        Me.ddlTiposDeImpresion.Items(1).Selected = True
        BindddlPlanteles_ZonasGeo()
        'End If

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