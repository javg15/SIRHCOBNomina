Imports DataAccessLayer.COBAEV
Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.Empleados
Imports System.Data
Imports DataAccessLayer.COBAEV.Administracion
Imports BusinessRulesLayer.COBAEV.Validaciones
Partial Class AdmonDeducCapturadasAnt
    Inherits System.Web.UI.Page
    Private dr As DataRow
    Private Sub AplicaValidaciones()
        Dim oValidacion As New Validaciones
        Dim _DataCOBAEV As New DataCOBAEV
        Dim dsValida As DataSet
        Dim ddlQnaInicio As DropDownList = CType(Me.WucEfectos1.FindControl("ddlQnaInicio"), DropDownList)

        dsValida = _DataCOBAEV.setDataSetErrores()

        With oValidacion
            .NombrePagina = Request.Url.Segments(Request.Url.Segments.Length - 1).ToString
            .RFC = Me.Request.Params("RFCEmp")
            '.IdPercepcion = CShort(Me.ddlPercepciones.SelectedValue)
            .IdDeduccion = CShort(Me.ddlDeducciones.SelectedValue)
            .IdQuincena = CShort(ddlQnaInicio.SelectedValue)
            .TipoOperacion = IIf(Request.Params("TipoOperacion") Is Nothing, 5, CByte(Request.Params("TipoOperacion")))

            Try
                .ImporteDeduccion = IIf(txtbxImporteDeduccion.Text.Trim <> String.Empty, CDec(txtbxImporteDeduccion.Text), 0)
            Catch
                .ImporteDeduccion = 0
            End Try

            If Request.Params("ValidacionAlCargarPagina") Is Nothing = False Then
                If Not oValidacion.ValidaPagsPercDeduc(dsValida, False, CShort(Me.ddlDeducciones.SelectedValue), "D") Then
                    Session.Add("dsValida", dsValida)
                    Response.Redirect("~/ErroresPagina2.aspx")
                Else
                    Session.Remove("dsValida")
                End If
            Else
                If Not oValidacion.ValidaPagsPercDeduc(dsValida, CShort(Me.ddlDeducciones.SelectedValue), "D") Then
                    Session.Add("dsValida", dsValida)
                    Response.Redirect("~/ErroresPagina2.aspx")
                Else
                    Session.Remove("dsValida")
                End If
            End If
        End With
    End Sub
    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, _
                        ByVal dt As DataTable, Optional ByVal SelectedValue As String = "", _
                        Optional ByVal Habilitado As Boolean = True)
        ddl.DataSource = dt
        ddl.DataTextField = TextField
        ddl.DataValueField = ValueField
        Try
            ddl.DataBind()
        Catch
        End Try
        If SelectedValue <> String.Empty Then ddl.SelectedValue = SelectedValue
        ddl.Enabled = Habilitado
    End Sub
    Private Sub BindddlPlazas(Optional ByVal dr As DataRow = Nothing)
        Dim oEmp As New Empleado
        oEmp.RFC = Me.Request.Params("RFCEmp")
        If Request.Params("TipoOperacion") = "0" Then
            LlenaDDL(Me.ddlPlazas, "Plazas", "IdPlaza", oEmp.ObtenPlazasVigentes(), dr("IdPlaza").ToString)
        ElseIf Request.Params("TipoOperacion") = "1" Then
            LlenaDDL(Me.ddlPlazas, "Plazas", "IdPlaza", oEmp.ObtenPlazasVigentes(), String.Empty)
        End If
    End Sub
    Private Sub DeterminaAmbitoDeduccion(Optional ByVal dr As DataRow = Nothing)
        Dim oDeduccion As New Deduccion
        Dim drDeduc As DataRow
        Dim ddlQnaInicio, ddlQnaFin As DropDownList
        Dim oQna As New Quincenas
        oDeduccion.IdDeduccion = CType(Me.ddlDeducciones.SelectedValue, Short)
        If Me.ddlPlazas.SelectedValue = "-1" Then
            drDeduc = oDeduccion.ObtenInfParaCaptura(Me.Request.Params("RFCEmp"), CType(Me.ddlPlazas.Items(1).Value, Integer))
        Else
            drDeduc = oDeduccion.ObtenInfParaCaptura(Me.Request.Params("RFCEmp"), CType(Me.ddlPlazas.SelectedValue, Integer))
        End If
        Select Case CType(drDeduc("IdAmbitoConcepto"), Byte)
            Case 1 'Por empleado
                If Me.ddlPlazas.Items.FindByValue("-1") Is Nothing Then
                    Me.ddlPlazas.Items.Insert(0, "Deducción por empleado")
                    Me.ddlPlazas.Items(0).Value = "-1"
                    Me.ddlPlazas.SelectedValue = "-1"
                    Me.ddlPlazas.Enabled = False
                End If
            Case 0, 2 'Por Plaza
                If Me.ddlPlazas.Items(0).Value = "-1" Then Me.ddlPlazas.Items.RemoveAt(0)
                Me.ddlPlazas.Enabled = True
        End Select
        Me.lblImporteDeduccion.Enabled = False
        Me.txtbxImporteDeduccion.Enabled = False
        Me.txtbxImporteDeduccion.Text = "Deshabilitado"
        Me.CVImporteDeduccion.Enabled = False
        Me.RFVImporteDeduccion.Enabled = False
        Select Case CType(drDeduc("IdFormaDePago"), Byte)
            Case 5 'PAGO FIJO
                Me.txtbxImporteDeduccion.Text = drDeduc("ImporteDeduccion").ToString
            Case 6 'CANTIDAD VARIABLE
                Me.lblImporteDeduccion.Enabled = True
                Me.txtbxImporteDeduccion.Enabled = True
                If Request.Params("TipoOperacion") = "0" Then
                    Me.txtbxImporteDeduccion.Text = dr("ImpDeduc").ToString
                ElseIf Request.Params("TipoOperacion") = "1" Then
                    Me.txtbxImporteDeduccion.Text = String.Empty
                End If
                Me.CVImporteDeduccion.Enabled = True
                Me.RFVImporteDeduccion.Enabled = True
        End Select
        ddlQnaInicio = CType(Me.WucEfectos1.FindControl("ddlQnaInicio"), DropDownList)
        ddlQnaFin = CType(Me.WucEfectos1.FindControl("ddlQnaFin"), DropDownList)
        If CByte(drDeduc("NumQnas")) > 0 Then
            LlenaDDL(ddlQnaFin, "Quincena", "IdQuincena", oQna.ObtenParaVigFin(CShort(ddlQnaInicio.SelectedValue), CByte(drDeduc("NumQnas"))), String.Empty)
        Else
            LlenaDDL(ddlQnaFin, "Quincena", "IdQuincena", oQna.ObtenParaVigFin(CType(ddlQnaInicio.SelectedValue, Short), True), String.Empty)
            ddlQnaFin.SelectedIndex = ddlQnaFin.Items.Count - 1
        End If
        CType(Me.WucEfectos1.FindControl("ddlQnaFin"), DropDownList).Enabled = CBool(drDeduc("EfectosAbiertos"))
        CType(Me.WucEfectos1.FindControl("chbxEspecificarNumQuincenas"), CheckBox).Enabled = CBool(drDeduc("EfectosAbiertos"))
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.Response.Expires = 0
            Dim oDeduccion As New Deduccion
            Dim oQna As New Quincenas
            Dim ddlQnaInicio As DropDownList = CType(Me.WucEfectos1.FindControl("ddlQnaInicio"), DropDownList)
            Dim ddlQnaFin As DropDownList = CType(Me.WucEfectos1.FindControl("ddlQnaFin"), DropDownList)
            Dim oUsr As New Usuario
            Dim dr2 As DataRow
            oUsr.Login = Session("Login")
            dr2 = oUsr.ObtenerPropiedadesDelRol().Rows(0)

            If Request.Params("TipoOperacion") = "3" Then
                Try
                    With oDeduccion
                        .IdDeducCapturada = CType(Request.Params("IdDeducCapturada"), Integer)
                        .IdPlaza = CType(Request.Params("IdPlaza"), Integer)
                        .IdDeduccion = CType(Request.Params("IdDeduccion"), Short)
                        .RFCEmp = Request.Params("RFCEmp")
                        .Elimina(CType(Session("ArregloAuditoria"), String()))
                    End With
                    Me.lblExito.Text = "Deducción eliminada exitosamente."
                    Me.MultiView1.SetActiveView(Me.viewExito)
                    Exit Sub
                Catch ex As Exception
                    Me.lblError.Text = ex.Message
                    Me.MultiView1.SetActiveView(Me.viewError)
                    Exit Sub
                End Try
            End If
            Me.MultiView1.SetActiveView(Me.viewDeducciones)
            If Request.Params("TipoOperacion") = "0" Then
                With oDeduccion
                    .IdDeducCapturada = CType(Request.Params("IdDeducCapturada"), Integer)
                    .IdDeduccion = CType(Request.Params("IdDeduccion"), Short)
                    .IdPlaza = CType(Request.Params("IdPlaza"), Integer)
                    dr = .ObtenPorIdDeCaptura()

                    oQna.IdQuincena = CShort(dr("IdQnaVigIniDeduc"))
                    ddlQnaInicio.DataSource = oQna.ObtenPorId(False)
                    ddlQnaInicio.DataTextField = "Quincena"
                    ddlQnaInicio.DataValueField = "IdQuincena"
                    ddlQnaInicio.DataBind()

                    oQna.IdQuincena = CShort(dr("IdQnaVigFinDeduc"))
                    ddlQnaFin.DataSource = oQna.ObtenPorId(False)
                    ddlQnaFin.DataTextField = "Quincena"
                    ddlQnaFin.DataValueField = "IdQuincena"
                    ddlQnaFin.DataBind()
                End With
                LlenaDDL(Me.ddlDeducciones, "Deduccion", "IdDeduccion", oDeduccion.ObtenPorRol(CByte(dr2("IdRol"))), dr("IdDeduccion").ToString, False)
                BindddlPlazas(dr)
            ElseIf Request.Params("TipoOperacion") = "1" Then
                LlenaDDL(Me.ddlDeducciones, "Deduccion", "IdDeduccion", oDeduccion.ObtenPorRol(CByte(dr2("IdRol"))), String.Empty)
                BindddlPlazas()
            End If
            If Me.ddlPlazas.Items.Count > 0 Then
                If Request.Params("TipoOperacion") = "0" Then
                    DeterminaAmbitoDeduccion(dr)
                    'ElseIf Request.Params("TipoOperacion") = "1" Then
                    '    DeterminaAmbitoDeduccion()
                End If
            Else
                Me.MultiView1.SetActiveView(Me.viewError)
                Me.lblError.Text = "El empleado no tiene plazas vigentes, lo sentimos."
            End If
        End If
    End Sub

    Protected Sub ddlDeducciones_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlDeducciones.SelectedIndexChanged
        DeterminaAmbitoDeduccion()
    End Sub

    Protected Sub ddlPlazas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlDeducciones.SelectedIndexChanged
        DeterminaAmbitoDeduccion()
    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            AplicaValidaciones()

            Dim oDeduccion As New Deduccion
            Dim ddlQnaInicio As DropDownList = CType(Me.WucEfectos1.FindControl("ddlQnaInicio"), DropDownList)
            Dim ddlQnaFin As DropDownList = CType(Me.WucEfectos1.FindControl("ddlQnaFin"), DropDownList)
            Dim chbxEspecificarNumQuincenas As CheckBox = CType(Me.WucEfectos1.FindControl("chbxEspecificarNumQuincenas"), CheckBox)
            Dim txtbxNumQnas As TextBox = CType(Me.WucEfectos1.FindControl("txtbxNumQnas"), TextBox)
            Dim Indice As Integer = 0
            If Me.ddlPlazas.Items.Count > 1 Then Indice = 1
            With oDeduccion
                .IdDeduccion = CType(Me.ddlDeducciones.SelectedValue, Short)
                .IdPlaza = IIf(Me.ddlPlazas.SelectedValue <> "-1", CType(Me.ddlPlazas.SelectedValue, Integer), CType(Me.ddlPlazas.Items(Indice).Value, Integer))
                If Me.txtbxImporteDeduccion.Enabled Then
                    .ImporteDeduccion = CDec(Me.txtbxImporteDeduccion.Text)
                Else
                    .ImporteDeduccion = 0
                End If
                '.ImporteDeduccion = IIf(Me.txtbxImporteDeduccion.Enabled = True, Me.txtbxImporteDeduccion.Text, 0)
                .IdQnaInicio = CType(ddlQnaInicio.SelectedValue, Short)
                .IdQnaFin = CType(ddlQnaFin.SelectedValue, Short)
                .EspecificarNumQuincenas = chbxEspecificarNumQuincenas.Checked
                If txtbxNumQnas.Text.Trim = String.Empty Then txtbxNumQnas.Text = "0"
                .NumQnas = IIf(chbxEspecificarNumQuincenas.Checked = True, CType(txtbxNumQnas.Text, Byte), 0)
                If Request.Params("TipoOperacion") = "0" Then
                    .IdDeducCapturada = CType(Request.Params("IdDeducCapturada"), Integer)
                    .Actualiza(Deduccion.TipoActualizacion.ParaPago, CType(Session("ArregloAuditoria"), String()))
                    Me.lblExito.Text = "Deducción modificada correctamente."
                Else 'If Request.Params("TipoOperacion") = "1" Then
                    .Inserta(Deduccion.TipoInsercion.ParaPago, CType(Session("ArregloAuditoria"), String()))
                    Me.lblExito.Text = "Deducción agregada correctamente."
                End If
            End With
            Me.MultiView1.SetActiveView(Me.viewExito)
        Catch Ex As Exception
            Me.MultiView1.SetActiveView(Me.viewError)
            Me.lblError.Text = Ex.Message
        End Try
    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            If Request.Params("TipoOperacion") = "0" Then
                Dim ddlQnaInicio As DropDownList = CType(Me.WucEfectos1.FindControl("ddlQnaInicio"), DropDownList)
                Dim ddlQnaFin As DropDownList = CType(Me.WucEfectos1.FindControl("ddlQnaFin"), DropDownList)
                Dim hfQnaFin As HiddenField = CType(Me.WucEfectos1.FindControl("hfQnaFin"), HiddenField)
                Dim chbxEspecificarNumQuincenas As CheckBox = CType(Me.WucEfectos1.FindControl("chbxEspecificarNumQuincenas"), CheckBox)
                Dim txtbxNumQnas As TextBox = CType(Me.WucEfectos1.FindControl("txtbxNumQnas"), TextBox)
                Dim CVNumQnas As CompareValidator = CType(Me.WucEfectos1.FindControl("CVNumQnas"), CompareValidator)
                Dim QnaMenorCaptura As String = ddlQnaFin.Items(ddlQnaFin.Items.Count - 1).Text
                Dim NumQuincenas As Byte
                Dim oMetCom As New MetodosComunes
                If ddlQnaInicio.Items.FindByText(dr("VigIniDeduc").ToString) Is Nothing = False Then
                    ddlQnaInicio.SelectedItem.Selected = False
                    ddlQnaInicio.Items.FindByText(dr("VigIniDeduc").ToString).Selected = True
                Else
                    Dim oQuincena As New Quincenas
                    'oQuincena.Quincena = CType(dr("VigIniDeduc"), Integer)
                    oQuincena.IdQuincena = CType(dr("IdQnaVigIniDeduc"), Short)
                    LlenaDDL(ddlQnaInicio, "Quincena", "IdQuincena", oQuincena.ObtenPorQuincena, String.Empty, False)
                End If
                If ddlQnaFin.Items.FindByText(dr("VigFinDeduc").ToString) Is Nothing = False Then
                    ddlQnaFin.SelectedItem.Selected = False
                    ddlQnaFin.Items.FindByText(dr("VigFinDeduc").ToString).Selected = True
                Else
                    ddlQnaFin.Items.Clear()
                    ddlQnaFin.Items.Insert(0, dr("VigFinDeduc").ToString)
                    ddlQnaFin.Items(0).Value = "-1"
                    hfQnaFin.Value = dr("VigFinDeduc").ToString
                    ddlQnaFin.Enabled = False
                    chbxEspecificarNumQuincenas.Checked = True
                    txtbxNumQnas.Text = oMetCom.DeterminaNumQuincenas(dr("VigIniDeduc").ToString, dr("VigFinDeduc").ToString)
                    txtbxNumQnas.Visible = True
                    With CVNumQnas
                        NumQuincenas = oMetCom.DeterminaNumQuincenas(ddlQnaInicio.SelectedItem.Text, QnaMenorCaptura)
                        .ErrorMessage = "Valor debe ser mayor o igual a " + (NumQuincenas - 1).ToString
                        .ValueToCompare = (NumQuincenas - 1).ToString
                    End With
                End If
            ElseIf Request.Params("TipoOperacion") = "1" Then
                DeterminaAmbitoDeduccion()
            End If
        Else
            If Request.Params("__EVENTTARGET") = "ctl00$ContentPlaceHolder1$WucEfectos1$ddlQnaInicio" Then
                DeterminaAmbitoDeduccion()
            End If
        End If
        'End If
    End Sub
End Class
