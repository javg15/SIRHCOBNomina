Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.Empleados
Imports System.Data
Imports DataAccessLayer.COBAEV.Administracion
Imports DataAccessLayer.COBAEV
Partial Class CompensacionesBuscarEmps
    Inherits System.Web.UI.Page
    Private Sub setPermisos()
        Dim oUsr As New Usuario
        Dim dtPermisosUsuario As DataTable
        Dim dtPermisosUsuario2 As DataTable
        'Dim oQna As New Quincenas
        'Dim vlHayQnaAbierta As Boolean

        dtPermisosUsuario = oUsr.ObtenPermisosSobreTabla(Session("Login"), "Compensaciones")
        dtPermisosUsuario2 = oUsr.ObtenPermisosSobreTabla(Session("Login"), "Compensaciones2")

        'vlHayQnaAbierta = oQna.HayAbiertasParaCaptura()

        lbAddCompen.Visible = CBool(dtPermisosUsuario.Rows(0).Item("Insercion")) 'And vlHayQnaAbierta 'Permiso inserción
        gvHistoriaCompe.Columns(18).Visible = CBool(dtPermisosUsuario.Rows(0).Item("Actualizacion")) 'And vlHayQnaAbierta 'Permiso actualización
        gvHistoriaCompe.Columns(19).Visible = CBool(dtPermisosUsuario.Rows(0).Item("Eliminacion")) 'And vlHayQnaAbierta 'Permiso eliminación

        lbAddBPA.Visible = CBool(dtPermisosUsuario2.Rows(0).Item("Insercion")) 'And vlHayQnaAbierta 'Permiso inserción
        gvBPA.Columns(4).Visible = CBool(dtPermisosUsuario2.Rows(0).Item("Consulta"))
        lbAddCompenBPA.Visible = CBool(dtPermisosUsuario2.Rows(0).Item("Insercion")) 'And vlHayQnaAbierta 'Permiso inserción
        gvHistoriaCompe2.Columns(16).Visible = CBool(dtPermisosUsuario2.Rows(0).Item("Actualizacion"))
        gvHistoriaCompe2.Columns(17).Visible = CBool(dtPermisosUsuario2.Rows(0).Item("Eliminacion"))
    End Sub
    Private Sub setPermisos2()
        Dim oUsr As New Usuario
        Dim dtPermisosUsuario As DataTable
        Dim dtPermisosUsuario2 As DataTable

        dtPermisosUsuario = oUsr.ObtenPermisosSobreTabla(Session("Login"), "Compensaciones")
        dtPermisosUsuario2 = oUsr.ObtenPermisosSobreTabla(Session("Login"), "Compensaciones2")

        lbAddCompen.Visible = lbAddCompen.Visible And CBool(dtPermisosUsuario.Rows(0).Item("Insercion")) 'And vlHayQnaAbierta 'Permiso inserción
        lbAddBPA.Visible = lbAddBPA.Visible And CBool(dtPermisosUsuario2.Rows(0).Item("Insercion")) 'And vlHayQnaAbierta 'Permiso inserción
        'lbAddCompenBPA.Visible = CBool(dtPermisosUsuario2.Rows(0).Item("Insercion")) 'And vlHayQnaAbierta 'Permiso inserción
    End Sub
    Private Sub setPermisos3()
        Dim oUsr As New Usuario
        Dim dtPermisosUsuario As DataTable
        Dim dtPermisosUsuario2 As DataTable

        dtPermisosUsuario = oUsr.ObtenPermisosSobreTabla(Session("Login"), "Compensaciones")
        dtPermisosUsuario2 = oUsr.ObtenPermisosSobreTabla(Session("Login"), "Compensaciones2")

        'lbAddCompen.Visible = lbAddCompen.Visible And CBool(dtPermisosUsuario.Rows(0).Item("Insercion")) 'And vlHayQnaAbierta 'Permiso inserción
        'lbAddBPA.Visible = lbAddBPA.Visible And CBool(dtPermisosUsuario2.Rows(0).Item("Insercion")) 'And vlHayQnaAbierta 'Permiso inserción
        lbAddCompenBPA.Visible = lbAddCompenBPA.Visible And CBool(dtPermisosUsuario2.Rows(0).Item("Insercion")) 'And vlHayQnaAbierta 'Permiso inserción
    End Sub
    Private Sub ibDetalleBPAClick(ByVal gvr As GridViewRow)
        Dim lblClaveCobro As Label = CType(gvr.FindControl("lblClaveCobro"), Label)
        Dim lblApePatBPA As Label = CType(gvr.FindControl("lblApePatBPA"), Label)
        Dim lblApeMatBPA As Label = CType(gvr.FindControl("lblApeMatBPA"), Label)
        Dim lblNombreBPA As Label = CType(gvr.FindControl("lblNombreBPA"), Label)
        Dim vlNombre As String = String.Concat(lblApePatBPA.Text, " ", lblApeMatBPA.Text, " ", lblNombreBPA.Text).Replace("  ", " ")

        gvBPA.SelectedIndex = gvr.RowIndex

        pnl4.GroupingText = "Desglose mensual de pensión alimenticia recibida durante el año " + ddlAnios.SelectedItem.Text + "  por: " + vlNombre
        BindgvHistoriaCompe2(lblClaveCobro.Text)
        pnl4.Visible = True
    End Sub
    Private Sub ModificarBPA(ByVal gvr As GridViewRow)
        'Dim gvr As GridViewRow = CType(CType(sender, ImageButton).NamingContainer, GridViewRow)
        'Dim vlRFCEmp As String
        'Dim hfRFC As HiddenField = CType(WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        Dim oCompensacion As New Compensacion
        Dim lblAnio As Label = CType(gvr.FindControl("lblAnio"), Label)
        Dim lblIdMes As Label = CType(gvr.FindControl("lblIdMes"), Label)
        Dim lblAdicional As Label = CType(gvr.FindControl("lblAdicional"), Label)
        Dim lblOrigen As Label = CType(gvr.FindControl("lblOrigen"), Label)
        Dim lblTipoDeNomina As Label = CType(gvr.FindControl("lblTipoDeNomina"), Label)
        Dim lblApePatBPA As Label = CType(gvBPA.SelectedRow.FindControl("lblApePatBPA"), Label)
        Dim lblApeMatBPA As Label = CType(gvBPA.SelectedRow.FindControl("lblApeMatBPA"), Label)
        Dim lblNombreBPA As Label = CType(gvBPA.SelectedRow.FindControl("lblNombreBPA"), Label)
        Dim dr As DataRow
        Dim ds As DataSet
        Dim dtMeses As DataTable
        Dim vlMesesAmparados As Byte
        Dim vlIndice As Byte
        Dim dtNumsAdic As DataTable
        Dim dtMesesQueAmparaPago As DataTable
        Dim lblClaveCobro As Label = CType(gvBPA.SelectedRow.FindControl("lblClaveCobro"), Label)

        'vlRFCEmp = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))

        gvHistoriaCompe2.SelectedIndex = gvr.RowIndex

        ds = oCompensacion.ObtenAcumuladoPorEmp3(lblClaveCobro.Text, CShort(lblAnio.Text))

        dr = oCompensacion.ObtenParaModificacionC2(lblClaveCobro.Text, CShort(lblAnio.Text), CByte(lblIdMes.Text), CByte(lblAdicional.Text), lblOrigen.Text)
        dtNumsAdic = oCompensacion.ObtenNumsDeAdicC2(lblClaveCobro.Text, CShort(lblAnio.Text), CByte(lblIdMes.Text), CByte(lblAdicional.Text), lblOrigen.Text)

        dtMeses = ds.Tables(1)
        dtMesesQueAmparaPago = ds.Tables(2)

        SetVisibleBotones_wucBuscaEmps(False)
        pnl6.GroupingText = "Información de la pensión alimenticia actual del beneficiario"
        txtbxTipoOperacionBPA.Text = "Actualización"
        txtbxApePatBPA.Text = lblApePatBPA.Text
        txtbxApeMatBPA.Text = lblApeMatBPA.Text
        txtbxNombreBPA.Text = lblNombreBPA.Text
        LlenaDDL(ddlNumeroDeNominasBPA, "AdicionalDescripcion", "Adicional", dtNumsAdic, dr("Adicional").ToString)
        txtbxImportePA.Text = dr("Importe")
        txtbxClaveCobroBPA.Text = dr("ClaveCobro").ToString
        txtbxClaveCobroBPA.Enabled = False
        ChBxPagarConChequeBPA.Checked = CBool(dr("PagarConCheque"))
        BindddlBancos(ddlBancosBPA, dr("IdBanco").ToString)
        txtbxCtaBancariaBPA.Text = dr("CuentaBancaria").ToString
        lblMesesAmparadosBPA.Text = "Meses amparados con el pago: (Año " + lblAnio.Text + ")"
        ChBxPagarConChequeBPACheckedChanged()

        If dtMeses.Rows.Count = CInt(lblIdMes.Text) Then
            vlMesesAmparados = 1
        ElseIf dtMeses.Rows.Count < CInt(lblIdMes.Text) Then
            'vlMesesAmparados = (CInt(lblIdMes.Text) - dtMeses.Rows.Count) + 1
            vlMesesAmparados = (CInt(lblIdMes.Text) - CInt(dtMesesQueAmparaPago.Rows(0).Item("MesesQueAmparaPago"))) + CInt(dr("MesesQueAmparaPago"))
        Else
            vlMesesAmparados = 1
        End If

        ddlMesesAmpBPA.Items.Clear()

        If lblTipoDeNomina.Text = "O" Then
            For vlIndice = 1 To vlMesesAmparados Step 1
                ddlMesesAmpBPA.Items.Add(New ListItem(vlIndice.ToString, vlIndice.ToString))
            Next
        ElseIf lblTipoDeNomina.Text = "C" Then
            For vlIndice = 0 To vlMesesAmparados Step 1
                ddlMesesAmpBPA.Items.Add(New ListItem(vlIndice.ToString, vlIndice.ToString))
            Next
        ElseIf lblTipoDeNomina.Text = "E" Then
            ddlMesesAmpBPA.Items.Add(New ListItem("0", "0"))
        End If

        ddlMesesAmpBPA.SelectedValue = dr("MesesQueAmparaPago").ToString

        txtbxObservsBPA.Text = dr("Observaciones").ToString

        pnl6.Enabled = True

        MVMain.SetActiveView(VCBPA)
    End Sub
    Private Sub BindddlMesesAmp()
        Dim vlRFCEmp As String
        Dim hfRFC As HiddenField = CType(WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        Dim vlMesesAmparados As Byte
        Dim vlIndice As Byte
        Dim oCompensacion As New Compensacion
        Dim ds As DataSet
        Dim dr2 As DataRow
        Dim dtMeses As DataTable
        Dim dtNumsAdic As DataTable
        Dim lblIdMes As New Label
        Dim lblTipoDeNomina As New Label

        vlRFCEmp = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))

        ds = oCompensacion.ObtenAcumuladoPorEmp2(vlRFCEmp, CShort(ddlAnios.SelectedValue))
        dr2 = oCompensacion.PosiblesDatosParaNuevaCompe(vlRFCEmp, 0).Rows(0)
        dtNumsAdic = oCompensacion.ObtenNumsDeAdic(vlRFCEmp, CShort(ddlAnios.SelectedValue), "C1")
        dtMeses = ds.Tables(2)

        lblIdMes.Text = dr2("IdMes").ToString

        If dtMeses.Rows.Count = CInt(lblIdMes.Text) Then
            vlMesesAmparados = 1
        ElseIf dtMeses.Rows.Count < CInt(lblIdMes.Text) Then
            vlMesesAmparados = CInt(lblIdMes.Text) - dtMeses.Rows.Count
        Else
            vlMesesAmparados = 1
        End If

        ddlMesesAmp.Items.Clear()

        For Each dr As DataRow In dtNumsAdic.Rows
            If dr("Adicional").ToString = ddlNumeroDeNominas.SelectedValue Then
                lblTipoDeNomina.Text = dr("TipoDeNomina").ToString
            End If
        Next

        If lblTipoDeNomina.Text = "O" Then
            For vlIndice = 1 To vlMesesAmparados Step 1
                ddlMesesAmp.Items.Add(New ListItem(vlIndice.ToString, vlIndice.ToString))
            Next
        ElseIf lblTipoDeNomina.Text = "C" Then
            For vlIndice = 0 To vlMesesAmparados Step 1
                ddlMesesAmp.Items.Add(New ListItem(vlIndice.ToString, vlIndice.ToString))
            Next
        ElseIf lblTipoDeNomina.Text = "E" Then
            ddlMesesAmp.Items.Add(New ListItem("0", "0"))
        End If
    End Sub
    Private Sub BindddlMesesAmpBPA()
        Dim vlMesesAmparados As Byte
        Dim vlIndice As Byte
        Dim oCompensacion As New Compensacion
        Dim ds As DataSet
        Dim dr2 As DataRow
        Dim dtMeses As DataTable
        Dim dtNumsAdic As DataTable
        Dim lblIdMes As New Label
        Dim lblTipoDeNomina As New Label
        Dim vlClaveCobro As String = txtbxClaveCobroBPA.Text

        ds = oCompensacion.ObtenAcumuladoPorEmp3(vlClaveCobro, CShort(ddlAnios.SelectedValue))
        dr2 = oCompensacion.PosiblesDatosParaNuevaCompe(vlClaveCobro).Rows(0)
        dtNumsAdic = oCompensacion.ObtenNumsDeAdic(vlClaveCobro, CShort(ddlAnios.SelectedValue), "C2")
        dtMeses = ds.Tables(2)

        lblIdMes.Text = dr2("IdMes").ToString

        If dtMeses.Rows.Count = CInt(lblIdMes.Text) Then
            vlMesesAmparados = 1
        ElseIf dtMeses.Rows.Count < CInt(lblIdMes.Text) Then
            vlMesesAmparados = CInt(lblIdMes.Text) - dtMeses.Rows.Count
        Else
            vlMesesAmparados = 1
        End If

        ddlMesesAmpBPA.Items.Clear()

        For Each dr As DataRow In dtNumsAdic.Rows
            If dr("Adicional").ToString = ddlNumeroDeNominasBPA.SelectedValue Then
                lblTipoDeNomina.Text = dr("TipoDeNomina").ToString
            End If
        Next

        If lblTipoDeNomina.Text = "O" Then
            For vlIndice = 1 To vlMesesAmparados Step 1
                ddlMesesAmpBPA.Items.Add(New ListItem(vlIndice.ToString, vlIndice.ToString))
            Next
        ElseIf lblTipoDeNomina.Text = "C" Then
            For vlIndice = 0 To vlMesesAmparados Step 1
                ddlMesesAmpBPA.Items.Add(New ListItem(vlIndice.ToString, vlIndice.ToString))
            Next
        ElseIf lblTipoDeNomina.Text = "E" Then
            ddlMesesAmpBPA.Items.Add(New ListItem("0", "0"))
        End If
    End Sub
    Private Sub BindddlBancos(ByVal ddl As DropDownList, ByVal SelectedValue As String)
        Dim oBanco As New Bancos
        LlenaDDL(ddl, "NombreCortoBanco", "IdBanco", oBanco.ObtenTodos(), SelectedValue)
    End Sub
    Private Sub ChBxPagarConChequeCheckedChanged()
        ddlBancos.Enabled = Not ChBxPagarConCheque.Checked
        ddlBancos_RFV.Enabled = Not ChBxPagarConCheque.Checked

        txtbxCtaBancaria.Enabled = Not ChBxPagarConCheque.Checked

        If txtbxTipoOperacion.Text = "Captura" Then
            ddlBancosSelectedIndexChanged()
        ElseIf txtbxTipoOperacion.Text = "Actualización" Then
            ddlBancosSelectedIndexChanged()
        End If
    End Sub
    Private Sub ChBxPagarConChequeBPACheckedChanged()
        ddlBancosBPA.Enabled = Not ChBxPagarConChequeBPA.Checked
        ddlBancosBPA_RFV.Enabled = Not ChBxPagarConChequeBPA.Checked

        txtbxCtaBancariaBPA.Enabled = Not ChBxPagarConChequeBPA.Checked

        If txtbxTipoOperacionBPA.Text = "Captura" Then
            ddlBancosBPASelectedIndexChanged()
        ElseIf txtbxTipoOperacionBPA.Text = "Actualización" Then
            ddlBancosBPASelectedIndexChanged()
        End If
    End Sub
    Private Sub ddlBancosSelectedIndexChanged()
        Dim oBanco As New Bancos
        Dim dr As DataRow
        Dim array() As String

        dr = oBanco.ObtenPorId(CByte(ddlBancos.SelectedValue))

        If ddlBancos.SelectedValue = "3" Then txtbxCtaBancaria.Text = String.Empty

        txtbxCtaBancaria.Enabled = CInt(dr("LongitudCuenta")) <> 0 And Not ChBxPagarConCheque.Checked
        If txtbxCtaBancaria.Enabled = False Then
            txtbxCtaBancaria_REV.Enabled = False
            txtbxCtaBancaria_RFV.Enabled = False
        Else
            txtbxCtaBancaria_REV.Enabled = True
            txtbxCtaBancaria_RFV.Enabled = True
            array = dr("LongitudCuenta").ToString.Split(",")
            txtbxCtaBancaria_REV.ValidationExpression = dr("ExpRegValidadora").ToString
            txtbxCtaBancaria.MaxLength = CInt(array(array.Length - 1))
            txtbxCtaBancaria_REV.ErrorMessage = "La longitud de la cuenta para la transferencia bancaria debe ser de " + dr("LongitudCuenta").ToString + " dígitos."
            txtbxCtaBancaria_REV.ToolTip = "La longitud de la cuenta para la transferencia bancaria debe ser de " + dr("LongitudCuenta").ToString + " dígitos."
            txtbxCtaBancaria_REV.Text = "*"
        End If
    End Sub
    Private Sub ddlBancosBPASelectedIndexChanged()
        Dim oBanco As New Bancos
        Dim dr As DataRow
        Dim array() As String

        dr = oBanco.ObtenPorId(CByte(ddlBancosBPA.SelectedValue))

        If ddlBancosBPA.SelectedValue = "3" Then txtbxCtaBancariaBPA.Text = String.Empty

        txtbxCtaBancariaBPA.Enabled = CInt(dr("LongitudCuenta")) <> 0 And Not ChBxPagarConChequeBPA.Checked
        If txtbxCtaBancariaBPA.Enabled = False Then
            txtbxCtaBancariaBPA_REV.Enabled = False
            txtbxCtaBancariaBPA_RFV.Enabled = False
        Else
            txtbxCtaBancariaBPA_REV.Enabled = True
            txtbxCtaBancariaBPA_RFV.Enabled = True
            array = dr("LongitudCuenta").ToString.Split(",")
            txtbxCtaBancariaBPA_REV.ValidationExpression = dr("ExpRegValidadora").ToString
            txtbxCtaBancariaBPA.MaxLength = CInt(array(array.Length - 1))
            txtbxCtaBancariaBPA_REV.ErrorMessage = "La longitud de la cuenta para la transferencia bancaria debe ser de " + dr("LongitudCuenta").ToString + " dígitos."
            txtbxCtaBancariaBPA_REV.ToolTip = "La longitud de la cuenta para la transferencia bancaria debe ser de " + dr("LongitudCuenta").ToString + " dígitos."
            txtbxCtaBancariaBPA_REV.Text = "*"
        End If
    End Sub
    Private Sub SetVisibleBotones_wucBuscaEmps(ByVal pValor As Boolean)
        Dim BtnNewSearch As Button = CType(WucBuscaEmpleados1.FindControl("BtnNewSearch"), Button)
        Dim BtnCancelSearch As Button = CType(Me.WucBuscaEmpleados1.FindControl("BtnCancelSearch"), Button)
        Dim BtnSearch As Button = CType(Me.WucBuscaEmpleados1.FindControl("BtnSearch"), Button)

        BtnNewSearch.Visible = pValor
        BtnCancelSearch.Visible = pValor
        BtnSearch.Visible = pValor
    End Sub
    Private Sub BindgvHistoriaCompe()
        Dim vlRFCEmp As String
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        Dim ds As DataSet = Nothing
        Dim oCompen As New Compensacion
        Dim lblImporteTotal As Label
        Dim lblImporteTotalPA As Label
        Dim lblImporteTotalR As Label
        Dim lblImporteFaltaTotalPA As Label
        Dim lblImporteFaltaTotal As Label
        Dim lblDiasFaltaTotal As Label
        Dim lblMesesQueAmparaPagoT As Label
        Dim dtNumsAdic As DataTable

        vlRFCEmp = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))
        If ddlAnios.SelectedValue <> "-1" Then
            ds = oCompen.ObtenAcumuladoPorEmp2(vlRFCEmp, CShort(ddlAnios.SelectedValue))
        End If

        With gvHistoriaCompe
            If ds Is Nothing = False Then
                .DataSource = ds.Tables(0)
            End If
            .DataBind()
        End With

        If gvHistoriaCompe.Rows.Count > 0 Then
            lblImporteTotal = CType(gvHistoriaCompe.FooterRow.FindControl("lblImporteTotal"), Label)
            lblImporteTotal.Text = Format(ds.Tables(0).Compute("Sum(Importe)", ""), "$ ###,###,##0.00")
            lblImporteTotalPA = CType(gvHistoriaCompe.FooterRow.FindControl("lblImporteTotalPA"), Label)
            lblImporteTotalPA.Text = Format(ds.Tables(0).Compute("Sum(ImportePA)", ""), "$ ###,###,##0.00")
            lblImporteTotalR = CType(gvHistoriaCompe.FooterRow.FindControl("lblImporteTotalR"), Label)
            lblImporteTotalR.Text = Format(ds.Tables(0).Compute("Sum(ImporteTR)", ""), "$ ###,###,##0.00")
            lblMesesQueAmparaPagoT = CType(gvHistoriaCompe.FooterRow.FindControl("lblMesesQueAmparaPagoT"), Label)
            lblMesesQueAmparaPagoT.Text = Format(ds.Tables(0).Compute("Sum(MesesQueAmparaPago)", ""), "###,###,##0")

            lblImporteFaltaTotalPA = CType(gvHistoriaCompe.FooterRow.FindControl("lblImporteFaltaTotalPA"), Label)
            lblImporteFaltaTotalPA.Text = Format(ds.Tables(0).Compute("Sum(ImportePAFalta)", ""), "$ ###,###,##0")
            lblImporteFaltaTotal = CType(gvHistoriaCompe.FooterRow.FindControl("lblImporteFaltaTotal"), Label)
            lblImporteFaltaTotal.Text = Format(ds.Tables(0).Compute("Sum(ImporteFalta)", ""), "$ ###,###,##0")
            lblDiasFaltaTotal = CType(gvHistoriaCompe.FooterRow.FindControl("lblDiasFaltaTotal"), Label)
            lblDiasFaltaTotal.Text = Format(ds.Tables(0).Compute("Sum(diasDto)", ""), "##0")
        End If

        With gvBPA
            If ds Is Nothing = False Then
                .DataSource = ds.Tables(1)
            End If
            .DataBind()
            gvBPA.SelectedIndex = -1
        End With

        dtNumsAdic = oCompen.ObtenNumsDeAdic(vlRFCEmp, CShort(ddlAnios.SelectedItem.Text), "C1")
        lbAddCompen.Visible = dtNumsAdic.Rows.Count > 0 And CShort(ds.Tables(4).Rows(0).Item("Anio")) = CShort(ddlAnios.SelectedValue) And ds.Tables(4).Rows(0).Item("MesAbierto").ToString = "SI"
        lbAddBPA.Visible = gvHistoriaCompe.Rows.Count > 0 And CShort(ds.Tables(4).Rows(0).Item("Anio")) = CShort(ddlAnios.SelectedValue) And ds.Tables(4).Rows(0).Item("MesAbierto").ToString = "SI"
        setPermisos2()
    End Sub
    Private Sub BindgvHistoriaCompe2(ByVal pClaveCobro As String)
        Dim dt As DataTable = Nothing
        Dim ds As DataSet
        Dim oCompen As New Compensacion
        Dim lblImporteTotal As Label
        Dim lblMesesQueAmparaPagoT As Label
        Dim dtNumsAdic As DataTable

        ds = oCompen.ObtenAcumuladoPorEmp3(pClaveCobro, CShort(ddlAnios.SelectedValue))

        With gvHistoriaCompe2
            If ds.Tables.Count > 0 Then
                dt = ds.Tables(0)
                .DataSource = dt
            End If
            .DataBind()
        End With

        If gvHistoriaCompe2.Rows.Count > 0 Then
            lblImporteTotal = CType(gvHistoriaCompe2.FooterRow.FindControl("lblImporteTotal"), Label)
            lblImporteTotal.Text = Format(dt.Compute("Sum(Importe)", ""), "$ ###,###,##0.00")
            lblMesesQueAmparaPagoT = CType(gvHistoriaCompe2.FooterRow.FindControl("lblMesesQueAmparaPagoT"), Label)
            lblMesesQueAmparaPagoT.Text = Format(dt.Compute("Sum(MesesQueAmparaPago)", ""), "###,###,##0")
        End If

        dtNumsAdic = oCompen.ObtenNumsDeAdicC2(pClaveCobro, CShort(ddlAnios.SelectedItem.Text), "C2")
        'lbAddBPA.Visible = CShort(ds.Tables(3).Rows(0).Item("Anio")) = CShort(ddlAnios.SelectedValue) And gvHistoriaCompe.Rows.Count > 0
        lbAddCompenBPA.Visible = dtNumsAdic.Rows.Count > 0 And CShort(ds.Tables(3).Rows(0).Item("Anio")) = CShort(ddlAnios.SelectedValue) And ds.Tables(3).Rows(0).Item("MesAbierto").ToString = "SI"
        setPermisos3()
    End Sub
    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, ByVal dt As DataTable, ByVal SelectedValue As String)
        ddl.DataSource = dt
        ddl.DataTextField = TextField
        ddl.DataValueField = ValueField
        ddl.DataBind()
        If SelectedValue Is Nothing = False Then ddl.SelectedValue = SelectedValue
    End Sub
    Private Sub BindgvAnios()
        Dim oCompen As New Compensacion
        Dim oNomina As New Nomina
        Dim vlRFCEmp As String
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        Dim hfNomEmp As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfNomEmp"), HiddenField)
        'Dim dtNumsAdic As DataTable

        vlRFCEmp = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))

        If vlRFCEmp <> String.Empty Then
            pnl1.GroupingText = "Años en los que el empleado " + hfNomEmp.Value + " ha tenido gratificación extraordinaria"
            LlenaDDL(ddlAnios, "Anio", "Anio", oCompen.BuscaAniosConCompenPorEmp(vlRFCEmp), Nothing)

            If ddlAnios.Items.Count > 0 Then
                pnl1.Visible = True
                btnConsultar.Visible = True
                pnl2.Visible = True
                pnl2.GroupingText = "Desglose mensual de gratificaciones extraordinarias recibidas durante el año: " + ddlAnios.SelectedItem.Text
                BindgvHistoriaCompe()
                pnl4.Visible = False
            Else
                pnl1.Visible = True
                ddlAnios.Items.Add(New ListItem(Now.Year.ToString, Now.Year.ToString))
                btnConsultar.Visible = False
                pnl2.Visible = True
                pnl2.GroupingText = "Desglose mensual de gratificaciones extraordinarias recibidas durante el año: " + ddlAnios.SelectedItem.Text
                BindgvHistoriaCompe()
                pnl4.Visible = False
            End If
        Else
            pnl1.Visible = False
            pnl2.Visible = False
        End If
    End Sub


    Protected Sub WucBuscaEmpleados1_PreRender(sender As Object, e As System.EventArgs) Handles WucBuscaEmpleados1.PreRender
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        If Request.Params(0).Contains("BtnSearch") Or Request.Params(1).Contains("BtnSearch") Then
            If hfRFC.Value <> String.Empty Then
                BindgvAnios()
            End If
        ElseIf Request.Params(0).Contains("BtnNewSearch") Or Request.Params(1).Contains("BtnNewSearch") Then
            pnl1.Visible = False
            pnl2.Visible = False
        ElseIf Request.Params(0).Contains("BtnCancelSearch") Or Request.Params(1).Contains("BtnCancelSearch") Then
            pnl1.Visible = True
            pnl2.Visible = True
        ElseIf Request.Params("__EVENTTARGET") Is Nothing = False Then
            If Request.Params("__EVENTTARGET").Contains("lnkbtnrfc") Then
                BindgvAnios()
            End If
        End If
    End Sub

    Protected Sub Page_LoadComplete(sender As Object, e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            MVMain.SetActiveView(VABCCompen)
            BindgvAnios()
            setPermisos()
        End If
    End Sub

    Protected Sub btnConsultar_Click(sender As Object, e As System.EventArgs) Handles btnConsultar.Click
        pnl2.GroupingText = "Desglose mensual de gratificaciones extraordinarias recibidas durante el año: " + ddlAnios.SelectedItem.Text
        BindgvHistoriaCompe()
        pnl4.Visible = False
    End Sub

    Protected Sub ddlAnios_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlAnios.SelectedIndexChanged
        pnl2.GroupingText = "Desglose mensual de gratificaciones extraordinarias recibidas durante el año: " + ddlAnios.SelectedItem.Text
        BindgvHistoriaCompe()
        pnl4.Visible = False
    End Sub

    Protected Sub ibDetalle_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs)
        Dim gvr As GridViewRow = CType(CType(sender, ImageButton).NamingContainer, GridViewRow)

        ibDetalleBPAClick(gvr)
    End Sub

    Protected Sub gvHistoriaCompe_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvHistoriaCompe.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                Dim ibModificar As ImageButton = CType(e.Row.FindControl("ibModificar"), ImageButton)
                Dim ibEliminar As ImageButton = CType(e.Row.FindControl("ibEliminar"), ImageButton)
                Dim lnAgregarFalta As ImageButton = CType(e.Row.FindControl("lnAgregarFalta"), ImageButton)
                Dim lblPermiteCambios As Label = CType(e.Row.FindControl("lblPermiteCambios"), Label)

                If e.Row.RowIndex > 0 Then
                    lnAgregarFalta.Visible = False
                End If
                If lblPermiteCambios.Text = "N" Then
                    ibModificar.Enabled = False
                    ibModificar.ImageUrl = "~/Imagenes/ModificarDisabled.jpg"
                    ibModificar.ToolTip = "(Opción deshabilitada)"
                    ibEliminar.Enabled = False
                    ibEliminar.ImageUrl = "~/Imagenes/EliminarDisabled.jpg"
                    ibEliminar.ToolTip = "(Opción deshabilitada)"
                Else
                    ibModificar.Enabled = True
                    ibModificar.ImageUrl = "~/Imagenes/Modificar.png"
                    ibModificar.ToolTip = "Modificar la información del registro."
                    ibEliminar.Enabled = True
                    ibEliminar.ImageUrl = "~/Imagenes/Eliminar.png"
                    ibEliminar.ToolTip = "Eliminar registro."
                End If

                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End Select
    End Sub

    Protected Sub ibModificar_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs)
        Dim gvr As GridViewRow = CType(CType(sender, ImageButton).NamingContainer, GridViewRow)
        Dim vlRFCEmp As String
        Dim hfRFC As HiddenField = CType(WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        Dim oCompensacion As New Compensacion
        Dim lblAnio As Label = CType(gvr.FindControl("lblAnio"), Label)
        Dim lblIdMes As Label = CType(gvr.FindControl("lblIdMes"), Label)
        Dim lblAdicional As Label = CType(gvr.FindControl("lblAdicional"), Label)
        Dim lblOrigen As Label = CType(gvr.FindControl("lblOrigen"), Label)
        Dim lblTipoDeNomina As Label = CType(gvr.FindControl("lblTipoDeNomina"), Label)
        Dim dr As DataRow
        Dim ds As DataSet
        Dim dtMeses As DataTable
        Dim vlMesesAmparados As Byte
        Dim vlIndice As Byte
        Dim dtNumsAdic As DataTable
        Dim dtMesesQueAmparaPago As DataTable

        vlRFCEmp = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))

        gvHistoriaCompe.SelectedIndex = gvr.RowIndex

        ds = oCompensacion.ObtenAcumuladoPorEmp2(vlRFCEmp, CShort(lblAnio.Text))
        dr = oCompensacion.ObtenParaModificacionC1(vlRFCEmp, CShort(lblAnio.Text), CByte(lblIdMes.Text), CByte(lblAdicional.Text), lblOrigen.Text)
        dtNumsAdic = oCompensacion.ObtenNumsDeAdic(vlRFCEmp, CShort(lblAnio.Text), CByte(lblIdMes.Text), CByte(lblAdicional.Text), lblOrigen.Text)

        dtMeses = ds.Tables(2)
        dtMesesQueAmparaPago = ds.Tables(3)

        SetVisibleBotones_wucBuscaEmps(False)
        pnl5.GroupingText = "Información de la gratificación extraordinaria actual del empleado"
        txtbxTipoOperacion.Text = "Actualización"
        LlenaDDL(ddlNumeroDeNominas, "AdicionalDescripcion", "Adicional", dtNumsAdic, dr("Adicional").ToString)
        txtbxImporte.Text = dr("Importe")
        txtbxClaveCobro.Text = dr("ClaveCobro").ToString
        ChBxPagarConCheque.Checked = CBool(dr("PagarConCheque"))
        BindddlBancos(ddlBancos, dr("IdBanco").ToString)
        txtbxCtaBancaria.Text = dr("CuentaBancaria").ToString
        lblMesesAmparados.Text = "Meses amparados con el pago: (Año " + lblAnio.Text + ")"
        ChBxPagarConChequeCheckedChanged()

        If dtMeses.Rows.Count = CInt(lblIdMes.Text) Then
            vlMesesAmparados = 1
        ElseIf dtMeses.Rows.Count < CInt(lblIdMes.Text) Then
            'vlMesesAmparados = (CInt(lblIdMes.Text) - dtMeses.Rows.Count) + 1
            vlMesesAmparados = (CInt(lblIdMes.Text) - CInt(dtMesesQueAmparaPago.Rows(0).Item("MesesQueAmparaPago"))) + CInt(dr("MesesQueAmparaPago"))
        Else
            vlMesesAmparados = 1
        End If

        'If CInt(dtMesesQueAmparaPago.Rows(0).Item("MesesQueAmparaPago")) = CInt(lblIdMes.Text) Then
        '    vlMesesAmparados = 1
        'ElseIf CInt(dtMesesQueAmparaPago.Rows(0).Item("MesesQueAmparaPago")) < CInt(lblIdMes.Text) Then
        '    vlMesesAmparados = (CInt(lblIdMes.Text) - CInt(dtMesesQueAmparaPago.Rows(0).Item("MesesQueAmparaPago"))) + 1
        'Else
        '    vlMesesAmparados = 1
        'End If

        ddlMesesAmp.Items.Clear()

        If lblTipoDeNomina.Text = "O" Then
            For vlIndice = 1 To vlMesesAmparados Step 1
                ddlMesesAmp.Items.Add(New ListItem(vlIndice.ToString, vlIndice.ToString))
            Next
        ElseIf lblTipoDeNomina.Text = "C" Then
            For vlIndice = 0 To vlMesesAmparados Step 1
                ddlMesesAmp.Items.Add(New ListItem(vlIndice.ToString, vlIndice.ToString))
            Next
        ElseIf lblTipoDeNomina.Text = "E" Then
            ddlMesesAmp.Items.Add(New ListItem("0", "0"))
        End If

        ddlMesesAmp.SelectedValue = dr("MesesQueAmparaPago").ToString

        txtbxObservs.Text = dr("Observaciones").ToString

        pnl5.Enabled = True

        MVMain.SetActiveView(VCCompen)
    End Sub

    Protected Sub btnCancelarFaltas_Click(sender As Object, e As System.EventArgs) Handles btnCancelarFaltas.Click
        gvHistoriaCompe.SelectedIndex = -1
        MVMain.SetActiveView(VABCCompen)
        SetVisibleBotones_wucBuscaEmps(True)
        pnlFaltasEd.Enabled = False
    End Sub

    Protected Sub btnCancelar1_Click(sender As Object, e As System.EventArgs) Handles btnCancelar1.Click
        gvHistoriaCompe.SelectedIndex = -1
        MVMain.SetActiveView(VABCCompen)
        SetVisibleBotones_wucBuscaEmps(True)
        pnl5.Enabled = False
    End Sub

    Protected Sub ChBxPagarConCheque_CheckedChanged(sender As Object, e As System.EventArgs) Handles ChBxPagarConCheque.CheckedChanged
        ChBxPagarConChequeCheckedChanged()
    End Sub

    Protected Sub ddlBancos_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlBancos.SelectedIndexChanged
        ddlBancosSelectedIndexChanged()
    End Sub

    Protected Sub btnGuardarModif_Click(sender As Object, e As System.EventArgs) Handles btnGuardarModif.Click
        Dim oCompen As New Compensacion
        Dim hfRFC As HiddenField = CType(WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        Dim vlRFCEmp As String
        Dim gvr As GridViewRow
        Dim lblAnio As New Label
        Dim lblIdMes As New Label
        Dim dr2 As DataRow
        Dim vlAnio As Short
        Dim vlIdMes As Byte
        Dim vlAdicionalNew As Byte
        Dim vlAdicionalAnt As Byte
        'Dim dtNumsAdic As DataTable

        vlRFCEmp = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))

        gvr = gvHistoriaCompe.SelectedRow

        If gvr Is Nothing Then
            dr2 = oCompen.PosiblesDatosParaNuevaCompe(vlRFCEmp, 0).Rows(0)
            vlAnio = CShort(dr2("Anio"))
            vlIdMes = CByte(dr2("IdMes"))
        End If

        'vlRFCEmp = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))

        If txtbxTipoOperacion.Text = "Captura" Then

            oCompen.InsertaRegistro(vlRFCEmp, "C1", CDec(txtbxImporte.Text), ChBxPagarConCheque.Checked,
                                txtbxClaveCobro.Text, CByte(ddlBancos.SelectedValue), txtbxCtaBancaria.Text, "",
                                "", "", txtbxObservs.Text, CByte(ddlMesesAmp.SelectedValue),
                                "", "", vlAnio, vlIdMes, CByte(ddlNumeroDeNominas.SelectedValue), CType(Session("ArregloAuditoria"), String()))

        ElseIf txtbxTipoOperacion.Text = "Actualización" Then
            lblAnio = CType(gvr.FindControl("lblAnio"), Label)
            lblIdMes = CType(gvr.FindControl("lblIdMes"), Label)
            lblAdicional = CType(gvr.FindControl("lblAdicional"), Label)

            vlAnio = CShort(lblAnio.Text)
            vlIdMes = CByte(lblIdMes.Text)
            vlAdicionalAnt = CByte(lblAdicional.Text)
            vlAdicionalNew = CByte(ddlNumeroDeNominas.SelectedValue)

            oCompen.ActualizaRegistro(0, "C1", CDec(txtbxImporte.Text), ChBxPagarConCheque.Checked,
                    txtbxClaveCobro.Text, CByte(ddlBancos.SelectedValue), txtbxCtaBancaria.Text, "",
                    "", "", txtbxObservs.Text, CByte(ddlMesesAmp.SelectedValue),
                    "", "", vlRFCEmp, vlAnio, vlIdMes, vlAdicionalNew, vlAdicionalAnt,
                    CType(Session("ArregloAuditoria"), String()))
        End If

        btnCancelar1_Click(sender, e)
        btnConsultar_Click(sender, e)
    End Sub

    Protected Sub lnAgregarFalta_Click(sender As Object, e As System.EventArgs)
        Dim gvr As GridViewRow = CType(CType(sender, ImageButton).NamingContainer, GridViewRow)

        Dim lblAnio As Label = CType(gvr.FindControl("lblAnio"), Label)
        Dim lblIdMes As Label = CType(gvr.FindControl("lblIdMes"), Label)
        Dim lblAdicional As Label = CType(gvr.FindControl("lblAdicional"), Label)
        Dim lblImportePANatural As Label = CType(gvr.FindControl("lblImportePANatural"), Label)
        Dim lblImporteNatural As Label = CType(gvr.FindControl("lblImporteNatural"), Label)
        Dim lblImporteFaltaNatural As Label = CType(gvr.FindControl("lblImporteFaltaNatural"), Label)
        Dim lblImporteFaltaPANatural As Label = CType(gvr.FindControl("lblImporteFaltaPANatural"), Label)
        Dim lblDiasFalta As Label = CType(gvr.FindControl("lblDiasFalta"), Label)

        gvHistoriaCompe2.SelectedIndex = gvr.RowIndex

        SetVisibleBotones_wucBuscaEmps(False)
        pnlFaltasEd.GroupingText = "Registro de Faltas"
        lblAñoFalta.Text = lblAnio.Text
        lblMesFalta.Text = lblIdMes.Text
        lblAdicionalFalta.Text = lblAdicional.Text
        hidImporteCompeFalta.Value = (CDec(lblImporteNatural.Text) + CDec(lblImportePANatural.Text) + CDec(lblImporteFaltaNatural.Text))
        hidImportePAFalta.Value = (CDec(lblImportePANatural.Text) + CDec(lblImporteFaltaPANatural.Text))

        'PA
        vldCprCompeFaltaPA1.Enabled = True
        vldCprCompeFaltaPA2.Enabled = True
        vldReqCompeFaltaPA1.Enabled = True
        txtbxImportePAFalta.Enabled = True
        If (CDec(lblImportePANatural.Text) = 0) Or (CDec(lblDiasFalta.Text) = 0) Then
            vldCprCompeFaltaPA1.Enabled = False
            vldCprCompeFaltaPA2.Enabled = False
            vldReqCompeFaltaPA1.Enabled = False
            txtbxImportePAFalta.Enabled = False
        End If

        txtbxImporteCompeFalta.Text = lblImporteFaltaNatural.Text
        txtbxImportePAFalta.Text = lblImporteFaltaPANatural.Text
        txtDiasFaltas.Text = lblDiasFalta.Text

        txtObservacionesFaltas.Text = String.Empty

        pnlFaltasEd.Enabled = True

        MVMain.SetActiveView(vwFaltas)
    End Sub

    Protected Sub btnGuardarModifFaltas_Click(sender As Object, e As System.EventArgs) Handles btnGuardarModifFaltas.Click
        Dim oCompen As New Compensacion
        Dim hfRFC As HiddenField = CType(WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        Dim vlRFCEmp As String
        Dim lblAnio As New Label
        Dim lblIdMes As New Label
        Dim vlAnio As Short
        Dim vlIdMes As Byte
        Dim vlAdicional As Byte
        Dim vlTipoMovimiento As Byte
        Dim vlDias As Byte
        Dim vlImporte As Decimal
        Dim vlImportePA As Decimal
        'Dim dtNumsAdic As DataTable

        vlRFCEmp = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))

        vlAnio = CShort(lblAñoFalta.Text)
        vlIdMes = CByte(lblMesFalta.Text)
        vlAdicional = CByte(lblAdicionalFalta.Text)
        vlImporte = CDec(txtbxImporteCompeFalta.Text)
        vlImportePA = CDec(txtbxImportePAFalta.Text)
        vlTipoMovimiento = CByte(ddlTipoMovimiento.SelectedValue)
        vlDias = CDec(txtDiasFaltas.Text)


        oCompen.IoURegistroFaltas(vlRFCEmp, vlAnio, vlIdMes,
                    vlAdicional, vlImporte, vlImportePA, vlDias, txtObservacionesFaltas.Text,
                    vlTipoMovimiento, CType(Session("ArregloAuditoria"), String()))

        btnCancelar1_Click(sender, e)
        btnConsultar_Click(sender, e)
    End Sub

    Protected Sub ibEliminar_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs)
        Dim gvr As GridViewRow = CType(CType(sender, ImageButton).NamingContainer, GridViewRow)
        Dim vlRFCEmp As String
        Dim hfRFC As HiddenField = CType(WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        Dim oCompen As New Compensacion
        Dim lblAnio As Label = CType(gvr.FindControl("lblAnio"), Label)
        Dim lblIdMes As Label = CType(gvr.FindControl("lblIdMes"), Label)
        Dim lblAdicional As Label = CType(gvr.FindControl("lblAdicional"), Label)
        Dim lblOrigen As Label = CType(gvr.FindControl("lblOrigen"), Label)
        Dim lblTipoDeNomina As Label = CType(gvr.FindControl("lblTipoDeNomina"), Label)
        'Dim dtNumsAdic As DataTable

        vlRFCEmp = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))

        oCompen.EliminaRegistroC1(vlRFCEmp, CShort(lblAnio.Text), CByte(lblIdMes.Text), CByte(lblAdicional.Text), lblOrigen.Text, CType(Session("ArregloAuditoria"), String()))

        btnConsultar_Click(sender, e)
        'dtNumsAdic = oCompen.ObtenNumsDeAdic(vlRFCEmp, CShort(lblAnio.Text), "C1")
        'lbAddCompen.Visible = dtNumsAdic.Rows.Count > 0
    End Sub

    Protected Sub gvHistoriaCompe2_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvHistoriaCompe2.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                Dim ibModificar As ImageButton = CType(e.Row.FindControl("ibModificar"), ImageButton)
                Dim ibEliminar As ImageButton = CType(e.Row.FindControl("ibEliminar"), ImageButton)
                Dim lblPermiteCambios As Label = CType(e.Row.FindControl("lblPermiteCambios"), Label)

                If lblPermiteCambios.Text = "N" Then
                    ibModificar.Enabled = False
                    ibModificar.ImageUrl = "~/Imagenes/ModificarDisabled.jpg"
                    ibModificar.ToolTip = "(Opción deshabilitada)"
                    ibEliminar.Enabled = False
                    ibEliminar.ImageUrl = "~/Imagenes/EliminarDisabled.jpg"
                    ibEliminar.ToolTip = "(Opción deshabilitada)"
                Else
                    ibModificar.Enabled = True
                    ibModificar.ImageUrl = "~/Imagenes/Modificar.png"
                    ibModificar.ToolTip = "Modificar la información del registro."
                    ibEliminar.Enabled = True
                    ibEliminar.ImageUrl = "~/Imagenes/Eliminar.png"
                    ibEliminar.ToolTip = "Eliminar registro."
                End If

                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End Select
    End Sub

    Protected Sub ibModificar_Click1(sender As Object, e As System.Web.UI.ImageClickEventArgs)
        Dim gvr As GridViewRow = CType(CType(sender, ImageButton).NamingContainer, GridViewRow)
        ModificarBPA(gvr)
    End Sub

    Protected Sub ibEliminar_Click1(sender As Object, e As System.Web.UI.ImageClickEventArgs)
        Dim gvr As GridViewRow = CType(CType(sender, ImageButton).NamingContainer, GridViewRow)
        Dim oCompen As New Compensacion
        Dim lblClaveCobro As Label = CType(gvBPA.SelectedRow.FindControl("lblClaveCobro"), Label)
        Dim lblAnio As Label = CType(gvr.FindControl("lblAnio"), Label)
        Dim lblIdMes As Label = CType(gvr.FindControl("lblIdMes"), Label)
        Dim lblAdicional As Label = CType(gvr.FindControl("lblAdicional"), Label)
        Dim lblOrigen As Label = CType(gvr.FindControl("lblOrigen"), Label)

        oCompen.EliminaRegistroC2(lblClaveCobro.Text, CShort(lblAnio.Text), CByte(lblIdMes.Text), CByte(lblAdicional.Text), lblOrigen.Text, CType(Session("ArregloAuditoria"), String()))

        BindgvHistoriaCompe2(lblClaveCobro.Text)

        If gvHistoriaCompe2.Rows.Count = 0 Then
            btnConsultar_Click(sender, e)
        End If
    End Sub
    Protected Sub lbAddCompen_Click(sender As Object, e As System.EventArgs) Handles lbAddCompen.Click
        Dim vlRFCEmp As String
        Dim hfRFC As HiddenField = CType(WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        Dim oCompensacion As New Compensacion
        Dim dr2 As DataRow
        Dim ds As DataSet
        Dim dtMeses As DataTable
        Dim dtNumsAdic As DataTable
        Dim lblIdMes As New Label
        Dim lblTipoDeNomina As New Label
        Dim vlMesesAmparados As Byte
        Dim vlAnio As Short
        Dim dtMesesQueAmparaPago As DataTable

        vlRFCEmp = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))

        dr2 = oCompensacion.PosiblesDatosParaNuevaCompe(vlRFCEmp, 0).Rows(0)

        If ddlAnios.SelectedValue <> "-1" Then
            vlAnio = CShort(ddlAnios.SelectedValue)
        Else
            vlAnio = CShort(dr2("Anio"))
        End If

        ds = oCompensacion.ObtenAcumuladoPorEmp2(vlRFCEmp, vlAnio)
        dtNumsAdic = oCompensacion.ObtenNumsDeAdic(vlRFCEmp, vlAnio, "C1")
        dtMeses = ds.Tables(2)
        dtMesesQueAmparaPago = ds.Tables(3)

        lblIdMes.Text = dr2("IdMes").ToString

        SetVisibleBotones_wucBuscaEmps(False)
        pnl5.GroupingText = "Asignar gratificación extraordinaria al empleado"
        txtbxTipoOperacion.Text = "Captura"
        LlenaDDL(ddlNumeroDeNominas, "AdicionalDescripcion", "Adicional", dtNumsAdic, Nothing)
        txtbxImporte.Text = dr2("Importe").ToString
        txtbxClaveCobro.Text = dr2("ClaveCobro").ToString
        ChBxPagarConCheque.Checked = CBool(dr2("PagarConCheque"))
        BindddlBancos(ddlBancos, dr2("IdBanco").ToString)
        txtbxCtaBancaria.Text = dr2("CuentaBancaria").ToString
        lblMesesAmparados.Text = "Meses amparados con el pago: (Año " + vlAnio.ToString + ")"
        ChBxPagarConChequeCheckedChanged()

        If dtMeses.Rows.Count = CInt(lblIdMes.Text) Then
            vlMesesAmparados = 1
        ElseIf dtMeses.Rows.Count < CInt(lblIdMes.Text) Then
            'vlMesesAmparados = CInt(lblIdMes.Text) - dtMeses.Rows.Count
            vlMesesAmparados = (CInt(lblIdMes.Text) - CInt(dtMesesQueAmparaPago.Rows(0).Item("MesesQueAmparaPago")))
        Else
            vlMesesAmparados = 1
        End If

        ddlMesesAmp.Items.Clear()

        lblTipoDeNomina.Text = dtNumsAdic.Rows(0).Item("TipoDeNomina").ToString

        If lblTipoDeNomina.Text = "O" Then
            For vlIndice = 1 To vlMesesAmparados Step 1
                ddlMesesAmp.Items.Add(New ListItem(vlIndice.ToString, vlIndice.ToString))
            Next
        ElseIf lblTipoDeNomina.Text = "C" Then
            For vlIndice = 0 To vlMesesAmparados Step 1
                ddlMesesAmp.Items.Add(New ListItem(vlIndice.ToString, vlIndice.ToString))
            Next
        ElseIf lblTipoDeNomina.Text = "E" Then
            ddlMesesAmp.Items.Add(New ListItem("0", "0"))
        End If

        txtbxObservs.Text = String.Empty

        pnl5.Enabled = True

        MVMain.SetActiveView(VCCompen)
    End Sub

    Protected Sub ddlNumeroDeNominas_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlNumeroDeNominas.SelectedIndexChanged
        If txtbxTipoOperacion.Text = "Captura" Then
            BindddlMesesAmp()
        End If
    End Sub

    Protected Sub btnCancelarBPA_Click(sender As Object, e As System.EventArgs) Handles btnCancelarBPA.Click
        gvHistoriaCompe2.SelectedIndex = -1
        MVMain.SetActiveView(VABCCompen)
        SetVisibleBotones_wucBuscaEmps(True)
        pnl6.Enabled = False
    End Sub

    Protected Sub lbAddBPA_Click(sender As Object, e As System.EventArgs) Handles lbAddBPA.Click
        'Dim vlRFCEmp As String
        'Dim hfRFC As HiddenField = CType(WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        Dim oCompensacion As New Compensacion
        Dim dr2 As DataRow
        Dim ds As DataSet
        Dim dtMeses As DataTable
        Dim dtNumsAdic As DataTable
        Dim lblIdMes As New Label
        Dim lblTipoDeNomina As New Label
        Dim vlMesesAmparados As Byte
        Dim vlAnio As Short
        Dim dtMesesQueAmparaPago As DataTable
        Dim vlClaveCobro As String
        Dim vlAdicional As Byte
        Dim vlIdMes As Byte

        'vlRFCEmp = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))

        dr2 = oCompensacion.PosiblesDatosParaNuevaCompe(String.Empty, 0).Rows(0)

        'If ddlAnios.SelectedValue <> "-1" Then
        '    vlAnio = CShort(ddlAnios.SelectedValue)
        'Else

        'End If

        vlClaveCobro = dr2("ClaveCobro").ToString
        vlAnio = CShort(dr2("Anio"))
        vlIdMes = CByte(dr2("IdMes"))
        vlAdicional = CByte(dr2("Adicional"))

        ds = oCompensacion.ObtenAcumuladoPorEmp3(vlClaveCobro, vlAnio)
        dtNumsAdic = oCompensacion.ObtenNumsDeAdicC2(vlClaveCobro, vlAnio, vlIdMes, vlAdicional, "C2")
        dtMeses = ds.Tables(1)
        dtMesesQueAmparaPago = ds.Tables(2)

        lblIdMes.Text = dr2("IdMes").ToString

        SetVisibleBotones_wucBuscaEmps(False)
        pnl6.GroupingText = "Captura de un nuevo beneficiario y asignación de importe de pensión alimenticia"
        txtbxTipoOperacionBPA.Text = "Captura"
        txtbxApePatBPA.Text = String.Empty
        txtbxApeMatBPA.Text = String.Empty
        txtbxNombreBPA.Text = String.Empty
        LlenaDDL(ddlNumeroDeNominasBPA, "AdicionalDescripcion", "Adicional", dtNumsAdic, Nothing)
        txtbxImportePA.Text = dr2("Importe").ToString
        txtbxClaveCobroBPA.Text = dr2("ClaveCobro").ToString
        txtbxClaveCobroBPA.Enabled = True
        ChBxPagarConChequeBPA.Checked = CBool(dr2("PagarConCheque"))
        BindddlBancos(ddlBancosBPA, dr2("IdBanco").ToString)
        txtbxCtaBancariaBPA.Text = dr2("CuentaBancaria").ToString
        lblMesesAmparadosBPA.Text = "Meses amparados con el pago: (Año " + vlAnio.ToString + ")"
        ChBxPagarConChequeBPACheckedChanged()

        If dtMeses.Rows.Count = CInt(lblIdMes.Text) Then
            vlMesesAmparados = 1
        ElseIf dtMeses.Rows.Count < CInt(lblIdMes.Text) Then
            'vlMesesAmparados = CInt(lblIdMes.Text) - dtMeses.Rows.Count
            vlMesesAmparados = (CInt(lblIdMes.Text) - CInt(dtMesesQueAmparaPago.Rows(0).Item("MesesQueAmparaPago")))
        Else
            vlMesesAmparados = 1
        End If

        ddlMesesAmpBPA.Items.Clear()

        lblTipoDeNomina.Text = dtNumsAdic.Rows(0).Item("TipoDeNomina").ToString

        If lblTipoDeNomina.Text = "O" Then
            For vlIndice = 1 To vlMesesAmparados Step 1
                ddlMesesAmpBPA.Items.Add(New ListItem(vlIndice.ToString, vlIndice.ToString))
            Next
        ElseIf lblTipoDeNomina.Text = "C" Then
            For vlIndice = 0 To vlMesesAmparados Step 1
                ddlMesesAmpBPA.Items.Add(New ListItem(vlIndice.ToString, vlIndice.ToString))
            Next
        ElseIf lblTipoDeNomina.Text = "E" Then
            ddlMesesAmpBPA.Items.Add(New ListItem("0", "0"))
        End If

        txtbxObservsBPA.Text = String.Empty

        pnl6.Enabled = True

        MVMain.SetActiveView(VCBPA)
    End Sub

    Protected Sub ChBxPagarConChequeBPA_CheckedChanged(sender As Object, e As System.EventArgs) Handles ChBxPagarConChequeBPA.CheckedChanged
        ChBxPagarConChequeBPACheckedChanged()
    End Sub

    Protected Sub ddlBancosBPA_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlBancosBPA.SelectedIndexChanged
        ddlBancosBPASelectedIndexChanged()
    End Sub

    Protected Sub lbAddCompenBPA_Click(sender As Object, e As System.EventArgs) Handles lbAddCompenBPA.Click
        Dim oCompensacion As New Compensacion
        Dim lblIdMes As New Label
        Dim lblTipoDeNomina As New Label
        Dim lblApePatBPA As Label = CType(gvBPA.SelectedRow.FindControl("lblApePatBPA"), Label)
        Dim lblApeMatBPA As Label = CType(gvBPA.SelectedRow.FindControl("lblApeMatBPA"), Label)
        Dim lblNombreBPA As Label = CType(gvBPA.SelectedRow.FindControl("lblNombreBPA"), Label)
        Dim dr2 As DataRow
        Dim ds As DataSet
        Dim dtMeses As DataTable
        Dim vlMesesAmparados As Byte
        Dim vlIndice As Byte
        Dim dtNumsAdic As DataTable
        Dim dtMesesQueAmparaPago As DataTable
        Dim lblClaveCobro As Label = CType(gvBPA.SelectedRow.FindControl("lblClaveCobro"), Label)
        Dim vlAnio As Short
        Dim vlClaveCobro As String = lblClaveCobro.Text

        dr2 = oCompensacion.PosiblesDatosParaNuevaCompe(vlClaveCobro).Rows(0)

        If ddlAnios.SelectedValue <> "-1" Then
            vlAnio = CShort(ddlAnios.SelectedValue)
        Else
            vlAnio = CShort(dr2("Anio"))
        End If

        ds = oCompensacion.ObtenAcumuladoPorEmp3(vlClaveCobro, vlAnio)
        dtNumsAdic = oCompensacion.ObtenNumsDeAdicC2(vlClaveCobro, vlAnio, "C2")

        dtMeses = ds.Tables(1)
        dtMesesQueAmparaPago = ds.Tables(2)

        lblIdMes.Text = dr2("IdMes").ToString

        SetVisibleBotones_wucBuscaEmps(False)
        pnl6.GroupingText = "Asignación de nuevo importe de pensión alimenticia"
        txtbxTipoOperacionBPA.Text = "Captura"
        txtbxApePatBPA.Text = lblApePatBPA.Text
        txtbxApeMatBPA.Text = lblApeMatBPA.Text
        txtbxNombreBPA.Text = lblNombreBPA.Text
        LlenaDDL(ddlNumeroDeNominasBPA, "AdicionalDescripcion", "Adicional", dtNumsAdic, Nothing)
        txtbxImportePA.Text = dr2("Importe").ToString
        txtbxClaveCobroBPA.Text = dr2("ClaveCobro").ToString
        ChBxPagarConChequeBPA.Checked = CBool(dr2("PagarConCheque"))
        BindddlBancos(ddlBancosBPA, dr2("IdBanco").ToString)
        txtbxCtaBancariaBPA.Text = dr2("CuentaBancaria").ToString
        lblMesesAmparadosBPA.Text = "Meses amparados con el pago: (Año " + vlAnio.ToString + ")"
        ChBxPagarConChequeBPACheckedChanged()

        If dtMeses.Rows.Count = CInt(lblIdMes.Text) Then
            vlMesesAmparados = 1
        ElseIf dtMeses.Rows.Count < CInt(lblIdMes.Text) Then
            vlMesesAmparados = (CInt(lblIdMes.Text) - CInt(dtMesesQueAmparaPago.Rows(0).Item("MesesQueAmparaPago")))
        Else
            vlMesesAmparados = 1
        End If

        ddlMesesAmpBPA.Items.Clear()

        lblTipoDeNomina.Text = dtNumsAdic.Rows(0).Item("TipoDeNomina").ToString

        If lblTipoDeNomina.Text = "O" Then
            For vlIndice = 1 To vlMesesAmparados Step 1
                ddlMesesAmpBPA.Items.Add(New ListItem(vlIndice.ToString, vlIndice.ToString))
            Next
        ElseIf lblTipoDeNomina.Text = "C" Then
            For vlIndice = 0 To vlMesesAmparados Step 1
                ddlMesesAmpBPA.Items.Add(New ListItem(vlIndice.ToString, vlIndice.ToString))
            Next
        ElseIf lblTipoDeNomina.Text = "E" Then
            ddlMesesAmpBPA.Items.Add(New ListItem("0", "0"))
        End If

        txtbxObservsBPA.Text = String.Empty

        pnl6.Enabled = True

        MVMain.SetActiveView(VCBPA)
    End Sub

    Protected Sub btnGuardarModifBPA_Click(sender As Object, e As System.EventArgs) Handles btnGuardarModifBPA.Click
        Dim oCompen As New Compensacion
        Dim hfNumEmp As HiddenField = CType(WucBuscaEmpleados1.FindControl("hfNumEmp"), HiddenField)
        Dim vlNumEmp As String
        Dim gvr As GridViewRow
        Dim lblAnio As New Label
        Dim lblIdMes As New Label
        Dim dr2 As DataRow
        Dim vlAnio As Short
        Dim vlIdMes As Byte
        Dim vlAdicionalNew As Byte
        Dim vlAdicionalAnt As Byte
        Dim vlClaveCobro As String
        Dim lblClaveCobro As Label = Nothing

        vlNumEmp = IIf(Session("NumEmpParaCons") Is Nothing, hfNumEmp.Value.Trim, Session("NumEmpParaCons"))

        vlClaveCobro = txtbxClaveCobroBPA.Text

        gvr = gvHistoriaCompe2.SelectedRow

        If gvr Is Nothing Then
            dr2 = oCompen.PosiblesDatosParaNuevaCompe(vlClaveCobro, 0).Rows(0)
            vlAnio = CShort(dr2("Anio"))
            vlIdMes = CByte(dr2("IdMes"))
        End If

        If txtbxTipoOperacionBPA.Text = "Captura" Then

            oCompen.InsertaRegistro("", "C2", CDec(txtbxImportePA.Text), ChBxPagarConChequeBPA.Checked, _
                                txtbxClaveCobroBPA.Text, CByte(ddlBancosBPA.SelectedValue), txtbxCtaBancariaBPA.Text, _
                                txtbxApePatBPA.Text.Trim.ToUpper, txtbxApeMatBPA.Text.Trim.ToUpper, txtbxNombreBPA.Text.Trim.ToUpper, _
                                txtbxObservsBPA.Text, CByte(ddlMesesAmpBPA.SelectedValue), _
                                "", vlNumEmp, vlAnio, vlIdMes, CByte(ddlNumeroDeNominasBPA.SelectedValue), _
                                CType(Session("ArregloAuditoria"), String()))

        ElseIf txtbxTipoOperacionBPA.Text = "Actualización" Then
            lblAnio = CType(gvr.FindControl("lblAnio"), Label)
            lblIdMes = CType(gvr.FindControl("lblIdMes"), Label)
            lblAdicional = CType(gvr.FindControl("lblAdicional"), Label)

            vlAnio = CShort(lblAnio.Text)
            vlIdMes = CByte(lblIdMes.Text)
            vlAdicionalAnt = CByte(lblAdicional.Text)
            vlAdicionalNew = CByte(ddlNumeroDeNominasBPA.SelectedValue)

            oCompen.ActualizaRegistro(0, "C2", CDec(txtbxImportePA.Text), ChBxPagarConChequeBPA.Checked, _
                    txtbxClaveCobroBPA.Text, CByte(ddlBancosBPA.SelectedValue), txtbxCtaBancariaBPA.Text, _
                    txtbxApePatBPA.Text.Trim.ToUpper, txtbxApeMatBPA.Text.Trim.ToUpper, txtbxNombreBPA.Text.Trim.ToUpper, _
                    txtbxObservsBPA.Text, CByte(ddlMesesAmpBPA.SelectedValue), _
                    "", vlNumEmp, "", vlAnio, vlIdMes, vlAdicionalNew, vlAdicionalAnt, _
                    CType(Session("ArregloAuditoria"), String()))
        End If

        btnCancelarBPA_Click(sender, e)
        BindgvHistoriaCompe()
        'BindgvHistoriaCompe2(txtbxClaveCobroBPA.Text)

        For Each gvr In gvBPA.Rows
            lblClaveCobro = CType(gvr.FindControl("lblClaveCobro"), Label)
            If lblClaveCobro.Text = txtbxClaveCobroBPA.Text Then
                gvBPA.SelectedIndex = gvr.RowIndex
                ibDetalleBPAClick(gvr)
                Exit For
            End If
        Next
    End Sub

    Protected Sub ddlNumeroDeNominasBPA_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlNumeroDeNominasBPA.SelectedIndexChanged
        If txtbxTipoOperacionBPA.Text = "Captura" Then
            BindddlMesesAmp()
        End If
    End Sub

    Protected Sub txtDiasFaltas_TextChanged(sender As Object, e As EventArgs) Handles txtDiasFaltas.TextChanged

        Dim vlImporteCompe As Decimal
        Dim vlImportePA As Decimal

        vlImporteCompe = CDec(hidImporteCompeFalta.Value)
        vlImportePA = CDec(hidImportePAFalta.Value)

        'Compe
        vldCprCompeFalta1.Enabled = True
        vldCprCompeFalta2.Enabled = True
        vldReqCompeFalta1.Enabled = True
        txtbxImporteCompeFalta.Enabled = True
        If (CDec(txtDiasFaltas.Text) = 0) Then
            vldCprCompeFalta1.Enabled = False
            vldCprCompeFalta2.Enabled = False
            vldReqCompeFalta1.Enabled = False
            txtbxImporteCompeFalta.Enabled = False

            If (CDec(hidImportePAFalta.Value) > 0) Then
                vldCprCompeFaltaPA1.Enabled = False
                vldCprCompeFaltaPA2.Enabled = False
                vldReqCompeFaltaPA1.Enabled = False
                txtbxImportePAFalta.Enabled = False
            End If
        Else
            If (CDec(hidImportePAFalta.Value) > 0) Then
                vldCprCompeFaltaPA1.Enabled = True
                vldCprCompeFaltaPA2.Enabled = True
                vldReqCompeFaltaPA1.Enabled = True
                txtbxImportePAFalta.Enabled = True
            End If
        End If

        Try
            txtbxImporteCompeFalta.Text = Math.Round(vlImporteCompe / 30 * CInt(txtDiasFaltas.Text), 2)
            txtbxImportePAFalta.Text = Math.Round(vlImportePA / 30 * CInt(txtDiasFaltas.Text), 2)
        Catch ex As Exception
            txtbxImporteCompeFalta.Text = "0"
            txtbxImportePAFalta.Text = "0"
        End Try

        'Días
        vldCprDiasFalta1.Enabled = True
        vldCprDiasFalta2.Enabled = True
        vldReqDiasFalta1.Enabled = True
        If (CDec(txtbxImporteCompeFalta.Text) = 0) Then
            vldCprDiasFalta1.Enabled = False
            vldCprDiasFalta2.Enabled = False
            vldReqDiasFalta1.Enabled = False
        End If

    End Sub
    Protected Sub txtbxImporteCompeFalta_TextChanged(sender As Object, e As EventArgs) Handles txtbxImporteCompeFalta.TextChanged


    End Sub
    Protected Sub ddlTipoMovimiento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlTipoMovimiento.SelectedIndexChanged
        If (ddlTipoMovimiento.SelectedValue = "1") Then
            lblImporteFalta.Text = "Importe del DESCUENTO por Faltas (Compensación)"
            lblImporteFaltaPA.Text = "Importe del DESCUENTO por Faltas (Pensión Alimenticia)"
            txtbxImporteCompeFalta.Enabled = True
            txtbxImportePAFalta.Enabled = True
            vldCprDiasFalta2.Enabled = True
            txtbxImporteCompeFalta.Text = ""
            txtbxImportePAFalta.Text = ""
            txtDiasFaltas.Text = 0
            vldCprDiasFalta2.Enabled = True
            vldCprCompeFalta2.Enabled = True
            If (CDec(hidImportePAFalta.Value) > 0) Then
                vldCprCompeFaltaPA2.Enabled = True
            End If
        ElseIf (ddlTipoMovimiento.SelectedValue = "3") Then
            txtbxImporteCompeFalta.Enabled = False
            txtbxImportePAFalta.Enabled = False
            txtDiasFaltas.Text = 0
            txtbxImporteCompeFalta.Text = 0
            txtbxImportePAFalta.Text = 0
            vldCprDiasFalta2.Enabled = False
            vldCprCompeFalta2.Enabled = False
            If (CDec(hidImportePAFalta.Value) > 0) Then
                vldCprCompeFaltaPA2.Enabled = False
            End If
        Else
            lblImporteFalta.Text = "Importe de la DEVOLUCIÓN por Faltas (Compensación)"
            lblImporteFaltaPA.Text = "Importe de la DEVOLUCIÓN por Faltas (Pensión Alimenticia)"
            lblImporteFalta.Enabled = True
            lblImporteFaltaPA.Enabled = True
            txtbxImporteCompeFalta.Text = ""
            txtbxImportePAFalta.Text = ""
            vldCprDiasFalta2.Enabled = True
            vldCprCompeFalta2.Enabled = True
            If (CDec(hidImportePAFalta.Value) > 0) Then
                vldCprCompeFaltaPA2.Enabled = True
            End If
        End If
    End Sub
End Class