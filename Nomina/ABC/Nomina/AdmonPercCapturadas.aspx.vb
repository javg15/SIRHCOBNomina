Imports DataAccessLayer.COBAEV
Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV.Empleados
Imports System.Data
Imports DataAccessLayer.COBAEV.Administracion
Imports BusinessRulesLayer.COBAEV.Validaciones
Partial Class AdmonPercCapturadas
    Inherits System.Web.UI.Page
    Private dr As DataRow
    Private Function HayErrores() As Boolean
        Dim oValidacion As New Validaciones
        Dim _DataCOBAEV As New DataCOBAEV
        Dim dsValida As DataSet
        Dim ddlQnaInicio As DropDownList = CType(WucEfectos2.FindControl("ddlQnaInicio"), DropDownList)
        Dim vlResult As Boolean = False

        dsValida = _DataCOBAEV.setDataSetErrores()

        With oValidacion
            .NombrePagina = Request.Url.Segments(Request.Url.Segments.Length - 1).ToString
            .RFC = Me.Request.Params("RFCEmp")
            .IdPercepcion = CShort(Request.Params("IdPercepcion"))  'CShort(Me.ddlPercepciones.SelectedValue)
            .IdQuincena = CShort(ddlQnaInicio.SelectedValue)
            .TipoOperacion = IIf(Request.Params("TipoOperacion") Is Nothing, 5, CByte(Request.Params("TipoOperacion")))

            Try
                .ImportePercepcion = IIf(txtbxImportePercepcion.Text.Trim <> String.Empty, CDec(txtbxImportePercepcion.Text), 0)
            Catch
                .ImportePercepcion = 0
            End Try

            If Request.Params("ValidacionAlCargarPagina") Is Nothing = False Then
                'If Not oValidacion.ValidaPagsPercDeduc(dsValida, False, CShort(Me.ddlPercepciones.SelectedValue), "P") Then
                If Not oValidacion.ValidaPagsPercDeduc(dsValida, False, CShort(Request.Params("IdPercepcion")), "P") Then
                    Session.Add("dsValida", dsValida)
                    wucMuestraErrores.ActualizaContenido()
                    MultiView1.SetActiveView(viewError)
                    vlResult = True
                    'Session.Add("dsValida", dsValida)
                    'Response.Redirect("~/ErroresPagina2.aspx")
                Else
                    Session.Remove("dsValida")
                    vlResult = False
                End If
            Else
                'If Not oValidacion.ValidaPagsPercDeduc(dsValida, CShort(Me.ddlPercepciones.SelectedValue), "P") Then
                If Not oValidacion.ValidaPagsPercDeduc(dsValida, CShort(Request.Params("IdPercepcion")), "P") Then
                    Session.Add("dsValida", dsValida)
                    wucMuestraErrores.ActualizaContenido()
                    MultiView1.SetActiveView(viewError)
                    vlResult = True
                    'Session.Add("dsValida", dsValida)
                    'Response.Redirect("~/ErroresPagina2.aspx")
                Else
                    Session.Remove("dsValida")
                    vlResult = False
                End If
            End If
        End With

        Return vlResult

    End Function
    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, _
                        ByVal dt As DataTable, Optional ByVal SelectedValue As String = "", _
                        Optional ByVal Habilitado As Boolean = True)
        If dt.Rows.Count > 0 Then
            ddl.Items.Clear()
            ddl.DataSource = dt
            ddl.DataTextField = TextField
            ddl.DataValueField = ValueField
            Try
                ddl.DataBind()
            Catch
            End Try
            If SelectedValue <> String.Empty Then ddl.SelectedValue = SelectedValue
            ddl.Enabled = Habilitado
        End If
    End Sub
    Private Sub BindddlPlazas(Optional ByVal dr As DataRow = Nothing)
        Dim oEmp As New Empleado
        Dim dtPlazas As DataTable

        oEmp.RFC = Me.Request.Params("RFCEmp")
        dtPlazas = oEmp.ObtenPlazasVigentes()

        If dtPlazas.Rows.Count > 0 Then
            If Request.Params("TipoOperacion") = "0" Then
                LlenaDDL(ddlPlazas, "Plazas", "IdPlaza", oEmp.ObtenPlazasVigentes(), dr("IdPlaza").ToString)
            ElseIf Request.Params("TipoOperacion") = "1" Then
                LlenaDDL(ddlPlazas, "Plazas", "IdPlaza", oEmp.ObtenPlazasVigentes(), String.Empty)
            End If
        Else
            lblError.Text = "El empleado no tiene plazas vigentes, lo sentimos."
            lbReintentarCaptura.Visible = False
            MultiView1.SetActiveView(viewErrorNoCont)
        End If
    End Sub
    Private Sub DeterminaAmbitoPercepcion(Optional ByVal dr As DataRow = Nothing)
        Dim oPercepcion As New Percepcion
        Dim drPerc As DataRow
        Dim oQna As New Quincenas
        Dim ddlQnaInicio, ddlQnaFin As DropDownList
        oPercepcion.IdPercepcion = CShort(Request.Params("IdPercepcion")) 'CType(Me.ddlPercepciones.SelectedValue, Short)
        If Me.ddlPlazas.SelectedValue = "-1" Then
            drPerc = oPercepcion.ObtenInfParaCaptura(Me.Request.Params("RFCEmp"), CType(Me.ddlPlazas.Items(1).Value, Integer))
        Else
            drPerc = oPercepcion.ObtenInfParaCaptura(Me.Request.Params("RFCEmp"), CType(Me.ddlPlazas.SelectedValue, Integer))
        End If
        Select Case CType(drPerc("IdAmbitoConcepto"), Byte)
            Case 1 'Por empleado
                If Me.ddlPlazas.Items.FindByValue("-1") Is Nothing Then
                    Me.ddlPlazas.Items.Insert(0, "Percepción por empleado")
                    Me.ddlPlazas.Items(0).Value = "-1"
                    Me.ddlPlazas.SelectedValue = "-1"
                    Me.ddlPlazas.Enabled = False
                End If
            Case 0, 2 'Por Plaza
                If Me.ddlPlazas.Items(0).Value = "-1" Then Me.ddlPlazas.Items.RemoveAt(0)
                Me.ddlPlazas.Enabled = True
        End Select
        Me.lblImportePercepcion.Enabled = False
        Me.txtbxImportePercepcion.Enabled = False
        Me.txtbxImportePercepcion.Text = "Deshabilitado"
        Me.CVImportePercepcion.Enabled = False
        Me.RFVImportePercepcion.Enabled = False
        If dr Is Nothing = False Then
            Me.tbDiasAPagar.Text = dr("NumDias").ToString
        Else
            Me.tbDiasAPagar.Text = "0"
        End If
        Me.tbDiasAPagar.Enabled = CBool(drPerc("RequiereDias"))
        If CBool(drPerc("RequiereDias")) = False Then Me.tbDiasAPagar.Text = "0"
        Me.rfvNumDias.Enabled = CBool(drPerc("RequiereDias"))
        Select Case CType(drPerc("IdFormaDePago"), Byte)
            Case 5 'PAGO FIJO
                Me.txtbxImportePercepcion.Text = drPerc("ImportePercepcion").ToString
            Case 6 'CANTIDAD VARIABLE
                Me.lblImportePercepcion.Enabled = True
                Me.txtbxImportePercepcion.Enabled = True
                If Request.Params("TipoOperacion") = "0" Then
                    Me.txtbxImportePercepcion.Text = dr("ImpPerc").ToString
                ElseIf Request.Params("TipoOperacion") = "1" Then
                    If drPerc("ImportePercepcion") > 0 Then
                        Me.txtbxImportePercepcion.Text = drPerc("ImportePercepcion").ToString
                    Else
                        Me.txtbxImportePercepcion.Text = String.Empty
                    End If
                End If
                Me.CVImportePercepcion.Enabled = True
                Me.RFVImportePercepcion.Enabled = True
        End Select
        ddlQnaInicio = CType(WucEfectos2.FindControl("ddlQnaInicio"), DropDownList)
        ddlQnaFin = CType(WucEfectos2.FindControl("ddlQnaFin"), DropDownList)

        If CByte(drPerc("NumQnas")) > 0 Then
            LlenaDDL(ddlQnaFin, "Quincena", "IdQuincena", oQna.ObtenParaVigFin(CShort(ddlQnaInicio.SelectedValue), CByte(drPerc("NumQnas"))), String.Empty)
        Else
            LlenaDDL(ddlQnaFin, "Quincena", "IdQuincena", oQna.ObtenParaVigFin(CType(ddlQnaInicio.SelectedValue, Short), True), String.Empty)
            ddlQnaFin.SelectedIndex = ddlQnaFin.Items.Count - 1
        End If
        CType(WucEfectos2.FindControl("ddlQnaFin"), DropDownList).Enabled = CBool(drPerc("EfectosAbiertos"))
        CType(WucEfectos2.FindControl("chbxEspecificarNumQuincenas"), CheckBox).Enabled = CBool(drPerc("EfectosAbiertos"))
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.Response.Expires = 0
            Dim oPercepcion As New Percepcion
            Dim ddlQnaInicio As DropDownList = CType(WucEfectos2.FindControl("ddlQnaInicio"), DropDownList)
            Dim ddlQnaFin As DropDownList = CType(WucEfectos2.FindControl("ddlQnaFin"), DropDownList)

            Dim BtnNewSearch As Button = CType(Me.WucBuscaEmpleados1.FindControl("BtnNewSearch"), Button)
            Dim BtnCancelSearch As Button = CType(Me.WucBuscaEmpleados1.FindControl("BtnCancelSearch"), Button)
            Dim BtnSearch As Button = CType(Me.WucBuscaEmpleados1.FindControl("BtnSearch"), Button)

            BtnNewSearch.Visible = False
            BtnCancelSearch.Visible = False
            BtnSearch.Visible = False

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

            Dim drPerc As DataRow
            Dim vlTipoOp As String

            Select Case Request.Params("TipoOperacion")
                Case "0"
                    vlTipoOp = " (CAMBIO)"
                Case "1"
                    vlTipoOp = " (ALTA)"
                Case "3"
                    vlTipoOp = " (BAJA)"
                Case Else
                    vlTipoOp = " (DESCONOCIDA)"
            End Select

            lblPercepcion.Text = "Tipo de operación: " + vlTipoOp

            drPerc = oPercepcion.ObtenPorId(CShort(Request.Params("IdPercepcion")))

            lblPercepcion2.Text = "PERCEPCIÓN: " + drPerc("Percepcion").ToString

            Dim oQna As New Quincenas
            Dim oUsr As New Usuario
            Dim dr2 As DataRow
            oUsr.Login = Session("Login")
            dr2 = oUsr.ObtenerPropiedadesDelRol().Rows(0)

            If Request.Params("TipoOperacion") = "3" Then
                Try
                    With oPercepcion
                        .IdPercCapturada = CType(Request.Params("IdPercCapturada"), Integer)
                        .IdPlaza = CType(Request.Params("IdPlaza"), Integer)
                        .IdPercepcion = CType(Request.Params("IdPercepcion"), Short)
                        .Elimina(CType(Session("ArregloAuditoria"), String()))
                    End With
                    lbOtraOperacion.Visible = False
                    MultiView1.SetActiveView(viewExito)
                    Exit Sub
                Catch ex As Exception
                    Me.lblError.Text = ex.Message
                    Me.MultiView1.SetActiveView(viewErrorNoCont)
                    Exit Sub
                End Try
            End If
            MultiView1.SetActiveView(viewPercepciones)
            If Request.Params("TipoOperacion") = "0" Then
                With oPercepcion
                    .IdPercCapturada = CType(Request.Params("IdPercCapturada"), Integer)
                    .IdPercepcion = CType(Request.Params("IdPercepcion"), Short)
                    .IdPlaza = CType(Request.Params("IdPlaza"), Integer)
                    dr = .ObtenPorIdDeCaptura()

                    oQna.IdQuincena = CShort(dr("IdQnaVigIniPerc"))
                    ddlQnaInicio.DataSource = oQna.ObtenPorId(False)
                    ddlQnaInicio.DataTextField = "Quincena"
                    ddlQnaInicio.DataValueField = "IdQuincena"
                    ddlQnaInicio.DataBind()

                    oQna.IdQuincena = CShort(dr("IdQnaVigFinPerc"))
                    ddlQnaFin.DataSource = oQna.ObtenPorId(False)
                    ddlQnaFin.DataTextField = "Quincena"
                    ddlQnaFin.DataValueField = "IdQuincena"
                    ddlQnaFin.DataBind()
                End With
                LlenaDDL(Me.ddlPercepciones, "Percepcion", "IdPercepcion", oPercepcion.ObtenPorRol(CByte(dr2("IdRol"))), dr("IdPercepcion").ToString, False)
                BindddlPlazas(dr)
            ElseIf Request.Params("TipoOperacion") = "1" Then
                LlenaDDL(Me.ddlPercepciones, "Percepcion", "IdPercepcion", oPercepcion.ObtenPorRol(CByte(dr2("IdRol"))), String.Empty)
                BindddlPlazas()

                If MultiView1.GetActiveView().ID = "viewErrorNoCont" Then Exit Sub
            End If
            If Me.ddlPlazas.Items.Count > 0 Then
                If Request.Params("TipoOperacion") = "0" Then
                    DeterminaAmbitoPercepcion(dr)
                End If
            Else
                MultiView1.SetActiveView(viewErrorNoCont)
                lblError.Text = "El empleado no tiene plazas vigentes, lo sentimos."
            End If
        End If
        'Me.btnGuardar.OnClientClick = "javascript:window.opener.doPostBack();"
    End Sub

    Protected Sub ddlPlazas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlPercepciones.SelectedIndexChanged
        DeterminaAmbitoPercepcion()
    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If Not HayErrores() Then

                Dim oPercepcion As New Percepcion
                Dim ddlQnaInicio As DropDownList = CType(WucEfectos2.FindControl("ddlQnaInicio"), DropDownList)
                Dim ddlQnaFin As DropDownList = CType(WucEfectos2.FindControl("ddlQnaFin"), DropDownList)
                Dim chbxEspecificarNumQuincenas As CheckBox = CType(WucEfectos2.FindControl("chbxEspecificarNumQuincenas"), CheckBox)
                Dim txtbxNumQnas As TextBox = CType(WucEfectos2.FindControl("txtbxNumQnas"), TextBox)
                Dim Indice As Integer = 0
                If Me.ddlPlazas.Items.Count > 1 Then Indice = 1
                With oPercepcion
                    .IdPercepcion = CShort(Request.Params("IdPercepcion")) 'CType(Me.ddlPercepciones.SelectedValue, Short)
                    .IdPlaza = IIf(Me.ddlPlazas.SelectedValue <> "-1", CType(Me.ddlPlazas.SelectedValue, Integer), CType(Me.ddlPlazas.Items(Indice).Value, Integer))
                    If Me.txtbxImportePercepcion.Enabled Then
                        .ImportePercepcion = CDec(Me.txtbxImportePercepcion.Text)
                    Else
                        .ImportePercepcion = 0
                    End If
                    .NumDias = CByte(Me.tbDiasAPagar.Text)
                    '.ImportePercepcion = IIf(Me.txtbxImportePercepcion.Enabled = True, CType(Me.txtbxImportePercepcion.Text, Decimal), 0)
                    .IdQnaInicio = CType(ddlQnaInicio.SelectedValue, Short)
                    .IdQnaFin = CType(ddlQnaFin.SelectedValue, Short)
                    .EspecificarNumQuincenas = chbxEspecificarNumQuincenas.Checked
                    If txtbxNumQnas.Text.Trim = String.Empty Then txtbxNumQnas.Text = "0"
                    .NumQnas = IIf(chbxEspecificarNumQuincenas.Checked, CType(txtbxNumQnas.Text, Byte), 0)
                    If Request.Params("TipoOperacion") = "0" Then
                        .IdPercCapturada = CType(Request.Params("IdPercCapturada"), Integer)
                        .Actualiza(Percepcion.TipoActualizacion.ParaPago, CType(Session("ArregloAuditoria"), String()))
                        lbOtraOperacion.Visible = True
                    Else
                        .Inserta(Percepcion.TipoInsercion.ParaPago, CType(Session("ArregloAuditoria"), String()))
                        lbOtraOperacion.Visible = False
                    End If
                End With
                MultiView1.SetActiveView(viewExito)
            End If
        Catch Ex As Exception
            lblError.Text = Ex.Message
            MultiView1.SetActiveView(viewErrorNoCont)
        End Try
    End Sub
    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            If MultiView1.GetActiveView().ID = "viewErrorNoCont" Then Exit Sub

            If Request.Params("TipoOperacion") = "0" Then
                Dim ddlQnaInicio As DropDownList = CType(WucEfectos2.FindControl("ddlQnaInicio"), DropDownList)
                Dim ddlQnaFin As DropDownList = CType(WucEfectos2.FindControl("ddlQnaFin"), DropDownList)
                Dim hfQnaFin As HiddenField = CType(WucEfectos2.FindControl("hfQnaFin"), HiddenField)
                Dim chbxEspecificarNumQuincenas As CheckBox = CType(WucEfectos2.FindControl("chbxEspecificarNumQuincenas"), CheckBox)
                Dim txtbxNumQnas As TextBox = CType(WucEfectos2.FindControl("txtbxNumQnas"), TextBox)
                Dim CVNumQnas As CompareValidator = CType(WucEfectos2.FindControl("CVNumQnas"), CompareValidator)
                Dim QnaMenorCaptura As String = ddlQnaFin.Items(ddlQnaFin.Items.Count - 1).Text
                Dim NumQuincenas As Byte
                Dim oMetCom As New MetodosComunes
                If ddlQnaInicio.Items.FindByText(dr("VigIniPerc").ToString) Is Nothing = False Then
                    ddlQnaInicio.SelectedItem.Selected = False
                    ddlQnaInicio.Items.FindByText(dr("VigIniPerc").ToString).Selected = True
                Else
                    Dim oQuincena As New Quincenas
                    'oQuincena.Quincena = CType(dr("VigIniPerc"), Integer)
                    oQuincena.IdQuincena = CType(dr("IdQnaVigIniPerc"), Short)
                    LlenaDDL(ddlQnaInicio, "Quincena", "IdQuincena", oQuincena.ObtenPorQuincena, String.Empty, False)
                End If
                If ddlQnaFin.Items.FindByText(dr("VigFinPerc").ToString) Is Nothing = False Then
                    ddlQnaFin.SelectedItem.Selected = False
                    ddlQnaFin.Items.FindByText(dr("VigFinPerc").ToString).Selected = True
                Else
                    ddlQnaFin.Items.Clear()
                    ddlQnaFin.Items.Insert(0, dr("VigFinPerc").ToString)
                    ddlQnaFin.Items(0).Value = "-1"
                    hfQnaFin.Value = dr("VigFinPerc").ToString
                    ddlQnaFin.Enabled = False
                    chbxEspecificarNumQuincenas.Checked = True
                    txtbxNumQnas.Text = oMetCom.DeterminaNumQuincenas(dr("VigIniPerc").ToString, dr("VigFinPerc").ToString)
                    txtbxNumQnas.Visible = True
                    With CVNumQnas
                        NumQuincenas = oMetCom.DeterminaNumQuincenas(ddlQnaInicio.SelectedItem.Text, QnaMenorCaptura)
                        .ErrorMessage = "Valor debe ser mayor o igual a " + (NumQuincenas - 1).ToString
                        .ValueToCompare = (NumQuincenas - 1).ToString
                    End With
                End If
            ElseIf Request.Params("TipoOperacion") = "1" Then
                DeterminaAmbitoPercepcion()
            End If
        Else
            If Request.Params("__EVENTTARGET") = "ctl00$ContentPlaceHolder1$WucEfectos1$ddlQnaInicio" Then
                DeterminaAmbitoPercepcion()
            End If
        End If
    End Sub

    Protected Sub ddlPercepciones_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlPercepciones.SelectedIndexChanged
        DeterminaAmbitoPercepcion()
    End Sub

    Protected Sub lbOtraOperacion_Click(sender As Object, e As System.EventArgs) Handles lbOtraOperacion.Click
        Dim strPostbackURL As String

        strPostbackURL = String.Empty
        If btnCancelar Is Nothing = False Then
            strPostbackURL = btnCancelar.PostBackUrl
        End If

        btnCancelar.PostBackUrl = strPostbackURL
        lbOtraOperacion0.PostBackUrl = strPostbackURL

        MultiView1.SetActiveView(viewPercepciones)
    End Sub

    Protected Sub lbReintentarCaptura_Click(sender As Object, e As System.EventArgs) Handles lbReintentarCaptura.Click
        MultiView1.SetActiveView(viewPercepciones)
    End Sub

    Protected Sub lbOtraOperacion2_Click(sender As Object, e As System.EventArgs) Handles lbOtraOperacion2.Click
        MultiView1.SetActiveView(viewPercepciones)
    End Sub
End Class
