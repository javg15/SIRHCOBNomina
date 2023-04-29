Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.Empleados
Imports System.Data
Imports DataAccessLayer.COBAEV.Administracion
Imports BusinessRulesLayer.COBAEV.Validaciones
Imports DataAccessLayer.COBAEV.Plazas
Imports DataAccessLayer.COBAEV

Partial Class PlazasEstructura
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim oPlantel As New Plantel

            BindddlPlanteles()
            BindddlCategorias()
            BindddlTipoPlaza()
            BindddlEstatusPlaza()

            Session.Remove("RFCParaCons")

            Me.WucBuscaEmpleados1.BtnNewSearch_Click2()
            Me.WucBuscaEmpleados1.SetPropertyEnabled_rfv(False, False, False)
            Me.WucBuscaEmpleados1.SetPropertyReadOnly_TxtBx(False, False, False)
        End If
    End Sub
    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            RecargaInformacion()
            'Me.WucBuscaEmpleados1.SetPropertyReadOnly_TxtBx(False, False, False)
            Me.WucBuscaEmpleados1.SetPropertyEnabled_rfv(False, False, False)
        End If
    End Sub


    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, ByVal dt As DataTable, ByVal SelectedValue As String)
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

    Private Sub SetVisibleBotones_wucBuscaEmps(ByVal pNewValor As Boolean, ByVal pCancelValor As Boolean, ByVal pSearchValor As Boolean)
        'Dim BtnNewSearch As Button = CType(WucBuscaEmpleados1.FindControl("BtnNewSearch"), Button)
        'Dim BtnCancelSearch As Button = CType(Me.WucBuscaEmpleados1.FindControl("BtnCancelSearch"), Button)
        'Dim BtnSearch As Button = CType(Me.WucBuscaEmpleados1.FindControl("BtnSearch"), Button)

        'Me.WucBuscaEmpleados1.SetPropertyEnabled_rfv(False, False, False)

        'BtnNewSearch.Visible = pNewValor
        'BtnCancelSearch.Visible = pCancelValor
        'BtnSearch.Visible = pSearchValor
    End Sub


    Private Sub BindddlCategorias()
        Dim oCategoria As New Categoria

        LlenaDDL(ddlCategorias, "Categoria", "IdCategoria", oCategoria.ObtenTodas(), Nothing)
    End Sub

    Private Sub BindddlTipoPlaza()
        Dim oFuncion As New EmpleadoFuncion

        LlenaDDL(ddlTipoPlaza, "DescEmpFuncion", "IdEmpFuncion", oFuncion.ObtenTodas(), Nothing)
    End Sub

    Private Sub BindddlPlanteles()
        Dim oPlantel As New Plantel

        LlenaDDL(ddlPlanteles, "DescPlantel", "IdPlantel", oPlantel.ObtenTodos(True), Nothing)
    End Sub

    Private Sub BindddlEstatusPlaza()
        Dim oSMP_Plazas As New SMP_Plazas

        LlenaDDL(ddlEstatusPlaza, "DescEstatusPlaza", "IdEstatusPlaza", oSMP_Plazas.ObtenEstatus(), Nothing)
    End Sub

    Private Sub RecargaInformacion()
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)

        If ddlEstatusPlaza.SelectedValue = "0" And ddlTipoPlaza.SelectedValue = "0" _
            And ddlCategorias.SelectedValue = "0" And ddlPlanteles.SelectedValue = "0" _
            And hfRFC.Value = "" Then
            lblMsjSinFiltros.Visible = True
        Else
            lblMsjSinFiltros.Visible = False
            Session.Add("RFCParaCons", hfRFC.Value)
            BindDatos()
        End If
        pnlDatos.Visible = True
    End Sub
    Private Sub BindDatos()
        Dim oEmp As New Empleado
        Dim txtbxRFC As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxRFC"), TextBox)
        Dim txtbxNomEmp As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxNomEmp"), TextBox)
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        Dim hfNumEmp As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfNumEmp"), HiddenField)
        Dim BtnNewSearch As Button = CType(Me.WucBuscaEmpleados1.FindControl("BtnNewSearch"), Button)

        Dim oSMP_Plazas As New SMP_Plazas

        With gvDatos
            .DataSource = oSMP_Plazas.ObtenEstructura(ddlPlanteles.SelectedValue _
                                , ddlCategorias.SelectedValue _
                                , ddlTipoPlaza.SelectedValue _
                                , txtbxRFC.Text _
                                , ddlEstatusPlaza.SelectedValue)
            .DataBind()
            .Visible = True
        End With

        BtnNewSearch.Enabled = True
        'Me.WucBuscaEmpleados1.SetPropertyReadOnly_TxtBx(True, True, True)
        Me.WucBuscaEmpleados1.SetPropertyEnabled_rfv(False, False, False)
    End Sub


    Protected Sub WucBuscaEmpleados1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles WucBuscaEmpleados1.PreRender
        If IsPostBack Then
            Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
            Dim txtbxRFC As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxRFC"), TextBox)
            'If Request.Params(0).Contains("BtnSearch") Or Request.Params(1).Contains("BtnSearch") Then
            '  If txtbxRFC.Text.Trim <> String.Empty Then
            '       RecargaInformacion()
            '       MultiView1.Visible = True
            '    Else
            '        MultiView1.Visible = False
            '    End If
            'Else
            If Request.Params(0).Contains("BtnNewSearch") Or Request.Params(1).Contains("BtnNewSearch") Then
                Me.WucBuscaEmpleados1.SetPropertyEnabled_rfv(False, False, False)
            ElseIf Request.Params(0).Contains("BtnCancelSearch") Or Request.Params(1).Contains("BtnCancelSearch") Then
                Me.WucBuscaEmpleados1.SetPropertyEnabled_rfv(False, False, False)
            ElseIf Request.Params("__EVENTTARGET") Is Nothing = False Then
                If Request.Params("__EVENTTARGET").Contains("lnkbtnrfc") Then
                    RecargaInformacion()
                    Me.WucBuscaEmpleados1.SetPropertyEnabled_rfv(False, False, False)
                End If
            End If
        End If
    End Sub



    Protected Sub ibCleanEstatusPlaza_Click(sender As Object, e As ImageClickEventArgs) Handles ibCleanEstatusPlaza.Click
        ddlEstatusPlaza.SelectedValue = "0"
    End Sub
    Protected Sub ibCleanTipoPlaza_Click(sender As Object, e As ImageClickEventArgs) Handles ibCleanTipoPlaza.Click
        ddlTipoPlaza.SelectedValue = "0"
    End Sub
    Protected Sub ibCleanCategoria_Click(sender As Object, e As ImageClickEventArgs) Handles ibCleanCategoria.Click
        ddlCategorias.SelectedValue = "0"
    End Sub
    Protected Sub ibCleanPlanteles_Click(sender As Object, e As ImageClickEventArgs) Handles ibCleanPlanteles.Click
        ddlPlanteles.SelectedValue = "0"
    End Sub
    Protected Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        RecargaInformacion()
    End Sub

    Protected Sub lbUltNombTitular_Click(sender As Object, e As System.EventArgs)
        Dim lbMes As LinkButton
        lbMes = CType(sender, LinkButton)
        'BindgvAusenciasJustificadas(CByte(lbMes.CommandArgument), lbMes.ID.Replace("lb", ""))
    End Sub

    Protected Sub lbUltNombOcupante_Click(sender As Object, e As System.EventArgs)
        Dim lbMes As LinkButton
        lbMes = CType(sender, LinkButton)
        'BindgvAusenciasNoJustificadas(CByte(lbMes.CommandArgument), lbMes.ID.Replace("lb", ""))
    End Sub
    Protected Sub ibCleanEmpleado_Click(sender As Object, e As ImageClickEventArgs) Handles ibCleanEmpleado.Click
        Me.WucBuscaEmpleados1.BtnNewSearch_Click2()
        Me.WucBuscaEmpleados1.SetPropertyEnabled_rfv(False, False, False)
        Me.WucBuscaEmpleados1.SetPropertyReadOnly_TxtBx(False, False, False)
    End Sub
End Class
