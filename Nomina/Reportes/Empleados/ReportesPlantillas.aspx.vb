Imports DataAccessLayer.COBAEV.Administracion
Imports DataAccessLayer.COBAEV.InformacionAcademica
Imports DataAccessLayer.COBAEV.Nominas
Imports DataAccessLayer.COBAEV
Imports System.Data
Partial Class ReportesPlantillas
    Inherits System.Web.UI.Page
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
    Private Sub BindddlMeses()
        Dim oQna As New Quincenas
        With Me.ddlMeses
            .DataSource = oQna.ObtenMesesCalculadosPorAnio(CShort(Me.ddlAños.SelectedValue))
            .DataTextField = "NombreMes"
            .DataValueField = "IdMes"
            .DataBind()
        End With
    End Sub
    Private Sub BindQuincenas(Optional ByVal MostrarAdicionales As Boolean = False)
        Dim oQna As New Quincenas
        Me.gvQuincenas.DataSource = oQna.ObtenCalculadasPorAnio(CShort(Me.ddlAños.SelectedValue), MostrarAdicionales)
        Me.gvQuincenas.DataBind()
        Me.lblMsj.Text = "Quincenas pagadas durante el año " + Me.ddlAños.SelectedItem.Text
        If Me.gvQuincenas.Rows.Count > 0 Then
            Me.gvQuincenas.SelectedIndex = 0
        End If
    End Sub
    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, ByVal dt As DataTable, Optional ByVal SelectedValue As String = "")
        ddl.DataSource = dt
        ddl.DataTextField = TextField
        ddl.DataValueField = ValueField
        ddl.DataBind()
        If SelectedValue <> String.Empty Then ddl.SelectedValue = SelectedValue
    End Sub
    Private Sub CreaLinkParaImpresion(ByVal gvr As GridViewRow)
        Dim lblIdReporte As Label = CType(gvr.FindControl("lblIdReporte"), Label)
        Dim dt As DataTable
        Dim oReporte As New Reportes
        Dim strOnClientClick As String = String.Empty
        Dim Valor As String = String.Empty
        Dim lblExportarAExcel As Label = CType(gvr.FindControl("lblExportarAExcel"), Label)
        Dim lblExportarAPDF As Label = CType(gvr.FindControl("lblExportarAPDF"), Label)
        Dim oUsr As New Usuario
        Dim drUsr As DataRow
        Dim lblImplicaMeses As Label = CType(gvr.FindControl("lblImplicaMeses"), Label)
        Dim lblImplicaQuincenas As Label = CType(gvr.FindControl("lblImplicaQuincenas"), Label)

        pnlMeses.Visible = CType(lblImplicaMeses.Text, Boolean)
        pnlQuincenas.Visible = CType(lblImplicaQuincenas.Text, Boolean)

        dt = oReporte.ObtenInfParaImpresion(CShort(lblIdReporte.Text))
        oUsr.Login = Session("Login")
        drUsr = oUsr.ObtenerPropiedadesDelRol().Rows(0)

        Dim lblIdQuincena As Label = CType(Me.gvQuincenas.SelectedRow.FindControl("lblIdQuincena"), Label)

        For Each dr As DataRow In dt.Rows
            If strOnClientClick = String.Empty Then
                strOnClientClick = "?" + dr("VariableAsociada")
            Else
                strOnClientClick = strOnClientClick + "&" + dr("VariableAsociada")
            End If
            Select Case dr("VariableAsociada").ToString
                Case "IdQuincena"
                    Valor = lblIdQuincena.Text
                Case "IdRol"
                    Valor = drUsr("IdRol").ToString
                Case "ConsZonasEsp"
                    Valor = CBool(drUsr("ConsultaZonasEspecificas")).ToString
                Case "ConsPlantelesEsp"
                    Valor = CBool(drUsr("ConsultaPlantelesEspecificos")).ToString
                Case "IdUsuario"
                    Valor = drUsr("IdUsuario").ToString
                Case "Anio"
                    Valor = ddlAños.SelectedValue
                Case "IdMes"
                    Valor = ddlMeses.SelectedValue
            End Select
            If dr("ValorDefault").ToString <> String.Empty Then
                Valor = dr("ValorDefault").ToString
            End If
            strOnClientClick = strOnClientClick + "=" + Valor
        Next

        strOnClientClick = strOnClientClick + "&IdReporte=" + lblIdReporte.Text + "','" + lblIdReporte.Text + "_" + lblIdQuincena.Text.Replace("-", "_") + "'); return false;"
        Me.ibExportarExcel.Visible = False
        Me.ibImprimir.Visible = False
        If CType(lblExportarAExcel.Text, Boolean) Then
            Me.ibExportarExcel.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportesExcel.aspx" + strOnClientClick
            Me.ibExportarExcel.Visible = True
        End If
        If CType(lblExportarAPDF.Text, Boolean) Then
            Me.ibImprimir.OnClientClick = "javascript:abreVentanaImpresion('../../VisorDeReportes.aspx" + strOnClientClick
            Me.ibImprimir.Visible = True
        End If

    End Sub

    Protected Sub gvQuincenas_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvQuincenas.RowCommand
        Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
        CreaLinkParaImpresion(gvr)
    End Sub

    Protected Sub gvQuincenas_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvQuincenas.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
                e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
                e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.gvQuincenas, "Select$" + e.Row.RowIndex.ToString)
        End Select
    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            BindddlAños()
            If Me.ddlAños.SelectedValue <> -1 Then
                BindddlMeses()
                BindQuincenas()
                BindgvReportes()
                Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
                Dim oUsr As New Usuario
                Dim drUsr As DataRow

                'CreaLinkParaImpresion(gvr)

                Dim lblIdReporte As Label = CType(gvr.FindControl("lblIdReporte"), Label)

                oUsr.Login = Session("Login")
                drUsr = oUsr.ObtenerPropiedadesDelRol().Rows(0)

                If CByte(drUsr("IdRol")) = 1 Or CByte(drUsr("IdRol")) = 13 Or CByte(drUsr("IdRol")) = 36 Then
                    If lblIdReporte.Text = "98" Then
                        BindQuincenas(True)
                        CreaLinkParaImpresion(gvr)
                    Else
                        If Session("vsIdReporteAnt") = "98" Then BindQuincenas()
                        CreaLinkParaImpresion(gvr)
                    End If
                Else
                    If Session("vsIdReporteAnt") = "98" Then BindQuincenas()
                    CreaLinkParaImpresion(gvr)
                End If
                Session.Remove("vsIdReporteAnt")
            End If
        End If
    End Sub

    Protected Sub btnConsultarQuincenas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultarQuincenas.Click
        'BindQuincenas()
        Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
        'CreaLinkParaImpresion(gvr)
        Dim oUsr As New Usuario
        Dim drUsr As DataRow

        Dim lblIdReporte As Label = CType(gvr.FindControl("lblIdReporte"), Label)

        oUsr.Login = Session("Login")
        drUsr = oUsr.ObtenerPropiedadesDelRol().Rows(0)

        If CByte(drUsr("IdRol")) = 1 Or CByte(drUsr("IdRol")) = 13 Or CByte(drUsr("IdRol")) = 36 Then
            If lblIdReporte.Text = "98" Then
                BindddlMeses()
                BindQuincenas(True)
                CreaLinkParaImpresion(gvr)
            Else
                'If Session("vsIdReporteAnt") = "98" Then
                BindddlMeses()
                BindQuincenas()
                CreaLinkParaImpresion(gvr)
            End If
        Else
            'If Session("vsIdReporteAnt") = "98" Then 
            BindddlMeses()
            BindQuincenas()
            CreaLinkParaImpresion(gvr)
        End If
        Session.Remove("vsIdReporteAnt")
    End Sub

    Protected Sub gvQuincenas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvQuincenas.SelectedIndexChanged
        Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
        CreaLinkParaImpresion(gvr)
    End Sub

    Protected Sub gvReportes_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvReportes.SelectedIndexChanged
        Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
        Dim gvrQna As GridViewRow = Me.gvQuincenas.SelectedRow
        Dim oUsr As New Usuario
        Dim drUsr As DataRow

        'CreaLinkParaImpresion(gvr)

        Dim lblIdReporte As Label = CType(gvr.FindControl("lblIdReporte"), Label)

        oUsr.Login = Session("Login")
        drUsr = oUsr.ObtenerPropiedadesDelRol().Rows(0)

        If CByte(drUsr("IdRol")) = 1 Or CByte(drUsr("IdRol")) = 13 Or CByte(drUsr("IdRol")) = 36 Then
            If lblIdReporte.Text = "98" Then
                BindQuincenas(True)
                CreaLinkParaImpresion(gvr)
            Else
                If Session("vsIdReporteAnt") = "98" Then BindQuincenas()
                CreaLinkParaImpresion(gvr)
            End If
        Else
            If Session("vsIdReporteAnt") = "98" Then BindQuincenas()
            CreaLinkParaImpresion(gvr)
        End If
        Session.Remove("vsIdReporteAnt")
    End Sub

    Protected Sub gvReportes_SelectedIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles gvReportes.SelectedIndexChanging
        Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
        Session.Add("vsIdReporteAnt", CType(gvr.FindControl("lblIdReporte"), Label).Text)
    End Sub

    Protected Sub ddlMeses_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlMeses.SelectedIndexChanged
        Dim gvr As GridViewRow = Me.gvReportes.SelectedRow
        CreaLinkParaImpresion(gvr)
    End Sub
End Class