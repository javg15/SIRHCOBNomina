Imports DataAccessLayer.COBAEV.Empleados
Imports System.Data
Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV
Imports DataAccessLayer.COBAEV.Administracion
Imports BusinessRulesLayer.COBAEV.Validaciones
Partial Class ABC_Recibos_AdmonRecibosBAK
    Inherits System.Web.UI.Page
    Private Sub AplicaValidaciones()
        Dim oValidacion As New Validaciones
        Dim _DataCOBAEV As New DataCOBAEV
        Dim dsValida As DataSet
        dsValida = _DataCOBAEV.setDataSetErrores()

        With oValidacion
            .NombrePagina = Request.Url.Segments(Request.Url.Segments.Length - 1).ToString
            '.RFC = Session("RFCParaCons")
            '.IdQuincena = 0
            .TipoOperacion = IIf(Request.Params("TipoOperacion") Is Nothing, 5, CByte(Request.Params("TipoOperacion")))
            'If Request.Params("TipoOperacion") <> "2" Then
            '    If Me.dvCargaHoraria.CurrentMode = DetailsViewMode.Insert Then
            '        .Cantidad = CByte(CType(Me.dvCargaHoraria.FindControl("txtbxCantidadIns"), TextBox).Text)
            '    ElseIf Me.dvCargaHoraria.CurrentMode = DetailsViewMode.Edit Then
            '        .Cantidad = CByte(CType(Me.dvCargaHoraria.FindControl("txtbxCantidad"), TextBox).Text)
            '        .IdHora = CType(Request.Params("IdHora"), Integer)
            '    End If
            'End If
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

        Dim pnlAdeudos As Panel = CType(Me.dvRecibo.FindControl("pnlAdeudo"), Panel)
        If Request.Params("TipoOperacion") = "0" Or Request.Params("TipoOperacion") = "3" Then
            ddlNombre.Items.Insert(0, dt.Rows(0).Item("NomEmp").ToString)
            ddlNombre.Items(0).Value = dt.Rows(0).Item("IdEmp").ToString
            ddlQuincena.Items.Insert(0, dt.Rows(0).Item("Quincena").ToString)
            ddlQuincena.Items(0).Value = dt.Rows(0).Item("IdQuincenaAplicacion").ToString

            drFecha = oQna.ObtenFechaInioFinQna(CShort(ddlQuincena.SelectedValue), "I")

            tbFecha_CV.ValueToCompare = drFecha("Fecha").ToString
            txtbxFechaIniQna.Text = drFecha("Fecha").ToString
            'hfFechaIniQna.Value = drFecha("Fecha").ToString

            LlenaDDL(ddlFondosPresup, "DescFondoPresup", "IdFondoPresup", oNomina.GetFondosPresupuestales(), dt.Rows(0).Item("IdFondoPresup").ToString)
            ChckBxImplicaAdeudo.Checked = dt.Rows(0).Item("IdQnaIniAdeudo") <> dt.Rows(0).Item("IdQnaFinAdeudo")
            'pnlAdeudos.Visible = ChckBxImplicaAdeudo.Checked
            pnlAdeudos.Enabled = ChckBxImplicaAdeudo.Checked
            txtbxQnaIni.Text = dt.Rows(0).Item("QnaIniAdeudo").ToString
            txtbxQnaFin.Text = dt.Rows(0).Item("QnaFinAdeudo").ToString
        End If
    End Sub
    Private Sub BindddlNombre()
        Dim oEmp As New Empleado
        Dim oUsr As New Usuario
        Dim dr As DataRow
        Dim dt As DataTable
        Dim ddlNombre As DropDownList = CType(Me.dvRecibo.FindControl("ddlNombre"), DropDownList)
        Dim ddlQuincena As DropDownList = CType(Me.dvRecibo.FindControl("ddlQuincena"), DropDownList)

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
            .DataSource = oQna.ObtenAbiertasParaCaptura()
            .DataTextField = "Quincena"
            .DataValueField = "IdQuincena"
            .DataBind()
            If .Items.Count = 0 Then
                .Items.Insert(0, "No hay quincenas abiertas para captura.")
                .Items(0).Value = -1

                If Request.Params("TipoOperacion") = "1" Then
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
    End Sub
    Private Sub BindddlTipoDeNomina()
        Dim oNomina As New Nomina
        Dim ddlFondosPresup As DropDownList = CType(Me.dvRecibo.FindControl("ddlFondosPresup"), DropDownList)
        LlenaDDL(ddlFondosPresup, "DescFondoPresup", "IdFondoPresup", oNomina.GetFondosPresupuestales())
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
            Me.MultiView1.SetActiveView(Me.viewEditar)
            If Request.Params("TipoOperacion") = "0" Then
                BinddvRecibo()
            ElseIf Request.Params("TipoOperacion") = "1" Then
                BinddvRecibo()
                BindddlQuincena()
                BindddlNombre()
                BindEmpleado()
                BindddlTipoDeNomina()
            ElseIf Request.Params("TipoOperacion") = "3" Then
                BinddvRecibo()
                btnGuardar_Click(sender, e)
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
        ibFecha.Attributes.Add("onclick", "javascript:abreCalendario('../../Calendario.aspx','" + tbFecha.ClientID + "','" + hfFecha.ClientID + "');")
        If Request.Params("TipoOperacion") = "0" Then
            With ddlEstatusRecibos
                .DataSource = oRecibo.ObtenPosiblesEstatus()
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

            Select Case ddlTiposDeRecibos.SelectedValue
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
            Dim oRecibo As New Recibos
            Dim oUsr As New Usuario
            'Dim drFecha As DataRow
            'Dim oQna As New Quincenas

            'drFecha = oQna.ObtenFechaInioFinQna(CShort(ddlQuincena.SelectedValue), "I")

            'If CDate(tbFecha.Text) < CDate(drFecha("Fecha").ToString) Then
            '    Page.Validate()
            '    Exit Sub
            'End If

            With oRecibo
                .Fecha = CDate(tbFecha.Text) 'CDate(hfFecha.Value)
                .IdTipoRecibo = CByte(ddlTiposDeRecibos.SelectedValue)
                .IdFondoPresup = CByte(ddlFondosPresup.SelectedValue)
                .ObservacionesRecibo = tbConceptoRecibo.Text.ToUpper
                .IdQuincenaAplicacion = CShort(ddlQuincena.SelectedValue)
                .ReciboImplicaAdeudo = ChckBxImplicaAdeudo.Checked
                .IdPlaza = CInt(lblIdPlaza.Text)
                .ClaveDeCobro = tbPlaza.Text
                'If ChckBxImplicaAdeudo.Checked And txtbxQnaIni.Text.Trim <> String.Empty And txtbxQnaFin.Text.Trim <> String.Empty Then
                .QnaIniAdeudo = txtbxQnaIni.Text
                .QnaFinAdeudo = txtbxQnaFin.Text
                'Else
                '.QnaIniAdeudo = ddlQuincena.SelectedItem.Text 'String.Empty
                '.QnaFinAdeudo = ddlQuincena.SelectedItem.Text 'String.Empty
                'End If
                '.IdPlaza = lblIdPlaza.Text
                If Request.Params("TipoOperacion") = "0" Then
                    .IdRecibo = CShort(lblIdRecibo.Text)
                    .IdEstatusRecibo = CByte(ddlEstatusRecibos.SelectedValue)
                    .Actualiza(CType(Session("ArregloAuditoria"), String()))
                ElseIf Request.Params("TipoOperacion") = "1" Then
                    oUsr.Login = Session("Login")
                    .IdUsuario = oUsr.ObtenerPorLogin()("IdUsuario")
                    .IdEmp = CInt(ddlNombre.SelectedValue)
                    Me.lblNumRecibo.Text = Me.lblNumRecibo.Text + .InsertaNuevo(CType(Session("ArregloAuditoria"), String()))
                    Me.lblNumRecibo.Visible = True
                ElseIf Request.Params("TipoOperacion") = "3" Then
                    .IdRecibo = CShort(lblIdRecibo.Text)
                    .EliminaPorId(CType(Session("ArregloAuditoria"), String()))
                End If
            End With
            Me.MultiView1.SetActiveView(Me.viewExito)
        Catch Ex As Exception
            Me.lblError.Text = Ex.Message
            Me.MultiView1.SetActiveView(Me.viewError)
        End Try
    End Sub

    Protected Sub ChckBxImplicaAdeudo_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ChckBxImplicaAdeudo As CheckBox = CType(Me.dvRecibo.FindControl("ChckBxImplicaAdeudo"), CheckBox)
        Dim pnlAdeudo As Panel = CType(Me.dvRecibo.FindControl("pnlAdeudo"), Panel)
        'pnlAdeudo.Visible = ChckBxImplicaAdeudo.Checked
        pnlAdeudo.Enabled = ChckBxImplicaAdeudo.Checked
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
End Class
