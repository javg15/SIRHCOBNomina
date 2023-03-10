Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.Empleados
Imports System.Data
Imports DataAccessLayer.COBAEV.Administracion
Imports BusinessRulesLayer.COBAEV.Validaciones
Imports DataAccessLayer.COBAEV.Plazas
Imports DataAccessLayer.COBAEV

Partial Class ABCPlazasBase
    Inherits System.Web.UI.Page

    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, ByVal dt As DataTable, Optional ByVal SelectedValue As String = "0")
        Dim R As DataRow = dt.NewRow
        'renglon de seleccion nula
        R(TextField) = "-"
        R(ValueField) = "0"
        dt.Rows.InsertAt(R, 0)

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

            If Request.Params("TipoOperacion") = "1" Then
                lbOtraOperacion.Visible = False
            Else
                lbOtraOperacion.Visible = True
            End If

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
            Dim ddlCategorias As DropDownList = CType(Me.dvPlaza.FindControl("ddlCategorias"), DropDownList)
            Dim ddlPlazasEstatus As DropDownList = CType(Me.dvPlaza.FindControl("ddlPlazasEstatus"), DropDownList)
            Dim ddlQnaInicio As DropDownList = CType(Me.dvPlaza.FindControl("ddlQuincenaInicio"), DropDownList)
            Dim ddlQnaTermino As DropDownList = CType(Me.dvPlaza.FindControl("ddlQuincenaTermino"), DropDownList)
            Dim lblNombreEmpleado As Label = CType(Me.dvPlaza.FindControl("lblNombreEmpleado"), Label)
            Dim hidIdEmpleado As HiddenField = CType(Me.dvPlaza.FindControl("hidIdEmpleado"), HiddenField)
            Dim chkPermitirReasignacion As CheckBox = CType(Me.dvPlaza.FindControl("chkPermitirReasignacion"), CheckBox)

            hidIdPlazas.Text = ""
            hidIdTitular.Text = "0"

            Dim oPlantel As New Plantel
            Dim dr, drE As DataRow
            Dim oEmpleadoPlaza As New EmpleadoPlazas
            Dim oEmpleado As New Empleado
            Dim oQna As New Quincenas

            oEmpleadoPlaza.IdPlaza = CType(Request.Params("IdPlaza"), Integer)

            dr = oEmpleadoPlaza.ObtenPorId()
            oEmpleadoPlaza.IdEmp = CType(dr("IdEmp"), Integer)
            drE = oEmpleado.BuscarPorId(oEmpleadoPlaza.IdEmp)
            lblNombreEmpleado.Text = drE("NumEmp") + " - " + drE("ApellidoPaterno") + " " + drE("ApellidoMaterno") + " " + drE("Nombre")
            hidIdEmpleado.Value = CType(dr("IdEmp"), Integer)

            If Request.Params("TipoOperacion") = "1" Then 'Insertar
                'BindgvPlazasHistoria()
                BindddlPlanteles(ddlPlantelesEmpleado, CInt(dr("IdPlantel")))
                BindddlCategorias(ddlCategorias, CInt(dr("IdCategoria")))
                BindddlPlanteles(ddlPlantelesPlaza, CInt(dr("IdPlantel")))
                BindddlQuincenas(ddlQnaInicio, 0)
                BindddlEstatusPlaza(ddlPlazasEstatus, 0)
                BindDatos(CInt(dr("IdPlantel")), CInt(dr("IdCategoria")), 0, 0, 0)

            ElseIf Request.Params("TipoOperacion") = "0" Then 'Actualizar 
                BindddlPlanteles(ddlPlantelesEmpleado, CInt(dr("IdPlantel")))
                BindddlCategorias(ddlCategorias, CInt(dr("IdCategoria")))
                BindddlPlanteles(ddlPlantelesPlaza, CInt(dr("IdPlantel")))
                BindddlQuincenas(ddlQnaInicio, 0)
                BindddlEstatusPlaza(ddlPlazasEstatus, 0)
                BindDatos(CInt(dr("IdPlantel")), CInt(dr("IdCategoria")), 0, 0, 0)
            End If
        End If
    End Sub

    Private Sub BindddlQuincenas(ByVal ddlQuincenas As DropDownList, ByVal IdSelected As Integer)
        Dim oQna As New Quincenas

        LlenaDDL(ddlQuincenas, "Quincena", "IdQuincena", oQna.ObtenListasCalculadas(), IdSelected)
    End Sub

    Private Sub BindddlCategorias(ByVal ddlCategorias As DropDownList, ByVal IdSelected As Integer)
        Dim oCategoria As New Categoria

        LlenaDDL(ddlCategorias, "Categoria", "IdCategoria", oCategoria.ObtenActivasBasificables(), IdSelected)
    End Sub

    Private Sub BindddlPlanteles(ByVal ddlPlantelesEmpleado As DropDownList, ByVal IdSelected As Integer)
        Dim oPlantel As New Plantel

        LlenaDDL(ddlPlantelesEmpleado, "DescPlantel", "IdPlantel", oPlantel.ObtenTodos(True), IdSelected)
    End Sub

    Private Sub BindddlQuincenaTermino()
        Dim ddlQnaInicio As DropDownList = CType(Me.dvPlaza.FindControl("ddlQuincenaInicio"), DropDownList)
        Dim ddlQnaTermino As DropDownList = CType(Me.dvPlaza.FindControl("ddlQuincenaTermino"), DropDownList)
        Dim ddlPlazasEstatus As DropDownList = CType(Me.dvPlaza.FindControl("ddlPlazasEstatus"), DropDownList)
        Dim oQna As New Quincenas

        If ddlQnaInicio.SelectedValue > 0 Then
            If ddlPlazasEstatus.SelectedValue = 3 Then
                LlenaDDL(ddlQnaTermino, "Quincena", "IdQuincena", oQna.ObtenParaVigFin(CType(ddlQnaInicio.SelectedValue, Short), True), 32767)
            Else
                LlenaDDL(ddlQnaTermino, "Quincena", "IdQuincena", oQna.ObtenParaVigFin(CType(ddlQnaInicio.SelectedValue, Short), CShort(12)), 0)
            End If
        End If
    End Sub

    Private Sub BindddlEstatusPlaza(ByVal ddl As DropDownList, ByVal IdSelected As Integer)

        'LlenaDDL(ddlEstatusPlaza, "DescEstatusPlaza", "IdEstatusPlaza", oSMP_Plazas.ObtenEstatus(), Nothing)
        ddl.Items.Clear()
        ddl.Items.Add(New ListItem("-", "0"))
        ddl.Items.Add(New ListItem("Base", "3"))
        ddl.Items.Add(New ListItem("Provisional", "9"))
        ddl.SelectedValue = IdSelected
    End Sub

    Private Sub BindDatos(ByVal IdPlanteles As Integer,
                            IdCategorias As Integer,
                            IdTipoPlaza As Integer,
                            NumEmp As String,
                            IdEstatusPlaza As Integer
                            )
        Dim oEmp As New Empleado

        Dim oSMP_Plazas As New SMP_Plazas

        With gvDatos
            .DataSource = oSMP_Plazas.ObtenEstructura(IdPlanteles _
                                , IdCategorias _
                                , IdTipoPlaza _
                                , NumEmp _
                                , IdEstatusPlaza)
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

            'Dim ddlEmpleadosFunciones As DropDownList = CType(Me.dvPlaza.FindControl("ddlEmpleadosFunciones"), DropDownList)
            Dim oPlaza As New SMP_Plazas
            Dim oEP As New EmpleadoPlazas

            With oEP
                .IdPlaza = CType(Me.gvDatos.SelectedRow.FindControl("lblIdPlazas"), Label).Text
                .IdPlantel = CType(ddlPlantelesEmpleado.SelectedValue, Short)
                .IdPlantelAdscripReal = CType(ddlPlantelesPlaza.SelectedValue, Short)
                .IdCategoria = CType(ddlCategorias.SelectedValue, Short)
            End With
            oPlaza.Guardar_SMP_PlazasECBOcup(oEP.IdPlaza, oEP.IdPlantel, oEP.IdPlantelAdscripReal, oEP.IdCategoria,
                        CType(ddlQnaInicio.SelectedValue, Short), CType(ddlQnaTermino.SelectedValue, Short),
                        CType(hidIdEmpleado.Value, Integer), 0, 0, 4, CType(Session("ArregloAuditoria"), String()))

            Me.MultiView1.SetActiveView(Me.viewExito)
        Catch Ex As Exception
            Me.lblError.Text = Ex.Message
            Me.MultiView1.SetActiveView(Me.viewError)
        End Try
    End Sub

    Protected Sub gvDatos_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvDatos.RowCommand
        Dim lblTitular As Label = CType(gvDatos.Rows(e.CommandArgument).FindControl("lblTitular"), Label)

        hidIdPlazas.Text = CType(gvDatos.Rows(e.CommandArgument).FindControl("lblIdPlazas"), Label).Text
        hidIdTitular.Text = lblTitular.Text
    End Sub

    Protected Sub ddlQuincenaInicio_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        BindddlQuincenaTermino()
    End Sub

    Protected Sub BindDatosDesdeControles()
        Dim ddlCategorias As DropDownList = CType(Me.dvPlaza.FindControl("ddlCategorias"), DropDownList)
        Dim ddlPlantelesPlaza As DropDownList = CType(Me.dvPlaza.FindControl("ddlPlantelesPlaza"), DropDownList)

        BindDatos(ddlPlantelesPlaza.SelectedValue, ddlCategorias.SelectedValue, 0, 0, 0)
    End Sub

    Protected Sub ddlCategorias_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        BindDatosDesdeControles()
    End Sub

    Protected Sub ddlPlantelesEmpleado_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ddlPlantel As DropDownList = CType(Me.dvPlaza.FindControl("ddlPlantelesEmpleado"), DropDownList)
        Dim ddlPlantelesPlaza As DropDownList = CType(Me.dvPlaza.FindControl("ddlPlantelesPlaza"), DropDownList)

        BindddlPlanteles(ddlPlantelesPlaza, ddlPlantel.SelectedValue)
        BindDatosDesdeControles()

        ddlPlantelesPlaza.SelectedValue = ddlPlantel.SelectedValue
    End Sub

    Protected Sub ddlPlazasEstatus_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ddlQuincenaInicio As DropDownList = CType(Me.dvPlaza.FindControl("ddlQuincenaInicio"), DropDownList)
        If ddlQuincenaInicio.items.count > 0 Then
            BindddlQuincenaTermino()
        End If
    End Sub

    Protected Sub btnUpdTitularPlaza_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub ddlQuincenaTermino_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub ddlMotivosDeBaja_SelectedIndexChanged(sender As Object, e As System.EventArgs)

    End Sub

    Protected Sub ddlPlantelesPlaza_SelectedIndexChanged(sender As Object, e As System.EventArgs)
        BindDatosDesdeControles()
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
            If Request.Params("TipoOperacion") <> "1" Then
                pnlDatos.Visible = False
                gvDatos.Visible = False
                pnlInfPlaza.GroupingText = "Información de la plaza"
            Else
                pnlInfPlaza.GroupingText = "Información de la plaza asignada o por asignar"
                pnlDatos.Visible = True
                gvDatos.Visible = True

            End If
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
        End If



    End Sub
    Protected Sub gvDatos_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvDatos.RowDataBound
        Dim lblTitular As Label = CType(e.Row.FindControl("lblTitular"), Label)
        Dim lblNombreEmpleado As Label = CType(Me.dvPlaza.FindControl("lblNombreEmpleado"), Label)

        If lblTitular Is Nothing = False Then
            If lblNombreEmpleado.Text.Split("-")(1).Trim = lblTitular.Text Then
                lblTitular.BackColor = Drawing.Color.LightGreen
            End If
        End If
    End Sub
End Class
