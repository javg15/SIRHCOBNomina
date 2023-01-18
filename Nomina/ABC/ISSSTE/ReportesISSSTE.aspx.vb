Imports DataAccessLayer.COBAEV.Administracion
Imports DataAccessLayer.COBAEV.InformacionAcademica
Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV
Imports System.Data
Imports System.IO
Imports System.IO.Stream
Imports System.IO.StreamWriter
 
Partial Class ReportesISSSTE
    Inherits System.Web.UI.Page
    Private Sub BindddlRegimenPensISSSTE()
        Dim oRegimenISSSTE As New ISSSTE
        With Me.ddlRegimenPensISSSTE
            .DataSource = oRegimenISSSTE.ObtenTodos()
            .DataTextField = "RegimenISSSTE"
            .DataValueField = "IdRegimenISSSTE"
            .DataBind()
        End With
    End Sub
    Private Sub BindgvReportes()
        Dim oAplic As New Aplicacion
        Dim drPagina As DataRow
        Dim oReporte As New Reportes
        drPagina = oAplic.ObtenInfSobrePagina(Request.Url.Segments(Request.Url.Segments.Length - 1).ToString)
        Me.gvReportes.DataSource = oReporte.ObtenPorPagina(CShort(drPagina("IdPagina")))
        Me.gvReportes.DataBind()
        Me.gvReportes.SelectedIndex = 0
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
                Me.btnConsultarQuincenas.Enabled = False
            Else
                Me.btnConsultarQuincenas.Enabled = True
            End If
        End With
    End Sub
    Private Sub BindQuincenas()
        Dim oQna As New Quincenas
        Me.gvQuincenas.DataSource = oQna.ObtenCalculadasPorAnioConISSSTE(CShort(Me.ddlAños.SelectedValue))
        Me.gvQuincenas.DataBind()
        Me.lblMsj.Text = "Quincenas pagadas durante el año " + Me.ddlAños.SelectedItem.Text
        If Me.gvQuincenas.Rows.Count > 0 Then
            Me.gvQuincenas.SelectedIndex = 0
        Else
            Me.gvQuincenas.EmptyDataText = "No existen quincenas con descuentos ISSSTE en el año " + ddlAños.SelectedValue
            Me.gvQuincenas.DataBind()
        End If
    End Sub
    Private Sub CreaLinkParaImpresion(ByVal gvr As GridViewRow)
        If Me.gvQuincenas.Rows.Count = 0 Then
            ddlRegimenPensISSSTE.Enabled = False
            gvReportes.Enabled = False
            ibExportPDF.Enabled = False
            ibExportarExcel.Enabled = False
            Exit Sub
        Else
            ddlRegimenPensISSSTE.Enabled = True
            gvReportes.Enabled = True
            ibExportPDF.Enabled = True
            ibExportarExcel.Enabled = True
        End If
        Dim lblIdReporte As Label = CType(gvr.FindControl("lblIdReporte"), Label)
        Dim dt As DataTable
        Dim oReporte As New Reportes
        Dim strOnClientClick As String = String.Empty
        Dim Valor As String = String.Empty
        Dim lblExportarAExcel As Label = CType(gvr.FindControl("lblExportarAExcel"), Label)
        Dim lblExportarAPDF As Label = CType(gvr.FindControl("lblExportarAPDF"), Label)
        Dim lblImplicaRegPenISSSTE As Label = CType(gvr.FindControl("lblImplicaRegPenISSSTE"), Label)
        Dim lblPorEmpleado As Label = CType(gvr.FindControl("lblPorEmpleado"), Label)

        Me.pnlRegPenISSSTE.Enabled = CType(lblImplicaRegPenISSSTE.Text, Boolean)

        dt = oReporte.ObtenInfParaImpresion(CShort(lblIdReporte.Text))

        Dim lblIdQuincena As Label = CType(Me.gvQuincenas.SelectedRow.FindControl("lblIdQuincena"), Label)
        Dim txtbxNumEmp As TextBox = CType(Me.wucSearchEmps1.FindControl("txtbxNumEmp"), TextBox)
        For Each dr As DataRow In dt.Rows
            If strOnClientClick = String.Empty Then
                strOnClientClick = "?" + dr("VariableAsociada")
            Else
                strOnClientClick = strOnClientClick + "&" + dr("VariableAsociada")
            End If
            Select Case dr("VariableAsociada").ToString
                Case "IdQuincena"
                    Valor = lblIdQuincena.Text
                Case "IdRegimenISSSTE1"
                    Valor = Me.ddlRegimenPensISSSTE.SelectedValue
                Case "IdRegimenISSSTE2"
                    Valor = Me.ddlRegimenPensISSSTE.SelectedValue
                Case "NumEmp"
                    If chbxRptParaEmp.Checked Then
                        Valor = IIf(txtbxNumEmp.Text.Trim <> String.Empty, txtbxNumEmp.Text.Trim, Nothing)
                    Else
                        Valor = Nothing
                    End If
            End Select
            If dr("ValorDefault").ToString <> String.Empty Then
                Valor = dr("ValorDefault").ToString
            End If
            If Valor Is Nothing = False Then
                strOnClientClick = strOnClientClick + "=" + Valor
            Else
                strOnClientClick = strOnClientClick.Replace("?" + dr("VariableAsociada").ToString, String.Empty)
                strOnClientClick = strOnClientClick.Replace("&" + dr("VariableAsociada").ToString, String.Empty)
            End If
        Next
        strOnClientClick = strOnClientClick + "&IdReporte=" + lblIdReporte.Text + "','" + lblIdReporte.Text + "_" + lblIdQuincena.Text.Replace("-", "_") + "'); return false;"
        chbxRptParaEmp.Enabled = CType(lblPorEmpleado.Text, Boolean)
        If chbxRptParaEmp.Checked And Not CType(lblPorEmpleado.Text, Boolean) Then
            chbxRptParaEmp.Checked = CType(lblPorEmpleado.Text, Boolean)
        End If
        pnlEmp.Visible = chbxRptParaEmp.Checked And CType(lblPorEmpleado.Text, Boolean)
        wucSearchEmps1.Visible = chbxRptParaEmp.Checked And CType(lblPorEmpleado.Text, Boolean)

        Dim txtbxRFC As TextBox = CType(Me.wucSearchEmps1.FindControl("txtbxRFC"), TextBox)

        Me.ibExportarExcel.Visible = False
        Me.ibExportPDF.Visible = False
        If CType(lblExportarAExcel.Text, Boolean) Then
            Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" + strOnClientClick
            Me.ibExportarExcel.Visible = True
            If chbxRptParaEmp.Checked Then ibExportarExcel.Visible = txtbxRFC.Text <> String.Empty
        End If
        If CType(lblExportarAPDF.Text, Boolean) Then
            Me.ibExportPDF.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" + strOnClientClick
            Me.ibExportPDF.Visible = True
            If chbxRptParaEmp.Checked Then Me.ibExportPDF.Visible = txtbxRFC.Text <> String.Empty
        End If
    End Sub
    'Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, ByVal dt As DataTable, ByVal SelectedValue As String)
    '    ddl.DataSource = dt
    '    ddl.DataTextField = TextField
    '    ddl.DataValueField = ValueField
    '    ddl.DataBind()
    '    If SelectedValue Is Nothing = False Then ddl.SelectedValue = SelectedValue
    'End Sub
    Protected Sub gvQuincenas_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvQuincenas.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End Select
    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            Dim oPlantel As New Plantel
            BindddlAños()
            If Me.ddlAños.SelectedValue <> -1 Then
                BindQuincenas()
                BindddlRegimenPensISSSTE()
                BindgvReportes()
                Dim gvr As GridViewRow = Me.gvReportes.SelectedRow

                CreaLinkParaImpresion(gvr)

                gvReportesSelectedIndexChanged(gvr)
            End If
        End If
    End Sub

    Protected Sub btnConsultarQuincenas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultarQuincenas.Click
        BindQuincenas()
        Dim gvr As GridViewRow = Me.gvReportes.SelectedRow

        CreaLinkParaImpresion(gvr)

        gvReportesSelectedIndexChanged(gvr)
    End Sub
    Protected Sub gvQuincenas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim gvr As GridViewRow = Me.gvReportes.SelectedRow

        CreaLinkParaImpresion(gvr)

        gvReportesSelectedIndexChanged(gvr)
    End Sub

    Private Sub gvReportesSelectedIndexChanged(ByVal gvr As GridViewRow)
        Dim oUsr As New Usuario
        Dim oReporte As New Reportes
        Dim drReporte As DataRow

        Dim vlIdReporte As Short = CShort(CType(gvr.FindControl("lblIdReporte"), Label).Text)

        If oUsr.EsAdministrador(Session("Login")) Or oUsr.EsVIP(Session("Login")) Or oUsr.EsAnalistaDeSegSoc(Session("Login")) Then
            drReporte = oReporte.ObtenOpcionesVarias(vlIdReporte)
            chbxRptParaEmp.Enabled = CBool(drReporte("PermiteImpPorEmp"))
            pnlFchImpRpt.Visible = CBool(drReporte("PedirFechaDeImp")) And CBool(drReporte("PermiteImpPorEmp")) And chbxRptParaEmp.Checked
            lblFechaImp.Text = drReporte("TextoParaPedirFecha").ToString
            Session.Remove("pFchImpRpt")
            txtbxFchImpRpt.Text = String.Empty
        Else
            chbxRptParaEmp.Enabled = False
            pnlFchImpRpt.Visible = False
        End If

    End Sub

    Protected Sub gvReportes_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvReportes.SelectedIndexChanged

        Dim gvr As GridViewRow = Me.gvReportes.SelectedRow

        CreaLinkParaImpresion(gvr)

        gvReportesSelectedIndexChanged(gvr)
    End Sub

    Protected Sub ddlRegimenPensISSSTE_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim gvr As GridViewRow = Me.gvReportes.SelectedRow

        CreaLinkParaImpresion(gvr)

        gvReportesSelectedIndexChanged(gvr)
    End Sub

    Protected Sub chbxRptParaEmp_CheckedChanged(sender As Object, e As System.EventArgs) Handles chbxRptParaEmp.CheckedChanged
        Dim gvr As GridViewRow = gvReportes.SelectedRow
        Dim oUsr As New Usuario
        Dim oReporte As New Reportes
        Dim drReporte As DataRow

        'Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
        CreaLinkParaImpresion(gvr)

        Dim vlIdReporte As Short = CShort(CType(gvr.FindControl("lblIdReporte"), Label).Text)

        pnlEmp.Visible = chbxRptParaEmp.Checked
        wucSearchEmps1.Visible = chbxRptParaEmp.Checked

        If oUsr.EsAdministrador(Session("Login")) Or oUsr.EsVIP(Session("Login")) Or oUsr.EsAnalistaDeSegSoc(Session("Login")) Then
            drReporte = oReporte.ObtenOpcionesVarias(vlIdReporte)
            chbxRptParaEmp.Enabled = CBool(drReporte("PermiteImpPorEmp"))
            pnlFchImpRpt.Visible = CBool(drReporte("PedirFechaDeImp")) And CBool(drReporte("PermiteImpPorEmp")) And chbxRptParaEmp.Checked
            lblFechaImp.Text = drReporte("TextoParaPedirFecha").ToString
            Session.Remove("pFchImpRpt")
            txtbxFchImpRpt.Text = String.Empty
        End If

    End Sub

    Protected Sub wucSearchEmps1_PreRender(sender As Object, e As System.EventArgs) Handles wucSearchEmps1.PreRender
        If IsPostBack Then
            Dim txtbxRFC As TextBox = CType(Me.wucSearchEmps1.FindControl("txtbxRFC"), TextBox)
            If Request.Params(0).Contains("BtnSearch") Then
                If txtbxRFC.Text.Trim <> String.Empty Then
                    Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
                    CreaLinkParaImpresion(gvr)
                    gvReportesSelectedIndexChanged(gvr)
                Else
                    'pnl1.Visible = False
                End If
            ElseIf Request.Params(0).Contains("BtnNewSearch") Then
                Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
                CreaLinkParaImpresion(gvr)
                gvReportesSelectedIndexChanged(gvr)
            ElseIf Request.Params(0).Contains("BtnCancelSearch") Then
                Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
                CreaLinkParaImpresion(gvr)
                gvReportesSelectedIndexChanged(gvr)
            ElseIf Request.Params("__EVENTTARGET") Is Nothing = False Then
                If Request.Params("__EVENTTARGET").Contains("lnkbtnrfc") Then
                    Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
                    CreaLinkParaImpresion(gvr)
                    gvReportesSelectedIndexChanged(gvr)
                End If
            End If
        End If
    End Sub
    Protected Sub txtbxFchImpRpt_TextChanged(sender As Object, e As System.EventArgs) Handles txtbxFchImpRpt.TextChanged
        If IsDate(txtbxFchImpRpt.Text.Trim) Then
            Session.Add("pFchImpRpt", txtbxFchImpRpt.Text)
        Else
            Session.Remove("pFchImpRpt")
        End If
    End Sub
End Class