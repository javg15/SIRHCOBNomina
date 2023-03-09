Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.Empleados
Imports System.Data
Imports DataAccessLayer.COBAEV.Administracion
Imports BusinessRulesLayer.COBAEV.Validaciones
Imports DataAccessLayer.COBAEV
Partial Class wfControlIncidenciasPorEmp
    Inherits System.Web.UI.Page

    Private Function HayErroresAlAplicarValidaciones(ByVal pIdTipoIncidencia As Byte, ByVal pTipoOperacion As Byte,
                                                     ByVal pFolioIndicencia As String, ByVal pFolioISSSTE As String,
                                                     ByVal pIdTipoIncidenciaSubtipos As Byte) As Boolean
        Dim oEmp As New Empleado
        Dim oValidacion As New Validaciones
        Dim _DataCOBAEV As New DataCOBAEV
        Dim dsValida As DataSet
        Dim vlResult As Boolean
        Dim vlNomPag As String = Request.Url.Segments(Request.Url.Segments.Length - 1).ToString
        Dim hfRFC As HiddenField = CType(WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        oEmp.RFC = hfRFC.Value

        Dim dt As DataTable = oEmp.ObtenDatosPersonales()

        dsValida = _DataCOBAEV.setDataSetErrores()

        With oValidacion
            .RFC = hfRFC.Value
            .TipoOperacion = pTipoOperacion
            .FechaInicial = CDate(txtbxFechaIni.Text)
            .FechaFinal = CDate(txtbxFechaFin.Text)
            .IdTipoIncidencia = pIdTipoIncidencia
            .FolioIncidencia = pFolioIndicencia
            .FolioISSSTE = pFolioISSSTE
            .IdTipoIncidenciaSubtipos = pIdTipoIncidenciaSubtipos
            .IdEmp = dt.Rows(0)("IdEmp")


            If Not .ValidaPagsIncidencias(dsValida, vlNomPag, pIdTipoIncidencia, pTipoOperacion, pIdTipoIncidenciaSubtipos) Then
                vlResult = True
                Session.Add("dsValida", dsValida)
                wucMuestraErrores.ActualizaContenido()
                MultiView1.SetActiveView(viewErrores)
            Else
                vlResult = False
                Session.Remove("dsValida")
            End If
        End With

        Return vlResult
    End Function

    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, ByVal dt As DataTable, ByVal SelectedValue As String)
        ddl.DataSource = dt
        ddl.DataTextField = TextField
        ddl.DataValueField = ValueField
        ddl.DataBind()
        If SelectedValue Is Nothing = False Then ddl.SelectedValue = SelectedValue
    End Sub

    Private Sub SetVisibleBotones_wucBuscaEmps(ByVal pValor As Boolean)
        Dim BtnNewSearch As Button = CType(WucBuscaEmpleados1.FindControl("BtnNewSearch"), Button)
        Dim BtnCancelSearch As Button = CType(Me.WucBuscaEmpleados1.FindControl("BtnCancelSearch"), Button)
        Dim BtnSearch As Button = CType(Me.WucBuscaEmpleados1.FindControl("BtnSearch"), Button)

        BtnNewSearch.Visible = pValor
        BtnCancelSearch.Visible = pValor
        BtnSearch.Visible = pValor
    End Sub

    Private Sub RecargaInformacion()
        BindddlAños()
        BindddlTiposDeIncidencias()
        BindDatos()
        BindgvResumenIncidencias()
        BindgvDiasEco(1, "Enero")
        pnlPermEcoDetalleMes.Visible = True
        BindgvAusenciasJustificadas(1, "Enero")
        pnlAusenciasJustificadasDetalleMes.Visible = True
        BindgvAusenciasNoJustificadas(1, "Enero")
        pnlAusenciasNoJustificadasDetalleMes.Visible = True
        BindgvOtros(1, "Enero")
        pnlOtrosDetalleMes.Visible = True
        BindgvPermSindic(1, "Enero")
        pnlPermSindicDetalleMes.Visible = True
        BindgvPerm2Hrs(1, "Enero")
        pnlPerm2HrsDetalleMes.Visible = True
        BindgvLicMed(1, "Enero")
        pnlLicMedDetalleMes.Visible = True


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
                Me.btnConsultar.Enabled = False
            Else
                Me.btnConsultar.Enabled = True
            End If
        End With
    End Sub
    Private Sub BindddlTiposDeIncidencias()
        Dim oIncidencias As New Incidencias

        Dim oUsuario As New Usuario
        Dim drUsuario As DataRow

        oUsuario.Login = Session("Login")
        drUsuario = oUsuario.ObtenerPorLogin()

        LlenaDDL(ddlTiposDeIncidencias, "DescTipoIncidencia", "IdTipoIncidencia", oIncidencias.ObtenTipos(drUsuario("IdUsuario")), Nothing)
    End Sub
    Private Sub BindDatos()
        Dim oEmp As New Empleado
        Dim txtbxRFC As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxRFC"), TextBox)
        Dim txtbxNomEmp As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxNomEmp"), TextBox)
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        Dim hfNomEmp As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfNomEmp"), HiddenField)

        oEmp.RFC = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))
        oEmp.IdEmp = 0
        MultiView1.ActiveViewIndex = -1
        If oEmp.RFC <> String.Empty Then
            MultiView1.SetActiveView(viewControlIncidencias)
            If Not Session("RFCParaCons") Is Nothing Or hfNomEmp.Value.Trim <> String.Empty Then
                Me.lblEmpInf.Text = "Información relacionada con el empleado: " + IIf(hfNomEmp.Value = String.Empty, Session("ApePatParaCons") + " " + Session("ApeMatParaCons") + " " + Session("NombreParaCons"), hfNomEmp.Value)
                pnlControlIncidencias.GroupingText = "Incidencias del empleado en el Año: " + Me.ddlAños.SelectedItem.Text
            Else
                Me.lblEmpInf.Text = String.Empty
                pnlControlIncidencias.GroupingText = "Incidencias del empleado en el Año: Sin espicificar"
                Me.lblFechaIni.Enabled = False
                Me.txtbxFechaIni.Enabled = False
                Me.btnGuardarIncidencia.Enabled = False
            End If
        End If
    End Sub
    Private Sub BindgvResumenIncidencias(Optional ByVal pNomCortoTipoIncidencia As String = "")
        Dim oIncidencias As New Incidencias
        Dim hfRFC As HiddenField = CType(WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        Dim dsIncidencias As DataSet

        hfRFC.Value = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))

        dsIncidencias = oIncidencias.ObtenPorAnioEmp(hfRFC.Value, CShort(ddlAños.SelectedValue))

        If pNomCortoTipoIncidencia = "" Or pNomCortoTipoIncidencia = "PE" Then
            gvResumenPermEco.DataSource = dsIncidencias.Tables(0)
            If dsIncidencias.Tables(0).Rows.Count = 0 Then
                gvResumenPermEco.EmptyDataText = "Sin información de permisos económicos del empleado en el Año: " + Me.ddlAños.SelectedItem.Text
            End If
            gvResumenPermEco.DataBind()
        End If

        If pNomCortoTipoIncidencia = "" Or pNomCortoTipoIncidencia = "AJ" Then
            gvResumenAusenciasJustificadas.DataSource = dsIncidencias.Tables(1)
            If dsIncidencias.Tables(1).Rows.Count = 0 Then
                gvResumenAusenciasJustificadas.EmptyDataText = "Sin información de AusenciasJustificadas del empleado en el Año: " + Me.ddlAños.SelectedItem.Text
            End If
            gvResumenAusenciasJustificadas.DataBind()
        End If

        If pNomCortoTipoIncidencia = "" Or pNomCortoTipoIncidencia = "ANJ" Then
            gvResumenAusenciasNoJustificadas.DataSource = dsIncidencias.Tables(2)
            If dsIncidencias.Tables(2).Rows.Count = 0 Then
                gvResumenAusenciasNoJustificadas.EmptyDataText = "Sin información de Ausencias No Justificadas del empleado en el Año: " + Me.ddlAños.SelectedItem.Text
            End If
            gvResumenAusenciasNoJustificadas.DataBind()
        End If

        If pNomCortoTipoIncidencia = "" Or pNomCortoTipoIncidencia = "OTR" Then
            gvResumenOtros.DataSource = dsIncidencias.Tables(3)
            If dsIncidencias.Tables(3).Rows.Count = 0 Then
                gvResumenOtros.EmptyDataText = "Sin información de Otros del empleado en el Año: " + Me.ddlAños.SelectedItem.Text
            End If
            gvResumenOtros.DataBind()
        End If


        If pNomCortoTipoIncidencia = "" Or pNomCortoTipoIncidencia = "PS" Then
            gvResumenPermSindic.DataSource = dsIncidencias.Tables(5)
            If dsIncidencias.Tables(5).Rows.Count = 0 Then
                gvResumenPermSindic.EmptyDataText = "Sin información de permanencias sindicales del empleado en el Año: " + Me.ddlAños.SelectedItem.Text
            End If
            gvResumenPermSindic.DataBind()
        End If

        If pNomCortoTipoIncidencia = "" Or pNomCortoTipoIncidencia = "P2H" Then
            gvResumenPerm2Hrs.DataSource = dsIncidencias.Tables(6)
            If dsIncidencias.Tables(6).Rows.Count = 0 Then
                gvResumenPerm2Hrs.EmptyDataText = "Sin información de permisos de 2 horas del empleado en el Año: " + Me.ddlAños.SelectedItem.Text
            End If
            gvResumenPerm2Hrs.DataBind()
        End If

        If pNomCortoTipoIncidencia = "" Or pNomCortoTipoIncidencia = "LM" Then
            gvResumenLicMed.DataSource = dsIncidencias.Tables(7)
            If dsIncidencias.Tables(7).Rows.Count = 0 Then
                gvResumenLicMed.EmptyDataText = "Sin información de Licencias Médicas del empleado en el Añoi: " + Me.ddlAños.SelectedItem.Text
            End If
            gvResumenLicMed.DataBind()
        End If
    End Sub
    Private Sub BindgvAusenciasJustificadas(ByVal pMes As Byte, ByVal pNombreMes As String)
        Dim oIncidencias As New Incidencias
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)

        hfRFC.Value = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))

        pnlAusenciasJustificadasDetalleMes.GroupingText = "Detalle de Ausencias Justificadas en el mes: " + pNombreMes
        pnlAusenciasJustificadasDetalleMes.Visible = True

        With gvAusenciasJustificadas
            .DataSource = oIncidencias.ObtenPorTipoAnioMesEmp(hfRFC.Value, CShort(Me.ddlAños.SelectedValue), pMes, "AJ")
            .DataBind()
            .Visible = True
        End With
    End Sub

    Private Sub BindgvDiasEco(ByVal pMes As Byte, ByVal pNombreMes As String)
        Dim oIncidencias As New Incidencias
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)

        hfRFC.Value = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))

        pnlPermEcoDetalleMes.GroupingText = "Detalle de permisos económicos en el mes: " + pNombreMes
        pnlPermEcoDetalleMes.Visible = True

        With gvDiasEco
            .DataSource = oIncidencias.ObtenPorTipoAnioMesEmp(hfRFC.Value, CShort(Me.ddlAños.SelectedValue), pMes, "PE")
            .DataBind()
            .Visible = True
        End With
    End Sub
    Private Sub BindgvAusenciasNoJustificadas(ByVal pMes As Byte, ByVal pNombreMes As String)
        Dim oIncidencias As New Incidencias
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)

        hfRFC.Value = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))

        pnlAusenciasNoJustificadasDetalleMes.GroupingText = "Detalle de AusenciasNoJustificadas en el mes: " + pNombreMes
        pnlAusenciasNoJustificadasDetalleMes.Visible = True

        With gvAusenciasNoJustificadas
            .DataSource = oIncidencias.ObtenPorTipoAnioMesEmp(hfRFC.Value, CShort(Me.ddlAños.SelectedValue), pMes, "ANJ")
            .DataBind()
            .Visible = True
        End With
    End Sub
    Private Sub BindgvOtros(ByVal pMes As Byte, ByVal pNombreMes As String)
        Dim oIncidencias As New Incidencias
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)

        hfRFC.Value = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))

        pnlOtrosDetalleMes.GroupingText = "Detalle de Otros en el mes: " + pNombreMes
        pnlOtrosDetalleMes.Visible = True

        With gvOtros
            .DataSource = oIncidencias.ObtenPorTipoAnioMesEmp(hfRFC.Value, CShort(Me.ddlAños.SelectedValue), pMes, "OTR")
            .DataBind()
            .Visible = True
        End With
    End Sub
    Private Sub BindgvPermSindic(ByVal pMes As Byte, ByVal pNombreMes As String)
        Dim oIncidencias As New Incidencias
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)

        hfRFC.Value = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))

        pnlPermSindicDetalleMes.GroupingText = "Detalle de permanencias sindicales en el mes: " + pNombreMes
        pnlPermSindicDetalleMes.Visible = True

        With gvPermSindic
            .DataSource = oIncidencias.ObtenPorTipoAnioMesEmp(hfRFC.Value, CShort(Me.ddlAños.SelectedValue), pMes, "PS")
            .DataBind()
            .Visible = True
        End With
    End Sub
    'BindgvLicMed
    Private Sub BindgvLicMed(ByVal pMes As Byte, ByVal pNombreMes As String)
        Dim oIncidencias As New Incidencias
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)

        hfRFC.Value = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))


        pnlLicMedDetalleMes.GroupingText = "Detalle de licencias médicas: " + pNombreMes
        pnlLicMedDetalleMes.Visible = True

        With gvLicMed
            .DataSource = oIncidencias.ObtenPorTipoAnioMesEmp(hfRFC.Value, CShort(Me.ddlAños.SelectedValue), pMes, "LM")
            .DataBind()
            .Visible = True
        End With
    End Sub

    Private Sub BindgvPerm2Hrs(ByVal pMes As Byte, ByVal pNombreMes As String)
        Dim oIncidencias As New Incidencias
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)

        hfRFC.Value = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))

        pnlPerm2HrsDetalleMes.GroupingText = "Detalle de permisos de 2 horas en el mes: " + pNombreMes
        pnlPerm2HrsDetalleMes.Visible = True

        With gvPerm2Hrs
            .DataSource = oIncidencias.ObtenPorTipoAnioMesEmp(hfRFC.Value, CShort(Me.ddlAños.SelectedValue), pMes, "P2H")
            .DataBind()
            .Visible = True
        End With
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.Response.Expires = 0
        End If
    End Sub
    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            RecargaInformacion()
        End If
    End Sub
    Protected Sub WucBuscaEmpleados1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles WucBuscaEmpleados1.PreRender
        If IsPostBack Then
            Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
            Dim txtbxRFC As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxRFC"), TextBox)
            If Request.Params(0).Contains("BtnSearch") Or Request.Params(1).Contains("BtnSearch") Then
                If txtbxRFC.Text.Trim <> String.Empty Then
                    RecargaInformacion()
                    MultiView1.Visible = True
                Else
                    MultiView1.Visible = False
                End If
            ElseIf Request.Params(0).Contains("BtnNewSearch") Or Request.Params(1).Contains("BtnNewSearch") Then
                MultiView1.Visible = False
            ElseIf Request.Params(0).Contains("BtnCancelSearch") Or Request.Params(1).Contains("BtnCancelSearch") Then
                MultiView1.Visible = True
            ElseIf Request.Params("__EVENTTARGET") Is Nothing = False Then
                If Request.Params("__EVENTTARGET").Contains("lnkbtnrfc") Then
                    RecargaInformacion()
                    MultiView1.Visible = True
                End If
            End If
        End If
    End Sub

    Protected Sub btnConsultar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        BindDatos()
        BindgvResumenIncidencias()
        BindgvDiasEco(1, "Enero")
        pnlPermEcoDetalleMes.Visible = True
        BindgvAusenciasJustificadas(1, "Enero")
        pnlAusenciasJustificadasDetalleMes.Visible = True
        BindgvAusenciasNoJustificadas(1, "Enero")
        pnlAusenciasNoJustificadasDetalleMes.Visible = True
        BindgvOtros(1, "Enero")
        pnlOtrosDetalleMes.Visible = True
        BindgvPermSindic(1, "Enero")
        pnlPermSindicDetalleMes.Visible = True
        BindgvPerm2Hrs(1, "Enero")
        pnlPerm2HrsDetalleMes.Visible = True
        BindgvLicMed(1, "Enero")
        pnlLicMedDetalleMes.Visible = True
    End Sub

    Protected Sub btnCancelarCapturaPermisoEco_Click(sender As Object, e As System.EventArgs) Handles btnCancelar.Click
        SetVisibleBotones_wucBuscaEmps(True)
        pnlFechIni.Visible = False
        pnlFechFin.Visible = False
        pnlFechaJust.Visible = False
        MultiView1.SetActiveView(viewControlIncidencias)
    End Sub

    Protected Sub btnCapturarIncidencia_Click(sender As Object, e As System.EventArgs) Handles btnCapturarIncidencia.Click
        Dim oIncidencia As New Incidencias
        Dim dtIncidencia As DataTable

        dtIncidencia = oIncidencia.ObtenTipoIncidenciaPorId(CShort(ddlTiposDeIncidencias.SelectedValue))

        SetVisibleBotones_wucBuscaEmps(False)
        pnlABCIncidencias.GroupingText = "Captura/Modificación de " + ddlTiposDeIncidencias.SelectedItem.Text '+ ", año: " + ddlAños.SelectedItem.Text
        txtbxNomCortoIncidencia.Text = dtIncidencia.Rows(0).Item("NomCortoTipoIncidencia").ToString

        LlenaDDL(ddlSubtipo, "DescSubtipo", "IdTiposDeIndicenciasSubtipos", oIncidencia.ObtenTiposDeIncidenciaSubtipos(ddlTiposDeIncidencias.SelectedValue, 0), Nothing)

        VisualizarControlesForm(ddlSubtipo.Items(0).Value)
        btnGuardarIncidencia.CommandArgument = "CAPTURA"

        MultiView1.SetActiveView(viewABCIncidencias)
    End Sub

    Protected Sub txtbxFechaIni_TextChanged(sender As Object, e As System.EventArgs) Handles txtbxFechaIni.TextChanged
        If txtbxFechaFin.Enabled = False Then
            txtbxFechaFin.Text = txtbxFechaIni.Text
        End If
    End Sub

    Protected Sub btnGuardarIncidencia_Click(sender As Object, e As System.EventArgs) Handles btnGuardarIncidencia.Click
        Dim oIncidencia As New Incidencias
        Dim oEmp As New Empleado
        Dim oUsuario As New Usuario
        Dim drUsuario As DataRow
        Dim drEmp As DataRow
        Dim hfRFC As HiddenField = CType(WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        Dim drIncidencia As DataRow
        Dim vlFolioIncidencia As String
        Dim resList As String()


        oUsuario.Login = Session("Login")
        drUsuario = oUsuario.ObtenerPorLogin()

        oEmp.RFC = hfRFC.Value
        drEmp = oEmp.ObtenDatosPersonales().Rows(0)




        Select Case btnGuardarIncidencia.CommandArgument
            Case "CAPTURA"
                If HayErroresAlAplicarValidaciones(CByte(ddlTiposDeIncidencias.SelectedValue), 1, String.Empty, String.Empty, CByte(ddlSubtipo.SelectedValue)) Then
                    Exit Sub
                End If

                vlFolioIncidencia = oIncidencia.Inserta(CShort(CDate(txtbxFechaIni.Text).Year),
                                                        txtbxFolioIncidencia.Text,
                                                        CByte(ddlTiposDeIncidencias.SelectedValue),
                                                        CInt(drEmp("IdEmp")),
                                                        CDate(txtbxFechaIni.Text),
                                                        CDate(txtbxFechaFin.Text),
                                                        0,
                                                        txtbxFolioISSSTE.Text,
                                                        txtFolioIncidencia2.Text,
                                                        CShort(drUsuario("IdUsuario")),
                                                        1,
                                                        txtbxFechaJust.Text,
                                                        CByte(ddlSubtipo.SelectedValue),
                                                        CType(Session("ArregloAuditoria"), String()))
                'La función retorna 2 valores separados por comas, necesitamos el primer valor que corresponde al folio de la incidencia
                ' el segundo valor coreresponde al folio que se genera automaticamente, ej: falta resultante por 3 retardos
                resList = vlFolioIncidencia.Split(",")

                drIncidencia = oIncidencia.ObtenPorId(resList(0))
                BindgvResumenIncidencias(txtbxNomCortoIncidencia.Text)
                Select Case txtbxNomCortoIncidencia.Text
                    Case "PE"
                        BindgvDiasEco(CByte(drIncidencia("Mes")), drIncidencia("NombreMes").ToString)
                    Case "AJ"
                        BindgvAusenciasJustificadas(CByte(drIncidencia("Mes")), drIncidencia("NombreMes").ToString)
                    Case "ANJ"
                        BindgvAusenciasNoJustificadas(CByte(drIncidencia("Mes")), drIncidencia("NombreMes").ToString)
                    Case "OTR"
                        BindgvOtros(CByte(drIncidencia("Mes")), drIncidencia("NombreMes").ToString)
                    Case "PS"
                        BindgvPermSindic(CByte(drIncidencia("Mes")), drIncidencia("NombreMes").ToString)
                    Case "P2H"
                        BindgvPerm2Hrs(CByte(drIncidencia("Mes")), drIncidencia("NombreMes").ToString)
                    Case "LM"
                        BindgvLicMed(CByte(drIncidencia("Mes")), drIncidencia("NombreMes").ToString)
                End Select
            Case "MODIFICACION"
                drIncidencia = oIncidencia.ObtenPorId(txtId.Text)

                If HayErroresAlAplicarValidaciones(CByte(drIncidencia("IdTipoIncidencia")), 0, txtbxFolioIncidencia.Text, txtbxFolioISSSTE.Text, CByte(ddlSubtipo.SelectedValue)) Then
                    Exit Sub
                End If

                oIncidencia.Actualiza(CInt(txtId.Text),
                     CShort(CDate(txtbxFechaIni.Text).Year), txtbxFolioIncidencia.Text,
                                      CByte(drIncidencia("IdTipoIncidencia")), CInt(drEmp("IdEmp")),
                    CDate(txtbxFechaIni.Text), CDate(txtbxFechaFin.Text), 0, txtbxFolioISSSTE.Text, txtFolioIncidencia2.Text, CShort(drUsuario("IdUsuario")), 0,
                     txtbxFechaJust.Text, CByte(ddlSubtipo.SelectedValue),
                    CType(Session("ArregloAuditoria"), String()))

                BindgvResumenIncidencias(txtbxNomCortoIncidencia.Text)
                Select Case txtbxNomCortoIncidencia.Text
                    Case "PE"
                        BindgvDiasEco(CByte(drIncidencia("Mes")), drIncidencia("NombreMes").ToString)
                    Case "AJ"
                        BindgvAusenciasJustificadas(CByte(drIncidencia("Mes")), drIncidencia("NombreMes").ToString)
                    Case "ANJ"
                        BindgvAusenciasNoJustificadas(CByte(drIncidencia("Mes")), drIncidencia("NombreMes").ToString)
                    Case "OTR"
                        BindgvOtros(CByte(drIncidencia("Mes")), drIncidencia("NombreMes").ToString)
                    Case "PS"
                        BindgvPermSindic(CByte(drIncidencia("Mes")), drIncidencia("NombreMes").ToString)
                    Case "P2H"
                        BindgvPerm2Hrs(CByte(drIncidencia("Mes")), drIncidencia("NombreMes").ToString)
                    Case "LM"
                        BindgvLicMed(CByte(drIncidencia("Mes")), drIncidencia("NombreMes").ToString)

                End Select
            Case "JUSTIFICACION"
                drIncidencia = oIncidencia.ObtenPorId(txtId.Text)

                If HayErroresAlAplicarValidaciones(CByte(drIncidencia("IdTipoIncidencia")), 0, txtbxFolioIncidencia.Text, txtbxFolioISSSTE.Text, CByte(ddlSubtipo.SelectedValue)) Then
                    Exit Sub
                End If

                If txtbxFechaJust.Text.Trim = String.Empty Then
                    txtbxFechaJust.Text = Date.Today.ToString("dd/MM/yyyy")
                End If

                oIncidencia.Actualiza(CInt(txtId.Text), CShort(CDate(txtbxFechaIni.Text).Year), txtbxFolioIncidencia.Text,
                                      CByte(drIncidencia("IdTipoIncidencia")), CInt(drEmp("IdEmp")),
                    CDate(txtbxFechaIni.Text), CDate(txtbxFechaFin.Text), 0, txtbxFolioISSSTE.Text, txtFolioIncidencia2.Text, CShort(drUsuario("IdUsuario")), 0,
                     txtbxFechaJust.Text, CByte(ddlSubtipo.SelectedValue),
                    CType(Session("ArregloAuditoria"), String()))

                BindgvResumenIncidencias(txtbxNomCortoIncidencia.Text)
                Select Case txtbxNomCortoIncidencia.Text
                    Case "PE"
                        BindgvDiasEco(CByte(drIncidencia("Mes")), drIncidencia("NombreMes").ToString)
                    Case "AJ"
                        BindgvAusenciasJustificadas(CByte(drIncidencia("Mes")), drIncidencia("NombreMes").ToString)
                    Case "ANJ"
                        BindgvAusenciasNoJustificadas(CByte(drIncidencia("Mes")), drIncidencia("NombreMes").ToString)
                    Case "OTR"
                        BindgvOtros(CByte(drIncidencia("Mes")), drIncidencia("NombreMes").ToString)
                    Case "PS"
                        BindgvPermSindic(CByte(drIncidencia("Mes")), drIncidencia("NombreMes").ToString)
                    Case "P2H"
                        BindgvPerm2Hrs(CByte(drIncidencia("Mes")), drIncidencia("NombreMes").ToString)
                    Case "LM"
                        BindgvLicMed(CByte(drIncidencia("Mes")), drIncidencia("NombreMes").ToString)

                End Select
        End Select

        SetVisibleBotones_wucBuscaEmps(True)
        MultiView1.SetActiveView(viewControlIncidencias)
    End Sub

    Protected Sub ibEditar_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs)
        Dim ib As ImageButton
        Dim gvr As GridViewRow

        ib = CType(sender, ImageButton)
        gvr = ib.NamingContainer

        Dim lblIdIncidencia As Label = CType(gvr.FindControl("lblIdIncidencia"), Label)
        Dim oIncidencia As New Incidencias
        Dim drIncidencia As DataRow
        Dim dtIncidencia As DataTable

        drIncidencia = oIncidencia.ObtenPorId(lblIdIncidencia.Text)
        dtIncidencia = oIncidencia.ObtenTipoIncidenciaPorId(CShort(drIncidencia("IdTipoIncidencia")))

        SetVisibleBotones_wucBuscaEmps(False)
        pnlABCIncidencias.GroupingText = "Captura/Modificación de " + dtIncidencia.Rows(0).Item("DescTipoIncidencia").ToString '+ ", año:  " + ddlAños.SelectedItem.Text

        LlenaDDL(ddlSubtipo, "DescSubtipo", "IdTiposDeIndicenciasSubtipos", oIncidencia.ObtenTiposDeIncidenciaSubtipos(CShort(drIncidencia("IdTipoIncidencia")), 0), drIncidencia("IdTiposDeIndicenciasSubtipos").ToString)
        VisualizarControlesForm(ddlSubtipo.Items(0).Value)

        txtId.Text = drIncidencia("Id").ToString
        txtbxNomCortoIncidencia.Text = dtIncidencia.Rows(0).Item("NomCortoTipoIncidencia").ToString
        txtbxFolioIncidencia.Text = drIncidencia("FolioIncidencia").ToString

        txtbxFolioISSSTE.Text = drIncidencia("FolioISSSTE").ToString
        txtbxFolioISSSTE.Enabled = True


        txtbxFechaIni.Text = Left(drIncidencia("FechaIni").ToString, 10)
        'ValidationSummary2.Enabled = True
        txtbxFechaFin.Text = Left(drIncidencia("FechaFin").ToString, 10)
        txtbxFechaJust.Text = IIf(Left(drIncidencia("FechaJust").ToString, 10) <> "31/12/2099", Left(drIncidencia("FechaJust").ToString, 10).ToString, String.Empty)
        txtFolioIncidencia2.Text = drIncidencia("FolioIncidencia2").ToString

        btnGuardarIncidencia.CommandArgument = "MODIFICACION"

        MultiView1.SetActiveView(viewABCIncidencias)
    End Sub

    Protected Sub ibEliminar_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs)
        Dim ib As ImageButton
        Dim gvr As GridViewRow
        Dim drIncidencia As DataRow
        Dim dtIncidencia As DataTable

        ib = CType(sender, ImageButton)
        gvr = ib.NamingContainer

        Dim lblIdIncidencia As Label = CType(gvr.FindControl("lblIdIncidencia"), Label)
        Dim oIncidencia As New Incidencias

        drIncidencia = oIncidencia.ObtenPorId(lblIdIncidencia.Text)
        dtIncidencia = oIncidencia.ObtenTipoIncidenciaPorId(CShort(drIncidencia("IdTipoIncidencia")))

        SetVisibleBotones_wucBuscaEmps(False)
        pnlABCIncidencias.GroupingText = "Captura/Modificación de " + dtIncidencia.Rows(0).Item("DescTipoIncidencia").ToString '+ ", año: " + ddlAños.SelectedItem.Text
        txtId.Text = drIncidencia("Id").ToString
        txtbxNomCortoIncidencia.Text = dtIncidencia.Rows(0).Item("NomCortoTipoIncidencia").ToString
        txtbxFolioIncidencia.Text = drIncidencia("FolioIncidencia").ToString
        txtbxFechaIni.Text = Left(drIncidencia("FechaIni").ToString, 10)
        txtbxFechaIni.Enabled = True
        txtbxFechaIni_CV.Enabled = True
        txtbxFechaIni_RFV.Enabled = True
        ibFechaIni.Visible = True
        txtbxFechaFin.Text = Left(drIncidencia("FechaFin").ToString, 10)
        'ValidationSummary2.Enabled = True

        txtbxFechaFin.Enabled = CBool(dtIncidencia.Rows(0).Item("RequierePeriodo"))
        ibFechaFin.Visible = txtbxFechaFin.Enabled
        txtbxFechaFin_RFV.Enabled = CBool(dtIncidencia.Rows(0).Item("RequierePeriodo"))
        txtbxFechaFin_CV.Enabled = CBool(dtIncidencia.Rows(0).Item("RequierePeriodo"))
        txtbxFechaFin_CV2.Enabled = CBool(dtIncidencia.Rows(0).Item("RequierePeriodo"))

        txtbxFechaJust.Text = IIf(Left(drIncidencia("FechaJust").ToString, 10) <> "31/12/2099", Left(drIncidencia("FechaJust").ToString, 10).ToString, String.Empty)
        txtbxFechaJust.Enabled = False
        ibFechaJust.Visible = False
        txtbxFechaJust_CV.Enabled = False

        If txtbxNomCortoIncidencia.Text <> "LM" Then
            LlenaDDL(ddlSubtipo, "DescSubtipo", "IdTiposDeIndicenciasSubtipos", oIncidencia.ObtenTiposDeIncidenciaSubtipos(0, 0), drIncidencia("IdTiposDeIndicenciasSubtipos").ToString)
            ddlSubtipo.Enabled = False
            ddlSubtipo_RFV.Enabled = False
        Else
            txtbxFechaJust.Enabled = True
            txtbxFechaJust_CV.Enabled = True
            ibFechaJust.Visible = True
            LlenaDDL(ddlSubtipo, "DescSubtipo", "IdTiposDeIndicenciasSubtipos", oIncidencia.ObtenTiposDeIncidenciaSubtipos(8, 0), drIncidencia("IdTiposDeIndicenciasSubtipos").ToString)
            ddlSubtipo.Enabled = True
            ddlSubtipo_RFV.Enabled = True
        End If

        'If HayErroresAlAplicarValidaciones(CByte(drIncidencia("IdTipoIncidencia")), 2, lblFolioIncidencia.Text, txtbxFolioISSSTE.Text) Then
        ' Exit Sub
        'End If

        oIncidencia.Elimina(lblIdIncidencia.Text, CType(Session("ArregloAuditoria"), String()))

        BindgvResumenIncidencias(drIncidencia("NomCortoTipoIncidencia").ToString)
        Select Case drIncidencia("NomCortoTipoIncidencia").ToString
            Case "PE"
                BindgvDiasEco(CByte(drIncidencia("Mes")), drIncidencia("NombreMes").ToString)
            Case "AJ"
                BindgvAusenciasJustificadas(CByte(drIncidencia("Mes")), drIncidencia("NombreMes").ToString)
            Case "ANJ"
                BindgvAusenciasNoJustificadas(CByte(drIncidencia("Mes")), drIncidencia("NombreMes").ToString)
            Case "OTR"
                BindgvOtros(CByte(drIncidencia("Mes")), drIncidencia("NombreMes").ToString)
            Case "PS"
                BindgvPermSindic(CByte(drIncidencia("Mes")), drIncidencia("NombreMes").ToString)
            Case "P2H"
                BindgvPerm2Hrs(CByte(drIncidencia("Mes")), drIncidencia("NombreMes").ToString)
            Case "LM"
                BindgvLicMed(CByte(drIncidencia("Mes")), drIncidencia("NombreMes").ToString)
        End Select
    End Sub

    Protected Sub lbVerDetallePermEco_Click(sender As Object, e As System.EventArgs)
        Dim lbMes As LinkButton
        lbMes = CType(sender, LinkButton)
        BindgvDiasEco(CByte(lbMes.CommandArgument), lbMes.ID.Replace("lb", ""))
    End Sub

    Protected Sub lbVerDetalleAusenciasJustificadas_Click(sender As Object, e As System.EventArgs)
        Dim lbMes As LinkButton
        lbMes = CType(sender, LinkButton)
        BindgvAusenciasJustificadas(CByte(lbMes.CommandArgument), lbMes.ID.Replace("lb", ""))
    End Sub

    Protected Sub lbVerDetalleAusenciasNoJustificadas_Click(sender As Object, e As System.EventArgs)
        Dim lbMes As LinkButton
        lbMes = CType(sender, LinkButton)
        BindgvAusenciasNoJustificadas(CByte(lbMes.CommandArgument), lbMes.ID.Replace("lb", ""))
    End Sub
    Protected Sub lbVerDetalleOtros_Click(sender As Object, e As System.EventArgs)
        Dim lbMes As LinkButton
        lbMes = CType(sender, LinkButton)
        BindgvOtros(CByte(lbMes.CommandArgument), lbMes.ID.Replace("lb", ""))
    End Sub
    Protected Sub lbVerDetallePermSindic_Click(sender As Object, e As System.EventArgs)
        Dim lbMes As LinkButton
        lbMes = CType(sender, LinkButton)
        BindgvPermSindic(CByte(lbMes.CommandArgument), lbMes.ID.Replace("lb", ""))
    End Sub
    Protected Sub lbVerDetallePerm2Hrs_Click(sender As Object, e As System.EventArgs)
        Dim lbMes As LinkButton
        lbMes = CType(sender, LinkButton)
        BindgvPerm2Hrs(CByte(lbMes.CommandArgument), lbMes.ID.Replace("lb", ""))
    End Sub

    Protected Sub lbVerDetalleLicMed_Click(sender As Object, e As System.EventArgs)
        Dim lbMes As LinkButton
        lbMes = CType(sender, LinkButton)
        BindgvLicMed(CByte(lbMes.CommandArgument), lbMes.ID.Replace("lb", ""))
    End Sub
    Protected Sub gvDiasEco_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvDiasEco.SelectedIndexChanged

    End Sub
    Protected Sub gvAusenciasJustificadas_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvAusenciasJustificadas.SelectedIndexChanged

    End Sub
    Protected Sub gvAusenciasNoJustificadas_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvAusenciasNoJustificadas.SelectedIndexChanged

    End Sub
    Protected Sub gvOtros_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvOtros.SelectedIndexChanged

    End Sub
    Protected Sub gvPermSindic_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvPermSindic.SelectedIndexChanged

    End Sub
    Protected Sub gvPerm2Hrs_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvPerm2Hrs.SelectedIndexChanged

    End Sub

    Protected Sub gvLicMed_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvPerm2Hrs.SelectedIndexChanged

    End Sub
    Private Sub gvRowDataBound(ByVal pGVREA As System.Web.UI.WebControls.GridViewRowEventArgs)
        Select Case pGVREA.Row.RowType
            Case DataControlRowType.DataRow
                Dim oUsr As New Usuario
                Dim dr As DataRow
                Dim lblIdUsuario As Label = CType(pGVREA.Row.FindControl("lblIdUsuario"), Label)
                Dim lblLogin As Label = CType(pGVREA.Row.FindControl("lblLogin"), Label)
                Dim lblFechaJust As Label = CType(pGVREA.Row.FindControl("lblFechaJust"), Label)
                Dim ibJustifPorJefe As ImageButton = CType(pGVREA.Row.FindControl("ibJustifPorJefe"), ImageButton)

                If lblFechaJust Is Nothing = False Then
                    If lblFechaJust.Text <> String.Empty And lblFechaJust.Text <> "31/12/2099" Then
                        'ibJustifPorJefe.ImageUrl = "~/Imagenes/ModificarDisabled.jpg"
                        'ibJustifPorJefe.ToolTip = ibJustifPorJefe.ToolTip + ". Opción no disponible. Si desea realizar algún cambio al registro tendrá que eliminarlo y capturarlo nuevamente."
                        'ibJustifPorJefe.Enabled = False
                    Else
                        'ibJustifPorJefe.ImageUrl = "~/Imagenes/Modificar.png"
                        'ibJustifPorJefe.ToolTip = "Justificar retardo (Justificación por Jefe)"
                        'ibJustifPorJefe.Enabled = True
                    End If
                End If

                oUsr.IdUsuario = CShort(lblIdUsuario.Text)
                dr = oUsr.ObtenerPorId()
                lblLogin.Text = dr("Login")
                lblLogin.ToolTip = dr("ApellidoPaterno").ToString.Trim + " " + dr("ApellidoMaterno").ToString.Trim + " " + dr("Nombre").ToString.Trim

                pGVREA.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                pGVREA.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End Select
    End Sub

    Protected Sub gvDiasEco_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvDiasEco.RowDataBound
        gvRowDataBound(e)
    End Sub
    Protected Sub gvAusenciasJustificadas_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvAusenciasJustificadas.RowDataBound
        gvRowDataBound(e)
    End Sub

    Protected Sub gvAusenciasNoJustificadas_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvAusenciasNoJustificadas.RowDataBound
        gvRowDataBound(e)
    End Sub

    Protected Sub gvOtros_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvOtros.RowDataBound
        gvRowDataBound(e)
    End Sub
    Protected Sub gvPermSindic_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvPermSindic.RowDataBound
        gvRowDataBound(e)
    End Sub
    Protected Sub gvPerm2Hrs_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvPerm2Hrs.RowDataBound
        gvRowDataBound(e)
    End Sub
    Protected Sub gvLicMed_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvLicMed.RowDataBound
        gvRowDataBound(e)
    End Sub

    Protected Sub ibFechaIni_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibFechaIni.Click
        Dim vlCalendario As Calendar = CType(wucCalendarFechIni.FindControl("Calendar1"), Calendar)

        If txtbxFechaIni.Text.Trim <> String.Empty And IsDate(txtbxFechaIni.Text.Trim) Then
            vlCalendario.SelectedDate = CDate(txtbxFechaIni.Text).ToString("dd/MM/yyyy")
            vlCalendario.VisibleDate = CDate(txtbxFechaIni.Text).ToString("dd/MM/yyyy")

            wucCalendarFechIni.Calendar1VisibleMonthChanged()
        Else
            vlCalendario.VisibleDate = Today
            vlCalendario.SelectedDate = Nothing

            wucCalendarFechIni.Calendar1VisibleMonthChanged()
        End If

        pnlFechIni.Visible = Not pnlFechIni.Visible
        pnlFechFin.Visible = False
    End Sub

    Protected Sub wucCalendarFechIni_PreRender(sender As Object, e As System.EventArgs) Handles wucCalendarFechIni.PreRender
        Dim vlCalendario As Calendar = CType(wucCalendarFechIni.FindControl("Calendar1"), Calendar)

        If IsPostBack Then
            If Request.Params(0).Contains("Calendar1") Or Request.Params(1).Contains("Calendar1") Then
                If txtbxFechaIni.Text <> vlCalendario.SelectedDate().ToString("dd/MM/yyyy") Then
                    txtbxFechaIni.Text = vlCalendario.SelectedDate().ToString("dd/MM/yyyy")
                    If txtbxFechaIni.Text = "01/01/0001" Then txtbxFechaIni.Text = String.Empty
                    txtbxFechaFin.Text = txtbxFechaIni.Text
                    If txtbxFechaIni.Text <> "01/01/0001" And txtbxFechaIni.Text <> String.Empty Then pnlFechIni.Visible = Not pnlFechIni.Visible

                    ValidacionPrevia()
                End If
            End If
        End If
    End Sub

    Protected Sub ibFechaFin_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibFechaFin.Click
        Dim vlCalendario As Calendar = CType(wucCalendarFechFin.FindControl("Calendar1"), Calendar)

        If txtbxFechaFin.Text.Trim <> String.Empty And IsDate(txtbxFechaFin.Text.Trim) Then
            vlCalendario.SelectedDate = CDate(txtbxFechaFin.Text).ToString("dd/MM/yyyy")
            vlCalendario.VisibleDate = CDate(txtbxFechaFin.Text).ToString("dd/MM/yyyy")

            wucCalendarFechFin.Calendar1VisibleMonthChanged()
        Else
            vlCalendario.VisibleDate = Today
            vlCalendario.SelectedDate = Nothing

            wucCalendarFechFin.Calendar1VisibleMonthChanged()
        End If

        pnlFechFin.Visible = Not pnlFechFin.Visible
        pnlFechIni.Visible = False
    End Sub

    Protected Sub ibJustifPorJefe_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs)
        Dim ib As ImageButton
        Dim gvr As GridViewRow

        ib = CType(sender, ImageButton)
        gvr = ib.NamingContainer

        Dim lblFolioIncidencia As Label = CType(gvr.FindControl("lblFolioIncidencia"), Label)
        Dim oIncidencia As New Incidencias
        Dim drIncidencia As DataRow
        Dim dtIncidencia As DataTable

        Dim lblIdIncidencia As Label = CType(gvr.FindControl("lblId"), Label)

        drIncidencia = oIncidencia.ObtenPorId(lblIdIncidencia.Text)
        dtIncidencia = oIncidencia.ObtenTipoIncidenciaPorId(CShort(drIncidencia("IdTipoIncidencia")))

        SetVisibleBotones_wucBuscaEmps(False)
        pnlABCIncidencias.GroupingText = "Justificación de " + dtIncidencia.Rows(0).Item("DescTipoIncidencia").ToString '+ ", año: " + ddlAños.SelectedItem.Text

        txtId.Text = dtIncidencia.Rows(0).Item("Id").ToString
        txtbxNomCortoIncidencia.Text = dtIncidencia.Rows(0).Item("NomCortoTipoIncidencia").ToString
        txtbxFolioIncidencia.Text = drIncidencia("FolioIncidencia").ToString

        txtbxFechaIni.Text = Left(drIncidencia("FechaIni").ToString, 10)
        txtbxFechaIni.Enabled = False
        ibFechaIni.Visible = False
        txtbxFechaIni_CV.Enabled = False
        txtbxFechaIni_RFV.Enabled = False
        'ValidationSummary2.Enabled = False

        txtbxFechaFin.Text = Left(drIncidencia("FechaFin").ToString, 10)
        txtbxFechaFin.Enabled = False
        ibFechaFin.Visible = False
        txtbxFechaFin_RFV.Enabled = False
        txtbxFechaFin_CV.Enabled = False
        txtbxFechaFin_CV2.Enabled = False

        txtbxFechaJust.Text = IIf(Left(drIncidencia("FechaJust").ToString, 10) <> "31/12/2099", Left(drIncidencia("FechaJust").ToString, 10).ToString, String.Empty)
        txtbxFechaJust.Enabled = True
        ibFechaJust.Visible = True
        txtbxFechaJust_CV.Enabled = True

        LlenaDDL(ddlSubtipo, "DescSubtipo", "IdTiposDeIndicenciasSubtipos", oIncidencia.ObtenTiposDeIncidenciaSubtipos(drIncidencia("IdTipoIncidencia"), 0), drIncidencia("IdTiposDeIndicenciasSubtipos").ToString)
        ddlSubtipo.Enabled = CBool(dtIncidencia.Rows(0).Item("TieneSubtipos"))
        ddlSubtipo_RFV.Enabled = CBool(dtIncidencia.Rows(0).Item("TieneSubtipos"))
        'txtbxFechaJust.Enabled = CBool(dtIncidencia.Rows(0).Item("MuestraOpcsDeJustificacion"))
        'txtbxFechaJust_CV.Enabled = CBool(dtIncidencia.Rows(0).Item("MuestraOpcsDeJustificacion"))
        'ibFechaJust.Visible = CBool(dtIncidencia.Rows(0).Item("MuestraOpcsDeJustificacion"))


        btnGuardarIncidencia.CommandArgument = "JUSTIFICACION"

        MultiView1.SetActiveView(viewABCIncidencias)
    End Sub

    Protected Sub ibFechaJust_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibFechaJust.Click
        Dim vlCalendario As Calendar = CType(wucCalendarFechJust.FindControl("Calendar1"), Calendar)

        If txtbxFechaJust.Text.Trim <> String.Empty And IsDate(txtbxFechaJust.Text.Trim) Then
            vlCalendario.SelectedDate = CDate(txtbxFechaJust.Text).ToString("dd/MM/yyyy")
            vlCalendario.VisibleDate = CDate(txtbxFechaJust.Text).ToString("dd/MM/yyyy")

            wucCalendarFechJust.Calendar1VisibleMonthChanged()
        Else
            vlCalendario.VisibleDate = Today
            vlCalendario.SelectedDate = Nothing

            wucCalendarFechJust.Calendar1VisibleMonthChanged()
        End If

        pnlFechaJust.Visible = Not pnlFechaJust.Visible
    End Sub

    Protected Sub wucCalendarFechJust_PreRender(sender As Object, e As System.EventArgs) Handles wucCalendarFechJust.PreRender
        Dim vlCalendario As Calendar = CType(wucCalendarFechJust.FindControl("Calendar1"), Calendar)

        If IsPostBack Then
            If (Request.Params(0).Contains("Calendar1") Or Request.Params(1).Contains("Calendar1")) And Left(vlCalendario.SelectedDate.ToString, 10) <> "01/01/0001" Then
                If txtbxFechaJust.Text <> vlCalendario.SelectedDate().ToString("dd/MM/yyyy") Then
                    txtbxFechaJust.Text = vlCalendario.SelectedDate().ToString("dd/MM/yyyy")
                    If txtbxFechaJust.Text = "01/01/0001" Then txtbxFechaJust.Text = String.Empty
                    If txtbxFechaJust.Text <> "01/01/0001" And txtbxFechaJust.Text <> String.Empty Then pnlFechaJust.Visible = Not pnlFechaJust.Visible
                End If
            End If
        End If
    End Sub

    Protected Sub wucCalendarFechFin_PreRender(sender As Object, e As System.EventArgs) Handles wucCalendarFechFin.PreRender
        Dim vlCalendario As Calendar = CType(wucCalendarFechFin.FindControl("Calendar1"), Calendar)

        If IsPostBack Then
            If Request.Params(0).Contains("Calendar1") Or Request.Params(1).Contains("Calendar1") Then
                If txtbxFechaFin.Text <> vlCalendario.SelectedDate().ToString("dd/MM/yyyy") Then
                    txtbxFechaFin.Text = vlCalendario.SelectedDate().ToString("dd/MM/yyyy")
                    If txtbxFechaFin.Text = "01/01/0001" Then txtbxFechaFin.Text = String.Empty
                    'If txtbxFechaFin.Enabled = False Then txtbxFechaFin.Text = txtbxFechaIni.Text
                    If txtbxFechaFin.Text <> "01/01/0001" And txtbxFechaFin.Text <> String.Empty Then pnlFechFin.Visible = Not pnlFechFin.Visible
                End If
            End If
        End If
    End Sub

    Protected Sub btnContinuar_Click(sender As Object, e As System.EventArgs) Handles btnContinuar.Click
        MultiView1.SetActiveView(viewABCIncidencias)
    End Sub

    Protected Sub btnContinuar0_Click(sender As Object, e As System.EventArgs) Handles btnContinuar0.Click
        SetVisibleBotones_wucBuscaEmps(True)
        MultiView1.SetActiveView(viewControlIncidencias)
    End Sub

    Protected Sub ddlSubtipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSubtipo.SelectedIndexChanged
        VisualizarControlesForm(ddlSubtipo.SelectedValue)

    End Sub

    Private Sub VisualizarControlesForm(ByVal idSubtipoIncidencia As Integer)
        Dim dtIncidenciaSubtipos As DataTable
        Dim oIncidencia As New Incidencias

        If idSubtipoIncidencia = 1 Then
            dtIncidenciaSubtipos = oIncidencia.ObtenTipoIncidenciaPorId(CShort(ddlTiposDeIncidencias.SelectedValue))
        Else
            dtIncidenciaSubtipos = oIncidencia.ObtenTiposDeIncidenciaSubtipos(0, idSubtipoIncidencia)
        End If

        ddlSubtipo.Enabled = True
        txtId.Text = ""
        txtbxFolioIncidencia.Text = "POR ASIGNAR"
        lblMensajePrevio.Text = ""
        txtbxFechaIni.Text = String.Empty
        txtbxFechaFin.Text = String.Empty
        txtbxFechaJust.Text = String.Empty
        txtFolioIncidencia2.Text = String.Empty
        txtbxFolioISSSTE.Text = String.Empty

        txtbxFolioISSSTE.Enabled = CBool(dtIncidenciaSubtipos.Rows(0).Item("RequiereFolioISSSTE"))

        txtbxFechaJust.Enabled = CBool(dtIncidenciaSubtipos.Rows(0).Item("MuestraOpcsDeJustificacion"))
        txtbxFechaJust_CV.Enabled = CBool(dtIncidenciaSubtipos.Rows(0).Item("MuestraOpcsDeJustificacion"))
        ibFechaJust.Visible = CBool(dtIncidenciaSubtipos.Rows(0).Item("MuestraOpcsDeJustificacion"))

        txtbxFechaIni.Enabled = CBool(dtIncidenciaSubtipos.Rows(0).Item("RequierePeriodo"))
        txtbxFechaIni_RFV.Enabled = CBool(dtIncidenciaSubtipos.Rows(0).Item("RequierePeriodo"))
        txtbxFechaIni_CV.Enabled = CBool(dtIncidenciaSubtipos.Rows(0).Item("RequierePeriodo"))
        ibFechaIni.Visible = CBool(dtIncidenciaSubtipos.Rows(0).Item("RequierePeriodo"))

        txtbxFechaFin.Enabled = CBool(dtIncidenciaSubtipos.Rows(0).Item("RequierePeriodo"))
        txtbxFechaFin_RFV.Enabled = CBool(dtIncidenciaSubtipos.Rows(0).Item("RequierePeriodo"))
        txtbxFechaFin_CV.Enabled = CBool(dtIncidenciaSubtipos.Rows(0).Item("RequierePeriodo"))
        ibFechaFin.Visible = CBool(dtIncidenciaSubtipos.Rows(0).Item("RequierePeriodo"))

        txtFolioIncidencia2.Enabled = CBool(dtIncidenciaSubtipos.Rows(0).Item("RequiereFolioIncidencia"))
    End Sub

    Private Sub ValidacionPrevia()
        Dim drVPreviaInsercion As DataRow
        Dim oIncidencia As New Incidencias
        Dim oEmp As New Empleado
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)

        oEmp.RFC = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))
        'validación previa a la inserción, para revisar si se debe enviar un mensaje preventivo al usuario
        'ej: 3 retardos generan una falta
        If txtbxFechaIni.Text <> "" And txtbxFechaFin.Text <> "" Then
            drVPreviaInsercion = oIncidencia.VInsercionPrevia_Incidencias(oEmp.RFC,
                                        CByte(ddlTiposDeIncidencias.SelectedValue),
                                       CDate(txtbxFechaIni.Text),
                                       CDate(txtbxFechaFin.Text),
                                       1,
                                       txtbxFolioIncidencia.Text,
                                       CByte(ddlSubtipo.SelectedValue))

            lblMensajePrevio.Text = ""
            lblMensajePrevio.Visible = False
            If drVPreviaInsercion("Mensaje").ToString <> "" Then
                lblMensajePrevio.Text = drVPreviaInsercion("Mensaje").ToString
                lblMensajePrevio.Visible = True
            End If
        End If
    End Sub

    Private Sub CreaLinkParaImpresion()
        Dim RFCEmp As String
        Dim Ejercicio As String
        Dim PeriodoActual As String
        Dim hfRFC As HiddenField = CType(WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        PeriodoActual = "0"
        If radioPeriodoAct.Checked Then
            PeriodoActual = "1"
        End If

        'Imprime reporte
        RFCEmp = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))
        Ejercicio = ddlAños.SelectedValue
        Me.btnRptLicMed.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" _
                   + "?" _
                   + "&RFCEmp=" + RFCEmp _
                   + "&Ejercicio=" + Ejercicio _
                   + "&PeriodoActual=" + PeriodoActual _
                   + "&IdReporte=160" + "','resumenLicMedxEmp_" + RFCEmp + "'); return false;"
    End Sub
    Protected Sub radioPeriodoAct_CheckedChanged(sender As Object, e As EventArgs) Handles radioPeriodoAct.CheckedChanged
        CreaLinkParaImpresion()
    End Sub
    Protected Sub radioPeriodoAnt_CheckedChanged(sender As Object, e As EventArgs) Handles radioPeriodoAnt.CheckedChanged
        CreaLinkParaImpresion()
    End Sub
    Protected Sub gvResumenLicMed_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvResumenLicMed.RowDataBound
        CreaLinkParaImpresion()
    End Sub

    Protected Sub btnRptLicMed_Click(sender As Object, e As EventArgs) Handles btnRptLicMed.Click

    End Sub

End Class
