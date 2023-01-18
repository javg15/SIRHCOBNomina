Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.Empleados
Imports System.Data
Imports BusinessRulesLayer.COBAEV.Validaciones
Imports DataAccessLayer.COBAEV
Imports DataAccessLayer.COBAEV.Empleados.Sexos
Imports DataAccessLayer.COBAEV.Mexico.Estados
Imports DataAccessLayer.COBAEV.Administracion
Partial Class wfCategoriaDetalles
    Inherits System.Web.UI.Page
    Private Sub GuardaInformacion(ByVal pTipoOperacion As String)
        Try
            Dim IdQnaFin As Short = CType(ddlQnaFin.SelectedValue, Short)
            Dim oValidacion As New Validaciones
            Dim _DataCOBAEV As New DataCOBAEV
            Dim dsValida As DataSet
            Dim vlIdBeneficiario As Short
            Dim vlPorcentaje As Decimal

            If pTipoOperacion = "0" Then
                vlIdBeneficiario = CShort(CType(gvPensionados.SelectedRow.FindControl("lblIdBeneficiario"), Label).Text)
            End If

            vlIdBeneficiario = IIf(pTipoOperacion = "1", 0, vlIdBeneficiario)
            vlPorcentaje = IIf(pTipoOperacion = "1", 0, CDec(txtbxPorc.Text))

            dsValida = _DataCOBAEV.setDataSetErrores()

            With oValidacion
                .NombrePagina = Request.Url.Segments(Request.Url.Segments.Length - 1).ToString
                .RFC = Session("RFCParaCons")
                .TipoOperacion = CByte(pTipoOperacion)
                .IdBeneficiario = vlIdBeneficiario
                .Porcentaje = vlPorcentaje
                If Not .ValidaPaginasOperacion(dsValida, False) Then
                    Session.Add("dsValida", dsValida)
                    wucMuestraErrores.ActualizaContenido()
                    MultiView1.SetActiveView(viewErrores)
                    Exit Sub
                Else
                    Session.Remove("dsValida")
                End If
            End With

            Dim oEmp As New BeneficiariosPensionAlimenticia
            With oEmp
                .IdBeneficiario = vlIdBeneficiario
                .RFCEmp = Session("RFCParaCons")
                .RFCBeneficiario = txtbxRFC.Text.Trim.ToUpper
                .CURPBeneficiario = txtbxCURP.Text.Trim.ToUpper
                .ApePatBeneficiario = txtbxApePat.Text.Trim.ToUpper
                .ApeMatBeneficiario = txtbxApeMat.Text.Trim.ToUpper
                .NomBeneficiario = txtbxNombre.Text.Trim.ToUpper
                .IdParentesco = CByte(ddlParentescos.SelectedValue)
                .Porcentaje = CType(txtbxPorc.Text, Decimal)
                .PrioridadCalculo = CType(ddlPrioridadCalculo.SelectedItem.Text, Byte)
                .IdPlantel = CType(ddlPlanteles.SelectedValue, Short)
                .IdSexo = CByte(ddlSexos.SelectedValue)
                .IdEdo = CByte(ddlEstados.SelectedValue)
                .FecNac = txtbxFecNac.Text.Trim

                .IncluirEnPagomatico = chkbxTransBanc.Checked
                .IdBanco = CByte(ddlBancosTB.SelectedValue)
                .CuentaBancaria = txtbxCtaBancTB.Text.Trim
                .IdBeneficiarioDivision = CShort(lbBeneficiarios.SelectedValue)
                .PagoInterbancario = chkbxTransInterBanc.Checked
                .IdBancoCLABE = CByte(ddlBancosTIB.SelectedValue)
                .CLABE = txtbxCtaTIB.Text.Trim
                .IdBanco2 = CByte(ddlBancosParaDispersion.SelectedValue) 'Banco mediante el cual se realizará la tranferencia interbancaria

                .IdQnaIni = CShort(ddlQnaIni.SelectedValue)
                .IdQnaFin = CShort(ddlQnaFin.SelectedValue)

                .OficioDictamenPA = txtbxOficioDictamenPA.Text.Trim
                .ExpedienteDictamenPA = txtbxExpedienteDictamenPA.Text.Trim

                If pTipoOperacion = "1" Then
                    .Insertar(CType(Session("ArregloAuditoria"), String()))
                    lblCapturaExitosa.Text = "La información del nuevo beneficiario " + txtbxNombre.Text.Trim.ToUpper + " " + _
                                            txtbxApePat.Text.Trim.ToUpper + " " + txtbxApeMat.Text.Trim.ToUpper + " ha sido guardada " + _
                                            "exitosamente."
                ElseIf pTipoOperacion = "0" Then
                    .Actualizar(CByte(pTipoOperacion), CType(Session("ArregloAuditoria"), String()))
                    lblCapturaExitosa.Text = "La información del beneficiario " + txtbxNombre.Text.Trim.ToUpper + " " + _
                                            txtbxApePat.Text.Trim.ToUpper + " " + txtbxApeMat.Text.Trim.ToUpper + " ha sido actualizada " + _
                                            "exitosamente."
                End If
            End With

            Me.MultiView1.SetActiveView(viewOperacionExitosa)
        Catch Ex As Exception
            Me.MultiView1.SetActiveView(Me.viewErrores)
        End Try
    End Sub
    Private Sub ConvierteAMayusculas(sender As Object, e As System.EventArgs) Handles txtbxApePat.TextChanged, txtbxRFC.TextChanged, txtbxCURP.TextChanged, txtbxApeMat.TextChanged, txtbxNombre.TextChanged
        Dim txtbx As TextBox = CType(sender, TextBox)
        txtbx.Text = txtbx.Text.ToUpper.Trim
    End Sub
    Private Sub chkbxTransInterBancCheckedChanged()
        ddlBancosTIB_RFV.Enabled = chkbxTransInterBanc.Checked
        txtbxCtaTIB.Enabled = chkbxTransInterBanc.Checked
        txtbxCtaTIB_RFV.Enabled = chkbxTransInterBanc.Checked
        txtbxCtaTIB_REV.Enabled = chkbxTransInterBanc.Checked

        ddlBancosParaDispersion.Enabled = chkbxTransInterBanc.Checked
        ddlBancosParaDispersion_RFV.Enabled = chkbxTransInterBanc.Checked

        If chkbxTransInterBanc.Checked = False Then
            txtbxCtaTIB.Text = String.Empty
            ddlBancosTIB.SelectedValue = "4"
            ddlBancosParaDispersion.SelectedValue = "3"
        End If

        If chkbxTransInterBanc.Checked Then
            chkbxTransBanc.Checked = False
            chkbxTransBanc.Enabled = False
            ddlBancosTB.SelectedValue = "3"
            ddlBancosTB.Enabled = False
            ddlBancosTB_RFV.Enabled = False
            txtbxCtaBancTB.Text = String.Empty
            txtbxCtaBancTB.Enabled = False
        Else
            chkbxTransBanc.Enabled = True
        End If
    End Sub
    Private Sub chkbxTransBancCheckedChanged()
        ddlBancosTB.Enabled = chkbxTransBanc.Checked
        ddlBancosTB_RFV.Enabled = chkbxTransBanc.Checked

        txtbxCtaBancTB.Enabled = chkbxTransBanc.Checked

        If chkbxTransBanc.Checked = False Then
            txtbxCtaBancTB.Text = String.Empty
            ddlBancosTB.SelectedValue = "3"
        End If

        If btnCrearBenef.Visible Then
            ddlBancosTBSelectedIndexChanged("1")
        ElseIf btnModifBenef.Visible Then
            ddlBancosTBSelectedIndexChanged("0")
        End If

        If chkbxTransBanc.Checked Then
            chkbxTransInterBanc.Checked = False
            chkbxTransInterBanc.Enabled = False
            ddlBancosTIB.SelectedValue = "4"
            ddlBancosTIB.Enabled = False
            txtbxCtaTIB.Text = String.Empty
            txtbxCtaTIB.Enabled = False
            ddlBancosParaDispersion.SelectedValue = "3"
            ddlBancosParaDispersion.Enabled = False
            ddlBancosParaDispersion_RFV.Enabled = False
        Else
            chkbxTransInterBanc.Enabled = True
        End If
    End Sub
    Private Sub MostraraDetallesRegistro(ByVal pIdBeneficiario As Short, ByVal pTipoOperacion As String, Optional pCopia As Boolean = False)
        'Dim hfNomEmp As HiddenField '= CType(wucBuscaEmps.FindControl("hfNomEmp"), HiddenField)
        Dim drBenefPA As DataRow = Nothing
        Dim oBenefPA As New BeneficiariosPensionAlimenticia

        pnlWarning.Visible = False
        chbxMostrarOcultarTips.Checked = False

        If pTipoOperacion = "0" Then 'Modificación
            'lblEmpInf2.Text = "Modificando información del beneficiario de pensión alimenticia del empleado: " + IIf(hfNomEmp.Value = String.Empty, Session("ApePatParaCons") + " " + Session("ApeMatParaCons") + " " + Session("NombreParaCons"), hfNomEmp.Value)
        ElseIf pTipoOperacion = "1" Then 'Inserción
            pnlWarning.Visible = True
            chbxMostrarOcultarTips.Checked = False

            'lblEmpInf2.Text = "Agregando beneficiario de pensión alimenticia al empleado: " + IIf(hfNomEmp.Value = String.Empty, Session("ApePatParaCons") + " " + Session("ApeMatParaCons") + " " + Session("NombreParaCons"), hfNomEmp.Value)
        Else '4 Actualización
            'lblEmpInf2.Text = "Consultando información del beneficiario de pensión alimenticia del empleado: " + IIf(hfNomEmp.Value = String.Empty, Session("ApePatParaCons") + " " + Session("ApeMatParaCons") + " " + Session("NombreParaCons"), hfNomEmp.Value)
        End If

        LimpiaCampos(pTipoOperacion, Page)

        chkbxTransBanc.Checked = False
        BindddlBancosTB(pTipoOperacion)
        chkbxTransInterBanc.Checked = False
        BindddlBancosTIB(pTipoOperacion)

        drBenefPA = oBenefPA.ObtenPorId(pIdBeneficiario)

        txtbxRFC.Text = drBenefPA("RFC").ToString.Trim
        txtbxCURP.Text = drBenefPA("CURP").ToString.Trim
        txtbxApePat.Text = drBenefPA("ApePat").ToString.Trim
        txtbxApeMat.Text = drBenefPA("ApeMat").ToString.Trim
        txtbxNombre.Text = drBenefPA("Nombre").ToString.Trim
        BindSexos(drBenefPA("IdSexo").ToString)
        txtbxFecNac.Text = drBenefPA("FecNac").ToString
        BindParentescos(drBenefPA("IdParentesco").ToString.Trim)
        BindEstados(drBenefPA("IdEdo").ToString.Trim)

        'txtbxPrioridad.Text = drBenefPA("PrioridadCalculo").ToString.Trim
        BindPrioridadCalculo(pTipoOperacion, pCopia, pIdBeneficiario, drBenefPA("PrioridadCalculo").ToString.Trim)

        txtbxPorc.Text = drBenefPA("PorcentajeNum").ToString.Trim
        BindlbBeneficiarios(drBenefPA("IdBeneficiarioDivision").ToString.Trim, pIdBeneficiario.ToString)

        chkbxTransBanc.Checked = CBool(drBenefPA("IncluirEnPagomatico"))
        chkbxTransInterBanc.Checked = CBool(drBenefPA("PagoInterbancario"))

        BindddlBancosTB(pTipoOperacion, drBenefPA("IdBanco").ToString.Trim)
        txtbxCtaTIB.Text = drBenefPA("CLABE").ToString.Trim
        txtbxCtaBancTB.Text = drBenefPA("CuentaBancaria").ToString.Trim

        BindddlBancosTIB(pTipoOperacion, drBenefPA("IdBancoCLABE").ToString)

        If pCopia = False Then
            BindEfectos(drBenefPA("IdQnaIni").ToString, drBenefPA("IdQnaFin").ToString)
        Else
            BindEfectos()
        End If

        BindPlantelesParaPago(drBenefPA("IdPlantel").ToString)
        BindddlBancosParaDispersion(drBenefPA("IdBancoDispersion").ToString)

        chkbxTransBancCheckedChanged()
        chkbxTransInterBancCheckedChanged()

        txtbxOficioDictamenPA.Text = drBenefPA("OficioDictamenPA").ToString
        txtbxExpedienteDictamenPA.Text = drBenefPA("ExpedienteDictamenPA").ToString

        btnCrearBenef.Visible = False
        btnModifBenef.Visible = True

        If pCopia Then
            btnCrearBenef.Visible = True
            btnModifBenef.Visible = False
        End If
    End Sub
    Private Sub setPermisos()
        Dim oUsr As New Usuario
        Dim dtPermisosUsuario As DataTable
        Dim oQna As New Quincenas
        Dim vlHayQnaAbierta As Boolean

        dtPermisosUsuario = oUsr.ObtenPermisosSobreTabla(Session("Login"), "BeneficiariosPensionAlimenticia")
        vlHayQnaAbierta = oQna.HayAbiertasParaCaptura()

        'pnlWarning2.Visible = Not vlHayQnaAbierta
        lbAgregarNuevo.Visible = CBool(dtPermisosUsuario.Rows(0).Item("Insercion")) And vlHayQnaAbierta 'Permiso inserción
        gvPensionados2.Columns(12).Visible = CBool(dtPermisosUsuario.Rows(0).Item("Consulta")) 'Permiso consulta para ver detalles
        gvPensionados2.Columns(13).Visible = CBool(dtPermisosUsuario.Rows(0).Item("Insercion")) And vlHayQnaAbierta 'Permiso inserción
        gvPensionados.Columns(12).Visible = CBool(dtPermisosUsuario.Rows(0).Item("Consulta")) 'Permiso consulta para ver detalles
        gvPensionados.Columns(13).Visible = CBool(dtPermisosUsuario.Rows(0).Item("Actualizacion")) And vlHayQnaAbierta 'Permiso modificación
        gvPensionados.Columns(14).Visible = CBool(dtPermisosUsuario.Rows(0).Item("Actualizacion")) And vlHayQnaAbierta 'Permiso baja
        gvPensionados.Columns(15).Visible = CBool(dtPermisosUsuario.Rows(0).Item("Eliminacion")) And vlHayQnaAbierta 'Permiso eliminación
    End Sub
    Private Sub LimpiaCampos(ByVal pTipoOperacion As String, ByVal Lista As Control)
        For Each myControl In Lista.Controls
            If TypeOf myControl Is TextBox Then
                If CType(myControl, TextBox).NamingContainer.ID <> "wucBuscaEmps" Then CType(myControl, TextBox).Text = String.Empty
            End If
            LimpiaCampos(pTipoOperacion, myControl)
        Next
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
    Private Sub BindEfectos(Optional ByVal pIdQnaIni As String = Nothing, Optional ByVal pIdQnaFin As String = Nothing)
        Dim oQna As New Quincenas
        Dim dtQnasAbiertasParaCaptura As DataTable

        LlenaDDL(ddlQnaIni, "Quincena", "IdQuincena", oQna.ObtenParaVigIni(True), pIdQnaIni)

        If pIdQnaIni Is Nothing Then
            dtQnasAbiertasParaCaptura = oQna.ObtenAbiertasParaCaptura()
            If dtQnasAbiertasParaCaptura.Rows.Count > 0 Then
                ddlQnaIni.SelectedValue = CStr(dtQnasAbiertasParaCaptura.Rows(0).Item("IdQuincena"))
            Else
                ddlQnaIni.SelectedIndex = 0
            End If
        End If

        LlenaDDL(ddlQnaFin, "Quincena", "IdQuincena", oQna.ObtenParaVigFin(CType(ddlQnaIni.SelectedValue, Short), True), pIdQnaFin)
    End Sub
    Private Sub BinddvCategoDetalles(ByVal pClavePuesto As String, pCveIdentificadorPuesto As Byte, Optional pIdQuincena As Short = 0)

        Dim oCatego As New Categoria
        Dim dtCategoDetalle As DataTable

        'If Not Session("RFCParaCons") Is Nothing Or hfNomEmp.Value.Trim <> String.Empty Then
        dtCategoDetalle = oCatego.ObtenDetalles(pClavePuesto, pCveIdentificadorPuesto, pIdQuincena)

        dvCategoDetalles.DataSource = dtCategoDetalle.Rows(0).Table
        dvCategoDetalles.DataBind()

        lblEmpInfConsulta.Text = "Información detallada de la categoría "
        lblEmpInfConsulta.Visible = True

        'gvPensionados.Enabled = True
        'gvPensionados2.Enabled = True
        'pnlBenefPAVig.Visible = True
        'pnlBenefPAHistoria.Visible = True
        'Else
        'lblEmpInf.Text = String.Empty
        'lblEmpInf.Visible = False
        'End If
    End Sub
    Private Sub BindlbBeneficiarios(Optional ByVal IdBeneficiarioDivision As String = Nothing, Optional ByVal IdBeneficiario As String = Nothing)
        'Dim RFCEmp As String
        Dim dt As DataTable
        'Dim hfRFC As HiddenField '= CType(wucBuscaEmps.FindControl("hfRFC"), HiddenField)
        'Dim hfNomEmp As HiddenField '= CType(wucBuscaEmps.FindControl("hfNomEmp"), HiddenField)
        Dim oEmp As New BeneficiariosPensionAlimenticia

        'RFCEmp = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))

        If Not Session("RFCParaCons") Is Nothing Then 'Or hfNomEmp.Value.Trim <> String.Empty Then
            'oEmp.RFCEmp = RFCEmp
            dt = oEmp.ObtenBeneficiariosDePensionAlimenticia

            With lbBeneficiarios
                .DataSource = dt
                .DataTextField = "NomCompletoBenef"
                .DataValueField = "IdBeneficiario"
                .DataBind()
                .Items.Insert(0, New ListItem("INGRESO DEL EMPLEADO", "0"))
            End With

            If IdBeneficiario Is Nothing = False Then lbBeneficiarios.Items.Remove(lbBeneficiarios.Items.FindByValue(IdBeneficiario))

            If IdBeneficiarioDivision Is Nothing = False Then
                lbBeneficiarios.SelectedValue = IdBeneficiarioDivision
            Else
                lbBeneficiarios.Items(0).Selected = True
            End If

        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'setPermisos()
            MultiView1.Visible = True
            BinddvCategoDetalles(Request.Params("pCveOfi").ToString, CByte(Request.Params("pCveIdentificadorPuesto")))
            MultiView1.SetActiveView(viewConsulta)
        End If
    End Sub
    Protected Sub gvPensionados_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvPensionados.RowDataBound
        'Dim hfRFC As HiddenField = CType(wucBuscaEmps.FindControl("hfRFC"), HiddenField)
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                Dim oBenefPA As New BeneficiariosPensionAlimenticia
                Dim lblIdBeneficiario As Label = CType(e.Row.FindControl("lblIdBeneficiario"), Label)
                Dim ibBaja As ImageButton = CType(e.Row.FindControl("ibBaja"), ImageButton)
                Dim ibBaja_CBE As AjaxControlToolkit.ConfirmButtonExtender = CType(e.Row.FindControl("ibBaja_CBE"), AjaxControlToolkit.ConfirmButtonExtender)
                Dim ibEliminar As ImageButton = CType(e.Row.FindControl("ibEliminar"), ImageButton)
                Dim ibModificar As ImageButton = CType(e.Row.FindControl("ibModificar"), ImageButton)
                Dim lblQnaIni As Label = CType(e.Row.FindControl("lblQnaIni"), Label)
                Dim vlInfSePuedeModificar As Boolean = False
                Dim oQna As New Quincenas
                Dim dtQnasAbiertasParaCapt As DataTable
                Dim dtUltQnaCobrada As DataTable

                vlInfSePuedeModificar = oBenefPA.ObtenSiSePuedeModificarInf(CShort(lblIdBeneficiario.Text))
                dtQnasAbiertasParaCapt = oQna.ObtenAbiertasParaCaptura()
                dtUltQnaCobrada = oBenefPA.ObtenUltQnaCobrada(CShort(lblIdBeneficiario.Text))

                ibBaja.Enabled = False
                ibBaja.ImageUrl = "~/Imagenes/BajaDisabled.png"
                If dtQnasAbiertasParaCapt.Rows.Count > 0 Then
                    If dtQnasAbiertasParaCapt.Rows(0).Item("Quincena").ToString = lblQnaIni.Text Then
                        If dtUltQnaCobrada.Rows.Count > 0 Then
                            ibBaja.Enabled = True
                            ibBaja.ImageUrl = "~/Imagenes/BajaEnabled.png"
                            ibBaja.ToolTip = "Utilice esta opción si lo que desea es dar de baja el registro. El registro sería dado de baja en la quincena " + dtUltQnaCobrada.Rows(0).Item("Quincena").ToString _
                                            + " que es la última quincena en la que se le refleja pago al beneficiario."
                            ibBaja_CBE.ConfirmText = "¿Está completamente seguro de utilizar ésta opción? De ser así, el registro será dado de baja utilizando " _
                                                       + "la quincena " + dtUltQnaCobrada.Rows(0).Item("Quincena").ToString + " como quincena final."

                        Else
                            ibBaja.ToolTip = "Opción no disponible, utilice la opción ELIMINAR o MODIFICAR según la operación que desee realizar."
                        End If
                    Else
                        If dtUltQnaCobrada.Rows.Count > 0 Then
                            ibBaja.Enabled = True
                            ibBaja.ImageUrl = "~/Imagenes/BajaEnabled.png"
                            ibBaja.ToolTip = "Utilice esta opción si lo que desea es dar de baja el registro. El registro sería dado de baja en la quincena " + dtUltQnaCobrada.Rows(0).Item("Quincena").ToString _
                                            + " que es la última quincena en la que se le refleja pago al beneficiario."
                            ibBaja_CBE.ConfirmText = "¿Está completamente seguro de utilizar ésta opción? De ser así, el registro será dado de baja utilizando " _
                                                       + "la quincena " + dtUltQnaCobrada.Rows(0).Item("Quincena").ToString + " como quincena final."
                        Else
                            ibBaja.ToolTip = "Opción no disponible, utilice la opción ELIMINAR o MODIFICAR según la operación que desee realizar."
                        End If
                    End If
                Else
                    ibBaja.ToolTip = "Opción no disponible, no hay quincenas abiertas para captura/modificación de información."
                End If

                ibModificar.Enabled = vlInfSePuedeModificar
                ibEliminar.Enabled = vlInfSePuedeModificar

                If ibModificar.Enabled = False Then
                    ibModificar.ImageUrl = "~/Imagenes/ModificarDisabled.jpg"
                    ibModificar.ToolTip = "Imposible modificar la información del registro."
                Else
                    ibModificar.ImageUrl = "~/Imagenes/Modificar.png"
                    ibModificar.ToolTip = "Utilice esta opción si lo que desea es modificar algún dato de la información del beneficiario."
                End If

                If ibEliminar.Enabled = False Then
                    ibEliminar.ImageUrl = "~/Imagenes/EliminarDisabled.jpg"
                    ibEliminar.ToolTip = "Imposible eliminar este registro."
                Else
                    ibEliminar.ImageUrl = "~/Imagenes/Eliminar.png"
                    ibEliminar.ToolTip = "Utilice esta opción si lo que desea es eliminar el registro."
                End If

                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvPensionados, "Select$" + e.Row.RowIndex.ToString)
        End Select
    End Sub
    Protected Sub gvPensionados2_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvPensionados2, "Select$" + e.Row.RowIndex.ToString)
        End Select
    End Sub
    'Protected Sub wucBuscaEmps_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles wucBuscaEmps.PreRender
    '    If IsPostBack Then
    '        Dim hfRFC As HiddenField '= CType(wucBuscaEmps.FindControl("hfRFC"), HiddenField)
    '        Dim txtbxRFC As TextBox '= CType(wucBuscaEmps.FindControl("txtbxRFC"), TextBox)
    '        If Request.Params(0).Contains("BtnSearch") Or Request.Params(1).Contains("BtnSearch") Then
    '            If txtbxRFC.Text <> String.Empty Then
    '                setPermisos()
    '                MultiView1.Visible = True
    '                MultiView1.SetActiveView(viewBenef)
    '                BindgvPensionados()
    '            Else
    '                MultiView1.Visible = False
    '            End If
    '        ElseIf Request.Params(0).Contains("BtnNewSearch") Or Request.Params(1).Contains("BtnNewSearch") Then
    '            MultiView1.Visible = False
    '        ElseIf Request.Params(0).Contains("BtnNewSearch") Or Request.Params(1).Contains("BtnCancelSearch") Then
    '            MultiView1.Visible = True
    '        ElseIf Request.Params("__EVENTTARGET") Is Nothing = False Then
    '            If Request.Params("__EVENTTARGET").Contains("lnkbtnrfc") Then
    '                setPermisos()
    '                MultiView1.Visible = True
    '                MultiView1.SetActiveView(viewBenef)
    '                BindgvPensionados()
    '            End If
    '        End If
    '    End If
    'End Sub
    Protected Sub lbAgregarNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbAgregarNuevo.Click
        'Dim hfNomEmp As HiddenField '= CType(wucBuscaEmps.FindControl("hfNomEmp"), HiddenField)
        Dim vlTipoOperacion As String = "1"

        pnlWarning.Visible = True
        chbxMostrarOcultarTips.Checked = False

        'lblEmpInf2.Text = "Agregando beneficiario de pensión alimenticia al empleado: " + IIf(hfNomEmp.Value = String.Empty, Session("ApePatParaCons") + " " + Session("ApeMatParaCons") + " " + Session("NombreParaCons"), hfNomEmp.Value)

        LimpiaCampos(vlTipoOperacion, Page)

        chkbxTransBanc.Checked = False
        BindddlBancosTB(vlTipoOperacion)
        chkbxTransInterBanc.Checked = False
        BindddlBancosTIB(vlTipoOperacion)

        BindSexos()
        BindParentescos()
        BindEstados()

        BindPrioridadCalculo(vlTipoOperacion, False, 0)

        BindlbBeneficiarios()

        BindEfectos()
        BindPlantelesParaPago()
        BindddlBancosTB(vlTipoOperacion, "3")
        BindddlBancosTIB(vlTipoOperacion, "4")
        BindddlBancosParaDispersion("3")

        Muestra_Oculta_Ayuda(False, Page)

        chkbxTransBancCheckedChanged()
        chkbxTransInterBancCheckedChanged()

        btnCrearBenef.Visible = True
        btnModifBenef.Visible = False

        MultiView1.SetActiveView(viewDetalles)
    End Sub
    Protected Sub ibModificar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim gvrBenefPA As GridViewRow = CType(sender.NamingContainer, GridViewRow)
        Dim lblIdBeneficiario As Label = CType(gvrBenefPA.FindControl("lblIdBeneficiario"), Label)
        Dim vlIdBeneficiario As Short = CShort(lblIdBeneficiario.Text)
        Dim vlTipoOperacion As String = "0"

        gvPensionados.SelectedIndex = gvrBenefPA.RowIndex

        MostraraDetallesRegistro(vlIdBeneficiario, vlTipoOperacion)

        Muestra_Oculta_Ayuda(False, Page)

        MultiView1.SetActiveView(viewDetalles)

    End Sub
    Protected Sub ibBaja_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Try
            Dim oBenefPA As New BeneficiariosPensionAlimenticia
            Dim gvrBenefPA As GridViewRow = CType(sender.NamingContainer, GridViewRow)
            Dim lblIdBeneficiario As Label = CType(gvrBenefPA.FindControl("lblIdBeneficiario"), Label)
            Dim vlIdBeneficiario As Short = CShort(lblIdBeneficiario.Text)
            Dim lblApePat, lblApeMat, lblNombre As Label
            Dim oQna As New Quincenas
            Dim dtUltQnaCobrada As DataTable

            dtUltQnaCobrada = oBenefPA.ObtenUltQnaCobrada(CShort(lblIdBeneficiario.Text))

            lblApePat = CType(gvrBenefPA.FindControl("lblApePat"), Label)
            lblApeMat = CType(gvrBenefPA.FindControl("lblApeMat"), Label)
            lblNombre = CType(gvrBenefPA.FindControl("lblNombre"), Label)

            oBenefPA.ActualizarVigenciaFinal(vlIdBeneficiario, CShort(dtUltQnaCobrada.Rows(0).Item("IdQuincena")), CType(Session("ArregloAuditoria"), String()))

            lblCapturaExitosa.Text = "El registro del beneficiario " + lblNombre.Text.Trim.ToUpper + " " + _
                            lblApePat.Text.Trim.ToUpper + " " + lblApeMat.Text.Trim.ToUpper + " ha sido dado de baja " + _
                            "exitosamente, utilizando la quincena " + dtUltQnaCobrada.Rows(0).Item("Quincena").ToString + _
                            " como quincena final."

            Me.MultiView1.SetActiveView(viewOperacionExitosa)
        Catch ex As Exception
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
            MultiView1.SetActiveView(viewErrores)
        End Try
    End Sub
    Protected Sub ibEliminar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Try
            Dim oBenefPA As New BeneficiariosPensionAlimenticia
            Dim gvrBenefPA As GridViewRow = CType(sender.NamingContainer, GridViewRow)
            Dim lblIdBeneficiario As Label = CType(gvrBenefPA.FindControl("lblIdBeneficiario"), Label)
            Dim vlIdBeneficiario As Short = CShort(lblIdBeneficiario.Text)
            Dim lblApePat, lblApeMat, lblNombre As Label

            lblApePat = CType(gvrBenefPA.FindControl("lblApePat"), Label)
            lblApeMat = CType(gvrBenefPA.FindControl("lblApeMat"), Label)
            lblNombre = CType(gvrBenefPA.FindControl("lblNombre"), Label)

            oBenefPA.Eliminar(vlIdBeneficiario, CType(Session("ArregloAuditoria"), String()))

            lblCapturaExitosa.Text = "El registro del beneficiario " + lblNombre.Text.Trim.ToUpper + " " + _
                            lblApePat.Text.Trim.ToUpper + " " + lblApeMat.Text.Trim.ToUpper + " ha sido eliminado " + _
                            "exitosamente."

            Me.MultiView1.SetActiveView(viewOperacionExitosa)
        Catch ex As Exception
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
            MultiView1.SetActiveView(viewErrores)
        End Try
    End Sub
    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, ByVal dt As DataTable, ByVal SelectedValue As String)
        ddl.DataSource = dt
        ddl.DataTextField = TextField
        ddl.DataValueField = ValueField
        ddl.DataBind()
        If SelectedValue Is Nothing = False And SelectedValue <> String.Empty Then
            If ddl.Items.FindByValue(SelectedValue) Is Nothing = False Then
                ddl.SelectedValue = SelectedValue
            End If
        End If
    End Sub
    Protected Sub btnCancelar_Click(sender As Object, e As System.EventArgs) Handles btnCancelar.Click
        MultiView1.SetActiveView(viewBenef)
    End Sub
    Protected Sub ddlSexos_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlSexos.SelectedIndexChanged
        BindParentescos()
    End Sub
    Private Sub BindSexos(Optional ByVal IdSexo As String = "3")
        Dim oSexo As New Sexo
        LlenaDDL(ddlSexos, "DescSexo", "IdSexo", oSexo.ObtenTodos(), IdSexo)
    End Sub
    Private Sub BindParentescos(Optional ByVal IdParentesco As String = "7")
        Dim oPatentesco As New Parentesco
        If CType(ddlSexos.SelectedValue, Byte) = 3 Then
            LlenaDDL(ddlParentescos, "DescParentesco", "IdParentesco", oPatentesco.ObtenTodos(), IdParentesco)
        Else
            LlenaDDL(ddlParentescos, "DescParentesco", "IdParentesco", oPatentesco.ObtenPorSexo(CType(ddlSexos.SelectedValue, Byte)), IdParentesco)
        End If
    End Sub
    Private Sub BindEstados(Optional ByVal IdEdo As String = "30")
        Dim oEstado As New Estado
        LlenaDDL(ddlEstados, "NomEdo", "IdEdo", oEstado.ObtenTodos, IdEdo)
    End Sub
    Private Sub BindPrioridadCalculo(ByVal pTipoOperacion As String, ByVal pCopia As Boolean, _
                                     Optional ByVal pIdBeneficiario As Short = 0, _
                                     Optional ByVal IdPrioridadCalculo As String = Nothing)
        Dim oEmp As New BeneficiariosPensionAlimenticia
        ' Dim txtbxRFC As TextBox '= CType(Me.wucBuscaEmps.FindControl("txtbxRFC"), TextBox)
        'LlenaDDL(ddlPrioridadCalculo, "PrioridadCalculo", "IdPrioridadCalculo", _
        '         oEmp.ObtenListaDePrioridadDeCalculo(txtbxRFC.Text, pTipoOperacion, pIdBeneficiario, pCopia), IdPrioridadCalculo)

        If IdPrioridadCalculo Is Nothing = False Then
            If ddlPrioridadCalculo.Items.FindByValue(IdPrioridadCalculo) Is Nothing = False Then
                ddlPrioridadCalculo.SelectedValue = IdPrioridadCalculo
            End If
        End If
        ddlPrioridadCalculo.Visible = True
    End Sub
    Private Sub BindPlantelesParaPago(Optional ByVal IdPlantel As String = Nothing)
        Dim oPlantel As New Plantel
        LlenaDDL(ddlPlanteles, "Plantel2", "IdPlantel", oPlantel.ObtenVigentesPorQna(CShort(ddlQnaIni.SelectedValue), True), IdPlantel)
    End Sub
    Private Sub BindddlBancosTB(ByVal pTipoOperacion As String, Optional ByVal IdBanco As String = Nothing)
        Dim oBanco As New Bancos
        LlenaDDL(ddlBancosTB, "NombreCortoBanco", "IdBanco", oBanco.ObtenTodos(), IdBanco)
        ddlBancosTBSelectedIndexChanged(pTipoOperacion)
    End Sub
    Private Sub BindddlBancosTIB(ByVal pTipoOperacion As String, Optional ByVal IdBanco As String = Nothing)
        Dim oBanco As New Bancos
        LlenaDDL(ddlBancosTIB, "NombreCortoBanco", "IdBanco", oBanco.ObtenTodos(True), IdBanco)
        ddlBancosTIBSelectedIndexChanged(pTipoOperacion)
    End Sub
    Private Sub BindddlBancosParaDispersion(Optional ByVal IdBanco As String = Nothing)
        Dim oBanco As New Bancos
        LlenaDDL(ddlBancosParaDispersion, "NombreCortoBanco", "IdBanco", oBanco.ObtenTodos(), IdBanco)
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
    End Sub
    Protected Sub ddlQnaIni_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlQnaIni.SelectedIndexChanged
        Dim oQna As New Quincenas

        LlenaDDL(ddlQnaFin, "Quincena", "IdQuincena", oQna.ObtenParaVigFin(CType(ddlQnaIni.SelectedValue, Short), True), Nothing)
        BindPlantelesParaPago(ddlPlanteles.SelectedValue)
    End Sub
    Protected Sub btnCrearBenef_Click(sender As Object, e As System.EventArgs) Handles btnCrearBenef.Click
        Dim vlTipoOperacion As String = "1"
        GuardaInformacion(vlTipoOperacion)
    End Sub
    Protected Sub chkbxTransBanc_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkbxTransBanc.CheckedChanged
        chkbxTransBancCheckedChanged()
    End Sub
    Protected Sub ddlBancosTB_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlBancosTB.SelectedIndexChanged
        ddlBancosTBSelectedIndexChanged("4")
    End Sub
    Protected Sub chkbxTransInterBanc_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkbxTransInterBanc.CheckedChanged
        chkbxTransInterBancCheckedChanged()
    End Sub
    Private Sub ddlBancosTIBSelectedIndexChanged(ByVal pTipoOperacion As String)
        Dim oBanco As New Bancos
        Dim dr As DataRow
        Dim array() As String

        dr = oBanco.ObtenPorId(CByte(ddlBancosTIB.SelectedValue), True)

        If pTipoOperacion = "1" Then
            txtbxCtaTIB.Text = String.Empty
        End If

        txtbxCtaTIB.Enabled = chkbxTransInterBanc.Checked
        If txtbxCtaTIB.Enabled = False Then
            txtbxCtaTIB_REV.Enabled = False
            txtbxCtaTIB_RFV.Enabled = False
        Else
            txtbxCtaTIB_REV.Enabled = True
            txtbxCtaTIB_RFV.Enabled = True
            array = dr("LongitudCuenta").ToString.Split(",")
            txtbxCtaTIB_REV.ValidationExpression = "\d{" + dr("LongitudCuenta").ToString + "}"
            txtbxCtaTIB.MaxLength = CInt(array(array.Length - 1))
            txtbxCtaTIB_REV.ToolTip = "La longitud de la cuenta para la transferencia interbancaria debe ser de " + dr("LongitudCuenta").ToString + " dígitos."
        End If
    End Sub
    Protected Sub ddlBancosTIB_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlBancosTIB.SelectedIndexChanged
        ddlBancosTIBSelectedIndexChanged("4")
    End Sub
    Protected Sub txtbxCtaTIB_TextChanged(sender As Object, e As System.EventArgs) Handles txtbxCtaTIB.TextChanged
        Dim oBanco As New Bancos
        Dim drBanco As DataRow
        Dim vlNumBancoCLABE As String = "000"

        If txtbxCtaTIB.Text.Trim.Length >= 3 Then vlNumBancoCLABE = Left(txtbxCtaTIB.Text.Trim, 3)

        drBanco = oBanco.ObtenPorNumBancoCLABE(vlNumBancoCLABE, True)

        If drBanco Is Nothing = False Then
            ddlBancosTIB.SelectedValue = drBanco("IdBanco").ToString
        Else
            ddlBancosTIB.SelectedValue = "4"
        End If

    End Sub
    Protected Sub lbContinuar_Click(sender As Object, e As System.EventArgs) Handles lbContinuar.Click
        'BindgvPensionados()
        MultiView1.SetActiveView(viewBenef)
    End Sub
    Protected Sub chbxMostrarOcultarTips_CheckedChanged(sender As Object, e As System.EventArgs) Handles chbxMostrarOcultarTips.CheckedChanged
        Muestra_Oculta_Ayuda(chbxMostrarOcultarTips.Checked, Page)
    End Sub
    Protected Sub ibVerDetalles_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs)
        Dim gvrBenefPA As GridViewRow = CType(sender.NamingContainer, GridViewRow)
        Dim lblIdBeneficiario As Label = CType(gvrBenefPA.FindControl("lblIdBeneficiario"), Label)
        Dim vlIdBeneficiario As Short = CShort(lblIdBeneficiario.Text)
        Dim drBenefPA As DataRow = Nothing
        Dim oBenefPA As New BeneficiariosPensionAlimenticia
        'Dim hfNomEmp As HiddenField '= CType(wucBuscaEmps.FindControl("hfNomEmp"), HiddenField)

        'lblEmpInfConsulta.Text = "Consultando beneficiario de pensión alimenticia del empleado: " + IIf(hfNomEmp.Value = String.Empty, Session("ApePatParaCons") + " " + Session("ApeMatParaCons") + " " + Session("NombreParaCons"), hfNomEmp.Value)

        gvPensionados.SelectedIndex = gvrBenefPA.RowIndex

        drBenefPA = oBenefPA.ObtenPorId(vlIdBeneficiario)

        'dvBenef.DataSource = drBenefPA.Table
        'dvBenef.DataBind()

        MultiView1.SetActiveView(viewConsulta)
    End Sub
    Protected Sub btnCancelar2_Click(sender As Object, e As System.EventArgs) Handles btnCancelar2.Click
        Response.Redirect("Categorias.aspx?TipoOperacion=4")
    End Sub
    Protected Sub btnModifBenef_Click(sender As Object, e As System.EventArgs) Handles btnModifBenef.Click
        Dim vlTipoOperacion As String = "0"
        GuardaInformacion(vlTipoOperacion)
    End Sub
    Protected Sub btnContinuar_Click(sender As Object, e As System.EventArgs) Handles btnContinuar.Click
        MultiView1.SetActiveView(viewBenef)
    End Sub
    Protected Sub ibCrearCopia_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs)
        Dim gvrBenefPA As GridViewRow = CType(sender.NamingContainer, GridViewRow)
        Dim lblIdBeneficiario As Label = CType(gvrBenefPA.FindControl("lblIdBeneficiario"), Label)
        Dim vlIdBeneficiario As Short = CShort(lblIdBeneficiario.Text)
        Dim vlTipoOperacion As String = "1"

        gvPensionados.SelectedIndex = gvrBenefPA.RowIndex

        MostraraDetallesRegistro(vlIdBeneficiario, vlTipoOperacion, True)

        Muestra_Oculta_Ayuda(False, Page)

        MultiView1.SetActiveView(viewDetalles)
    End Sub
End Class
