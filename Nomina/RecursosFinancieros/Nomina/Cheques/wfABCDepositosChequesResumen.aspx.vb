Imports DataAccessLayer.COBAEV.Nominas
Imports System.Data
Imports DataAccessLayer.COBAEV

Partial Class wfABCDepositosChequesResumen
    Inherits System.Web.UI.Page
    Private Sub BindddlBancos()
        Dim ddlAux As New DropDownList
        Dim oBanco As New Bancos
        Dim li As ListItem
        LlenaDDL(ddlBancos, "NombreCortoBanco", "IdBanco", oBanco.ObtenTodos(), Nothing)
        LlenaDDL(ddlAux, "NombreCortoBanco", "IdBanco", oBanco.ObtenTodos(), Nothing)
        li = Me.ddlBancos.Items.FindByText("SIN DEFINIR")
        If li Is Nothing = False Then
            Me.ddlBancos.Items.Remove(li)
            ddlAux.Items.Remove(li)
        End If
    End Sub
    Private Sub BindddlBancosDeposito()
        Dim ddlAux As New DropDownList
        Dim oBanco As New Bancos
        Dim li As ListItem
        LlenaDDL(ddlBancosDeposito, "NombreCortoBanco", "IdBanco", oBanco.ObtenTodos(), Nothing)
        LlenaDDL(ddlAux, "NombreCortoBanco", "IdBanco", oBanco.ObtenTodos(), Nothing)
        li = ddlBancosDeposito.Items.FindByText("SIN DEFINIR")
        If li Is Nothing = False Then
            ddlBancosDeposito.Items.Remove(li)
            ddlAux.Items.Remove(li)
        End If
    End Sub
    Private Sub setVisibleImgenes(ByVal pValor1 As Boolean, ByVal pValor2 As Boolean, _
                                  ByVal pValor3 As Boolean, ByVal pValor4 As Boolean, _
                                  ByVal pValor5 As Boolean, ByVal pValor6 As Boolean, _
                                  ByVal pValor7 As Boolean, ByVal pValor8 As Boolean)
        imgCheckTipoCheque.Visible = pValor1
        imgNoCheckTipoCheque.Visible = pValor2
        imgCheckAnio.Visible = pValor3
        imgNoCheckAnio.Visible = pValor4
        imgCheckMes.Visible = pValor5
        imgNoCheckMes.Visible = pValor6
        imgCheckQna.Visible = pValor7
        imgNoCheckQna.Visible = pValor8
    End Sub
    Private Sub setVisibleColumns(ByVal pGridView As GridView, _
                                  ByVal pValor1 As Boolean, ByVal pValor2 As Boolean, _
                                  ByVal pValor3 As Boolean, ByVal pValor4 As Boolean, _
                                  ByVal pValor5 As Boolean)
        pGridView.Columns(7).Visible = pValor1
        pGridView.Columns(8).Visible = pValor2
        pGridView.Columns(12).Visible = pValor3
        pGridView.Columns(14).Visible = pValor4
        pGridView.Columns(15).Visible = pValor5
    End Sub
    Private Sub setVisibleColumns2(ByVal pGridView As GridView, _
                                  ByVal pValor1 As Boolean, ByVal pValor2 As Boolean, _
                                  ByVal pValor3 As Boolean, ByVal pValor4 As Boolean, _
                                  ByVal pValor5 As Boolean)
        pGridView.Columns(8).Visible = pValor1
        pGridView.Columns(9).Visible = pValor2
        pGridView.Columns(13).Visible = pValor3
        pGridView.Columns(15).Visible = pValor4
        pGridView.Columns(16).Visible = pValor5
    End Sub
    Private Sub ddlTiposDeChequesSelectedValue()
        Select Case ddlTiposDeCheques.SelectedValue
            Case "C"
                pnlMeses.Enabled = True
                pnlQnas.Enabled = False
            Case "CPA"
                pnlMeses.Enabled = True
                pnlQnas.Enabled = False
            Case "N"
                pnlMeses.Enabled = False
                pnlQnas.Enabled = True
            Case "NPA"
                pnlMeses.Enabled = False
                pnlQnas.Enabled = True
            Case "R"
                pnlMeses.Enabled = False
                pnlQnas.Enabled = True
            Case Else

        End Select
    End Sub
    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, ByVal dt As DataTable, Optional ByVal SelectedValue As String = "")
        ddl.DataSource = dt
        ddl.DataTextField = TextField
        ddl.DataValueField = ValueField
        ddl.DataBind()
        If SelectedValue <> String.Empty Then ddl.SelectedValue = SelectedValue
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
            End If
        End With
    End Sub
    Private Sub BindddlMeses()
        Dim oQna As New Quincenas
        With Me.ddlMeses
            .DataSource = oQna.ObtenMesesCalculadosPorAnio(CShort(Me.ddlAños.SelectedValue))
            .DataTextField = "NombreMes"
            .DataValueField = "IdMes"
            .DataBind()
        End With
    End Sub
    Private Sub BindQuincenas()
        Dim oQna As New Quincenas
        Dim dt As DataTable

        dt = oQna.ObtenCalculadasPorAnio(CShort(Me.ddlAños.SelectedValue))

        LlenaDDL(ddlQnas, "QuincenaObservs", "IdQuincena", dt)
    End Sub
    Private Sub BindQuincenasAdic()
        Dim oQna As New Quincenas
        Dim dt As DataTable

        dt = oQna.ObtenCalculadasPorAnio(CShort(Me.ddlAños.SelectedValue), False)

        LlenaDDL(ddlQnas, "QuincenaObservs", "IdQuincena", dt)
    End Sub
    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            BindddlAños()
            If Me.ddlAños.SelectedValue <> -1 Then
                BindddlMeses()
                BindQuincenas()
                BindddlBancosDeposito()
                btnConsultar_Click(sender, e)
                pnlTiposDeCheques.Enabled = False
                pnlAños.Enabled = False
                pnlMeses.Enabled = False
                pnlQnas.Enabled = False
                btnConsultar.Visible = False
            End If
        End If
    End Sub
    Protected Sub ddlMeses_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlMeses.SelectedIndexChanged

    End Sub

    Protected Sub ddlTiposDeCheques_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlTiposDeCheques.SelectedIndexChanged
        Select Case ddlTiposDeCheques.SelectedValue
            Case "C"
                BindQuincenas()
                pnlMeses.Enabled = True
                pnlQnas.Enabled = False
            Case "CPA"
                BindQuincenas()
                pnlMeses.Enabled = True
                pnlQnas.Enabled = False
            Case "N"
                BindQuincenas()
                pnlMeses.Enabled = False
                pnlQnas.Enabled = True
            Case "NPA"
                BindQuincenas()
                pnlMeses.Enabled = False
                pnlQnas.Enabled = True
            Case "R"
                BindQuincenasAdic()
                pnlMeses.Enabled = False
                pnlQnas.Enabled = True
            Case Else

        End Select
    End Sub

    Protected Sub ddlAños_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlAños.SelectedIndexChanged
        BindddlMeses()
        Select Case ddlTiposDeCheques.SelectedValue
            Case "R"
                BindQuincenasAdic()
            Case Else
                BindQuincenas()
        End Select

    End Sub

    Protected Sub btnCambiarPrmsCons_Click(sender As Object, e As System.EventArgs) Handles btnCambiarPrmsCons.Click
        mvCheques.Visible = False
        pnlTiposDeCheques.Enabled = True
        pnlAños.Enabled = True
        pnlBancos.Enabled = True
        ddlTiposDeChequesSelectedValue()
        imgCheckTipoCheque.Visible = False
        imgNoCheckTipoCheque.Visible = False
        imgCheckAnio.Visible = False
        imgNoCheckAnio.Visible = False
        imgCheckMes.Visible = False
        imgNoCheckMes.Visible = False
        imgCheckQna.Visible = False
        imgNoCheckQna.Visible = False
        btnConsultar.Visible = True
    End Sub

    Protected Sub btnConsultar_Click(sender As Object, e As System.EventArgs) Handles btnConsultar.Click
        Dim oNomina As New Nomina

        gvCheques.DataSource = oNomina.getDepositosCheques(CShort(ddlQnas.SelectedValue), CShort(ddlAños.SelectedValue), _
                                                 CByte(ddlMeses.SelectedValue), ddlTiposDeCheques.SelectedValue, CByte(ddlBancosDeposito.SelectedValue))
        gvCheques.DataBind()
        mvCheques.SetActiveView(viewCheques)
        mvCheques.Visible = True
        pnlTiposDeCheques.Enabled = False
        pnlAños.Enabled = False
        pnlMeses.Enabled = False
        pnlQnas.Enabled = False
        pnlBancos.Enabled = False
        btnConsultar.Visible = False

        Select Case ddlTiposDeCheques.SelectedValue
            Case "C"
                setVisibleImgenes(True, False, True, False, True, False, False, True)
                'setVisibleColumns(gvCheques, False, True, False, True, False)
            Case "CPA"
                setVisibleImgenes(True, False, True, False, True, False, False, True)
                'setVisibleColumns(gvCheques, False, False, True, True, False)
            Case "N"
                setVisibleImgenes(True, False, True, False, False, True, True, False)
                'setVisibleColumns(gvCheques, False, True, False, True, True)
            Case "NPA"
                setVisibleImgenes(True, False, True, False, False, True, True, False)
                'setVisibleColumns(gvCheques, False, False, True, False, True)
            Case "R"
                setVisibleImgenes(True, False, True, False, False, True, True, False)
                'setVisibleColumns(gvCheques, True, True, False, True, False)
            Case Else

        End Select
    End Sub

    Protected Sub ibCapturar_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs)
        pnldivBotonesErrores.Visible = False

        Dim oNomina As New Nomina

        Dim ib As ImageButton : Dim gvr As GridViewRow
        Dim dtCheque As DataTable : Dim oBanco As New Bancos

        Dim lblId_Emp_BenefPA As Label : Dim lblIdQuincena As Label
        Dim lblAnio As Label : Dim lblIdMes As Label
        Dim lblAdicional As Label : Dim lblIdPlantel As Label
        Dim lblIdRecibo As Label : Dim lblTipoCheque As Label
        Dim lblId_Emp_BenefPA_Aux As Label : Dim lblIdQuincena_Aux As Label
        Dim lblAnio_Aux As Label : Dim lblIdMes_Aux As Label
        Dim lblAdicional_Aux As Label : Dim lblIdPlantel_Aux As Label
        Dim lblIdRecibo_Aux As Label : Dim lblTipoCheque_Aux As Label
        Dim chkbxSelec As CheckBox : Dim chkbxSelecAll As CheckBox

        Dim lblIdBanco As Label : Dim lblCuentaPagadora As Label
        Dim lblNumCheque As Label : Dim lblFechaEmision As Label
        Dim lblFechaPagoCheque As Label : Dim lblObservsCheque As Label
        Dim chkbxCancelado As CheckBox : Dim lblFechaCancelacion As Label

        ib = CType(sender, ImageButton)
        btnGuardar.CommandArgument = ib.CommandArgument
        gvr = ib.NamingContainer

        lblId_Emp_BenefPA = CType(gvr.FindControl("lblId_Emp_BenefPA"), Label)
        lblIdQuincena = CType(gvr.FindControl("lblIdQuincena"), Label)
        lblAnio = CType(gvr.FindControl("lblAnio"), Label)
        lblIdMes = CType(gvr.FindControl("lblIdMes"), Label)
        lblAdicional = CType(gvr.FindControl("lblAdicional"), Label)
        lblIdPlantel = CType(gvr.FindControl("lblIdPlantel"), Label)
        lblIdRecibo = CType(gvr.FindControl("lblIdRecibo"), Label)
        lblTipoCheque = CType(gvr.FindControl("lblTipoCheque"), Label)

        dtCheque = oNomina.getCheque(CInt(lblId_Emp_BenefPA.Text), CShort(lblIdQuincena.Text), CShort(lblAnio.Text), _
                                                 CByte(lblIdMes.Text), CByte(lblAdicional.Text), _
                                                 CShort(lblIdPlantel.Text), CShort(lblIdRecibo.Text), lblTipoCheque.Text)

        gvCheque.DataSource = dtCheque
        gvCheque.DataBind()

        For Each gvr_aux As GridViewRow In gvCheque.Rows
            chkbxSelec = CType(gvr_aux.FindControl("chkbxSelec"), CheckBox)
            lblId_Emp_BenefPA_Aux = CType(gvr_aux.FindControl("lblId_Emp_BenefPA"), Label)
            lblIdQuincena_Aux = CType(gvr_aux.FindControl("lblIdQuincena"), Label)
            lblAnio_Aux = CType(gvr_aux.FindControl("lblAnio"), Label)
            lblIdMes_Aux = CType(gvr_aux.FindControl("lblIdMes"), Label)
            lblAdicional_Aux = CType(gvr_aux.FindControl("lblAdicional"), Label)
            lblIdPlantel_Aux = CType(gvr_aux.FindControl("lblIdPlantel"), Label)
            lblIdRecibo_Aux = CType(gvr_aux.FindControl("lblIdRecibo"), Label)
            lblTipoCheque_Aux = CType(gvr_aux.FindControl("lblTipoCheque"), Label)

            lblIdBanco = CType(gvr_aux.FindControl("lblIdBanco"), Label)
            lblCuentaPagadora = CType(gvr_aux.FindControl("lblCuentaPagadora"), Label)
            lblNumCheque = CType(gvr_aux.FindControl("lblNumCheque"), Label)
            lblFechaEmision = CType(gvr_aux.FindControl("lblFechaEmision"), Label)
            lblFechaPagoCheque = CType(gvr_aux.FindControl("lblFechaPagoCheque"), Label)
            lblObservsCheque = CType(gvr_aux.FindControl("lblObservsCheque"), Label)
            chkbxCancelado = CType(gvr_aux.FindControl("chkbxCancelado"), CheckBox)
            lblFechaCancelacion = CType(gvr_aux.FindControl("lblFechaCancelacion"), Label)

            If (lblId_Emp_BenefPA_Aux.Text = lblId_Emp_BenefPA.Text And
                lblIdQuincena_Aux.Text = lblIdQuincena.Text And lblAnio_Aux.Text = lblAnio.Text And
                lblIdMes_Aux.Text = lblIdMes.Text And lblAdicional_Aux.Text = lblAdicional.Text And
                lblIdPlantel_Aux.Text = lblIdPlantel.Text And lblIdRecibo_Aux.Text = lblIdRecibo.Text And
                lblTipoCheque_Aux.Text = lblTipoCheque.Text) Then

                chkbxSelec.Checked = True

                If ib.CommandArgument = 0 Then
                    ddlBancos.SelectedValue = lblIdBanco.Text
                    ddlCtasPag.SelectedValue = lblCuentaPagadora.Text
                    txtbxNumCheque.Text = lblNumCheque.Text
                    txtbxFechaEmision.Text = IIf(lblFechaEmision.Text = "31/12/2099", String.Empty, lblFechaEmision.Text)
                    txtbxFechaPagoCheque.Text = IIf(lblFechaPagoCheque.Text = "31/12/2099", String.Empty, lblFechaPagoCheque.Text)
                    chkbxChequeCancel.Checked = chkbxCancelado.Checked
                    txtbxFechaCancelacion.Text = IIf(lblFechaCancelacion.Text = "31/12/2099", String.Empty, lblFechaCancelacion.Text)
                    txtbxFechaCancelacion.Enabled = chkbxChequeCancel.Checked
                    txtbxFechaCancelacion_RFV.Enabled = chkbxChequeCancel.Checked
                    txtbxFechaCancelacion_CV.Enabled = chkbxChequeCancel.Checked
                    txtbxFechaCancelacion_CV2.Enabled = chkbxChequeCancel.Checked
                    txtbxFechaCancelacion_CV3.Enabled = chkbxChequeCancel.Checked
                End If

                btnGuardar_CBE.ConfirmText = "Los datos capturados afectarán un total de 1 registro(s). ¿Continuar?"

                If gvCheque.Rows.Count = 1 Then
                    chkbxSelecAll = CType(gvCheque.HeaderRow.FindControl("chkbxSelecAll"), CheckBox)
                    chkbxSelecAll.Checked = True
                End If
            End If
        Next

        Select Case lblTipoCheque.Text
            Case "C"
                'setVisibleColumns2(gvCheque, False, True, False, True, False)
            Case "CPA"
                'setVisibleColumns2(gvCheque, False, False, True, True, False)
            Case "N"
                'setVisibleColumns2(gvCheque, False, True, False, True, True)
            Case "NPA"
                'setVisibleColumns2(gvCheque, False, False, True, False, True)
            Case "R"
                'setVisibleColumns2(gvCheque, True, True, False, True, False)
            Case Else

        End Select

        BindddlBancos()
        LlenaDDL(ddlCtasPag, "CuentaPagadora", "CuentaPagadora", oBanco.ObtenCtasPagadoras(CByte(ddlBancos.SelectedValue)))

        If ib.CommandArgument = 1 Then
            txtbxNumCheque.Text = String.Empty
            txtbxFechaEmision.Text = String.Empty
            txtbxFechaPagoCheque.Text = String.Empty
            chkbxChequeCancel.Checked = False
            txtbxFechaCancelacion.Text = String.Empty
            txtbxFechaCancelacion.Enabled = chkbxChequeCancel.Checked
            txtbxFechaCancelacion_RFV.Enabled = chkbxChequeCancel.Checked
            txtbxFechaCancelacion_CV.Enabled = chkbxChequeCancel.Checked
            txtbxFechaCancelacion_CV2.Enabled = chkbxChequeCancel.Checked
            txtbxFechaCancelacion_CV3.Enabled = chkbxChequeCancel.Checked
        End If

        mvCheques.SetActiveView(viewCaptura)
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As System.EventArgs) Handles btnCancelar.Click
        pnlTiposDeCheques.Visible = True
        pnlAños.Visible = True
        pnlMeses.Visible = True
        pnlQnas.Visible = True
        pnldivBotonesErrores.Visible = True
        mvCheques.SetActiveView(viewCheques)
    End Sub
    Protected Sub ddlBancos_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlBancos.SelectedIndexChanged
        Dim oBanco As New Bancos

        LlenaDDL(ddlCtasPag, "CuentaPagadora", "CuentaPagadora", oBanco.ObtenCtasPagadoras(CByte(ddlBancos.SelectedValue)))
    End Sub

    Protected Sub chkbxChequeCancel_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkbxChequeCancel.CheckedChanged
        txtbxFechaCancelacion.Enabled = chkbxChequeCancel.Checked
        txtbxFechaCancelacion_RFV.Enabled = chkbxChequeCancel.Checked
        txtbxFechaCancelacion_CV.Enabled = chkbxChequeCancel.Checked
        txtbxFechaCancelacion_CV2.Enabled = chkbxChequeCancel.Checked
        txtbxFechaCancelacion_CV3.Enabled = chkbxChequeCancel.Checked
    End Sub

    Protected Sub chkbxSelec_CheckedChanged(sender As Object, e As System.EventArgs)
        Dim vlCuentaRegistros As Short = 0
        Dim chkbxSelec As CheckBox = Nothing
        Dim chkbxSelecAll As CheckBox = Nothing

        chkbxSelecAll = CType(gvCheque.HeaderRow.FindControl("chkbxSelecAll"), CheckBox)

        For Each gvr_aux As GridViewRow In gvCheque.Rows
            Select Case gvr_aux.RowType
                Case DataControlRowType.DataRow
                    chkbxSelec = CType(gvr_aux.FindControl("chkbxSelec"), CheckBox)
                    If chkbxSelec.Checked Then vlCuentaRegistros = vlCuentaRegistros + 1
            End Select
        Next

        btnGuardar_CBE.ConfirmText = "Los datos capturados afectarán un total de " + vlCuentaRegistros.ToString + " registro(s). ¿Continuar?"

        btnGuardar.Enabled = vlCuentaRegistros > 0

        If vlCuentaRegistros = 0 Then
            chkbxSelecAll.Checked = False
        ElseIf vlCuentaRegistros = gvCheque.Rows.Count Then
            chkbxSelecAll.Checked = True
        ElseIf vlCuentaRegistros < gvCheque.Rows.Count Then
            chkbxSelecAll.Checked = False
        End If

    End Sub

    Protected Sub chkbxSelecAll_CheckedChanged(sender As Object, e As System.EventArgs)
        Dim chkbxSelecAll As CheckBox
        Dim chkbxSelec As CheckBox

        chkbxSelecAll = CType(sender, CheckBox)

        For Each gvr_aux As GridViewRow In gvCheque.Rows
            chkbxSelec = CType(gvr_aux.FindControl("chkbxSelec"), CheckBox)
            chkbxSelec.Checked = chkbxSelecAll.Checked
        Next

        If chkbxSelecAll.Checked Then
            btnGuardar_CBE.ConfirmText = "Los datos capturados afectarán un total de " + gvCheque.Rows.Count.ToString + " registro(s). ¿Continuar?"
            btnGuardar.Enabled = True
        Else
            btnGuardar_CBE.ConfirmText = "Los datos capturados afectarán un total de 0 registro(s). ¿Continuar?"
            btnGuardar.Enabled = False
        End If
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As System.EventArgs) Handles btnGuardar.Click
        Dim chkbxSelec As CheckBox
        Dim lblId_Emp_BenefPA As Label
        Dim lblIdQuincena As Label
        Dim lblAnio As Label
        Dim lblIdMes As Label
        Dim lblAdicional As Label
        Dim lblIdPlantel As Label
        Dim lblIdRecibo As Label
        Dim lblTipoCheque As Label
        Dim vlFechaEmision As String
        Dim vlFechaPagoCheque As String
        Dim vlFechaCancelacion As String
        Dim oNomina As New Nomina

        vlFechaEmision = IIf(txtbxFechaEmision.Text.Trim = String.Empty, "31/12/2099", txtbxFechaEmision.Text)
        vlFechaPagoCheque = IIf(txtbxFechaPagoCheque.Text.Trim = String.Empty, "31/12/2099", txtbxFechaPagoCheque.Text)
        vlFechaCancelacion = IIf(txtbxFechaCancelacion.Text.Trim = String.Empty, "31/12/2099", txtbxFechaCancelacion.Text)

        For Each gvr_aux As GridViewRow In gvCheque.Rows
            chkbxSelec = CType(gvr_aux.FindControl("chkbxSelec"), CheckBox)
            lblId_Emp_BenefPA = CType(gvr_aux.FindControl("lblId_Emp_BenefPA"), Label)
            lblIdQuincena = CType(gvr_aux.FindControl("lblIdQuincena"), Label)
            lblAnio = CType(gvr_aux.FindControl("lblAnio"), Label)
            lblIdMes = CType(gvr_aux.FindControl("lblIdMes"), Label)
            lblAdicional = CType(gvr_aux.FindControl("lblAdicional"), Label)
            lblIdPlantel = CType(gvr_aux.FindControl("lblIdPlantel"), Label)
            lblIdRecibo = CType(gvr_aux.FindControl("lblIdRecibo"), Label)
            lblTipoCheque = CType(gvr_aux.FindControl("lblTipoCheque"), Label)

            If chkbxSelec.Checked Then
                oNomina.InsUpdInfCompCheques(CInt(lblId_Emp_BenefPA.Text), CShort(lblIdQuincena.Text), CShort(lblAnio.Text), _
                                                  CByte(lblIdMes.Text), CByte(lblAdicional.Text), CShort(lblIdPlantel.Text), _
                                                  CShort(lblIdRecibo.Text), lblTipoCheque.Text, _
                                                  CByte(ddlBancos.SelectedValue), ddlCtasPag.SelectedValue, txtbxNumCheque.Text, _
                                                  CDate(vlFechaEmision), CDate(vlFechaPagoCheque), _
                                                  txtbxObservs.Text, chkbxChequeCancel.Checked, CDate(vlFechaCancelacion), CByte(btnGuardar.CommandArgument))
            End If

        Next

        pnldivBotonesErrores.Visible = True
        btnConsultar_Click(sender, e)
        mvCheques.SetActiveView(viewCheques)
    End Sub

    Protected Sub gvCheques_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvCheques.RowDataBound
        Dim lblNumCheque As Label
        Dim ibCapturar As ImageButton
        Dim ibModificar As ImageButton

        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                lblNumCheque = CType(e.Row.FindControl("lblNumCheque"), Label)
                ibCapturar = CType(e.Row.FindControl("ibCapturar"), ImageButton)
                ibModificar = CType(e.Row.FindControl("ibModificar"), ImageButton)

                If lblNumCheque.Text.Trim <> String.Empty Then
                    ibCapturar.Visible = False
                    ibModificar.Visible = True
                Else
                    ibCapturar.Visible = True
                    ibModificar.Visible = False
                End If

                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End Select

    End Sub

    Protected Sub gvCheque_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvCheque.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End Select

    End Sub
End Class