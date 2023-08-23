Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.Empleados
Imports System.Data
Imports DataAccessLayer.COBAEV.Administracion
Imports BusinessRulesLayer.COBAEV.Validaciones
Imports DataAccessLayer.COBAEV.Plazas
Imports DataAccessLayer.COBAEV
Imports ClosedXML.Excel
Imports System.IO
Imports System.Drawing

Partial Class ABCPlazasBase
    Inherits System.Web.UI.Page

    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, ByVal dt As DataTable, Optional ByVal SelectedValue As String = "0")
        Dim R As DataRow = dt.NewRow
        'renglon de seleccion nula
        R(TextField) = "-"
        R(ValueField) = "0"
        dt.Rows.InsertAt(R, 0)

        If ddl.ID = "ddlQuincenaTermino" Then
            If (dt.Rows.Count > 1) Then
                If (dt.Rows(1).Item(ValueField).ToString <> "32767") Then
                    R = dt.NewRow
                    R(TextField) = "999999"
                    R(ValueField) = "32767"
                    dt.Rows.InsertAt(R, 1)
                End If
            End If
        End If

            ddl.DataSource = dt
        ddl.DataTextField = TextField
        ddl.DataValueField = ValueField
        ddl.DataBind()
        If SelectedValue Is Nothing = False Then ddl.SelectedValue = SelectedValue
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.Response.Expires = 0

            Dim btnCancelar As Button

            btnCancelar = CType(dvBotones.FindControl("btnCancelar"), Button)

            'If Request.Params("TipoOperacion") = "1" Then
            lbOtraOperacion.Visible = False
            'Else
            'lbOtraOperacion.Visible = True
            'End If

            Dim vlComplementoURL As String = String.Empty


            If Session("URLAnt") Is Nothing = False Then
                If Session("URLAnt").ToString.Contains(Request.Url.Segments(Request.Url.Segments.Length - 1).ToString) Then
                    btnCancelar.PostBackUrl = "~/MenuPrincipal.aspx"
                    'btnCancelar0.PostBackUrl = "~/MenuPrincipal.aspx"
                    'lbOtraOperacion0.PostBackUrl = "~/MenuPrincipal.aspx"
                Else
                    btnCancelar.PostBackUrl = "~/" + Session("URLAnt") + vlComplementoURL
                    'btnCancelar0.PostBackUrl = "~/" + Session("URLAnt")
                    'lbOtraOperacion0.PostBackUrl = "~/" + Session("URLAnt")
                End If
            Else
                btnCancelar.PostBackUrl = "~/MenuPrincipal.aspx"
                'btnCancelar0.PostBackUrl = "~/MenuPrincipal.aspx"
                'lbOtraOperacion0.PostBackUrl = "~/MenuPrincipal.aspx"
            End If


            Me.MultiView1.SetActiveView(Me.viewPlazas)
            Dim ddlPlantelesEmpleado As DropDownList = CType(Me.dvPlaza.FindControl("ddlPlantelesEmpleado"), DropDownList)
            Dim ddlPlantelesPlaza As DropDownList = CType(Me.dvPlaza.FindControl("ddlPlantelesPlaza"), DropDownList)
            Dim ddlZonaEconomica As DropDownList = CType(Me.dvPlaza.FindControl("ddlZonaEconomica"), DropDownList)
            Dim ddlZonaGeografica As DropDownList = CType(Me.dvPlaza.FindControl("ddlZonaGeografica"), DropDownList)
            Dim ddlCategorias As DropDownList = CType(Me.dvPlaza.FindControl("ddlCategorias"), DropDownList)
            Dim ddlPlazasEstatus As DropDownList = CType(Me.dvPlaza.FindControl("ddlPlazasEstatus"), DropDownList)
            Dim ddlQnaInicio As DropDownList = CType(Me.dvPlaza.FindControl("ddlQuincenaInicio"), DropDownList)
            Dim ddlQnaTermino As DropDownList = CType(Me.dvPlaza.FindControl("ddlQuincenaTermino"), DropDownList)
            Dim ddlSindicato As DropDownList = CType(Me.dvPlaza.FindControl("ddlSindicato"), DropDownList)
            Dim lblNombreEmpleado As Label = CType(Me.dvPlaza.FindControl("lblNombreEmpleado"), Label)
            Dim hidIdEmpleado As HiddenField = CType(Me.dvPlaza.FindControl("hidIdEmpleado"), HiddenField)
            Dim chkPermitirReasignacion As CheckBox = CType(Me.dvPlaza.FindControl("chkPermitirReasignacion"), CheckBox)
            Dim chkLiberarPlaza As CheckBox = CType(Me.dvPlaza.FindControl("chkLiberarPlaza"), CheckBox)

            hidIdPlazas.Text = ""
            hidIdTitular.Text = "0"
            chkLiberarPlaza.Checked = False
            chkLiberarPlaza.Visible = False

            Dim oPlantel As New Plantel
            Dim dr, drE As DataRow
            Dim drTE As DataRow
            Dim oEmpleadoPlaza As New EmpleadoPlazas
            Dim oEmpleado As New Empleado
            Dim oQna As New Quincenas

            If Not (Request.Params("IdPlaza") Is Nothing) Then
                oEmpleadoPlaza.IdPlaza = CType(Request.Params("IdPlaza"), Integer)

                dr = oEmpleadoPlaza.ObtenPorId()

                oEmpleadoPlaza.IdEmp = CType(dr("IdEmp"), Integer)
                drE = oEmpleado.BuscarPorId(oEmpleadoPlaza.IdEmp)
                lblNombreEmpleado.Text = drE("NumEmp") + " - " + drE("ApellidoPaterno") + " " + drE("ApellidoMaterno") + " " + drE("Nombre")
                hidIdEmpleado.Value = CType(dr("IdEmp"), Integer)
                drTE = oEmpleadoPlaza.ObtenUltimaOcupada(drE("RFC"))

                ddlZonaEconomica.Enabled = False

                If Request.Params("TipoOperacion") = "1" Then 'Insertar
                    'BindgvPlazasHistoria()
                    BindddlZonaGeografica(ddlZonaGeografica, 0)
                    BindddlZonaEconomica(ddlZonaEconomica, 0)
                    BindddlPlanteles(ddlPlantelesEmpleado, CInt(dr("IdPlantel")))
                    BindddlCategorias(ddlCategorias, CInt(dr("IdCategoria")), drTE("IdPlazaTipoOcupacion"))
                    BindddlPlanteles(ddlPlantelesPlaza, CInt(dr("IdPlantel")))
                    BindddlQuincenas(ddlQnaInicio, 0)
                    BindddlEstatusPlaza(ddlPlazasEstatus, 0)
                    BindddlSindicato(ddlSindicato, 0)
                    BindDatos(0, CInt(dr("IdPlantel")), CInt(dr("IdCategoria")), 0, drE("NumEmp"), 0, 0, 0)
                ElseIf Request.Params("TipoOperacion") = "0" Then 'Actualizar 
                    BindddlZonaGeografica(ddlZonaGeografica, 0)
                    BindddlZonaEconomica(ddlZonaEconomica, 0)
                    BindddlPlanteles(ddlPlantelesEmpleado, CInt(dr("IdPlantel")))
                    BindddlCategorias(ddlCategorias, CInt(dr("IdCategoria")), drTE("IdPlazaTipoOcupacion"))
                    BindddlPlanteles(ddlPlantelesPlaza, CInt(dr("IdPlantel")))
                    BindddlQuincenas(ddlQnaInicio, 0)
                    BindddlEstatusPlaza(ddlPlazasEstatus, 0)
                    BindddlSindicato(ddlSindicato, 0)
                    BindDatos(0, CInt(dr("IdPlantel")), CInt(dr("IdCategoria")), 0, drE("NumEmp"), 0, 0, 0)
                End If

            Else
                BindddlZonaGeografica(ddlZonaGeografica, 0)
                BindddlZonaEconomica(ddlZonaEconomica, 0)
                BindddlPlanteles(ddlPlantelesEmpleado, 0)
                BindddlCategorias(ddlCategorias, 0, 0)
                BindddlPlanteles(ddlPlantelesPlaza, 0)
                BindddlQuincenas(ddlQnaInicio, 0)
                BindddlEstatusPlaza(ddlPlazasEstatus, 0)
                BindddlSindicato(ddlSindicato, 0)
            End If
        End If
    End Sub

    Private Sub BindddlQuincenas(ByVal ddlQuincenas As DropDownList, ByVal IdSelected As Integer)
        Dim oQna As New Quincenas

        LlenaDDL(ddlQuincenas, "Quincena", "IdQuincena", oQna.ObtenListasCalculadas(), IdSelected)
    End Sub

    Private Sub BindddlCategorias(ByVal ddlCategorias As DropDownList, ByVal IdSelected As Integer, ByVal IdTipoEmp As Integer)
        Dim oCategoria As New Categoria

        'If IdTipoEmp = 2 Or IdTipoEmp = 0 Then
        LlenaDDL(ddlCategorias, "Categoria", "IdCategoria", oCategoria.ObtenTodas(), IdSelected)
        'Else
        'LlenaDDL(ddlCategorias, "Categoria", "IdCategoria", oCategoria.ObtenActivasBasificables(), IdSelected)
        'End If

    End Sub
    Private Sub BindddlZonaGeografica(ByVal ddlZonaGeografica As DropDownList, ByVal IdSelected As Integer)
        Dim oZG As New Zonageografica
        Dim oUsuario As New Usuario

        LlenaDDL(ddlZonaGeografica, "NombreZonaGeografica", "IdZonaGeografica", oZG.ObtenTodas(), IdSelected)
    End Sub
    Private Sub BindddlZonaEconomica(ByVal ddlZonaEconomica As DropDownList, ByVal IdSelected As Integer)
        Dim oZE As New ZonaEconomica
        Dim oUsuario As New Usuario

        LlenaDDL(ddlZonaEconomica, "DescZonaEco", "IdZonaEco", oZE.ObtenTodas(), IdSelected)
    End Sub


    Private Sub BindddlPlanteles(ByVal ddlPlantelesEmpleado As DropDownList, ByVal IdSelected As Integer)
        Dim oPlantel As New Plantel
        Dim oUsuario As New Usuario

        'If oUsuario.EsAdministrador(Session("Login")) Or oUsuario.EsSuperAdmin(Session("Login")) Then
        LlenaDDL(ddlPlantelesEmpleado, "DescPlantel", "IdPlantel", oPlantel.ObtenParaPagoPorUsr2(Session("Login"), True), IdSelected)
        'Else
        'LlenaDDL(ddlPlantelesEmpleado, "DescPlantel", "IdPlantel", oPlantel.ObtenPorUsuario(Session("Login")), IdSelected)
        'End If
    End Sub

    Private Sub BindddlSindicato(ByVal ddlSindicato As DropDownList, ByVal IdSelected As Integer)
        Dim oSindicato As New Sindicato
        Dim oUsuario As New Usuario

        LlenaDDL(ddlSindicato, "SiglasSindicato", "IdSindicato", oSindicato.ObtenTodos(True), IdSelected)
    End Sub

    Private Sub BindddlQuincenaTermino()
        Dim ddlQnaInicio As DropDownList = CType(Me.dvPlaza.FindControl("ddlQuincenaInicio"), DropDownList)
        Dim ddlQnaTermino As DropDownList = CType(Me.dvPlaza.FindControl("ddlQuincenaTermino"), DropDownList)
        Dim ddlPlazasEstatus As DropDownList = CType(Me.dvPlaza.FindControl("ddlPlazasEstatus"), DropDownList)
        Dim oQna As New Quincenas

        If ddlQnaInicio.SelectedValue > 0 Then
            'If ddlPlazasEstatus.SelectedValue = 3 Then
            LlenaDDL(ddlQnaTermino, "Quincena", "IdQuincena", oQna.ObtenQnasFinParaCaptura(CType(ddlQnaInicio.SelectedValue, Short)), 32767)
            'Else
            'LlenaDDL(ddlQnaTermino, "Quincena", "IdQuincena", oQna.ObtenParaVigFin(CType(ddlQnaInicio.SelectedValue, Short), CShort(12)), 0)
            'End If
        End If
    End Sub

    Private Sub BindddlEstatusPlaza(ByVal ddl As DropDownList, ByVal IdSelected As Integer)

        'LlenaDDL(ddlEstatusPlaza, "DescEstatusPlaza", "IdEstatusPlaza", oSMP_Plazas.ObtenEstatus(), Nothing)
        ddl.Items.Clear()
        ddl.Items.Add(New ListItem("-", "0"))
        ddl.Items.Add(New ListItem("Base", "3"))
        ddl.Items.Add(New ListItem("Provisional", "4"))
        ddl.Items.Add(New ListItem("Confianza", "10"))

        If Request.Params("IdPlaza") Is Nothing Then
            ddl.Items.Add(New ListItem("(Vacante)", "100"))
        End If

        ddl.SelectedValue = IdSelected
    End Sub

    Private Sub BindDatos(ByVal IdZonaEconomica As Integer,
                            IdPlanteles As Integer,
                            IdCategorias As Integer,
                            IdTipoPlaza As Integer,
                            NumEmp As String,
                            IdEstatusPlaza As Integer,
                            IdSindicato As Integer,
                            IdZonaGeografica As Integer
                            )
        Dim oEmp As New Empleado
        Dim oSMP_Plazas As New SMP_Plazas
        Dim drUsr As DataRow
        Dim oUsr As New Usuario


        drUsr = oUsr.ObtenerPropiedadesDelRol(Session("Login"))

        With gvDatos
            .DataSource = oSMP_Plazas.ObtenEstructura(IdZonaEconomica _
                                , IdPlanteles _
                                , IdCategorias _
                                , IdTipoPlaza _
                                , 0 _
                                , IdEstatusPlaza _
                                , drUsr("IdUsuario") _
                                , IdSindicato _
                                , IdZonaGeografica)
            .DataBind()
            lblTotalRegistros.Text = "Total de registros: " + gvDatos.Rows.Count.ToString
            .Visible = True
        End With

        With grdHistorial
            .DataSource = oSMP_Plazas.ObtenEstructuraHistorial(NumEmp)
            .DataBind()
            .Visible = True
        End With


    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            'Deshabilitamos el botón guardar para evitar el doble click
            'CType(Me.dvPlaza.FindControl("btnGuardar"), Button).Visible = False

            Dim ddlQnaInicio As DropDownList = CType(Me.dvPlaza.FindControl("ddlQuincenaInicio"), DropDownList)
            Dim ddlQnaTermino As DropDownList = CType(Me.dvPlaza.FindControl("ddlQuincenaTermino"), DropDownList)
            Dim ddlCategorias As DropDownList = CType(Me.dvPlaza.FindControl("ddlCategorias"), DropDownList)
            Dim ddlPlantelesEmpleado As DropDownList = CType(Me.dvPlaza.FindControl("ddlPlantelesEmpleado"), DropDownList)
            Dim ddlPlantelesPlaza As DropDownList = CType(Me.dvPlaza.FindControl("ddlPlantelesPlaza"), DropDownList)
            Dim hidIdEmpleado As HiddenField = CType(Me.dvPlaza.FindControl("hidIdEmpleado"), HiddenField)
            Dim ddlPlazasEstatus As DropDownList = CType(Me.dvPlaza.FindControl("ddlPlazasEstatus"), DropDownList)
            Dim txtObservaciones As TextBox = CType(Me.dvPlaza.FindControl("txtObservaciones"), TextBox)
            Dim chkLiberarPlaza As CheckBox = CType(Me.dvPlaza.FindControl("chkLiberarPlaza"), CheckBox)

            'Dim ddlEmpleadosFunciones As DropDownList = CType(Me.dvPlaza.FindControl("ddlEmpleadosFunciones"), DropDownList)
            Dim oPlaza As New SMP_Plazas
            Dim oEP As New EmpleadoPlazas

            With oEP
                .IdPlaza = hidIdPlazas.Text
                .IdPlantel = CType(ddlPlantelesEmpleado.SelectedValue, Short)
                .IdPlantelAdscripReal = CType(ddlPlantelesPlaza.SelectedValue, Short)
                .IdCategoria = CType(ddlCategorias.SelectedValue, Short)

            End With
            oPlaza.Guardar_SMP_PlazasECBOcup(oEP.IdPlaza, oEP.IdPlantel, oEP.IdPlantelAdscripReal, oEP.IdCategoria,
                        CType(ddlQnaInicio.SelectedValue, Short), CType(ddlQnaTermino.SelectedValue, Short),
                        CType(hidIdEmpleado.Value, Integer), 0,
                        IIf(chkLiberarPlaza.Checked = True, 0, CType(ddlPlazasEstatus.SelectedValue, Short)), txtObservaciones.Text,
                        IIf(Request.Params("TipoOperacion") = 1, 4, Request.Params("TipoOperacion")), CType(Session("ArregloAuditoria"), String()))

            Me.MultiView1.SetActiveView(Me.viewExito)
        Catch Ex As Exception
            Me.lblError.Text = Ex.Message
            Me.MultiView1.SetActiveView(Me.viewError)
        End Try
    End Sub

    Protected Sub gvDatos_SelectedIndexChanging(ByVal sender As Object, ByVal e As GridViewSelectEventArgs)

        Dim gvDatos As GridView = CType(Me.pnlDatos.FindControl("gvDatos"), GridView)
        Dim hidIdPlazas As TextBox = CType(Me.pnlDatos.FindControl("hidIdPlazas"), TextBox)

        If e.NewSelectedIndex >= 0 Then
            Dim lblIdPlazas As Label = CType(gvDatos.Rows(e.NewSelectedIndex).FindControl("lblIdPlazas"), Label)
            Dim lblTitular As Label = CType(gvDatos.Rows(e.NewSelectedIndex).FindControl("lblTitular"), Label)

            hidIdPlazas.Text = lblIdPlazas.Text
            hidIdTitular.Text = lblTitular.Text
        Else
            hidIdPlazas.Text = "0"
        End If
    End Sub

    Protected Sub ddlZonaEconomica_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ddlPlantelesPlaza As DropDownList = CType(Me.dvPlaza.FindControl("ddlPlantelesPlaza"), DropDownList)
        Dim ddlPlantelesEmpleado As DropDownList = CType(Me.dvPlaza.FindControl("ddlPlantelesPlaza"), DropDownList)
        Dim ddlZonaEconomica As DropDownList = CType(Me.dvPlaza.FindControl("ddlZonaEconomica"), DropDownList)

        BindddlPlanteles(ddlPlantelesPlaza, ddlPlantelesEmpleado.SelectedValue)
        If Not (Request.Params("IdPlaza") Is Nothing) Then
            BindDatosDesdeControles()
        End If

        ddlPlantelesPlaza.SelectedValue = ddlPlantelesEmpleado.SelectedValue
    End Sub
    Protected Sub ddlZonaGeografica_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ddlZonaGeografica As DropDownList = CType(Me.dvPlaza.FindControl("ddlZonaGeografica"), DropDownList)

    End Sub


    Protected Sub ddlQuincenaInicio_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        BindddlQuincenaTermino()
    End Sub

    Protected Sub BindDatosDesdeControles()
        Dim ddlCategorias As DropDownList = CType(Me.dvPlaza.FindControl("ddlCategorias"), DropDownList)
        Dim ddlPlantelesPlaza As DropDownList = CType(Me.dvPlaza.FindControl("ddlPlantelesPlaza"), DropDownList)
        Dim ddlPlazasEstatus As DropDownList = CType(Me.dvPlaza.FindControl("ddlPlazasEstatus"), DropDownList)
        Dim ddlSindicato As DropDownList = CType(Me.dvPlaza.FindControl("ddlSindicato"), DropDownList)
        Dim ddlZonaEconomica As DropDownList = CType(Me.dvPlaza.FindControl("ddlZonaEconomica"), DropDownList)
        Dim ddlZonaGeografica As DropDownList = CType(Me.dvPlaza.FindControl("ddlZonaGeografica"), DropDownList)


        Dim drE As DataRow
        Dim oEmpleado As New Empleado
        Dim hidIdEmpleado As HiddenField = CType(Me.dvPlaza.FindControl("hidIdEmpleado"), HiddenField)


        If hidIdEmpleado.Value <> "" Then
            drE = oEmpleado.BuscarPorId(CType(hidIdEmpleado.Value, Integer))

            BindDatos(ddlZonaEconomica.SelectedValue, ddlPlantelesPlaza.SelectedValue, ddlCategorias.SelectedValue, 0, drE("NumEmp"), If(Request.Params("IdPlaza") Is Nothing, ddlPlazasEstatus.SelectedValue, "0"), ddlSindicato.SelectedValue, ddlZonaGeografica.SelectedValue)
        Else
            BindDatos(ddlZonaEconomica.SelectedValue, ddlPlantelesPlaza.SelectedValue, ddlCategorias.SelectedValue, 0, 0, If(Request.Params("IdPlaza") Is Nothing, ddlPlazasEstatus.SelectedValue, "0"), ddlSindicato.SelectedValue, ddlZonaGeografica.SelectedValue)
        End If
    End Sub

    Protected Sub btnConsultar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        BindDatosDesdeControles()
    End Sub



    Protected Sub ddlPlantelesEmpleado_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ddlPlantel As DropDownList = CType(Me.dvPlaza.FindControl("ddlPlantelesEmpleado"), DropDownList)
        Dim ddlPlantelesPlaza As DropDownList = CType(Me.dvPlaza.FindControl("ddlPlantelesPlaza"), DropDownList)

        BindddlPlanteles(ddlPlantelesPlaza, ddlPlantel.SelectedValue)
        If Not (Request.Params("IdPlaza") Is Nothing) Then
            BindDatosDesdeControles()
        End If

        ddlPlantelesPlaza.SelectedValue = ddlPlantel.SelectedValue
    End Sub

    Protected Sub ddlPlazasEstatus_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ddlQuincenaInicio As DropDownList = CType(Me.dvPlaza.FindControl("ddlQuincenaInicio"), DropDownList)
        If ddlQuincenaInicio.items.count > 0 Then
            BindddlQuincenaTermino()
        End If

        If Not (Request.Params("IdPlaza") Is Nothing) Then
            BindDatosDesdeControles()
        End If
    End Sub

    Protected Sub btnUpdTitularPlaza_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub lbReintentarCaptura_Click(sender As Object, e As System.EventArgs) Handles lbReintentarCaptura.Click
        CType(Me.dvPlaza.FindControl("btnGuardar"), Button).Visible = True
        MultiView1.SetActiveView(viewPlazas)
    End Sub

    Protected Sub lbOtraOperacion_Click(sender As Object, e As System.EventArgs) Handles lbOtraOperacion.Click
        Dim btnCancelar As Button
        Dim strPostbackURL As String

        btnCancelar = CType(dvPlaza.FindControl("btnCancelar"), Button)

        strPostbackURL = String.Empty
        If btnCancelar Is Nothing = False Then
            strPostbackURL = btnCancelar.PostBackUrl
        End If

        btnCancelar = CType(dvPlaza.FindControl("btnCancelar"), Button)
        btnCancelar.PostBackUrl = strPostbackURL
        lbOtraOperacion0.PostBackUrl = strPostbackURL

        MultiView1.SetActiveView(viewPlazas)
    End Sub

    Protected Sub Page_LoadComplete(sender As Object, e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            'If Request.Params("TipoOperacion") <> "1" Then
            'pnlDatos.Visible = False
            'gvDatos.Visible = False
            'pnlInfPlaza.GroupingText = "Información de la plaza"
            'Else
            pnlInfPlaza.GroupingText = "Información de la plaza asignada o por asignar"
            pnlDatos.Visible = True
                gvDatos.Visible = True

            'End If
        End If
    End Sub

    Protected Sub btnContinuar_Click(sender As Object, e As System.EventArgs) Handles btnReintentarOp.Click
        MultiView1.SetActiveView(viewPlazas)
    End Sub

    Protected Sub lbUltNombTitular_Click(sender As Object, e As System.EventArgs)
        Dim lbMes As LinkButton
        lbMes = CType(sender, LinkButton)
        'BindgvAusenciasJustificadas(CByte(lbMes.CommandArgument), lbMes.ID.Replace("lb", ""))
    End Sub

    Protected Sub chkPermitirReasignacion_CheckedChanged(sender As Object, e As EventArgs)
        Dim oUsuario As New Usuario
        Dim chkPermitirReasignacion As CheckBox = CType(Me.dvPlaza.FindControl("chkPermitirReasignacion"), CheckBox)
        Dim CVIdTitular As CompareValidator = CType(Me.pnlDatos.FindControl("CVIdTitular"), CompareValidator)

        CVIdTitular.Enabled = True
        If oUsuario.EsAdministrador(Session("Login")) And chkPermitirReasignacion.Checked Then
            CVIdTitular.Enabled = False
            TitlePanelHistorial.Visible = True
            PanelHistorial.Visible = True
        End If
    End Sub
    Protected Sub gvDatos_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvDatos.RowDataBound
        Dim lblTitular As Label = CType(e.Row.FindControl("lblTitular"), Label)
        Dim lblNombreEmpleado As Label = CType(Me.dvPlaza.FindControl("lblNombreEmpleado"), Label)
        Dim lnSelectPlaza As ImageButton = CType(e.Row.FindControl("lnSelectPlaza"), ImageButton)
        Dim lblDescEstatusPlaza As Label = CType(e.Row.FindControl("lblDescEstatusPlaza"), Label)
        Dim lblIdPlazas As Label = CType(e.Row.FindControl("lblIdPlazas"), Label)
        Dim lblIdPlazas_Ocup As Label = CType(e.Row.FindControl("lblIdPlazas_Ocup"), Label)
        Dim gvPlazas As GridView = CType(dvPlaza.FindControl("gvPlazas"), GridView)
        Dim ibHistorial As ImageButton = CType(e.Row.FindControl("ibHistorial"), ImageButton)
        Dim ibEditar As ImageButton = CType(e.Row.FindControl("ibEditar"), ImageButton)

        If Not lblTitular Is Nothing Then
            ibHistorial.OnClientClick = "javascript:abreVentanaImpresion('../../Consultas/Plazas/PlazasEstructura.aspx?idPlazaOcup=" + lblIdPlazas.Text + "','PlazasHistorial');"
            If lblTitular.Text = "" And (Not (Request.Params("IdPlaza") Is Nothing)) Then
                lnSelectPlaza.Visible = True
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")

            Else
                lnSelectPlaza.Enabled = False
                lnSelectPlaza.Width = 1
                lnSelectPlaza.Height = 1
                lnSelectPlaza.ToolTip = "."
                e.Row.Attributes.Add("OnMouseOver", "")
                e.Row.Attributes.Add("OnMouseOut", "")
                If lblNombreEmpleado.Text = lblTitular.Text Then
                    lblTitular.BackColor = Drawing.Color.LightGreen
                    e.Row.BackColor = Drawing.Color.Orange
                    If Request.Params("TipoOperacion") = 0 Then
                        ibEditar.Visible = True
                    End If
                Else
                    ibEditar.Visible = False
                End If
            End If

        End If
    End Sub

    Protected Sub grdHistorial_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdHistorial.RowCommand
        Try
            Select Case e.CommandName
                Case "EliminarPlaza"
                    'Dim index As Integer = e.CommandArgument
                    Dim gvr As GridViewRow = CType(CType(e.CommandSource, ImageButton).NamingContainer, GridViewRow)
                    'Dim RowIndex As Integer = gvr.RowIndex

                    Dim lblIdPlaza As Label = CType(gvr.FindControl("lblIdPlazas"), Label)
                    Dim oPlaza As New SMP_Plazas

                    oPlaza.Guardar_SMP_PlazasECBOcup(lblIdPlaza.Text, 0, 0, 0,
                    0, 0, 0, 0, 0, "", 2, CType(Session("ArregloAuditoria"), String()))

                    Me.MultiView1.SetActiveView(Me.viewExito)
            End Select
        Catch Ex As Exception
            Me.lblError.Text = Ex.Message
            Me.MultiView1.SetActiveView(Me.viewError)
        End Try
    End Sub
    Protected Sub grdHistorial_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdHistorial.RowDataBound

    End Sub

    Protected Sub gvDatos_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvDatos.RowCommand
        Try
            Select Case e.CommandName
                Case "EditarPlaza"
                    Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                    Dim gvRow As GridViewRow = gvDatos.Rows(index)
                    Dim oQna As New Quincenas

                    Dim lblIdPlazas As Label = CType(gvDatos.Rows(index).FindControl("lblIdPlazas"), Label)
                    Dim lblIdEstatusPlazaBase As Label = CType(gvDatos.Rows(index).FindControl("lblIdEstatusPlazaBase"), Label)
                    Dim lblIdQnaVigIni As Label = CType(gvDatos.Rows(index).FindControl("lblIdQnaVigIni"), Label)
                    Dim lblIdQnaVigFin As Label = CType(gvDatos.Rows(index).FindControl("lblIdQnaVigFin"), Label)
                    Dim lblQuinTermino As Label = CType(gvDatos.Rows(index).FindControl("lblQuinTermino"), Label)

                    Dim ddlZonaEconomica As DropDownList = CType(Me.dvPlaza.FindControl("ddlZonaEconomica"), DropDownList)
                    Dim ddlZonaGeografica As DropDownList = CType(Me.dvPlaza.FindControl("ddlZonaGeografica"), DropDownList)
                    Dim ddlPlantelesEmpleado As DropDownList = CType(Me.dvPlaza.FindControl("ddlPlantelesEmpleado"), DropDownList)
                    Dim ddlPlantelesPlaza As DropDownList = CType(Me.dvPlaza.FindControl("ddlPlantelesPlaza"), DropDownList)
                    Dim ddlCategorias As DropDownList = CType(Me.dvPlaza.FindControl("ddlCategorias"), DropDownList)
                    Dim ddlSindicato As DropDownList = CType(Me.dvPlaza.FindControl("ddlSindicato"), DropDownList)
                    Dim txtObservaciones As TextBox = CType(Me.dvPlaza.FindControl("txtObservaciones"), TextBox)
                    Dim ddlPlazasEstatus As DropDownList = CType(Me.dvPlaza.FindControl("ddlPlazasEstatus"), DropDownList)

                    Dim ddlQnaInicio As DropDownList = CType(Me.dvPlaza.FindControl("ddlQuincenaInicio"), DropDownList)
                    Dim ddlQnaTermino As DropDownList = CType(Me.dvPlaza.FindControl("ddlQuincenaTermino"), DropDownList)
                    Dim chkLiberarPlaza As CheckBox = CType(Me.dvPlaza.FindControl("chkLiberarPlaza"), CheckBox)

                    CType(Me.pnlDatos.FindControl("hidIdPlazas"), TextBox).Text = lblIdPlazas.Text

                    ddlPlazasEstatus.SelectedValue = CInt(lblIdEstatusPlazaBase.Text)
                    ddlQnaInicio.SelectedValue = CInt(lblIdQnaVigIni.Text)
                    LlenaDDL(ddlQnaTermino, "Quincena", "IdQuincena", oQna.ObtenParaVigFin(CShort(lblIdQnaVigIni.Text), True), 32767)
                    Try
                        ddlQnaTermino.SelectedValue = CInt(lblIdQnaVigFin.Text)
                    Catch ex As Exception
                        Dim newListItem As ListItem
                        newListItem = New ListItem(lblQuinTermino.text, CInt(lblIdQnaVigFin.Text))
                        newListItem.Selected = True
                        ddlQnaTermino.Items.Add(newListItem)
                        ddlQnaTermino.SelectedValue = CInt(lblIdQnaVigFin.Text)
                    End Try

                    ddlZonaEconomica.Enabled = False
                    ddlZonaGeografica.Enabled = False
                    ddlPlantelesEmpleado.Enabled = False
                    ddlPlantelesPlaza.Enabled = False
                    ddlCategorias.Enabled = False
                    ddlSindicato.Enabled = False
                    txtObservaciones.Enabled = False
                    ddlPlazasEstatus.Enabled = False

                    CVIdPlazas.Enabled = False
                    CVIdTitular.Enabled = False

                    chkLiberarPlaza.Visible = True
                Case Else
                    CVIdPlazas.Enabled = True
                    CVIdTitular.Enabled = True

            End Select
        Catch Ex As Exception
            Me.lblError.Text = Ex.Message
            Me.MultiView1.SetActiveView(Me.viewError)
        End Try
    End Sub
End Class
