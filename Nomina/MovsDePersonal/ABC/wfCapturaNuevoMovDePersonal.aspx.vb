Imports DataAccessLayer.COBAEV
Imports DataAccessLayer.COBAEV.MovsDePersonal
Imports System.Data
Imports DataAccessLayer.COBAEV.Plazas

Partial Class wfCapturaNuevoMovDePersonal
    Inherits System.Web.UI.Page

    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, ByVal dt As DataTable, ByVal SelectedValue As String)
        ddl.DataSource = dt
        ddl.DataTextField = TextField
        ddl.DataValueField = ValueField
        ddl.DataBind()
        If SelectedValue Is Nothing = False And SelectedValue <> String.Empty Then
            If ddl.Items.FindByValue(SelectedValue) Is Nothing = False Then
                ddl.SelectedValue = SelectedValue
            End If
        End If
    End Sub

    Private Sub Bind_ddlMotivos()
        Dim oMovDePers As New MovsDePersonal

        LlenaDDL(ddlMotivos, "DescMotivo", "IdMotivo", oMovDePers.ObtenMotivosPorTramite(CShort(ddlTramites.SelectedValue)), Nothing)
    End Sub

    Private Sub Bind_ddlTramites()
        Dim oMovDePers As New MovsDePersonal

        LlenaDDL(ddlTramites, "DescTramite", "IdTramite", oMovDePers.ObtenTramites(), Nothing)
        Bind_ddlMotivos()

    End Sub

    Private Sub ComplementaInfCadena()
        Dim oCadena As New Cadenas
        Dim dtCadena As DataTable
        Dim oOrigProp As New OrigenPropuestas

        dtCadena = oCadena.ObtenPorId(CInt(ddlCadenas.SelectedValue))

        LlenaDDL(ddlOrigenPropuestas, "OrigenPropuesta", "IdOrigenPropuesta", oOrigProp.ObtenOrigenPropuestas(), dtCadena.Rows(0).Item("IdOrigenPropuesta").ToString)
        txtbxOficioProp.Text = dtCadena.Rows(0).Item("OficioDePropuesta").ToString

    End Sub

    Private Sub Bind_ddlCadenas()
        Dim oCadena As New Cadenas

        LlenaDDL(ddlCadenas, "NumCadena2", "IdCadena", oCadena.ObtenAbiertasPorUsr(Session("Login")), Nothing)

        If ddlCadenas.Items.Count = 1 And ddlCadenas.SelectedValue = "-1" Then
            ddlCadenas.Items(0).Text = "(NO HAY CADENAS ABIERTAS PARA CAPTURA)"
        ElseIf ddlCadenas.Items.Count > 1 Then
            If ddlCadenas.Items.FindByValue("-1") Is Nothing = False Then
                ddlCadenas.Items.Remove(ddlCadenas.Items.FindByValue("-1"))
            End If

            ComplementaInfCadena()
        End If
    End Sub

    Private Sub BindDatos()
        Dim hfNomEmp As HiddenField = CType(WucBuscaEmpleados1.FindControl("hfNomEmp"), HiddenField)

        If Not Session("RFCParaCons") Is Nothing Or hfNomEmp.Value.Trim <> String.Empty Then
            pnl1.GroupingText = "El movimiento de personal se asociará al empleado: " + IIf(hfNomEmp.Value = String.Empty, Session("ApePatParaCons") + " " + Session("ApeMatParaCons") + " " + Session("NombreParaCons"), hfNomEmp.Value)
            'lblInfEmp.Text = "El movimiento de personal se asociará al empleado: " + IIf(hfNomEmp.Value = String.Empty, Session("ApePatParaCons") + " " + Session("ApeMatParaCons") + " " + Session("NombreParaCons"), hfNomEmp.Value)
            'lblInfEmp.Visible = True
            Bind_ddlCadenas()
            pnlInfMovPers.Visible = True
        Else
            pnlInfMovPers.Visible = False
            'lblInfEmp.Text = String.Empty
            'lblInfEmp.Visible = False
        End If
    End Sub

    Protected Sub WucBuscaEmpleados1_PreRender(sender As Object, e As System.EventArgs) Handles WucBuscaEmpleados1.PreRender
        Dim hfRFC As HiddenField = CType(WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        Dim oMetodoComun As New MetodosComunes
        Dim c As Control = oMetodoComun.GetPostBackControl(Page)

        If c Is Nothing Then Exit Sub
        If c.ID = "BtnSearch" Then
            If hfRFC.Value <> String.Empty Then
                BindDatos()
                pnlInfMovPers.Visible = True
            End If
        ElseIf c.ID = "BtnNewSearch" Then
            pnlInfMovPers.Visible = False
        ElseIf c.ID = "BtnCancelSearch" Then
            pnlInfMovPers.Visible = True
        ElseIf c.ID = "lnkbtnrfc" Then
            BindDatos()
            pnlInfMovPers.Visible = True
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim dtInfTraMot As DataTable
        Dim oMovDePers As New MovsDePersonal
        If Not IsPostBack Then
            BindDatos()
            Bind_ddlTramites()
        Else
            dtInfTraMot = oMovDePers.ObtenInfTramiteMotivo(CShort(ddlTramites.SelectedValue), CShort(ddlMotivos.SelectedValue))
            wucPlazas1.propdtInfTraMot = dtInfTraMot
        End If
    End Sub

    Protected Sub btnContinuar_Click(sender As Object, e As System.EventArgs) Handles btnContinuar.Click
        Dim hfNomEmp As HiddenField = CType(WucBuscaEmpleados1.FindControl("hfNomEmp"), HiddenField)
        Dim oMovDePers As New MovsDePersonal
        Dim dtInfTraMot As DataTable
        Dim oPlaza As New SMP_Plazas
        Dim oZonaEco As New ZonaEconomica

        dtInfTraMot = oMovDePers.ObtenInfTramiteMotivo(CShort(ddlTramites.SelectedValue), CShort(ddlMotivos.SelectedValue))

        Response.Redirect(dtInfTraMot.Rows(0).Item("URL").ToString + "&RFCEmp=" + Request.Params("RFCEmp") + "&IdCadena=" + ddlCadenas.SelectedValue + "&IdTramite=" + ddlTramites.SelectedValue + "&IdMotivo=" + ddlMotivos.SelectedValue)


        'Select Case dtInfTraMot.Rows(0).Item("URL").ToString
        '    Case "viewAlta"
        '        pnl1.Enabled = False
        '        pnl1Botones.Visible = False

        '        'wucPlazas1.proplblInfEmp = lblInfEmp.Text
        '        'wucPlazas1.proplblNumCadena = "Cadena: " + ddlCadenas.SelectedItem.Text
        '        'wucPlazas1.proplblTramite = "Trámite: " + ddlTramites.SelectedItem.Text
        '        'wucPlazas1.proplblMotivo = "Motivo: " + ddlMotivos.SelectedItem.Text
        '        wucPlazas1.propdtInfTraMot = dtInfTraMot
        '        wucPlazas1.proptxtbxCod_Pago = dtInfTraMot.Rows(0).Item("Cod_Pago").ToString
        '        wucPlazas1.proplblDescCod_Pago = dtInfTraMot.Rows(0).Item("DescCod_Pago").ToString
        '        wucPlazas1.UpdateIsPostBack()



        '        pnlviewAlta.Visible = True
        '        pnlviewAltaBotones.Visible = True

        '        mviewMain.SetActiveView(viewAlta)
        'End Select
    End Sub

    Protected Sub ddlCadenas_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlCadenas.SelectedIndexChanged
        ComplementaInfCadena()
    End Sub

    Protected Sub ddlTramites_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlTramites.SelectedIndexChanged
        Bind_ddlMotivos()
    End Sub

    Protected Sub btnRegresarAviewInfMovPers_Click(sender As Object, e As System.EventArgs) Handles btnRegresarAviewInfMovPers.Click
        pnlviewAlta.Visible = False
        pnlviewAltaBotones.Visible = False
        pnl1.Enabled = True
        pnl1Botones.Visible = True
        mviewMain.SetActiveView(viewInfMovPers)
    End Sub
    Protected Sub btnContinuar2_Click(sender As Object, e As System.EventArgs) Handles btnContinuar2.Click
        Dim dtInfTraMot As DataTable
        Dim oMovDePers As New MovsDePersonal

        Dim txtbxFechaFIni As TextBox

        txtbxFechaFIni = CType(wucPlazas1.FindControl("txtbxFechaIni"), TextBox)

        wucPlazas1.UpdateHorasPlaza()
        wucPlazas1.UpdateClavePlaza()
        If wucPlazas1.ContinuarConMovDePers Then
            dtInfTraMot = oMovDePers.ObtenInfTramiteMotivo(CShort(ddlTramites.SelectedValue), CShort(ddlMotivos.SelectedValue))

            Select Case dtInfTraMot.Rows(0).Item("URL").ToString
                Case "viewAlta"
                    pnlviewAlta.Enabled = False
                    pnlviewAltaBotones.Visible = False

                    'wucPlazas2.proplblInfEmp = wucPlazas1.proplblInfEmp
                    'wucPlazas2.proplblNumCadena = wucPlazas1.proplblNumCadena
                    'wucPlazas2.proplblTramite = wucPlazas1.proplblTramite
                    'wucPlazas2.proplblMotivo = wucPlazas1.proplblMotivo
                    wucPlazas2.proplblClavePlaza = wucPlazas1.proplblClavePlaza
                    wucPlazas2.proplblDescPlazaTipo = wucPlazas1.propddlCvePlazaTipo + " = " + wucPlazas1.proplblDescPlazaTipo
                    wucPlazas2.proplblZonaEco = wucPlazas1.propddlZonasEco + " = " + wucPlazas1.proplblDescZonaEco
                    wucPlazas2.proplblCod_Pago = wucPlazas1.proptxtbxCod_Pago + " = " + wucPlazas1.proplblDescCod_Pago
                    wucPlazas2.proplblCveCategoCOBACH = wucPlazas1.propddlCveCategoCOBACH + " = (" + wucPlazas1.propddlCveCategoCOBACH2 + ") " + _
                                                        "(" + wucPlazas1.proplblDescCatego + ")"
                    wucPlazas2.proplblHorasPlaza = wucPlazas1.proptxtbxHorasPlaza + " = HORAS ASOCIADAS A LA PLAZA"
                    wucPlazas2.proplblConsPlaza = wucPlazas1.proptxtbxConsPlaza + " = CONSECUTIVO DE LA PLAZA"
                    wucPlazas2.UpdateIsPostBack()

                    mviewMain.SetActiveView(viewAlta2)
            End Select
        End If
    End Sub

    Protected Sub btnRegresarAviewAlta_Click(sender As Object, e As System.EventArgs) Handles btnRegresarAviewAlta.Click
        mviewMain.SetActiveView(viewAlta)
    End Sub
End Class
