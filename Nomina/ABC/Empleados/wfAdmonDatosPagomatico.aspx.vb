Imports DataAccessLayer.COBAEV.Empleados
Imports System.Data
Imports DataAccessLayer.COBAEV
Imports BusinessRulesLayer.COBAEV.Validaciones
Partial Class wfAdmonDatosPagomatico
    Inherits System.Web.UI.Page
    Private Sub chkbxTransBancCheckedChanged()
        ddlBancosTB.Enabled = chkbxTransBanc.Checked
        ddlBancosTB_RFV.Enabled = chkbxTransBanc.Checked
        txtbxCtaBancTB.Enabled = chkbxTransBanc.Checked

        If chkbxTransBanc.Checked And ddlBancosTB.SelectedValue = "3" Then ddlBancosTB.SelectedIndex = 0

        If chkbxTransBanc.Checked = False Then
            If IsPostBack Then
                'ddlBancosTB.Enabled = False
                'txtbxCtaBancTB.Enabled = False
                'txtbxCtaBancTB.Text = String.Empty
                'ddlBancosTB.SelectedValue = "3"
            End If
        End If

        If btnCrearBenef.Visible Then
            ddlBancosTBSelectedIndexChanged("1")
        ElseIf btnModifBenef.Visible Then
            ddlBancosTBSelectedIndexChanged("0")
        End If
    End Sub

    Private Sub ddlBancosTBSelectedIndexChanged(ByVal pTipoOperacion As String)
        Dim oBanco As New Bancos
        Dim dr As DataRow
        Dim array() As String

        dr = oBanco.ObtenPorId(CByte(ddlBancosTB.SelectedValue))

        If pTipoOperacion = "1" Then txtbxCtaBancTB.Text = String.Empty

        txtbxCtaBancTB.Enabled = CInt(dr("LongitudCuenta")) <> 0 And chkbxTransBanc.Checked
        If txtbxCtaBancTB.Enabled = False Then
            txtbxCtaBancTB_REV.Enabled = False
            txtbxCtaBancTB_RFV.Enabled = False
        Else
            txtbxCtaBancTB_REV.Enabled = True
            txtbxCtaBancTB_RFV.Enabled = True
            array = dr("LongitudCuenta").ToString.Split(",")
            txtbxCtaBancTB_REV.ValidationExpression = dr("ExpRegValidadora").ToString '"\d{" + dr("LongitudCuenta").ToString + "}"
            txtbxCtaBancTB.MaxLength = CInt(array(array.Length - 1))
            txtbxCtaBancTB_REV.ToolTip = "La longitud de la cuenta para la transferencia bancaria debe ser de " + dr("LongitudCuenta").ToString + " dígitos."
        End If
        lblLongCtaBacTB.Text = dr("LongitudCuenta").ToString

        txtbxCtaBancTB.Enabled = CBool(dr("Activo")) And chkbxTransBanc.Checked
        txtbxCtaBancTB_REV.Enabled = CBool(dr("Activo"))
        txtbxCtaBancTB_RFV.Enabled = CBool(dr("Activo"))

        If ddlBancosTB.SelectedValue = "3" Then 'BANCO SIN DEFINIR
            chkbxTransBanc.Checked = False
            ddlBancosTB.Enabled = False
            ddlBancosTB_RFV.Enabled = False
            If IsPostBack Then
                txtbxCtaBancTB.Text = String.Empty
            End If
            btnModifBenef.Visible = True
        ElseIf CBool(dr("Activo")) = False Then
            btnModifBenef.Visible = False
        Else
            btnModifBenef.Visible = True
        End If
    End Sub
    Private Sub Muestra_Oculta_Ayuda(ByVal pValor As Boolean, ByVal Lista As Control)
        Dim myControl As Control

        For Each myControl In Lista.Controls
            If TypeOf myControl Is AjaxControlToolkit.BalloonPopupExtender Then
                If myControl.ID.EndsWith("_BPE") Then CType(myControl, AjaxControlToolkit.BalloonPopupExtender).Enabled = pValor
            End If

            If TypeOf myControl Is Panel Then
                If myControl.ID.StartsWith("pnlHelp") Then CType(myControl, Panel).Visible = pValor
            End If
            Muestra_Oculta_Ayuda(pValor, myControl)
        Next
    End Sub
    Private Sub AplicaValidaciones()
        Dim oValidacion As New Validaciones
        Dim _DataCOBAEV As New DataCOBAEV
        Dim dsValida As DataSet

        dsValida = _DataCOBAEV.setDataSetErrores()

        With oValidacion
            .NombrePagina = Request.Url.Segments(Request.Url.Segments.Length - 1).ToString
            .IdEmp = CType(Request.Params("IdEmp"), Integer)
            .IdBanco = CByte(ddlBancosTB.SelectedValue)
            .CuentaBancaria = txtbxCtaBancTB.Text.Trim
            .TipoOperacion = IIf(Request.Params("TipoOperacion") Is Nothing, 5, CByte(Request.Params("TipoOperacion")))
            If Not .ValidaPaginasOperacion(dsValida, False) Then
                Session.Add("dsValida", dsValida)
                wucMuestraErrores.ActualizaContenido()
                MultiView1.SetActiveView(viewError)
                Exit Sub
                'Session.Add("dsValida", dsValida)
                'Response.Redirect("~/ErroresPagina2.aspx")
            Else
                Session.Remove("dsValida")
            End If
        End With
    End Sub
    Private Sub BindddlBancosTB(ByVal pIdBanco As Byte)
        Dim oBanco As New Bancos
        Dim dt As DataTable

        dt = oBanco.ObtenTodos()
        With ddlBancosTB
            .DataSource = dt
            .DataTextField = "NombreCortoBanco"
            .DataValueField = "IdBanco"
            .DataBind()
            .SelectedValue = pIdBanco.ToString
        End With
    End Sub

    Private Sub BindDatos()
        Dim oEmp As New Empleado
        Dim dtDatosFormaPago As DataTable
        Dim oBanco As New Bancos

        Dim strPostbackURL As String

        strPostbackURL = String.Empty
        If btnCancelar Is Nothing = False Then
            strPostbackURL = btnCancelar.PostBackUrl
        End If

        dtDatosFormaPago = oEmp.ObtenDatosLaboralesPorIdEmp(CType(Request.Params("IdEmp"), Integer))

        If dtDatosFormaPago.Rows.Count > 0 Then
            lblEmpInf2.Text = "Modificando forma de pago del empleado: " + Request.Params("NomEmp")
            chkbxTransBanc.Checked = CBool(dtDatosFormaPago.Rows(0).Item("IncluirEnPagomatico"))
            BindddlBancosTB(CByte(dtDatosFormaPago.Rows(0).Item("IdBanco")))
            txtbxCtaBancTB.Text = dtDatosFormaPago.Rows(0).Item("CuentaBancaria").ToString
            chkbxTransBancCheckedChanged()

            btnCancelar.PostBackUrl = strPostbackURL
            lbOtraOperacion0.PostBackUrl = strPostbackURL
        Else
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Response.Expires = 0

            Dim BtnNewSearch As Button = CType(Me.WucBuscaEmpleados1.FindControl("BtnNewSearch"), Button)
            Dim BtnCancelSearch As Button = CType(Me.WucBuscaEmpleados1.FindControl("BtnCancelSearch"), Button)
            Dim BtnSearch As Button = CType(Me.WucBuscaEmpleados1.FindControl("BtnSearch"), Button)

            BtnNewSearch.Visible = False
            BtnCancelSearch.Visible = False
            BtnSearch.Visible = False

            Muestra_Oculta_Ayuda(False, Page)
            If Request.Params("TipoOperacion") = "0" Then
                Me.MultiView1.SetActiveView(Me.viewEdit)                
                BindDatos()

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

    Protected Sub btnModifBenef_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnModifBenef.Click
        Try
            AplicaValidaciones()

            Dim oEmpleado As New Empleado
            With oEmpleado
                .IdEmp = CType(Request.Params("IdEmp"), Integer)
                .IdBanco = CByte(ddlBancosTB.SelectedValue)
                .CuentaBancaria = txtbxCtaBancTB.Text.Trim
                .IncluirEnPagomatico = chkbxTransBanc.Checked
                .ActualizarDatosPagomatico(CByte(Request.Params("TipoOperacion")), CType(Session("ArregloAuditoria"), String()))
            End With
            lblCapturaExitosa.Text = "La información fue guardada exitosamente. Por favor, cierre la ventana para continuar."
            Me.MultiView1.SetActiveView(Me.viewExito)
        Catch Ex As Exception
            Dim dsValida As DataSet
            Dim _DataCOBAEV As New DataCOBAEV
            Dim drValida As DataRow

            dsValida = _DataCOBAEV.setDataSetErrores()

            drValida = dsValida.Tables(0).NewRow
            drValida(0) = Err.Number
            drValida(1) = Err.Description

            dsValida.Tables(0).Rows.Add(drValida)

            Session.Add("dsValida", dsValida)
            wucMuestraErrores.ActualizaContenido()
            Me.MultiView1.SetActiveView(Me.viewError)
        End Try
    End Sub

    Protected Sub chbxMostrarOcultarTips_CheckedChanged(sender As Object, e As System.EventArgs) Handles chbxMostrarOcultarTips.CheckedChanged
        Muestra_Oculta_Ayuda(chbxMostrarOcultarTips.Checked, Page)
    End Sub

    Protected Sub ddlBancosTB_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlBancosTB.SelectedIndexChanged
        ddlBancosTBSelectedIndexChanged(Request.Params("TipoOperacion").ToString)
    End Sub
    Protected Sub chkbxTransBanc_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkbxTransBanc.CheckedChanged
        chkbxTransBancCheckedChanged()
    End Sub

    Protected Sub lbOtraOperacion_Click(sender As Object, e As System.EventArgs) Handles lbOtraOperacion.Click
        MultiView1.SetActiveView(viewEdit)
        BindDatos()
    End Sub

    Protected Sub btnContinuar_Click(sender As Object, e As System.EventArgs) Handles btnContinuar.Click
        MultiView1.SetActiveView(viewEdit)
    End Sub
End Class
