Imports DataAccessLayer.COBAEV.Administracion
Imports DataAccessLayer.COBAEV.InformacionAcademica
Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV
Imports System.Data

Partial Class ImpresionPlantillas
    Inherits System.Web.UI.Page
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
        Me.gvQuincenas.DataSource = oQna.ObtenPorAnioParaImpresionDePlantillas(CShort(Me.ddlAños.SelectedValue))
        Me.gvQuincenas.DataBind()
        Me.lblMsj.Text = "Quincenas posibles para impresión deplantillas en el año " + Me.ddlAños.SelectedItem.Text
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
        Select Case Me.ddlTiposDeImpresion.SelectedValue
            Case "1"  'Planteles
                Me.pnlPlanteles_ZonasGeo.GroupingText = "Seleccione plantel"
                Me.pnlPlanteles_ZonasGeo.Visible = True
                Dim oPlantel As New Plantel
                LlenaDDL(Me.ddlPlanteles_ZonasGeo, "DescPlantel", "IdPlantel", oPlantel.ObtenParaPagoPorUsr(Session("Login")))
            Case "2" 'Zonas geográficas
                Me.pnlPlanteles_ZonasGeo.GroupingText = "Seleccione zona geográfica"
                Me.pnlPlanteles_ZonasGeo.Visible = True
                Dim oZonaGeo As New Zonageografica
                LlenaDDL(Me.ddlPlanteles_ZonasGeo, "NombreZonaGeografica", "IdZonaGeografica", oZonaGeo.ObtenTodas())
            Case Else
                Me.pnlPlanteles_ZonasGeo.Visible = False
        End Select
    End Sub
    Private Sub CreaLinkParaImpresion()
        Dim lblIdQuincena As Label = CType(Me.gvQuincenas.SelectedRow.FindControl("lblIdQuincena"), Label)
        Select Case Me.ddlReportes.SelectedValue
            Case "103" 'Plantilla de personal (REVISIÓN)
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                            + "?IdPlantel=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                            + "&IdQuincena=" + lblIdQuincena.Text _
                            + "&IdReporte=" + Me.ddlReportes.SelectedValue + "','Plantilla_" + lblIdQuincena.Text.Replace("-", "_") + "_Plantel_" + Me.ddlPlanteles_ZonasGeo.SelectedValue + "'); return false;"
                Me.ibImprimir.Visible = True
                Me.ibImprimirWord.Visible = False
                Me.ibImprimirExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                            + "?IdPlantel=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                            + "&IdQuincena=" + lblIdQuincena.Text _
                            + "&IdReporte=" + Me.ddlReportes.SelectedValue + "','Plantilla_" + lblIdQuincena.Text.Replace("-", "_") + "_Plantel_" + Me.ddlPlanteles_ZonasGeo.SelectedValue + "'); return false;"
                Me.ibImprimirExcel.Visible = True
            Case "158" 'Plantilla de personal (NUEVA A PARTIR DE 2022) 'ADDALEXIS : NUEVA PLANTILLA PARA REVISION 14/01/2022'
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                            + "?IdPlantel=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                            + "&IdQuincena=" + lblIdQuincena.Text _
                            + "&IdReporte=" + Me.ddlReportes.SelectedValue + "','Plantilla_" + lblIdQuincena.Text.Replace("-", "_") + "_Plantel_" + Me.ddlPlanteles_ZonasGeo.SelectedValue + "'); return false;"
                Me.ibImprimir.Visible = True
                Me.ibImprimirWord.Visible = False
                Me.ibImprimirExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                            + "?IdPlantel=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                            + "&IdQuincena=" + lblIdQuincena.Text _
                            + "&IdReporte=" + Me.ddlReportes.SelectedValue + "','Plantilla_" + lblIdQuincena.Text.Replace("-", "_") + "_Plantel_" + Me.ddlPlanteles_ZonasGeo.SelectedValue + "'); return false;"
                Me.ibImprimirExcel.Visible = True
            Case "16" 'Plantilla de personal
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                            + "?IdPlantel=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                            + "&IdQuincena=" + lblIdQuincena.Text _
                            + "&IdReporte=" + Me.ddlReportes.SelectedValue + "','Plantilla_" + lblIdQuincena.Text.Replace("-", "_") + "_Plantel_" + Me.ddlPlanteles_ZonasGeo.SelectedValue + "'); return false;"
                Me.ibImprimir.Visible = True
                Me.ibImprimirWord.Visible = False
                Me.ibImprimirExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                            + "?IdPlantel=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                            + "&IdQuincena=" + lblIdQuincena.Text _
                            + "&IdReporte=" + Me.ddlReportes.SelectedValue + "','Plantilla_" + lblIdQuincena.Text.Replace("-", "_") + "_Plantel_" + Me.ddlPlanteles_ZonasGeo.SelectedValue + "'); return false;"
                Me.ibImprimirExcel.Visible = True
            Case "92" 'SISTEMA NACIONAL DE BACHILLERATO
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                            + "?IdPlantel=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                            + "&IdQuincena=" + lblIdQuincena.Text _
                            + "&IdReporte=" + Me.ddlReportes.SelectedValue + "','SistNacBach_" + lblIdQuincena.Text.Replace("-", "_") + "_Plantel_" + Me.ddlPlanteles_ZonasGeo.SelectedValue + "'); return false;"
                Me.ibImprimirWord.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesWord.aspx" _
                            + "?IdPlantel=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                            + "&IdQuincena=" + lblIdQuincena.Text _
                            + "&IdReporte=" + Me.ddlReportes.SelectedValue + "','SistNacBach_" + lblIdQuincena.Text.Replace("-", "_") + "_Plantel_" + Me.ddlPlanteles_ZonasGeo.SelectedValue + "'); return false;"
                Me.ibImprimir.Visible = True
                Me.ibImprimirWord.Visible = True
                Me.ibImprimirExcel.Visible = False
            Case "CR01" 'CONSTANCIA LABORAL EN CRYSTAL REPORTS
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesCrystal.aspx" _
                            + "?IdPlantel=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                            + "&IdReporte=" + Me.ddlReportes.SelectedValue + "','ConstLaboralPDF_Plantel_" + Me.ddlPlanteles_ZonasGeo.SelectedValue + "'); return false;"
                Me.ibImprimirWord.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesCrystalEnWord.aspx" _
                            + "?IdPlantel=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                            + "&IdReporte=" + Me.ddlReportes.SelectedValue + "','ConstLaboralWord_Plantel_" + Me.ddlPlanteles_ZonasGeo.SelectedValue + "'); return false;"
                Me.ibImprimir.Visible = True
                Me.ibImprimirWord.Visible = True
                Me.ibImprimirExcel.Visible = False
            Case "CR02" 'CONSTANCIA LABORAL CON INGRESOS EN CRYSTAL REPORTS
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesCrystal.aspx" _
                            + "?Anio=2015&Folio=1" _
                            + "&IdReporte=" + Me.ddlReportes.SelectedValue + "','ConstLaboralConIngPDF_Plantel_2015_1'); return false;"
                Me.ibImprimirWord.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesCrystalEnWord.aspx" _
                            + "?Anio=2015&Folio=1" _
                            + "&IdReporte=" + Me.ddlReportes.SelectedValue + "','ConstLaboralWord_Plantel_2015_1'); return false;"
                Me.ibImprimir.Visible = True
                Me.ibImprimirWord.Visible = True
                Me.ibImprimirExcel.Visible = False
            Case "159" 'Plantilla de personal
                Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                            + "?IdPlantel=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                            + "&IdQuincena=" + lblIdQuincena.Text _
                            + "&IdReporte=" + Me.ddlReportes.SelectedValue + "','Plantilla_" + lblIdQuincena.Text.Replace("-", "_") + "_Plantel_" + Me.ddlPlanteles_ZonasGeo.SelectedValue + "'); return false;"
                Me.ibImprimir.Visible = True
                Me.ibImprimirWord.Visible = False
                Me.ibImprimirExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
                            + "?IdPlantel=" + Me.ddlPlanteles_ZonasGeo.SelectedValue _
                            + "&IdQuincena=" + lblIdQuincena.Text _
                            + "&IdReporte=" + Me.ddlReportes.SelectedValue + "','Plantilla_" + lblIdQuincena.Text.Replace("-", "_") + "_Plantel_" + Me.ddlPlanteles_ZonasGeo.SelectedValue + "'); return false;"
                Me.ibImprimirExcel.Visible = True
        End Select
    End Sub
    Protected Sub gvQuincenas_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvQuincenas.RowCommand
        CreaLinkParaImpresion()
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
                BindddlPlanteles_ZonasGeo()
                CreaLinkParaImpresion()
            End If
        End If
    End Sub

    Protected Sub btnConsultarQuincenas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultarQuincenas.Click
        BindQuincenas()
        CreaLinkParaImpresion()
    End Sub

    Protected Sub ddlTiposDeImpresion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        BindddlPlanteles_ZonasGeo()
        CreaLinkParaImpresion()
    End Sub
    Protected Sub ddlPlanteles_ZonasGeo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        CreaLinkParaImpresion()
    End Sub

    Protected Sub gvQuincenas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvQuincenas.SelectedIndexChanged
        CreaLinkParaImpresion()
    End Sub

    Protected Sub ddlReportes_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlReportes.SelectedIndexChanged
        CreaLinkParaImpresion()
    End Sub

End Class