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

Partial Class ABCPlazasBaseAsignacion
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

    Protected Sub WucBuscaEmpleados1_PreRender(sender As Object, e As System.EventArgs) Handles WucBuscaEmpleados1.PreRender
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        Dim hidIdEmpleado As HiddenField = CType(Me.dvPlaza.FindControl("hidIdEmpleado"), HiddenField)
        Dim lblNombreEmpleado As Label = CType(Me.dvPlaza.FindControl("lblNombreEmpleado"), Label)
        Dim oEmp As New Empleado
        Dim drEmp As DataRow

        If hfRFC.Value <> String.Empty Then
            drEmp = oEmp.BuscarPorRFC(hfRFC.Value)
            hidIdEmpleado.Value = drEmp("IdEmp")
            lblNombreEmpleado.Text = drEmp("NumEmp") +
                    " - " + drEmp("ApellidoPaterno") +
                    " " + drEmp("ApellidoMaterno") +
                    " " + drEmp("Nombre")
        Else
            hidIdEmpleado.Value = ""
            lblNombreEmpleado.Text = ""
        End If

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


            hidIdPlazas.Text = ""
            hidIdTitular.Text = "0"

            If Not (Request.Params("IdPlaza") Is Nothing) Then
                hidIdPlazas.Text = Request.Params("IdPlaza")
                BindDatos(CInt(hidIdPlazas.Text))
            End If
        End If
    End Sub

    Private Sub BindddlQuincenas(ByVal ddlQuincenas As DropDownList, ByVal IdSelected As Integer)
        Dim oQna As New Quincenas

        LlenaDDL(ddlQuincenas, "Quincena", "IdQuincena", oQna.ObtenListasCalculadas(), IdSelected)
    End Sub

    Private Sub BindddlCategorias(ByVal ddlCategorias As DropDownList, ByVal IdSelected As Integer)
        Dim oCategoria As New Categoria

        'If IdTipoEmp = 2 Or IdTipoEmp = 0 Then
        LlenaDDL(ddlCategorias, "Categoria", "IdCategoria", oCategoria.ObtenTodas(), IdSelected)

        'Else
        'LlenaDDL(ddlCategorias, "Categoria", "IdCategoria", oCategoria.ObtenActivasBasificables(), IdSelected)
        'End If

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

    Private Sub BindDatos(IdPlazas As Integer)
        Dim oEmp As New Empleado
        Dim oSMP_Plazas As New SMP_Plazas
        Dim drUsr As DataRow
        Dim oUsr As New Usuario
        Dim oQna As New Quincenas
        Dim dt As DataTable
        Dim dr As DataRow


        drUsr = oUsr.ObtenerPropiedadesDelRol(Session("Login"))
        dt = oSMP_Plazas.ObtenInfoDePlazaSMPOcup(IdPlazas)

        With gvDatos
            .DataSource = dt
            .DataBind()
            .Visible = True
        End With

        If gvDatos.Rows.Count > 0 Then
            dr = dt.Rows(0)

            Dim lblIdPlazas As Label = CType(gvDatos.Rows(0).FindControl("lblIdPlazas"), Label)
            Dim lblIdEstatusPlazaBase As Label = CType(gvDatos.Rows(0).FindControl("lblIdEstatusPlazaBase"), Label)
            Dim lblIdQnaVigIni As Label = CType(gvDatos.Rows(0).FindControl("lblIdQnaVigIni"), Label)
            Dim lblIdQnaVigFin As Label = CType(gvDatos.Rows(0).FindControl("lblIdQnaVigFin"), Label)
            Dim lblQuinTermino As Label = CType(gvDatos.Rows(0).FindControl("lblQuinTermino"), Label)

            Dim lblNombreEmpleado As Label = CType(Me.dvPlaza.FindControl("lblNombreEmpleado"), Label)
            Dim ddlPlantelesEmpleado As DropDownList = CType(Me.dvPlaza.FindControl("ddlPlantelesEmpleado"), DropDownList)
            Dim ddlPlantelesPlaza As DropDownList = CType(Me.dvPlaza.FindControl("ddlPlantelesPlaza"), DropDownList)
            Dim ddlCategorias As DropDownList = CType(Me.dvPlaza.FindControl("ddlCategorias"), DropDownList)
            Dim ddlSindicato As DropDownList = CType(Me.dvPlaza.FindControl("ddlSindicato"), DropDownList)
            Dim txtObservaciones As TextBox = CType(Me.dvPlaza.FindControl("txtObservaciones"), TextBox)
            Dim ddlPlazasEstatus As DropDownList = CType(Me.dvPlaza.FindControl("ddlPlazasEstatus"), DropDownList)

            Dim ddlQnaInicio As DropDownList = CType(Me.dvPlaza.FindControl("ddlQuincenaInicio"), DropDownList)
            Dim ddlQnaTermino As DropDownList = CType(Me.dvPlaza.FindControl("ddlQuincenaTermino"), DropDownList)
            Dim chkLiberarPlaza As CheckBox = CType(Me.dvPlaza.FindControl("chkLiberarPlaza"), CheckBox)

            lblNombreEmpleado.Text = dr("NombT")
            BindddlPlanteles(ddlPlantelesEmpleado, CInt(dr("IdPlantelEmpleado")))
            BindddlCategorias(ddlCategorias, CInt(dr("IdCategoria")))
            BindddlPlanteles(ddlPlantelesPlaza, CInt(dr("IdPlantelPlaza")))
            BindddlSindicato(ddlSindicato, CInt(dr("IdSindicato")))

            CType(Me.pnlDatos.FindControl("hidIdPlazas"), TextBox).Text = lblIdPlazas.Text




            If CInt(dr("CuentaAsignaciones")) > 0 Then
                ddlPlantelesPlaza.Enabled = False
                ddlCategorias.Enabled = False
                ddlSindicato.Enabled = False
            Else
                ddlPlantelesPlaza.Enabled = True
                ddlCategorias.Enabled = True
                ddlSindicato.Enabled = True
            End If

            If (CStr(dr("IdEmpT")) <> 0) Then
                Session.Add("RFCParaCons", dr("RFCEmpT"))
                Session.Add("CURPParaCons", dr("CURPEmpT"))
                Session.Add("ApePatParaCons", dr("ApePatEmpT"))
                Session.Add("ApeMatParaCons", dr("ApeMatEmpT"))
                Session.Add("NombreParaCons", dr("NomEmpT"))
                Session.Add("NumEmpParaCons", dr("NumEmpT"))

                WucBuscaEmpleados1.Visible = False
                Me.WucBuscaEmpleados1.PerformClick_BtnSearch()
                Me.WucBuscaEmpleados1.SetButtonVisible(False, False, False)
                Me.WucBuscaEmpleados1.SetPropertyReadOnly_TxtBx(False, False, False)
                Me.WucBuscaEmpleados1.SetPropertyEnabled_rfv(False, False, False)

                ddlPlantelesEmpleado.Enabled = False
                ddlPlazasEstatus.Enabled = False

                BindddlQuincenas(ddlQnaInicio, CInt(dr("IdQnaVigIni")))
                LlenaDDL(ddlQnaTermino, "Quincena", "IdQuincena", oQna.ObtenParaVigFin(CShort(lblIdQnaVigIni.Text), True), 32767)
                BindddlEstatusPlaza(ddlPlazasEstatus, CInt(dr("IdEstatusPlazaBase")))

                Try
                    ddlQnaTermino.SelectedValue = CInt(lblIdQnaVigFin.Text)
                Catch ex As Exception
                    Dim newListItem As ListItem
                    newListItem = New ListItem(lblQuinTermino.Text, CInt(lblIdQnaVigFin.Text))
                    newListItem.Selected = True
                    ddlQnaTermino.Items.Add(newListItem)
                    ddlQnaTermino.SelectedValue = CInt(lblIdQnaVigFin.Text)
                End Try
            Else
                Me.WucBuscaEmpleados1.Visible = True
                ddlPlantelesEmpleado.Enabled = True
                ddlPlazasEstatus.Enabled = True
                BindddlQuincenas(ddlQnaInicio, 0)
                BindddlQuincenas(ddlQnaTermino, 0)
                BindddlEstatusPlaza(ddlPlazasEstatus, 0)
            End If

            chkLiberarPlaza.Visible = True
        End If
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
            oPlaza.Guardar_SMP_PlazasECBOcupTitulares(oEP.IdPlaza, oEP.IdPlantel, oEP.IdPlantelAdscripReal, oEP.IdCategoria,
                        CType(ddlQnaInicio.SelectedValue, Short), CType(ddlQnaTermino.SelectedValue, Short),
                        CType(hidIdEmpleado.Value, Integer), 0,
                        CType(ddlPlazasEstatus.SelectedValue, Short), txtObservaciones.Text,
                        IIf(Request.Params("TipoOperacion") = 1, 4, Request.Params("TipoOperacion")), CType(Session("ArregloAuditoria"), String())
                        )

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



    Protected Sub ddlQuincenaInicio_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        BindddlQuincenaTermino()
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

            pnlInfPlaza.GroupingText = "Información de la plaza asignada o por asignar"
            pnlDatos.Visible = True
            gvDatos.Visible = True
            BindDatos(CInt(Request.Params("IdPlaza")))
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

    Protected Sub chkLiberarPlaza_CheckedChanged(sender As Object, e As EventArgs)
        Dim oUsuario As New Usuario
        Dim chkLiberarPlaza As CheckBox = CType(Me.dvPlaza.FindControl("chkLiberarPlaza"), CheckBox)
        Dim ddlQnaTermino As DropDownList = CType(Me.dvPlaza.FindControl("ddlQuincenaTermino"), DropDownList)

        If chkLiberarPlaza.Checked Then
            ddlQnaTermino.Items(1).Enabled = False
        Else
            ddlQnaTermino.Items(1).Enabled = True
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


        If Not lblTitular Is Nothing Then

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
                End If
            End If

        End If
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
                        newListItem = New ListItem(lblQuinTermino.Text, CInt(lblIdQnaVigFin.Text))
                        newListItem.Selected = True
                        ddlQnaTermino.Items.Add(newListItem)
                        ddlQnaTermino.SelectedValue = CInt(lblIdQnaVigFin.Text)
                    End Try

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
