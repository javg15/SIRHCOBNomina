Imports DataAccessLayer.COBAEV.Empleados
Imports DataAccessLayer.COBAEV
Imports DataAccessLayer.COBAEV.Administracion
Imports DataAccessLayer.COBAEV.Nominas
Imports System.Data
Imports BusinessRulesLayer.COBAEV.Validaciones
Partial Class ABCDeducciones
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
        Dim ddlAmbitoAplic As DropDownList = CType(Me.dvDatosDeduc.FindControl("ddlAmbitoAplic" + pTipoOp), DropDownList)
        LlenaDDL(ddlAmbitoAplic, "DescAmbitoConcepto", "IdAmbitoConcepto", oNomina.ObtenAmbitoAplicDePercDeduc(), SelectedValue)
    End Sub
    Private Sub BindSPs(ByVal pTipoOp As String, Optional ByVal SelectedValue As String = "1")
        Dim oSPs As New Aplicacion
        Dim ddlSPs As DropDownList = CType(Me.dvDatosDeduc.FindControl("ddlSPs" + pTipoOp), DropDownList)
        LlenaDDL(ddlSPs, "NombreProc", "IdProc", oSPs.ObtenDeBDNomina(), SelectedValue)
    End Sub
    Private Sub BindZonasEco(ByVal pTipoOp As String, Optional ByVal SelectedValue As String = "3")
        Dim oZonasEco As New ZonaEconomica
        Dim ddlZonasEco As DropDownList = CType(Me.dvDatosDeduc.FindControl("ddlZonasEco" + pTipoOp), DropDownList)
        LlenaDDL(ddlZonasEco, "DescZonaEco", "IdZonaEco", oZonasEco.ObtenTodasSinComodin(), String.Empty)
        ddlZonasEco.Items.Insert(2, "ZONA ECONOMICA 2 Y 3")
        ddlZonasEco.Items(2).Value = "3"
        ddlZonasEco.SelectedValue = SelectedValue
    End Sub
    Private Sub BindTiposDeEmp(ByVal pTipoOp As String, Optional ByVal SelectedValue As String = "4")
        Dim oEmpFuncion As New EmpleadoFuncion
        Dim ddlTiposDeEmp As DropDownList = CType(Me.dvDatosDeduc.FindControl("ddlTiposDeEmp" + pTipoOp), DropDownList)
        LlenaDDL(ddlTiposDeEmp, "DescEmpFuncion", "IdEmpFuncion", oEmpFuncion.ObtenTodas(), SelectedValue)
    End Sub
    Private Sub BindddlDeducsPadre(ByVal pTipoOp As String, Optional ByVal SelectedValue As String = "")
        Dim oDeducs As New Deduccion
        Dim ddlDeducsPadre As DropDownList = CType(Me.dvDatosDeduc.FindControl("ddlDeducsPadre" + pTipoOp), DropDownList)
        Dim chbxTieneDeducPadre As CheckBox = CType(Me.dvDatosDeduc.FindControl("chbxTieneDeducPadre" + pTipoOp), CheckBox)
        LlenaDDL(ddlDeducsPadre, "NombreDeduccionParaDDL", "IdDeduccion", oDeducs.ObtenParaDeducPadre(True), SelectedValue)

        ddlDeducsPadre.Enabled = chbxTieneDeducPadre.Checked And pTipoOp <> ""
    End Sub
    Private Sub BindddlPercsParaRelComoDevol(ByVal pTipoOp As String, Optional ByVal SelectedValue As String = "")
        Dim oPerc As New Percepcion
        Dim ddlPercsParaRelComoDevol As DropDownList = CType(Me.dvDatosDeduc.FindControl("ddlPercsParaRelComoDevol" + pTipoOp), DropDownList)
        Dim chbxSeraDeducDeDevol As CheckBox = CType(Me.dvDatosDeduc.FindControl("chbxSeraDeducDeDevol" + pTipoOp), CheckBox)
        LlenaDDL(ddlPercsParaRelComoDevol, "DescPercParaDDL", "IdPercepcion", oPerc.ObtenOrdinarias("NOMBRE"), SelectedValue)

        ddlPercsParaRelComoDevol.Enabled = chbxSeraDeducDeDevol.Checked And pTipoOp <> ""
    End Sub
    Private Sub BindddlFormasDePago(ByVal pTipoOp As String, pNombreDDL As String, Optional ByVal SelectedValue As String = "")
        Dim oDeducs As New Deduccion
        Dim ddlFormasDePago As DropDownList = CType(Me.dvDatosDeduc.FindControl(pNombreDDL + pTipoOp), DropDownList)

        LlenaDDL(ddlFormasDePago, "DescFormaDePago", "IdFormaDePago", oDeducs.ObtenFormasDePago(), SelectedValue)
    End Sub
    Private Sub BindddlClasifDeduc(ByVal pTipoOp As String, Optional ByVal SelectedValue As String = "")
        Dim oDeducs As New Deduccion
        Dim ddlClasifDeduc As DropDownList = CType(Me.dvDatosDeduc.FindControl("ddlClasifDeduc" + pTipoOp), DropDownList)

        LlenaDDL(ddlClasifDeduc, "DescClasifDeducParaDDL", "IdClasifDeduc", oDeducs.ObtenClasifInterna(), SelectedValue)
    End Sub
    Private Sub BindddlDeducsSAT(ByVal pTipoOp As String, Optional ByVal SelectedValue As String = "")
        Dim oDeducs As New Deduccion
        Dim ddlDeducsSAT As DropDownList = CType(Me.dvDatosDeduc.FindControl("ddlDeducsSAT" + pTipoOp), DropDownList)

        LlenaDDL(ddlDeducsSAT, "DescTipoDeducSATParaDDL", "IdTipoDeducSAT", oDeducs.ObtenClasifSAT, SelectedValue)
    End Sub

    Private Sub BindddlDeducsContrarias(ByVal pTipoOp As String, Optional ByVal SelectedValue As String = "")
        Dim oPerc As New Percepcion
        Dim ddlDeducsContrarias As DropDownList = CType(Me.dvDatosDeduc.FindControl("ddlDeducsContrarias" + pTipoOp), DropDownList)
        Dim chbxDeduccionContraria As CheckBox = CType(Me.dvDatosDeduc.FindControl("chbxDeduccionContraria" + pTipoOp), CheckBox)
        LlenaDDL(ddlDeducsContrarias, "DescPercParaDDL", "IdPercepcion", oPerc.ObtenNoOrdinarias("NOMBRE"), SelectedValue)

        ddlDeducsContrarias.Enabled = chbxDeduccionContraria.Checked And pTipoOp <> ""
    End Sub

    Private Sub BindddlddlHoras(ByVal pTipoOp As String, Optional ByVal SelectedValue As String = "")
        Dim oDeducs As New Deduccion
        Dim ddlHoras As DropDownList = CType(Me.dvDatosDeduc.FindControl("ddlHoras" + pTipoOp), DropDownList)

        ddlHoras.SelectedValue = SelectedValue
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

            Dim lblIdDeduccion As Label = CType(Me.dvDatosDeduc.FindControl("lblIdDeduccion" + vlTipoOp), Label)
            Dim lblClaveDeduccion As Label = CType(Me.dvDatosDeduc.FindControl("lblClaveDeduccion" + vlTipoOp), Label)
            Dim txtbxNombreDeduccion As TextBox = CType(Me.dvDatosDeduc.FindControl("txtbxNombreDeduccion" + vlTipoOp), TextBox)
            Dim oDeduc As New Deduccion
            Dim drDeduc As DataRow

            If Request.Params("TipoOperacion") = "1" And Request.Params("CrearCopia") = "NO" Then
                Me.MultiView1.SetActiveView(Me.viewCaptura)
                lblIdDeduccion.Text = "0"
                lblClaveDeduccion.Text = oDeduc.ObtenNuevaClave.Rows(0).Item("NuevaClaveDeduccion").ToString()
                BindSPs(vlTipoOp)
                BindAmbitoAplic(vlTipoOp)
                BindZonasEco(vlTipoOp)
                BindTiposDeEmp(vlTipoOp)
                BindddlDeducsPadre(vlTipoOp)
                BindddlClasifDeduc(vlTipoOp)
                BindddlFormasDePago(vlTipoOp, "ddlFormasDePago1A")
                BindddlFormasDePago(vlTipoOp, "ddlFormasDePago1D")
                BindddlPercsParaRelComoDevol(vlTipoOp)
                BindddlDeducsContrarias(vlTipoOp)
                BindddlDeducsSAT(vlTipoOp)
            ElseIf Request.Params("TipoOperacion") = "1" And Request.Params("CrearCopia") = "SI" Then
                Me.MultiView1.SetActiveView(Me.viewCaptura)
                Me.dvDatosDeduc.ChangeMode(DetailsViewMode.Edit)
                drDeduc = oDeduc.ObtenParaUpdate(CShort(Request.Params("IdDeduccion")), True)
                Me.dvDatosDeduc.DataSource = drDeduc.Table
                Me.dvDatosDeduc.DataBind()

                lblIdDeduccion = CType(Me.dvDatosDeduc.FindControl("lblIdDeduccion" + vlTipoOp), Label)
                lblClaveDeduccion = CType(Me.dvDatosDeduc.FindControl("lblClaveDeduccion" + vlTipoOp), Label)
                txtbxNombreDeduccion = CType(Me.dvDatosDeduc.FindControl("txtbxNombreDeduccion" + vlTipoOp), TextBox)

                lblIdDeduccion.Text = "0"
                lblClaveDeduccion.Text = oDeduc.ObtenNuevaClave.Rows(0).Item("NuevaClaveDeduccion").ToString()
                txtbxNombreDeduccion.Text = String.Empty

                BindSPs(vlTipoOp, drDeduc("IdProc").ToString)
                BindAmbitoAplic(vlTipoOp, drDeduc("IdAmbitoConcepto").ToString)
                BindZonasEco(vlTipoOp, drDeduc("IdZonaEco").ToString)
                BindTiposDeEmp(vlTipoOp, drDeduc("IdEmpFuncion").ToString)
                BindddlddlHoras(vlTipoOp, drDeduc("Horas").ToString)
                BindddlDeducsPadre(vlTipoOp, drDeduc("IdDeduccionPadre").ToString)
                BindddlClasifDeduc(vlTipoOp, drDeduc("IdClasifDeduc").ToString)
                BindddlFormasDePago(vlTipoOp, "ddlFormasDePago1A", drDeduc("IdFormaDePago1A").ToString)
                BindddlFormasDePago(vlTipoOp, "ddlFormasDePago1D", drDeduc("IdFormaDePago1D").ToString)
                BindddlPercsParaRelComoDevol(vlTipoOp, drDeduc("IdPercParaDevol").ToString)
                BindddlDeducsContrarias(vlTipoOp, drDeduc("IdPercNoOrdParaDevol").ToString)
                BindddlDeducsSAT(vlTipoOp, drDeduc("IdTipoDeducSAT").ToString)
            ElseIf Request.Params("TipoOperacion") = "0" Then
                Me.MultiView1.SetActiveView(Me.viewCaptura)
                Me.dvDatosDeduc.ChangeMode(DetailsViewMode.Edit)
                drDeduc = oDeduc.ObtenParaUpdate(CShort(Request.Params("IdDeduccion")), True)
                Me.dvDatosDeduc.DataSource = drDeduc.Table
                Me.dvDatosDeduc.DataBind()
                BindSPs(vlTipoOp, drDeduc("IdProc").ToString)
                BindAmbitoAplic(vlTipoOp, drDeduc("IdAmbitoConcepto").ToString)
                BindZonasEco(vlTipoOp, drDeduc("IdZonaEco").ToString)
                BindTiposDeEmp(vlTipoOp, drDeduc("IdEmpFuncion").ToString)
                BindddlddlHoras(vlTipoOp, drDeduc("Horas").ToString)
                BindddlDeducsPadre(vlTipoOp, drDeduc("IdDeduccionPadre").ToString)
                BindddlClasifDeduc(vlTipoOp, drDeduc("IdClasifDeduc").ToString)
                BindddlFormasDePago(vlTipoOp, "ddlFormasDePago1A", drDeduc("IdFormaDePago1A").ToString)
                BindddlFormasDePago(vlTipoOp, "ddlFormasDePago1D", drDeduc("IdFormaDePago1D").ToString)
                BindddlPercsParaRelComoDevol(vlTipoOp, drDeduc("IdPercParaDevol").ToString)
                BindddlDeducsContrarias(vlTipoOp, drDeduc("IdPercNoOrdParaDevol").ToString)
                BindddlDeducsSAT(vlTipoOp, drDeduc("IdTipoDeducSAT").ToString)
            ElseIf Request.Params("TipoOperacion") = "4" Then
                Me.MultiView1.SetActiveView(Me.viewCaptura)
                Me.dvDatosDeduc.ChangeMode(DetailsViewMode.ReadOnly)
                drDeduc = oDeduc.ObtenParaUpdate(CShort(Request.Params("IdDeduccion")), True)
                Me.dvDatosDeduc.DataSource = drDeduc.Table
                Me.dvDatosDeduc.DataBind()
                BindSPs(vlTipoOp, drDeduc("IdProc").ToString)
                BindAmbitoAplic(vlTipoOp, drDeduc("IdAmbitoConcepto").ToString)
                BindZonasEco(vlTipoOp, drDeduc("IdZonaEco").ToString)
                BindTiposDeEmp(vlTipoOp, drDeduc("IdEmpFuncion").ToString)
                BindddlddlHoras(vlTipoOp, drDeduc("Horas").ToString)
                BindddlDeducsPadre(vlTipoOp, drDeduc("IdDeduccionPadre").ToString)
                BindddlClasifDeduc(vlTipoOp, drDeduc("IdClasifDeduc").ToString)
                BindddlFormasDePago(vlTipoOp, "ddlFormasDePago1A", drDeduc("IdFormaDePago1A").ToString)
                BindddlFormasDePago(vlTipoOp, "ddlFormasDePago1D", drDeduc("IdFormaDePago1D").ToString)
                BindddlPercsParaRelComoDevol(vlTipoOp, drDeduc("IdPercParaDevol").ToString)
                BindddlDeducsContrarias(vlTipoOp, drDeduc("IdPercNoOrdParaDevol").ToString)
                BindddlDeducsSAT(vlTipoOp, drDeduc("IdTipoDeducSAT").ToString)
            End If

            Dim btnCancelar As Button
            Dim vlTipoOp2 As String

            Select Case dvDatosDeduc.CurrentMode
                Case DetailsViewMode.ReadOnly
                    vlTipoOp2 = ""
                Case DetailsViewMode.Edit
                    vlTipoOp2 = "E"
                Case DetailsViewMode.Insert
                    vlTipoOp2 = "I"
                Case Else
                    vlTipoOp2 = ""
            End Select

            btnCancelar = CType(dvDatosDeduc.FindControl("btnCancelar" + vlTipoOp2), Button)

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
        End If
    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim vlTipoOp As String

            vlTipoOp = IIf(Request.Params("TipoOperacion") = "1", "I", IIf(Request.Params("TipoOperacion") = "0", "E", ""))

            If Request.Params("TipoOperacion") = "1" And Request.Params("CrearCopia") = "SI" Then
                vlTipoOp = "E"
            End If

            Dim lblIdDeduccion As Label = CType(Me.dvDatosDeduc.FindControl("lblIdDeduccion" + vlTipoOp), Label)
            Dim lblClaveDeduccion As Label = CType(Me.dvDatosDeduc.FindControl("lblClaveDeduccion" + vlTipoOp), Label)
            Dim txtbxNombreDeduccion As TextBox = CType(Me.dvDatosDeduc.FindControl("txtbxNombreDeduccion" + vlTipoOp), TextBox)
            Dim ddlSPs As DropDownList = CType(Me.dvDatosDeduc.FindControl("ddlSPs" + vlTipoOp), DropDownList)
            Dim chbxMostrarParaCaptura As CheckBox = CType(Me.dvDatosDeduc.FindControl("chbxMostrarParaCaptura" + vlTipoOp), CheckBox)
            Dim ddlAmbitoAplic As DropDownList = CType(Me.dvDatosDeduc.FindControl("ddlAmbitoAplic" + vlTipoOp), DropDownList)
            Dim chbxActiva As CheckBox = CType(Me.dvDatosDeduc.FindControl("chbxActiva" + vlTipoOp), CheckBox)
            Dim chbxEfectosAbiertos As CheckBox = CType(Me.dvDatosDeduc.FindControl("chbxEfectosAbiertos" + vlTipoOp), CheckBox)
            Dim txtbxNumQnas As TextBox = CType(Me.dvDatosDeduc.FindControl("txtbxNumQnas" + vlTipoOp), TextBox)
            Dim ddlTiposDeEmp As DropDownList = CType(Me.dvDatosDeduc.FindControl("ddlTiposDeEmp" + vlTipoOp), DropDownList)
            Dim ddlZonasEco As DropDownList = CType(Me.dvDatosDeduc.FindControl("ddlZonasEco" + vlTipoOp), DropDownList)
            Dim chbxMasiva As CheckBox = CType(Me.dvDatosDeduc.FindControl("chbxMasiva" + vlTipoOp), CheckBox)
            Dim chbxCalcularComoVigente As CheckBox = CType(Me.dvDatosDeduc.FindControl("chbxCalcularComoVigente" + vlTipoOp), CheckBox)
            Dim txtbxURL As TextBox = CType(Me.dvDatosDeduc.FindControl("txtbxURL" + vlTipoOp), TextBox)
            Dim ddlHoras As DropDownList = CType(Me.dvDatosDeduc.FindControl("ddlHoras" + vlTipoOp), DropDownList)
            Dim chbxIncluirParaNegativos As CheckBox = CType(Me.dvDatosDeduc.FindControl("chbxIncluirParaNegativos" + vlTipoOp), CheckBox)
            Dim ddlClasifDeduc As DropDownList = CType(Me.dvDatosDeduc.FindControl("ddlClasifDeduc" + vlTipoOp), DropDownList)
            Dim chbxDosPorcNomina As CheckBox = CType(Me.dvDatosDeduc.FindControl("chbxDosPorcNomina" + vlTipoOp), CheckBox)
            Dim chbxValidaParaRP As CheckBox = CType(Me.dvDatosDeduc.FindControl("chbxDosPorcNomina" + vlTipoOp), CheckBox)
            Dim chbxTieneDeducPadre As CheckBox = CType(Me.dvDatosDeduc.FindControl("chbxTieneDeducPadre" + vlTipoOp), CheckBox)
            Dim ddlDeducsPadre As DropDownList = CType(Me.dvDatosDeduc.FindControl("ddlDeducsPadre" + vlTipoOp), DropDownList)
            Dim chbxDeduccionPorLey As CheckBox = CType(Me.dvDatosDeduc.FindControl("chbxDeduccionPorLey" + vlTipoOp), CheckBox)
            Dim chbxIncluirParaRecibos As CheckBox = CType(Me.dvDatosDeduc.FindControl("chbxIncluirParaRecibos" + vlTipoOp), CheckBox)
            Dim chbxConceptoIndemnizatorio As CheckBox = CType(Me.dvDatosDeduc.FindControl("chbxConceptoIndemnizatorio" + vlTipoOp), CheckBox)
            Dim ddlFormasDePago1A As DropDownList = CType(Me.dvDatosDeduc.FindControl("ddlFormasDePago1A" + vlTipoOp), DropDownList)
            Dim ddlFormasDePago1D As DropDownList = CType(Me.dvDatosDeduc.FindControl("ddlFormasDePago1D" + vlTipoOp), DropDownList)
            Dim chbxSeraDeducDeDevol As CheckBox = CType(Me.dvDatosDeduc.FindControl("chbxSeraDeducDeDevol" + vlTipoOp), CheckBox)
            Dim ddlPercsParaRelComoDevol As DropDownList = CType(Me.dvDatosDeduc.FindControl("ddlPercsParaRelComoDevol" + vlTipoOp), DropDownList)

            'Dim chbxImpuestoAbsorbidoPorColegio As CheckBox = CType(Me.dvDatosDeduc.FindControl("chbxImpuestoAbsorbidoPorColegio" + vlTipoOp), CheckBox)
            'Dim chbxOrdinaria As CheckBox = CType(Me.dvDatosDeduc.FindControl("chbxOrdinaria" + vlTipoOp), CheckBox)
            'Dim chbxRequiereDias As CheckBox = CType(Me.dvDatosDeduc.FindControl("chbxRequiereDias" + vlTipoOp), CheckBox)
            'Dim chbxFicticia As CheckBox = CType(Me.dvDatosDeduc.FindControl("chbxFicticia" + vlTipoOp), CheckBox)
            Dim chbxDeduccionContraria As CheckBox = CType(Me.dvDatosDeduc.FindControl("chbxDeduccionContraria" + vlTipoOp), CheckBox)
            Dim ddlDeducsContrarias As DropDownList = CType(Me.dvDatosDeduc.FindControl("ddlDeducsContrarias" + vlTipoOp), DropDownList)
            'Dim chbxSeraDeducDeRetro As CheckBox = CType(Me.dvDatosDeduc.FindControl("chbxSeraDeducDeRetro" + vlTipoOp), CheckBox)
            'Dim ddlDeducsParaRelComoRetro As DropDownList = CType(Me.dvDatosDeduc.FindControl("ddlDeducsParaRelComoRetro" + vlTipoOp), DropDownList)
            'Dim ddlNumQnasReqParaCalc As DropDownList = CType(Me.dvDatosDeduc.FindControl("ddlNumQnasReqParaCalc" + vlTipoOp), DropDownList)
            Dim ddlDeducsSAT As DropDownList = CType(Me.dvDatosDeduc.FindControl("ddlDeducsSAT" + vlTipoOp), DropDownList)
            Dim chbxDerivadaDePercsDeducs As CheckBox = CType(Me.dvDatosDeduc.FindControl("chbxDerivadaDePercsDeducs" + vlTipoOp), CheckBox)

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


            Dim oDeduc As New Deduccion
            With oDeduc
                .IdDeduccion = CShort(lblIdDeduccion.Text)
                .ClaveDeduccion = lblClaveDeduccion.Text.Trim
                .NombreDeduccion = txtbxNombreDeduccion.Text.Trim
                .IdProc = CShort(ddlSPs.SelectedValue)
                .MostrarParaCaptura = chbxMostrarParaCaptura.Checked
                .IdAmbitoConcepto = CByte(ddlAmbitoAplic.SelectedValue)
                .Activa = chbxActiva.Checked
                .EfectosAbiertos = chbxEfectosAbiertos.Checked
                If txtbxNumQnas.Text.Trim = String.Empty Then
                    .NumQnas = 0
                Else
                    .NumQnas = CByte(txtbxNumQnas.Text.Trim)
                End If
                .IdEmpFuncion = CByte(ddlTiposDeEmp.SelectedValue)
                .IdZonaEco = CByte(ddlZonasEco.SelectedValue)
                .Masiva = chbxMasiva.Checked
                .CalcularComoVigente = chbxCalcularComoVigente.Checked
                .URL = txtbxURL.Text.Trim
                .Horas = ddlHoras.SelectedValue
                .IncluirParaNegativos = chbxIncluirParaNegativos.Checked
                .IdClasifDeduc = CByte(ddlClasifDeduc.SelectedValue)
                .DosPorcNomina = chbxDosPorcNomina.Checked
                .ValidaParaRP = chbxValidaParaRP.Checked
                .IdDeduccionPadre = IIf(chbxTieneDeducPadre.Checked, CShort(ddlDeducsPadre.SelectedValue), -1)
                .DeduccionPorLey = chbxDeduccionPorLey.Checked
                .IncluirParaRecibos = chbxIncluirParaRecibos.Checked
                .ConceptoIndemnizatorio = chbxConceptoIndemnizatorio.Checked
                .IdPercParaDevol = IIf(chbxSeraDeducDeDevol.Checked, CShort(ddlPercsParaRelComoDevol.SelectedValue), -1)
                .IdFormaDePago1A = CByte(ddlFormasDePago1A.SelectedValue)
                .IdFormaDePago1D = CByte(ddlFormasDePago1D.SelectedValue)
                .IdPercNoOrdParaDevol = IIf(chbxDeduccionContraria.Checked, CShort(ddlDeducsContrarias.SelectedValue), -1)
                .IdTipoDeducSAT = CShort(ddlDeducsSAT.SelectedValue)
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
        Me.MultiView1.SetActiveView(viewCaptura)
    End Sub


    Protected Sub chbxTieneDeducPadre_CheckedChanged(sender As Object, e As System.EventArgs)
        Dim vlTipoOp As String = IIf(Request.Params("TipoOperacion") = "1", "I", IIf(Request.Params("TipoOperacion") = "0", "E", ""))
        If Request.Params("TipoOperacion") = "1" And Request.Params("CrearCopia") = "SI" Then
            vlTipoOp = "E"
        End If
        Dim ddlDeducsPadre As DropDownList = CType(Me.dvDatosDeduc.FindControl("ddlDeducsPadre" + vlTipoOp), DropDownList)
        Dim chbxTieneDeducPadre As CheckBox = CType(Me.dvDatosDeduc.FindControl("chbxTieneDeducPadre" + vlTipoOp), CheckBox)
        Dim lblIdDeduccion As Label = CType(Me.dvDatosDeduc.FindControl("lblIdDeduccion" + vlTipoOp), Label)

        ddlDeducsPadre.Enabled = chbxTieneDeducPadre.Checked
        If chbxTieneDeducPadre.Checked = False Then
            If lblIdDeduccion.Text = "0" Then
                ddlDeducsPadre.SelectedValue = "0"
            Else
                ddlDeducsPadre.SelectedValue = lblIdDeduccion.Text
            End If
        End If
    End Sub

    Protected Sub chbxOrdinaria_CheckedChanged(sender As Object, e As System.EventArgs)
        Dim vlTipoOp As String = IIf(Request.Params("TipoOperacion") = "1", "I", IIf(Request.Params("TipoOperacion") = "0", "E", ""))
        If Request.Params("TipoOperacion") = "1" And Request.Params("CrearCopia") = "SI" Then
            vlTipoOp = "E"
        End If
        Dim chbxOrdinaria As CheckBox = CType(Me.dvDatosDeduc.FindControl("chbxOrdinaria" + vlTipoOp), CheckBox)
        Dim lblAyudachbxOrdinaria As Label = CType(Me.dvDatosDeduc.FindControl("lblAyudachbxOrdinaria" + vlTipoOp), Label)

        lblAyudachbxOrdinaria.Visible = chbxOrdinaria.Checked
    End Sub

    Protected Sub chbxDeduccionContraria_CheckedChanged(sender As Object, e As System.EventArgs)
        Dim vlTipoOp As String = IIf(Request.Params("TipoOperacion") = "1", "I", IIf(Request.Params("TipoOperacion") = "0", "E", ""))
        If Request.Params("TipoOperacion") = "1" And Request.Params("CrearCopia") = "SI" Then
            vlTipoOp = "E"
        End If
        Dim chbxDeduccionContraria As CheckBox = CType(Me.dvDatosDeduc.FindControl("chbxDeduccionContraria" + vlTipoOp), CheckBox)
        Dim ddlDeducsContrarias As DropDownList = CType(Me.dvDatosDeduc.FindControl("ddlDeducsContrarias" + vlTipoOp), DropDownList)

        ddlDeducsContrarias.Enabled = chbxDeduccionContraria.Checked
    End Sub

    'Protected Sub chbxSeraDeducDeRetro_CheckedChanged(sender As Object, e As System.EventArgs)
    '    Dim vlTipoOp As String = IIf(Request.Params("TipoOperacion") = "1", "I", IIf(Request.Params("TipoOperacion") = "0", "E", ""))
    '    If Request.Params("TipoOperacion") = "1" And Request.Params("CrearCopia") = "SI" Then
    '        vlTipoOp = "E"
    '    End If
    '    Dim chbxSeraDeducDeRetro As CheckBox = CType(Me.dvDatosDeduc.FindControl("chbxSeraDeducDeRetro" + vlTipoOp), CheckBox)
    '    Dim ddlDeducsParaRelComoRetro As DropDownList = CType(Me.dvDatosDeduc.FindControl("ddlDeducsParaRelComoRetro" + vlTipoOp), DropDownList)

    '    ddlDeducsParaRelComoRetro.Enabled = chbxSeraDeducDeRetro.Checked
    'End Sub

    Protected Sub chbxSeraDeducDeDevol_CheckedChanged(sender As Object, e As System.EventArgs)
        Dim vlTipoOp As String = IIf(Request.Params("TipoOperacion") = "1", "I", IIf(Request.Params("TipoOperacion") = "0", "E", ""))
        If Request.Params("TipoOperacion") = "1" And Request.Params("CrearCopia") = "SI" Then
            vlTipoOp = "E"
        End If
        Dim chbxSeraDeducDeDevol As CheckBox = CType(Me.dvDatosDeduc.FindControl("chbxSeraDeducDeDevol" + vlTipoOp), CheckBox)
        Dim ddlPercsParaRelComoDevol As DropDownList = CType(Me.dvDatosDeduc.FindControl("ddlPercsParaRelComoDevol" + vlTipoOp), DropDownList)

        ddlPercsParaRelComoDevol.Enabled = chbxSeraDeducDeDevol.Checked
    End Sub

    Protected Sub lbOtraOperacion_Click(sender As Object, e As System.EventArgs) Handles lbOtraOperacion.Click
        Dim btnCancelar As Button
        Dim strPostbackURL As String
        Dim vlTipoOp2 As String

        Select Case dvDatosDeduc.CurrentMode
            Case DetailsViewMode.ReadOnly
                vlTipoOp2 = ""
            Case DetailsViewMode.Edit
                vlTipoOp2 = "E"
            Case DetailsViewMode.Insert
                vlTipoOp2 = "I"
            Case Else
                vlTipoOp2 = ""
        End Select

        btnCancelar = CType(dvDatosDeduc.FindControl("btnCancelar" + vlTipoOp2), Button)

        strPostbackURL = String.Empty
        If btnCancelar Is Nothing = False Then
            strPostbackURL = btnCancelar.PostBackUrl
        End If

        btnCancelar = CType(dvDatosDeduc.FindControl("btnCancelar" + vlTipoOp2), Button)
        btnCancelar.PostBackUrl = strPostbackURL
        lbOtraOperacion0.PostBackUrl = strPostbackURL

        MultiView1.SetActiveView(viewCaptura)
    End Sub
End Class
