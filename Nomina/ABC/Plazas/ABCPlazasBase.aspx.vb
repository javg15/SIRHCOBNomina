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

            If Not (Request.Params("IdPlaza") Is Nothing) Then
                hidIdPlazas.Text = Request.Params("IdPlaza")
                BindDatos(CInt(hidIdPlazas.Text))
            End If
        End If
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

    Protected Sub ddlFuncionPlaza_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ddlFuncionPlaza As DropDownList = CType(Me.dvPlaza.FindControl("ddlFuncionPlaza"), DropDownList)
        Dim ddlCategorias As DropDownList = CType(Me.dvPlaza.FindControl("ddlCategorias"), DropDownList)

        Dim oCatego As New Categoria
        Dim oTipoDeNomina As New TipoDeNomina
        Dim oEmp As New Empleado
        ddlCategorias.DataSource = oCatego.ObtenPorFuncionDelEmpleado(CByte(ddlFuncionPlaza.SelectedValue))
        ddlCategorias.DataBind()
        ddlCategorias_SelectedIndexChanged(sender, e)


    End Sub

    Private Sub BindDatos(IdPlazas As Integer)
        Dim oSMP_Plazas As New SMP_Plazas
        Dim dr As DataRow

        dr = oSMP_Plazas.ObtenRegistro(IdPlazas)

        Dim ddlEstatusPlaza As DropDownList = CType(Me.dvPlaza.FindControl("ddlEstatusPlaza"), DropDownList)
        Dim ddlTipoPlaza As DropDownList = CType(Me.dvPlaza.FindControl("ddlTipoPlaza"), DropDownList)
        Dim ddlCategorias As DropDownList = CType(Me.dvPlaza.FindControl("ddlCategorias"), DropDownList)
        Dim ddlSindicato As DropDownList = CType(Me.dvPlaza.FindControl("ddlSindicato"), DropDownList)
        Dim ddlPlantelesPlaza As DropDownList = CType(Me.dvPlaza.FindControl("ddlPlantelesPlaza"), DropDownList)
        Dim ddlFuncionPlaza As DropDownList = CType(Me.dvPlaza.FindControl("ddlFuncionPlaza"), DropDownList)
        Dim txtHoras As TextBox = CType(Me.dvPlaza.FindControl("txtHoras"), TextBox)

        If Not dr Is Nothing Then
            hidIdPlazas.Text = CStr(dr("IdPlazas"))

            BindddlCategorias(ddlCategorias, CInt(dr("IdCategoria")))
            BindddlPlanteles(ddlPlantelesPlaza, CInt(dr("IdPlantel")))
            BindddlSindicato(ddlSindicato, IIf(dr("IdSindicato") Is System.DBNull.Value, 0, dr("IdSindicato")))
            ddlEstatusPlaza.SelectedValue = IIf(dr("EstatusPlaza") Is System.DBNull.Value, 0, dr("EstatusPlaza"))
            ddlTipoPlaza.SelectedValue = IIf(dr("CvePlazaTipo") Is System.DBNull.Value, 0, dr("CvePlazaTipo"))
            ddlFuncionPlaza.SelectedValue = IIf(dr("IdEmpFuncion") Is System.DBNull.Value, 0, dr("IdEmpFuncion"))
            txtHoras.Text = IIf(dr("Horas") Is System.DBNull.Value, 0, dr("Horas"))
            ddlCategorias_SelectedIndexChanged(Nothing, Nothing)
            LlenaDDL(ddlEsquemaPago, "DescEsquemaPago", "IdEsquemaPago", oNomina.getEsquemasDePago(Session("RFCParaCons").ToString, CShort(ddlCategorias.SelectedValue), CShort(ddlPlanteles.SelectedValue), True), drEmpsPlazasDatosComplemen("IdEsquemaPago").ToString)
        Else
            hidIdPlazas.Text = "0"

            BindddlCategorias(ddlCategorias, 0)
            BindddlPlanteles(ddlPlantelesPlaza, 0)
            BindddlSindicato(ddlSindicato, 0)
            ddlEstatusPlaza.SelectedValue = ""
            ddlTipoPlaza.SelectedValue = ""
            ddlFuncionPlaza.SelectedValue = ""
            txtHoras.Text = "0"
        End If


    End Sub

    Protected Sub ddlCategorias_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ddlFuncionPlaza As DropDownList = CType(Me.dvPlaza.FindControl("ddlFuncionPlaza"), DropDownList)
        Dim ddlCategorias As DropDownList = CType(Me.dvPlaza.FindControl("ddlCategorias"), DropDownList)
        Dim txtHoras As TextBox = CType(Me.dvPlaza.FindControl("txtHoras"), TextBox)

        Dim oCategoria As New Categoria

        If ddlFuncionPlaza.SelectedValue = 2 And oCategoria.ObtenSiEsHomologada(CShort(ddlCategorias.SelectedValue))("CategoriaEsHomologada") = 0 Then
            txtHoras.Enabled = True
        Else
            txtHoras.Enabled = False
            txtHoras.Text = 0
        End If
    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            'Deshabilitamos el botón guardar para evitar el doble click
            'CType(Me.dvPlaza.FindControl("btnGuardar"), Button).Visible = False

            Dim ddlCategorias As DropDownList = CType(Me.dvPlaza.FindControl("ddlCategorias"), DropDownList)
            Dim ddlPlantelesPlaza As DropDownList = CType(Me.dvPlaza.FindControl("ddlPlantelesPlaza"), DropDownList)
            Dim ddlEstatusPlaza As DropDownList = CType(Me.dvPlaza.FindControl("ddlEstatusPlaza"), DropDownList)
            Dim ddlSindicato As DropDownList = CType(Me.dvPlaza.FindControl("ddlSindicato"), DropDownList)
            Dim ddlTipoPlaza As DropDownList = CType(Me.dvPlaza.FindControl("ddlTipoPlaza"), DropDownList)
            Dim txtHoras As TextBox = CType(Me.dvPlaza.FindControl("txtHoras"), TextBox)

            'Dim ddlEmpleadosFunciones As DropDownList = CType(Me.dvPlaza.FindControl("ddlEmpleadosFunciones"), DropDownList)
            Dim oPlaza As New SMP_Plazas

            With oPlaza
                .IdPlazas = hidIdPlazas.Text
                .IdPlantel = CType(ddlPlantelesPlaza.SelectedValue, Integer)
                .IdCategoria = CType(ddlCategorias.SelectedValue, Integer)
                .IdSindicato = CType(ddlSindicato.SelectedValue, Integer)
                .EstatusPlaza = ddlEstatusPlaza.SelectedValue
                .CvePlazaTipo = ddlTipoPlaza.SelectedValue
                .Horas = CInt(txtHoras.Text)
            End With
            oPlaza.Guardar_SMP_PlazasECBOcup(Request.Params("TipoOperacion"), CType(Session("ArregloAuditoria"), String()))

            Me.MultiView1.SetActiveView(Me.viewExito)
        Catch Ex As Exception
            Me.lblError.Text = Ex.Message
            Me.MultiView1.SetActiveView(Me.viewError)
        End Try
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
            BindDatos(CInt(Request.Params("IdPlaza")))
        End If
    End Sub

    Protected Sub btnContinuar_Click(sender As Object, e As System.EventArgs) Handles btnReintentarOp.Click
        MultiView1.SetActiveView(viewPlazas)
    End Sub

End Class
