Imports DataAccessLayer.COBAEV.Empleados
Imports System.Data
Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV
Imports DataAccessLayer.COBAEV.Administracion
Imports BusinessRulesLayer.COBAEV.Validaciones
Partial Class ABC_Recibos_AdmonConceptosRecibos
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

        oRecibo.IdRecibo = CShort(Request.Params("IdRecibo"))
        oRecibo.IdConcepto = CShort(Request.Params("IdConcepto"))
        oRecibo.TipoConcepto = Request.Params("TipoConcepto")
        If Request.Params("TipoOperacion") = "0" Then
            Me.dvConcepto.DataSource = oRecibo.ObtenImportesDeConceptos()
        ElseIf Request.Params("TipoOperacion") = "3" Then
            oRecibo.IdRecibo = CShort(Request.Params("IdRecibo"))
            Me.dvConcepto.DataSource = oRecibo.ObtenPorId()
            Me.dvConcepto.Visible = False
        End If
        Me.dvConcepto.DataBind()
    End Sub
    Private Sub BindddlConcepto(ByVal ddl As String, ByVal IdConcepto As Short, ByVal TipoConcepto As String)
        Dim ddlConcepto As DropDownList
        Dim oRecibo As New Recibos
        Dim dt As DataTable
        Dim EsReinstalacion As Boolean = False
        Dim oNomina As New Nomina
        Dim lblGrava As Label = Nothing
        Dim lblDiasExentos As Label = Nothing
        Dim vlPermisoDiasExentos As Boolean
        Dim drDiasExentos As DataRow = Nothing

        Dim Terminacion As String = String.Empty
        If Me.dvConcepto.CurrentMode = DetailsViewMode.Edit Then
            Terminacion = "_E"
        ElseIf Me.dvConcepto.CurrentMode = DetailsViewMode.Insert Then
            Terminacion = "_I"
        End If

        Dim Importe As TextBox = CType(Me.dvConcepto.FindControl("tbImporte" + Terminacion), TextBox)
        Dim ImporteParaRetroactivo As TextBox = CType(Me.dvConcepto.FindControl("tbImporteRetroactivo" + Terminacion), TextBox)
        Dim ImporteParaAguinaldo As TextBox = CType(Me.dvConcepto.FindControl("tbImporteAguinaldo" + Terminacion), TextBox)
        Dim ImporteGravado As TextBox = CType(Me.dvConcepto.FindControl("tbImporteGrav" + Terminacion), TextBox)
        Dim MostrarEnRecibo As CheckBox = CType(Me.dvConcepto.FindControl("ChBxMostrarEnRecibo" + Terminacion), CheckBox)
        Dim DiasExentos = CType(Me.dvConcepto.FindControl("tbDiasExentos" + Terminacion), TextBox)
        'Dim ddlDiasExentos = CType(Me.dvConcepto.FindControl("ddlDiasExentos" + Terminacion), DropDownList)
        'Dim REVtbDiasExentos = CType(Me.dvConcepto.FindControl("REVtbDiasExentos" + Terminacion), RegularExpressionValidator)
        Dim vlNomTabla As String = "RecibosImportes"

        Dim drPSCImporte As DataRow
        Dim drPSCImporteParaRetroactivo As DataRow
        Dim drPSCImporteParaAguinaldo As DataRow
        Dim drPSCImporteGravado As DataRow
        Dim drPSCMostrarEnRecibo As DataRow
        Dim drPSCDiasExentos As DataRow

        Dim oAplic As New Aplicacion

        drPSCImporte = oAplic.ObtenerPermisosUsrTablasCampos(Session("Login").ToString, vlNomTabla, "Importe")
        drPSCImporteParaRetroactivo = oAplic.ObtenerPermisosUsrTablasCampos(Session("Login").ToString, vlNomTabla, "ImporteParaRetroactivo")
        drPSCImporteParaAguinaldo = oAplic.ObtenerPermisosUsrTablasCampos(Session("Login").ToString, vlNomTabla, "ImporteParaAguinaldo")
        drPSCImporteGravado = oAplic.ObtenerPermisosUsrTablasCampos(Session("Login").ToString, vlNomTabla, "ImporteGravado")
        drPSCMostrarEnRecibo = oAplic.ObtenerPermisosUsrTablasCampos(Session("Login").ToString, vlNomTabla, "MostrarEnRecibo")
        drPSCDiasExentos = oAplic.ObtenerPermisosUsrTablasCampos(Session("Login").ToString, vlNomTabla, "DiasExentos")

        If Request.Params("IdRecibo") Is Nothing = False Then
            oRecibo.IdRecibo = CShort(Request.Params("IdRecibo"))
            dt = oRecibo.ObtenPorId()
            EsReinstalacion = IIf(dt.Rows(0).Item("IdTipoRecibo").ToString = "1", True, False)
        End If

        If Me.dvConcepto.CurrentMode = DetailsViewMode.Edit Then
            Importe.Enabled = CBool(drPSCImporte("Actualizacion"))
            ImporteParaRetroactivo.Enabled = CBool(drPSCImporteParaRetroactivo("Actualizacion")) = True And EsReinstalacion = True _
                                            And TipoConcepto = "P"
            ImporteParaAguinaldo.Enabled = CBool(drPSCImporteParaAguinaldo("Actualizacion")) And EsReinstalacion = True _
                                            And TipoConcepto = "P"
            ImporteGravado.Enabled = CBool(drPSCImporteGravado("Actualizacion"))
            MostrarEnRecibo.Enabled = CBool(drPSCMostrarEnRecibo("Actualizacion"))
            DiasExentos.Enabled = CBool(drPSCDiasExentos("Actualizacion"))
            'ddlDiasExentos.Enabled = CBool(drPSCDiasExentos("Actualizacion"))
            vlPermisoDiasExentos = CBool(drPSCDiasExentos("Actualizacion"))
        ElseIf Me.dvConcepto.CurrentMode = DetailsViewMode.Insert Then
            Importe.Enabled = CBool(drPSCImporte("Insercion"))
            ImporteParaRetroactivo.Enabled = CBool(drPSCImporteParaRetroactivo("Insercion")) And EsReinstalacion = True _
                                            And TipoConcepto = "P"
            ImporteParaAguinaldo.Enabled = CBool(drPSCImporteParaAguinaldo("Insercion")) And EsReinstalacion = True _
                                            And TipoConcepto = "P"
            ImporteGravado.Enabled = CBool(drPSCImporteGravado("Insercion"))
            MostrarEnRecibo.Enabled = CBool(drPSCMostrarEnRecibo("Insercion"))
            DiasExentos.Enabled = CBool(drPSCDiasExentos("Insercion"))
            'ddlDiasExentos.Enabled = CBool(drPSCDiasExentos("Insercion"))
            vlPermisoDiasExentos = CBool(drPSCDiasExentos("Insercion"))
        End If

        Dim oUsr As New Usuario
        Dim dr As DataRow
        oUsr.Login = Session("Login")
        dr = oUsr.ObtenerPropiedadesDelRol().Rows(0)

        ddlConcepto = CType(Me.dvConcepto.FindControl(ddl), DropDownList)
        With ddlConcepto
            .DataSource = oRecibo.ObtenConceptos(CShort(Request.Params("IdRecibo")), IdConcepto, TipoConcepto, CByte(Request.Params("TipoOperacion")), CByte(dr("IdRol")))
            .DataTextField = "Concepto"
            .DataValueField = "IdConcepto"
            .DataBind()
            If IdConcepto <> 0 Then .SelectedValue = IdConcepto.ToString
            If Request.Params("TipoOperacion") = "0" Then .Enabled = False
        End With

        If Me.dvConcepto.CurrentMode = DetailsViewMode.Edit Then
            'ddlConcepto = CType(Me.dvConcepto.FindControl("ddlConcepto_E"), DropDownList)
            lblGrava = CType(Me.dvConcepto.FindControl("lblGrava_E"), Label)
            lblDiasExentos = CType(Me.dvConcepto.FindControl("lblDiasExentos_E"), Label)
        ElseIf Me.dvConcepto.CurrentMode = DetailsViewMode.Insert Then
            ' ddlConcepto = CType(Me.dvConcepto.FindControl("ddlConcepto_I"), DropDownList)
            lblGrava = CType(Me.dvConcepto.FindControl("lblGrava_I"), Label)
            lblDiasExentos = CType(Me.dvConcepto.FindControl("lblDiasExentos_I"), Label)
        End If

        If Request.Params("TipoOperacion") <> "3" Then 'Operación es diferente de eliminar
            If (oNomina.DeterminaSiConceptoGrava(CShort(ddlConcepto.SelectedValue), Request.Params("TipoConcepto"))) = True Then
                lblGrava.Text = "Concepto gravable"
            Else
                lblGrava.Text = "Concepto no gravable"
            End If
        End If

        If Request.Params("TipoOperacion") <> "3" Then 'Operación es diferente de eliminar
            If (oNomina.ConceptoRequiereDiasExentos(CShort(ddlConcepto.SelectedValue), Request.Params("TipoConcepto"))) = True Then
                DiasExentos.Enabled = True And vlPermisoDiasExentos
                lblDiasExentos.Text = "" '"Requiere días exentos."

                'drDiasExentos = oNomina.getPorEmpDiasExentosPorAnioPerc(CShort(Request.Params("IdRecibo")), CShort(ddlConcepto.SelectedValue))

                'If CShort(ddlConcepto.SelectedValue = 9) Then 'Aguinaldo
                '    Select Case CDec(drDiasExentos("DiasExentosEnElAnio"))
                '        Case 0.0
                '            REVtbDiasExentos.ValidationExpression = "{/(0.00)|(0.00)|(15.00)|(30.00)}"
                '        Case 15
                '            REVtbDiasExentos.ValidationExpression = "{/(0.00)|(0.00)|(15.00)}"
                '        Case 30
                '            REVtbDiasExentos.ValidationExpression = "{/(0.00)}"
                '    End Select
                'End If

                'If CShort(ddlConcepto.SelectedValue = 10) Then 'Prima vacacional
                '    Select Case CDec(drDiasExentos("DiasExentosEnElAnio"))
                '        Case 0.0
                '            REVtbDiasExentos.ValidationExpression = "{/(0.00)|(0.00)|(7.50)|(15.00)}"
                '        Case 7.5
                '            REVtbDiasExentos.ValidationExpression = "{/(0.00)|(0.00)|(7.50)}"
                '        Case 15
                '            REVtbDiasExentos.ValidationExpression = "{/(0.00)}"
                '    End Select
                'End If
            Else
                DiasExentos.Text = "0.00"
                DiasExentos.Enabled = False
                lblDiasExentos.Text = "" '"No requiere días exentos."
                'REVtbDiasExentos.ValidationExpression = "{/(0.00)}"
            End If
        End If
    End Sub
    Private Sub EliminaImportesDeConceptos()
        Try
            Dim oRecibo As New Recibos
            Dim oUsr As New Usuario
            With oRecibo
                .IdRecibo = CShort(Request.Params("IdRecibo"))
                .IdConcepto = CShort(Request.Params("IdConcepto"))
                .TipoConcepto = Request.Params("TipoConcepto")
                .EliminaImportesDeConceptos(CType(Session("ArregloAuditoria"), String()))
            End With
            Me.MultiView1.SetActiveView(Me.viewExito)
        Catch Ex As Exception
            Me.lblError.Text = Ex.Message
            Me.MultiView1.SetActiveView(Me.viewError)
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Response.Expires = 0
            Me.MultiView1.SetActiveView(Me.viewEditar)
            If Request.Params("TipoOperacion") = "0" Then
                Me.dvConcepto.DefaultMode = DetailsViewMode.Edit
                BinddvRecibo()
                If Request.Params("TipoConcepto") = "P" Then
                    Me.dvConcepto.HeaderText = "Modificar percepción"
                    BindddlConcepto("ddlConcepto_E", CShort(Request.Params("IdConcepto")), "P")
                Else
                    Me.dvConcepto.HeaderText = "Modificar deducción"
                    BindddlConcepto("ddlConcepto_E", CShort(Request.Params("IdConcepto")), "D")
                End If
            ElseIf Request.Params("TipoOperacion") = "1" Then
                Me.dvConcepto.DefaultMode = DetailsViewMode.Insert
                If Request.Params("TipoConcepto") = "P" Then
                    Me.dvConcepto.HeaderText = "Capturar percepción"
                    BindddlConcepto("ddlConcepto_I", 0, "P")
                Else
                    Me.dvConcepto.HeaderText = "Capturar deducción"
                    BindddlConcepto("ddlConcepto_I", 0, "D")
                End If
            ElseIf Request.Params("TipoOperacion") = "3" Then
                EliminaImportesDeConceptos()
            End If
        End If
    End Sub

    'Protected Sub tbImporte_E_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim tbImporte_E, tbImporteRetroactivo_E, tbImporteAguinaldo_E As TextBox
    '    tbImporte_E = CType(Me.dvConcepto.FindControl("tbImporte_E"), TextBox)
    '    tbImporteRetroactivo_E = CType(Me.dvConcepto.FindControl("tbImporteRetroactivo_E"), TextBox)
    '    tbImporteAguinaldo_E = CType(Me.dvConcepto.FindControl("tbImporteAguinaldo_E"), TextBox)
    '    'tbImporteGrav_E = CType(Me.dvConcepto.FindControl("tbImporteGrav_E"), TextBox)
    '    'tbImporteGrav_E.Text = tbImporte_E.Text
    'End Sub

    Protected Sub tbImporte_I_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim tbImporte_I, tbImporteGrav_I As TextBox
        Dim lblGrava_I As Label
        Dim ddlConcepto As DropDownList
        Dim oNomina As New Nomina

        ddlConcepto = CType(Me.dvConcepto.FindControl("ddlConcepto_I"), DropDownList)
        tbImporte_I = CType(Me.dvConcepto.FindControl("tbImporte_I"), TextBox)
        tbImporteGrav_I = CType(Me.dvConcepto.FindControl("tbImporteGrav_I"), TextBox)
        lblGrava_I = CType(Me.dvConcepto.FindControl("lblGrava_I"), Label)

        If (oNomina.DeterminaSiConceptoGrava(CShort(ddlConcepto.SelectedValue), Request.Params("TipoConcepto"))) = True Then
            tbImporteGrav_I.Text = tbImporte_I.Text
            lblGrava_I.Text = "Concepto gravable"
        Else
            tbImporteGrav_I.Text = "0.00"
            lblGrava_I.Text = "Concepto no gravable"
        End If
    End Sub

    Private Function ValidaDiasExentos(ByVal pDiasExentos As Decimal, ByVal pIdRecibo As Short, ByVal pIdConcepto As Short) As String
        Dim drDiasExentos As DataRow
        Dim oNomina As New Nomina
        Dim msj As String = String.Empty

        drDiasExentos = oNomina.getPorEmpDiasExentosPorAnioPerc(pIdRecibo, pIdConcepto)

        If CShort(pIdConcepto = 9) Or CShort(pIdConcepto = 22) Or CShort(pIdConcepto = 73) Then 'Aguinaldo
            Select Case CDec(drDiasExentos("DiasExentosEnElAnio"))
                Case 0.0
                    If pDiasExentos = 0.0 Or pDiasExentos = 15.0 Or pDiasExentos = 30.0 Then
                        msj = String.Empty
                    Else
                        msj = "Valor incorrecto para los días exentos para la prestación de aguinaldo. " + _
                            "Los valores pueden ser: 0.00,15.00 o 30.00, " + _
                                "dado que el empleado durante el año no tiene ningún día exento para la prestación antes mencionada."
                    End If
                Case 15
                    If pDiasExentos = 0.0 Or pDiasExentos = 15.0 Then
                        msj = String.Empty
                    Else
                        msj = "Valor incorrecto para los días exentos para la prestación de aguinaldo. " + _
                            "Los valores pueden ser: 0.00 o 15.00, " + _
                            "dado que el empleado ya tiene durante el año " + CDec(drDiasExentos("DiasExentosEnElAnio")).ToString + _
                            " días exentos para la prestación antes mencionada."
                    End If
                Case 30
                    If pDiasExentos = 0.0 Then
                        msj = String.Empty
                    Else
                        msj = "Valor incorrecto para los días exentos para la prestación de aguinaldo. " + _
                            "Los valores pueden ser: 0.00, " + _
                            "dado que el empleado ya tiene durante el año " + CDec(drDiasExentos("DiasExentosEnElAnio")).ToString + _
                            " días exentos para la prestación antes mencionada."
                    End If
            End Select
        End If

        If CShort(pIdConcepto = 10) Or CShort(pIdConcepto = 29) Or CShort(pIdConcepto = 31) Then 'Prima vacacional
            Select Case CDec(drDiasExentos("DiasExentosEnElAnio"))
                Case 0.0
                    If pDiasExentos = 0.0 Or pDiasExentos = 7.5 Or pDiasExentos = 15.0 Then
                        msj = String.Empty
                    Else
                        msj = "Valor incorrecto para los días exentos para la prestación de prima vacacional. " + _
                            "Los valores pueden ser: 0.00,7.50 o 15.00, " + _
                                "dado que el empleado durante el año no tiene ningún día exento para la prestación antes mencionada."
                    End If
                Case 7.5
                    If pDiasExentos = 0.0 Or pDiasExentos = 7.5 Then
                        msj = String.Empty
                    Else
                        msj = "Valor incorrecto para los días exentos para la prestación de prima vacacional. " + _
                            "Los valores pueden ser: 0.00 ó 7.50, " + _
                            "dado que el empleado ya tiene durante el año " + CDec(drDiasExentos("DiasExentosEnElAnio")).ToString + _
                            " días exentos para la prestación antes mencionada."
                    End If
                Case 15
                    If pDiasExentos = 0.0 Or pDiasExentos = 7.5 Then
                        msj = String.Empty
                    Else
                        msj = "Valor incorrecto para los días exentos para la prestación de prima vacacional. " + _
                            "Los valores pueden ser: 0.00, " + _
                            "dado que el empleado ya tiene durante el año " + CDec(drDiasExentos("DiasExentosEnElAnio")).ToString + _
                            " días exentos para la prestación antes mencionada."
                    End If
            End Select
        End If

        Return msj

    End Function

    Protected Sub btnGurdar_E_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            ''AplicaValidaciones()
            Dim Terminacion As String = String.Empty
            If Me.dvConcepto.CurrentMode = DetailsViewMode.Edit Then
                Terminacion = "_E"
            ElseIf Me.dvConcepto.CurrentMode = DetailsViewMode.Insert Then
                Terminacion = "_I"
            End If

            Dim ddlConcepto As DropDownList = CType(Me.dvConcepto.FindControl("ddlConcepto" + Terminacion), DropDownList)
            Dim tbImporte As TextBox = CType(Me.dvConcepto.FindControl("tbImporte" + Terminacion), TextBox)
            Dim tbImporteRetroactivo As TextBox = CType(Me.dvConcepto.FindControl("tbImporteRetroactivo" + Terminacion), TextBox)
            Dim tbImporteAguinaldo As TextBox = CType(Me.dvConcepto.FindControl("tbImporteAguinaldo" + Terminacion), TextBox)
            Dim tbImporteGrav As TextBox = CType(Me.dvConcepto.FindControl("tbImporteGrav" + Terminacion), TextBox)
            Dim tbDiasExentos As TextBox = CType(Me.dvConcepto.FindControl("tbDiasExentos" + Terminacion), TextBox)
            Dim ChBxMostrarEnRecibo As CheckBox = CType(Me.dvConcepto.FindControl("ChBxMostrarEnRecibo" + Terminacion), CheckBox)
            Dim msj As String = String.Empty

            Select Case CShort(ddlConcepto.SelectedValue)
                Case 9, 10, 22, 73, 29, 31
                    msj = ValidaDiasExentos(CDec(IIf(tbDiasExentos.Text.Trim = String.Empty, "0.00", tbDiasExentos.Text)), _
                                            CShort(Request.Params("IdRecibo")), CShort(ddlConcepto.SelectedValue))
                    If msj <> String.Empty Then
                        Me.lblError.Text = msj
                        MultiView1.SetActiveView(Me.viewError)
                        Exit Sub
                    End If
            End Select

            Dim oRecibo As New Recibos
            Dim oUsr As New Usuario
            With oRecibo
                .IdRecibo = CShort(Request.Params("IdRecibo"))
                .IdConcepto = CShort(ddlConcepto.SelectedValue)
                .TipoConcepto = Request.Params("TipoConcepto")
                .Importe = CDec(tbImporte.Text)
                .ImporteParaRetroactivo = CDec(tbImporteRetroactivo.Text)
                .ImporteParaAguinaldo = CDec(tbImporteAguinaldo.Text)
                .ImporteGravado = CDec(tbImporteGrav.Text)
                .DiasExentos = CDec(IIf(tbDiasExentos.Text.Trim = String.Empty, "0.00", tbDiasExentos.Text))
                .MostrarEnRecibo = ChBxMostrarEnRecibo.Checked
                If Request.Params("TipoOperacion") = "0" Then
                    .ActualizaConceptos(CType(Session("ArregloAuditoria"), String()))
                ElseIf Request.Params("TipoOperacion") = "1" Then
                    .InsertaConceptos(CType(Session("ArregloAuditoria"), String()))
                End If
            End With
            Me.MultiView1.SetActiveView(Me.viewExito)
        Catch Ex As Exception
            Me.lblError.Text = Ex.Message
            Me.MultiView1.SetActiveView(Me.viewError)
        End Try
    End Sub

    Protected Sub ddlConcepto_I_SelectedIndexChanged(sender As Object, e As System.EventArgs)
        Dim tbImporte_I As TextBox = Nothing
        Dim tbDiasExentos_I As TextBox = Nothing
        Dim tbImporteGrav_I As TextBox = Nothing
        Dim lblGrava_I As Label = Nothing
        Dim lblDiasExentos_I As Label = Nothing
        Dim ddlConcepto As DropDownList = Nothing
        'Dim ddlDiasExentos As DropDownList = Nothing
        Dim oNomina As New Nomina
        Dim drPSCDiasExentos As DataRow
        Dim vlNomTabla As String = "RecibosImportes"
        Dim oAplic As New Aplicacion
        Dim drDiasExentos As DataRow = Nothing
        Dim vlPermisoDiasExentos As Boolean
        'Dim REVtbDiasExentos As RegularExpressionValidator

        ddlConcepto = CType(Me.dvConcepto.FindControl("ddlConcepto_I"), DropDownList)
        tbImporte_I = CType(Me.dvConcepto.FindControl("tbImporte_I"), TextBox)
        tbImporteGrav_I = CType(Me.dvConcepto.FindControl("tbImporteGrav_I"), TextBox)
        lblGrava_I = CType(Me.dvConcepto.FindControl("lblGrava_I"), Label)
        lblDiasExentos_I = CType(Me.dvConcepto.FindControl("lblDiasExentos_I"), Label)
        tbDiasExentos_I = CType(Me.dvConcepto.FindControl("tbDiasExentos_I"), TextBox)
        'ddlDiasExentos = CType(Me.dvConcepto.FindControl("ddlDiasExentos_I"), DropDownList)
        'REVtbDiasExentos = CType(Me.dvConcepto.FindControl("REVtbDiasExentos_I"), RegularExpressionValidator)

        drPSCDiasExentos = oAplic.ObtenerPermisosUsrTablasCampos(Session("Login").ToString, vlNomTabla, "DiasExentos")
        vlPermisoDiasExentos = CBool(drPSCDiasExentos("Actualizacion"))

        If (oNomina.DeterminaSiConceptoGrava(CShort(ddlConcepto.SelectedValue), Request.Params("TipoConcepto"))) = True Then
            tbImporteGrav_I.Text = tbImporte_I.Text
            lblGrava_I.Text = "Concepto gravable"
        Else
            tbImporteGrav_I.Text = "0.00"
            lblGrava_I.Text = "Concepto no gravable"
        End If

        If (oNomina.ConceptoRequiereDiasExentos(CShort(ddlConcepto.SelectedValue), Request.Params("TipoConcepto"))) = True Then
            tbDiasExentos_I.Enabled = True And CBool(drPSCDiasExentos("Insercion"))
            lblDiasExentos_I.Text = "" '"Requiere días exentos."

            'drDiasExentos = oNomina.getPorEmpDiasExentosPorAnioPerc(CShort(Request.Params("IdRecibo")), CShort(ddlConcepto.SelectedValue))

            'If CShort(ddlConcepto.SelectedValue = 9) Then 'Aguinaldo
            '    Select Case CDec(drDiasExentos("DiasExentosEnElAnio"))
            '        Case 0.0
            '            REVtbDiasExentos.ValidationExpression = "{/(0.00)|(0.00)|(15.00)|(30.00)}"
            '        Case 15
            '            REVtbDiasExentos.ValidationExpression = "{/(0.00)|(0.00)|(15.00)}"
            '        Case 30
            '            REVtbDiasExentos.ValidationExpression = "{/(0.00)}"
            '    End Select
            'End If

            'If CShort(ddlConcepto.SelectedValue = 10) Then 'Prima vacacional
            '    Select Case CDec(drDiasExentos("DiasExentosEnElAnio"))
            '        Case 0.0
            '            REVtbDiasExentos.ValidationExpression = "{/(0.00)|(0.00)|(7.50)|(15.00)}"
            '        Case 7.5
            '            REVtbDiasExentos.ValidationExpression = "{/(0.00)|(0.00)|(7.50)}"
            '        Case 15
            '            REVtbDiasExentos.ValidationExpression = "{/(0.00)}"
            '    End Select
            'End If
        Else
            tbDiasExentos_I.Text = "0.00"
            tbDiasExentos_I.Enabled = False
            lblDiasExentos_I.Text = "" '"No requiere días exentos."
            'REVtbDiasExentos.ValidationExpression = "{/(0.00)}"
        End If
    End Sub


    Protected Sub lbReintentarCaptura_Click(sender As Object, e As System.EventArgs) Handles lbReintentarCaptura.Click
        MultiView1.SetActiveView(viewEditar)
    End Sub
End Class
