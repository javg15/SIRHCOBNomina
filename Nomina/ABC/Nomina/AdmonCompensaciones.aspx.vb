Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.Administracion
Imports DataAccessLayer.COBAEV.InformacionAcademica
Imports DataAccessLayer.COBAEV
Imports System.Data
Imports DataAccessLayer.COBAEV.Empleados
Partial Class ABC_Nomina_AdmonCompensaciones
    Inherits System.Web.UI.Page
    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, ByVal dt As DataTable, ByVal SelectedValue As String)
        ddl.DataSource = dt
        ddl.DataTextField = TextField
        ddl.DataValueField = ValueField
        ddl.DataBind()
        If SelectedValue Is Nothing = False Then ddl.SelectedValue = SelectedValue
    End Sub
    Private Sub BindddlBancos(ByVal ddl As DropDownList, ByVal SelectedValue As String)
        Dim oBanco As New Bancos
        LlenaDDL(ddl, "NombreCortoBanco", "IdBanco", oBanco.ObtenTodos(), SelectedValue)
    End Sub
    Private Sub BinddvDatosNuevaCompe()
        Dim oCompe As New Compensacion
        Dim dt As DataTable
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        Dim ChBxPagarConCheque_EI_Aux As CheckBox = Nothing
        If Request.Params("TipoOperacion") = "1" Then
            If hfRFC.Value <> String.Empty And Request.Params("Extraordinario") Is Nothing Then
                dt = oCompe.PosiblesDatosParaNuevaCompe(hfRFC.Value, 0)
                If dt.Rows.Count > 0 Then
                    Me.dvDatosNuevaCompe.DataSource = dt
                End If
            ElseIf Request.Params("Extraordinario") Is Nothing = False Then
                Dim lblIdEmp As Label = Nothing
                If Me.dvDatosNuevaCompe.CurrentMode = DetailsViewMode.ReadOnly Then
                    lblIdEmp = CType(Me.dvDatosNuevaCompe.FindControl("lblIdEmp_RO"), Label)
                ElseIf Me.dvDatosNuevaCompe.CurrentMode = DetailsViewMode.Edit Then
                    lblIdEmp = CType(Me.dvDatosNuevaCompe.FindControl("lblIdEmp_EI"), Label)
                End If
                If CInt(lblIdEmp.Text) = 0 Then
                    dt = oCompe.PosiblesDatosParaNuevaCompe(String.Empty, 0)
                Else
                    dt = oCompe.PosiblesDatosParaNuevaCompe(String.Empty, CInt(lblIdEmp.Text))
                End If
                If dt.Rows.Count > 0 Then
                    Me.dvDatosNuevaCompe.DataSource = dt
                End If
            End If
        ElseIf Request.Params("TipoOperacion") = "0" Then
            dt = oCompe.ObtenParaModificacion(CInt(Request.Params("IdEmp")), Request.Params("Origen"))
            Me.dvDatosNuevaCompe.DataSource = dt
        End If
        If Me.dvDatosNuevaCompe.CurrentMode = DetailsViewMode.Edit Then
            ChBxPagarConCheque_EI_Aux = CType(Me.dvDatosNuevaCompe.FindControl("ChBxPagarConCheque_EI"), CheckBox)
        End If
        Me.dvDatosNuevaCompe.DataBind()
        If Me.dvDatosNuevaCompe.CurrentMode = DetailsViewMode.Edit Then
            Dim ChBxPagarConCheque_EI As CheckBox = CType(Me.dvDatosNuevaCompe.FindControl("ChBxPagarConCheque_EI"), CheckBox)
            ChBxPagarConCheque_EI.Checked = ChBxPagarConCheque_EI_Aux.Checked
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Response.Expires = 0
            If Request.Params("TipoOperacion") Is Nothing Then
                Response.Redirect("~/SinPermiso.aspx?Home=SI")
            End If
            'If Request.Params("Extraordinario") Is Nothing Then
            '    Dim txtbxRFC As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxRFC"), TextBox)
            '    Dim txtbxNomEmp As TextBox = CType(Me.WucBuscaEmpleados1.FindControl("txtbxNomEmp"), TextBox)
            '    Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
            '    Dim hfNomEmp As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfNomEmp"), HiddenField)
            '    Dim ibBuscarEmp As ImageButton = CType(Me.WucBuscaEmpleados1.FindControl("ibBuscarEmp"), ImageButton)
            '    ibBuscarEmp.Attributes.Add("onclick", "javascript:abreVentanaBuscaEmpsDesdeWebForms('../../Busquedas/Empleados.aspx?LlamadoDesde=AdmonCompensaciones','" + txtbxRFC.ClientID + "','" + txtbxNomEmp.ClientID + "','" + hfRFC.ClientID + "','" + hfNomEmp.ClientID + "');")
            'End If
            If Request.Params("TipoOperacion") = "1" Then
                Dim oCompe As New Compensacion
                Dim dt As DataTable
                If Request.Params("Extraordinario") Is Nothing = False Then
                    Me.WucBuscaEmpleados1.Visible = False
                    dt = oCompe.PosiblesDatosParaNuevaCompe(String.Empty, 0)
                    If dt.Rows.Count > 0 Then
                        Me.dvDatosNuevaCompe.DataSource = dt
                    End If
                    Me.dvDatosNuevaCompe.DataBind()
                End If
                Me.dvDatosNuevaCompe.HeaderText = "Nueva compensación extraordinaria"
                Me.dvDatosNuevaCompe.Fields(1).Visible = True
                Me.dvDatosNuevaCompe.Fields(2).Visible = True
                Me.dvDatosNuevaCompe.Fields(3).Visible = True
                Me.dvDatosNuevaCompe.Fields(12).Visible = True
            End If
        End If
    End Sub
    Protected Sub btnModificar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'System.Threading.Thread.Sleep(1000)
        Dim oCompe As New Compensacion
        Dim dt As DataTable
        If Request.Params("TipoOperacion") = "1" Then
            Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
            If hfRFC.Value <> String.Empty And Request.Params("Extraordinario") Is Nothing Then
                dt = oCompe.PosiblesDatosParaNuevaCompe(hfRFC.Value, 0)
                If dt.Rows.Count > 0 Then
                    Me.dvDatosNuevaCompe.ChangeMode(DetailsViewMode.Edit)
                    Me.dvDatosNuevaCompe.DataSource = dt
                End If
                Me.dvDatosNuevaCompe.DataBind()
            ElseIf Request.Params("Extraordinario") Is Nothing = False Then
                Dim lblIdEmp As Label = Nothing
                lblIdEmp = CType(Me.dvDatosNuevaCompe.FindControl("lblIdEmp_RO"), Label)
                If CInt(lblIdEmp.Text) = 0 Then
                    dt = oCompe.PosiblesDatosParaNuevaCompe(String.Empty, 0)
                Else
                    dt = oCompe.PosiblesDatosParaNuevaCompe(String.Empty, CInt(lblIdEmp.Text))
                End If
                If dt.Rows.Count > 0 Then
                    Me.dvDatosNuevaCompe.ChangeMode(DetailsViewMode.Edit)
                    Me.dvDatosNuevaCompe.DataSource = dt
                End If
                Me.dvDatosNuevaCompe.DataBind()
                If dt.Rows.Count > 0 Then
                    Dim RFVNombre As RequiredFieldValidator = CType(Me.dvDatosNuevaCompe.FindControl("RFVNombre"), RequiredFieldValidator)
                    Dim RFVApePat As RequiredFieldValidator = CType(Me.dvDatosNuevaCompe.FindControl("RFVApePat"), RequiredFieldValidator)
                    RFVNombre.Enabled = True
                    RFVApePat.Enabled = True
                    CType(Me.dvDatosNuevaCompe.FindControl("txtbxNombre_EI"), TextBox).ReadOnly = False
                    CType(Me.dvDatosNuevaCompe.FindControl("txtbxApePat_EI"), TextBox).ReadOnly = False
                    CType(Me.dvDatosNuevaCompe.FindControl("txtbxApeMat_EI"), TextBox).ReadOnly = False
                    CType(Me.dvDatosNuevaCompe.FindControl("txtbxNumEmpOficial_EI"), TextBox).ReadOnly = False
                    CType(Me.dvDatosNuevaCompe.FindControl("btnValidarNumEmpOficial"), Button).Enabled = False
                    CType(Me.dvDatosNuevaCompe.FindControl("txtbxNumEmpAfectado_EI"), TextBox).ReadOnly = False
                    CType(Me.dvDatosNuevaCompe.FindControl("btnValidarNumEmpAfectado"), Button).Enabled = False
                    'CType(Me.dvDatosNuevaCompe.FindControl("txtbxObservaciones_EI"), TextBox).ReadOnly = False
                End If
            End If
        ElseIf Request.Params("TipoOperacion") = "0" Then
            dt = oCompe.ObtenParaModificacion(CInt(Request.Params("IdEmp")), Request.Params("Origen"))
            Me.dvDatosNuevaCompe.ChangeMode(DetailsViewMode.Edit)
            Me.dvDatosNuevaCompe.DataSource = dt
            Me.dvDatosNuevaCompe.DataBind()
        End If
        CType(Me.WucBuscaEmpleados1.FindControl("BtnNewSearch"), Button).Enabled = False
    End Sub

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'System.Threading.Thread.Sleep(1000)
        Dim oCompe As New Compensacion
        Dim dt As DataTable
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        If Request.Params("TipoOperacion") = "1" Then
            If hfRFC.Value <> String.Empty And Request.Params("Extraordinario") Is Nothing Then
                dt = oCompe.PosiblesDatosParaNuevaCompe(hfRFC.Value, 0)
                If dt.Rows.Count > 0 Then
                    Me.dvDatosNuevaCompe.ChangeMode(DetailsViewMode.ReadOnly)
                    Me.dvDatosNuevaCompe.DataSource = dt
                End If
            ElseIf Request.Params("Extraordinario") Is Nothing = False Then
                Dim lblIdEmp As Label = Nothing
                lblIdEmp = CType(Me.dvDatosNuevaCompe.FindControl("lblIdEmp_EI"), Label)
                If CInt(lblIdEmp.Text) = 0 Then
                    dt = oCompe.PosiblesDatosParaNuevaCompe(String.Empty, 0)
                Else
                    dt = oCompe.PosiblesDatosParaNuevaCompe(String.Empty, CInt(lblIdEmp.Text))
                End If
                If dt.Rows.Count > 0 Then
                    Me.dvDatosNuevaCompe.ChangeMode(DetailsViewMode.ReadOnly)
                    Me.dvDatosNuevaCompe.DataSource = dt
                End If
            End If
            Me.dvDatosNuevaCompe.DataBind()
        ElseIf Request.Params("TipoOperacion") = "0" Then
            dt = oCompe.ObtenParaModificacion(CInt(Request.Params("IdEmp")), Request.Params("Origen"))
            Me.dvDatosNuevaCompe.ChangeMode(DetailsViewMode.ReadOnly)
            Me.dvDatosNuevaCompe.DataSource = dt
            Me.dvDatosNuevaCompe.DataBind()
        End If
        CType(Me.WucBuscaEmpleados1.FindControl("BtnNewSearch"), Button).Enabled = True
    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'System.Threading.Thread.Sleep(1000)
        Dim oCompe As New Compensacion
        Dim hfRFC As HiddenField = CType(Me.WucBuscaEmpleados1.FindControl("hfRFC"), HiddenField)
        Dim lblOrigen_EI As Label = CType(Me.dvDatosNuevaCompe.FindControl("lblOrigen_EI"), Label)
        Dim tbImporte_E As TextBox = CType(Me.dvDatosNuevaCompe.FindControl("tbImporte_E"), TextBox)
        Dim ChBxPagarConCheque_EI As CheckBox = CType(Me.dvDatosNuevaCompe.FindControl("ChBxPagarConCheque_EI"), CheckBox)
        Dim tbClaveCobro_EI As TextBox = CType(Me.dvDatosNuevaCompe.FindControl("tbClaveCobro_EI"), TextBox)
        Dim ddlBancos_EI As DropDownList = CType(Me.dvDatosNuevaCompe.FindControl("ddlBancos_EI"), DropDownList)
        Dim tbCuentaBancaria_EI As TextBox = CType(Me.dvDatosNuevaCompe.FindControl("tbCuentaBancaria_EI"), TextBox)
        Dim lblIdEmp_EI As Label = CType(Me.dvDatosNuevaCompe.FindControl("lblIdEmp_EI"), Label)
        Dim txtbxNombre_EI As TextBox = CType(Me.dvDatosNuevaCompe.FindControl("txtbxNombre_EI"), TextBox)
        Dim txtbxApePat_EI As TextBox = CType(Me.dvDatosNuevaCompe.FindControl("txtbxApePat_EI"), TextBox)
        Dim txtbxApeMat_EI As TextBox = CType(Me.dvDatosNuevaCompe.FindControl("txtbxApeMat_EI"), TextBox)
        Dim txtbxObservaciones_EI As TextBox = CType(Me.dvDatosNuevaCompe.FindControl("txtbxObservaciones_EI"), TextBox)
        Dim txtbxMesesQueAmparaPago_EI As TextBox = CType(Me.dvDatosNuevaCompe.FindControl("txtbxMesesQueAmparaPago_EI"), TextBox)
        Dim txtbxNumEmpOficial_EI As TextBox = CType(Me.dvDatosNuevaCompe.FindControl("txtbxNumEmpOficial_EI"), TextBox)
        Dim txtbxNumEmpAfectado_EI As TextBox = CType(Me.dvDatosNuevaCompe.FindControl("txtbxNumEmpAfectado_EI"), TextBox)
        Dim dt As DataTable

        Me.dvDatosNuevaCompe.ChangeMode(DetailsViewMode.ReadOnly)
        If Request.Params("TipoOperacion") = "1" Then
            If lblOrigen_EI.Text <> "EXTRAORDINARIO" Then
                oCompe.InsertaRegistro(hfRFC.Value, lblOrigen_EI.Text, CDec(tbImporte_E.Text), ChBxPagarConCheque_EI.Checked, _
                                    tbClaveCobro_EI.Text, CByte(ddlBancos_EI.SelectedValue), tbCuentaBancaria_EI.Text, txtbxApePat_EI.Text, _
                                    txtbxApeMat_EI.Text, txtbxNombre_EI.Text, txtbxObservaciones_EI.Text, CByte(txtbxMesesQueAmparaPago_EI.Text), _
                                    txtbxNumEmpOficial_EI.Text, txtbxNumEmpAfectado_EI.Text, _
                                    CType(Session("ArregloAuditoria"), String()))
                dt = oCompe.PosiblesDatosParaNuevaCompe(hfRFC.Value, 0)
                Me.dvDatosNuevaCompe.DataSource = dt
            Else
                Dim IdEmp As Integer
                IdEmp = oCompe.InsertaRegistro2(CInt(lblIdEmp_EI.Text), lblOrigen_EI.Text, CDec(tbImporte_E.Text), ChBxPagarConCheque_EI.Checked, _
                    tbClaveCobro_EI.Text, CByte(ddlBancos_EI.SelectedValue), tbCuentaBancaria_EI.Text, txtbxApePat_EI.Text, _
                    txtbxApeMat_EI.Text, txtbxNombre_EI.Text, txtbxObservaciones_EI.Text, CByte(txtbxMesesQueAmparaPago_EI.Text), _
                    txtbxNumEmpOficial_EI.Text, txtbxNumEmpAfectado_EI.Text, _
                    CType(Session("ArregloAuditoria"), String()))
                lblIdEmp_EI.Text = IdEmp.ToString
                dt = oCompe.PosiblesDatosParaNuevaCompe(String.Empty, IdEmp)
                Me.dvDatosNuevaCompe.DataSource = dt
            End If
        ElseIf Request.Params("TipoOperacion") = "0" Then
            oCompe.ActualizaRegistro(CInt(lblIdEmp_EI.Text), lblOrigen_EI.Text, CDec(tbImporte_E.Text), ChBxPagarConCheque_EI.Checked, _
                    tbClaveCobro_EI.Text, CByte(ddlBancos_EI.SelectedValue), tbCuentaBancaria_EI.Text, txtbxApePat_EI.Text, _
                    txtbxApeMat_EI.Text, txtbxNombre_EI.Text, txtbxObservaciones_EI.Text, CByte(txtbxMesesQueAmparaPago_EI.Text), _
                    txtbxNumEmpOficial_EI.Text, txtbxNumEmpAfectado_EI.Text, _
                    CType(Session("ArregloAuditoria"), String()))
            dt = oCompe.ObtenParaModificacion(CInt(Request.Params("IdEmp")), Request.Params("Origen"))
            Me.dvDatosNuevaCompe.DataSource = dt
        End If
        Me.dvDatosNuevaCompe.DataBind()
        CType(Me.WucBuscaEmpleados1.FindControl("BtnNewSearch"), Button).Enabled = True
    End Sub

    Protected Sub dvDatosNuevaCompe_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles dvDatosNuevaCompe.DataBound
        If Me.dvDatosNuevaCompe.CurrentMode = DetailsViewMode.Edit Then
            Dim ddlBancos_EI As DropDownList = CType(Me.dvDatosNuevaCompe.FindControl("ddlBancos_EI"), DropDownList)
            Dim lblIdBanco_EI As Label = CType(Me.dvDatosNuevaCompe.FindControl("lblIdBanco_EI"), Label)
            'Dim btnGuardar As Button = CType(Me.dvDatosNuevaCompe.FindControl("btnGuardar"), Button)
            'Dim btnCancelar As Button = CType(Me.dvDatosNuevaCompe.FindControl("btnCancelar"), Button)

            'btnGuardar.OnClientClick = "if (confirm('Está operación guardará la información en la Base de datos, ¿Continuar?')==true){this.disabled = true; this.value = 'Guardando...';" + btnCancelar.ClientID + ".disabled = true;}else{return false;}"

            'btnGuardar.UseSubmitBehavior = False
            'btnCancelar.UseSubmitBehavior = False
            'If ddlBancos_EI Is Nothing = False Then
            BindddlBancos(ddlBancos_EI, lblIdBanco_EI.Text)
            'End If
        End If
    End Sub

    Protected Sub WucBuscaEmpleados1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles WucBuscaEmpleados1.PreRender
        BinddvDatosNuevaCompe()
    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If IsPostBack = False Then
            Dim oCompe As New Compensacion
            Dim dt As DataTable
            If Request.Params("TipoOperacion") = "0" Then
                Me.WucBuscaEmpleados1.Visible = False
                Me.dvDatosNuevaCompe.HeaderText = "Modificación de datos de compensaciones"
                Me.dvDatosNuevaCompe.Fields(1).Visible = True
                Me.dvDatosNuevaCompe.Fields(2).Visible = True
                Me.dvDatosNuevaCompe.Fields(3).Visible = True
                'Me.dvDatosNuevaCompe.Fields(12).Visible = True
                Me.dvDatosNuevaCompe.Fields(13).Visible = True
                dt = oCompe.ObtenParaModificacion(CInt(Request.Params("IdEmp")), Request.Params("Origen"))
                If dt.Rows.Count > 0 Then
                    Me.dvDatosNuevaCompe.DataSource = dt
                End If
                Me.dvDatosNuevaCompe.ChangeMode(DetailsViewMode.Edit)
                Me.dvDatosNuevaCompe.DataBind()
                If dt.Rows.Count > 0 Then
                    If Request.Params("Origen") <> "EXTRAORDINARIO" Then
                        CType(Me.dvDatosNuevaCompe.FindControl("txtbxNombre_EI"), TextBox).ReadOnly = True
                        CType(Me.dvDatosNuevaCompe.FindControl("txtbxApePat_EI"), TextBox).ReadOnly = True
                        CType(Me.dvDatosNuevaCompe.FindControl("txtbxApeMat_EI"), TextBox).ReadOnly = True
                        CType(Me.dvDatosNuevaCompe.FindControl("txtbxNumEmpOficial_EI"), TextBox).ReadOnly = True
                        CType(Me.dvDatosNuevaCompe.FindControl("btnValidarNumEmpOficial"), Button).Enabled = False
                        CType(Me.dvDatosNuevaCompe.FindControl("txtbxNumEmpAfectado_EI"), TextBox).ReadOnly = True
                        CType(Me.dvDatosNuevaCompe.FindControl("btnValidarNumEmpAfectado"), Button).Enabled = False
                        'CType(Me.dvDatosNuevaCompe.FindControl("txtbxObservaciones_EI"), TextBox).ReadOnly = False
                    Else
                        CType(Me.dvDatosNuevaCompe.FindControl("txtbxNombre_EI"), TextBox).ReadOnly = False
                        CType(Me.dvDatosNuevaCompe.FindControl("txtbxApePat_EI"), TextBox).ReadOnly = False
                        CType(Me.dvDatosNuevaCompe.FindControl("txtbxApeMat_EI"), TextBox).ReadOnly = False
                        CType(Me.dvDatosNuevaCompe.FindControl("txtbxNumEmpOficial_EI"), TextBox).ReadOnly = False
                        CType(Me.dvDatosNuevaCompe.FindControl("btnValidarNumEmpOficial"), Button).Enabled = True
                        CType(Me.dvDatosNuevaCompe.FindControl("txtbxNumEmpAfectado_EI"), TextBox).ReadOnly = False
                        CType(Me.dvDatosNuevaCompe.FindControl("btnValidarNumEmpAfectado"), Button).Enabled = True
                        'CType(Me.dvDatosNuevaCompe.FindControl("txtbxObservaciones_EI"), TextBox).ReadOnly = False
                    End If
                End If
            End If
        End If
    End Sub

    Protected Sub ChBxPagarConCheque_EI_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.dvDatosNuevaCompe.CurrentMode = DetailsViewMode.Edit Then
            Dim ChBxPagarConCheque_EI As CheckBox = CType(Me.dvDatosNuevaCompe.FindControl("ChBxPagarConCheque_EI"), CheckBox)
            Dim RFVBanco As RequiredFieldValidator = CType(Me.dvDatosNuevaCompe.FindControl("RFVBanco"), RequiredFieldValidator)
            Dim RFVCuentaBancaria As RequiredFieldValidator = CType(Me.dvDatosNuevaCompe.FindControl("RFVCuentaBancaria"), RequiredFieldValidator)
            RFVBanco.Enabled = Not ChBxPagarConCheque_EI.Checked
            RFVCuentaBancaria.Enabled = Not ChBxPagarConCheque_EI.Checked
        End If
    End Sub

    Protected Sub btnValidarNumEmpOficial_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim oEmp As New Empleado
        Dim txtbxNumEmpOficial_EI As TextBox = CType(Me.dvDatosNuevaCompe.FindControl("txtbxNumEmpOficial_EI"), TextBox)
        Dim lblNomEmpOficial As Label = CType(Me.dvDatosNuevaCompe.FindControl("lblNomEmpOficial"), Label)
        Dim dr As DataRow = Nothing
        dr = oEmp.BuscarPorNumEmp(txtbxNumEmpOficial_EI.Text)
        If dr Is Nothing Then
            lblNomEmpOficial.Text = "Empleado inexistente."
        Else
            lblNomEmpOficial.Text = (dr("Nombre").ToString + " " + dr("ApellidoPaterno").ToString + "  " + dr("ApellidoMaterno").ToString).ToString.ToUpper.Trim
        End If
    End Sub
    Protected Sub btnValidarNumEmpAfectado_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim oEmp As New Empleado
        Dim txtbxNumEmpAfectado_EI As TextBox = CType(Me.dvDatosNuevaCompe.FindControl("txtbxNumEmpAfectado_EI"), TextBox)
        Dim lblNomEmpAfectado As Label = CType(Me.dvDatosNuevaCompe.FindControl("lblNomEmpAfectado"), Label)
        Dim dr As DataRow = Nothing
        dr = oEmp.BuscarPorNumEmp(txtbxNumEmpAfectado_EI.Text)
        If dr Is Nothing Then
            lblNomEmpAfectado.Text = "Empleado inexistente."
        Else
            lblNomEmpAfectado.Text = (dr("Nombre").ToString + " " + dr("ApellidoPaterno").ToString + "  " + dr("ApellidoMaterno").ToString).ToString.ToUpper.Trim
        End If
    End Sub

End Class
