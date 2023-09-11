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

Partial Class PlazasBase
    Inherits System.Web.UI.Page

    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, ByVal dt As DataTable, Optional ByVal SelectedValue As String = "0")
        Dim R As DataRow = dt.NewRow
        'renglon de seleccion nula
        R(TextField) = "-"
        R(ValueField) = "0"
        dt.Rows.InsertAt(R, 0)

        If TextField = "Categoria" Then
            Dim dvOptions As DataView = New DataView(dt)
            dvOptions.Sort = "Categoria"
            ddl.DataSource = dvOptions
        Else
            ddl.DataSource = dt
        End If

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
            Dim ddlQnaTermino As DropDownList = CType(Me.dvPlaza.FindControl("ddlQuincenaTermino"), DropDownList)
            Dim ddlSindicato As DropDownList = CType(Me.dvPlaza.FindControl("ddlSindicato"), DropDownList)

            hidIdPlazas.Text = ""

            Dim oPlantel As New Plantel
            Dim oEmpleadoPlaza As New EmpleadoPlazas
            Dim oEmpleado As New Empleado
            Dim oQna As New Quincenas

            
            BindddlZonaGeografica(ddlZonaGeografica, 0)
            BindddlZonaEconomica(ddlZonaEconomica, 0)
            BindddlPlanteles(ddlPlantelesEmpleado, 0)
            BindddlCategorias(ddlCategorias, 0, 0)
            BindddlPlanteles(ddlPlantelesPlaza, 0)
            BindddlQuincenas(ddlQnaTermino, 0)
            BindddlEstatusPlaza(ddlPlazasEstatus, 0)
            BindddlSindicato(ddlSindicato, 0)
        End If
    End Sub

    Private Sub BindddlQuincenas(ByVal ddlQuincenas As DropDownList, ByVal IdSelected As Integer)
        Dim oQna As New Quincenas

        LlenaDDL(ddlQuincenas, "Quincena", "IdQuincena", oQna.ObtenListasCalculadas(), IdSelected)
    End Sub

    Private Sub BindddlCategorias(ByVal ddlCategorias As DropDownList, ByVal IdSelected As Integer, ByVal IdTipoEmp As Integer)
        Dim oCategoria As New Categoria

        LlenaDDL(ddlCategorias, "Categoria", "IdCategoria", oCategoria.ObtenTodas(), IdSelected)

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

    End Sub

    

    Protected Sub gvDatos_SelectedIndexChanging(ByVal sender As Object, ByVal e As GridViewSelectEventArgs)

        Dim gvDatos As GridView = CType(Me.pnlDatos.FindControl("gvDatos"), GridView)
        Dim hidIdPlazas As TextBox = CType(Me.pnlDatos.FindControl("hidIdPlazas"), TextBox)

        If e.NewSelectedIndex >= 0 Then
            Dim lblIdPlazas As Label = CType(gvDatos.Rows(e.NewSelectedIndex).FindControl("lblIdPlazas"), Label)

            hidIdPlazas.Text = lblIdPlazas.Text
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
        Dim ddlPlantelesPlaza As DropDownList = CType(Me.dvPlaza.FindControl("ddlPlantelesPlaza"), DropDownList)
        Dim ddlPlantelesEmpleado As DropDownList = CType(Me.dvPlaza.FindControl("ddlPlantelesPlaza"), DropDownList)
        Dim ddlZonaGeografica As DropDownList = CType(Me.dvPlaza.FindControl("ddlZonaGeografica"), DropDownList)

    End Sub


    Protected Sub BindDatosDesdeControles()
        Dim ddlCategorias As DropDownList = CType(Me.dvPlaza.FindControl("ddlCategorias"), DropDownList)
        Dim ddlPlantelesPlaza As DropDownList = CType(Me.dvPlaza.FindControl("ddlPlantelesPlaza"), DropDownList)
        Dim ddlPlazasEstatus As DropDownList = CType(Me.dvPlaza.FindControl("ddlPlazasEstatus"), DropDownList)
        Dim ddlSindicato As DropDownList = CType(Me.dvPlaza.FindControl("ddlSindicato"), DropDownList)
        Dim ddlZonaEconomica As DropDownList = CType(Me.dvPlaza.FindControl("ddlZonaEconomica"), DropDownList)
        Dim ddlZonaGeografica As DropDownList = CType(Me.dvPlaza.FindControl("ddlZonaGeografica"), DropDownList)


        BindDatos(ddlZonaEconomica.SelectedValue, ddlPlantelesPlaza.SelectedValue, ddlCategorias.SelectedValue, 0, 0, ddlPlazasEstatus.SelectedValue, ddlSindicato.SelectedValue, ddlZonaGeografica.SelectedValue)
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


    Protected Sub btnUpdTitularPlaza_Click(ByVal sender As Object, ByVal e As System.EventArgs)

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

    Protected Sub gvDatos_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvDatos.RowDataBound
        Dim lblTitular As Label = CType(e.Row.FindControl("lblTitular"), Label)
        Dim lblNombreEmpleado As Label = CType(Me.dvPlaza.FindControl("lblNombreEmpleado"), Label)

        Dim lblDescEstatusPlaza As Label = CType(e.Row.FindControl("lblDescEstatusPlaza"), Label)
        Dim lblIdPlazas As Label = CType(e.Row.FindControl("lblIdPlazas"), Label)
        Dim lblIdPlazas_Ocup As Label = CType(e.Row.FindControl("lblIdPlazas_Ocup"), Label)
        Dim gvPlazas As GridView = CType(dvPlaza.FindControl("gvPlazas"), GridView)
        Dim ibHistorial As ImageButton = CType(e.Row.FindControl("ibHistorial"), ImageButton)
        Dim ibNombramiento As ImageButton = CType(e.Row.FindControl("ibNombramiento"), ImageButton)
        Dim ibEditar As ImageButton = CType(e.Row.FindControl("ibEditar"), ImageButton)
        Dim hidCuentaAsignaciones As HiddenField = CType(e.Row.FindControl("hidCuentaAsignaciones"), HiddenField)

        If Not lblIdPlazas Is Nothing Then
            If Not lblTitular Is Nothing And lblTitular.Text <> "" Then
                ibHistorial.OnClientClick = "javascript:abreVentanaImpresion('../../Consultas/Plazas/PlazasEstructura.aspx?idPlazaOcup=" + lblIdPlazas.Text + "','PlazasHistorial');"
                If lblTitular.Text = "" And (Not (Request.Params("IdPlaza") Is Nothing)) Then
                    e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                    e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")

                Else
                    e.Row.Attributes.Add("OnMouseOver", "")
                    e.Row.Attributes.Add("OnMouseOut", "")
                End If

                ibEditar.Enabled = False
                ibEditar.ImageUrl = "~/Imagenes/ModificarDisabled.jpg"
                If Not CType(e.Row.FindControl("lblIdPlazas"), Label) Is Nothing Then
                    ibNombramiento.PostBackUrl = "../../ABC/Plazas/ABCPlazasBaseAsignacion.aspx?TipoOperacion=0&IdPlaza=" + lblIdPlazas.Text
                End If
            Else
                If CInt(hidCuentaAsignaciones.Value) = 0 Then
                    ibEditar.Enabled = True
                    ibEditar.ImageUrl = "~/Imagenes/Modificar.png"
                    ibEditar.PostBackUrl = "../../ABC/Plazas/ABCPlazasBase.aspx?TipoOperacion=0&IdPlaza=" + lblIdPlazas.Text
                Else
                    ibEditar.Enabled = False
                    ibEditar.ImageUrl = "~/Imagenes/ModificarDisabled.jpg"
                End If


                If Not CType(e.Row.FindControl("lblIdPlazas"), Label) Is Nothing Then
                    ibNombramiento.PostBackUrl = "../../ABC/Plazas/ABCPlazasBaseAsignacion.aspx?TipoOperacion=4&IdPlaza=" + lblIdPlazas.Text
                End If
            End If
        End If
    End Sub

    Protected Sub lbAsignarPlaza_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub gvDatos_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvDatos.RowCommand
        Select Case e.CommandName
            Case "NombrarPlaza"
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Dim gvRow As GridViewRow = gvDatos.Rows(index)

                Dim lblIdPlazas As Label = CType(gvDatos.Rows(index).FindControl("lblIdPlazas"), Label)
                Dim ibNombramiento As ImageButton = CType(gvDatos.Rows(index).FindControl("ibNombramiento"), ImageButton)



        End Select

    End Sub
End Class
