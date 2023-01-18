Imports DataAccessLayer.COBAEV.Empleados
Imports System.Data
Imports DataAccessLayer.COBAEV
Partial Class ABC_Empleados_AdministracionDatosLaborales
    Inherits System.Web.UI.Page
    Private Sub BindDatos()
        Dim oEmp As New Empleado

        Dim btnCancelar As Button
        Dim strPostbackURL As String

        btnCancelar = CType(dvDatosLab.FindControl("btnCancelar"), Button)

        strPostbackURL = String.Empty
        If btnCancelar Is Nothing = False Then
            strPostbackURL = btnCancelar.PostBackUrl
        End If

        oEmp.RFC = String.Empty
        oEmp.IdEmp = CType(Request.Params("IdEmp"), Integer)
        Me.dvDatosLab.DataSource = oEmp.ObtenDatosLaboralesPorIdEmp
        Me.dvDatosLab.DataBind()

        btnCancelar = CType(dvDatosLab.FindControl("btnCancelar"), Button)
        btnCancelar.PostBackUrl = strPostbackURL
        lbOtraOperacion0.PostBackUrl = strPostbackURL
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim btnCancelar As Button
            Response.Expires = 0

            Dim BtnNewSearch As Button = CType(Me.WucBuscaEmpleados1.FindControl("BtnNewSearch"), Button)
            Dim BtnCancelSearch As Button = CType(Me.WucBuscaEmpleados1.FindControl("BtnCancelSearch"), Button)
            Dim BtnSearch As Button = CType(Me.WucBuscaEmpleados1.FindControl("BtnSearch"), Button)

            BtnNewSearch.Visible = False
            BtnCancelSearch.Visible = False
            BtnSearch.Visible = False

            If Request.Params("TipoOperacion") = "0" Then
                Me.MultiView1.SetActiveView(Me.viewDatosLab)
                BindDatos()

                btnCancelar = CType(dvDatosLab.FindControl("btnCancelar"), Button)

                If Session("URLAnt") Is Nothing = False Then
                    If Session("URLAnt").ToString.Contains(Request.Url.Segments(Request.Url.Segments.Length - 1).ToString) Then
                        btnCancelar.PostBackUrl = "~/MenuPrincipal.aspx"
                        lbOtraOperacion0.PostBackUrl = "~/MenuPrincipal.aspx"
                    Else
                        btnCancelar.PostBackUrl = "~/" + Session("URLAnt")
                        lbOtraOperacion0.PostBackUrl = "~/" + Session("URLAnt")
                    End If
                Else
                    btnCancelar.PostBackUrl = "~/MenuPrincipal.aspx"
                    lbOtraOperacion0.PostBackUrl = "~/MenuPrincipal.aspx"
                End If

            ElseIf Request.Params("TipoOperacion") = "1" Then

            End If
        End If
    End Sub

    Protected Sub btnGurdar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim txtbxNumEmp As TextBox = CType(Me.dvDatosLab.FindControl("txtbxNumEmp"), TextBox)
            Dim ChBxHomEnSemA As CheckBox = CType(Me.dvDatosLab.FindControl("ChBxHomEnSemA"), CheckBox)
            Dim ChBxHomEnSemB As CheckBox = CType(Me.dvDatosLab.FindControl("ChBxHomEnSemB"), CheckBox)
            Dim ddlPlanteles As DropDownList = CType(Me.dvDatosLab.FindControl("ddlPlanteles"), DropDownList)
            Dim ddlCategosSemA As DropDownList = CType(Me.dvDatosLab.FindControl("ddlCategosSemA"), DropDownList)
            Dim ddlCategosSemB As DropDownList = CType(Me.dvDatosLab.FindControl("ddlCategosSemB"), DropDownList)
            Dim ddlZonasEcoA As DropDownList = CType(Me.dvDatosLab.FindControl("ddlZonasEcoA"), DropDownList)
            Dim ddlZonasEcoB As DropDownList = CType(Me.dvDatosLab.FindControl("ddlZonasEcoB"), DropDownList)

            'Dim tbNSS As TextBox = CType(Me.dvDatosLab.FindControl("tbNSS"), TextBox)
            'Dim ddlBancos As DropDownList = CType(Me.dvDatosLab.FindControl("ddlBancos"), DropDownList)
            'Dim tbCuentaBancaria As TextBox = CType(Me.dvDatosLab.FindControl("tbCuentaBancaria"), TextBox)
            'Dim chbIncluirEnPagomatico As CheckBox = CType(Me.dvDatosLab.FindControl("chbIncluirEnPagomatico"), CheckBox)
            'Dim ddlRegimenISSSTE As DropDownList = CType(Me.dvDatosLab.FindControl("ddlRegimenISSSTE"), DropDownList)
            Dim oEmpleado As New Empleado
            With oEmpleado
                .IdEmp = CType(Request.Params("IdEmp"), Integer)
                .NumEmp = txtbxNumEmp.Text
                .HomologaEnSemestreA = ChBxHomEnSemA.Checked
                .HomologaEnSemestreB = ChBxHomEnSemB.Checked
                .IdPlantel = CShort(ddlPlanteles.SelectedValue)
                .IdCategoriaSemA = CShort(ddlCategosSemA.SelectedValue)
                .IdCategoriaSemB = CShort(ddlCategosSemB.SelectedValue)
                .IdZonaEcoA = CByte(ddlZonasEcoA.SelectedValue)
                .IdZonaEcoB = CByte(ddlZonasEcoB.SelectedValue)
                '.NSS = tbNSS.Text.Trim
                '.IdBanco = CByte(ddlBancos.SelectedValue)
                '.CuentaBancaria = tbCuentaBancaria.Text.Trim
                '.IncluirEnPagomatico = chbIncluirEnPagomatico.Checked
                '.IdRegimenISSSTE = CByte(ddlRegimenISSSTE.SelectedValue)
                .ActualizarDatosLaborales(CByte(Request.Params("TipoOperacion")), CType(Session("ArregloAuditoria"), String()))
            End With
            Me.MultiView1.SetActiveView(Me.viewExito)
        Catch Ex As Exception
            Me.lblError.Text = Ex.Message
            Me.MultiView1.SetActiveView(Me.viewError)
        End Try
    End Sub

    Protected Sub dvDatosLab_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles dvDatosLab.DataBound
        Dim ddlPlanteles, ddlCategosSemA, ddlCategosSemB, ddlZonasEcoA, ddlZonasEcoB As DropDownList
        Dim lblIdPlantel, lblIdCatSemA, lblIdCatSemB, lblIdZonaEcoA, lblIdZonaEcoB As Label
        Dim RFVddlCategosSemA, RFVddlCategosSemB As RequiredFieldValidator
        Dim oPlantel As New Plantel
        Dim oCategoria As New Categoria
        Dim oBanco As New Bancos
        Dim oRegimenISSSTE As New ISSSTE
        Dim oZonaEco As New ZonaEconomica
        Dim dt, dtPlantel As DataTable
        lblIdPlantel = CType(Me.dvDatosLab.FindControl("lblIdPlantel"), Label)
        lblIdCatSemA = CType(Me.dvDatosLab.FindControl("lblIdCatSemA"), Label)
        lblIdCatSemB = CType(Me.dvDatosLab.FindControl("lblIdCatSemB"), Label)
        ddlPlanteles = CType(Me.dvDatosLab.FindControl("ddlPlanteles"), DropDownList)
        ddlCategosSemA = CType(Me.dvDatosLab.FindControl("ddlCategosSemA"), DropDownList)
        RFVddlCategosSemA = CType(Me.dvDatosLab.FindControl("RFVddlCategosSemA"), RequiredFieldValidator)
        lblIdZonaEcoA = CType(Me.dvDatosLab.FindControl("lblIdZonaEcoA"), Label)
        ddlZonasEcoA = CType(Me.dvDatosLab.FindControl("ddlZonasEcoA"), DropDownList)
        ddlCategosSemB = CType(Me.dvDatosLab.FindControl("ddlCategosSemB"), DropDownList)
        RFVddlCategosSemB = CType(Me.dvDatosLab.FindControl("RFVddlCategosSemB"), RequiredFieldValidator)
        lblIdZonaEcoB = CType(Me.dvDatosLab.FindControl("lblIdZonaEcoB"), Label)
        ddlZonasEcoB = CType(Me.dvDatosLab.FindControl("ddlZonasEcoB"), DropDownList)
        With ddlPlanteles
            '.DataSource = oPlantel.ObtenParaPagoPorEmp(CInt(Request.Params("IdEmp")))
            .DataSource = oPlantel.ObtenPorUsuario(Session("Login"))
            .DataTextField = "DescPlantel"
            .DataValueField = "IdPlantel"
            .DataBind()
            .SelectedValue = lblIdPlantel.Text
        End With
        dt = oCategoria.ObtenHomologadas()
        With ddlCategosSemA
            .DataSource = dt
            .DataTextField = "Categoria"
            .DataValueField = "IdCategoria"
            .DataBind()
            .SelectedValue = lblIdCatSemA.Text
            ddlCategosSemA.Enabled = .SelectedValue <> "-1"
            RFVddlCategosSemA.Enabled = .SelectedValue <> "-1"
        End With
        With ddlZonasEcoA
            .DataSource = oZonaEco.ObtenTodasSinComodin()
            .DataTextField = "ClaveZonaEco"
            .DataValueField = "IdZonaEco"
            .DataBind()
            If lblIdZonaEcoA.Text = String.Empty Then
                If lblIdPlantel.Text <> "0" Then
                    dtPlantel = oPlantel.ObtenPorId(CShort(lblIdPlantel.Text))
                    .SelectedValue = dtPlantel.Rows(0).Item("IdZonaEco").ToString
                End If
            Else
                .SelectedValue = lblIdZonaEcoA.Text
            End If
            .Enabled = Me.ddlCategosSemA.SelectedValue <> "-1"
        End With
        With ddlCategosSemB
            .DataSource = dt
            .DataTextField = "Categoria"
            .DataValueField = "IdCategoria"
            .DataBind()
            .SelectedValue = lblIdCatSemB.Text
            ddlCategosSemB.Enabled = .SelectedValue <> "-1"
            RFVddlCategosSemB.Enabled = .SelectedValue <> "-1"
        End With
        With ddlZonasEcoB
            .DataSource = oZonaEco.ObtenTodasSinComodin()
            .DataTextField = "ClaveZonaEco"
            .DataValueField = "IdZonaEco"
            .DataBind()
            If lblIdZonaEcoB.Text = String.Empty Then
                If lblIdPlantel.Text <> "0" Then
                    dtPlantel = oPlantel.ObtenPorId(CShort(lblIdPlantel.Text))
                    .SelectedValue = dtPlantel.Rows(0).Item("IdZonaEco").ToString
                End If
            Else
                .SelectedValue = lblIdZonaEcoB.Text
            End If
            .Enabled = Me.ddlCategosSemB.SelectedValue <> "-1"
        End With
    End Sub

    Protected Sub ChBxHomEnSemA_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ddlCategosSemA As DropDownList = CType(Me.dvDatosLab.FindControl("ddlCategosSemA"), DropDownList)
        Dim ChBxHomEnSemA As CheckBox = CType(Me.dvDatosLab.FindControl("ChBxHomEnSemA"), CheckBox)
        Dim RFVddlCategosSemA As RequiredFieldValidator = CType(Me.dvDatosLab.FindControl("RFVddlCategosSemA"), RequiredFieldValidator)
        Dim ddlZonasEcoA As DropDownList = CType(Me.dvDatosLab.FindControl("ddlZonasEcoA"), DropDownList)
        ddlCategosSemA.Enabled = ChBxHomEnSemA.Checked
        RFVddlCategosSemA.Enabled = ChBxHomEnSemA.Checked
        ddlZonasEcoA.Enabled = ChBxHomEnSemA.Checked
    End Sub

    Protected Sub ChBxHomEnSemB_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ddlCategosSemB As DropDownList = CType(Me.dvDatosLab.FindControl("ddlCategosSemB"), DropDownList)
        Dim ChBxHomEnSemB As CheckBox = CType(Me.dvDatosLab.FindControl("ChBxHomEnSemB"), CheckBox)
        Dim RFVddlCategosSemB As RequiredFieldValidator = CType(Me.dvDatosLab.FindControl("RFVddlCategosSemB"), RequiredFieldValidator)
        Dim ddlZonasEcoB As DropDownList = CType(Me.dvDatosLab.FindControl("ddlZonasEcoB"), DropDownList)
        ddlCategosSemB.Enabled = ChBxHomEnSemB.Checked
        RFVddlCategosSemB.Enabled = ChBxHomEnSemB.Checked
        ddlZonasEcoB.Enabled = ChBxHomEnSemB.Checked
    End Sub

    Protected Sub lbOtraOperacion_Click(sender As Object, e As System.EventArgs) Handles lbOtraOperacion.Click
        'Response.Redirect(Request.RawUrl)
        MultiView1.SetActiveView(viewDatosLab)
        BindDatos()
    End Sub

    Protected Sub lbReintentarCaptura_Click(sender As Object, e As System.EventArgs) Handles lbReintentarCaptura.Click
        MultiView1.SetActiveView(viewDatosLab)
    End Sub
End Class
