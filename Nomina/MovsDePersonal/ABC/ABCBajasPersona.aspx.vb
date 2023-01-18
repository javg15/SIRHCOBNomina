Imports DataAccessLayer.COBAEV.Empleados
Imports System.Data
Imports DataAccessLayer.COBAEV.MovsDePersonal
Imports DataAccessLayer.COBAEV.Nominas

Partial Class ABCBajasPersona
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
        Dim dt As DataTable

        dt = oMovDePers.ObtenInfTramiteMotivo(CShort(Request.Params("pIdTramite")), CShort(Request.Params("pIdMotivo")))

        If dt.Rows.Count > 0 Then
            lblH2.Text = "Sistema de nómina: Captura de " + dt.Rows(0).Item("TramiteMotivo").ToString
            txtbxFechaIni.Enabled = CBool(dt.Rows(0).Item("PedirVigIni"))
            txtbxFechaFin.Enabled = CBool(dt.Rows(0).Item("PedirVigFin"))
            If CBool(dt.Rows(0).Item("PedirVigFin")) = False Then txtbxFechaFin.Text = "31/12/2099"
            gvPlazasVigentes.DataBind()
            gvPlazasVigentes2.DataBind()
        End If
    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            Dim BtnSearch As Button = CType(wucBuscaEmps.FindControl("BtnSearch"), Button)
            Dim BtnNewSearch As Button = CType(wucBuscaEmps.FindControl("BtnNewSearch"), Button)
            Dim BtnCancelSearch As Button = CType(wucBuscaEmps.FindControl("BtnCancelSearch"), Button)
            Dim hfRFC As HiddenField = CType(wucBuscaEmps.FindControl("hfRFC"), HiddenField)
            ' Dim lblTipoBusq As Label = CType(wucBuscaEmps.FindControl("lblTipoBusq"), Label)
            Dim ddlTipoBusqueda As DropDownList = CType(wucBuscaEmps.FindControl("ddlTipoBusqueda"), DropDownList)

            'lblTipoBusq.Visible = False
            ddlTipoBusqueda.Enabled = False
            BtnSearch.Visible = False
            BtnNewSearch.Visible = False
            BtnCancelSearch.Visible = False

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

    Protected Sub gvPlazasVigentes_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvPlazasVigentes.RowDataBound
        Dim oEmpleadoPlaza As New EmpleadoPlazas
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                Dim lblIdPlaza As Label = CType(e.Row.FindControl("lblIdPlaza"), Label)
                Dim lblNombreFuncionPri As Label = CType(e.Row.FindControl("lblNombreFuncionPri"), Label)
                Dim lblNombreFuncionSec As Label = CType(e.Row.FindControl("lblNombreFuncionSec"), Label)
                Dim lblMotGralBaja As Label = CType(e.Row.FindControl("lblMotGralBaja"), Label)
                Dim ibDetalles As ImageButton = CType(e.Row.FindControl("ibDetalles"), ImageButton)
                Dim ibWarning As ImageButton = CType(e.Row.FindControl("ibWarning"), ImageButton)
                Dim imgInfTitular As Image = CType(e.Row.FindControl("imgInfTitular"), Image)
                Dim lblOcupacion As Label = CType(e.Row.FindControl("lblOcupacion"), Label)
                Dim drFuncionPriSecPorPlaza As DataRow
                Dim drMotivoGeneralDeBajaPorPlaza As DataRow
                Dim oPlaza As New EmpleadoPlazas
                Dim dtWarnings As DataTable
                Dim drInfTitular As DataRow
                Dim vlNomTitular As String

                imgInfTitular.Visible = False
                If lblOcupacion.Text = "I" Then
                    imgInfTitular.Visible = True
                    oEmpleadoPlaza.IdPlaza = CInt(lblIdPlaza.Text)
                    drInfTitular = oEmpleadoPlaza.ObtenTitular()
                    vlNomTitular = (drInfTitular("ApePatEmp") + " " + drInfTitular("ApeMatEmp") + " " + drInfTitular("NomEmp")).ToString.Trim
                    If vlNomTitular = String.Empty Then
                        vlNomTitular = "Información del titular no capturada."
                    End If
                    imgInfTitular.ToolTip = vlNomTitular
                End If

                drFuncionPriSecPorPlaza = oEmpleadoPlaza.ObtenFuncionesPri_Y_Sec(CInt(lblIdPlaza.Text))
                drMotivoGeneralDeBajaPorPlaza = oEmpleadoPlaza.ObtenMotivoGeneralDeBaja(CInt(lblIdPlaza.Text))

                lblNombreFuncionPri.Text = drFuncionPriSecPorPlaza("NombreFuncionPri").ToString
                lblNombreFuncionSec.Text = drFuncionPriSecPorPlaza("NombreFuncionSec").ToString
                lblMotGralBaja.Text = drMotivoGeneralDeBajaPorPlaza("DescMotGralBaja").ToString

                'ibDetalles.OnClientClick = "javascript:abreVentMedAncha('../../ABC/Plazas/AdministracionPlazas.aspx?TipoOperacion=4&IdPlaza=" + lblIdPlaza.Text + "'); return false;"
                ibDetalles.PostBackUrl = "../../ABC/Plazas/AdministracionPlazas.aspx?TipoOperacion=4&IdPlaza=" + lblIdPlaza.Text

                ibWarning.OnClientClick = "javascript:abreVentMedAncha('../Plazas/ObservacionesSobrePlazas.aspx?TipoOperacion=4&IdPlaza=" + lblIdPlaza.Text + "'); return false;"

                dtWarnings = oPlaza.ObtenObservaciones(CInt(lblIdPlaza.Text))
                ibWarning.Visible = dtWarnings.Rows.Count > 0
        End Select
    End Sub

    Protected Sub btnContinuar_Click(sender As Object, e As System.EventArgs) Handles btnContinuar.Click
        Dim oEmp As New Empleado
        Dim txtbxRFC As TextBox = CType(wucBuscaEmps.FindControl("txtbxRFC"), TextBox)

        txtbxFechaIni.Enabled = False
        btnContinuar.Visible = False

        gvPlazasVigentes.DataSource = oEmp.ObtenPlazasVigParaBajaPersona(txtbxRFC.Text, CDate(txtbxFechaIni.Text))
        gvPlazasVigentes.DataBind()

        gvPlazasVigentes2.DataSource = oEmp.ObtenPlazasVigParaBajaPersona(txtbxRFC.Text, CDate(txtbxFechaIni.Text))
        gvPlazasVigentes2.DataBind()

        btnContinuar2.Visible = True
    End Sub

End Class
