Imports DataAccessLayer.COBAEV.Nominas
Imports System.Data
Imports DataAccessLayer.COBAEV

Partial Class wfConciliacionNominas
    Inherits System.Web.UI.Page
    'Private Sub BindddlBancos()
    '    Dim ddlAux As New DropDownList
    '    Dim oBanco As New Bancos
    '    Dim li As ListItem
    '    LlenaDDL(ddlBancos, "NombreCortoBanco", "IdBanco", oBanco.ObtenTodos(), Nothing)
    '    LlenaDDL(ddlAux, "NombreCortoBanco", "IdBanco", oBanco.ObtenTodos(), Nothing)
    '    li = Me.ddlBancos.Items.FindByText("SIN DEFINIR")
    '    If li Is Nothing = False Then
    '        Me.ddlBancos.Items.Remove(li)
    '        ddlAux.Items.Remove(li)
    '    End If
    'End Sub
    Private Sub setVisibleImgenes(ByVal pValor1 As Boolean, ByVal pValor2 As Boolean, _
                                  ByVal pValor3 As Boolean, ByVal pValor4 As Boolean, _
                                  ByVal pValor5 As Boolean, ByVal pValor6 As Boolean, _
                                  ByVal pValor7 As Boolean, ByVal pValor8 As Boolean, _
                                  ByVal pValor9 As Boolean, ByVal pValor10 As Boolean)
        imgCheckTipoCheque.Visible = pValor1
        imgNoCheckTipoCheque.Visible = pValor2
        imgCheckAnio.Visible = pValor3
        imgNoCheckAnio.Visible = pValor4
        imgCheckMes.Visible = pValor5
        imgNoCheckMes.Visible = pValor6
        imgCheckQna.Visible = pValor7
        imgNoCheckQna.Visible = pValor8
        imgCheckCompenAfect.Visible = pValor9
        imgNoCheckCompenAfect.Visible = pValor10
    End Sub
    Private Sub setVisibleColumns(ByVal pGridView As GridView, _
                                  ByVal pValor1 As Boolean, ByVal pValor2 As Boolean, _
                                  ByVal pValor3 As Boolean, ByVal pValor4 As Boolean, _
                                  ByVal pValor5 As Boolean)
        pGridView.Columns(7).Visible = pValor1
        pGridView.Columns(8).Visible = pValor2
        pGridView.Columns(12).Visible = pValor3
        pGridView.Columns(14).Visible = pValor4
        pGridView.Columns(15).Visible = pValor5
    End Sub
    Private Sub setVisibleColumns2(ByVal pGridView As GridView, _
                                  ByVal pValor1 As Boolean, ByVal pValor2 As Boolean, _
                                  ByVal pValor3 As Boolean, ByVal pValor4 As Boolean, _
                                  ByVal pValor5 As Boolean)
        pGridView.Columns(8).Visible = pValor1
        pGridView.Columns(9).Visible = pValor2
        pGridView.Columns(13).Visible = pValor3
        pGridView.Columns(15).Visible = pValor4
        pGridView.Columns(16).Visible = pValor5
    End Sub
    Private Sub ddlTiposDeChequesSelectedValue()
        Select Case ddlTiposDeCheques.SelectedValue
            Case "C"
                pnlMeses.Enabled = True
                pnlCompenAfectacion.Enabled = True
                pnlQnas.Enabled = False
                'Case "CPA"
                '    pnlMeses.Enabled = True
                '    pnlQnas.Enabled = False
            Case "N"
                pnlMeses.Enabled = False
                pnlCompenAfectacion.Enabled = False
                pnlQnas.Enabled = True
                'Case "NPA"
                '    pnlMeses.Enabled = False
                '    pnlQnas.Enabled = True
                'Case "R"
                '    pnlMeses.Enabled = False
                '    pnlQnas.Enabled = True
            Case Else

        End Select
    End Sub
    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, ByVal dt As DataTable, Optional ByVal SelectedValue As String = "")
        ddl.DataSource = dt
        ddl.DataTextField = TextField
        ddl.DataValueField = ValueField
        ddl.DataBind()
        If SelectedValue <> String.Empty Then ddl.SelectedValue = SelectedValue
    End Sub
    Private Sub BindddlAños()
        Dim oQna As New Quincenas
        With Me.ddlAños
            .DataSource = oQna.ObtenAños(True)
            .DataTextField = "Anio"
            .DataValueField = "Anio"
            .DataBind()
            If .Items.Count = 0 Then
                .Items.Insert(0, "No existe información de años")
                .Items(0).Value = -1
            End If
        End With
    End Sub
    Private Sub BindddlMeses()
        Dim oQna As New Quincenas
        With Me.ddlMeses
            .DataSource = oQna.ObtenMesesCalculadosPorAnio(CShort(Me.ddlAños.SelectedValue))
            .DataTextField = "NombreMes"
            .DataValueField = "IdMes"
            .DataBind()
        End With
    End Sub
    Private Sub BindddlCompenAfect()
        Dim oCompen As New Compensacion
        With ddlCompenAfect
            .DataSource = oCompen.BuscaAfectacionesPorAnioMes(CShort(Me.ddlAños.SelectedValue), CByte(ddlMeses.SelectedValue))
            .DataTextField = "DescDelPago"
            .DataValueField = "NumAfect"
            .DataBind()
        End With
    End Sub
    Private Sub BindQuincenas()
        Dim oQna As New Quincenas
        Dim dt As DataTable

        dt = oQna.ObtenCalculadasPorAnio(CShort(Me.ddlAños.SelectedValue))

        LlenaDDL(ddlQnas, "QuincenaObservs", "IdQuincena", dt)
    End Sub
    Private Sub BindQuincenasAdic()
        Dim oQna As New Quincenas
        Dim dt As DataTable

        dt = oQna.ObtenCalculadasPorAnio(CShort(Me.ddlAños.SelectedValue), False)

        LlenaDDL(ddlQnas, "QuincenaObservs", "IdQuincena", dt)
    End Sub
    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            BindddlAños()
            If Me.ddlAños.SelectedValue <> -1 Then
                BindddlMeses()
                BindddlCompenAfect()
                BindQuincenas()
                btnConsultar_Click(sender, e)
                pnlTiposDeCheques.Enabled = False
                pnlAños.Enabled = False
                pnlMeses.Enabled = False
                pnlCompenAfectacion.Enabled = False
                pnlQnas.Enabled = False
                btnConsultar.Visible = False
            End If
        End If
    End Sub
    Protected Sub ddlMeses_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlMeses.SelectedIndexChanged
        BindddlCompenAfect()
        If ddlCompenAfect.Items.Count = 0 Then
            ddlCompenAfect.Items.Add(New ListItem("(Sin afectaciones relacionadas)", "-1"))
        End If
    End Sub

    Protected Sub ddlTiposDeCheques_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlTiposDeCheques.SelectedIndexChanged
        Select Case ddlTiposDeCheques.SelectedValue
            Case "C"
                BindQuincenas()
                pnlMeses.Enabled = True
                pnlCompenAfectacion.Enabled = True
                pnlQnas.Enabled = False
                'Case "CPA"
                '    BindQuincenas()
                '    pnlMeses.Enabled = True
                '    pnlQnas.Enabled = False
            Case "N"
                BindQuincenas()
                pnlMeses.Enabled = False
                pnlCompenAfectacion.Enabled = False
                pnlQnas.Enabled = True
                'Case "NPA"
                '    BindQuincenas()
                '    pnlMeses.Enabled = False
                '    pnlQnas.Enabled = True
                'Case "R"
                '    BindQuincenasAdic()
                '    pnlMeses.Enabled = False
                '    pnlQnas.Enabled = True
            Case Else

        End Select
    End Sub

    Protected Sub ddlAños_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlAños.SelectedIndexChanged
        BindddlMeses()
        Select Case ddlTiposDeCheques.SelectedValue
            Case "R"
                BindQuincenasAdic()
            Case Else
                BindQuincenas()
        End Select

    End Sub

    Protected Sub btnCambiarPrmsCons_Click(sender As Object, e As System.EventArgs) Handles btnCambiarPrmsCons.Click
        mvCheques.Visible = False
        pnlTiposDeCheques.Enabled = True
        pnlAños.Enabled = True
        ddlTiposDeChequesSelectedValue()
        imgCheckTipoCheque.Visible = False
        imgNoCheckTipoCheque.Visible = False
        imgCheckAnio.Visible = False
        imgNoCheckAnio.Visible = False
        imgCheckMes.Visible = False
        imgNoCheckMes.Visible = False
        imgCheckCompenAfect.Visible = False
        imgNoCheckCompenAfect.Visible = False
        imgCheckQna.Visible = False
        imgNoCheckQna.Visible = False
        btnConsultar.Visible = True
        btnExportarEXCEL.Visible = False
    End Sub

    Protected Sub btnConsultar_Click(sender As Object, e As System.EventArgs) Handles btnConsultar.Click
        Dim oNomina As New Nomina
        Dim strCadena As String

        strCadena = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" _
            + "?Anio=" + ddlAños.SelectedValue _
            + "&IdMes=" + ddlMeses.SelectedValue _
            + "&IdQuincena=" + ddlQnas.SelectedValue _
            + "&Origen=" + ddlTiposDeCheques.SelectedValue _
            + "&NumAfect=" + ddlCompenAfect.SelectedValue _
            + "&DescPago=" + IIf(ddlTiposDeCheques.SelectedValue = "C", ddlCompenAfect.SelectedItem.Text, ddlQnas.SelectedItem.Text) _
            + "&IdReporte=151','rptConcilPagosRecFin_" + ddlAños.SelectedValue + "_" + ddlMeses.SelectedValue + "_" + ddlQnas.SelectedValue + "_" _
                    + ddlTiposDeCheques.SelectedValue + "_" + IIf(ddlCompenAfect.SelectedValue = "-1", "1", ddlCompenAfect.SelectedValue.Replace("/", "_")) + "'); return false;"

        btnExportarEXCEL.OnClientClick = strCadena


        gvConciliacion.DataSource = oNomina.getConciliacionParaRecFin(CShort(ddlQnas.SelectedValue), CShort(ddlAños.SelectedValue), _
                                                 CByte(ddlMeses.SelectedValue), ddlTiposDeCheques.SelectedValue, _
                                                 ddlCompenAfect.SelectedValue)
        gvConciliacion.DataBind()

        mvCheques.SetActiveView(viewCheques)
        mvCheques.Visible = True
        pnlTiposDeCheques.Enabled = False
        pnlAños.Enabled = False
        pnlMeses.Enabled = False
        pnlCompenAfectacion.Enabled = False
        pnlQnas.Enabled = False
        btnConsultar.Visible = False
        btnExportarEXCEL.Visible = True

        Select Case ddlTiposDeCheques.SelectedValue
            Case "C"
                setVisibleImgenes(True, False, True, False, True, False, False, True, True, False)
                'setVisibleColumns(gvCheques, False, True, False, True, False)
                'Case "CPA"
                '    setVisibleImgenes(True, False, True, False, True, False, False, True)
                '    setVisibleColumns(gvCheques, False, False, True, True, False)
            Case "N"
                setVisibleImgenes(True, False, True, False, False, True, True, False, False, True)
                'setVisibleColumns(gvCheques, False, True, False, True, True)
                'Case "NPA"
                '    setVisibleImgenes(True, False, True, False, False, True, True, False)
                '    setVisibleColumns(gvCheques, False, False, True, False, True)
                'Case "R"
                '    setVisibleImgenes(True, False, True, False, False, True, True, False)
                '    setVisibleColumns(gvCheques, True, True, False, True, False)
            Case Else

        End Select
    End Sub
End Class