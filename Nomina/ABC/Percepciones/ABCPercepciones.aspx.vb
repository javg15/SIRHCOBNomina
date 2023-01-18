Imports DataAccessLayer.COBAEV.Empleados
Imports DataAccessLayer.COBAEV
Imports DataAccessLayer.COBAEV.Administracion
Imports DataAccessLayer.COBAEV.Nominas
Imports System.Data
Imports BusinessRulesLayer.COBAEV.Validaciones
Partial Class ABCPercepciones
    Inherits System.Web.UI.Page
    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, ByVal dt As DataTable, ByVal SelectedValue As String)
        ddl.DataSource = dt
        ddl.DataTextField = TextField
        ddl.DataValueField = ValueField
        ddl.DataBind()
        If SelectedValue Is Nothing = False Then ddl.SelectedValue = SelectedValue
    End Sub
    Private Sub BindAmbitoAplic(ByVal pTipoOp As String, Optional ByVal SelectedValue As String = "3")
        Dim oNomina As New Nomina
        Dim ddlAmbitoAplic As DropDownList = CType(Me.dvDatosPerc.FindControl("ddlAmbitoAplic" + pTipoOp), DropDownList)
        LlenaDDL(ddlAmbitoAplic, "DescAmbitoConcepto", "IdAmbitoConcepto", oNomina.ObtenAmbitoAplicDePercDeduc(), SelectedValue)
    End Sub
    Private Sub BindSPs(ByVal pTipoOp As String, Optional ByVal SelectedValue As String = "1")
        Dim oSPs As New Aplicacion
        Dim ddlSPs As DropDownList = CType(Me.dvDatosPerc.FindControl("ddlSPs" + pTipoOp), DropDownList)
        LlenaDDL(ddlSPs, "NombreProc", "IdProc", oSPs.ObtenDeBDNomina(), SelectedValue)
    End Sub
    Private Sub BindZonasEco(ByVal pTipoOp As String, Optional ByVal SelectedValue As String = "3")
        Dim oZonasEco As New ZonaEconomica
        Dim ddlZonasEco As DropDownList = CType(Me.dvDatosPerc.FindControl("ddlZonasEco" + pTipoOp), DropDownList)
        LlenaDDL(ddlZonasEco, "DescZonaEco", "IdZonaEco", oZonasEco.ObtenTodasSinComodin(), String.Empty)
        ddlZonasEco.Items.Insert(2, "ZONA ECONOMICA 2 Y 3")
        ddlZonasEco.Items(2).Value = "3"
        ddlZonasEco.SelectedValue = SelectedValue
    End Sub
    Private Sub BindTiposDeEmp(ByVal pTipoOp As String, Optional ByVal SelectedValue As String = "4")
        Dim oEmpFuncion As New EmpleadoFuncion
        Dim ddlTiposDeEmp As DropDownList = CType(Me.dvDatosPerc.FindControl("ddlTiposDeEmp" + pTipoOp), DropDownList)
        LlenaDDL(ddlTiposDeEmp, "DescEmpFuncion", "IdEmpFuncion", oEmpFuncion.ObtenTodas(), SelectedValue)
    End Sub
    Private Sub BindddlPercsPadre(ByVal pTipoOp As String, Optional ByVal SelectedValue As String = "")
        Dim oPercs As New Percepcion
        Dim ddlPercsPadre As DropDownList = CType(Me.dvDatosPerc.FindControl("ddlPercsPadre" + pTipoOp), DropDownList)
        Dim chbxTienePercPadre As CheckBox = CType(Me.dvDatosPerc.FindControl("chbxTienePercPadre" + pTipoOp), CheckBox)
        LlenaDDL(ddlPercsPadre, "NombrePercepcionParaDDL", "IdPercepcion", oPercs.ObtenNoFicticias(), SelectedValue)

        ddlPercsPadre.Enabled = chbxTienePercPadre.Checked And pTipoOp <> ""
    End Sub
    Private Sub BindddlPercsParaRelComoAdeudo(ByVal pTipoOp As String, Optional ByVal SelectedValue As String = "")
        Dim oPercs As New Percepcion
        Dim ddlPercsParaRelComoAdeudo As DropDownList = CType(Me.dvDatosPerc.FindControl("ddlPercsParaRelComoAdeudo" + pTipoOp), DropDownList)
        Dim chbxSeraPercDeAdeudo As CheckBox = CType(Me.dvDatosPerc.FindControl("chbxSeraPercDeAdeudo" + pTipoOp), CheckBox)
        LlenaDDL(ddlPercsParaRelComoAdeudo, "NombrePercepcionParaDDL", "IdPercepcion", oPercs.ObtenNoFicticias(True), SelectedValue)

        ddlPercsParaRelComoAdeudo.Enabled = chbxSeraPercDeAdeudo.Checked And pTipoOp <> ""
    End Sub
    Private Sub BindddlFormasDePago(ByVal pTipoOp As String, pNombreDDL As String, Optional ByVal SelectedValue As String = "")
        Dim oPercs As New Percepcion
        Dim ddlFormasDePago As DropDownList = CType(Me.dvDatosPerc.FindControl(pNombreDDL + pTipoOp), DropDownList)

        LlenaDDL(ddlFormasDePago, "DescFormaDePago", "IdFormaDePago", oPercs.ObtenFormasDePago(), SelectedValue)
    End Sub
    Private Sub BindddlDeducsContrarias(ByVal pTipoOp As String, Optional ByVal SelectedValue As String = "")
        Dim oDeducs As New Deduccion
        Dim ddlDeducsContrarias As DropDownList = CType(Me.dvDatosPerc.FindControl("ddlDeducsContrarias" + pTipoOp), DropDownList)
        Dim chbxDeduccionContraria As CheckBox = CType(Me.dvDatosPerc.FindControl("chbxDeduccionContraria" + pTipoOp), CheckBox)
        LlenaDDL(ddlDeducsContrarias, "NombreDeduccionParaDDL", "IdDeduccion", oDeducs.ObtenParaRelacionarConPercepcion(), SelectedValue)

        ddlDeducsContrarias.Enabled = chbxDeduccionContraria.Checked And pTipoOp <> ""
    End Sub
    Private Sub BindddlPercsParaRelComoRetro(ByVal pTipoOp As String, Optional ByVal SelectedValue As String = "")
        Dim oPercs As New Percepcion
        Dim ddlPercsParaRelComoRetro As DropDownList = CType(Me.dvDatosPerc.FindControl("ddlPercsParaRelComoRetro" + pTipoOp), DropDownList)
        Dim chbxSeraPercDeRetro As CheckBox = CType(Me.dvDatosPerc.FindControl("chbxSeraPercDeRetro" + pTipoOp), CheckBox)
        LlenaDDL(ddlPercsParaRelComoRetro, "NombrePercepcionParaDDL", "IdPercepcion", oPercs.ObtenNoFicticias(False, True), SelectedValue)
        'If SelectedValue <> "" And SelectedValue Is Nothing = False Then ddlPercsParaRelComoRetro.Items.FindByValue(SelectedValue).Selected = True
        ddlPercsParaRelComoRetro.Enabled = chbxSeraPercDeRetro.Checked And pTipoOp <> ""
    End Sub
    Private Sub BindddlNumQnasReqParaCalc(ByVal pTipoOp As String, Optional ByVal SelectedValue As String = "0")
        Dim oPercs As New Percepcion
        Dim ddlNumQnasReqParaCalc As DropDownList = CType(Me.dvDatosPerc.FindControl("ddlNumQnasReqParaCalc" + pTipoOp), DropDownList)
        ddlNumQnasReqParaCalc.SelectedValue = SelectedValue
    End Sub

    Private Sub BindddlddlHoras(ByVal pTipoOp As String, Optional ByVal SelectedValue As String = "")
        Dim oPercs As New Percepcion
        Dim ddlHoras As DropDownList = CType(Me.dvDatosPerc.FindControl("ddlHoras" + pTipoOp), DropDownList)

        ddlHoras.SelectedValue = SelectedValue
    End Sub
    Private Sub BindddlPercsSAT(ByVal pTipoOp As String, Optional ByVal SelectedValue As String = "")
        Dim oPerc As New Percepcion
        Dim ddlPercsSAT As DropDownList = CType(Me.dvDatosPerc.FindControl("ddlPercsSAT" + pTipoOp), DropDownList)

        LlenaDDL(ddlPercsSAT, "DescTipoPercSATParaDDL", "IdTipoPercSAT", oPerc.ObtenClasifSAT(), SelectedValue)
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

            Dim lblIdPercepcion As Label = CType(Me.dvDatosPerc.FindControl("lblIdPercepcion" + vlTipoOp), Label)
            Dim lblClavePercepcion As Label = CType(Me.dvDatosPerc.FindControl("lblClavePercepcion" + vlTipoOp), Label)
            Dim txtbxNombrePercepcion As TextBox = CType(Me.dvDatosPerc.FindControl("txtbxNombrePercepcion" + vlTipoOp), TextBox)
            Dim oPerc As New Percepcion
            Dim drPerc As DataRow

            If Request.Params("TipoOperacion") = "1" And Request.Params("CrearCopia") = "NO" Then
                Me.MultiView1.SetActiveView(Me.viewCaptura)
                lblIdPercepcion.Text = "0"
                lblClavePercepcion.Text = oPerc.ObtenNuevaClave.Rows(0).Item("NuevaClavePercepcion").ToString()
                BindSPs(vlTipoOp)
                BindAmbitoAplic(vlTipoOp)
                BindZonasEco(vlTipoOp)
                BindTiposDeEmp(vlTipoOp)
                BindddlPercsPadre(vlTipoOp)
                BindddlDeducsContrarias(vlTipoOp)
                BindddlPercsParaRelComoAdeudo(vlTipoOp)
                BindddlPercsParaRelComoRetro(vlTipoOp)
                BindddlNumQnasReqParaCalc(vlTipoOp)
                BindddlFormasDePago(vlTipoOp, "ddlFormasDePago1A")
                BindddlFormasDePago(vlTipoOp, "ddlFormasDePago1D")
                BindddlFormasDePago(vlTipoOp, "ddlFormasDePago2A")
                BindddlFormasDePago(vlTipoOp, "ddlFormasDePago2D")
                BindddlPercsSAT(vlTipoOp)
            ElseIf Request.Params("TipoOperacion") = "1" And Request.Params("CrearCopia") = "SI" Then
                Me.MultiView1.SetActiveView(Me.viewCaptura)
                Me.dvDatosPerc.ChangeMode(DetailsViewMode.Edit)
                drPerc = oPerc.ObtenParaUpdate(CShort(Request.Params("IdPercepcion")), True)
                Me.dvDatosPerc.DataSource = drPerc.Table
                Me.dvDatosPerc.DataBind()

                lblIdPercepcion = CType(Me.dvDatosPerc.FindControl("lblIdPercepcion" + vlTipoOp), Label)
                lblClavePercepcion = CType(Me.dvDatosPerc.FindControl("lblClavePercepcion" + vlTipoOp), Label)
                txtbxNombrePercepcion = CType(Me.dvDatosPerc.FindControl("txtbxNombrePercepcion" + vlTipoOp), TextBox)

                lblIdPercepcion.Text = "0"
                lblClavePercepcion.Text = oPerc.ObtenNuevaClave.Rows(0).Item("NuevaClavePercepcion").ToString()
                txtbxNombrePercepcion.Text = String.Empty

                BindSPs(vlTipoOp, drPerc("IdProc").ToString)
                BindAmbitoAplic(vlTipoOp, drPerc("IdAmbitoConcepto").ToString)
                BindZonasEco(vlTipoOp, drPerc("IdZonaEco").ToString)
                BindTiposDeEmp(vlTipoOp, drPerc("IdEmpFuncion").ToString)
                BindddlddlHoras(vlTipoOp, drPerc("Horas").ToString)
                BindddlPercsPadre(vlTipoOp, drPerc("IdPercepcionPadre").ToString)
                BindddlDeducsContrarias(vlTipoOp, drPerc("IdDeducContrariaDePerc").ToString)
                BindddlPercsParaRelComoAdeudo(vlTipoOp, drPerc("IdPercAdeudoDePerc").ToString)
                BindddlPercsParaRelComoRetro(vlTipoOp, drPerc("IdPercRetroDePerc").ToString)
                BindddlNumQnasReqParaCalc(vlTipoOp, drPerc("NumQnasRequeridas").ToString)
                BindddlFormasDePago(vlTipoOp, "ddlFormasDePago1A", drPerc("IdFormaDePago1A").ToString)
                BindddlFormasDePago(vlTipoOp, "ddlFormasDePago1D", drPerc("IdFormaDePago1D").ToString)
                BindddlFormasDePago(vlTipoOp, "ddlFormasDePago2A", drPerc("IdFormaDePago2A").ToString)
                BindddlFormasDePago(vlTipoOp, "ddlFormasDePago2D", drPerc("IdFormaDePago2D").ToString)
                BindddlPercsSAT(vlTipoOp, drPerc("IdTipoPercSAT").ToString)
            ElseIf Request.Params("TipoOperacion") = "0" Then
                Me.MultiView1.SetActiveView(Me.viewCaptura)
                Me.dvDatosPerc.ChangeMode(DetailsViewMode.Edit)
                drPerc = oPerc.ObtenParaUpdate(CShort(Request.Params("IdPercepcion")), True)
                Me.dvDatosPerc.DataSource = drPerc.Table
                Me.dvDatosPerc.DataBind()
                BindSPs(vlTipoOp, drPerc("IdProc").ToString)
                BindAmbitoAplic(vlTipoOp, drPerc("IdAmbitoConcepto").ToString)
                BindZonasEco(vlTipoOp, drPerc("IdZonaEco").ToString)
                BindTiposDeEmp(vlTipoOp, drPerc("IdEmpFuncion").ToString)
                BindddlddlHoras(vlTipoOp, drPerc("Horas").ToString)
                BindddlPercsPadre(vlTipoOp, drPerc("IdPercepcionPadre").ToString)
                BindddlDeducsContrarias(vlTipoOp, drPerc("IdDeducContrariaDePerc").ToString)
                BindddlPercsParaRelComoAdeudo(vlTipoOp, drPerc("IdPercAdeudoDePerc").ToString)
                BindddlPercsParaRelComoRetro(vlTipoOp, drPerc("IdPercRetroDePerc").ToString)
                BindddlNumQnasReqParaCalc(vlTipoOp, drPerc("NumQnasRequeridas").ToString)
                BindddlFormasDePago(vlTipoOp, "ddlFormasDePago1A", drPerc("IdFormaDePago1A").ToString)
                BindddlFormasDePago(vlTipoOp, "ddlFormasDePago1D", drPerc("IdFormaDePago1D").ToString)
                BindddlFormasDePago(vlTipoOp, "ddlFormasDePago2A", drPerc("IdFormaDePago2A").ToString)
                BindddlFormasDePago(vlTipoOp, "ddlFormasDePago2D", drPerc("IdFormaDePago2D").ToString)
                BindddlPercsSAT(vlTipoOp, drPerc("IdTipoPercSAT").ToString)
            ElseIf Request.Params("TipoOperacion") = "4" Then
                Me.MultiView1.SetActiveView(Me.viewCaptura)
                Me.dvDatosPerc.ChangeMode(DetailsViewMode.ReadOnly)
                drPerc = oPerc.ObtenParaUpdate(CShort(Request.Params("IdPercepcion")), True)
                Me.dvDatosPerc.DataSource = drPerc.Table
                Me.dvDatosPerc.DataBind()
                BindSPs(vlTipoOp, drPerc("IdProc").ToString)
                BindAmbitoAplic(vlTipoOp, drPerc("IdAmbitoConcepto").ToString)
                BindZonasEco(vlTipoOp, drPerc("IdZonaEco").ToString)
                BindTiposDeEmp(vlTipoOp, drPerc("IdEmpFuncion").ToString)
                BindddlddlHoras(vlTipoOp, drPerc("Horas").ToString)
                BindddlPercsPadre(vlTipoOp, drPerc("IdPercepcionPadre").ToString)
                BindddlDeducsContrarias(vlTipoOp, drPerc("IdDeducContrariaDePerc").ToString)
                BindddlPercsParaRelComoAdeudo(vlTipoOp, drPerc("IdPercAdeudoDePerc").ToString)
                BindddlPercsParaRelComoRetro(vlTipoOp, drPerc("IdPercRetroDePerc").ToString)
                BindddlNumQnasReqParaCalc(vlTipoOp, drPerc("NumQnasRequeridas").ToString)
                BindddlFormasDePago(vlTipoOp, "ddlFormasDePago1A", drPerc("IdFormaDePago1A").ToString)
                BindddlFormasDePago(vlTipoOp, "ddlFormasDePago1D", drPerc("IdFormaDePago1D").ToString)
                BindddlFormasDePago(vlTipoOp, "ddlFormasDePago2A", drPerc("IdFormaDePago2A").ToString)
                BindddlFormasDePago(vlTipoOp, "ddlFormasDePago2D", drPerc("IdFormaDePago2D").ToString)
                BindddlPercsSAT(vlTipoOp, drPerc("IdTipoPercSAT").ToString)
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

            Dim lblIdPercepcion As Label = CType(Me.dvDatosPerc.FindControl("lblIdPercepcion" + vlTipoOp), Label)
            Dim lblClavePercepcion As Label = CType(Me.dvDatosPerc.FindControl("lblClavePercepcion" + vlTipoOp), Label)
            Dim txtbxNombrePercepcion As TextBox = CType(Me.dvDatosPerc.FindControl("txtbxNombrePercepcion" + vlTipoOp), TextBox)
            Dim ddlSPs As DropDownList = CType(Me.dvDatosPerc.FindControl("ddlSPs" + vlTipoOp), DropDownList)
            Dim chbxMostrarParaCaptura As CheckBox = CType(Me.dvDatosPerc.FindControl("chbxMostrarParaCaptura" + vlTipoOp), CheckBox)
            Dim ddlAmbitoAplic As DropDownList = CType(Me.dvDatosPerc.FindControl("ddlAmbitoAplic" + vlTipoOp), DropDownList)
            Dim chbxActiva As CheckBox = CType(Me.dvDatosPerc.FindControl("chbxActiva" + vlTipoOp), CheckBox)
            Dim chbxEfectosAbiertos As CheckBox = CType(Me.dvDatosPerc.FindControl("chbxEfectosAbiertos" + vlTipoOp), CheckBox)
            Dim txtbxNumQnas As TextBox = CType(Me.dvDatosPerc.FindControl("txtbxNumQnas" + vlTipoOp), TextBox)
            Dim ddlZonasEco As DropDownList = CType(Me.dvDatosPerc.FindControl("ddlZonasEco" + vlTipoOp), DropDownList)
            Dim ddlTiposDeEmp As DropDownList = CType(Me.dvDatosPerc.FindControl("ddlTiposDeEmp" + vlTipoOp), DropDownList)
            Dim txtbxURL As TextBox = CType(Me.dvDatosPerc.FindControl("txtbxURL" + vlTipoOp), TextBox)
            Dim ddlHoras As DropDownList = CType(Me.dvDatosPerc.FindControl("ddlHoras" + vlTipoOp), DropDownList)
            Dim chbxDosPorcNomina As CheckBox = CType(Me.dvDatosPerc.FindControl("chbxDosPorcNomina" + vlTipoOp), CheckBox)
            Dim chbxValidaParaRP As CheckBox = CType(Me.dvDatosPerc.FindControl("chbxDosPorcNomina" + vlTipoOp), CheckBox)
            Dim chbxTienePercPadre As CheckBox = CType(Me.dvDatosPerc.FindControl("chbxTienePercPadre" + vlTipoOp), CheckBox)
            Dim ddlPercsPadre As DropDownList = CType(Me.dvDatosPerc.FindControl("ddlPercsPadre" + vlTipoOp), DropDownList)
            Dim chbxImpuestoAbsorbidoPorColegio As CheckBox = CType(Me.dvDatosPerc.FindControl("chbxImpuestoAbsorbidoPorColegio" + vlTipoOp), CheckBox)
            Dim chbxOrdinaria As CheckBox = CType(Me.dvDatosPerc.FindControl("chbxOrdinaria" + vlTipoOp), CheckBox)
            Dim chbxMasiva As CheckBox = CType(Me.dvDatosPerc.FindControl("chbxMasiva" + vlTipoOp), CheckBox)
            Dim chbxRequiereDias As CheckBox = CType(Me.dvDatosPerc.FindControl("chbxRequiereDias" + vlTipoOp), CheckBox)
            Dim chbxIncluirParaRecibos As CheckBox = CType(Me.dvDatosPerc.FindControl("chbxIncluirParaRecibos" + vlTipoOp), CheckBox)
            Dim chbxConceptoIndemnizatorio As CheckBox = CType(Me.dvDatosPerc.FindControl("chbxConceptoIndemnizatorio" + vlTipoOp), CheckBox)
            Dim chbxPercepcionPorLey As CheckBox = CType(Me.dvDatosPerc.FindControl("chbxPercepcionPorLey" + vlTipoOp), CheckBox)
            Dim chbxFicticia As CheckBox = CType(Me.dvDatosPerc.FindControl("chbxFicticia" + vlTipoOp), CheckBox)
            Dim chbxDeduccionContraria As CheckBox = CType(Me.dvDatosPerc.FindControl("chbxDeduccionContraria" + vlTipoOp), CheckBox)
            Dim ddlDeducsContrarias As DropDownList = CType(Me.dvDatosPerc.FindControl("ddlDeducsContrarias" + vlTipoOp), DropDownList)
            Dim chbxSeraPercDeAdeudo As CheckBox = CType(Me.dvDatosPerc.FindControl("chbxSeraPercDeAdeudo" + vlTipoOp), CheckBox)
            Dim ddlPercsParaRelComoAdeudo As DropDownList = CType(Me.dvDatosPerc.FindControl("ddlPercsParaRelComoAdeudo" + vlTipoOp), DropDownList)
            Dim chbxSeraPercDeRetro As CheckBox = CType(Me.dvDatosPerc.FindControl("chbxSeraPercDeRetro" + vlTipoOp), CheckBox)
            Dim ddlPercsParaRelComoRetro As DropDownList = CType(Me.dvDatosPerc.FindControl("ddlPercsParaRelComoRetro" + vlTipoOp), DropDownList)
            Dim ddlNumQnasReqParaCalc As DropDownList = CType(Me.dvDatosPerc.FindControl("ddlNumQnasReqParaCalc" + vlTipoOp), DropDownList)
            Dim ddlFormasDePago1A As DropDownList = CType(Me.dvDatosPerc.FindControl("ddlFormasDePago1A" + vlTipoOp), DropDownList)
            Dim ddlFormasDePago1D As DropDownList = CType(Me.dvDatosPerc.FindControl("ddlFormasDePago1D" + vlTipoOp), DropDownList)
            Dim ddlFormasDePago2A As DropDownList = CType(Me.dvDatosPerc.FindControl("ddlFormasDePago2A" + vlTipoOp), DropDownList)
            Dim ddlFormasDePago2D As DropDownList = CType(Me.dvDatosPerc.FindControl("ddlFormasDePago2D" + vlTipoOp), DropDownList)
            Dim ddlPercsSAT As DropDownList = CType(Me.dvDatosPerc.FindControl("ddlPercsSAT" + vlTipoOp), DropDownList)
            Dim chbxDerivadaDePercsDeducs As CheckBox = CType(Me.dvDatosPerc.FindControl("chbxDerivadaDePercsDeducs" + vlTipoOp), CheckBox)

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


            Dim oPerc As New Percepcion
            With oPerc
                .IdPercepcion = CShort(lblIdPercepcion.Text)
                .ClavePercepcion = lblClavePercepcion.Text.Trim
                .NombrePercepcion = txtbxNombrePercepcion.Text.Trim
                .IdProc = ddlSPs.SelectedValue
                .MostrarParaCaptura = chbxMostrarParaCaptura.Checked
                .IdAmbitoConcepto = ddlAmbitoAplic.SelectedValue
                .Activa = chbxActiva.Checked
                .EfectosAbiertos = chbxEfectosAbiertos.Checked
                If txtbxNumQnas.Text.Trim = String.Empty Then
                    .NumQnas = 0
                Else
                    .NumQnas = CByte(txtbxNumQnas.Text.Trim)
                End If
                '.NumQnas = IIf(txtbxNumQnas.Text.Trim = String.Empty, 0, CByte(txtbxNumQnas.Text.Trim))
                .IdZonaEco = ddlZonasEco.SelectedValue
                .IdEmpFuncion = ddlTiposDeEmp.SelectedValue
                .URL = txtbxURL.Text.Trim
                .Horas = ddlHoras.SelectedValue
                .DosPorcNomina = chbxDosPorcNomina.Checked
                .ValidaParaRP = chbxValidaParaRP.Checked
                .IdPercepcionPadre = IIf(chbxTienePercPadre.Checked, CShort(ddlPercsPadre.SelectedValue), -1)
                .ImpuestoAbsorbidoPorColegio = chbxImpuestoAbsorbidoPorColegio.Checked
                .Ordinaria = chbxOrdinaria.Checked
                .Masiva = chbxMasiva.Checked
                .RequiereDias = chbxRequiereDias.Checked
                .IncluirParaRecibos = chbxIncluirParaRecibos.Checked
                .ConceptoIndemnizatorio = chbxConceptoIndemnizatorio.Checked
                .PercepcionPorLey = chbxPercepcionPorLey.Checked
                .Ficticia = chbxFicticia.Checked
                .IdDeduccionContraria = IIf(chbxDeduccionContraria.Checked, CShort(ddlDeducsContrarias.SelectedValue), -1)
                .IdPercepcionAdeudo = IIf(chbxSeraPercDeAdeudo.Checked, CShort(ddlPercsParaRelComoAdeudo.SelectedValue), -1)
                .IdPercepcionRetro = IIf(chbxSeraPercDeRetro.Checked, CShort(ddlPercsParaRelComoRetro.SelectedValue), -1)
                .NumQnasRequeridas = CByte(ddlNumQnasReqParaCalc.SelectedValue)
                .IdFormaDePago1A = CByte(ddlFormasDePago1A.SelectedValue)
                .IdFormaDePago1D = CByte(ddlFormasDePago1D.SelectedValue)
                .IdFormaDePago2A = CByte(ddlFormasDePago2A.SelectedValue)
                .IdFormaDePago2D = CByte(ddlFormasDePago2D.SelectedValue)
                .IdTipoPercSAT = CShort(ddlPercsSAT.SelectedValue)
                .DerivadaDePercsDeducs = chbxDerivadaDePercsDeducs.Checked

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


    Protected Sub chbxTienePercPadre_CheckedChanged(sender As Object, e As System.EventArgs)
        Dim vlTipoOp As String = IIf(Request.Params("TipoOperacion") = "1", "I", IIf(Request.Params("TipoOperacion") = "0", "E", ""))
        If Request.Params("TipoOperacion") = "1" And Request.Params("CrearCopia") = "SI" Then
            vlTipoOp = "E"
        End If
        Dim ddlPercsPadre As DropDownList = CType(Me.dvDatosPerc.FindControl("ddlPercsPadre" + vlTipoOp), DropDownList)
        Dim chbxTienePercPadre As CheckBox = CType(Me.dvDatosPerc.FindControl("chbxTienePercPadre" + vlTipoOp), CheckBox)

        ddlPercsPadre.Enabled = chbxTienePercPadre.Checked
    End Sub

    Protected Sub chbxOrdinaria_CheckedChanged(sender As Object, e As System.EventArgs)
        Dim vlTipoOp As String = IIf(Request.Params("TipoOperacion") = "1", "I", IIf(Request.Params("TipoOperacion") = "0", "E", ""))
        If Request.Params("TipoOperacion") = "1" And Request.Params("CrearCopia") = "SI" Then
            vlTipoOp = "E"
        End If
        Dim chbxOrdinaria As CheckBox = CType(Me.dvDatosPerc.FindControl("chbxOrdinaria" + vlTipoOp), CheckBox)
        Dim lblAyudachbxOrdinaria As Label = CType(Me.dvDatosPerc.FindControl("lblAyudachbxOrdinaria" + vlTipoOp), Label)

        lblAyudachbxOrdinaria.Visible = chbxOrdinaria.Checked
    End Sub

    Protected Sub chbxDeduccionContraria_CheckedChanged(sender As Object, e As System.EventArgs)
        Dim vlTipoOp As String = IIf(Request.Params("TipoOperacion") = "1", "I", IIf(Request.Params("TipoOperacion") = "0", "E", ""))
        If Request.Params("TipoOperacion") = "1" And Request.Params("CrearCopia") = "SI" Then
            vlTipoOp = "E"
        End If
        Dim chbxDeduccionContraria As CheckBox = CType(Me.dvDatosPerc.FindControl("chbxDeduccionContraria" + vlTipoOp), CheckBox)
        Dim ddlDeducsContrarias As DropDownList = CType(Me.dvDatosPerc.FindControl("ddlDeducsContrarias" + vlTipoOp), DropDownList)

        ddlDeducsContrarias.Enabled = chbxDeduccionContraria.Checked
    End Sub

    Protected Sub chbxSeraPercDeAdeudo_CheckedChanged(sender As Object, e As System.EventArgs)
        Dim vlTipoOp As String = IIf(Request.Params("TipoOperacion") = "1", "I", IIf(Request.Params("TipoOperacion") = "0", "E", ""))
        If Request.Params("TipoOperacion") = "1" And Request.Params("CrearCopia") = "SI" Then
            vlTipoOp = "E"
        End If
        Dim chbxSeraPercDeAdeudo As CheckBox = CType(Me.dvDatosPerc.FindControl("chbxSeraPercDeAdeudo" + vlTipoOp), CheckBox)
        Dim ddlPercsParaRelComoAdeudo As DropDownList = CType(Me.dvDatosPerc.FindControl("ddlPercsParaRelComoAdeudo" + vlTipoOp), DropDownList)

        ddlPercsParaRelComoAdeudo.Enabled = chbxSeraPercDeAdeudo.Checked
    End Sub

    Protected Sub chbxSeraPercDeRetro_CheckedChanged(sender As Object, e As System.EventArgs)
        Dim vlTipoOp As String = IIf(Request.Params("TipoOperacion") = "1", "I", IIf(Request.Params("TipoOperacion") = "0", "E", ""))
        If Request.Params("TipoOperacion") = "1" And Request.Params("CrearCopia") = "SI" Then
            vlTipoOp = "E"
        End If
        Dim chbxSeraPercDeRetro As CheckBox = CType(Me.dvDatosPerc.FindControl("chbxSeraPercDeRetro" + vlTipoOp), CheckBox)
        Dim ddlPercsParaRelComoRetro As DropDownList = CType(Me.dvDatosPerc.FindControl("ddlPercsParaRelComoRetro" + vlTipoOp), DropDownList)

        ddlPercsParaRelComoRetro.Enabled = chbxSeraPercDeRetro.Checked
    End Sub

End Class
