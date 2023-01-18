Imports DataAccessLayer.COBAEV.Empleados
Imports DataAccessLayer.COBAEV.Plazas
Imports System.Data
Imports DataAccessLayer.COBAEV
Imports DataAccessLayer.COBAEV.Administracion

Partial Class ABCPlazas
    Inherits System.Web.UI.Page
    Private Sub ValidaPlaza()
        Dim oPlaza As New SMP_Plazas
        Dim drPlaza As DataRow
        Dim oUsr As New Usuario
        Dim oPlantel As New Plantel
        Dim drUsr As DataRow

        drUsr = oUsr.ObtenerPropiedadesDelRol(Session("Login"))

        If CBool(drUsr("ConsultaZonasEspecificas")) = False And CBool(drUsr("ConsultaPlantelesEspecificos")) = False Then
            drPlaza = oPlaza.ObtenDetallePlaza(CShort(ddlPlanteles.SelectedValue), txtbxZE.Text, ddlFPsPlaza.SelectedValue, txtbxClaveCatego.Text, _
                                                CDec(txtBxHoras.Text), txtbxCons.Text)

            If drPlaza Is Nothing = False Then
                txtbxSindicato.Text = drPlaza("SiglasSindicato").ToString
                txtbxTitular.Text = drPlaza("NomEmpTit").ToString
                txtbxOcupAct.Text = drPlaza("NomEmpOcupAct").ToString
                txtbxEstatusPlaza.Text = drPlaza("DescEstatusPlaza").ToString
            Else
                txtbxSindicato.Text = "Información no disponible"
                txtbxTitular.Text = "Información no disponible"
                txtbxOcupAct.Text = "Información no disponible"
                txtbxEstatusPlaza.Text = "Información no disponible"
            End If
        Else
            If oPlantel.EsVisibleParaUsr(CShort(drUsr("IdUsuario")), CShort(ddlPlanteles.SelectedValue)) Then
                drPlaza = oPlaza.ObtenDetallePlaza(CShort(ddlPlanteles.SelectedValue), txtbxZE.Text, ddlFPsPlaza.SelectedValue, txtbxClaveCatego.Text, _
                                                    CDec(txtBxHoras.Text), txtbxCons.Text)

                If drPlaza Is Nothing = False Then
                    txtbxSindicato.Text = drPlaza("SiglasSindicato").ToString
                    txtbxTitular.Text = drPlaza("NomEmpTit").ToString
                    txtbxOcupAct.Text = drPlaza("NomEmpOcupAct").ToString
                    txtbxEstatusPlaza.Text = drPlaza("DescEstatusPlaza").ToString
                Else
                    txtbxSindicato.Text = "Información no disponible"
                    txtbxTitular.Text = "Información no disponible"
                    txtbxOcupAct.Text = "Información no disponible"
                    txtbxEstatusPlaza.Text = "Información no disponible"
                End If
            Else
                txtbxSindicato.Text = "Sin permisos disponibles"
                txtbxTitular.Text = "Sin permisos disponibles"
                txtbxOcupAct.Text = "Sin permisos disponibles"
                txtbxEstatusPlaza.Text = "Sin permisos disponibles"
            End If
        End If
    End Sub

    Private Sub UpdDeptos()
        Dim oPlantel As New Plantel
        Dim oDepto As New CentroDeTrabajo
        Dim dtCT As DataTable

        dtCT = oPlantel.ObtenPorId(CShort(ddlPlanteles.SelectedValue))

        If dtCT.Rows.Count > 0 Then
            txtbxZE.Text = dtCT.Rows(0).Item("ClaveZonaEco").ToString
            ddlZonasEco.SelectedValue = txtbxZE.Text
        Else
            txtbxZE.Text = String.Empty            
        End If

        LlenaDDL(ddlDeptos, "CentroDeTrabajo", "IdCT", oDepto.ObtenPorPlantel(CShort(ddlPlanteles.SelectedValue), IIf(ddlOrdenDeptos.SelectedValue = "", "CLAVEASC", ddlOrdenDeptos.SelectedValue)))
    End Sub
    Private Sub UpdDatosClavePlazas(ByVal pLlenaddlCatego As Boolean)
        Dim oPlaza As New SMP_Plazas
        Dim dr As DataRow
        Dim vlOrdenarPor As String

        txtbxZE.Text = ddlZonasEco.SelectedValue

        If pLlenaddlCatego Then
            If ddlOrdenCategos.SelectedValue = String.Empty Then
                vlOrdenarPor = "CLAVEASC"
            Else
                vlOrdenarPor = ddlOrdenCategos.SelectedValue
            End If
            LlenaDDL(ddlCategos, "Categoria", "IdCategoria", oPlaza.ObtenPlazasPorZETipoFuncion(ddlZonasEco.SelectedValue, ddlFPsPlaza.SelectedValue, CByte(ddlTiposPlaza.SelectedValue), vlOrdenarPor))
        End If

        If ddlCategos.SelectedValue <> "-1" Then
            dr = oPlaza.ObtenDetalleCategoria(ddlZonasEco.SelectedValue, ddlFPsPlaza.SelectedValue, Right(ddlCategos.SelectedValue, 3))

            txtbxClaveCatego.Text = Right(ddlCategos.SelectedValue, 3)
            txtBxHoras.Text = dr("HrsJornada").ToString
        Else
            txtbxClaveCatego.Text = String.Empty
            txtBxHoras.Text = String.Empty
        End If
    End Sub
    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, ByVal dt As DataTable, Optional ByVal SelectedValue As String = "")
        ddl.DataSource = dt
        ddl.DataTextField = TextField
        ddl.DataValueField = ValueField
        ddl.DataBind()
        If ddl.Items.Count > 0 Then
            If SelectedValue <> String.Empty Then ddl.SelectedValue = SelectedValue
        Else
            ddl.Items.Insert(0, New ListItem("SIN ELEMENTOS", "-1"))
        End If
    End Sub
    Private Sub ConfiguraItemsPagina(Optional ByVal pIsPostBack As Boolean = False)
        Dim BtnSearch As Button = CType(wucBuscaEmpsAux.FindControl("BtnSearch"), Button)
        Dim BtnNewSearch As Button = CType(wucBuscaEmpsAux.FindControl("BtnNewSearch"), Button)
        Dim BtnCancelSearch As Button = CType(wucBuscaEmpsAux.FindControl("BtnCancelSearch"), Button)
        Dim hfRFC As HiddenField = CType(wucBuscaEmpsAux.FindControl("hfRFC"), HiddenField)
        Dim pnlContentPanelBusqueda As Panel = CType(wucBuscaEmpsAux.FindControl("ContentPanelBusqueda"), Panel)
        Dim ddlTipoBusqueda As DropDownList = CType(wucBuscaEmpsAux.FindControl("ddlTipoBusqueda"), DropDownList)
        Dim oPlaza As SMP_Plazas
        Dim oZonaEco As ZonaEconomica
        Dim oPlantel As Plantel

        Select Case Request.Params("TipoMov")
            Case "A"
                lblH2.Text = "Sistema de nómina: ABC Plazas (Altas)"
                mvABCPLazas.SetActiveView(viewCapturaModif)
            Case "B"
                lblH2.Text = "Sistema de nómina: ABC Plazas (Bajas)"
                ddlTipoBusqueda.Enabled = False
                BtnSearch.Visible = False
                BtnNewSearch.Visible = False
                BtnCancelSearch.Visible = False
                mvABCPLazas.SetActiveView(viewBaja)
            Case "C"
                lblH2.Text = "Sistema de nómina: ABC Plazas (Modificación)"
                ddlTipoBusqueda.Enabled = False
                BtnSearch.Visible = False
                BtnNewSearch.Visible = False
                BtnCancelSearch.Visible = False
                mvABCPLazas.SetActiveView(viewCapturaModif)
        End Select

        If hfRFC.Value = String.Empty Then
            pnlContentPanelBusqueda.GroupingText = "Seleccione el empleado al que afectará el movimiento:"
            mvABCPLazas.Visible = False
        Else
            pnlContentPanelBusqueda.GroupingText = "Empleado al que afectará el movimiento:"
            mvABCPLazas.Visible = True
            oPlantel = New Plantel
            oPlaza = New SMP_Plazas
            oZonaEco = New ZonaEconomica

            LlenaDDL(ddlPlanteles, "Plantel", "IdPlantel", oPlantel.ObtenTodos(IIf(ddlOrdenPlanteles.SelectedValue = "", "CLAVEASC", ddlOrdenPlanteles.SelectedValue)))
            UpdDeptos()

            LlenaDDL(ddlZonasEco, "ZonaEconomica", "ClaveZonaEco", oZonaEco.ObtenTodasSinComodin(), txtbxZE.Text)
            LlenaDDL(ddlFPsPlaza, "DescPlazaTipo", "CvePlazaTipo", oPlaza.ObtenTipos())
            LlenaDDL(ddlTiposPlaza, "DescTipoPlaza", "IdEmpFuncion", oPlaza.ObtenTipificaciones())

            UpdDatosClavePlazas(True)
            End If
    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            ConfiguraItemsPagina(False)
        End If
    End Sub

    Protected Sub wucBuscaEmpsAux_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles wucBuscaEmpsAux.PreRender
        If IsPostBack Then
            Dim txtbxRFC As TextBox = CType(wucBuscaEmpsAux.FindControl("txtbxRFC"), TextBox)
            Dim pnlContentPanelBusqueda As Panel = CType(wucBuscaEmpsAux.FindControl("ContentPanelBusqueda"), Panel)

            If Request.Params(0).Contains("BtnSearch") Or Request.Params(1).Contains("BtnSearch") Then
                If txtbxRFC.Text.Trim <> String.Empty Then
                    mvABCPLazas.Visible = True
                    ConfiguraItemsPagina(True)
                Else
                    mvABCPLazas.Visible = False
                End If
            ElseIf Request.Params(0).Contains("BtnNewSearch") Or Request.Params(1).Contains("BtnNewSearch") Then
                mvABCPLazas.Visible = False
                pnlContentPanelBusqueda.GroupingText = "Seleccione el empleado al que afectará el movimiento:"
            ElseIf Request.Params(0).Contains("BtnCancelSearch") Or Request.Params(1).Contains("BtnCancelSearch") Then
                mvABCPLazas.Visible = True
                ConfiguraItemsPagina(True)
            ElseIf Request.Params("__EVENTTARGET") Is Nothing = False Then
                If Request.Params("__EVENTTARGET").Contains("lnkbtnrfc") Then
                    ConfiguraItemsPagina(True)
                    mvABCPLazas.Visible = True
                End If
            End If
        End If
    End Sub
    Protected Sub ddlZonasEco_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlZonasEco.SelectedIndexChanged
        UpdDatosClavePlazas(True)
    End Sub

    Protected Sub ddlFPsPlaza_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlFPsPlaza.SelectedIndexChanged
        UpdDatosClavePlazas(True)
    End Sub

    Protected Sub ddlTiposPlaza_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlTiposPlaza.SelectedIndexChanged
        UpdDatosClavePlazas(True)
    End Sub

    Protected Sub ddlCategos_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlCategos.SelectedIndexChanged
        Dim oPlaza As New SMP_Plazas
        Dim dr As DataRow

        dr = oPlaza.ObtenDetalleCategoria(ddlZonasEco.SelectedValue, ddlFPsPlaza.SelectedValue, Right(ddlCategos.SelectedValue, 3))

        txtbxClaveCatego.Text = Right(ddlCategos.SelectedValue, 3)
        txtBxHoras.Text = dr("HrsJornada").ToString
    End Sub

    Protected Sub ddlPlanteles_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlPlanteles.SelectedIndexChanged
        UpdDeptos()
        UpdDatosClavePlazas(True)
    End Sub

    Protected Sub ddlOrdenPlanteles_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlOrdenPlanteles.SelectedIndexChanged
        Dim oPlantel As New Plantel
        LlenaDDL(ddlPlanteles, "Plantel", "IdPlantel", oPlantel.ObtenTodos(ddlOrdenPlanteles.SelectedValue))
        UpdDeptos()
    End Sub

    Protected Sub ddlOrdenDeptos_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlOrdenDeptos.SelectedIndexChanged
        UpdDeptos()
    End Sub

    Protected Sub ddlOrdenCategos_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlOrdenCategos.SelectedIndexChanged
        Dim oPlaza As New SMP_Plazas

        UpdDatosClavePlazas(True)
    End Sub

    Protected Sub txtbxConsecutivo_TextChanged(sender As Object, e As System.EventArgs) Handles txtbxConsecutivo.TextChanged
        txtbxConsecutivo.Text = IIf(txtbxConsecutivo.Text.PadLeft(5, "0") = "00000", "", txtbxConsecutivo.Text.PadLeft(5, "0"))
        txtbxCons.Text = txtbxConsecutivo.Text
        ValidaPlaza()
    End Sub

    Protected Sub btnValidaPlaza_Click(sender As Object, e As System.EventArgs) Handles btnValidaPlaza.Click
        ValidaPlaza()
    End Sub
End Class
