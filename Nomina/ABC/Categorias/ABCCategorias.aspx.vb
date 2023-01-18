Imports DataAccessLayer.COBAEV.Empleados
Imports DataAccessLayer.COBAEV
Imports DataAccessLayer.COBAEV.Administracion
Imports DataAccessLayer.COBAEV.Nominas
Imports System.Data
Imports BusinessRulesLayer.COBAEV.Validaciones
Partial Class ABCCategorias
    Inherits System.Web.UI.Page
    Private Sub ddlTiposDeCatego_SelectedIndexChanged()
        Dim vlTipoOp As String = IIf(Request.Params("TipoOperacion") = "1", "I", IIf(Request.Params("TipoOperacion") = "0", "E", ""))
        If Request.Params("TipoOperacion") = "1" And Request.Params("CrearCopia") = "SI" Then
            vlTipoOp = "E"
        End If
        Dim ddlTiposDeCatego As DropDownList = CType(Me.dvDatosCatego.FindControl("ddlTiposDeCatego" + vlTipoOp), DropDownList)
        Dim ddlPercsParaMatDid As DropDownList = CType(Me.dvDatosCatego.FindControl("ddlPercsParaMatDid" + vlTipoOp), DropDownList)
        Dim ddlPercsParaDescHoras As DropDownList = CType(Me.dvDatosCatego.FindControl("ddlPercsParaDescHoras" + vlTipoOp), DropDownList)

        ddlPercsParaMatDid.Enabled = ddlTiposDeCatego.SelectedValue = "2"
        ddlPercsParaDescHoras.Enabled = ddlTiposDeCatego.SelectedValue = "2"
    End Sub
    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, ByVal dt As DataTable, ByVal SelectedValue As String)
        ddl.DataSource = dt
        ddl.DataTextField = TextField
        ddl.DataValueField = ValueField
        ddl.DataBind()
        If SelectedValue Is Nothing = False Then ddl.SelectedValue = SelectedValue
    End Sub
    Private Sub BindddlPercsParaMatDid(ByVal pTipoOp As String, Optional ByVal SelectedValue As String = "0")
        Dim oPerc As New Percepcion
        Dim ddlPercsParaMatDid As DropDownList = CType(Me.dvDatosCatego.FindControl("ddlPercsParaMatDid" + pTipoOp), DropDownList)
        LlenaDDL(ddlPercsParaMatDid, "PercepcionParaDDL", "IdPercepcion", oPerc.ObtenMaterialDidactico(), SelectedValue)
    End Sub
    Private Sub BindZonasEco(ByVal pTipoOp As String, Optional ByVal SelectedValue As String = "1")
        Dim oZonasEco As New ZonaEconomica
        Dim ddlZonasEco As DropDownList = CType(Me.dvDatosCatego.FindControl("ddlZonasEco" + pTipoOp), DropDownList)
        LlenaDDL(ddlZonasEco, "DescZonaEco", "IdZonaEco", oZonasEco.ObtenTodasSinComodin(), String.Empty)
        ddlZonasEco.Items.Insert(2, "ZONA ECONOMICA 2 Y 3")
        ddlZonasEco.Items(2).Value = "3"
        ddlZonasEco.SelectedValue = SelectedValue
    End Sub
    Private Sub BindTiposDeCatego(ByVal pTipoOp As String, Optional ByVal SelectedValue As String = "1")
        Dim oCatego As New Categoria
        Dim ddlTiposDeCatego As DropDownList = CType(Me.dvDatosCatego.FindControl("ddlTiposDeCatego" + pTipoOp), DropDownList)
        LlenaDDL(ddlTiposDeCatego, "DescEmpFuncion", "IdEmpFuncion", oCatego.ObtenTipificadores(), SelectedValue)
    End Sub
    Private Sub BindddlPercsParaDescHoras(ByVal pTipoOp As String, Optional ByVal SelectedValue As String = "0")
        Dim oPerc As New Percepcion
        Dim ddlPercsParaDescHoras As DropDownList = CType(Me.dvDatosCatego.FindControl("ddlPercsParaDescHoras" + pTipoOp), DropDownList)
        LlenaDDL(ddlPercsParaDescHoras, "PercepcionParaDDL", "IdPercepcion", oPerc.ObtenReferentesADescDeHoras(), SelectedValue)
    End Sub
    Private Sub BindddlCategosRP(ByVal pTipoOp As String, Optional ByVal SelectedValue As String = "0")
        Dim oCatego As New Categoria
        Dim ddlCategosRP As DropDownList = CType(Me.dvDatosCatego.FindControl("ddlCategosRP" + pTipoOp), DropDownList)
        LlenaDDL(ddlCategosRP, "CategoriaParaDDL", "IdCategoria", oCatego.ObtenSoloRP(True), SelectedValue)
    End Sub

    Private Sub BindddlFuncsPrim(ByVal pTipoOp As String, Optional ByVal SelectedValue As String = "")
        Dim oCatego As New Empleado
        Dim ddlFuncsPrim As DropDownList = CType(Me.dvDatosCatego.FindControl("ddlFuncsPrim" + pTipoOp), DropDownList)
        LlenaDDL(ddlFuncsPrim, "FuncionPri", "IdFuncionPri", oCatego.ObtenFuncionesPrimarias(), SelectedValue)
    End Sub
 
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim vlTipoOp As String

            vlTipoOp = IIf(Request.Params("TipoOperacion") = "1", "I", IIf(Request.Params("TipoOperacion") = "0", "E", ""))

            lblTipoOp.Text = IIf(vlTipoOp = "I", "Captura", IIf(vlTipoOp = "E", "Modificación", "Consulta"))

            If Request.Params("TipoOperacion") = "1" And Request.Params("CrearCopia") = "SI" Then
                vlTipoOp = "E"
                lblTipoOp.Text = "Captura"
            End If

            Dim lblIdCategoria As Label = CType(Me.dvDatosCatego.FindControl("lblIdCategoria" + vlTipoOp), Label)
            Dim lblClaveCategoria As Label = CType(Me.dvDatosCatego.FindControl("lblClaveCategoria" + vlTipoOp), Label)
            Dim txtbxDescCategoria As TextBox = CType(Me.dvDatosCatego.FindControl("txtbxDescCategoria" + vlTipoOp), TextBox)
            Dim oCatego As New Categoria
            Dim drCatego As DataRow

            If Request.Params("TipoOperacion") = "1" And Request.Params("CrearCopia") = "NO" Then
                Me.MultiView1.SetActiveView(Me.viewCaptura)
                lblIdCategoria.Text = "0"
                lblClaveCategoria.Text = oCatego.ObtenNuevaClave.Rows(0).Item("NuevaClaveCategoria").ToString()
                BindTiposDeCatego(vlTipoOp)
                BindddlPercsParaMatDid(vlTipoOp)
                BindddlPercsParaDescHoras(vlTipoOp)
                ddlTiposDeCatego_SelectedIndexChanged()
                BindZonasEco(vlTipoOp)
                BindddlCategosRP(vlTipoOp)
                BindddlFuncsPrim(vlTipoOp)
            ElseIf Request.Params("TipoOperacion") = "1" And Request.Params("CrearCopia") = "SI" Then
                Me.MultiView1.SetActiveView(Me.viewCaptura)
                Me.dvDatosCatego.ChangeMode(DetailsViewMode.Edit)
                drCatego = oCatego.ObtenParaUpdate(CShort(Request.Params("IdCategoria")))
                Me.dvDatosCatego.DataSource = drCatego.Table
                Me.dvDatosCatego.DataBind()

                lblIdCategoria = CType(Me.dvDatosCatego.FindControl("lblIdCategoria" + vlTipoOp), Label)
                lblClaveCategoria = CType(Me.dvDatosCatego.FindControl("lblClaveCategoria" + vlTipoOp), Label)
                txtbxDescCategoria = CType(Me.dvDatosCatego.FindControl("txtbxDescCategoria" + vlTipoOp), TextBox)

                lblIdCategoria.Text = "0"
                lblClaveCategoria.Text = oCatego.ObtenNuevaClave.Rows(0).Item("NuevaClaveCategoria").ToString()
                txtbxDescCategoria.Text = String.Empty

                BindTiposDeCatego(vlTipoOp, drCatego("IdEmpFuncion").ToString)
                BindddlPercsParaMatDid(vlTipoOp, drCatego("IdPercMatDid").ToString)
                BindddlPercsParaDescHoras(vlTipoOp, drCatego("IdPercepcionHoras").ToString)
                ddlTiposDeCatego_SelectedIndexChanged()
                BindZonasEco(vlTipoOp, drCatego("IdZonaEco").ToString)
                BindddlCategosRP(vlTipoOp, drCatego("IdCategoriaRP").ToString)
                BindddlFuncsPrim(vlTipoOp, drCatego("IdFuncionPri").ToString)
            ElseIf Request.Params("TipoOperacion") = "0" Then
                Me.MultiView1.SetActiveView(Me.viewCaptura)
                Me.dvDatosCatego.ChangeMode(DetailsViewMode.Edit)
                drCatego = oCatego.ObtenParaUpdate(CShort(Request.Params("IdCategoria")))
                Me.dvDatosCatego.DataSource = drCatego.Table
                Me.dvDatosCatego.DataBind()

                BindTiposDeCatego(vlTipoOp, drCatego("IdEmpFuncion").ToString)
                BindddlPercsParaMatDid(vlTipoOp, drCatego("IdPercMatDid").ToString)
                BindddlPercsParaDescHoras(vlTipoOp, drCatego("IdPercepcionHoras").ToString)
                ddlTiposDeCatego_SelectedIndexChanged()
                BindZonasEco(vlTipoOp, drCatego("IdZonaEco").ToString)
                BindddlCategosRP(vlTipoOp, drCatego("IdCategoriaRP").ToString)
                BindddlFuncsPrim(vlTipoOp, drCatego("IdFuncionPri").ToString)
            ElseIf Request.Params("TipoOperacion") = "4" Then
                Me.MultiView1.SetActiveView(Me.viewCaptura)
                Me.dvDatosCatego.ChangeMode(DetailsViewMode.ReadOnly)
                drCatego = oCatego.ObtenParaUpdate(CShort(Request.Params("IdCategoria")))
                Me.dvDatosCatego.DataSource = drCatego.Table
                Me.dvDatosCatego.DataBind()

                BindTiposDeCatego(vlTipoOp, drCatego("IdEmpFuncion").ToString)
                BindddlPercsParaMatDid(vlTipoOp, drCatego("IdPercMatDid").ToString)
                BindddlPercsParaDescHoras(vlTipoOp, drCatego("IdPercepcionHoras").ToString)
                ddlTiposDeCatego_SelectedIndexChanged()
                BindZonasEco(vlTipoOp, drCatego("IdZonaEco").ToString)
                BindddlCategosRP(vlTipoOp, drCatego("IdCategoriaRP").ToString)
                BindddlFuncsPrim(vlTipoOp, drCatego("IdFuncionPri").ToString)
            End If
        End If
    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim vlTipoOp As String

            vlTipoOp = IIf(Request.Params("TipoOperacion") = "1", "I", IIf(Request.Params("TipoOperacion") = "0", "E", ""))

            If Request.Params("TipoOperacion") = "1" And Request.Params("CrearCopia") = "SI" Then
                vlTipoOp = "E"
            End If

            Dim lblIdCategoria As Label = CType(Me.dvDatosCatego.FindControl("lblIdCategoria" + vlTipoOp), Label)
            Dim lblClaveCategoria As Label = CType(Me.dvDatosCatego.FindControl("lblClaveCategoria" + vlTipoOp), Label)
            Dim txtbxDescCategoria As TextBox = CType(Me.dvDatosCatego.FindControl("txtbxDescCategoria" + vlTipoOp), TextBox)
            Dim txtbxPuesto As TextBox = CType(Me.dvDatosCatego.FindControl("txtbxPuesto" + vlTipoOp), TextBox)
            Dim ddlTiposDeCatego As DropDownList = CType(Me.dvDatosCatego.FindControl("ddlTiposDeCatego" + vlTipoOp), DropDownList)
            Dim ddlPercsParaMatDid As DropDownList = CType(Me.dvDatosCatego.FindControl("ddlPercsParaMatDid" + vlTipoOp), DropDownList)
            Dim ddlPercsParaDescHoras As DropDownList = CType(Me.dvDatosCatego.FindControl("ddlPercsParaDescHoras" + vlTipoOp), DropDownList)
            Dim ddlZonasEco As DropDownList = CType(Me.dvDatosCatego.FindControl("ddlZonasEco" + vlTipoOp), DropDownList)
            Dim txtbxNumHoras As TextBox = CType(Me.dvDatosCatego.FindControl("txtbxNumHoras" + vlTipoOp), TextBox)
            Dim chbxRecursosPropios As CheckBox = CType(Me.dvDatosCatego.FindControl("chbxRecursosPropios" + vlTipoOp), CheckBox)
            Dim chbxActiva As CheckBox = CType(Me.dvDatosCatego.FindControl("chbxActiva" + vlTipoOp), CheckBox)
            Dim chbxCategoriaTecnicaDocente As CheckBox = CType(Me.dvDatosCatego.FindControl("chbxCategoriaTecnicaDocente" + vlTipoOp), CheckBox)
            Dim chbxTieneCategoAsocRP As CheckBox = CType(Me.dvDatosCatego.FindControl("chbxTieneCategoAsocRP" + vlTipoOp), CheckBox)
            Dim ddlCategosRP As DropDownList = CType(Me.dvDatosCatego.FindControl("ddlCategosRP" + vlTipoOp), DropDownList)
            Dim ddlFuncsPrim As DropDownList = CType(Me.dvDatosCatego.FindControl("ddlFuncsPrim" + vlTipoOp), DropDownList)
            Dim chbxEsCategoHomologada As CheckBox = CType(Me.dvDatosCatego.FindControl("chbxEsCategoHomologada" + vlTipoOp), CheckBox)
            ''Código de validación
            'Dim oValidacion As New Validaciones
            'Dim _DataCOBAEV As New DataCOBAEV
            'Dim dsValida As DataSet
            'dsValida = _DataCOBAEV.setDataSetErrores()

            'With oValidacion
            '    .NombrePagina = Request.Url.Segments(Request.Url.Segments.Length - 1).ToString
            '    .TipoOperacion = IIf(Request.Params("TipoOperacion") Is Nothing, 5, CByte(Request.Params("TipoOperacion")))
            '    .RFC = txtbxRFC.Text.Trim
            '    .CURPEmp = txtbxCURP.Text.Trim
            '    If Not .ValidaPaginasOperacion(dsValida) Then
            '        Session.Add("dsValida", dsValida)
            '        Response.Redirect("~/ErroresPagina.aspx?Home=SI")
            '    Else
            '        Session.Remove("dsValida")
            '    End If
            'End With
            ''Código de validación


            Dim oCatego As New Categoria
            With oCatego
                .IdCategoria = CShort(lblIdCategoria.Text)
                .ClaveCategoria = lblClaveCategoria.Text.Trim
                .DescCategoria = txtbxDescCategoria.Text.Trim.ToUpper
                .Puesto = txtbxPuesto.Text.Trim.ToUpper
                .IdEmpFuncion = CByte(ddlTiposDeCatego.SelectedValue)
                .IdPercMatDid = CShort(ddlPercsParaMatDid.SelectedValue)
                .IdPercepcionHoras = CShort(ddlPercsParaDescHoras.SelectedValue)
                .IdZonaEco = CByte(ddlZonasEco.SelectedValue)
                .Horas = CByte(IIf(txtbxNumHoras.Text.Trim = String.Empty, "0", txtbxNumHoras.Text))
                .RecursosPropios = chbxRecursosPropios.Checked
                .Activa = chbxActiva.Checked
                .CategoriaTecnicaDocente = chbxCategoriaTecnicaDocente.Checked
                .TieneCategoAsocRP = chbxTieneCategoAsocRP.Checked
                .IdCategoriaRP = CShort(ddlCategosRP.SelectedValue)
                .IdFuncionPri = CShort(ddlFuncsPrim.SelectedValue)
                .EsCategoHomologada = chbxEsCategoHomologada.Checked

                If Request.Params("TipoOperacion") = "1" Then
                    .CrearNueva(CType(Session("ArregloAuditoria"), String()))
                ElseIf Request.Params("TipoOperacion") = "0" Then
                    .ActualizaInf(CType(Session("ArregloAuditoria"), String()))
                End If
            End With
            Me.MultiView1.SetActiveView(viewCapturaExitosa)
        Catch Ex As Exception
            Me.lblErrores.Text = Ex.Message
            Me.MultiView1.SetActiveView(Me.viewErrores)
        End Try
    End Sub

    Protected Sub lbReintentarCaptura_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbReintentarCaptura.Click
        Me.MultiView1.SetActiveView(Me.viewCaptura)
    End Sub

    Protected Sub ddlTiposDeCatego_SelectedIndexChanged(sender As Object, e As System.EventArgs)
        ddlTiposDeCatego_SelectedIndexChanged()
    End Sub

    Protected Sub chbxTieneCategoAsocRP_CheckedChanged(sender As Object, e As System.EventArgs)
        Dim vlTipoOp As String = IIf(Request.Params("TipoOperacion") = "1", "I", IIf(Request.Params("TipoOperacion") = "0", "E", ""))
        If Request.Params("TipoOperacion") = "1" And Request.Params("CrearCopia") = "SI" Then
            vlTipoOp = "E"
        End If
        Dim ddlCategosRP As DropDownList = CType(Me.dvDatosCatego.FindControl("ddlCategosRP" + vlTipoOp), DropDownList)
        Dim chbxTieneCategoAsocRP As CheckBox = CType(Me.dvDatosCatego.FindControl("chbxTieneCategoAsocRP" + vlTipoOp), CheckBox)

        ddlCategosRP.Enabled = chbxTieneCategoAsocRP.Checked
    End Sub

End Class
