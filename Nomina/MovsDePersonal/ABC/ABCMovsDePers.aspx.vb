Imports DataAccessLayer.COBAEV.Empleados
Imports System.Data
Imports DataAccessLayer.COBAEV.MovsDePersonal
Imports DataAccessLayer.COBAEV.Nominas

Partial Class ABCMovsDePers
    Inherits System.Web.UI.Page
    Private Sub LlenaDDL(ByVal ddl As DropDownList, ByVal TextField As String, ByVal ValueField As String, ByVal dt As DataTable, Optional ByVal SelectedValue As String = "")
        ddl.DataSource = dt
        ddl.DataTextField = TextField
        ddl.DataValueField = ValueField
        ddl.DataBind()
        If SelectedValue <> String.Empty Then ddl.SelectedValue = SelectedValue
    End Sub
    Private Sub ConfiguraItemsPagina(Optional ByVal pIsPostBack As Boolean = False)
        Dim oMovDePers As New MovsDePersonal
        Dim oQna As New Quincenas

        Dim hfRFC As HiddenField = CType(wucBuscaEmps.FindControl("hfRFC"), HiddenField)
        Dim hfNomEmp As HiddenField = CType(wucBuscaEmps.FindControl("hfNomEmp"), HiddenField)

        LlenaDDL(ddlTramites, "DescTramite", "IdTramite", oMovDePers.ObtenTramites(), Nothing)
        LlenaDDL(ddlMotivos, "DescMotivo", "IdMotivo", oMovDePers.ObtenMotivosPorTramite(CShort(ddlTramites.SelectedValue)), Nothing)
    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            Dim hfRFC As HiddenField = CType(wucBuscaEmps.FindControl("hfRFC"), HiddenField)
            If hfRFC.Value <> String.Empty Then
                ConfiguraItemsPagina()
                pnlCaptura.Visible = True
            Else
                pnlCaptura.Visible = False
            End If
        End If
    End Sub

    Protected Sub wucBuscaEmps_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles wucBuscaEmps.PreRender
        If IsPostBack Then
            'Dim hfRFC As HiddenField = CType(wucBuscaEmps.FindControl("hfRFC"), HiddenField)
            Dim txtbxRFC As TextBox = CType(wucBuscaEmps.FindControl("txtbxRFC"), TextBox)
            'Dim txtbxNomEmp As TextBox = CType(wucBuscaEmps.FindControl("txtbxNomEmp"), TextBox)
            'Dim hfNomEmp As HiddenField = CType(wucBuscaEmps.FindControl("hfNomEmp"), HiddenField)

            If Request.Params(0).Contains("BtnSearch") Or Request.Params(1).Contains("BtnSearch") Then
                If txtbxRFC.Text.Trim <> String.Empty Then
                    pnlCaptura.Visible = True
                    ConfiguraItemsPagina(True)
                Else
                    pnlCaptura.Visible = False
                End If
            ElseIf Request.Params(0).Contains("BtnNewSearch") Or Request.Params(1).Contains("BtnNewSearch") Then
                pnlCaptura.Visible = False
            ElseIf Request.Params(0).Contains("BtnCancelSearch") Or Request.Params(1).Contains("BtnCancelSearch") Then
                pnlCaptura.Visible = True
            ElseIf Request.Params("__EVENTTARGET") Is Nothing = False Then
                If Request.Params("__EVENTTARGET").Contains("lnkbtnrfc") Then
                    ConfiguraItemsPagina(True)
                    pnlCaptura.Visible = True
                End If
            End If
        End If
    End Sub

    'Protected Sub ddlQnaInicio_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlQnaInicio.SelectedIndexChanged
    '    Dim oQna As New Quincenas
    '    If Not chkbx_EfectosAbiertos.Checked Then
    '        LlenaDDL(ddlFechaInicio, "Fecha", "Fecha", oQna.ObtenFechasPorQnaParaMovPers(CShort(ddlQnaInicio.SelectedValue)), Nothing)
    '        LlenaDDL(ddlQnaTermino, "Quincena", "IdQuincena", oQna.ObtenParaTerminoDeMovPers(CShort(Left(ddlQnaInicio.SelectedItem.Text, 4)), CShort(ddlQnaInicio.SelectedValue)), Nothing)
    '        ddlQnaTermino.SelectedValue = ddlQnaInicio.SelectedValue
    '        LlenaDDL(ddlFechaTermino, "Fecha", "Fecha", oQna.ObtenFechasPorQnaParaMovPers(CShort(ddlQnaTermino.SelectedValue), ddlFechaInicio.SelectedValue), Nothing)
    '        ddlFechaTermino.SelectedIndex = ddlFechaTermino.Items.Count - 1
    '    Else
    '        LlenaDDL(ddlFechaInicio, "Fecha", "Fecha", oQna.ObtenFechasPorQnaParaMovPers(CShort(ddlQnaInicio.SelectedValue)), Nothing)
    '    End If
    'End Sub

    'Protected Sub chkbx_EfectosAbiertos_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkbx_EfectosAbiertos.CheckedChanged
    '    Dim oQna As New Quincenas
    '    If chkbx_EfectosAbiertos.Checked Then
    '        ddlQnaTermino.Items.Clear()
    '        ddlQnaTermino.Items.Add(New ListItem("999999", "32767"))
    '        ddlQnaTermino.Enabled = False
    '        ddlFechaTermino.Items.Clear()
    '        ddlFechaTermino.Items.Add(New ListItem("31/12/2099", "31/12/2099"))
    '        ddlFechaTermino.Enabled = False
    '    Else
    '        LlenaDDL(ddlQnaTermino, "Quincena", "IdQuincena", oQna.ObtenParaTerminoDeMovPers(CShort(Left(ddlQnaInicio.SelectedItem.Text, 4)), CShort(ddlQnaInicio.SelectedValue)), Nothing)
    '        ddlQnaTermino.SelectedValue = ddlQnaInicio.SelectedValue
    '        ddlQnaTermino.Enabled = True
    '        LlenaDDL(ddlFechaTermino, "Fecha", "Fecha", oQna.ObtenFechasPorQnaParaMovPers(CShort(ddlQnaTermino.SelectedValue), ddlFechaInicio.SelectedValue), Nothing)
    '        ddlFechaTermino.SelectedIndex = ddlFechaTermino.Items.Count - 1
    '        ddlFechaTermino.Enabled = True
    '    End If
    'End Sub

    'Protected Sub ddlQnaTermino_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlQnaTermino.SelectedIndexChanged
    '    Dim oQna As New Quincenas
    '    LlenaDDL(ddlFechaTermino, "Fecha", "Fecha", oQna.ObtenFechasPorQnaParaMovPers(CShort(ddlQnaTermino.SelectedValue), ddlFechaInicio.SelectedValue), Nothing)
    '    ddlFechaTermino.SelectedIndex = ddlFechaTermino.Items.Count - 1
    'End Sub

    'Protected Sub ddlFechaInicio_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlFechaInicio.SelectedIndexChanged
    '    If Not chkbx_EfectosAbiertos.Checked Then
    '        Dim oQna As New Quincenas
    '        LlenaDDL(ddlFechaTermino, "Fecha", "Fecha", oQna.ObtenFechasPorQnaParaMovPers(CShort(ddlQnaTermino.SelectedValue), ddlFechaInicio.SelectedValue), Nothing)
    '        ddlFechaTermino.SelectedIndex = ddlFechaTermino.Items.Count - 1
    '    End If
    'End Sub

    Protected Sub ddlTramites_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlTramites.SelectedIndexChanged
        Dim oMovDePers As New MovsDePersonal
        LlenaDDL(ddlMotivos, "DescMotivo", "IdMotivo", oMovDePers.ObtenMotivosPorTramite(CShort(ddlTramites.SelectedValue)), Nothing)
    End Sub

    Protected Sub btnContinuar_Click(sender As Object, e As System.EventArgs) Handles btnContinuar.Click
        Dim oMovDePers As New MovsDePersonal

        Dim dt As DataTable

        dt = oMovDePers.ObtenInfTramiteMotivo(CShort(ddlTramites.SelectedValue), CShort(ddlMotivos.SelectedValue))

        If dt.Rows.Count > 0 Then
            Response.Redirect(dt.Rows(0).Item("URL").ToString + "?pIdTramite=" + ddlTramites.SelectedValue + "&pIdMotivo=" + ddlMotivos.SelectedValue)
        End If
    End Sub
End Class
