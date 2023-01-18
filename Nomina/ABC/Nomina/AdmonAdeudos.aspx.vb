Imports DataAccessLayer.COBAEV.Empleados
Imports DataAccessLayer.COBAEV.Nominas
Imports System.Data
Imports BusinessRulesLayer.COBAEV.Validaciones
Imports DataAccessLayer.COBAEV
Partial Class ABC_Nomina_AdmonAdeudos
    Inherits System.Web.UI.Page
    Private Sub FillCargaHoraria()
        Dim oEmp As New Empleado
        'Dim hfRFC As HiddenField = CType(wucSearchEmps2.FindControl("hfRFC"), HiddenField)

        BindCargaHoraria(oEmp.ConAdeudos(Request.Params("RFC"), CShort(Request.Params("IdQnaAplicacion"))))

        oEmp.RFC = Session("RFCParaCons2") 'hfRFC.Value
        If Me.gvCargaHoraria.Rows.Count = 0 And oEmp.ObtenFuncion() = 2 Then
            Me.gvCargaHoraria.EmptyDataText = "Docente sin carga horaria definida."
            Me.gvCargaHoraria.DataBind()
        ElseIf Me.gvCargaHoraria.Rows.Count = 0 And oEmp.ObtenFuncion() = 1 Then
            Me.gvCargaHoraria.EmptyDataText = "Empleado administrativo (No se requiere carga horaria)"
            Me.gvCargaHoraria.DataBind()
        End If
    End Sub
    Private Sub BindCargaHoraria(ByVal ds As DataSet)
        Dim oEmp As New Empleado
        'Dim hfRFC As HiddenField = CType(wucSearchEmps2.FindControl("hfRFC"), HiddenField)
        Dim lblIdHora As Label
        Dim chbxHora As CheckBox
        oEmp.RFC = Session("RFCParaCons2")
        'oEmp.RFC = IIf(Session("RFCParaCons") Is Nothing, hfRFC.Value.Trim, Session("RFCParaCons"))
        If oEmp.RFC <> String.Empty Then
            Me.gvCargaHoraria.DataSource = oEmp.ObtenCargaHorariaDadaUnaQna(CType(Me.ddlQnaIni.SelectedValue, Short), CType(Me.ddlQnaFin.SelectedValue, Short))
            Me.gvCargaHoraria.DataBind()
            Me.gvCargaHoraria.SelectedIndex = -1
            If Me.gvCargaHoraria.Rows.Count > 0 Then
                Select Case Me.ddlTipoDeAdeudo.SelectedValue
                    Case "3", "5", "8" 'Carga horaria completa
                        Me.gvCargaHoraria.Columns(0).Visible = False
                    Case "4", "6", "9"
                        Me.gvCargaHoraria.Columns(0).Visible = True
                        If Request.Params("TipoOperacion") = "0" Or Request.Params("TipoOperacion") = "3" Then
                            For Each dr As DataRow In ds.Tables(1).Rows
                                For Each gvr As GridViewRow In Me.gvCargaHoraria.Rows
                                    chbxHora = CType(gvr.FindControl("chbxHora"), CheckBox)
                                    lblIdHora = CType(gvr.FindControl("lblIdHora"), Label)
                                    If lblIdHora.Text = dr("IdHora").ToString Then
                                        chbxHora.Checked = True
                                        Exit For
                                    End If
                                Next
                            Next
                        End If
                End Select
            End If
        End If
    End Sub
    Private Sub BindQnas(ByVal dr As DataRow)
        Dim oQna As New Quincenas
        Dim crItem As ListItem
        Dim dt As DataTable
        With Me.ddlQnaAplic
            .DataSource = oQna.ObtenAbiertasParaCaptura
            .DataTextField = "Quincena"
            .DataValueField = "IdQuincena"
            .DataBind()
            If .Items.Count = 0 Then
                .Items.Clear()
                .Items.Insert(0, "No hay quincenas abiertas para captura")
                .Items(0).Value = -1
                If dr Is Nothing = False Then
                    .Items.Clear()
                    .Items.Insert(0, dr("QnaAplic").ToString)
                    .Items(0).Value = dr("IdQnaAplicacion").ToString
                    With Me.ddlQnaIni
                        .Items.Clear()
                        .Items.Insert(0, dr("QnaIni").ToString)
                        .Items(0).Value = dr("IdQnaIni").ToString
                    End With
                    With Me.ddlQnaFin
                        .Items.Clear()
                        .Items.Insert(0, dr("QnaFin").ToString)
                        .Items(0).Value = dr("IdQnaFin").ToString
                    End With
                End If
            Else
                If Request.Params("TipoOperacion") = "0" Or Request.Params("TipoOperacion") = "3" Then
                    crItem = .Items.FindByValue(Request.Params("IdQnaAplicacion"))
                    If crItem Is Nothing Then
                        Me.hfNoGuardar.Value = 0
                        Me.lblFinalizar.Text = "No se podrá realizar la operación, lo sentimos."
                        .Items.Clear()
                        .Items.Insert(0, dr("QnaAplic").ToString)
                        .Items(0).Value = dr("IdQnaAplicacion").ToString
                        With Me.ddlQnaIni
                            .Items.Clear()
                            .Items.Insert(0, dr("QnaIni").ToString)
                            .Items(0).Value = dr("IdQnaIni").ToString
                        End With
                        With Me.ddlQnaFin
                            .Items.Clear()
                            .Items.Insert(0, dr("QnaFin").ToString)
                            .Items(0).Value = dr("IdQnaFin").ToString
                        End With
                    Else
                        .SelectedValue = Request.Params("IdQnaAplicacion")
                        With Me.ddlQnaIni
                            .Items.Clear()
                            .Items.Insert(0, dr("QnaIni").ToString)
                            .Items(0).Value = dr("IdQnaIni").ToString
                        End With
                        With Me.ddlQnaFin
                            .Items.Clear()
                            .Items.Insert(0, dr("QnaFin").ToString)
                            .Items(0).Value = dr("IdQnaFin").ToString
                        End With
                    End If
                    Me.hfQnaAplic.Value = Me.ddlQnaAplic.SelectedValue
                Else
                    oQna.IdQuincena = CShort(Me.ddlQnaAplic.SelectedValue)
                    dt = oQna.ObtenAnteriorNoAdic()
                    With Me.ddlQnaIni
                        .DataSource = dt
                        .DataTextField = "Quincena"
                        .DataValueField = "IdQuincena"
                        .DataBind()
                    End With
                    With Me.ddlQnaFin
                        .DataSource = dt
                        .DataTextField = "Quincena"
                        .DataValueField = "IdQuincena"
                        .DataBind()
                    End With
                End If
            End If
        End With
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim txtbxRFC As TextBox = CType(wucSearchEmps2.FindControl("txtbxRFC"), TextBox)
        'Dim txtbxNomEmp As TextBox = CType(wucSearchEmps2.FindControl("txtbxNomEmp"), TextBox)
        'Dim hfRFC As HiddenField = CType(wucSearchEmps2.FindControl("hfRFC"), HiddenField)
        'Dim hfNomEmp As HiddenField = CType(wucSearchEmps2.FindControl("hfNomEmp"), HiddenField)
        'Dim txtbxNumEmp As TextBox = CType(wucSearchEmps2.FindControl("txtbxNumEmp"), TextBox)
        'Dim hfNumEmp As HiddenField = CType(wucSearchEmps2.FindControl("hfNumEmp"), HiddenField)
        Dim dr As DataRow = Nothing
        If Not IsPostBack Then
            Response.Expires = 0
            Me.MultiView1.SetActiveView(Me.viewOperacion)
            Me.Wizard1.ActiveStepIndex = 0
            Dim BtnSearch As Button = CType(Me.wucSearchEmps2.FindControl("BtnSearch"), Button)
            Dim BtnNewSearch As Button = CType(Me.wucSearchEmps2.FindControl("BtnNewSearch"), Button)
            Dim BtnCancelSearch As Button = CType(Me.wucSearchEmps2.FindControl("BtnCancelSearch"), Button)
            If Request.Params("TipoOperacion") = "0" Or Request.Params("TipoOperacion") = "3" Then
                Dim oEmp As New Empleado
                dr = oEmp.ConAdeudos(Request.Params("RFC"), CShort(Request.Params("IdQnaAplicacion"))).Tables(0).Rows(0)
                Session.Add("RFCParaCons2", dr("RFCEmp").ToString.Trim)
                Session.Add("ApePatParaCons2", dr("ApePatEmp").ToString.Trim)
                Session.Add("ApeMatParaCons2", dr("ApeMatEmp").ToString.Trim)
                Session.Add("NombreParaCons2", dr("NomEmp").ToString.Trim)
                Session.Add("NumEmpParaCons2", dr("NumEmp").ToString.Trim)
                'txtbxRFC.Text = dr("RFCEmp").ToString.Trim
                'hfRFC.Value = dr("RFCEmp").ToString.Trim
                'txtbxNomEmp.Text = dr("ApePatEmp").ToString.Trim + " " + dr("ApeMatEmp").ToString.Trim + " " + dr("NomEmp").ToString.Trim
                'hfNomEmp.Value = txtbxNomEmp.Text
                'txtbxNumEmp.Text = dr("NumEmp").ToString.Trim
                'hfNumEmp.Value = txtbxNumEmp.Text
                'Session.Add("NoLimpiar", "Ok")
                'Session.Add("IdTipoAdeudo", "Ok")
                BtnSearch.Visible = False
                BtnNewSearch.Visible = False
                BtnCancelSearch.Visible = False
                If Request.Params("TipoOperacion") = "0" Then
                    Me.Wizard1.FinishCompleteButtonText = "Actualizar"
                Else
                    Me.Wizard1.ActiveStepIndex = 4
                    Me.Wizard1.HeaderText = "Finalizar operación"
                    Me.Wizard1.WizardSteps(4).AllowReturn = False
                    Me.Wizard1.FinishCompleteButtonText = "Eliminar"
                End If
            ElseIf Request.Params("TipoOperacion") = "1" Then
                Session.Remove("RFCParaCons2")
                Session.Remove("ApePatParaCons2")
                Session.Remove("ApeMatParaCons2")
                Session.Remove("NombreParaCons2")
                Session.Remove("NumEmpParaCons2")
                'Session.Add("NoLlenar", "Ok")
                'ibBuscarEmp.Attributes.Add("onclick", "javascript:abreVentanaBuscaEmpsDesdeWebForms('../../Busquedas/Empleados.aspx?LlamadoDesde=DatosPersonales','" + txtbxRFC.ClientID + "','" + txtbxNomEmp.ClientID + "','" + hfRFC.ClientID + "','" + hfNomEmp.ClientID + "'); return false")
                'ibBuscarEmp.Attributes.Add("onclick", "javascript:abreVentanaBuscaEmpsDesdeWebForms('../../Busquedas/Empleados.aspx?LlamadoDesde=DatosPersonales','" + txtbxRFC.ClientID + "','" + txtbxNomEmp.ClientID + "','" + hfRFC.ClientID + "','" + hfNomEmp.ClientID + "','" + txtbxNumEmp.ClientID + "','" + hfNumEmp.ClientID + "'); return false")
            End If
            BindQnas(dr)
            Me.lbCerrar.OnClientClick = "javascript:window.close();"
        Else
            If Request.Params("TipoOperacion") = "0" Or Request.Params("TipoOperacion") = "3" Then
                'Session.Add("NoLimpiar", "Ok")
            Else
                'If hfRFC.Value = "" Then
                '    'Session.Add("NoLlenar", "Ok")
                '    Session.Remove("RFCParaCons2")
                '    Session.Remove("ApePatParaCons2")
                '    Session.Remove("ApeMatParaCons2")
                '    Session.Remove("NombreParaCons2")
                '    Session.Remove("NumEmpParaCons2")
                'End If
            End If
        End If
    End Sub

    Protected Sub lbContinuar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbContinuar.Click
        Me.pnlError.Visible = False
        Me.Wizard1.Visible = True
    End Sub

    Protected Sub ddlQnaAplic_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlQnaAplic.SelectedIndexChanged
        Dim oQna As New Quincenas
        Dim dt As DataTable
        oQna.IdQuincena = CShort(Me.ddlQnaAplic.SelectedValue)
        dt = oQna.ObtenAnteriorNoAdic()
        With Me.ddlQnaIni
            .DataSource = dt
            .DataTextField = "Quincena"
            .DataValueField = "IdQuincena"
            .DataBind()
        End With
        With Me.ddlQnaFin
            .DataSource = dt
            .DataTextField = "Quincena"
            .DataValueField = "IdQuincena"
            .DataBind()
        End With
        If gvQnasDias.Visible Then
            Dim oEmp As New Empleado
            Me.gvQnasDias.DataSource = oEmp.CreaTablaParaEspecificarDias(CShort(Me.ddlQnaIni.SelectedValue), CShort(Me.ddlQnaFin.SelectedValue), True)
            Me.gvQnasDias.DataBind()
            Me.gvQnasDias.Visible = True
        End If
    End Sub

    Protected Sub btnUpdQnaIni_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdQnaIni.Click
        Dim oQna As New Quincenas
        oQna.IdQuincena = CShort(Me.ddlQnaFin.SelectedValue)
        With Me.ddlQnaIni
            .DataSource = oQna.ObtenIniParaAdeudo(CByte(Me.txtbxNumQnas.Text))
            .DataTextField = "Quincena"
            .DataValueField = "IdQuincena"
            .DataBind()
        End With
        If gvQnasDias.Visible Then
            Dim oEmp As New Empleado
            Me.gvQnasDias.DataSource = oEmp.CreaTablaParaEspecificarDias(CShort(Me.ddlQnaIni.SelectedValue), CShort(Me.ddlQnaFin.SelectedValue), True)
            Me.gvQnasDias.DataBind()
            Me.gvQnasDias.Visible = True
        End If
    End Sub

    Protected Sub btnUpdQnaFin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdQnaFin.Click
        Dim oQna As New Quincenas
        If Me.txtbxQnasARestar.Text <> String.Empty Then
            oQna.IdQuincena = CShort(Me.ddlQnaFin.SelectedValue)
            With Me.ddlQnaFin
                .DataSource = oQna.ObtenIniParaAdeudo(CByte(Me.txtbxQnasARestar.Text) + 1)
                .DataTextField = "Quincena"
                .DataValueField = "IdQuincena"
                .DataBind()
            End With
        End If
        oQna.IdQuincena = CShort(Me.ddlQnaFin.SelectedValue)
        With Me.ddlQnaIni
            .DataSource = oQna.ObtenIniParaAdeudo(CByte(Me.txtbxNumQnas.Text))
            .DataTextField = "Quincena"
            .DataValueField = "IdQuincena"
            .DataBind()
        End With
        If gvQnasDias.Visible Then
            Dim oEmp As New Empleado
            Me.gvQnasDias.DataSource = oEmp.CreaTablaParaEspecificarDias(CShort(Me.ddlQnaIni.SelectedValue), CShort(Me.ddlQnaFin.SelectedValue), True)
            Me.gvQnasDias.DataBind()
            Me.gvQnasDias.Visible = True
        End If
    End Sub

    Protected Sub btnRest_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRest.Click
        Dim oEmp As Empleado
        Dim dr As DataRow
        If Request.Params("TipoOperacion") = "1" Then
            BindQnas(Nothing)
        ElseIf (Request.Params("TipoOperacion") = "0" Or Request.Params("TipoOperacion") = "3") Then
            oEmp = New Empleado
            dr = oEmp.ConAdeudos(Request.Params("RFC"), CShort(Request.Params("IdQnaAplicacion"))).Tables(0).Rows(0)
            BindQnas(dr)
        End If
        'If gvQnasDias.Visible Then
        '    oEmp = New Empleado
        '    Me.gvQnasDias.DataSource = oEmp.CreaTablaParaEspecificarDias(CShort(Me.ddlQnaIni.SelectedValue), CShort(Me.ddlQnaFin.SelectedValue))
        '    Me.gvQnasDias.DataBind()
        '    Me.gvQnasDias.Visible = True
        'End If
        If gvQnasDias.Visible Then
            If Request.Params("TipoOperacion") = "0" Then
                oEmp = New Empleado
                Me.gvQnasDias.DataSource = oEmp.ConAdeudos(Request.Params("RFC"), CShort(Request.Params("IdQnaAplicacion"))).Tables(2)
                Me.gvQnasDias.DataBind()
                Me.gvQnasDias.Visible = True
            ElseIf Request.Params("TipoOperacion") = "1" Then
                oEmp = New Empleado
                Me.gvQnasDias.DataSource = oEmp.CreaTablaParaEspecificarDias(CShort(Me.ddlQnaIni.SelectedValue), CShort(Me.ddlQnaFin.SelectedValue), True)
                Me.gvQnasDias.DataBind()
                Me.gvQnasDias.Visible = True
            End If
        End If
    End Sub

    Protected Sub Wizard1_NextButtonClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.WizardNavigationEventArgs)
        'Dim hfRFC As HiddenField = CType(wucSearchEmps2.FindControl("hfRFC"), HiddenField)

        Dim oEmp As Empleado
        Dim Cont As Byte = 0
        Dim dr As DataRow = Nothing
        Select Case e.CurrentStepIndex
            Case 0 'Empleado
                'If hfRFC.Value = String.Empty Then
                If Session("RFCParaCons2") Is Nothing Then
                    e.Cancel = True
                Else
                    Me.Wizard1.HeaderText = "Tipo de adeudo"
                    Select Case e.NextStepIndex
                        Case 1
                            Dim oValue As String = String.Empty
                            'Dim crItem As ListItem
                            'If Me.ddlTipoDeAdeudo.Items.Count > 0 Then oValue = Me.ddlTipoDeAdeudo.SelectedValue
                            Dim oTipoAdeudo As New TiposDeAdeudos
                            If ddlTipoDeAdeudo.Items.Count = 0 Then
                                With Me.ddlTipoDeAdeudo
                                    .Items.Clear()
                                    .DataSource = oTipoAdeudo.ObtenPorFuncionDelEmpleado(Session("RFCParaCons2")) '(hfRFC.Value)
                                    .DataTextField = "TipoAdeudo"
                                    .DataValueField = "IdTipoAdeudo"
                                    .DataBind()
                                    If (Request.Params("TipoOperacion") = "0" Or Request.Params("TipoOperacion") = "3") Then
                                        oEmp = New Empleado
                                        dr = oEmp.ConAdeudos(Request.Params("RFC"), CShort(Request.Params("IdQnaAplicacion"))).Tables(0).Rows(0)
                                        ddlTipoDeAdeudo.SelectedValue = dr("IdTipoAdeudo").ToString
                                        'Session.Remove("IdTipoDevolucion")
                                    End If
                                    'crItem = .Items.FindByValue(oValue)
                                    'If crItem Is Nothing = False Then
                                    '    .SelectedValue = oValue
                                    'End If
                                End With
                            End If
                            'If (Request.Params("TipoOperacion") = "0" Or Request.Params("TipoOperacion") = "3") And Session("IdTipoAdeudo") Is Nothing = False Then
                            '    oEmp = New Empleado
                            '    dr = oEmp.ConAdeudos(Request.Params("RFC"), CShort(Request.Params("IdQnaAplicacion"))).Tables(0).Rows(0)
                            '    Me.ddlTipoDeAdeudo.SelectedValue = dr("IdTipoAdeudo").ToString
                            '    Session.Remove("IdTipoAdeudo")
                            'End If
                    End Select
                End If
            Case 1
                Me.Wizard1.HeaderText = "Período"
                Select Case Me.ddlTipoDeAdeudo.SelectedValue
                    Case "2", "5", "6" 'Días y/o quincenas completas, Días y/o quincenas completas (Carga horaria completa), Días y/o quincenas completas (Solo algunas horas)
                        'Dim oEmp As Empleado
                        If Request.Params("TipoOperacion") = "0" Then
                            oEmp = New Empleado
                            Me.gvQnasDias.DataSource = oEmp.ConAdeudos(Request.Params("RFC"), CShort(Request.Params("IdQnaAplicacion"))).Tables(3)
                            Me.gvQnasDias.DataBind()
                            Me.gvQnasDias.Visible = True
                        ElseIf Request.Params("TipoOperacion") = "1" Then
                            oEmp = New Empleado
                            Me.gvQnasDias.DataSource = oEmp.CreaTablaParaEspecificarDias(CShort(Me.ddlQnaIni.SelectedValue), CShort(Me.ddlQnaFin.SelectedValue), True)
                            Me.gvQnasDias.DataBind()
                            Me.gvQnasDias.Visible = True
                        End If
                        '    Me.chbxNumDias.Enabled = True
                    Case Else
                        'Me.chbxNumDias.Enabled = False
                        Me.gvQnasDias.Visible = False
                        'If Request.Params("TipoOperacion") = "1" Then
                        '    Me.chbxNumDias.Checked = False
                        'End If
                End Select
            Case 2 'Período
                Me.Wizard1.HeaderText = "Carga horaria"
                Select Case e.NextStepIndex
                    Case 3 'Carga horaria
                        FillCargaHoraria()
                End Select
            Case 3 'Carga horaria
                oEmp = New Empleado
                oEmp.RFC = Session("RFCParaCons2") 'hfRFC.Value
                If Me.gvCargaHoraria.Rows.Count = 0 And oEmp.ObtenFuncion() = 2 Then
                    e.Cancel = True
                    Exit Select
                End If
                Select Case Me.ddlTipoDeAdeudo.SelectedValue
                    Case "4", "6" 'Por horas
                        For Each gvr As GridViewRow In Me.gvCargaHoraria.Rows
                            If CType(gvr.FindControl("chbxHora"), CheckBox).Checked Then
                                Cont += 1
                            End If
                        Next
                        If Cont = Me.gvCargaHoraria.Rows.Count Or Cont = 0 Then
                            e.Cancel = True
                            Exit Select
                        End If
                    Case Else
                        Me.Wizard1.HeaderText = "Finalizar operación"
                End Select
        End Select
    End Sub

    Protected Sub Wizard1_SideBarButtonClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.WizardNavigationEventArgs)
        e.Cancel = True
    End Sub

    Protected Sub Wizard1_FinishButtonClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.WizardNavigationEventArgs)
        Try
            If Me.hfNoGuardar.Value = 0 Then
                e.Cancel = True
                Exit Sub
            End If
            'Dim hfRFC As HiddenField = CType(wucSearchEmps2.FindControl("hfRFC"), HiddenField)

            Dim oValidacion As New Validaciones
            Dim _DataCOBAEV As New DataCOBAEV
            Dim dsValida As DataSet
            dsValida = _DataCOBAEV.setDataSetErrores()

            With oValidacion
                .NombrePagina = Request.Url.Segments(Request.Url.Segments.Length - 1).ToString
                .RFC = Session("RFCParaCons2") 'hfRFC.Value
                .TipoOperacion = IIf(Request.Params("TipoOperacion") Is Nothing, 5, CByte(Request.Params("TipoOperacion")))
                If Not .ValidaPaginasOperacion(dsValida) Then
                    Session.Add("dsValida", dsValida)
                    Response.Redirect("~/ErroresPagina2.aspx")
                Else
                    Session.Remove("dsValida")
                End If
            End With

            Dim oEmp As New Empleado
            Dim IdQnaIni, IdQnaFin, IdQnaAplicacion, IdQuincena As Short
            Dim IdTipoAdeudo, NumDias As Byte
            Dim lblIdHora As Label
            Dim chbxHora As CheckBox
            oEmp.RFC = Session("RFCParaCons2") 'hfRFC.Value
            If Request.Params("TipoOperacion") <> "3" Then
                IdQnaIni = CShort(Me.ddlQnaIni.SelectedValue)
                IdQnaFin = CShort(Me.ddlQnaFin.SelectedValue)
                IdQnaAplicacion = CShort(Me.ddlQnaAplic.SelectedValue)
                IdTipoAdeudo = CByte(Me.ddlTipoDeAdeudo.SelectedValue)
            End If
            If Request.Params("TipoOperacion") = "1" Then
                oEmp.InsertaAdeudo(IdQnaIni, IdQnaFin, IdQnaAplicacion, IdTipoAdeudo, CType(Session("ArregloAuditoria"), String()))
                Select Case Me.ddlTipoDeAdeudo.SelectedValue
                    Case "2", "5", "6" 'Días y/o quincenas completas, Días y/o quincenas completas (Carga horaria completa), Días y/o quincenas completas (Solo algunas horas)
                        For Each gvr As GridViewRow In Me.gvQnasDias.Rows
                            NumDias = CByte(CType(gvr.FindControl("txtbxNumDias"), TextBox).Text)
                            IdQuincena = CShort(CType(gvr.FindControl("lblIdQuincena"), Label).Text)
                            oEmp.UpdNumDiasAdeudo(IdQuincena, IdQnaAplicacion, NumDias, CType(Session("ArregloAuditoria"), String()))
                        Next
                End Select
                If oEmp.ObtenFuncion() = 2 Then
                    For Each gvr As GridViewRow In Me.gvCargaHoraria.Rows
                        If Me.gvCargaHoraria.Columns(0).Visible = True Then 'Por horas
                            chbxHora = CType(gvr.FindControl("chbxHora"), CheckBox)
                        Else
                            chbxHora = New CheckBox
                            chbxHora.Checked = False
                        End If
                        lblIdHora = CType(gvr.FindControl("lblIdHora"), Label)
                        Dim ArregloAuditoria(2) As String

                        ArregloAuditoria(0) = Request.ServerVariables("REMOTE_ADDR")
                        ArregloAuditoria(1) = Session("Login")

                        oEmp.ABCHoraAdeudo(CInt(lblIdHora.Text), CShort(IdQnaAplicacion), chbxHora.Checked, ArregloAuditoria)
                    Next
                End If
            ElseIf Request.Params("TipoOperacion") = "0" Then
                oEmp.UpdAdeudo(IdQnaIni, IdQnaFin, IdQnaAplicacion, CShort(Me.hfQnaAplic.Value), IdTipoAdeudo, CType(Session("ArregloAuditoria"), String()))
                Select Case Me.ddlTipoDeAdeudo.SelectedValue
                    Case "2", "5", "6" 'Días y/o quincenas completas, Días y/o quincenas completas (Carga horaria completa), Días y/o quincenas completas (Solo algunas horas) 
                        For Each gvr As GridViewRow In Me.gvQnasDias.Rows
                            NumDias = CByte(CType(gvr.FindControl("txtbxNumDias"), TextBox).Text)
                            IdQuincena = CShort(CType(gvr.FindControl("lblIdQuincena"), Label).Text)
                            oEmp.UpdNumDiasAdeudo(IdQuincena, IdQnaAplicacion, NumDias, CType(Session("ArregloAuditoria"), String()))
                        Next
                End Select
                If oEmp.ObtenFuncion() = 2 Then
                    For Each gvr As GridViewRow In Me.gvCargaHoraria.Rows
                        If Me.gvCargaHoraria.Columns(0).Visible = True Then 'Por horas
                            chbxHora = CType(gvr.FindControl("chbxHora"), CheckBox)
                        Else
                            chbxHora = New CheckBox
                            chbxHora.Checked = False
                        End If
                        lblIdHora = CType(gvr.FindControl("lblIdHora"), Label)
                        oEmp.ABCHoraAdeudo(CInt(lblIdHora.Text), CShort(IdQnaAplicacion), chbxHora.Checked, CType(Session("ArregloAuditoria"), String()))
                    Next
                End If
            ElseIf Request.Params("TipoOperacion") = "3" Then
                FillCargaHoraria()
                oEmp.DelAdeudo(CShort(Request.Params("IdQnaAplicacion")), CType(Session("ArregloAuditoria"), String()))
                If oEmp.ObtenFuncion() = 2 Then
                    For Each gvr As GridViewRow In Me.gvCargaHoraria.Rows
                        chbxHora = New CheckBox
                        chbxHora.Checked = False
                        lblIdHora = CType(gvr.FindControl("lblIdHora"), Label)
                        oEmp.ABCHoraAdeudo(CInt(lblIdHora.Text), CShort(Request.Params("IdQnaAplicacion")), chbxHora.Checked, CType(Session("ArregloAuditoria"), String()))
                    Next
                End If
            End If
            Me.Wizard1.Visible = False
            Me.pnlExito.Visible = True
        Catch Ex As Exception
            Me.lblError.Text = Ex.Message
            Me.Wizard1.Visible = False
            Me.pnlError.Visible = True
            Me.lbContinuar.Visible = False
        End Try
    End Sub

    Protected Sub Wizard1_PreviousButtonClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.WizardNavigationEventArgs)
        Select Case e.CurrentStepIndex
            Case 1
                Me.Wizard1.HeaderText = "Empleado"
            Case 2
                Me.Wizard1.HeaderText = "Tipo de adeudo"
            Case 3
                Me.Wizard1.HeaderText = "Período"
            Case 4
                If Request.Params("TipoOperacion") = "3" Then
                    e.Cancel = True
                Else
                    Me.Wizard1.HeaderText = "Carga horaria"
                End If
        End Select
    End Sub

End Class
