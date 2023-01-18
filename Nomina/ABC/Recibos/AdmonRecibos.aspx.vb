Imports DataAccessLayer.COBAEV.Empleados
Imports System.Data
Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV
Imports DataAccessLayer.COBAEV.Administracion
Imports BusinessRulesLayer.COBAEV.Validaciones
Partial Class ABC_Recibos_AdmonRecibos
    Inherits System.Web.UI.Page
    Private Sub AplicaValidaciones()
        Dim oValidacion As New Validaciones
        Dim _DataCOBAEV As New DataCOBAEV
        Dim dsValida As DataSet
        dsValida = _DataCOBAEV.setDataSetErrores()

        With oValidacion
            .NombrePagina = Request.Url.Segments(Request.Url.Segments.Length - 1).ToString

            .TipoOperacion = IIf(Request.Params("TipoOperacion") Is Nothing, 5, CByte(Request.Params("TipoOperacion")))

            If Not .ValidaPaginasOperacion(dsValida) Then
                Session.Add("dsValida", dsValida)
                Response.Redirect("~/ErroresPagina2.aspx")
            Else
                Session.Remove("dsValida")
            End If
        End With
    End Sub
    Private Sub BinddvRecibo()
        Dim oRecibo As New Recibos
        Dim dt As DataTable = Nothing
        Dim oNomina As New Nomina
        Dim drFecha As DataRow
        Dim oQna As New Quincenas
        Dim oUsr As New Usuario

        If Request.Params("TipoOperacion") = "0" Then
            oRecibo.IdRecibo = CShort(Request.Params("IdRecibo"))
            dt = oRecibo.ObtenPorId()
            Me.dvRecibo.DataSource = dt
        ElseIf Request.Params("TipoOperacion") = "1" Then
            Me.dvRecibo.DataSource = oRecibo.ObtenDatosProbables
        ElseIf Request.Params("TipoOperacion") = "3" Then
            oRecibo.IdRecibo = CShort(Request.Params("IdRecibo"))
            dt = oRecibo.ObtenPorId()
            Me.dvRecibo.DataSource = dt
            Me.dvRecibo.Visible = False
        End If
        Me.dvRecibo.DataBind()

        Dim ddlNombre As DropDownList = CType(Me.dvRecibo.FindControl("ddlNombre"), DropDownList)
        Dim ddlQuincena As DropDownList = CType(Me.dvRecibo.FindControl("ddlQuincena"), DropDownList)
        Dim ddlFondosPresup As DropDownList = CType(Me.dvRecibo.FindControl("ddlFondosPresup"), DropDownList)
        Dim txtbxQnaIni As TextBox = CType(Me.dvRecibo.FindControl("txtbxQnaIni"), TextBox)
        Dim txtbxQnaFin As TextBox = CType(Me.dvRecibo.FindControl("txtbxQnaFin"), TextBox)
        Dim ChckBxImplicaAdeudo As CheckBox = CType(Me.dvRecibo.FindControl("ChckBxImplicaAdeudo"), CheckBox)
        Dim txtbxFechaIniQna As TextBox = CType(Me.dvRecibo.FindControl("txtbxFechaIniQna"), TextBox)
        Dim tbFecha_CV As CompareValidator = CType(Me.dvRecibo.FindControl("tbFecha_CV"), CompareValidator)
        Dim ChckBxIgnorarEmpParaPasivos As CheckBox = CType(Me.dvRecibo.FindControl("ChckBxIgnorarEmpParaPasivos"), CheckBox)
        Dim ChckBxIgnorarParaDecAnual As CheckBox = CType(Me.dvRecibo.FindControl("ChckBxIgnorarParaDecAnual"), CheckBox)
        Dim ChckBxReciboDeSustitucion As CheckBox = CType(Me.dvRecibo.FindControl("ChckBxReciboDeSustitucion"), CheckBox)
        Dim ChckBxReciboTimbrado As CheckBox = CType(Me.dvRecibo.FindControl("ChckBxReciboTimbrado"), CheckBox)
        Dim pnlAdeudos As Panel = CType(Me.dvRecibo.FindControl("pnlAdeudo"), Panel)
        Dim ddlAnioPasivos As DropDownList = CType(Me.dvRecibo.FindControl("ddlAnioPasivos"), DropDownList)
        Dim ChkBeneficiario As CheckBox = CType(Me.dvRecibo.FindControl("chkBeneficiario"), CheckBox)
        Dim ddlBeneficiario As DropDownList = CType(Me.dvRecibo.FindControl("ddlBeneficiario"), DropDownList)
        Dim pnlBeneficiario As Panel = CType(Me.dvRecibo.FindControl("pnlBeneficiario"), Panel)



        ChckBxIgnorarEmpParaPasivos.Enabled = False
        ChckBxIgnorarParaDecAnual.Enabled = False
        ChckBxReciboDeSustitucion.Enabled = True
        ChckBxReciboTimbrado.Enabled = False
        ChkBeneficiario.Enabled = False

        If oUsr.EsVIP(Session("Login")) Or oUsr.EsAdministrador(Session("Login")) Then
            ChckBxIgnorarEmpParaPasivos.Enabled = True
            ChckBxIgnorarParaDecAnual.Enabled = True
            ChckBxReciboTimbrado.Enabled = True
        End If

        If Request.Params("TipoOperacion") = "0" Or Request.Params("TipoOperacion") = "3" Then
            ddlNombre.Items.Insert(0, dt.Rows(0).Item("NomEmp").ToString)
            ddlNombre.Items(0).Value = dt.Rows(0).Item("IdEmp").ToString
            ddlQuincena.Items.Insert(0, dt.Rows(0).Item("Quincena").ToString)
            ddlQuincena.Items(0).Value = dt.Rows(0).Item("IdQuincenaAplicacion").ToString

            drFecha = oQna.ObtenFechaInioFinQna(CShort(ddlQuincena.SelectedValue), "I")

            tbFecha_CV.ValueToCompare = drFecha("Fecha").ToString
            txtbxFechaIniQna.Text = drFecha("Fecha").ToString

            LlenaDDL(ddlFondosPresup, "DescFondoPresup", "IdFondoPresup", oNomina.GetFondosPresupuestales(), dt.Rows(0).Item("IdFondoPresup").ToString)
            LlenaDDL(ddlAnioPasivos, "DescEjercicio", "idAnio", oNomina.GetEjerciciosAnteriores, dt.Rows(0).Item("AnioPasivos").ToString)
            LlenaDDL(ddlBeneficiario, "NombreBeneficiario", "idBeneficiario", oRecibo.ObtenBeneficiarios(oRecibo.IdRecibo, ddlNombre.Items(0).Value), dt.Rows(0).Item("IdBeneficiario").ToString)
            ChckBxImplicaAdeudo.Checked = dt.Rows(0).Item("IdQnaIniAdeudo") <> dt.Rows(0).Item("IdQnaFinAdeudo")

            pnlAdeudos.Enabled = ChckBxImplicaAdeudo.Checked
            txtbxQnaIni.Text = dt.Rows(0).Item("QnaIniAdeudo").ToString
            txtbxQnaFin.Text = dt.Rows(0).Item("QnaFinAdeudo").ToString

            ChckBxIgnorarEmpParaPasivos.Checked = dt.Rows(0).Item("IgnorarEmpParaPasivos")
            ChckBxIgnorarParaDecAnual.Checked = dt.Rows(0).Item("IgnorarReciboParaDecAnual")
            ChckBxReciboDeSustitucion.Checked = dt.Rows(0).Item("ReciboDeSustitucion")
            ChckBxReciboTimbrado.Checked = dt.Rows(0).Item("ReciboTimbrado")
            ChkBeneficiario.Checked = dt.Rows(0).Item("PagaTercero")
            ChkBeneficiario.Enabled = True

            pnlBeneficiario.Visible = ChkBeneficiario.Checked
            'pnlBeneficiario.Enabled = ChkBeneficiario.Checked
            ddlBeneficiario.Visible = ChkBeneficiario.Checked
            'ddlBeneficiario.Enabled = ChkBeneficiario.Checked
        
        End If
    End Sub
    Private Sub BindddlNombre()
        Dim oEmp As New Empleado
        Dim oRecibo As New Recibos
        Dim oUsr As New Usuario
        Dim dr As DataRow
        Dim dt As DataTable

        Dim ddlNombre As DropDownList = CType(Me.dvRecibo.FindControl("ddlNombre"), DropDownList)
        Dim ddlQuincena As DropDownList = CType(Me.dvRecibo.FindControl("ddlQuincena"), DropDownList)
        Dim ChkBeneficiario As CheckBox = CType(Me.dvRecibo.FindControl("chkBeneficiario"), CheckBox)
        Dim ddlBeneficiario As DropDownList = CType(Me.dvRecibo.FindControl("ddlBeneficiario"), DropDownList)



        If ddlQuincena.SelectedValue = "-1" Then
            ddlNombre.Items.Insert(0, "No disponible.")
            ddlNombre.Items(0).Value = -1
            Exit Sub
        End If

        oUsr.Login = Session("Login")
        dr = oUsr.ObtenerPropiedadesDelRol().Rows(0)

        dt = oEmp.BuscarParaRecibo(CShort(ddlQuincena.SelectedValue), CByte(dr("IdRol")), CBool(dr("ConsultaZonasEspecificas")), CBool(dr("ConsultaPlantelesEspecificos")), Session("Login"), False)

        With ddlNombre
            .DataSource = dt
            .DataTextField = "NombreCompleto"
            .DataValueField = "IdEmp"
            .DataBind()
            If .Items.Count = 0 Then
                .Items.Insert(0, "No disponible.")
                .Items(0).Value = -1
            End If
        End With


    End Sub
    Private Sub BindddlQuincena()
        Dim oQna As New Quincenas
        Dim drFecha As DataRow
        Dim ddlQuincena As DropDownList = CType(Me.dvRecibo.FindControl("ddlQuincena"), DropDownList)
        Dim btnGuardar As Button = CType(Me.dvRecibo.FindControl("btnGuardar"), Button)
        Dim txtbxQnaIni As TextBox = CType(Me.dvRecibo.FindControl("txtbxQnaIni"), TextBox)
        Dim txtbxQnaFin As TextBox = CType(Me.dvRecibo.FindControl("txtbxQnaFin"), TextBox)
        Dim txtbxFechaIniQna As TextBox = CType(Me.dvRecibo.FindControl("txtbxFechaIniQna"), TextBox)
        Dim tbFecha_CV As CompareValidator = CType(Me.dvRecibo.FindControl("tbFecha_CV"), CompareValidator)
        With ddlQuincena
            .DataSource = oQna.ObtenAbiertasParaCapturaDeRecibos()
            .DataTextField = "Quincena"
            .DataValueField = "IdQuincena"
            .DataBind()
            If .Items.Count = 0 Then
                .Items.Insert(0, "No hay quincenas abiertas para captura.")
                .Items(0).Value = -1

                If Request.Params("TipoOperacion") = "1" Then
                    If tbFecha_CV.ValueToCompare = String.Empty Then
                        tbFecha_CV.ValueToCompare = Date.Today
                    End If
                    txtbxQnaIni.Text = String.Empty
                    txtbxQnaFin.Text = String.Empty
                End If

                btnGuardar.Enabled = False
            Else
                drFecha = oQna.ObtenFechaInioFinQna(CShort(ddlQuincena.SelectedValue), "I")

                tbFecha_CV.ValueToCompare = drFecha("Fecha").ToString
                txtbxFechaIniQna.Text = drFecha("Fecha").ToString

                If Request.Params("TipoOperacion") = "1" Then
                    txtbxQnaIni.Text = ddlQuincena.SelectedItem.Text
                    txtbxQnaFin.Text = ddlQuincena.SelectedItem.Text
                End If
            End If
        End With
    End Sub
    Private Sub BindEmpleado()
        Dim dr2 As DataRow
        Dim oEmp As New Empleado
        Dim ddlNombre As DropDownList = CType(Me.dvRecibo.FindControl("ddlNombre"), DropDownList)
        Dim tbRFC As TextBox = CType(Me.dvRecibo.FindControl("tbRFC"), TextBox)
        Dim tbPlaza As TextBox = CType(Me.dvRecibo.FindControl("tbPlaza"), TextBox)
        Dim lblIdPlaza As Label = CType(Me.dvRecibo.FindControl("lblIdPlaza"), Label)
        Dim btnGuardar As Button = CType(Me.dvRecibo.FindControl("btnGuardar"), Button)
        Dim ddlQuincena As DropDownList = CType(Me.dvRecibo.FindControl("ddlQuincena"), DropDownList)
        Dim RFVtbPlaza As RequiredFieldValidator = CType(Me.dvRecibo.FindControl("RFVtbPlaza"), RequiredFieldValidator)
        Dim REVtbPlaza As RegularExpressionValidator = CType(Me.dvRecibo.FindControl("REVtbPlaza"), RegularExpressionValidator)
        Dim FTBEtbPlaza As AjaxControlToolkit.FilteredTextBoxExtender = CType(Me.dvRecibo.FindControl("FTBEtbPlaza"), AjaxControlToolkit.FilteredTextBoxExtender)

        Dim ChkBeneficiario As CheckBox = CType(Me.dvRecibo.FindControl("chkBeneficiario"), CheckBox)
        Dim ddlBeneficiario As DropDownList = CType(Me.dvRecibo.FindControl("ddlBeneficiario"), DropDownList)
        Dim pnlBeneficiario As Panel = CType(Me.dvRecibo.FindControl("pnlBeneficiario"), Panel)
        Dim oRecibo As New Recibos
        Dim dtB As DataTable

        If ddlNombre.SelectedValue = "-1" Then
            tbRFC.Text = "No disponible"
            tbPlaza.Text = "No disponible"
            lblIdPlaza.Text = 0
            btnGuardar.Enabled = False
            Exit Sub
        End If

        dr2 = oEmp.BuscarPorId(CInt(ddlNombre.SelectedValue))

        tbRFC.Text = dr2("RFC").ToString

        Dim oEmpPlaza As New EmpleadoPlazas
        If tbRFC.Text <> String.Empty Then
            Dim dr3 As DataRow
            Dim dt As DataTable
            dt = oEmp.ObtenPlazasVigentes2(tbRFC.Text, CShort(ddlQuincena.SelectedValue))
            If dt.Rows.Count > 0 Then
                dr3 = dt.Rows(0)
            Else
                dr3 = oEmpPlaza.ObtenUltimaOcupada(tbRFC.Text)
            End If
            If dr3 Is Nothing = False Then
                tbPlaza.ReadOnly = True
                RFVtbPlaza.Enabled = False
                REVtbPlaza.Enabled = False
                FTBEtbPlaza.Enabled = False
                tbPlaza.Text = dr3("Plazas").ToString.Replace("-", "").Substring(0, 8)
                lblIdPlaza.Text = dr3("IdPlaza")
            Else
                tbPlaza.ReadOnly = False
                tbPlaza.Text = String.Empty
                RFVtbPlaza.Enabled = True
                REVtbPlaza.Enabled = True
                FTBEtbPlaza.Enabled = True
                lblIdPlaza.Text = "0"
            End If
        End If

        dtB = oRecibo.ObtenBeneficiarios(0, CInt(ddlNombre.SelectedValue))

        ChkBeneficiario.Enabled = False
        ddlBeneficiario.Enabled = False

        If dtB.Rows.Count > 0 Then
            ChkBeneficiario.Enabled = True
            LlenaDDL(ddlBeneficiario, "NombreBeneficiario", "idBeneficiario", oRecibo.ObtenBeneficiarios(0, ddlNombre.SelectedValue))
        End If
        ddlBeneficiario.Enabled = ChkBeneficiario.Checked
        pnlBeneficiario.Enabled = ChkBeneficiario.Checked
        pnlBeneficiario.Visible = ChkBeneficiario.Checked


    End Sub
    Private Sub BindddlTipoDeNomina()
        Dim oNomina As New Nomina
        Dim oRecibo As New Recibos
        Dim ddlFondosPresup As DropDownList = CType(Me.dvRecibo.FindControl("ddlFondosPresup"), DropDownList)
        LlenaDDL(ddlFondosPresup, "DescFondoPresup", "IdFondoPresup", oNomina.GetFondosPresupuestales())

        Dim ddlAnioPasivos As DropDownList = CType(Me.dvRecibo.FindControl("ddlAnioPasivos"), DropDownList)
        LlenaDDL(ddlAnioPasivos, "DescEjercicio", "idAnio", oNomina.GetEjerciciosAnteriores)

    End Sub
    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, ByVal dt As DataTable, Optional ByVal SelectedValue As String = "")
        ddl.DataSource = dt
        ddl.DataTextField = TextField
        ddl.DataValueField = ValueField
        ddl.DataBind()
        If SelectedValue <> String.Empty Then ddl.SelectedValue = SelectedValue
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Response.Expires = 0
            MultiView1.SetActiveView(viewEditar)

            Dim vlComplementoURL As String = String.Empty

            If Request.Params("TipoOperacion") = "0" Then
                pnl_viewEditar.GroupingText = "Información sobre el recibo (Modo: Modificación)"
                vlComplementoURL = "?Anio=" + Request.Params("Anio").ToString + "&IdQuincena=" + Request.Params("IdQuincena").ToString
                BinddvRecibo()
            ElseIf Request.Params("TipoOperacion") = "1" Then
                pnl_viewEditar.GroupingText = "Información sobre el recibo (Modo: Creación)"
                BinddvRecibo()
                BindddlQuincena()
                BindddlNombre()
                BindEmpleado()
                BindddlTipoDeNomina()

            ElseIf Request.Params("TipoOperacion") = "3" Then
                BinddvRecibo()
                btnGuardar_Click(sender, e)
            End If

            Dim btnCancelar As Button
            btnCancelar = CType(dvRecibo.FindControl("btnCancelar"), Button)

            If Session("URLAnt") Is Nothing = False Then
                If Session("URLAnt").ToString.Contains(Request.Url.Segments(Request.Url.Segments.Length - 1).ToString) Then
                    btnCancelar.PostBackUrl = "~/MenuPrincipal.aspx"
                    lbOtraOperacion0.PostBackUrl = "~/MenuPrincipal.aspx"
                Else
                    btnCancelar.PostBackUrl = "~/" + Session("URLAnt") + vlComplementoURL
                    lbOtraOperacion0.PostBackUrl = "~/" + Session("URLAnt") + vlComplementoURL
                End If
            Else
                btnCancelar.PostBackUrl = "~/MenuPrincipal.aspx"
                lbOtraOperacion0.PostBackUrl = "~/MenuPrincipal.aspx"
            End If
        End If
    End Sub
    Protected Sub dvRecibo_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles dvRecibo.DataBound
        Dim tbFecha As TextBox = CType(Me.dvRecibo.FindControl("tbFecha"), TextBox)
        Dim hfFecha As HiddenField = CType(Me.dvRecibo.FindControl("hfFecha"), HiddenField)
        Dim ibFecha As ImageButton = CType(Me.dvRecibo.FindControl("ibFecha"), ImageButton)
        Dim lblIdEstatusRecibo As Label = CType(Me.dvRecibo.FindControl("lblIdEstatusRecibo"), Label)
        Dim lblDescEstatusRecibo As Label = CType(Me.dvRecibo.FindControl("lblDescEstatusRecibo"), Label)
        Dim ddlEstatusRecibos As DropDownList = CType(Me.dvRecibo.FindControl("ddlEstatusRecibos"), DropDownList)
        Dim lblIdTipoRecibo As Label = CType(Me.dvRecibo.FindControl("lblIdTipoRecibo"), Label)
        Dim ddlTiposDeRecibos As DropDownList = CType(Me.dvRecibo.FindControl("ddlTiposDeRecibos"), DropDownList)
        Dim ChckBxImplicaAdeudo As CheckBox = CType(Me.dvRecibo.FindControl("ChckBxImplicaAdeudo"), CheckBox)
        Dim pnlAdeudos As Panel = CType(Me.dvRecibo.FindControl("pnlAdeudo"), Panel)
        Dim oRecibo As New Recibos
        Dim oUsr As New Usuario

        ibFecha.Attributes.Add("onclick", "javascript:abreCalendario('../../Calendario.aspx','" + tbFecha.ClientID + "','" + hfFecha.ClientID + "');")
        If Request.Params("TipoOperacion") = "0" Then
            With ddlEstatusRecibos
                If oUsr.EsAnalista(Session("Login")) Then
                    .DataSource = oRecibo.ObtenPosiblesEstatus(True)
                Else
                    .DataSource = oRecibo.ObtenPosiblesEstatus()
                End If
                .DataTextField = "DescEstatusRecibo"
                .DataValueField = "IdEstatusRecibo"
                .DataBind()
                .SelectedValue = lblIdEstatusRecibo.Text
                .Visible = True
            End With
        ElseIf Request.Params("TipoOperacion") = "1" Then
            lblDescEstatusRecibo.Visible = True
        End If
        With ddlTiposDeRecibos
            .DataSource = oRecibo.ObtenTipos()
            .DataTextField = "DescTipoRecibo"
            .DataValueField = "IdTipoRecibo"
            .DataBind()
            .SelectedValue = lblIdTipoRecibo.Text
            .Visible = True

            Select ddlTiposDeRecibos.SelectedValue
                Case "4", "1"
                    ChckBxImplicaAdeudo.Enabled = True
                    pnlAdeudos.Enabled = False
                Case Else
                    ChckBxImplicaAdeudo.Enabled = False
                    pnlAdeudos.Enabled = False
            End Select



        End With
    End Sub
    Protected Sub ibFecha_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim hfFecha As HiddenField = CType(Me.dvRecibo.FindControl("hfFecha"), HiddenField)
        Dim lblAnio As Label = CType(Me.dvRecibo.FindControl("lblAnio"), Label)
        lblAnio.Text = CDate(hfFecha.Value).Year.ToString
    End Sub

    Protected Sub ddlNombre_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        BindEmpleado()


    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            'AplicaValidaciones()
            Dim lblIdRecibo As Label = CType(Me.dvRecibo.FindControl("lblIdRecibo"), Label)
            Dim hfFecha As HiddenField = CType(Me.dvRecibo.FindControl("hfFecha"), HiddenField)
            Dim ddlEstatusRecibos As DropDownList = CType(Me.dvRecibo.FindControl("ddlEstatusRecibos"), DropDownList)
            Dim ddlTiposDeRecibos As DropDownList = CType(Me.dvRecibo.FindControl("ddlTiposDeRecibos"), DropDownList)
            Dim ddlFondosPresup As DropDownList = CType(Me.dvRecibo.FindControl("ddlFondosPresup"), DropDownList)
            Dim ddlNombre As DropDownList = CType(Me.dvRecibo.FindControl("ddlNombre"), DropDownList)
            Dim tbConceptoRecibo As TextBox = CType(Me.dvRecibo.FindControl("tbConceptoRecibo"), TextBox)
            Dim ddlQuincena As DropDownList = CType(Me.dvRecibo.FindControl("ddlQuincena"), DropDownList)
            Dim ChckBxImplicaAdeudo As CheckBox = CType(Me.dvRecibo.FindControl("ChckBxImplicaAdeudo"), CheckBox)
            Dim txtbxQnaIni As TextBox = CType(Me.dvRecibo.FindControl("txtbxQnaIni"), TextBox)
            Dim txtbxQnaFin As TextBox = CType(Me.dvRecibo.FindControl("txtbxQnaFin"), TextBox)
            Dim lblIdPlaza As Label = CType(Me.dvRecibo.FindControl("lblIdPlaza"), Label)
            Dim tbPlaza As TextBox = CType(Me.dvRecibo.FindControl("tbPlaza"), TextBox)
            Dim tbFecha As TextBox = CType(Me.dvRecibo.FindControl("tbFecha"), TextBox)
            Dim txtbxFechaIniQna As TextBox = CType(Me.dvRecibo.FindControl("txtbxFechaIniQna"), TextBox)
            Dim tbFecha_CV As CompareValidator = CType(Me.dvRecibo.FindControl("tbFecha_CV"), CompareValidator)
            Dim tbFechaRealDePago As TextBox = CType(Me.dvRecibo.FindControl("tbFechaRealDePago"), TextBox)
            Dim ChckBxIgnorarEmpParaPasivos As CheckBox = CType(Me.dvRecibo.FindControl("ChckBxIgnorarEmpParaPasivos"), CheckBox)
            Dim ChckBxIgnorarParaDecAnual As CheckBox = CType(Me.dvRecibo.FindControl("ChckBxIgnorarParaDecAnual"), CheckBox)
            Dim ChckBxReciboDeSustitucion As CheckBox = CType(Me.dvRecibo.FindControl("ChckBxReciboDeSustitucion"), CheckBox)
            Dim ChckBxReciboTimbrado As CheckBox = CType(Me.dvRecibo.FindControl("ChckBxReciboTimbrado"), CheckBox)

            '*********************
            'CÓDIGO AÑADIDO 2021, PARA CONTROLAR LOS RECIBOS DE OTROS EJERCICIOS Y LOS BENEFICIARIOS DE UN RECIBO
            '*********************

            Dim ddlAnioPasivos As DropDownList = CType(Me.dvRecibo.FindControl("ddlAnioPasivos"), DropDownList)
            Dim ChkBeneficiario As CheckBox = CType(Me.dvRecibo.FindControl("chkBeneficiario"), CheckBox)
            Dim ddlBeneficiario As DropDownList = CType(Me.dvRecibo.FindControl("ddlBeneficiario"), DropDownList)
            Dim pnlBeneficiario As Panel = CType(Me.dvRecibo.FindControl("pnlBeneficiario"), Panel)

            Dim oRecibo As New Recibos
            Dim oUsr As New Usuario

            Dim I As Integer

            I = 0

            With oRecibo
                .Fecha = CDate(tbFecha.Text)
                .FechaRealDePago = CDate(tbFechaRealDePago.Text)
                .IdTipoRecibo = CByte(ddlTiposDeRecibos.SelectedValue)
                .IdFondoPresup = CByte(ddlFondosPresup.SelectedValue)
                .ObservacionesRecibo = tbConceptoRecibo.Text.ToUpper
                .IdQuincenaAplicacion = CShort(ddlQuincena.SelectedValue)
                .ReciboImplicaAdeudo = ChckBxImplicaAdeudo.Checked
                .IdPlaza = CInt(lblIdPlaza.Text)
                .ClaveDeCobro = tbPlaza.Text
                .QnaIniAdeudo = txtbxQnaIni.Text
                .QnaFinAdeudo = txtbxQnaFin.Text
                .IgnorarEmpParaPasivos = ChckBxIgnorarEmpParaPasivos.Checked
                .IgnorarReciboParaDecAnual = ChckBxIgnorarParaDecAnual.Checked
                .ReciboDeSustitucion = ChckBxReciboDeSustitucion.Checked
                .Recibotimbrado = ChckBxReciboTimbrado.Checked
                .AnioPasivos = CInt(ddlAnioPasivos.SelectedValue)
                .PagaTercero = ChkBeneficiario.Checked
                If ddlBeneficiario.Items.Count > 0 Then
                    .IdBeneficiario = CInt(ddlBeneficiario.SelectedValue)
                Else
                    .IdBeneficiario = 0
                End If
                If Request.Params("TipoOperacion") = "0" Then
                    .IdRecibo = CShort(lblIdRecibo.Text)
                    .IdEstatusRecibo = CByte(ddlEstatusRecibos.SelectedValue)
                    .Actualiza(CType(Session("ArregloAuditoria"), String()))
                ElseIf Request.Params("TipoOperacion") = "1" Then
                    lbOtraOperacion.Visible = False
                    oUsr.Login = Session("Login")
                    .IdUsuario = oUsr.ObtenerPorLogin()("IdUsuario")
                    .IdEmp = CInt(ddlNombre.SelectedValue)
                    lblNumRecibo.Text = Me.lblNumRecibo.Text + .InsertaNuevo(CType(Session("ArregloAuditoria"), String()))
                    lblNumRecibo.Visible = True
                ElseIf Request.Params("TipoOperacion") = "3" Then
                    lbOtraOperacion.Visible = False
                    .IdRecibo = CShort(lblIdRecibo.Text)
                    .EliminaPorId(CType(Session("ArregloAuditoria"), String()))
                End If
            End With
            MultiView1.SetActiveView(Me.viewExito)
        Catch Ex As Exception
            Me.lblError.Text = Ex.Message
            Me.MultiView1.SetActiveView(Me.viewError)
        End Try
    End Sub

    Protected Sub ChckBxImplicaAdeudo_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ChckBxImplicaAdeudo As CheckBox = CType(Me.dvRecibo.FindControl("ChckBxImplicaAdeudo"), CheckBox)
        Dim pnlAdeudo As Panel = CType(Me.dvRecibo.FindControl("pnlAdeudo"), Panel)
        pnlAdeudo.Enabled = ChckBxImplicaAdeudo.Checked
    End Sub
    
    Protected Sub ChkBeneficiario_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ChkBeneficiario As CheckBox = CType(Me.dvRecibo.FindControl("chkBeneficiario"), CheckBox)
        Dim ddlBeneficiario As DropDownList = CType(Me.dvRecibo.FindControl("ddlBeneficiario"), DropDownList)
        Dim pnlBeneficiario As Panel = CType(Me.dvRecibo.FindControl("pnlBeneficiario"), Panel)

        ddlBeneficiario.Enabled = ChkBeneficiario.Checked
        pnlBeneficiario.Enabled = ChkBeneficiario.Checked

        ddlBeneficiario.Visible = ChkBeneficiario.Checked
        pnlBeneficiario.Visible = ChkBeneficiario.Checked

    End Sub
    Protected Sub ddlTiposDeRecibos_SelectedIndexChanged(sender As Object, e As System.EventArgs)
        Dim ddlTiposDeRecibos As DropDownList = CType(Me.dvRecibo.FindControl("ddlTiposDeRecibos"), DropDownList)
        Dim ChckBxImplicaAdeudo As CheckBox = CType(Me.dvRecibo.FindControl("ChckBxImplicaAdeudo"), CheckBox)
        Dim pnlAdeudos As Panel = CType(Me.dvRecibo.FindControl("pnlAdeudo"), Panel)
        Select Case ddlTiposDeRecibos.SelectedValue
            Case "4", "1"
                ChckBxImplicaAdeudo.Enabled = True
                pnlAdeudos.Enabled = False
            Case Else
                ChckBxImplicaAdeudo.Enabled = False
                pnlAdeudos.Enabled = False
        End Select
    End Sub

    Protected Sub txtbxFechaIniQna_TextChanged(sender As Object, e As System.EventArgs)
        Dim ddlQuincena As DropDownList = CType(Me.dvRecibo.FindControl("ddlQuincena"), DropDownList)
        Dim txtbxFechaIniQna As TextBox = CType(Me.dvRecibo.FindControl("txtbxFechaIniQna"), TextBox)
        Dim drFecha As DataRow
        Dim oQna As New Quincenas
        drFecha = oQna.ObtenFechaInioFinQna(CShort(ddlQuincena.SelectedValue), "I")

        txtbxFechaIniQna.Text = drFecha("Fecha").ToString
    End Sub

    Protected Sub lbOtraOperacion_Click(sender As Object, e As System.EventArgs) Handles lbOtraOperacion.Click
        If Request.Params("TipoOperacion") = "0" Then
            BinddvRecibo()

            Dim vlComplementoURL As String = "?Anio=" + Request.Params("Anio").ToString + "&IdQuincena=" + Request.Params("IdQuincena").ToString
            Dim btnCancelar As Button
            btnCancelar = CType(dvRecibo.FindControl("btnCancelar"), Button)

            If Session("URLAnt") Is Nothing = False Then
                If Session("URLAnt").ToString.Contains(Request.Url.Segments(Request.Url.Segments.Length - 1).ToString) Then
                    btnCancelar.PostBackUrl = "~/MenuPrincipal.aspx"
                    lbOtraOperacion0.PostBackUrl = "~/MenuPrincipal.aspx"
                Else
                    btnCancelar.PostBackUrl = "~/" + Session("URLAnt") + vlComplementoURL
                    lbOtraOperacion0.PostBackUrl = "~/" + Session("URLAnt") + vlComplementoURL
                End If
            Else
                btnCancelar.PostBackUrl = "~/MenuPrincipal.aspx"
                lbOtraOperacion0.PostBackUrl = "~/MenuPrincipal.aspx"
            End If
        ElseIf Request.Params("TipoOperacion") = "1" Then
        ElseIf Request.Params("TipoOperacion") = "3" Then
        End If
        MultiView1.SetActiveView(viewEditar)
    End Sub

    Protected Sub lbReintentarCaptura_Click(sender As Object, e As System.EventArgs) Handles lbReintentarCaptura.Click
        MultiView1.SetActiveView(viewEditar)
    End Sub

    Protected Sub dvRecibo_PageIndexChanging(sender As Object, e As DetailsViewPageEventArgs) Handles dvRecibo.PageIndexChanging

    End Sub
End Class
